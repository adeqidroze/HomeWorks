using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8CApp
{
    public abstract class FileWorkerClass
    {
        public int fileSize = 128 ;
        public abstract string Spread { get; }

        public abstract void Read();
        public abstract void Write();

        public abstract void Edit();

        public abstract void Delete();
        

    }

    class FileSorter : FileWorkerClass
    {
        public override string Spread { get => "txt"; }
     
        public override void Delete()
        {
            Console.WriteLine($"I can Delete from {Spread} with max storage {fileSize}");
        }

        public override void Edit()
        {
            Console.WriteLine($"I can Edit {Spread} with max storage {fileSize}");
        }

        public override void Read()
        {
            Console.WriteLine($"I can Read from {Spread} with max storage {fileSize}");
        }

        public override void Write()
        {
            Console.WriteLine($"I can Write to {Spread} with max storage {fileSize}");
        }
    }
}
