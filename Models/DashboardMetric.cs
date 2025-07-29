namespace DashboardApi.Models
{
    public class DashboardMetric
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TodaysMoney { get; set; }
        public int TodaysUsers { get; set; }
        public int NewClients { get; set; }
        public decimal Sales { get; set; }
    }
}
