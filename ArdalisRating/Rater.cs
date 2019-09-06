namespace ArdalisRating
{
    public abstract class Rater
    {
        public readonly RatingEngine _engine;
        public readonly ConsoleLogger _logger;
        public Rater(RatingEngine engine, ConsoleLogger logger)
        {
            _engine = engine;
            _logger = logger;
        }
        public virtual void Rate(Policy policy)
        { }
    }
}