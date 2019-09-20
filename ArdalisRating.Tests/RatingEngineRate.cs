using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        private ILogger _logger;
        private RatingEngine _engine;
        public RatingEngineRate()
        {
            _logger = new FakeLogger();
            _engine = new RatingEngine(_logger);
        }
        //[Fact]
        //public void ReturnsRatingOf10000For200000LandPolicy()
        //{
        //    var policy = new Policy
        //    {
        //        Type = PolicyType.Land,
        //        BondAmount = 200000,
        //        Valuation = 210000
        //    };
        //    string json = JsonConvert.SerializeObject(policy);
        //    File.WriteAllText("policy.json", json);

        //    var engine = new RatingEngine();
        //    engine.Rate();
        //    var result = engine.Rating;

        //    Assert.Equal(10000, result);            
        //}

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            
            _engine.Rate();
            var result = _engine.Rating;

            Assert.Equal(0, result);            
        }
        [Fact]
        public void ReturnsDefaultPolicyFromEmptyJsonString()
        {
            var inputJson = "{}";
            var serializer = new PolicySerializer();
            var result = serializer.GetPolicyFromJsonString(inputJson);

            var policy = new Policy();
            Assert.Equal(result.Amount, policy.Amount);
            // AssertPoliciesEqual(result, policy);
        }
        private void AssertPoliciesEqual(Policy result, Policy policy)
        {
            Assert.Equal(result,policy);
        }
    }
}
