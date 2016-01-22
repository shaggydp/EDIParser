using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("GS")]
    public class GS_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string FunctionalIDCode { get; set; }
        [PositionIndex(2)]
        public string ApplicationSendersCode { get; set; }
        [PositionIndex(3)]
        public string ApplicationReceiversCode { get; set; }
        [PositionIndex(4)]
        public string Date { get; set; }
        [PositionIndex(5)]
        public string Time { get; set; }
        [PositionIndex(6)]
        public string GroupControlNumber { get; set; }
        [PositionIndex(7)]
        public string ResponsibleAgencyCode { get; set; }
        [PositionIndex(8)]
        public string Version { get; set; }
    }
}
