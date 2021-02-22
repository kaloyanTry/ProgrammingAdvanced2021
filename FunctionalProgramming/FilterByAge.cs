using System;

namespace FilterByAge
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class FilterByAge
    {
        static void Main(string[] args)
        {
          int n = int.Parse(Console.ReadLine());

            Person[] person = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                person[i] = new Person();
                person[i].Name = input[0];
                person[i].Age = int.Parse(input[1]);
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());

            Func<Person, bool> condition = GetAgeCondition(filter, filterAge);
            Action<Person> formatter = GetFormatter(Console.ReadLine());

            PrintPerson(person, condition, formatter);
        }

        static Action<Person> GetFormatter(string format)
        {
            switch (format)
            {
                case "name":
                    return p => { Console.WriteLine($"{p.Name}"); };
                case "age":
                    return p => { Console.WriteLine($"{p.Age}"); };
                case "name age":
                    return p => { Console.WriteLine($"{p.Name} - {p.Age}"); };

                default:
                    return null;
            }
        }

        static Func<Person, bool> GetAgeCondition(string filter, int filterAge)
        {
            switch (filter)
            {
                case "younger": return p => p.Age < filterAge;
                case "older": return p => p.Age >= filterAge;
                default:
                    return null;
            }
        }

        static void PrintPerson(Person[] persons, Func<Person, bool> condition, Action<Person> formatter)
        {
            foreach (var person in persons)
            {
                if (condition(person))
                {
                    formatter(person);
                }
            }
        }
    }
}
