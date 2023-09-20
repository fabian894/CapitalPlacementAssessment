using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementAssessment.Model
{
    public class WorkflowEntity
    {
        public string ProgramId { get; set; }
        public List<WorkflowStageEntity> Stages { get; set; }
    }
}
