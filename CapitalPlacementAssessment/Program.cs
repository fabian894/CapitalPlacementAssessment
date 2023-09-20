using CapitalPlacementAssessment.DTOs;
using CapitalPlacementAssessment.Managers;
using CapitalPlacementAssessment.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Documents;
using System.ComponentModel;
using Container = Microsoft.Azure.Cosmos.Container;
using Database = Microsoft.Azure.Cosmos.Database;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using PartitionKey = Microsoft.Azure.Cosmos.PartitionKey;

//class Program
//{
//    private const string EndpointUrl = "https://localhost:8081";
//    private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
//    private const string DatabaseId = "03";
//    private const string ContainerId = "15";

//    private static CosmosClient cosmosClient;
//    private static Database database;
//    private static Container container;

//    static async Task Main(string[] args)
//    {
//        cosmosClient = new CosmosClient(EndpointUrl, PrimaryKey);
//        database = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseId);
//        container = await database.CreateContainerIfNotExistsAsync(ContainerId, "/Id");
//    }
//}


//class ProgramTab1
//{
//    private static List<ProgramEntity> programs = new List<ProgramEntity>();

//    private static void CreateProgram()
//    {
//        ProgramEntity program = new ProgramEntity();
//        program.Id = Guid.NewGuid().ToString(); // Generate a unique ID
//        Console.Write("Enter Program Title: ");
//        program.Title = Console.ReadLine();
//        Console.Write("Enter Program Summary: ");
//        program.Summary = Console.ReadLine();
//        Console.Write("Enter Program Description: ");
//        program.Description = Console.ReadLine();

//        // Key Skills (you can implement a more structured input method)
//        program.KeySkills = new List<string>();
//        Console.Write("Enter Key Skills (comma-separated): ");
//        program.KeySkills.AddRange(Console.ReadLine().Split(','));

//        // Benefits (you can implement a more structured input method)
//        program.Benefits = new List<string>();
//        Console.Write("Enter Program Benefits (comma-separated): ");
//        program.Benefits.AddRange(Console.ReadLine().Split(','));

//        Console.Write("Enter Application Criteria: ");
//        program.ApplicationCriteria = Console.ReadLine();

//        programs.Add(program);
//        Console.WriteLine("Program created successfully.");
//    }

//    private static void GetProgramById()
//    {
//        Console.Write("Enter Program ID: ");
//        string id = Console.ReadLine();
//        ProgramEntity program = programs.FirstOrDefault(p => p.Id == id);

//        if (program != null)
//        {
//            Console.WriteLine($"Title: {program.Title}");
//            Console.WriteLine($"Summary: {program.Summary}");
//            Console.WriteLine($"Description: {program.Description}");
//            Console.WriteLine($"Key Skills: {string.Join(", ", program.KeySkills)}");
//            Console.WriteLine($"Benefits: {string.Join(", ", program.Benefits)}");
//            Console.WriteLine($"Application Criteria: {program.ApplicationCriteria}");
//        }
//        else
//        {
//            Console.WriteLine("Program not found.");
//        }
//    }

//    private static void UpdateProgram()
//    {
//        Console.Write("Enter Program ID to update: ");
//        string id = Console.ReadLine();
//        ProgramEntity program = programs.FirstOrDefault(p => p.Id == id);

//        if (program != null)
//        {
//            Console.Write("Enter Program Title: ");
//            program.Title = Console.ReadLine();
//            Console.Write("Enter Program Summary: ");
//            program.Summary = Console.ReadLine();
//            Console.Write("Enter Program Description: ");
//            program.Description = Console.ReadLine();

//            // Key Skills (you can implement a more structured input method)
//            program.KeySkills = new List<string>();
//            Console.Write("Enter Key Skills (comma-separated): ");
//            program.KeySkills.AddRange(Console.ReadLine().Split(','));

//            // Benefits (you can implement a more structured input method)
//            program.Benefits = new List<string>();
//            Console.Write("Enter Program Benefits (comma-separated): ");
//            program.Benefits.AddRange(Console.ReadLine().Split(','));

//            Console.Write("Enter Application Criteria: ");
//            program.ApplicationCriteria = Console.ReadLine();

//            Console.WriteLine("Program updated successfully.");
//        }
//        else
//        {
//            Console.WriteLine("Program not found.");
//        }
//    }

//    static void Main(string[] args)
//    {
//        while (true)
//        {
//            Console.WriteLine("1. Create Program");
//            Console.WriteLine("2. Get Program by ID");
//            Console.WriteLine("3. Update Program by ID");
//            Console.WriteLine("4. Exit");
//            Console.Write("Select an option: ");

//            if (int.TryParse(Console.ReadLine(), out int choice))
//            {
//                switch (choice)
//                {
//                    case 1:
//                        CreateProgram();
//                        break;
//                    case 2:
//                        GetProgramById();
//                        break;
//                    case 3:
//                        UpdateProgram();
//                        break;
//                    case 4:
//                        Environment.Exit(0);
//                        break;
//                    default:
//                        Console.WriteLine("Invalid option. Try again.");
//                        break;
//                }
//            }
//            else
//            {
//                Console.WriteLine("Invalid input. Enter a number.");
//            }
//        }
//    }
//}


class Program
{
    private const string EndpointUrl = "https://localhost:8081";
    private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
    private const string DatabaseId = "03";
    private const string ContainerId = "15";


    private static CosmosClient cosmosClient;
    private static Database database;
    private static Container container;
    private static ApplicationTemplateManager templateManager = new ApplicationTemplateManager();
    private static WorkflowManager workflowManager = new WorkflowManager();
    static async Task Main(string[] args)
    {
        cosmosClient = new CosmosClient(EndpointUrl, PrimaryKey);
        database = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseId);
        container = await database.CreateContainerIfNotExistsAsync(ContainerId, "/Id");
        while (true)
        {
            Console.WriteLine("1. Tab 1: Create Program");
            Console.WriteLine("2. Tab 1: Get Program by ID");
            Console.WriteLine("3. Tab 1: Update Program by ID");
            Console.WriteLine("4. Tab 2: Create Application Template");
            Console.WriteLine("5. Tab 2: Get Application Template by Program ID");
            Console.WriteLine("6. Tab 3: Create Workflow");
            Console.WriteLine("7. Tab 3: Get Workflow by Program ID");
            Console.WriteLine("8. Tab 4: Preview Program");
            Console.WriteLine("9. Exit");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Tab1_CreateProgram();
                        break;
                    case 2:
                        Tab1_GetProgramById();
                        break;
                    case 3:
                        Tab1_UpdateProgram();
                        break;
                    case 4:
                        Tab2_CreateApplicationTemplate();
                        break;
                    case 5:
                        Tab2_GetApplicationTemplate();
                        break;
                    case 6:
                        Tab3_CreateWorkflow();
                        break;
                    case 7:
                        Tab3_GetWorkflow();
                        break;
                    case 8:
                        Tab4_PreviewProgram();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a number.");
            }
        }
    }

    private static async void Tab1_CreateProgram()
    {
        Console.Write("Enter Program Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Program Summary: ");
        string summary = Console.ReadLine();

        Console.Write("Enter Program Description: ");
        string description = Console.ReadLine();

        // Key Skills (comma-separated)
        Console.Write("Enter Key Skills (comma-separated): ");
        string keySkillsInput = Console.ReadLine();
        List<string> keySkills = keySkillsInput.Split(',').Select(skill => skill.Trim()).ToList();

        // Benefits (comma-separated)
        Console.Write("Enter Program Benefits (comma-separated): ");
        string benefitsInput = Console.ReadLine();
        List<string> benefits = benefitsInput.Split(',').Select(benefit => benefit.Trim()).ToList();

        Console.Write("Enter Application Criteria: ");
        string applicationCriteria = Console.ReadLine();

        // Generate a unique ID
        string id = Guid.NewGuid().ToString();

        // Create a program object
        ProgramEntity program = new ProgramEntity
        {
            Id = id,
            Title = title,
            Summary = summary,
            Description = description,
            KeySkills = keySkills,
            Benefits = benefits,
            ApplicationCriteria = applicationCriteria
        };

        try
        {
            // Insert the program into Cosmos DB
            await container.CreateItemAsync(program, new PartitionKey(id));
            Console.WriteLine("Program created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating program: {ex.Message}");
        }
    }



    private static async void Tab1_GetProgramById()
    {
        Console.Write("Enter Program ID: ");
        string id = Console.ReadLine();

        try
        {
            // Retrieve the program from Cosmos DB
            ItemResponse<ProgramEntity> response = await container.ReadItemAsync<ProgramEntity>(id, new PartitionKey(id));
            ProgramEntity program = response.Resource;

            Console.WriteLine($"Title: {program.Title}");
            Console.WriteLine($"Summary: {program.Summary}");
            Console.WriteLine($"Description: {program.Description}");

            Console.WriteLine("Key Skills:");
            foreach (string skill in program.KeySkills)
            {
                Console.WriteLine($"- {skill}");
            }

            Console.WriteLine("Benefits:");
            foreach (string benefit in program.Benefits)
            {
                Console.WriteLine($"- {benefit}");
            }

            Console.WriteLine($"Application Criteria: {program.ApplicationCriteria}");
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("Program not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving program: {ex.Message}");
        }
    }

    private static async void Tab1_UpdateProgram()
    {
        Console.Write("Enter Program ID to update: ");
        string id = Console.ReadLine();

        try
        {
            // Retrieve the program from Cosmos DB
            ItemResponse<ProgramEntity> response = await container.ReadItemAsync<ProgramEntity>(id, new PartitionKey(id));
            ProgramEntity program = response.Resource;

            // Modify the program properties
            Console.Write("Enter new Program Title: ");
            program.Title = Console.ReadLine();
            // Modify other program properties

            // Update the program in Cosmos DB
            await container.ReplaceItemAsync(program, program.Id, new PartitionKey(program.Id));
            Console.WriteLine("Program updated successfully.");
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine("Program not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating program: {ex.Message}");
        }
    }

    private static void Tab2_CreateApplicationTemplate()
    {
        Console.Write("Enter Program ID: ");
        string programId = Console.ReadLine();

        // Create application questions (you can add more)
        List<ApplicationQuestionDto> questions = new List<ApplicationQuestionDto>
        {
            new ApplicationQuestionDto
            {
                QuestionText = "Enter your first name:",
                QuestionType = "ShortAnswer"
            },
            new ApplicationQuestionDto
            {
                QuestionText = "Select your gender:",
                QuestionType = "Dropdown"
            },
             new ApplicationQuestionDto
            {
                QuestionText = "Select your last name:",
                QuestionType = "ShortAnswer"
            },

              new ApplicationQuestionDto
            {
                QuestionText = "Select your email address:",
                QuestionType = "ShortAnswer"
            },

               new ApplicationQuestionDto
            {
                QuestionText = "Select your nationality:",
                QuestionType = "Dropdown"
            },

                new ApplicationQuestionDto
            {
                QuestionText = "Select your current residence:",
                QuestionType = "ShortAnswer"
            },

                 new ApplicationQuestionDto
            {
                QuestionText = "Select your Id Number:",
                QuestionType = "ShortAnswer"
            },

                  new ApplicationQuestionDto
            {
                QuestionText = "Select your Eduation:",
                QuestionType = "ShortAnswer"
            },

                   new ApplicationQuestionDto
            {
                QuestionText = "Select your Experience:",
                QuestionType = "ShortAnswer"
            },
        };

        // Create the application template
        ApplicationTemplateDto templateDto = new ApplicationTemplateDto
        {
            ProgramId = programId,
            Questions = questions
        };

        templateManager.CreateApplicationTemplate(templateDto);
    }

    private static void Tab2_GetApplicationTemplate()
    {
        Console.Write("Enter Program ID: ");
        string programId = Console.ReadLine();

        ApplicationTemplateModel template = templateManager.GetApplicationTemplate(programId);

        if (template != null)
        {
            Console.WriteLine($"Program ID: {template.ProgramId}");
            Console.WriteLine("Application Questions:");
            foreach (var question in template.Questions)
            {
                Console.WriteLine($"- {question.QuestionText} ({question.QuestionType})");
                // Print other attributes based on question type
            }
        }
        else
        {
            Console.WriteLine("Application Template not found.");
        }
    }
        private static void Tab3_CreateWorkflow()
        {
            Console.Write("Enter Program ID: ");
            string programId = Console.ReadLine();

            // Create workflow stages (you can add more)
            List<WorkflowStageDto> stages = new List<WorkflowStageDto>
        {
            new WorkflowStageDto
            {
                StageName = "Shortlisting",
                StageType = "Shortlisting"
            },
            new WorkflowStageDto
            {
                StageName = "Video Interview",
                StageType = "VideoInterview"
            },
            // Add more stages with types and attributes
        };

            // Create the workflow
            WorkflowDto workflowDto = new WorkflowDto
            {
                ProgramId = programId,
                Stages = stages
            };

            workflowManager.CreateWorkflow(workflowDto);
        }

    private static void Tab3_GetWorkflow()
    {
        Console.Write("Enter Program ID: ");
        string programId = Console.ReadLine();

        WorkflowEntity workflow = workflowManager.GetWorkflow(programId);

        if (workflow != null)
        {
            Console.WriteLine($"Program ID: {workflow.ProgramId}");
            Console.WriteLine("Workflow Stages:");
            foreach (var stage in workflow.Stages)
            {
                Console.WriteLine($"- {stage.StageName} ({stage.StageType})");
                // Print other attributes based on stage type
            }
        }
        else
        {
            Console.WriteLine("Workflow not found.");
        }
    }
        private static async void Tab4_PreviewProgram()
        {
            Console.Write("Enter Program ID: ");
            string id = Console.ReadLine();

            try
            {
                // Retrieve the program from Cosmos DB
                ItemResponse<ProgramEntity> response = await container.ReadItemAsync<ProgramEntity>(id, new PartitionKey(id));
                ProgramEntity program = response.Resource;

                Console.WriteLine($"Program ID: {program.Id}");
                Console.WriteLine($"Title: {program.Title}");
                Console.WriteLine($"Summary: {program.Summary}");
                Console.WriteLine($"Description: {program.Description}");

                Console.WriteLine("Key Skills:");
                foreach (string skill in program.KeySkills)
                {
                    Console.WriteLine($"- {skill}");
                }

                Console.WriteLine("Benefits:");
                foreach (string benefit in program.Benefits)
                {
                    Console.WriteLine($"- {benefit}");
                }

                Console.WriteLine($"Application Criteria: {program.ApplicationCriteria}");
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("Program not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving program: {ex.Message}");
            }
        }
    }

    




