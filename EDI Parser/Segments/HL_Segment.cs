using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("HL")]
    public class HL_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string HierarchicalIDNumber { get; set; }
        [PositionIndex(2)]
        public string HierarchicalParentIDNumber { get; set; }
        [PositionIndex(3)]
        public string HierarchicalLevelCodeID { get; set; }
        [PositionIndex(4)]
        public string HierarchicalChildCodeID { get; set; }
    }
}
