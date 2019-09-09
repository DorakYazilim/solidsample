using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ArdalisRating.Tests
{
    public class FakeLogger : ILogger
    {
        public List<string> LoggedMessages { get; } = new List<string>();
        public void Log(string message)
        {
            LoggedMessages.Add(message);
        }
    }

    public class AutoPolicyRaterRate
    {
        [Fact]
        public void LogsMakeRquiredMessageGivenPolicyWithoutMake()
        {
            var policy = new Policy() { Type = PolicyType.Auto };
            var logger = new FakeLogger();
            var rater = new AutoPolicyRater(null);
            rater.Logger = logger;

            rater.Rate(policy);

            Assert.Equal("Auto Policy must specify Make", logger.LoggedMessages.Last());

        }
    }
}
