using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementAssessment.DTOs
{
  public class WorkflowDto
    {
        public string ProgramId { get; set; }
        public List<WorkflowStageDto> Stages { get; set; }
    }
}
