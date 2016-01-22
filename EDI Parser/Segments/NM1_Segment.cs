using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("NM1")]
    public class NM1_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string EntityIdentifierCode { get; set; }
        [PositionIndex(2)]
        public string EntityTypeQualifierID { get; set; }
        [PositionIndex(3)]
        public string NameLast { get; set; }
        [PositionIndex(4)]
        public string NameFirst { get; set; }
        [PositionIndex(5)]
        public string NameMiddle { get; set; }
        [PositionIndex(6)]
        public string NamePrefix { get; set; }
        [PositionIndex(7)]
        public string NameSuffix { get; set; }
        [PositionIndex(8)]
        public string IdentificationCodeQualifier { get; set; }
        [PositionIndex(9)]
        public string IdentificationCode { get; set; }
    }
}
