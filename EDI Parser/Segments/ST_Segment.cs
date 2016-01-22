using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("ST")]
    public class ST_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string TransactionSetIDCode { get; set; }
        [PositionIndex(2)]
        public string TransactionSetControlNumber { get; set; }
        [PositionIndex(3)]
        public string ImplementationConventionReference { get; set; }
    
    }
}
