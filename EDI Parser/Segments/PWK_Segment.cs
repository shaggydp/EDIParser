using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("PWK")]
    public class PWK_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string ReportTypeCode { get; set; }
        [PositionIndex(2)]
        public string ReportTransmissionCode { get; set; }
        [PositionIndex(5)]
        public string IdentificationCodeQualifier { get; set; }
        [PositionIndex(6)]
        public string IdentificationCode { get; set; }
        
    }
}
