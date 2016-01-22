using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("DMG")]
    public class DMG_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string DateTimePeriodFormatQualifier { get; set; }
        [PositionIndex(2)]
        public string DateTimePeriod { get; set; }
        [PositionIndex(3)]
        public string GenderCode { get; set; }        
    }
}
