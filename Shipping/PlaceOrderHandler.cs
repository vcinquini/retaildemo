using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Shipping
{
	public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
	{
		static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

		public Task Handle( PlaceOrder message, IMessageHandlerContext context )
		{
			log.Info( $"SHIPPING - Received PlaceOrder, OrderId = {message.OrderId}" );
			//return Task.CompletedTask;

			// This is normally where some business logic would occur
			var orderPlaced = new OrderPlaced
			{
				OrderId = message.OrderId
			};
			return context.Publish( orderPlaced );
		}
	}
}
