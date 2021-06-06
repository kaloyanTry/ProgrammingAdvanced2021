using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, string weight = "n/a", string color = "n/a")
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine?.Model}:");
            sb.AppendLine($"    Power: {Engine?.Power}");
            sb.AppendLine($"    Displacement: {Engine?.Displacement}");
            sb.AppendLine($"    Efficiency: {Engine?.Efficiency}");
            sb.AppendLine($"  Weight: {Weight}");
            sb.AppendLine($"  Color: {Color}");

            return sb.ToString().Trim();
        }
    }
}
