﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Sales
{
	public class Program
	{
		public static async Task Main()
		{
			Console.Title = "Sales";

			var endpointConfiguration = new EndpointConfiguration( "Sales" );

			var transport = endpointConfiguration.UseTransport<LearningTransport>();

			var endpointInstance = await Endpoint.Start( endpointConfiguration )
				.ConfigureAwait( false );

			Console.WriteLine( "Press Enter to exit." );
			Console.ReadLine();

			await endpointInstance.Stop()
				.ConfigureAwait( false );
		}
	}
}
