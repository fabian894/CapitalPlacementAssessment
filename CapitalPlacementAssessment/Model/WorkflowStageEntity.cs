﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementAssessment.Model
{
    public class WorkflowStageEntity
    {
        public string? StageName { get; set; }
        public string? StageType { get; set; }
        public string? Shortlisting { get; set; }
        public string? VideoInterview { get; set; }
        public string? Placement { get; set; }
    }
}
