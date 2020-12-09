namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double DefaultCubicCentimeters = 3000;
        private const int DefaultMinHorsePower = 250;
        private const int DefaultMaxHorsePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, DefaultCubicCentimeters, DefaultMinHorsePower, DefaultMaxHorsePower)
        {

        }

        //public override int HorsePower
        //{
        //    get => horsePower;
        //    protected set
        //    {
        //        if (minHorsePower < DefaultMinHorsePower || maxHorsePower > DefaultMaxHorsePower)
        //        {
        //            throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
        //        }

        //        horsePower = value;
        //    }
        //}
    }
}
