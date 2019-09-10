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

    public class FakeRatingUpdater : IRatingUpdater
    {
        public decimal? NewRating { get; private set; }
        public void UpdateRating(decimal rating)
        {
            NewRating = rating;
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
            string rtn = logger.LoggedMessages.Last();
            Assert.Equal("Auto policy must specify Make", rtn);

        }
        [Fact]
        public void SetRatingTo1000ForBMWWith250Deductible()
        {
            var policy = new Policy()
            {
                Type = PolicyType.Auto,
                Make = "BMW",
                Deductible = 250m
            };
            var ratingUpdater = new FakeRatingUpdater();
            var rater = new AutoPolicyRater(ratingUpdater);

            rater.Rate(policy);

            Assert.Equal(1000m, ratingUpdater.NewRating.Value);
        }
    }
}
