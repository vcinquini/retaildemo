﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Billing
{
	class Program
	{
		public static async Task Main()
		{
			Console.Title = "Billing";

			var endpointConfiguration = new EndpointConfiguration( "Billing" );

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
