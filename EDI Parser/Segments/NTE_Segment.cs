using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("NTE")]
    public class NTE_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string NoteReferenceCode { get; set; }
        [PositionIndex(2)]
        public string Description { get; set; }        
    }
}
