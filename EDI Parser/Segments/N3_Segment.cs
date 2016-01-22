using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("N3")]
    public class N3_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string AddressLine1 { get; set; }
        [PositionIndex(2)]
        public string AddressLine2 { get; set; }        
    }
}
