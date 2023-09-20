using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementAssessment.DTOs
{
    public class ApplicationTemplateDto
    {
        public string? ProgramId { get; set; }
        public List<ApplicationQuestionDto> Questions { get; set; }
    }
}
