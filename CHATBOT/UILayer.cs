using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using BusinessLayer;
using System.Threading;

namespace UILayer
{
    using BusinessLayer;

    class UILayer
    {
        public static void Main(string[] args)
        {
            string t = null;
            var userName = RegisterUser(out var userPhone,out var userEmail);
            Console.WriteLine("-------------------------------------------------------------------\n");
            t = Intro(userName);
            while (true)
            {
                ProvideAssistance(t);
                t=Bot.Prompt("Do you want to look for more Monitors and solutions? If Yes, Please specify whether you want to look for monitor or solution");
                if (t.Contains("no"))
                {
                    Bot.PrintLine("Thank you for contacting us. Your order details will be shared with our executive.");
                    Console.WriteLine("Your order details will be contacted to you through your phone number: {0} and you Email: {1}",userPhone,userEmail);
                    EndConversation();
                    Console.WriteLine("-------------------------------------------------------------------");
                    return;
                }
            }
        }

        private static string RegisterUser(out string userPhone,out string userEmail)
        {
            Console.WriteLine("Please provide your details to have a hassle free enquiry.\n");
            string userName = GetUserName();
            userPhone = GetUserPhoneNum();
            userEmail = GetUserEmail();
            Console.WriteLine("\n\n\nThank you. Your session with ChatBot will begin now\n");
            return userName;
        }

        public static string GetUserName()
        {
            Console.WriteLine("Please provide your name: ");
            string name = Console.ReadLine();
            return name;
        }

        public static string GetUserPhoneNum()
        {
            Console.WriteLine("\nPlease provide your Phone number: ");
            string phoneNum = Console.ReadLine();
            return phoneNum;

        }

        public static string GetUserEmail()
        {
            Console.WriteLine("\nPlease provide your Email Id: ");
            string emailId = Console.ReadLine();
            return emailId;
        }

        private static void EndConversation()
        {

            if (Cart.Monitors.Count == 0)
            {
                Bot.PrintLine("You haven't added any Patient Monitors to your cart yet");
            }
            else
            {
                Bot.PrintLine("These are the Monitor item(s) in your cart :");
                Bot.PrintData(Logic.RetunList(Cart.Monitors));
            }

            if (Cart.Solutions.Count == 0)
            {
                Bot.PrintLine("You haven't added any Solutions to your cart yet");
            }
            else
            {
                Bot.PrintLine("These are the Solution item(s) in your cart :");
                Bot.PrintData(Logic.RetunList(Cart.Solutions));
            }

            Bot.Prompt("I hope we have helped you in a proper way. Have a great day.");
            Thread.Sleep(3000);
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
                else if (t.Contains("no") || (t.Contains("dont")))
                {
                    return;
                }
                else
                {
                    t = Bot.Prompt(
                        "We only provide information on Patient Monitors Devices or Solutions. Please specify");
                }
            }

        }

        private static string Intro(string user)
        {
            Bot.Prompt("Hi {0}, you are talking with a ChatBot. I'm here to help you in selecting the desired product of your need",user);
            string t = Bot.Prompt("Do you want information about purchasing Patient Monitor or Solutions?");
            return t;
        }

        private static void AccessMonitor()
        {
            while (true)
            {
                string again = "";
                string userChoice = Bot.Prompt("Do you want monitor based on categories or specifications?");
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
                Bot.PrintLine("These are the item(s) in your cart :");
                Bot.PrintData(Logic.RetunList(Cart.Monitors));
                again = Bot.Prompt("Do you want to look for more products?");
                if (again.Contains("no"))
                {
                    return;
                }
            }
        }

        private static void GetMonitorsBasedOnSpecs()
        {
            Bot.PrintLine("These are the specifications which are available : ");
            string allDistinctSpecs = MonitorAccessor.GetDistinctSpecs();
            Bot.PrintData(allDistinctSpecs);
            string UserQuerySentence = Bot.Prompt("Please give me your specifications of the Monitor you are expecting");
            allDistinctSpecs = allDistinctSpecs.ToLower();
            string UserQuery = Logic.ExtractKeyword(allDistinctSpecs, UserQuerySentence);
            while (!(allDistinctSpecs.Contains(UserQuery)))
            {
                UserQuerySentence = Bot.Prompt("Sorry, No monitor is available for this specification.Please tell us any other specification.");
                if (UserQuerySentence.Contains("show") || UserQuerySentence.Contains("all") ||
                    UserQuerySentence.Contains("what"))
                {
                    Bot.PrintData(allDistinctSpecs);
                    UserQuerySentence=Bot.Prompt("Here you go, These are all the different specifications that the monitors have. Please specify your need");
                }
                UserQuery = Logic.ExtractKeyword(allDistinctSpecs, UserQuerySentence);
            }
            Bot.PrintLine("Model Numbers with {0} as a specification are: ",UserQuery);
            string modelsOnSpecs = MonitorAccessor.GetModelOnSpecifications(UserQuery);
            Bot.PrintData(modelsOnSpecs);
            string modelNameSentence = Bot.Prompt("Select the model you want to inquire about");
            string modelName = Logic.ExtractKeyword(modelsOnSpecs, modelNameSentence).ToUpper();
            while (true)
            {
                while (!modelsOnSpecs.Contains(modelName))
                {
                    modelNameSentence = Bot.Prompt(
                        "The model you selected does not have {0} as a specification or is not available with us. Please enter the model name which has {0} as the specification",
                        UserQuery);
                    modelName = Logic.ExtractKeyword(modelsOnSpecs, modelNameSentence).ToUpper();
                }
                Bot.PrintData(MonitorAccessor.GetSpecification(modelName));
                string buyMonitor = Bot.Prompt("Do you want to select this product?");
                if (buyMonitor.Contains("yes"))
                {
                    Cart.Monitors.Add(modelName);
                    Bot.PrintLine("The product is successfully added to your cart.");
                }
                modelNameSentence = Bot.Prompt("Do you want the full specifications for more models? If Yes, Please specify the Model name.");
                if (modelNameSentence.Contains("what") || modelNameSentence.Contains("show"))
                {
                    Bot.PrintData(modelsOnSpecs);
                    modelNameSentence=Bot.Prompt("Here you go, These are the models of the specification '{0}'. Please choose one",UserQuery);
                }
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
            string allCategories = MonitorAccessor.GetSerialName();
            Bot.PrintData(allCategories);
            string categorySentence = Bot.Prompt("Select the Category you want to purchase?");
            string category = Logic.ExtractKeyword(allCategories, categorySentence);
            while (!allCategories.Contains(category)&&category.Contains(""))
            {
                categorySentence=Bot.Prompt("Sorry, This category is not available. Please enter the available categories with us.");
                category = Logic.ExtractKeyword(allCategories, categorySentence);
            }
            Bot.PrintLine("Model Numbers of the category '{0}' are mentioned below:", category);
            string modelOnCategory = MonitorAccessor.GetModels(category);
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
                Bot.PrintData(MonitorAccessor.GetSpecification(modelName));
                string buyMonitor = Bot.Prompt("Do you want to select this product?");
                if (buyMonitor.Contains("yes"))
                {
                    Cart.Monitors.Add(modelName);
                    Bot.PrintLine("The product is successfully added to your cart.");
                }
                modelNameSentence =Bot.Prompt("Do you want the full specifications for more models? If Yes, Please specify the Model name.");
                if (modelNameSentence.Contains("what") || modelNameSentence.Contains("show"))
                {
                    Bot.PrintData(modelOnCategory);
                    modelNameSentence=Bot.Prompt("Here you go, These are the models of category '{0}'.Please choose one",category);
                }
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
            while (true)
            {
                string solution = SolutionsAccessor.GetPurpose(userQuery);
                while (String.Equals(solution, "null"))
                {
                    userQuery = Bot.Prompt(
                        "I'm Sorry. I'm not able to understand what you are looking for. Can you please be more specific? ");
                    solution = SolutionsAccessor.GetPurpose(userQuery);

                }
                ShowSolution(solution);
                userQuery=Bot.Prompt("Do you want to look for more Solutions based on different purpose of your choice? If Yes, Mention your purpose");
                if (userQuery.Contains("no"))
                {
                    return;
                }
            }
        }

        private static void SolutionsAll()
        {
            Bot.PrintLine("The various types of solution are given below:");
            string allCategory= SolutionsAccessor.GetSolutionName();
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
                if (typeSentence.Contains("what") || typeSentence.Contains("show"))
                {
                    Bot.PrintData(allCategory);
                    typeSentence = Bot.Prompt("Here you go, Choose one from the above types of solution");
                }
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
            string allSolutions = SolutionsAccessor.GetSolution(type);
            Bot.PrintData(allSolutions);
            allSolutions = allSolutions.ToLower();
            string solnNameSentence = Bot.Prompt("Which solution of above are you interested to know more about?");
            string solnName = Logic.ExtractKeyword(allSolutions, solnNameSentence);
            while (true)
            {
                while (!allSolutions.Contains(solnName))
                {
                    solnNameSentence = Bot.Prompt(
                        "I'm sorry, We don't have a solution in that name. Please choose one of the above solutions to display it's description.");
                    solnName = Logic.ExtractKeyword(allSolutions, solnNameSentence);
                }
                Bot.PrintLine("The solution description is :");
                Bot.PrintData(SolutionsAccessor.GetDescription(solnName));
                string addcartSolution = Bot.Prompt("Do you want to Select this solution");
                if (addcartSolution.Contains("yes"))
                {
                    Cart.Solutions.Add(type);
                    Bot.PrintLine("The solution {0} is now added to your cart", type);
                }
                solnNameSentence = Bot.Prompt("Do you want to look for more solutions of the type '{0}' ? Mention the solution you want to choose.", type);
                if (solnNameSentence.Contains("what") || solnNameSentence.Contains("show"))
                {
                    Bot.PrintData(allSolutions);
                    solnNameSentence = Bot.Prompt("Here you go, Choose one from the above solutions to know more.");
                }
                solnName = Logic.ExtractKeyword(allSolutions, solnNameSentence);
                if (solnNameSentence.Contains("no"))
                {
                    return;
                }
            }

        }
    }

    
}
