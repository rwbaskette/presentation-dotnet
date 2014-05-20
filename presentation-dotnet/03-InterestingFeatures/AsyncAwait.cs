using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InterestingFeatures
{
	public class AsyncAwait
	{
		private const string PROMPT = "Who many would you like me to count to: ";

		public static void Run()
		{
			var prog = new AsyncAwait();
			while (true)
			{
				prog.Prompt();
				System.Threading.Thread.Sleep(100);
			}
		}

		public async Task Prompt()
		{
			Console.Write(PROMPT);
			var limitString = Console.ReadLine();
			int limit;
			if (!Int32.TryParse(limitString, out limit))
			{
				Console.WriteLine("Please enter a valid number");
				return;
			}

			int result = await this.Count(limit);
			Console.Write("\n\nDONE: That took {0} seconds to count to {1}\n\n{2}", result, limit, PROMPT);
		}

		public async Task<int> Count(int limit)
		{
			DateTime start = DateTime.Now;
			for (int i = 0; i <= limit; i++)
			{
				await Task.Delay(250);
			}
			return DateTime.Now.Subtract(start).Seconds;
		}
	}
}
