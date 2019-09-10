namespace ArdalisRating
{
    public interface IRatingUpdater
    {
        void UpdateRating(decimal rating);
    }
    public interface IRatingContext :ILogger
    {
        RatingEngine Engine { get; set; }
        //ConsoleLogger Logger { get; set; }

        // void Log(string message);
        string LoadPolicyFromFile();
        Policy GetPolicyFromJsonString(string policyJson);
        Rater CreateRaterForPolicy(Policy policy, IRatingContext context);
        // void UpdateRating(decimal rating);        
    }
}