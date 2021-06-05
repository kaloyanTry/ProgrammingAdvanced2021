namespace RawData
{
    public class Tire
    {
        public Tire(double tirePressure, int tireAge)
        {
            TirePressure = tirePressure;
            TireAge = tireAge;
        }

        public double TirePressure { get; set; }
        public int TireAge { get; set; }
        public int Pressure { get; internal set; }
    }
}
