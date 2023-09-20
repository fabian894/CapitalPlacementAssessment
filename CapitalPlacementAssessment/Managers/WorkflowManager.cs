using CapitalPlacementAssessment.DTOs;
using CapitalPlacementAssessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementAssessment.Managers
{
    class WorkflowManager
    {
        private static List<WorkflowEntity> workflows = new List<WorkflowEntity>();

        public void CreateWorkflow(WorkflowDto workflowDto)
        {
            // Map the DTO to your internal model
            WorkflowEntity workflowEntity = MapToModel(workflowDto);

            // Save the workflowModel
            workflows.Add(workflowEntity);

            Console.WriteLine("Workflow created successfully.");
        }

        public WorkflowEntity GetWorkflow(string programId)
        {
            return workflows.FirstOrDefault(w => w.ProgramId == programId);
        }

        private WorkflowEntity MapToModel(WorkflowDto workflowDto)
        {
            return new WorkflowEntity
            {
                ProgramId = workflowDto.ProgramId,
                Stages = workflowDto.Stages.Select(s => new WorkflowStageEntity
                {
                    StageName = s.StageName,
                    StageType = s.StageType
                    // Map other attributes based on stage type
                }).ToList()
            };
        }
    }
}
