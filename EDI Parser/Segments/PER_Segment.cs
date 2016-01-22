using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("PER")]
    public class PER_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string ContactFunctionalCode { get; set; }
        [PositionIndex(2)]
        public string ContactName { get; set; }
        [PositionIndex(3)]
        public string CommunicationNumberQualifier1 { get; set; }
        [PositionIndex(4)]
        public string CommunicationNumber1 { get; set; }
        [PositionIndex(5)]
        public string CommunicationNumberQualifier2 { get; set; }
        [PositionIndex(6)]
        public string CommunicationNumber2 { get; set; }
        [PositionIndex(7)]
        public string CommunicationNumberQualifier3 { get; set; }
        [PositionIndex(8)]
        public string CommunicationNumber3{ get; set; }
        [PositionIndex(9)]
        public string ContactInquiryReference { get; set; }
    }
}
