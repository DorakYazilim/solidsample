using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class FloodPolicyRater: Rater
    {
        public FloodPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {

        }
        public override void Rate(Policy policy)
        {
            // base.Rate(policy);
            _logger.Log("Rating Flood policy...");
            _logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Log("Flood policy must specify Bound Amoun and Valuation..");
                return;
            }
            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                _logger.Log("Flood policy is not available above Sea Level 0..");
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
            _engine.Rating = policy.BondAmount * 0.05m * multiple;


        }
    }
}
