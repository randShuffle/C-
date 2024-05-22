using System.Collections;  
  
namespace  ConsoleApp1  
{  
    class Program  
    {  
        public class Student  
        {  
            public int Id;  
            public String Name;  
            public int Age;  
        }  
  
        public class StudentScore  
        {  
            public int StudentId;  
            public float English;  
            public float Math;  
        }  
        static void Main(string[] args)  
        {  
            Student[] students = new Student[]  
            {  
                new Student { Id = 1, Name = "John", Age = 18 },  
                new Student { Id = 2, Name = "Marry", Age = 19 },  
                new Student { Id = 3, Name = "Tom", Age = 20 },  
                new Student { Id = 4, Name = "Jerry", Age = 21 },  
                new Student { Id = 5, Name = "Jack", Age = 22 }  
            };  
            StudentScore[] score = new StudentScore[]  
            {  
                new StudentScore { StudentId = 1, English = 80, Math = 90 },  
                new StudentScore { StudentId = 2, English = 85, Math = 95 },  
                new StudentScore { StudentId = 3, English = 90, Math = 100 },  
                new StudentScore { StudentId = 4, English = 95, Math = 105 },  
                new StudentScore { StudentId = 5, English = 100, Math = 110 }  
            };  
            var list = students.Join(score,o=>o.Id, i=>i.StudentId,   
(o,i)=> new {Name=o.Name, English = i.English, Math =i.Math});  
  
            foreach (var item in list)  
            {  
                Console.WriteLine(item);  
            }  
            Console.WriteLine("===========================");  
            var list2 = from s in students  
                        from sc in score  
                        where s.Id == sc.StudentId  
                            orderby sc.Math  
                            select new{Name = s.Name,English = sc.English, Math = sc.Math};  
            foreach (var item in list2)  
            {  
                Console.WriteLine(item);  
            }  
            Console.WriteLine("===========================");  
        }  
    }  
}