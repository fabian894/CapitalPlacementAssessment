using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementAssessment.DTOs
{
    public class ApplicationQuestionDto
    {
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }
        public string? IdNumber { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public byte Resume { get; set; }

    }
}
