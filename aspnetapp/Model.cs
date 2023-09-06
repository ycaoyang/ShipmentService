namespace aspnetapp
{
    public class Counter
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class Express
    {
        public int Id { get; set; }
        public string? OrderNumber { get; set; }
        public string? OrderName { get; set; }
        public double Quantity { get; set; }
        public string? ClientName { get; set; }
        public int ClientPhone { get; set; }
        public string? ClientProvince { get; set; }
        public string? ClientCity { get; set; }
        public string? ClientArrondissement { get; set; }
        public string? ClientAddress { get; set; }
        public string? ExpressName { get; set; }
        public string? ExpressNumber { get; set; }
        public string? Commment { get; set;}
        public string? Article { get; set;}
    }
}