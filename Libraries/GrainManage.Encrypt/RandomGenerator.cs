using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Encrypt
{
    public class RandomGenerator
    {
        public static string Next(int length, string seed = "")
        {
            const string initialSeed = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(seed))
            {
                seed = initialSeed;
            }
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, seed.Length);
                builder.Append(Convert.ToString(seed[index]));
            }
            return builder.ToString();
        }
    }
}
