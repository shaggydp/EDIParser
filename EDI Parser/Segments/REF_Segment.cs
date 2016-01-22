using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("REF")]
    public class REF_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string ReferenceIdentificationQualifier { get; set; }
        [PositionIndex(2)]
        public string ReferenceIdentification { get; set; }        
    }
}
