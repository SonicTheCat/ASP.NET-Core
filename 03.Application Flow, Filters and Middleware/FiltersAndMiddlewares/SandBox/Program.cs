using System;

namespace SandBox
{
    public class Program
    {
        public static void Main()
        {
            var res = Calc(person => person.Name + " " + person.Age);
            Console.WriteLine(res);
         }

        public static string Calc(Func<Person, string> myFunc)
        {
            var res =  myFunc.Invoke(new Person() { Name = "pael", Age = 20});
            return res; 
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}