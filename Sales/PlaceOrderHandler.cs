using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Sales
{
	public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
	{
		static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

		public Task Handle( PlaceOrder message, IMessageHandlerContext context )
		{
			log.Info( $"SALES - Received PlaceOrder, OrderId = {message.OrderId}\n" +
				$"Item = {message.Item} - Qty = {message.Quantity}\n\n" );
			//return Task.CompletedTask;

			// This is normally where some business logic would occur
			var orderPlaced = new OrderPlaced
			{
				OrderId = message.OrderId,
				Item = message.Item,
				Quantity = message.Quantity,
				Status = "Order placed."
			};
			return context.Publish( orderPlaced );
		}
	}
}
