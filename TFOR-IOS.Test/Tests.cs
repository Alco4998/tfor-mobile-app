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
        public void TestSitesGet()
        {
            ServerServices services = new ServerServices();

            List<Site> sites = services.GetSites();
            Assert.True(sites.Count > 0);
        }

        [Test]
        public void TestSightingVaild()
        {
            Sighting sight = new Sighting(1, "Magpie", "3");
            Assert.True(sight.VaildForSighting());
        }

        [Test]
        public void TestSightingInvaild()
        {
            Sighting sight = new Sighting(1,"","0");
            Assert.False(sight.VaildForSighting());
        }

        [Test]
        public void TestBirdSurveyVaild()
        {
            BirdSurvey survey = new BirdSurvey(
                new DateTime(2020,11,24),
                new DateTime(2020,10,24, 10,35,00),
                new DateTime(2020, 10, 24, 10, 55, 00),
                new Site(1, "Rock Pool", "Pool"),
                new[] { new Sighting(1, "Magpie", "3")},
                "Comments");

            Assert.True(survey.VaildforBirdSurvey());
        }

        [Test]
        public void TestBirdSurveyInvaild()
        {
            BirdSurvey survey = new BirdSurvey(
                new DateTime(2020, 11, 24),
                new DateTime(2020, 10, 24, 10, 35, 00),
                new DateTime(2020, 10, 24, 10, 35, 00),
                new Site(1, "Rock Pool", "Pool"),
                new[] { new Sighting(1, "Magpie", "3") },
                "Comments");

            Assert.False(survey.VaildforBirdSurvey());
        }
    }
}
