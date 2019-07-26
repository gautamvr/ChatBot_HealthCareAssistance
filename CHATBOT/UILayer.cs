using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Data.Common;
using System.Configuration;
using BusinessLayer;


namespace UILayer
{
    
    using BusinessLayer;
    class UILayer
    {
        public static void Main(string[] args)
        {
            string t = null;
            t = Intro();
            while (true)
            {
                ProvideAssistance(t);
                t=Bot.Prompt("Do you want to look for more Monitors and solutions? If Yes, Please specify whether you want to look for monitor or solution");
                if (t.Contains("no"))
                {
                    EndConversation();
                    return;
                }
            }
        }

        private static void EndConversation()
        {
            Bot.Prompt("Thank you for contacting us. I hope we have helped you in a proper way. Have a great day.");
            Bot.PrintLine(":)");
        }

        private static void ProvideAssistance(string t)
        {
            bool loop = true;
            while (loop)
            {
                if (t.Contains("monitor"))
                {
                    AccessMonitor();
                    loop = false;
                }
                else if (t.Contains("solution"))
                {
                    AccessSolutions();
                    loop = false;
                }
                else
                {
                    t = Bot.Prompt(
                        "We only provide information on Patient Monitors Devices or Solutions. Please specify");
                }
            }
        }

        private static string Intro()
        {
            Bot.Prompt("Hi, you are talking with a ChatBot");
            string t = Bot.Prompt("Do you want information about purchasing Patient Monitor or Solutions?");
            return t;
        }

        private static void AccessMonitor()
        {
            while (true)
            {
                string again = "";
                string userChoice = Bot.Prompt("Do you want monitor based on categories or specifications?");
                //if (userChoice.Contains("back") || userChoice.Contains("previous"))
                //{
                //    return;
                //}
                while ((!userChoice.Contains("category") && !userChoice.Contains("categories")) &&
                       !userChoice.Contains("spec"))
                {
                    userChoice = Bot.Prompt("Sorry, I did not understand you. Can you please be more specific?");
                }
                if (userChoice.Contains("category") || userChoice.Contains("categories"))
                {
                    GetMonitorsBasedOnCategory();
                }
                else if (userChoice.Contains("spec"))
                {
                    GetMonitorsBasedOnSpecs();
                }
                again = Bot.Prompt("Do you want to look for more products?");
                if (again.Contains("no"))
                {
                    return;
                }
            }
        }

        private static void GetMonitorsBasedOnSpecs()
        {
            string UserQuerySentence = Bot.Prompt("Please give me your specifications of the Monitor you are expecting");
            string allDistinctSpecs = MonitorLogic.GetDistinctSpecs();
            allDistinctSpecs = allDistinctSpecs.ToLower();
            string UserQuery = Logic.ExtractKeyword(allDistinctSpecs, UserQuerySentence);
            Console.WriteLine(allDistinctSpecs);
            while (!(allDistinctSpecs.Contains(UserQuery)))
            {
                UserQuery = Bot.Prompt("Sorry, No monitor is available for this specification.Please tell us any other specification.");
            }
            Bot.PrintLine("Model Numbers according to your required specifications are: ");
            string modelsOnSpecs = MonitorLogic.GetModelOnSpecifications(UserQuery);
            Bot.PrintData(modelsOnSpecs);
            string modelNameSentence = Bot.Prompt("Select the model you want to inquire about");
            string modelName = Logic.ExtractKeyword(modelsOnSpecs, modelNameSentence).ToUpper();
            while (true)
            {
                while (!modelsOnSpecs.Contains(modelName))
                {
                    modelNameSentence = Bot.Prompt(
                        "The model you selected does not have your required specifications or is not available with us. Please enter the model name which has {0} as the specification",
                        UserQuery);
                    modelName = Logic.ExtractKeyword(modelsOnSpecs, modelNameSentence).ToUpper();


                }
                Bot.PrintData(MonitorLogic.GetSpecification(modelName));
                modelNameSentence = Bot.Prompt("Do you want the full specifications for more models? If Yes, Please specify the Model name.");
                modelName = Logic.ExtractKeyword(modelsOnSpecs, modelNameSentence).ToUpper();
                 if (modelNameSentence.Contains("no"))
                 {
                     return;
                 }
            }
        }

        private static void GetMonitorsBasedOnCategory()
        {
            Bot.PrintLine("Categories are mentioned below:");
            string allCategories = MonitorLogic.GetSerialName();
            Bot.PrintData(allCategories);
            string categorySentence = Bot.Prompt("Select the Category you want to purchase?");
            string category = Logic.ExtractKeyword(allCategories, categorySentence);
            while (!allCategories.Contains(category)&&category.Contains(""))
            {
                categorySentence=Bot.Prompt("Sorry, This category is not available. Please enter the available categories with us.");
                category = Logic.ExtractKeyword(allCategories, categorySentence);
            }
            Bot.PrintLine("Model Numbers of the category '{0}' are mentioned below:", category);
            string modelOnCategory = MonitorLogic.GetModels(category);
            Bot.PrintData(modelOnCategory);
            string modelNameSentence = Bot.Prompt("Select the model you want to inquire about");
            string modelName = Logic.ExtractKeyword(modelOnCategory, modelNameSentence).ToUpper();
            while (true)
            {
                while (!modelOnCategory.Contains(modelName))
                {
                    modelNameSentence = Bot.Prompt("The model you selected is not present in the '{0}' category. Please specify the model that is present in the selected category.", category);
                    modelName = Logic.ExtractKeyword(modelOnCategory, modelNameSentence).ToUpper();

                }
                Bot.PrintData(MonitorLogic.GetSpecification(modelName));
                modelNameSentence=Bot.Prompt("Do you want the full specifications for more models? If Yes, Please specify the Model name.");
                modelName = Logic.ExtractKeyword(modelOnCategory, modelNameSentence).ToUpper();
                if (modelNameSentence.Contains("no"))
                {
                    return;
                }
            }
        }

        private static void AccessSolutions()
        {
            string UserChoice = Bot.Prompt("We offer a Standard set of Hospital Solutions. Would you like to see what we have to offer or do you have something specific in mind ?");
            while (true)
            {
                if (UserChoice.Contains("show") || (UserChoice.Contains("offer")) || (UserChoice.Contains("all")) ||
                    (UserChoice.Contains("see")))
                {
                    SolutionsAll();
                }
                else if (UserChoice.Contains("specific") || (UserChoice.Contains("purpose")) ||
                         (UserChoice.Contains("looking")) || (UserChoice.Contains("want")))
                {
                    SolutionsBasedOnPurpose();
                }
                else
                {
                    UserChoice = Bot.Prompt("Sorry, I'm not able to understand you properly. Can you be more specific?");
                    if (UserChoice.Contains("no"))
                    {
                        return;
                    }
                }
            }
        }

        private static void SolutionsBasedOnPurpose()
        {
            string userQuery = Bot.Prompt("What is the purpose of the solution you need?");
            
            string solution = SolutionLogic.GetPurpose(userQuery);
            while (true)
            {
                while (String.Equals(solution, "null"))
                {
                    userQuery = Bot.Prompt(
                        "I'm Sorry. I'm not able to understand what you are looking for. Can you please be more specific? ");
                    solution = SolutionLogic.GetPurpose(userQuery);

                }
                Bot.PrintLine("These are possible Solutions we offer that could match your requirement : ");
                Bot.PrintData(solution);
                string reply=Bot.Prompt("Do you want to look for more Solutions based on different purpose of your choice? If Yes, Mention your purpose");
                if (reply.Contains("no"))
                {
                    return;
                }
            }
        }

        private static void SolutionsAll()
        {
            Bot.PrintLine("The various types of solution are given below:");
            string allCategory= SolutionLogic.GetSolutionName();
            Bot.PrintData(allCategory);
            allCategory = allCategory.ToLower();
            string typeSentence = Bot.Prompt("Select the type of solution you want to purchase?");
            string type = Logic.ExtractKeyword(allCategory, typeSentence);
            while (true)
            {
                while (!allCategory.Contains(type))
                {
                    typeSentence = Bot.Prompt(
                        "I'm sorry, We don't have the type of solution you mentioned. Please choose one from above types");
                    type = Logic.ExtractKeyword(allCategory, typeSentence);
                }
                ShowSolution(type);
                typeSentence=Bot.Prompt("Do you want to explore other solution types? If Yes, enter the type of the solution.");
                type = Logic.ExtractKeyword(allCategory, typeSentence);
                if (typeSentence.Contains("no"))
                {
                    return;
                }
            }
        }

        private static void ShowSolution(string type)
        {
            Bot.PrintLine("Available solutions of the type '{0}' are mentioned below:", type);
            string allSolutions = SolutionLogic.GetSolution(type);
            Bot.PrintData(allSolutions);
            allSolutions = allSolutions.ToLower();
            string name = Bot.Prompt("Which solution of above are you interested to know more about?");
            while (true)
            {
                while (!allSolutions.Contains(name))
                {
                    name = Bot.Prompt(
                        "I'm sorry, We don't have a solution in that name. Please choose one of the above solutions to display it's description.");
                }

                Bot.PrintLine("The solution description is :");
                Bot.PrintData(SolutionLogic.GetDescription(name));
                string more = Bot.Prompt("Do you want to look for more solutions of the type '{0}' ?", type);
                if (more.Contains("no"))
                {
                    return;

                }
            }

        }
    }

    
}
