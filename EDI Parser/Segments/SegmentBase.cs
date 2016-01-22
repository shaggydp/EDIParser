using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    public class SegmentBase
    {
        [PositionIndex(0)]
        public string SegmentID { get; set; }
    }
}
