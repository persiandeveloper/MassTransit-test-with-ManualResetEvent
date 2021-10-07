using Broker;
using MassTransit;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApp;
using Xunit;

namespace IntegrationTests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Test1()
        {
            // Arrange 

            var stubHelper = new StubHelper();

            var bus = (IBus)_factory.Services.GetService(typeof(IBus));

            bus.ConnectConsumeObserver(new ConsumeObserver(stubHelper));

            // Act
            await bus.Publish(new Message() { Text = "Test" });

            StubHelper.ManualResetEvent.WaitOne();


            // Assert
            Assert.True(stubHelper.ConsumeFailed);
        }
    }
}
