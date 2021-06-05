namespace RawData
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, string[] tiresData)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoWeight, cargoType);
            Tires = new Tire[4]
            {
                new Tire(double.Parse(tiresData[0]), int.Parse(tiresData[1])),
                new Tire(double.Parse(tiresData[2]), int.Parse(tiresData[3])),
                new Tire(double.Parse(tiresData[4]), int.Parse(tiresData[5])),
                new Tire(double.Parse(tiresData[6]), int.Parse(tiresData[7])),
            };
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public override string ToString()
        {
            return $"{Model}";
        }
    }
}
