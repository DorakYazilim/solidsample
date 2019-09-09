namespace ArdalisRating
{
    internal class DefaultRatingContext: IRatingContext
    {
        public DefaultRatingContext()
        {
        }

        public RatingEngine Engine { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        // public ConsoleLogger Logger => new ConsoleLogger();

        public ConsoleLogger Logger { get => new ConsoleLogger(); set => throw new System.NotImplementedException(); }

        public Rater CreateRaterForPolicy(Policy policy, IRatingContext context)
        {
            //throw new System.NotImplementedException();
            return new RaterFactory().Create(policy, context);
        }

        public Policy GetPolicyFromJsonString(string policyJson)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}