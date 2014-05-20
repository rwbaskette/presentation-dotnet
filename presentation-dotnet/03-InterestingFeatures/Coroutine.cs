using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InterestingFeatures
{
	public class Coroutine
	{
		public static void Run()
		{
			var cor = new Coroutine();
			Console.WriteLine("The value of Counter is {0}", cor.Counter);

			int nextValue = cor.NextCounter.First();
			Console.WriteLine(@"Get the ""Next"" one and we have: {0}", nextValue);

			Console.WriteLine("Now it gets weird and we're going to add 3, 5, and 10 using our NextAddableThing");

			foreach (int number in cor.NextAddableThing())
			{
				Console.WriteLine("\t Result - {0}", number);
			}
			
			Console.ReadLine();
		}

		public int Counter { get; set; }

		public Coroutine()
		{
			this.Counter = 0;
		}

		public IEnumerable<int> NextCounter
		{
			get
			{
				while (this.Counter < Int32.MaxValue)
				{
					yield return ++this.Counter;
				}
				yield break;
			}
		}

		private int AddThreeToCounter()
		{
			this.Counter += 3;
			return this.Counter;
		}

		private int AddFiveToCounter()
		{
			this.Counter += 5;
			return this.Counter;
		}

		private int AddTenToCounter()
		{
			this.Counter += 10;
			return this.Counter;
		}

		public IEnumerable<int> NextAddableThing()
		{
			yield return this.AddThreeToCounter();

			yield return this.AddFiveToCounter();

			yield return this.AddTenToCounter();

			yield break;
		}
	}
}
