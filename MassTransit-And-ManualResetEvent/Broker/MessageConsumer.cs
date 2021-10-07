using MassTransit;
using System.Threading.Tasks;

namespace Broker
{

    public class MessageConsumer :
        IConsumer<Message>
    {
        public Task Consume(ConsumeContext<Message> context)
        {
            throw new System.Exception();
        }
    }
}
