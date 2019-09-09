namespace ArdalisRating
{
    public abstract class Rater
    {
        //public readonly RatingEngine _engine;
        //public readonly ConsoleLogger _logger;
        //public Rater(RatingEngine engine, ConsoleLogger logger)
        //{
        //    _engine = engine;
        //    _logger = logger;
        //}

        public readonly IRatingContext _context;
        // public readonly ConsoleLogger _logger;

        // public readonly ILogger _logger;

        public ILogger Logger { get; set; } = new ConsoleLogger();

        protected readonly IRatingUpdater _ratingUpdater;

        public Rater(IRatingUpdater ratingUpdater)
        {
            // _context = context;
            // _logger = context.Logger;

            _ratingUpdater = ratingUpdater;
        }


        public virtual void Rate(Policy policy)
        { }
    }
}