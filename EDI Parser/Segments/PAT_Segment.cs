﻿using EDI_Parser.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Parser.Segments
{
    [SegmentId("PAT")]
    public class PAT_Segment : SegmentBase
    {
        [PositionIndex(1)]
        public string IndividualRelationshipCode { get; set; }
        [PositionIndex(5)]
        public string DateTimePeriodFormatQualifier { get; set; }
        [PositionIndex(6)]
        public string DateTimePeriod { get; set; }
        [PositionIndex(7)]
        public string MeasurementCode { get; set; }
        [PositionIndex(8)]
        public string Weight { get; set; }        
    }
}
