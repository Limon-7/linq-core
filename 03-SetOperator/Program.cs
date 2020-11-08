using System;
using System.Collections.Generic;
using System.Linq;

namespace SetOperator
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student {ID = 101, Name = "Preety" },
                new Student {ID = 102, Name = "Sambit" },
                new Student {ID = 103, Name = "Hina"},
                new Student {ID = 104, Name = "Anurag"},
                new Student {ID = 102, Name = "Sambit"},
                new Student {ID = 103, Name = "Hina"},
                new Student {ID = 101, Name = "Preety" },
            };
            return students;
        }
    }

    class Program
	{
		static void Main(string[] args)
		{
           //basic Distinct() //
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"********Distinct set operators*************");
            Console.ResetColor();
            List<int> intCollection = new List<int>()
            {
                1,2,3,2,3,4,4,5,6,3,4,5
            };
            string[] namesArray = { "Priyanka", "HINA", "hina", "Anurag", "Anurag", "ABC", "abc" };
            //Using Method Syntax
            var MS = intCollection.Distinct();
            //Using Query Syntax
            var QS = (from num in intCollection select num).Distinct();
            foreach (var item in MS)
            {
                Console.WriteLine(item);
            }
            var distinctNames = namesArray.Distinct(StringComparer.OrdinalIgnoreCase);
            var distinctQuery= (from num in namesArray select num).Distinct(StringComparer.OrdinalIgnoreCase);
            foreach (var name in distinctQuery)
            {
                Console.WriteLine(name);
            }

            //complex example
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*******Distinct operator************");
            Console.ResetColor();
            //Using Method Syntax
            var complexMethod = Student.GetStudents().Select(p=> p.Name).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            foreach (var item in complexMethod)
            {
               // Console.WriteLine($"ID : Name : {item} ");
            }

            //Except() Operator Basic 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*******Except() Method Basic************");
            Console.ResetColor();
            List<int> dataSource1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> dataSource2 = new List<int>() { 1, 3, 5, 8, 9, 10 };
            string[] stringdataSource1 = { "India", "USA", "UK", "Canada", "Srilanka" };
            string[] stringdataSource2 = { "India", "uk", "Canada", "France", "Japan" };
            //Method Syntax
            var exceptMethod = stringdataSource1.Except(stringdataSource2).ToList();
            //Query Syntax
            var exceptQuery = (from num in stringdataSource1
                               select num)
                      .Except(stringdataSource2).ToList();
            foreach (var item in exceptQuery)
            {
                Console.WriteLine(item);
            }

            //Intersect() Operator Basic 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*******Intersect() Operator Basic************");
            Console.ResetColor();
            //Method Syntax
            var intersecttMethod = stringdataSource1.Intersect(stringdataSource2).ToList();
            //Query Syntax
            var intersectQuery = (from num in stringdataSource1
                               select num)
                      .Intersect(stringdataSource2, StringComparer.OrdinalIgnoreCase).ToList();
            foreach (var item in intersecttMethod)
            {
                Console.WriteLine(item);
            }

            //Union() Operator Basic 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*******Union() Operator Basic************");
            Console.ResetColor();
            //Method Syntax
            var unionMethod = stringdataSource1.Union(stringdataSource2, StringComparer.OrdinalIgnoreCase).ToList();
            //Query Syntax
            var unionQuery = (from num in stringdataSource1
                               select num)
                      .Union(stringdataSource2, StringComparer.OrdinalIgnoreCase).ToList();
            foreach (var item in unionQuery)
            {
                Console.WriteLine(item);
            }

            //Concat() Operator Basic 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"*******Union() Operator Basic************");
            Console.ResetColor();
            //Method Syntax
            var concatMethod = stringdataSource1.Concat(stringdataSource2).ToList();
            //Query Syntax
            var concatQuery = (from num in stringdataSource1
                              select num)
                      .Concat(stringdataSource2).ToList();
            foreach (var item in concatQuery)
            {
                Console.WriteLine(item);
            }
        }
    }
}
