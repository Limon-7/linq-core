
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projection
{

//Student Class    
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Programming { get; set; }
        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student(){ID = 1, Name = "James", Email = "James@j.com", Programming = new List<string>() { "C#", "Jave", "C++"} },
                new Student(){ID = 2, Name = "Sam", Email = "Sara@j.com", Programming = new List<string>() { "WCF", "SQL Server", "C#" }},
                new Student(){ID = 3, Name = "Patrik", Email = "Patrik@j.com", Programming = new List<string>() { "MVC", "Jave", "LINQ"} },
                new Student(){ID = 4, Name = "Sara", Email = "Sara@j.com", Programming = new List<string>() { "ADO.NET", "C#", "LINQ" } }
            };
        }
    }

//Employee Class//
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000 },
                new Employee {ID = 102, FirstName = "Priyanka", LastName = "Dewangan", Salary = 70000 },
                new Employee {ID = 103, FirstName = "Hina", LastName = "Sharma", Salary = 80000 },
                new Employee {ID = 104, FirstName = "Anurag", LastName = "Mohanty", Salary = 90000 },
                new Employee {ID = 105, FirstName = "Sambit", LastName = "Satapathy", Salary = 100000 },
                new Employee {ID = 106, FirstName = "Sushanta", LastName = "Jena", Salary = 160000 }
            };
            return employees;
        }
    }
    class Program
	{
		static void Main(string[] args)
		{
//Query syntax
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"*****************Query------syntax************************");
            Console.ResetColor();
            var querySyntax =
                (from emp in Employee.GetEmployees()
                 select new {Id=emp.ID,FullName= emp.FirstName+""+ "emp.LastName",AnnualSalary=emp.Salary*12 });
            var querySyntaxWithIndex =
                from emp in Employee.GetEmployees().Select((value, index) => new { v=value, i=index })
                select new { IndexPosition=emp.i, FullName = emp.v.FirstName + "" + emp.v.LastName, AnnualSalary = emp.v.Salary * 12 };
            foreach (var emp in querySyntaxWithIndex)
            {
                Console.WriteLine($"Employee Index : {emp.IndexPosition} Full Name : {emp.FullName} AnnualSalary: {emp.AnnualSalary}");
            }

//Method Syntax            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"******************Method syntax********************");
            Console.ResetColor();
            //select with anonymos
            var selectAll=Employee.GetEmployees().ToList();
            foreach (var item in selectAll)
            {
                Console.WriteLine($"{item.Salary}");
            }
            var methodSyntax = Employee.GetEmployees().Select(p => new
            {
                EmployeeID = p.ID,
               FullName = p.FirstName+""+p.LastName,
                Salary = p.Salary*12

            }).ToList() ;
            // select with index
            var selectIndex = Employee.GetEmployees().Select((value, index) => new {
                IndexPosition = index,
            FullName=value.FirstName+" "+value.LastName,
            AnnualSalary=value.Salary*12
            }).ToList();
            foreach (var emp in selectIndex)
            {
                //Console.WriteLine($"Employee Id: {emp.EmployeeID} Full Name: {emp.FullName} Annual Salary:{emp.Salary}");
                Console.WriteLine($"Employee Index : {emp.IndexPosition} Full Name : {emp.FullName} AnnualSalary: {emp.AnnualSalary}");
            }  

//Mixed syntax            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"******************Mixed syntax********************");
            Console.ResetColor();
            var mixedSyntax = (from emp in Employee.GetEmployees()
                                select new { Id = emp.ID, FullName = emp.FirstName + "" + "emp.LastName", AnnualSalary = emp.Salary * 12 }).ToList();

            foreach (var emp in mixedSyntax)
            {
                Console.WriteLine($"Employee ID : {emp.Id} Full Name : {emp.FullName} AnnualSalary: {emp.AnnualSalary}");
            }

//Selected Many with Query Syntax            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"****************** Selected Query syntax********************");
            Console.ResetColor();
            var selectedMany = (from s in Student.GetStudents() from p in s.Programming select new { StudentName = s.Name, Program = p });
            foreach (var stu in selectedMany)
            {
                Console.WriteLine(stu.StudentName + " => " + stu.Program);
            }

 //Selected Many with Query Syntax
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"****************** Selected Method syntax********************");
            Console.ResetColor();
            var selectedManyMethod = Student.GetStudents().SelectMany(p => p.Programming, (s, p) => new {StudentName=s.Name,Program=p }).ToList();
            foreach (var stu in selectedMany)
            {
                Console.WriteLine(stu.StudentName + " => " + stu.Program);
            }
        }
    }
}
