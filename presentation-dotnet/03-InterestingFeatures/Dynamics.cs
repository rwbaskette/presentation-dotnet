using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InterestingFeatures
{
	public class Dynamics
	{
		public static void Run()
		{
			var o = new Dynamics();
			o.DynamicsExample();
			Console.Write("\n\n");

			o.ObjectExmaple();
			Console.ReadLine();
		}

		public void DynamicsExample()
		{
			dynamic dynvar = "I'm a string";
			Console.WriteLine("Value or dynvar is: {0}", dynvar);

			dynvar = 0;
			Console.WriteLine("Value or dynvar is: {0}", dynvar);

			dynvar = DateTime.Now;
			Console.WriteLine("Value or dynvar is: {0:d}", dynvar);


		}

		public void ObjectExmaple()
		{
			dynamic obj = new ExpandoObject();
			obj.Title = "Tycho Monolith Anomaly 1";
			obj.CreatedUTC = DateTime.UtcNow;
			obj.Height = 10.0;
			obj.Width = 5.5;
			obj.Depth = 12.0;
			obj.ComputeVolume = new Func<double>(() => obj.Height * obj.Width * obj.Depth);

			Console.WriteLine("Object '{0}' has a volume of {1}", obj.Title, obj.ComputeVolume());
		}
	}
}
