using EDI_Parser.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser
{
    public class Group
    {
        private EDIParser eDIParser;
        public List<TransactionSet> TransactionSet { get; set; }       
        public Group(EDIParser eDIParser)
        {
            // TODO: Complete member initialization
            this.eDIParser = eDIParser;
            this.TransactionSet = new List<TransactionSet>();
        }
        public void AddSegment(SegmentBase segment)
        {
            switch(segment.SegmentID)
            {
                case "GS":
                    this.Header = segment as GS_Segment;
                    break;
                case "GE":
                    this.Footer = segment as GE_Segment;
                    break;
                case "ST":                
                    this.TransactionSet.Add(new TransactionSet(this.eDIParser));
                    this.TransactionSet.Last().AddSegment(segment);
                    break;
                default:
                    this.TransactionSet.Last().AddSegment(segment);
                    break;
            }
        }
        public GS_Segment Header { get; set; }
        public GE_Segment Footer { get; set; }
    }
}
