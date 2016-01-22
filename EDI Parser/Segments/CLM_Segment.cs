using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("CLM")]
    public class CLM_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string ClaimSubmitterIdentifier { get; set; }
        [PositionIndex(2)]
        public string MonetaryAmount { get; set; }
        [PositionIndex(5)]//Should break into components
        public HCSLInformation HealthCareServiceLocationInformation { get; set; }
        
        [PositionIndex(6)]
        public string ResponseCode { get; set; }
        [PositionIndex(7)]
        public string ProviderAcceptAssignmentCode { get; set; }
        [PositionIndex(8)]
        public string  RemitPaymentDirectlyToProvider { get; set; }
        [PositionIndex(9)]
        public string ReleaseofInformationCode { get; set; }
        [PositionIndex(10)]
        public string PatientSignatureSourceCode { get; set; }
        [PositionIndex(11)]//Should break into components
        public RCInformation RelatedCausesInformation { get; set; }
        [PositionIndex(20)]
        public string DelayReasonCode { get; set; }
        public class HCSLInformation : IComplexField
        {
            [PositionIndex(0)]
            public string FacilityCodeValue { get; set; }
            [PositionIndex(1)]
            public string FacilityCodeQualifier { get; set; }
            [PositionIndex(2)]
            public string ClaimFrequencyTypeCode { get; set; }
        }
        public class RCInformation : IComplexField
        {
            [PositionIndex(0)]
            public string RelatedCausesCode1 { get; set; }
            [PositionIndex(1)]
            public string RelatedCausesCode2 { get; set; }
            [PositionIndex(3)]
            public string State { get; set; }
            [PositionIndex(4)]
            public string CountryCode { get; set; }
        }
         
    }
}
