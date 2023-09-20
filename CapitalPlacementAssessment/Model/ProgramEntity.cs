using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementAssessment.Model
{
    public class ProgramEntity
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public List<string>? KeySkills { get; set; }
        public List<string>? Benefits { get; set; }
        public string? ApplicationCriteria { get; set; }
    }

}
