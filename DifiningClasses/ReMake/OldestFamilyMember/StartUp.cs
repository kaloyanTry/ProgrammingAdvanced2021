using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember().ToString());
        }
    }
}
