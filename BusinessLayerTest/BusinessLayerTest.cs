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
    }
}
