using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosServerCore.Model
{
    public class RandomNumberHandler
    {
        private Random random = new Random();
             
        public double GenerateLambdaRandomNumber(double minValue, double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        public double GenerateXRandomNumber(double minValue, double maxValue)
        {
            return Math.Round((random.NextDouble()*(maxValue - minValue) + minValue), 2);
        }
    }
}
