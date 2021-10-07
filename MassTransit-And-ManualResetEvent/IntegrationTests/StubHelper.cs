using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class StubHelper
    {
        public static ManualResetEvent ManualResetEvent { get; }

        static StubHelper()
        {
            ManualResetEvent = new ManualResetEvent(false);
        }

        public bool ConsumeFailed { get; set; }
    }
}
