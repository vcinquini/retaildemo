using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Shipping
{
	public class OrderShippedHandler : IHandleMessages<OrderBilled>,
									IHandleMessages<OrderPlaced>
	{
		static ILog log = LogManager.GetLogger<OrderShippedHandler>();

		public Task Handle( OrderBilled message, IMessageHandlerContext context )
		{
			log.Info( $"SHIPPING - Received PlaceOrder, OrderId = {message.OrderId}\n" +
						$"Item = {message.Item} - Qty = {message.Quantity}\n" +
						$"Status = {message.Status} - Should we ship now?...\n\n" );

			return Task.CompletedTask;
		}

		public Task Handle( OrderPlaced message, IMessageHandlerContext context )
		{
			log.Info( $"SHIPPING - Received PlaceOrder, OrderId = {message.OrderId}\n" +
						$"Item = {message.Item} - Qty = {message.Quantity}\n" +
						$"Status = {message.Status} - Should we ship now?...\n\n" );

			return Task.CompletedTask;
		}

	}


	//public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
	//{
	//	static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

	//	public Task Handle( OrderPlaced message, IMessageHandlerContext context )
	//	{
	//		log.Info( $"SHIPPING - Received PlaceOrder, OrderId = {message.OrderId}\n" +
	//					$"Item = {message.Item} - Qty = {message.Quantity}\n" +
	//					$"Status = {message.Status} - Should we ship now?..." );

	//		return Task.CompletedTask;
	//	}
	//}
}