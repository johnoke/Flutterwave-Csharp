using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.Constants
{
    public class Environments
    {
        public const string Staging = "staging";
        public const string Production = "production";

        public static bool validateEnvironment(string env)
        {
            if (String.IsNullOrEmpty(env) || (env != Environments.Staging && env != Environments.Production))
            {
                throw new Exception("Env variable can only be either staging or production");
            }
            return true;
        }
    }
}
