using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("BHT")]
    public class BHT_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string HierarchicalStructureCodeID { get; set; }
        [PositionIndex(2)]
        public string TransactionSetPurposeCodeID { get; set; }
        [PositionIndex(3)]
        public string ReferenceIdentification { get; set; }
        [PositionIndex(4)]
        public string Date { get; set; }
        [PositionIndex(5)]
        public string InterchangeIDQualifier { get; set; }
        [PositionIndex(6)]
        public string TransactionTypeCodeID { get; set; }
    }
}
