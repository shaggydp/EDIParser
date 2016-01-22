using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("SBR")]
    public class SBR_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string PayerResponsibilitySequenceNumberCode { get; set; }
        [PositionIndex(2)]
        public string IndividualRelationshipCode { get; set; }
        [PositionIndex(3)]
        public string ReferenceIdentification { get; set; }
        [PositionIndex(4)]
        public string Name { get; set; }
        [PositionIndex(9)]
        public string ClaimFilingIndicatorCode { get; set; }        
    }
}
