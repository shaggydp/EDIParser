using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("ISA")]
    public class ISA_Segment:SegmentBase
    {
        [PositionIndex(1)]
        public string AuthorizationInformationQualifier { get; set; }
        [PositionIndex(2)]
        public string AuthorizationInformation { get; set; }
        [PositionIndex(3)]
        public string SecurityInformationQualifier { get; set; }
        [PositionIndex(4)]
        public string SecurityInformation { get; set; }
        [PositionIndex(5)]
        public string SenderIDQualifier { get; set; }
        [PositionIndex(6)]
        public string InterchangeSenderID { get; set; }
        [PositionIndex(7)]
        public string ReceverIDQualifier { get; set; }
        [PositionIndex(8)]
        public string InterchangeReceiverID { get; set; }
        [PositionIndex(10)]
        public string InterchangeTime { get; set; }
        [PositionIndex(11)]
        public string RepetitionSeparator { get; set; }
        [PositionIndex(12)]
        public string InterchangeControlVersionNumber { get; set; }
        [PositionIndex(13)]
        public string InterchangeControlNumber { get; set; }
        [PositionIndex(14)]
        public string AcknowledgementRequired { get; set; }
        [PositionIndex(15)]
        public string UsageIndicator { get; set; }
        [PositionIndex(16)]
        public string ComponentElementSeparator { get; set; }
    }
}
