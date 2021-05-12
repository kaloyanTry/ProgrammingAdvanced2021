using System;

namespace _05.FilterByAge
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] persons = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                persons[i] = new Person();
                persons[i].Name = data[0];
                persons[i].Age = int.Parse(data[1]);
            }

            string inputFilter = Console.ReadLine();
            int inputAge = int.Parse(Console.ReadLine());

            Func<Person, bool> ageCondition = GetAgeCondition(inputFilter, inputAge);

            Action<Person> inputFormatter = GetFormatter(Console.ReadLine());

            PrintPersons(persons, ageCondition, inputFormatter);
        }

        private static void PrintPersons(Person[] persons, Func<Person, bool> ageCondition, Action<Person> inputFormatter)
        {
            foreach (var person in persons)
            {
                if (ageCondition(person))
                {
                    inputFormatter(person);
                }
            }
        }

        private static Action<Person> GetFormatter(string format)
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

        private static Func<Person, bool> GetAgeCondition(string inputFilter, int inputAge)
        {
            if (inputFilter == "younger")
            {
                return p => p.Age < inputAge;
            }
            else if (inputFilter == "older")
            {
                return p => p.Age >= inputAge;
            }
            else
            {
                return null;
            }
        }
    }
}
