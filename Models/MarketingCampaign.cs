public class MarketingCampaign
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
    public DateTime StartDate { get; set; }
    public decimal Budget { get; set; } 
    public int ClientsCount { get; set; } 
}