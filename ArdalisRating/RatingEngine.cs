using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public IRatingContext Context { get; set; } = new DefaultRatingContext();

        public RatingEngine()
        {

            Context.Engine = this;
        }


        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        public PolicySerializer PolicySerializer { get; set; } = new PolicySerializer();

        public decimal Rating { get; set; }
        public void Rate()
        {
            Context.Log("Starting rate.");

            Context.Log("Loading policy.");

            // load policy - open file policy.json
            // string policyJson = PolicySource.GetPolicyFromSource();
            string policyJson = Context.LoadPolicyFromFile();

            var policy = Context.GetPolicyFromJsonString(policyJson);

            // var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var rater = Context.CreateRaterForPolicy(policy, Context);

            //var factory = new RaterFactory();

            // var rater = factory.Create(policy, this);
            // rater?.Rate(policy);

            rater.Rate(policy);

            Logger.Log("Rating completed.");            
            Console.ReadKey();
        }
    }
}
