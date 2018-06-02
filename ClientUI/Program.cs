﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace ClientUI
{
	class Program
	{
		static ILog log = LogManager.GetLogger<Program>();

		public static async Task Main( string[] args )
		{
			/****** CONFIGURATION CODE ******/
			Console.Title = "ClientUI";

			var endpointConfiguration = new EndpointConfiguration( "ClientUI" );

			var transport = endpointConfiguration.UseTransport<LearningTransport>();

			var routing = transport.Routing();
			routing.RouteToEndpoint( typeof( PlaceOrder ), "Sales" );

			/****** STARTING UP ******/
			var endpointInstance = await Endpoint
						.Start( endpointConfiguration )
						.ConfigureAwait( false );

			await RunLoop( endpointInstance )
						.ConfigureAwait( false );

			await endpointInstance.Stop()
						.ConfigureAwait( false );

		}

		static async Task RunLoop( IEndpointInstance endpointInstance )
		{
			Random r = new Random();

			while (true)
			{
				log.Info( "Press 'P' to place an order, or 'Q' to quit." );
				var key = Console.ReadKey();
				Console.WriteLine();

				switch (key.Key)
				{
					case ConsoleKey.P:
						// Instantiate the command
						var command = new PlaceOrder
						{
							OrderId = Guid.NewGuid().ToString(),
							Item = r.Next().ToString(),
							Quantity = r.Next()
						};

						// Send the command to the local endpoint
						log.Info( $"Sending PlaceOrder command, OrderId = {command.OrderId}\n\n" );
						await endpointInstance.Send( command )
							.ConfigureAwait( false );

						break;

					case ConsoleKey.Q:
						return;

					default:
						log.Info( "Unknown input. Please try again.\n\n" );
						break;
				}
			}
		}
	}
}
