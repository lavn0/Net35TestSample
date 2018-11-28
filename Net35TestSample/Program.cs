using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net35TestSample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            var sample = new AsyncSample();
            var title = await sample.GetTitleAsync();
            Console.WriteLine(title);
            Console.WriteLine("Please Enter.");
            Console.ReadLine();
        }
    }
}
