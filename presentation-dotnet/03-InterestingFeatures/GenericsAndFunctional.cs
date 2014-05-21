using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InterestingFeatures
{
	public class GenericsAndFunctional
	{
		public static void Run()
		{
			var gfo = new GenericsAndFunctional();
			gfo.ClosureExample();
			gfo.FunctionalExample();
			gfo.DictionaryExample();
			Console.ReadLine();
		}

		public void ClosureExample()
		{
			// To demonstrate a closure.... we're going to need a scope value
			int x = 0;

			// Lets make a function variable that's recursive!
			// It returns void, so it's an Action vs a Func 
			Action incrementX = null; // assigned null so it's initialized before the recursion
			incrementX = delegate()
			 {
				 // Let's take the variable in the parent scope, increment it
				 // , then test if it's greater than 9.
				 if (++x < 10)
				 {
					 incrementX();
				 }
			 };

			// Call the recursive function
			incrementX();

			Console.WriteLine("The value of x is {0}", x);
		}

		public void FunctionalExample()
		{
			// Make a list and fill it with 10 items
			List<int> list = new List<int>();
			for (int i = 0; i < 10; i++)
			{
				list.Add(i);
			}
			Console.WriteLine("The list : {0}", string.Join(",", list.ToArray()));

			// Create a function to add 15 to a value via the composition of the existing Add function
			Func<int, int> addFifteen = delegate(int value)
			{
				return this.Add(value, 15);
			};

			// Now lets map this function against the list.
			// Note: List elements are mutable but these methods resturn new list instances
			var mappedList = list.Select(x => addFifteen(x)).ToList();

			Console.WriteLine("The list after the map: {0}", string.Join(",", mappedList.ToArray()));

			// This x=> syntax is equivelent to this. These are just different ways of passing function references.
			mappedList = list.Select(addFifteen).ToList();


			// Now lets reduce and get a sum of each element multiplied by 2
			var sum = mappedList.Aggregate((x, y) => x + (y * 2));
			Console.WriteLine("The sum of each element multiplied by 2 is {0}", sum);
		}

		public void DictionaryExample()
		{
			// Mime Types
			Dictionary<string, string> lookupTable = new Dictionary<string, string>();
			lookupTable.Add("html", "text/html");
			lookupTable.Add("htm", "text/html");
			lookupTable.Add("png", "image/png");
			lookupTable.Add("pdf", "application/pdf");

			// Are there any type with more than one extension associated?
			var t = lookupTable.GroupBy(x => x.Key).Select(x => new { MimeType = x.Key, Count = x.Count() }).Where(x => x.Count > 1);

			// for each of the types with more than one extension...
			foreach (var item in t)
			{
				// get the extensions:
				var extensionArray = lookupTable.Where(x => x.Value == item.MimeType).Select(x => x.Key).ToArray<string>();
				var extensions = string.Join(",", extensionArray);
				Console.WriteLine("{0} has the following extensions: {1}", item, extensions);
			}
		}

		private int Add(int x, int y)
		{
			return x + y;
		}

	}
}
