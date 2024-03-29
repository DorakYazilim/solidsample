﻿namespace ArdalisRating
{
    internal class DefaultRatingContext: IRatingContext
    {
        public DefaultRatingContext()
        {
        }

        public RatingEngine Engine { get; set ; }
        // public ConsoleLogger Logger => new ConsoleLogger();

        //public ConsoleLogger Logger { get => new ConsoleLogger(); set => throw new System.NotImplementedException(); }

        //public Rater CreateRaterForPolicy(Policy policy, IRatingUpdater updater)
        //{
        //    //throw new System.NotImplementedException();
        //    return new RaterFactory().Create(policy, updater);
        //}

        public Rater CreateRaterForPolicy(Policy policy, IRatingContext context)
        {
            return new RaterFactory().Create(policy, context);
        }

        public Policy GetPolicyFromJsonString(string policyJson)
        {
            //throw new System.NotImplementedException();
            var serializer = new PolicySerializer();
            return serializer.GetPolicyFromJsonString(policyJson);
        }

        public string LoadPolicyFromFile()
        {
            //throw new System.NotImplementedException();
            return new FilePolicySource().GetPolicyFromSource();
        }

        public void Log(string message)
        {
            //throw new System.NotImplementedException();
            new ConsoleLogger().Log(message);
        }

        public void UpdateRating(decimal rating)
        {
            new ConsoleLogger().Log("Rating Updated To : " + rating.ToString("##"));
            //throw new System.NotImplementedException();
        }
    }
}