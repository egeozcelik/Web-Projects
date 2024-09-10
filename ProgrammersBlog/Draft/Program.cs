using System;
using System.Threading;
using System.Threading.Tasks;

namespace Draft
{
    class Program
    {
        static void Main(string[] args)
        {
         //   Thread.Sleep(2000);
             
           
            Console.WriteLine("Hello World!");
            Task t2 = Task.Run(() => { Console.WriteLine("taskli merhaba dünya 2"); });
            Task t = Task.Run(() => { Console.WriteLine("taskli merhaba dünya"); });
        }
    }
}
