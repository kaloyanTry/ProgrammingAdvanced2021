using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RawData
{
    public class Tire
    {
        public Tire(double presssure, int age)
        {
            Pressure = presssure;
            Age = age;
        }

        public double Pressure { get; set; }
        public int Age { get; set; }
    }
}
