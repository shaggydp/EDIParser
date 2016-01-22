using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("AMT")]
    public class AMT_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string AmountQualifierCode { get; set; }
        [PositionIndex(2)]
        public string MonetaryAmount { get; set; }       
    }
}
