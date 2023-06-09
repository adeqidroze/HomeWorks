using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns
{
    internal class SecureActors : ProxyInterface
    {
        private readonly ProxyInterface proxyInterface;

        public SecureActors(ProxyInterface proxyInterface)
        {
            this.proxyInterface = proxyInterface;
        }
        public void PerformanceDangerLvl(string role)
        {
            if(role.ToLower() == "main" || role.ToLower() == "stunt double")
            {
                this.proxyInterface.PerformanceDangerLvl(role);
            }
            else
            {
                throw new UnauthorizedAccessException($"Danger level unknown for {role}s");
            }
        }

        public void PerformInMovieAccess(string role)
        {
            if (role.ToLower() == "main" || role.ToLower() == "stunt double")
            {
                this.proxyInterface.PerformanceDangerLvl(role);
            }
            else
            {
                throw new UnauthorizedAccessException($"Access denied for {role}s");
            }
        }
    }
}
