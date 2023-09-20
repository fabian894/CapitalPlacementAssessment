using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementAssessment.Model
{
    public class ApplicationTemplateModel
    {
        public string ProgramId { get; set; }
        public List<ApplicationQuestionModel> Questions { get; set; }
    }
}
