using EDI_Parser.Attributes;
using EDI_Parser.Messages;
using EDI_Parser.Segments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser
{
    public class EDIParser
    {
        public class Seperators
        {
            public char DataElement { get; set; }
            public char ComponentDataElement { get; set; }
            public char Repetition { get; set; }
            public char Segment { get; set; }
        }
        public Seperators CurrentSeperators { get; private set; }
        public ISA_Segment InterchangeHeader { get; set; }
        public IEA_Segment InterchangeFooter { get; set; }
        public List<Group> Groups { get; set; }

        internal Dictionary<string, Type> SegmentDefinitions { get; set; }
        internal Dictionary<string, Type> MessageDefinitions { get; set; }
        public List<SegmentBase> Segments { get; set; }
        public EDIParser()
        {
            Groups = new List<Group>();
            Segments = new List<SegmentBase>();
            SegmentDefinitions = new Dictionary<string, Type>();
            MessageDefinitions = new Dictionary<string, Type>();
            var type = typeof(SegmentBase);
            foreach (Type segBase in AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p)))
            {
                SegmentIdAttribute idAtt = Attribute.GetCustomAttribute(segBase, typeof(SegmentIdAttribute)) as SegmentIdAttribute;

                if (idAtt != null)
                    SegmentDefinitions.Add(idAtt.Id, segBase);
            }

            type = typeof(MessageBase);
            foreach (Type segBase in AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p)))
            {
                MessageTypeAttribute idAtt = Attribute.GetCustomAttribute(segBase, typeof(MessageTypeAttribute)) as MessageTypeAttribute;

                if (idAtt != null)
                    MessageDefinitions.Add(idAtt.MessageType, segBase);
            }

        }
        public void LoadFile(TextReader reader)
        {
            this.CurrentSeperators = new Seperators();
            char[] charData = new char[105];
            int count = reader.Read(charData, 0, 105);
            if (count != 105)
                throw new Exception("File is not long enough");
            string isaString = new String(charData);
            if (isaString.Substring(0, 3) != "ISA")
                throw new Exception("This File does not start with an ISA Segment");
            CurrentSeperators.DataElement = isaString[3];
            string[] isaFields = isaString.Split(CurrentSeperators.DataElement);
            CurrentSeperators.ComponentDataElement = isaFields[16].First();
            CurrentSeperators.Repetition = isaFields[11] == "U" ? '~' : isaFields[11].First();
            this.CurrentSeperators.Segment = (char)reader.Read();
            this.InterchangeHeader = ParseUsingPosition(typeof(ISA_Segment), isaFields) as ISA_Segment;
            string[] segments = reader.ReadToEnd().Split(this.CurrentSeperators.Segment);

            foreach (string segment in segments)
            {
                string[] fields = segment.Trim(new char[] { '\r', '\n', ' ' }).Split(CurrentSeperators.DataElement);
                Type tp;
                if (SegmentDefinitions.TryGetValue(fields[0], out tp))
                {
                    SegmentBase segmentbase = ParseUsingPosition(tp, fields);
                    switch (segmentbase.SegmentID)
                    {
                        case "IEA":
                            this.InterchangeFooter = segmentbase as IEA_Segment;
                            break;
                        case "GS":
                            this.Groups.Add(new Group(this));
                            this.Groups.Last().AddSegment(segmentbase);
                            break;
                        default:
                            this.Groups.Last().AddSegment(segmentbase);
                            break;
                    }


                }
            }

        }

        private SegmentBase ParseUsingPosition(Type type, string[] fields)
        {

            SegmentBase ret = Activator.CreateInstance(type) as SegmentBase;
            foreach (PropertyInfo p in ret.GetType().GetProperties())
            {
                PositionIndexAttribute pos = p.GetCustomAttributes().Where(a => a is PositionIndexAttribute).FirstOrDefault() as PositionIndexAttribute;
                if (pos != null && pos.Index < fields.Length)
                {
                    if (p.PropertyType.GetInterfaces().Contains(typeof(IComplexField)))
                    {
                       IComplexField complexField=  Activator.CreateInstance(p.PropertyType) as IComplexField;
                       this.UpdateComplexField(complexField, fields[pos.Index]);
                       p.SetValue(ret, complexField);

                    }
                    else
                        p.SetValue(ret, fields[pos.Index]);
                }
            }
            return ret;
        }

        private void UpdateComplexField(IComplexField complexField, string data)
        {
            string[] fields = data.Split(CurrentSeperators.ComponentDataElement);
            foreach (PropertyInfo p in complexField.GetType().GetProperties())
            {
                PositionIndexAttribute pos = p.GetCustomAttributes().Where(a => a is PositionIndexAttribute).FirstOrDefault() as PositionIndexAttribute;
                if (pos != null && pos.Index < fields.Length)
                {
                    p.SetValue(complexField, fields[pos.Index]);
                }
            }
        }
        private bool ValidateFieldChecks(List<FieldCheckAttribute> checks,SegmentBase segment)
        {
            foreach (FieldCheckAttribute att in checks)
            {
                if (!ValidateFieldChecks(att,segment))
                    return false;
            }
            return true;
        }
        private bool ValidateFieldChecks(FieldCheckAttribute check, SegmentBase segment)
        {
            if (!check.Valid(segment))
                return false;
            return true;
        }

        /// <summary>
        /// Uses Reflection to search through and get the MessageBase Object that matches
        /// </summary>
        /// <param name="transactionSet"></param>
        /// <returns>MessageBase object</returns>
        internal MessageBase GetMessage(TransactionSet transactionSet)
        {
            string messageType = transactionSet.Header.ImplementationConventionReference;
            Type tp;//005010X222A1
            if (this.MessageDefinitions.TryGetValue(messageType, out tp))
            {
                MessageBase ret = Activator.CreateInstance(tp) as MessageBase;
                SetProperty(transactionSet.Segments,0, ret);
                return ret;
            }
            return null;
        }
        /// <summary>
        /// actual Meet it cycles through the segments and gets the associated segments and multi level if need be
        /// </summary>
        /// <param name="segments"></param>
        /// <param name="position"></param>
        /// <param name="setObject"></param>
        /// <param name="parentFieldChecks"></param>
        /// <returns></returns>
        private int SetProperty(List<SegmentBase> segments,int position, Object setObject, List<FieldCheckAttribute> parentFieldChecks = null)
        {
            if (setObject == null)
                return position;

            int segmentPosition = position;
            var sets = setObject.GetType().GetProperties()
                   .Where(a => a.GetCustomAttributes().Where(b => b is PositionIndexAttribute).FirstOrDefault() != null)
                   .Select(a => new
                   {
                       Property = a,
                       Index = (a.GetCustomAttributes().Where(b => b is PositionIndexAttribute).FirstOrDefault() as PositionIndexAttribute).Index,
                       FieldChecks = (a.GetCustomAttributes().Where(b => b is FieldCheckAttribute)).Select(b => b as FieldCheckAttribute).ToList()
                   })
                   .OrderBy(a => a.Index);

            if (setObject is SegmentBase)
            {
                throw new Exception("ERROR");
            }
            foreach (var p in sets)
            {
                if (p.Property.PropertyType.GetInterfaces().Contains(typeof(System.Collections.IList)) && p.Property.PropertyType.IsGenericType)
                {                   
                    Type type = p.Property.PropertyType.GetGenericArguments().FirstOrDefault();
                    System.Collections.IList  list= (System.Collections.IList)p.Property.GetValue(setObject);                  
                  
                    if (list == null)
                        continue;
                    //list.Add()
                    int retPos = segmentPosition;                    
                    do
                    {
                        List < FieldCheckAttribute >  check =new List<FieldCheckAttribute>(p.FieldChecks.ToArray());
                        segmentPosition = retPos;
                        if (!type.IsSubclassOf(typeof(SegmentBase)))
                        {
                            //Complex Object     
                            object val = Activator.CreateInstance(type);                                                   
                            retPos = SetProperty(segments, segmentPosition, val, check);
                            if (retPos != segmentPosition && check.Count == 0)
                            {
                                list.Add(val);
                            }
                        }
                        else if (type.IsAssignableFrom(segments[segmentPosition].GetType()))
                        {

                        }

                    } while (segmentPosition != retPos);
                    
                }
                else if (!p.Property.PropertyType.IsSubclassOf(typeof(SegmentBase)))
                {
                    object val = Activator.CreateInstance(p.Property.PropertyType);
                    int retPos = SetProperty(segments,segmentPosition, val, p.FieldChecks);
                    if (retPos != segmentPosition && p.FieldChecks.Count == 0)
                    {
                        p.Property.SetValue(setObject, val);
                        segmentPosition = retPos;
                    }
                }
                else if (p.Property.PropertyType.IsAssignableFrom(segments[segmentPosition].GetType()))
                {
                    bool success = ValidateFieldChecks(p.FieldChecks, segments[segmentPosition]);                   
                    if (parentFieldChecks != null)
                    {
                        for (int i = 0; i < parentFieldChecks.Count;i++ )
                        {
                            if (segments[segmentPosition].SegmentID == parentFieldChecks[i].SegmentId)
                            {                                
                                if (!ValidateFieldChecks(parentFieldChecks[i], segments[segmentPosition]))
                                    segmentPosition= position;
                                parentFieldChecks.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    if (success)
                    {
                        p.Property.SetValue(setObject, segments[segmentPosition]);
                        segmentPosition++;
                    }
                }
            }
            return segmentPosition;
        }    
        
    }
}
