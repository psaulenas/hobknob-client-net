﻿using NUnit.Framework;
using System.Collections.Generic;

namespace HobknobClientNet.Tests.Scenarios
{
    internal class GetAll : TestBase
    {
        Dictionary<string, bool> _toggles;

        [SetUp]
        public void SetUp()
        {
            Set_application_name("app1");
        }

        [Test]
        public void Get_all_toggles_for_the_given_application()
        {
            var _expected = new Dictionary<string, bool>()
            {
                { "feature1", false },
                { "feature2", true },
                { "feature3/toggle1", true }
            };

            Given_a_toggle("app1", "feature1", "false");
            Given_a_toggle("app1", "feature2", "true");
            Given_a_toggle("app1", "feature3", "toggle1", "true");
            Given_a_toggle("app2", "feature2", "true");
            Given_a_toggle("app2", "feature3", "toggle1", "true");
            When_I_get_all_the_toggles(out _toggles);
            CollectionAssert.AreEquivalent(_toggles, _expected);
        }
    }
}
