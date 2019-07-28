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
    using DataLayer;
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
            Assert.AreEqual(Logic.ExtractKeyword(monitorTestData1,testSentence1),"bedside monitor");
            Assert.AreEqual(Logic.ExtractKeyword(monitorTestData1, testSentence2), "high end monitor");
            Assert.AreEqual(Logic.ExtractKeyword(monitorTestData1, testSentence3), "vital signs monitor");
            Assert.AreEqual(Logic.ExtractKeyword(monitorTestData1, testSentence4), "maternity and fatal monitor");
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
        public void TestGetModelsFromCategory()
        {
            string category1 = "bedside monitor";
            string category2 = "high end monitors";
            string category3 = "vital signs monitor";
            string category4 = "maternity and fetal monitor";
            string models1 = "MX400     \nMX450     \nMX500     \nMX550     \nMX700     \nMX800     \nMP2       \nMP5       ";
            string models2 = "CM SERIES \nCMS200    ";
            string models3 = "VM1       \nVM4       \nVM6       \nVM8       \nVSI       \nVS2+      ";
            string models4 = "CL        \nFM20      \nFM30      \nFM40      \nFM50      ";
            Assert.AreEqual(models1, MonitorLogic.GetModels(category1));
            Assert.AreEqual(models2,MonitorLogic.GetModels(category2));
            Assert.AreEqual(models3,MonitorLogic.GetModels(category3));
            Assert.AreEqual(models4,MonitorLogic.GetModels(category4));
        }

        [Test]
        public void TestGetModelsOnSpec()
        {
            string models1 = "MX400     \nVM1       \nVM4       ";
            string models2 = "MX700     \nMX800     \nVS2+      \nCM SERIES \nCMS200    ";
            string models3 = "MX400     \nVM1       \nVM4       ";
            string query1 = "I want a monitor with 9' touch screen";
            string query2 = "I want a non-portable monitor";
            string query3 = "I want a portable 9' touch screen monitor";
            Assert.AreEqual(models1,MonitorLogic.GetModelOnSpecifications(query1));
            Assert.AreEqual(models2,MonitorLogic.GetModelOnSpecifications(query2));
            Assert.AreEqual(models3,MonitorLogic.GetModelOnSpecifications(query3));
        }
        [Test]
        public void TestGetSolutions()
        {
            string solutions1 = "ISAR\nISEM\nIVIC-Xi";
            string solutions2 = "IGS                                               ";
            string solutions3 = "CDS Online Electronic help                        ";
            string category1 = "CSA";
            string category2 = "EWES";
            string category3 = "Clinical Decision Support";
            Assert.AreEqual(solutions1,SolutionLogic.GetSolution(category1));
            Assert.AreEqual(solutions2, SolutionLogic.GetSolution(category2));
            Assert.AreEqual(solutions3, SolutionLogic.GetSolution(category3));

        }
        
    }
}
