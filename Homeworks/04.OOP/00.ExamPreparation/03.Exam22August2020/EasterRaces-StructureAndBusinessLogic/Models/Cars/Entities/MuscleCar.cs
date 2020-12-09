namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double DefaultCubicCentimeters = 5000;
        private const int DefaultMinHorsePower = 400;
        private const int DefaultMaxHorsePower = 600;

        public MuscleCar(string model, int horsePower)
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
