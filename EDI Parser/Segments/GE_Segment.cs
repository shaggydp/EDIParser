using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("GE")]
    public class GE_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string NumberofTransactionSets { get; set; }
        [PositionIndex(2)]
        public string GroupControlNumber { get; set; }
    }
    
}
