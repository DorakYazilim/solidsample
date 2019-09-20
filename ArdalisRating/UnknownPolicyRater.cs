using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class UnknownPolicyRater : Rater
    {
        private IRatingContext context;

        public UnknownPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater)
        {

        }

        //public UnknownPolicyRater(IRatingContext context) :base (context)
        //{
        //    this.context = context;
        //}

        //public UnknownPolicyRater(RatingEngine engine,ConsoleLogger logger) : base ( engine, logger)
        //{

        //}
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Rate(Policy policy)
        {
            //base.Rate(policy);
            Logger.Log("Unknown policy type !!!");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
