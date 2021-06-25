namespace CarShop.ViewModels.Cars
{
    public class AllCarsListingModel
    {
        public string CarId { get; set; }

        public string Title { get; set; }

        public string PlateNumber { get; set; }

        public string Image { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssues { get; set; }
    }
}
