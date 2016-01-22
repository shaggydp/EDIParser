using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
     [SegmentId("IEA")]
    public class IEA_Segment:SegmentBase
    {
        [PositionIndex(1)]
        public string NumberofFunctionalGroupSets { get; set; }
        [PositionIndex(2)]
        public string InterchangeControlNumber { get; set; }
    }
}
