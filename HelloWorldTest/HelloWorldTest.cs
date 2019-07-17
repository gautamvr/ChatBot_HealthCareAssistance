using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HelloWorld;

namespace HelloWorld
{
    [TestFixture]
    public class HelloWorldTest
    {
        [TestCase]
        public void HelloWorldStringTest()
        {
            string expected = "Hello World";
            Assert.AreEqual(expected, HelloWorld.HelloWorldString());
        }
    }
}