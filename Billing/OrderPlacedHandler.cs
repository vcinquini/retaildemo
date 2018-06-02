using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
	public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
	{
		static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

		public Task Handle( OrderPlaced message, IMessageHandlerContext context )
		{
			log.Info( $"BILLING - Received PlaceOrder, OrderId = {message.OrderId}\n" +
						$"Item = {message.Item} - Qty = {message.Quantity}\n" +
						$"Status = {message.Status} - Charging credit card...\n\n" );

			// This is normally where some business logic would occur
			var orderBilled = new OrderBilled
			{
				OrderId = message.OrderId,
				Item = message.Item,
				Quantity = message.Quantity,
				Status = "Credit card charged, order billed."

			};
			return context.Publish( orderBilled );
		}
	}
}