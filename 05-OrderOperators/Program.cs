using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderOperators
{
	/// <summary>
	/// Student Class
	/// </summary>
	public class Student
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Branch { get; set; }
		public static List<Student> GetAllStudents()
		{
			List<Student> listStudents = new List<Student>()
			{
				new Student{ID= 101,FirstName = "Preety",LastName = "Tiwary",Branch = "CSE"},
				new Student{ID= 102,FirstName = "Preety",LastName = "Agrawal",Branch = "ETC"},
				new Student{ID= 103,FirstName = "Priyanka",LastName = "Dewangan",Branch = "ETC"},
				new Student{ID= 104,FirstName = "Hina",LastName = "Sharma",Branch = "ETC"},
				new Student{ID= 105,FirstName = "Anugrag",LastName = "Mohanty",Branch = "CSE"},
				new Student{ID= 106,FirstName = "Anurag",LastName = "Sharma",Branch = "CSE"},
				new Student{ID= 107,FirstName = "Pranaya",LastName = "Kumar",Branch = "CSE"},
				new Student{ID= 108,FirstName = "Manoj",LastName = "Kumar",Branch = "ETC"},
				new Student{ID= 109,FirstName = "Pranaya",LastName = "Rout",Branch = "ETC"},
				new Student{ID= 110,FirstName = "Saurav",LastName = "Rout",Branch = "CSE"}
			};
			return listStudents;
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
//basic order by			// basic order by
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"*********basic order by************");
			Console.ResetColor();
			List<int> intList = new List<int>() { 10, 45, 35, 29, 100, 69, 58, 50 };
			List<string> stringList = new List<string>() { "Preety", "Tiwary", "Agrawal", "Priyanka", "Dewangan",
			"Hina","Kumar","Manoj", "Rout", "James"};
			Console.WriteLine("Before Sorting : ");
			foreach (var item in intList)
			{
				Console.Write(item + " ");
			}
			//Using Method Syntax
			var MS = intList.OrderBy(num => num);
			//Using Query Syntax
			var QS = (from num in intList
					  orderby num
					  select num).ToList();
			Console.WriteLine("After Sorting : ");
			foreach (var item in QS)
			{
				Console.Write(item + " ");
			}


			//string  with orderby
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"*********basic order by using string type************");
			Console.ResetColor();
			Console.WriteLine("Before Sorting : ");
			foreach (var item in stringList)
			{
				Console.Write(item + " ");
			}
			//Using Method Syntax
			var stringOrderbyMethod = stringList.OrderBy(num => num);
			//Using Query Syntax
			var stringOrderbyQuery = (from num in stringList
					  orderby num
					  select num).ToList();
			Console.WriteLine("After Sorting : ");
			foreach (var item in stringOrderbyQuery)
			{
				Console.Write(item + " ");
			}

			
			//ComplexType  with orderby
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"*********basic order by ComplexType************");
			Console.ResetColor();
			//Method Syntax
			var complexOrderbyMethod = Student.GetAllStudents().Where(std => std.Branch.ToUpper() == "CSE").OrderBy(x => x.FirstName).ToList();
			//Query Syntax
			var complexOrderbyQuery = (from std in Student.GetAllStudents() where std.Branch.ToUpper() == "CSE" orderby std.Branch ascending,std.FirstName descending select std);
			foreach (var student in complexOrderbyQuery)
			{
				Console.WriteLine(" Branch: " + student.Branch + ", Name :" + student.FirstName + " " + student.LastName);
			}

			//Reverse()
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"*********Reverse************");
			Console.ResetColor();
			int[] intArray = new int[] { 10, 30, 50, 40, 60, 20, 70, 100 };
			Console.WriteLine("Before Reverse the Data");
			foreach (var number in intArray)
			{
				Console.Write(number + " ");
			}
			Console.WriteLine();
			var ArrayReversedData = intArray.AsQueryable().Reverse();
			var queryReverse = (from d in intArray select d).AsQueryable().Reverse();
			Console.WriteLine("After Reverse the Data");
			foreach (var number in queryReverse)
			{
				Console.Write(number + " ");
			}

		}
	}
}
