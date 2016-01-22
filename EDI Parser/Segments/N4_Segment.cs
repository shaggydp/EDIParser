using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("N4")]
    public class N4_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string City { get; set; }
        [PositionIndex(2)]
        public string State { get; set; }
        [PositionIndex(3)]
        public string PostalCode { get; set; }       
    }
}
