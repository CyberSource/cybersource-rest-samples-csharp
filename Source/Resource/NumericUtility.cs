using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Resource
{
    public class NumericUtility
    {
        public static string LongRandom(int min, int max)
        {
            Random generator = new Random();
            string r = generator.Next(min, max).ToString("D8");
            return r;
        }
    }
}
