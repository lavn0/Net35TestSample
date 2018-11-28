using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net35TestSample
{
    public class AsyncSample
    {
        public async Task<string> GetTitleAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            return "Hello World.";
        }
    }
}
