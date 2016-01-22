using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Attributes
{
    public class FieldCheckAttribute : Attribute
    {
        public FieldCheckAttribute(string segmentId, string field,string value)
        {
            this.SegmentId = segmentId;
            this.Field = field;
            this.Value = value;
        }

        public string SegmentId { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }

        internal bool Valid(Segments.SegmentBase segmentBase)
        {
            if(this.SegmentId!=segmentBase.SegmentID)
                return false;
            System.Reflection.PropertyInfo ret=null;
            if(this.Value==null)
                ret = segmentBase.GetType().GetProperties().Where(a => a.Name == this.Field && a.GetValue(segmentBase)==null).FirstOrDefault();
            else
                ret= segmentBase.GetType().GetProperties().Where(a => a.Name == this.Field && this.Value.Equals(a.GetValue(segmentBase))).FirstOrDefault();
            if (ret == null)
                return false;
            return true;        
            
        }
        
    }
}
