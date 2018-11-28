using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net35TestSample
{
    public class AsyncSample
    {
        public Task<string> GetTitleAsync() => Task.FromResult("Hello World.");
    }
}
