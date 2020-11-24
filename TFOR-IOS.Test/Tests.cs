using System;
using NUnit.Framework;
using System.Collections.Generic;
using TFOR_IOS;

namespace TFORIOS.test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TesttoPass()
        {
            ServerServices services = new ServerServices();

            List<Site> sites = services.GetSites();
            Assert.True(sites.Count > 0);
        }
    }
}
