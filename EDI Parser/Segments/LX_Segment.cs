using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("LX")]
    public class LX_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string AssignedNumber { get; set; }
    }
}
