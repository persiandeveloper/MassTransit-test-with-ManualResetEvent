using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class ConsumeObserver : IConsumeObserver
    {
        private readonly StubHelper stubHelper;

        public ConsumeObserver(StubHelper stubHelper)
        {
            this.stubHelper = stubHelper;
        }

        public Task ConsumeFault<T>(ConsumeContext<T> context, Exception exception) where T : class
        {
            this.stubHelper.ConsumeFailed = true;
            StubHelper.ManualResetEvent.Set();
            return Task.CompletedTask;
        }

        public Task PostConsume<T>(ConsumeContext<T> context) where T : class
        {
            return Task.CompletedTask;
        }

        public Task PreConsume<T>(ConsumeContext<T> context) where T : class
        {
            return Task.CompletedTask;
        }
    }
}
