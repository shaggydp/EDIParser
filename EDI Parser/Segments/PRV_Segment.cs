using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("PRV")]
    public class PRV_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string ProviderCode { get; set; }
        [PositionIndex(2)]
        public string ReferenceIdQualifier { get; set; }
        [PositionIndex(3)]
        public string ProviderSpecialtyCode { get; set; }
        [PositionIndex(4)]
        public string StateCode { get; set; }
        [PositionIndex(5)]
        public string ProviderSpecialtyInformation { get; set; }
        [PositionIndex(6)]
        public string ProviderOrganizationCode { get; set; }
    }
}
