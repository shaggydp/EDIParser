using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("SV1")]
    public class SV1_Segment : SegmentBase
    {       
        [PositionIndex(1)]//Should break into components
        public CMPIInformation CompositeMedicalProcedureIdentifier { get; set; }
        [PositionIndex(2)]
        public string MonetaryAmount { get; set; }
        [PositionIndex(3)]
        public string MeasurementCode { get; set; }
        [PositionIndex(4)]
        public string Quantity { get; set; } 
        [PositionIndex(5)]
        public string FacilityCodeValue { get; set; }
        [PositionIndex(7)]//Should break into components
        public CDCPInformation CompositeDiagnosisCodePointer { get; set; }
        [PositionIndex(9)]
        public string ConditionResponseCode1 { get; set; }
        [PositionIndex(11)]
        public string ConditionResponseCode2 { get; set; }
        [PositionIndex(12)]
        public string ConditionResponseCode3 { get; set; }
        [PositionIndex(15)]
        public string CopayStatusCode { get; set; }        

        public class CDCPInformation:IComplexField
        {
            [PositionIndex(0)]
            public string DiagnosisCodePointer1 { get; set; }
            [PositionIndex(1)]
            public string DiagnosisCodePointer2 { get; set; }
            [PositionIndex(2)]
            public string DiagnosisCodePointer3 { get; set; }
            [PositionIndex(3)]
            public string DiagnosisCodePointer4 { get; set; }
        }
        public class CMPIInformation : IComplexField
        {
            [PositionIndex(0)]
            public string ServiceIDQualifier { get; set; }
            [PositionIndex(1)]
            public string ServiceID { get; set; }
            [PositionIndex(2)]
            public string ProcedureModifier1 { get; set; }
            [PositionIndex(3)]
            public string ProcedureModifier2 { get; set; }
            [PositionIndex(4)]
            public string ProcedureModifier3 { get; set; }
            [PositionIndex(5)]
            public string ProcedureModifier4 { get; set; }
            [PositionIndex(6)]
            public string Description { get; set; }          

        }       
         
    }
}
