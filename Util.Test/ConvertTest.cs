using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Util.Test
{
    [TestClass]
    public class ConvertTest
    {
        [TestMethod]
        public void TestToInt_Null()
        {
            Assert.AreEqual(0,ConverHelper.ToInt(null));
        }

        [TestMethod]
        public void TestToInt_Empty()
        {
            Assert.AreEqual(0,ConverHelper.ToInt(""));
        }
    }
}
