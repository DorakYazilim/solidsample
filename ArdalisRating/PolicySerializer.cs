using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class PolicySerializer
    {
        public Policy GetPolicyFromJsonString(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<Policy>(jsonString, new StringEnumConverter());
            }
            catch
            {
                return null;
            }
        }
    }
}
