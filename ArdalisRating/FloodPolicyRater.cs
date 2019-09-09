using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class FloodPolicyRater: Rater
    {
        //public FloodPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        //{

        //}
        public FloodPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater)
        {

        }
        public override void Rate(Policy policy)
        {
            // base.Rate(policy);
            Logger.Log("Rating Flood policy...");
            Logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Flood policy must specify Bound Amoun and Valuation..");
                return;
            }
            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                Logger.Log("Flood policy is not available above Sea Level 0..");
                return;
            }
            decimal multiple = 1.0m;
            if (policy.ElevationAboveSeaLevelFeet < 100)
            {
                multiple = 2.0m;
            }
            else if (policy.ElevationAboveSeaLevelFeet < 1000)
            {
                multiple = 1.3m;
            }
            _ratingUpdater.UpdateRating(policy.BondAmount * 0.05m * multiple);


        }
    }
}
