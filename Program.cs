using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using System.IO;

using (var context = new ApplicationDbContext())
{
    
    var campaignBudgets = context.MarketingCampaigns
        .Select(c => new
        {
            CampaignName = c.Name,
            AvgBudgetPerClient = c.ClientsCount > 0 ? c.Budget / c.ClientsCount : 0
        })
        .ToList();

    foreach (var campaign in campaignBudgets)
    {
        Console.WriteLine($"Кампанія: {campaign.CampaignName}, Середній бюджет на клієнта: {campaign.AvgBudgetPerClient}");
    }

    
    var campaigns = context.MarketingCampaigns.ToList();
    Console.WriteLine("Початок збереження даних");
    SaveCampaignsToXml(campaigns, "MarketingCampaigns.xml");
    Console.WriteLine("Успішно збережені");
}


static void SaveCampaignsToXml(List<MarketingCampaign> campaigns, string filePath)
{
    XmlSerializer serializer = new XmlSerializer(typeof(List<MarketingCampaign>));
    using (FileStream fs = new FileStream(filePath, FileMode.Create))
    {
        serializer.Serialize(fs, campaigns);
    }
}
