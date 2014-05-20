using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InterestingFeatures
{
	class Program
	{
		static void Main(string[] args)
		{

		NeverUseGotos:
			Console.Write(@"Choices:
	1. Async/Await
	2. Coroutines
Choose wisely: ");
			var choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					AsyncAwait.Run();
					break;
				case "2":
					Coroutine.Run();
					break;
				default:
					Console.WriteLine("You have chosen poorly");
					goto NeverUseGotos;
			}
		}
	}
}
