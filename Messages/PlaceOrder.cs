using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NServiceBus;

namespace Messages
{
    public class PlaceOrder : ICommand
    {
		public string OrderId { get; set; }
		public int Quantity { get; set; }
		public string Item { get; set; }
	}
}