using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns
{
    public interface IFactoryInterface : IChair, ICoffeeTable,ISofa
    {
        public string FactoryCreateChair();
        public string FactoryCreateSofa();
        public string FactoryCreateCoTable();

    }

    public interface IChair 
    {
        public void SitOn(string furnitureType);
        public void HasLegs(string furnitureType);
    }

    public interface ICoffeeTable
    {
        public void SitOn(string furnitureType);
        public void HasLegs(string furnitureType);
    }

    public interface ISofa 
    {
        public void SitOn(string furnitureType);
        public void HasLegs(string furnitureType);
    }
}
