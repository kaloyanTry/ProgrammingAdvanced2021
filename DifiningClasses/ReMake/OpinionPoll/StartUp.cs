using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                Person person = new Person(name, age);
                persons.Add(person);

            }

            foreach (var person in persons.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
