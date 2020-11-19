namespace Vehicles.Models.Contracts
{
    public interface IVehicle : IDriveable, IRefuelable
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public double TankCapacity { get; }

        public bool IsEmpty { get; }
    }
}
