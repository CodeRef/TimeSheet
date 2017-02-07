namespace TimeTracker.Service.ViewModels
{
    public class ShopDashboard
    {
        public int ShopId { get; set; }
        public int NewFeedbacks { get; set; }
        public double TotalProfits { get; set; }
        public int Orders { get; set; }
        public int BrandPopularity { get; set; }
        public string[] Widgets { get; set; }
    }
}