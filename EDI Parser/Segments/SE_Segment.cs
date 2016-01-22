using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("SE")]
    public class SE_Segment:SegmentBase
    {
        [PositionIndex(1)]
        public string NumberofIncludedSegments{get;set;}
        [PositionIndex(2)]
        public string TransactionSetControlNumber { get; set; }
    }
}
