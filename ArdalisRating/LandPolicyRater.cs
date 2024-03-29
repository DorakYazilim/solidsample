﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LandPolicyRater : Rater
    {
        //private readonly RatingEngine _engine;
        //private readonly ConsoleLogger _logger;
        //public LandPolicyRater(RatingEngine engine, ConsoleLogger logger)
        //{
        //    _engine = engine;
        //    _logger = logger;
        //}

        //public LandPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        //{

        //}

        public LandPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater)
        {

        }

        public override void Rate(Policy policy)
        {
            Logger.Log("Rating LAND policy...");
            Logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
                return;
            }
            _ratingUpdater.UpdateRating(policy.BondAmount * 0.05m);
        }
    }
}
