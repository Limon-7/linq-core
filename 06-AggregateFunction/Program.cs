using System;
using System.Linq;

namespace AggregateFunction
{
	class Program
	{
		static void Main(string[] args)
		{
			//Basic aggregate function
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"*********************");
			Console.ResetColor();
			int[] intNumbers = new int[] { 10, 30, 50, 40, 60, 20, 70, 90, 80, 100 };
			//Using Method Syntax with a Predicate
			int MSTotal =(from num in intNumbers select num).Sum(num => {
				if (num > 50) return num;
				else return 0;
			});

			Console.WriteLine("Sum = " + MSTotal);
		}
	}
}
