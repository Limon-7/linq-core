using System;
using System.Collections.Generic;

namespace GroupByOperators
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] namesArray = { "Priyanka", "HINA", "hina", "Anurag", "Anurag", "ABC", "abc" };
			var namelist = new List<string>(namesArray);
			var has = new HashSet<string>();
			foreach (var item in namelist)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("Hasset example");
			//var has = new HashSet<string>();
			foreach (var item in has)
			{
				Console.WriteLine(item);
			}
		}
	}
}
