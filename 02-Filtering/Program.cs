using System;
using System.Collections.Generic;
using System.Linq;

namespace Filtering
{

//Employ class
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public List<string> Technology { get; set; }
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee {ID = 101, Name = "Preety", Gender = "Female", Salary = 60000,
                              Technology = new List<string>() {"C#", "Jave", "C++"} },
                new Employee {ID = 102, Name = "Priyanka", Gender = "Female", Salary = 50000,
                              Technology =new List<string>() { "WCF", "SQL Server", "C#" } },
                new Employee {ID = 103, Name = "Hina", Gender = "Female", Salary = 40000,
                              Technology =new List<string>() { "MVC", "Jave", "LINQ"}},
                new Employee {ID = 104, Name = "Anurag", Gender = "Male", Salary = 450000},
                new Employee {ID = 105, Name = "Sambit", Gender = "Male", Salary = 550000},
                new Employee {ID = 106, Name = "Sushanta", Gender = "Male", Salary = 700000,
                             Technology =new List<string>() { "ADO.NET", "C#", "LINQ" }}
            };
            return employees;
        }
    }

    class Program
	{
		static void Main(string[] args)
		{
//Where filtering basic//
            var numberlist = new List<int>() {1,2,3,4,5,6,7,8,9,12 };
			var querySyntax = from p in numberlist where p > 5 select p;
			var querySyntaxIndex = from p in numberlist.Select((v, index) => new { v, index })
							  where p.v%2!=0
							  select new { Index = p.index, Number = p.v };
			var queryMethodIndex = numberlist.Select((v, i) => new { Index = i, Number = v }).Where(p => p.Number % 2 != 0).ToList();
			IEnumerable<int> queryMethod = numberlist.Where(p => p%2==0).ToList();
			foreach (var num in queryMethodIndex)
			{
				Console.WriteLine($"Index={num.Index} Number={num.Number}");
			}

//where with method and query//
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"********where with method and query*************");
            Console.ResetColor();
            var queryMethodWhere = Employee.GetEmployees().Where(v => v.Salary > 40000).ToList();
            var querySyntaxWhere = from e in Employee.GetEmployees()
                                   where e.Salary > 40000
                                   select e;
            foreach (var emp in queryMethodWhere)
            {
                Console.WriteLine($"Name : {emp.Name}, Salary : {emp.Salary}, Gender : {emp.Gender}");
                if (emp.Technology != null && emp.Technology.Count > 0)
                {
                    Console.Write($"Technology:");
                    foreach (var tech in emp.Technology)
                    {
                        Console.Write(tech);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Technology Not Available");
                    Console.ResetColor();
                }
            }

//where with method and query with index  //
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*********where with method and query with index value************");
            Console.ResetColor();
            var querySyntaxWhereIndex = from emp in Employee.GetEmployees().Select((v, i) => new { v, i })
                                        where emp.v.Salary > 50000 && emp.v.Gender == "Male"
                                        select new
                                        {
                                            EmployeeName = emp.v.Name,
                                            Gender = emp.v.Gender,
                                            Salary = emp.v.Salary,
                                            IndexPosition = emp.i
                                        };

            var queryMethodWhereIndex = Employee.GetEmployees().Select((v, i) => new { v, i })
                .Where(emp => emp.v.Salary > 50000 && emp.v.Gender.ToLower() == "male")
                .Select(emp=> new {
                    EmployeeName = emp.v.Name,
                    Gender = emp.v.Gender,
                    Salary = emp.v.Salary,
                    IndexPosition = emp.i
                }).ToList();
            foreach (var emp in queryMethodWhereIndex)
            {
                Console.WriteLine($"Position : {emp.IndexPosition} Name : {emp.EmployeeName}, Gender : {emp.Gender}, Salary : {emp.Salary}");
            }

        }
	}
}
