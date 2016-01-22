using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("CR1")]
    public class CR1_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string UnitOfMeasurementCode1 { get; set; }
        [PositionIndex(2)]
        public string Weight { get; set; }
        [PositionIndex(4)]
        public string AmbulanceTransportReasonCode { get; set; }
        [PositionIndex(5)]
        public string UnitOfMeasurementCode2 { get; set; }
        [PositionIndex(6)]
        public string Quantity { get; set; }
        [PositionIndex(9)]
        public string Description1 { get; set; }
        [PositionIndex(10)]
        public string Description2 { get; set; }    
    }
}
