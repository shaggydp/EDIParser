using EDI_Parser.Attributes;
using EDI_Parser.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Messages._5010
{
    [MessageType("005010X222")]
    public class Msg837P : MessageBase
    {
        public Msg837P()
        {
            this.Submitter = new Loop_1000A();
            this.Receiver = new Loop_1000B();
            this.BillerProviderLevel = new Loop_2000A();
            this.SubscriberLevel = new List<Loop_2000B>();
            this.PatientLevel = new Loop_2000C();
            this.Claims = new List<Loop_2300>();
            this.ServiceLines = new List<Loop_2400>();
        }
        [PositionIndex(0)]
        public BHT_Segment Header { get; set; }
        [PositionIndex(1), FieldCheck("NM1", "EntityIdentifierCode", "41")]
        public Loop_1000A Submitter { get; set; }
        [PositionIndex(2), FieldCheck("NM1", "EntityIdentifierCode", "40")]
        public Loop_1000B Receiver { get; set; }
        [PositionIndex(3), FieldCheck("HL", "HierarchicalLevelCodeID", "20")]
        public Loop_2000A BillerProviderLevel { get; set; }
        [PositionIndex(4), FieldCheck("HL", "HierarchicalLevelCodeID", "22")]
        public List<Loop_2000B> SubscriberLevel { get; set; }
        [PositionIndex(5), FieldCheck("HL", "HierarchicalLevelCodeID", "23")]
        public Loop_2000C PatientLevel { get; set; }
        [PositionIndex(6), FieldCheck("CLM", "SegmentID", "CLM")]
        public List<Loop_2300> Claims { get; set; }
        [PositionIndex(7), FieldCheck("LX", "SegmentID", "LX")]
        public List<Loop_2400> ServiceLines { get; set; }
        
        public class Loop_1000A
        {
            [PositionIndex(0)]
            public NM1_Segment SubmitterName { get; set; }
            [PositionIndex(1)]
            public PER_Segment SubmitterContactInformation { get; set; }
        }
        public class Loop_1000B
        {
            [PositionIndex(0)]
            public NM1_Segment ReceiverName { get; set; }
        }
        public class Loop_2000A
        {
            public Loop_2000A()
            {
                this.BillingProvider = new Loop_2010AA();
                this.PayToProvider = new Loop_2010AB();
            }
            [PositionIndex(0)]
            public HL_Segment HierarchicalLevel { get; set; }
            [PositionIndex(1)]
            public PRV_Segment ProviderSpecialtyInformation { get; set; }
            [PositionIndex(2), FieldCheck("NM1", "EntityIdentifierCode", "85")]
            public Loop_2010AA BillingProvider { get; set; }
            [PositionIndex(3), FieldCheck("NM1", "EntityIdentifierCode", "87")]
            public Loop_2010AB PayToProvider { get; set; }
            public class Loop_2010AA
            {
                [PositionIndex(0)]
                public NM1_Segment BillingProviderName { get; set; }
                [PositionIndex(1)]
                public N3_Segment BillingProviderAddress { get; set; }
                [PositionIndex(2)]
                public N4_Segment BillingProviderCity{ get; set; }
                [PositionIndex(3)]
                public REF_Segment BillingProviderTaxIdentification { get; set; }
                [PositionIndex(4)]
                public PER_Segment BillingProviderContactInformation  { get; set; }
                
            }
            public class Loop_2010AB
            {
                [PositionIndex(0)]
                public NM1_Segment PayToProviderName { get; set; }
                [PositionIndex(1)]
                public N3_Segment PayToProviderAddress { get; set; }
                [PositionIndex(2)]
                public N4_Segment PayToProviderCity { get; set; }               
            }
        }
        public class Loop_2000B
        {
            public Loop_2000B()
            {
                this.SubscriberDemographics = new Loop_2010BA();
                this.PayerName = new Loop_2010BB();
            }
            [PositionIndex(0)]
            public HL_Segment HierarchicalLevel { get; set; }
            [PositionIndex(1)]
            public SBR_Segment SubscriberInformation  { get; set; }
            [PositionIndex(2)]
            public PAT_Segment PatientInformation  { get; set; }
            [PositionIndex(3), FieldCheck("NM1", "EntityIdentifierCode", "IL")]
            public Loop_2010BA SubscriberDemographics { get; set; }
            [PositionIndex(4), FieldCheck("NM1", "EntityIdentifierCode", "PR")]
            public Loop_2010BB PayerName { get; set; }
            public class Loop_2010BA
            {
                [PositionIndex(0)]
                public NM1_Segment SubscriberName { get; set; }
                [PositionIndex(1)]
                public N3_Segment SubscriberAddress { get; set; }
                [PositionIndex(2)]
                public N4_Segment SubscriberCity { get; set; }
                [PositionIndex(3)]
                public DMG_Segment DemographicInformation { get; set; }             

            }
            public class Loop_2010BB
            {
                [PositionIndex(0)]
                public NM1_Segment PayerName { get; set; }
                [PositionIndex(1)]
                public N3_Segment PayerAddress { get; set; }
                [PositionIndex(2)]
                public N4_Segment PayerCity { get; set; }
            }
        }
        public class Loop_2000C
        {
            public Loop_2000C()
            {
                this.PatientDemographics = new Loop_2010CA();
            }
            [PositionIndex(0)]
            public HL_Segment HierarchicalLevel { get; set; }
            [PositionIndex(1)]
            public PAT_Segment PatientInformation { get; set; }
            [PositionIndex(2), FieldCheck("NM1", "EntityIdentifierCode", "QC")]
            public Loop_2010CA PatientDemographics { get; set; }            
            public class Loop_2010CA
            {
                [PositionIndex(0)]
                public NM1_Segment PatientName { get; set; }
                [PositionIndex(1)]
                public N3_Segment PatientAddress { get; set; }
                [PositionIndex(2)]
                public N4_Segment PatientCity { get; set; }
                [PositionIndex(3)]
                public DMG_Segment PatientDemographicInfo{ get; set; }

            }           
        }

        public class Loop_2300
        {
            public Loop_2300()
            {
                this.ClaimSupplementalInformation = new List<PWK_Segment>();
            }
            [PositionIndex(0)]
            public CLM_Segment ClaimInformation { get; set; }
            [PositionIndex(1), FieldCheck("PWK", "SegmentID", "PWK")]
            public List<PWK_Segment> ClaimSupplementalInformation { get; set; }
            [PositionIndex(2), FieldCheck("AMT", "AmountQualifierCode", "F5")]
            public AMT_Segment PatientAmountPaid { get; set; }
            [PositionIndex(3), FieldCheck("REF", "ReferenceIdentificationQualifier", "9F")]
            public REF_Segment ReferralNumber { get; set; }
            [PositionIndex(4), FieldCheck("REF", "ReferenceIdentificationQualifier", "G1")]
            public REF_Segment PriorAuthorization { get; set; }
            [PositionIndex(5), FieldCheck("REF", "ReferenceIdentificationQualifier", "F8")]
            public REF_Segment PayerClaimControlNumber { get; set; }
            [PositionIndex(6)]
            public NTE_Segment ClaimNote { get; set; }
            [PositionIndex(7)]
            public CR1_Segment AmbulanceTransportInformation  { get; set; }
            [PositionIndex(8)]
            public HI_Segment HealthCareDiagnosisCode { get; set; }
            [PositionIndex(9)]
            public HI_Segment AnesthesiaRelatedProcedure { get; set; }

        }
        public class Loop_2400
        {
            public Loop_2400()
            {
               
            }
            [PositionIndex(0)]
            public LX_Segment ServiceLineNumber { get; set; }
            [PositionIndex(1)]
            public SV1_Segment SV1 { get; set; }         
            
        }
    }
}


