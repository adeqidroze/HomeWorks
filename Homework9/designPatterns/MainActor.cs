using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns
{
    internal class MainActor : ProxyInterface
    {
        public void PerformanceDangerLvl(string role)
        {
            Console.WriteLine("Performance danger level: <LOW>");
        }

        public void PerformInMovieAccess(string role)
        {
            Console.WriteLine("Access granted");
        }
    }
}
