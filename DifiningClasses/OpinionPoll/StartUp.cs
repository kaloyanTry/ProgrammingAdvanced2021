using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Dictionary<string, Person> persons = new Dictionary<string, Person>();

            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person person = new Person(name, age);

                //persons.Add(name, person);

                people.Add(person);
            }

            foreach (var person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine(person);
            }

            //foreach (var person in persons.Where(p => p.Value.Age > 30).OrderBy(p => p.Key))
            //{
            //    Console.WriteLine(person.Value.ToString());
            //}
        }
    }
}
