using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns
{
    internal class ArtDeco : IFactoryInterface
    {
        public string FactoryCreateChair()
        {
            return "Chair";
        }

        public string FactoryCreateCoTable()
        {
            return "Coffee table";

        }

        public string FactoryCreateSofa()
        {
            return "Sofa";
        }

        public void HasLegs(string furnitureType)
        {
            if(furnitureType == "Chair")
                Console.WriteLine("New Art Deco Chair has legs.");
            if (furnitureType == "Sofa")
                Console.WriteLine("New Art Deco sofa has legs.");
            else
                Console.WriteLine("New Art Deco Coffee table has no legs.");
        }

        public void SitOn(string furnitureType)
        {
            if (furnitureType == "Chair")
                Console.WriteLine("You can sit on Chair.");
            if (furnitureType == "Sofa")
                Console.WriteLine("You can sit on Sofa.");
            else
                Console.WriteLine("You can not sit on Coffee table.");
        }
    }
}
