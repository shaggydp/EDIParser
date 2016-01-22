using EDI_Parser.Attributes;
using EDI_Parser.Messages;
using EDI_Parser.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser
{
    public class TransactionSet
    {
        public int position = 0;
        private EDIParser eDIParser;
        public List<SegmentBase> Segments { get; set; }
        public ST_Segment Header { get; set; }
        public SE_Segment Footer { get; set; }        

        public TransactionSet(EDIParser eDIParser)
        {
            this.Segments = new List<SegmentBase>();            
            this.eDIParser = eDIParser;
        }

        internal void AddSegment(Segments.SegmentBase segment)
        {
            switch (segment.SegmentID)
            {
                case "ST":
                    this.Header = segment as ST_Segment;
                    break;
                case "SE":
                    this.Footer = segment as SE_Segment;
                    break;               
                default:
                    this.Segments.Add(segment);
                    break;
            }
        }
        public MessageBase GetMessage()
        {
            return this.eDIParser.GetMessage(this);       
           
        }
        
    }
}
