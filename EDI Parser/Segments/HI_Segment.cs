using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("HI")]
    public class HI_Segment : SegmentBase
    {     
        [PositionIndex(1)]//Should break into components
        public HCCInformation HealthCareCodeInformation1 { get; set; }
        [PositionIndex(2)]//Should break into components
        public HCCInformation HealthCareCodeInformation2 { get; set; }
        [PositionIndex(3)]//Should break into components
        public HCCInformation HealthCareCodeInformation3 { get; set; }
        [PositionIndex(4)]//Should break into components
        public HCCInformation HealthCareCodeInformation4 { get; set; }
        [PositionIndex(5)]//Should break into components
        public HCCInformation HealthCareCodeInformation5 { get; set; }
        [PositionIndex(6)]//Should break into components
        public HCCInformation HealthCareCodeInformation6 { get; set; }
        [PositionIndex(7)]//Should break into components
        public HCCInformation HealthCareCodeInformation7 { get; set; }
        [PositionIndex(8)]//Should break into components
        public HCCInformation HealthCareCodeInformation8 { get; set; }
        [PositionIndex(9)]//Should break into components
        public HCCInformation HealthCareCodeInformation9 { get; set; }
        [PositionIndex(10)]//Should break into components
        public HCCInformation HealthCareCodeInformation10 { get; set; }
        [PositionIndex(11)]//Should break into components
        public HCCInformation HealthCareCodeInformation11 { get; set; }
        [PositionIndex(12)]//Should break into components
        public HCCInformation HealthCareCodeInformation12 { get; set; }
        
        public class HCCInformation : IComplexField
        {
            [PositionIndex(0)]
            public string CodeListQualifierCode { get; set; }
            [PositionIndex(1)]
            public string IndustryCode { get; set; }           
        }
         
    }
}
