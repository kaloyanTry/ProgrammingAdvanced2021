using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesmanExercise
{
    public class Engine
    {
        public Engine(string model, string power, string displacement = "n/a", string efficiency = "n/a")
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
