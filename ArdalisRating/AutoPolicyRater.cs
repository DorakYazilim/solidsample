using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        //private readonly RatingEngine _engine;
        //private readonly ConsoleLogger _logger;
        //public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger)
        //{
        //    _engine = engine;
        //    _logger = logger;
        //}
        //public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        //{

        //}

        //public AutoPolicyRater(IRatingContext context) : base(context)
        //{

        //}

        public AutoPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater)
        {

        }

        public override void Rate(Policy policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                Logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                //if (policy.Deductible < 500)
                //{
                //    _context.UpdateRating(1000m);
                //}
                //_context.UpdateRating(900m);

                if (policy.Deductible < 500)
                {
                    _ratingUpdater.UpdateRating(1000m);
                }
                _ratingUpdater.UpdateRating(900m);
            }
        }
    }
}
