using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public Person(string name, int age)
        {
            name = "Pesho";
            age = 20;
        }

        public string Name { get; set; }
        public int Age { get; set; }

    }
}
