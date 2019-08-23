using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BusinessLayerTest
{
    using BusinessLayer;
    
    [TestFixture]
    public class BusinessLayerTest
    {
        [Test]
        public void TestExtractKeyword()
        {
            string monitorTestData1 = "bedside monitor\nhigh end monitor\nvital signs monitor\nmaternity and fatal monitor";
            string testSentence1 = "I want a Bedside Monitor";
            string testSentence2 = "Show me a High End monitor";
            string testSentence3 = "Vital Signs monitor would work.";
            string testSentence4 = "Can you give me details about maternity and fatal monitor";
            string testSentence5 = "There is no keyword in this sentence";
            Assert.AreEqual( "bedside monitor",Logic.ExtractKeyword(monitorTestData1,testSentence1));
            Assert.AreEqual("high end monitor",Logic.ExtractKeyword(monitorTestData1, testSentence2));
            Assert.AreEqual("vital signs monitor",Logic.ExtractKeyword(monitorTestData1, testSentence3));
            Assert.AreEqual("maternity and fatal monitor",Logic.ExtractKeyword(monitorTestData1, testSentence4));
            Assert.AreEqual("there is no keyword in this sentence", Logic.ExtractKeyword(monitorTestData1, testSentence5));
        }

        [Test]
        public void TestHashSetParser()
        {
            string monitorTestData1 = "bedside monitor\nhigh end monitor\nvital signs monitor\nmaternity and fatal monitor";
            HashSet<string> outputHash= new HashSet<string>();
            outputHash.Add("bedside monitor");
            outputHash.Add("high end monitor");
            outputHash.Add("vital signs monitor");
            outputHash.Add("maternity and fatal monitor");
            Assert.AreEqual(Logic.ParseToHashSet(monitorTestData1),outputHash);
        }

        [Test]
        public void TestGetCategories()
        {
            string output = "bedside monitor\nhigh end monitors\nmaternity and fetal monitor\nvital signs monitor";
            Assert.AreEqual(output,MonitorAccessor.GetSerialName());
        }

        [Test]
        public void TestGetModelsFromCategory()
        {
            string category1 = "bedside monitor";
            string category2 = "high end monitors";
            string category3 = "vital signs monitor";
            string category4 = "maternity and fetal monitor";
            string models1 = "MX400\nMX450\nMX500\nMX550\nMX700\nMX800\nMP2\nMP5";
            string models2 = "CM SERIES\nCMS200";
            string models3 = "VM1\nVM4\nVM6\nVM8\nVSI\nVS2+";
            string models4 = "CL\nFM20\nFM30\nFM40\nFM50";
            Assert.AreEqual(models1, MonitorAccessor.GetModels(category1));
            Assert.AreEqual(models2,MonitorAccessor.GetModels(category2));
            Assert.AreEqual(models3,MonitorAccessor.GetModels(category3));
            Assert.AreEqual(models4,MonitorAccessor.GetModels(category4));
        }

        [Test]
        public void TestGetModelsOnSpec()
        {
            string models1 = "MX400\nVM1\nVM4";
            string models2 = "MX700\nMX800\nCM SERIES";
            string models3 = "MP5\nVSI";
            string test1spec2 = "9 Inch Touch Screen";
            string test1spec1 = "Portable";
            string test2spec2 = "15 Inch Touch Screen";
            string test2spec1 = "Non-Portable";
            string test3spec2 = "5.5 Inch Touch Screen";
            string test3spec1 = "Portable";
            Assert.AreEqual(models1,MonitorAccessor.GetModelOnSpecifications(test1spec1,test1spec2));
            Assert.AreEqual(models2,MonitorAccessor.GetModelOnSpecifications(test2spec1,test2spec2));
            Assert.AreEqual(models3,MonitorAccessor.GetModelOnSpecifications(test3spec1,test3spec2));
        }
        [Test]
        public void TestGetSolutions()
        {
            string solutions1 = "ISAR\nISEM\nIVIC-Xi";
            string solutions2 = "IGS";
            string solutions3 = "CDS Online Electronic help";
            string category1 = "CSA";
            string category2 = "EWES";
            string category3 = "Clinical Decision Support";
            Assert.AreEqual(solutions1,SolutionsAccessor.GetSolution(category1));
            Assert.AreEqual(solutions2, SolutionsAccessor.GetSolution(category2));
            Assert.AreEqual(solutions3, SolutionsAccessor.GetSolution(category3));

        }

        [Test]
        public void TestGetCategoriesForSolutions()
        {
            string output = "Clinical Decision Support\nCSA\nEWES";
            Assert.AreEqual(output,SolutionsAccessor.GetSolutionName());
        }

        [Test]
        public void TestReturnSpec()
        {
            int testnum1 = 1;
            int testnum2 = 2;
            int testnum3 = 3;
            string testspec1 = "Spec1";
            string testspec2 = "Spec2";
            string testspec3 = "Spec2";
            Assert.AreEqual("Non-Portable", Logic.ReturnSpec(testnum1, testspec1));
            Assert.AreEqual("15 Inch Touch Screen", Logic.ReturnSpec(testnum2, testspec2));
            Assert.AreEqual("4.5 Inch Touch Screen", Logic.ReturnSpec(testnum3, testspec3));
        }

        [Test]
        public void TestParseDictToStr()
        {
            var testDict1 = new Dictionary<int, string>()
            {
                {1,"One" },
                {2,"Two" },
                {3,"Three" }
            };
            var testDict2 = new Dictionary<int, string>()
            {
                {100,"One Hundred             " },
                {20,"Twenty     " },
                {40,"Forty    " }
            };
            var testDict3 = new Dictionary<int, string>()
            {
                {16,"Sixteen" },
                {18,"Eighteen    " },
                {11,"Eleven   " }
            };
            string output1 = "1  --->  One\n2  --->  Two\n3  --->  Three\n4  --->  Anything";
            string output2 = "100  --->  One Hundred\n20  --->  Twenty\n40  --->  Forty\n4  --->  Anything";
            string output3 = "16  --->  Sixteen\n18  --->  Eighteen\n11  --->  Eleven\n4  --->  Anything";
            Assert.AreEqual(output1, Logic.ParseDictToString(testDict1));
            Assert.AreEqual(output2, Logic.ParseDictToString(testDict2));
            Assert.AreEqual(output3, Logic.ParseDictToString(testDict3));
        }

        [Test]
        public void TestReturnList()
        {
            var testList1 = new List<string>()
            {
                "One",
                "Two",
                "Three",
                "Four"
            };
            var testList2 = new List<string>()
            {
                "item1",
                "item2",
                "item3"
            };
            var output1 = "One\nTwo\nThree\nFour\n";
            var output2 = "item1\nitem2\nitem3\n";
            Assert.AreEqual(output1, Logic.ReturnList(testList1));
            Assert.AreEqual(output2, Logic.ReturnList(testList2));
        }
        
        [Test]
        public void TestGetAllSpecs()
        {
            string test1 = "Spec1";
            string test2 = "Spec2";
            string output1 = "1  --->  Non-Portable\n2  --->  Portable\n3  --->  Anything";
            string output2 = "1  --->  12 Inch Touch Screen\n2  --->  15 Inch Touch Screen\n3  --->  4.5 Inch Touch Screen\n4  --->  5.5 Inch Touch Screen\n5  --->  9 Inch Touch Screen\n6  --->  NA\n7  --->  Anything";
            Assert.AreEqual(output1, Logic.GetAllSpec(test1));
            Assert.AreEqual(output2, Logic.GetAllSpec(test2));
        }

        [Test]
        public void TestGetSpecification()
        {
            string testmodel1 = "MX400";
            string output1 = "MX400\n   Portable\n   9 Inch Touch Screen\n   Wireless Data transfer to EMR\n   For more inforrmation visit : https://www.philips.co.in/healthcare/product/HC866060/intellivue-mx400-portablebedside-patient-monitortient-monitoring";
            Assert.AreEqual(output1, MonitorAccessor.GetSpecification(testmodel1));
        }

        [Test]
        public void TestGetDistinctSpecs()
        {
            string output = "Non-Portable\nPortable\n12 Inch Touch Screen\n15 Inch Touch Screen\n4.5 Inch Touch Screen\n5.5 Inch Touch Screen\n9 Inch Touch Screen\nNA";
            Assert.AreEqual(output, MonitorAccessor.GetDistinctSpecs());
        }

        [Test]
        public void TestGetDistinctModelNames()
        {
            string output = "CL\nCM SERIES\nCMS200\nFM20\nFM30\nFM40\nFM50\nMP2\nMP5\nMX400\nMX450\nMX500\nMX550\nMX700\nMX800\nVM1\nVM4\nVM6\nVM8\nVS2+\nVSI";
            Assert.AreEqual(output, MonitorAccessor.GetDistinctModelNames());
        }

        [Test]
        public void TestGetDescription()
        {
            string test1 = "IGS";
            string test2 = "ISAR";
            string output1 = "The EWS movement helps doctors, nurses, and staff detect subtle signs of deterioration, assisting with early intervention. The solution allows you to see early warning scores right in the spot-check monitor, giving you all the information you need, at the point of care.\n   Detects deviations to spot subtle signs of deterioration\n   Informs responsible clinicians for early, effective intervention\n   https://www.philips.co.in/healthcare/product/HCNOCTN60/intellivue-guardian-solution-early-warning-scoring-solution";
            string output2 = "This solution offers you an all-in-one option that tackles both sides of the situation. It’s easy to implement, with reports developed using best practices gained from years of alarm management expertise. Our experienced clinical specialists analyze the information and provide education and training for your team to do the same. We help set up protocols tailored to your organization, using insights gleaned from your individual patient population.\n   Custom reports to identify trends in your information\n   End-to-end solution to provide actionable information\n   https://www.philips.co.in/healthcare/product/HCNOCTN60/intellivue-guardian-solution-early-warning-scoring-solution";
            Assert.AreEqual(output1, SolutionsAccessor.GetDescription(test1));
            Assert.AreEqual(output2, SolutionsAccessor.GetDescription(test2));
        }
    }
}
