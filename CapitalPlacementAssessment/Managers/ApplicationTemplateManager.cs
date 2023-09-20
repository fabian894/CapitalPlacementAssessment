using CapitalPlacementAssessment.DTOs;
using CapitalPlacementAssessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementAssessment.Managers
{
    public class ApplicationTemplateManager
    {
        private static List<ApplicationTemplateModel> templates = new List<ApplicationTemplateModel>();

        public void CreateApplicationTemplate(ApplicationTemplateDto templateDto)
        {
            // Map the DTO to your internal model
            ApplicationTemplateModel templateModel = MapToModel(templateDto);

            // Save the templateModel
            templates.Add(templateModel);

            Console.WriteLine("Application Template created successfully.");
        }

        public ApplicationTemplateModel GetApplicationTemplate(string programId)
        {
            return templates.FirstOrDefault(t => t.ProgramId == programId);
        }

        private ApplicationTemplateModel MapToModel(ApplicationTemplateDto templateDto)
        {
            return new ApplicationTemplateModel
            {
                ProgramId = templateDto.ProgramId,
                Questions = templateDto.Questions.Select(q => new ApplicationQuestionModel
                {
                    QuestionText = q.QuestionText,
                    QuestionType = q.QuestionType
                    // Map other attributes based on question type
                }).ToList()
            };
        }
    }

}
