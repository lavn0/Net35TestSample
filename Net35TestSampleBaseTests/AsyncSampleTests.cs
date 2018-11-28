using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net35TestSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net35TestSample.Tests
{
    [TestClass()]
    public class AsyncSampleTests
    {
        [TestMethod()]
        public void GetTitleAsyncTest()
        {
            var sample = new AsyncSample();
            var title = sample.GetTitleAsync().Result;
            Assert.AreEqual("Hello World.", title);
        }
    }
}