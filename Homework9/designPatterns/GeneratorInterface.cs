using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns
{
    interface IGenerator
    {
        IGenerator Reportgenerator(string format, List<string> inputText);
    }
    interface IStructureGenerator
    {
        bool Nextstage();
        bool IsDone(string stage);

        IStructureGenerator Reportgenerator(string format , List<string> inputText);
    }

    class Generator : IGenerator
    {
        public IGenerator Reportgenerator(string format, List<string> inputText)
        {
            throw new NotImplementedException();
        }
    }
    class FileStructurer : IStructureGenerator
    {
        private IGenerator generator;

       // public IStructureGenerator(IGenerator generator)
       // {
      //      this.generator = new Generator();
      //  }
        public bool IsDone(string stage)
        {       
            bool result = (stage == "footer") ?  true :  false;
            return result;
        }

        public bool Nextstage()
        {
            throw new NotImplementedException();
        }

        public IStructureGenerator Reportgenerator(string format, List<string> inputText)
        {
            throw new NotImplementedException();
        }
    }
}
