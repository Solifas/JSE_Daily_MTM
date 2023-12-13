using System.ComponentModel.DataAnnotations.Schema;

namespace JSE_Daily_MTM.Domain.Entities;

public class DailyMTM
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime FileDate { get; set; }
    public string? Contract { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string? Classification { get; set; }
    public decimal Strike { get; set; }
    public string? CallPut { get; set; }
    public decimal MTMYield { get; set; }
    public decimal MarkPrice { get; set; }
    public decimal SpotRate { get; set; }
    public decimal PreviousMTM { get; set; }
    public decimal PreviousPrice { get; set; }
    public decimal? PremiumOnOption { get; set; }
    public decimal? Volatility { get; set; }
    public decimal? Delta { get; set; }
    public decimal? DeltaValue { get; set; }
    public int ContractsTraded { get; set; }
    public int OpenInterest { get; set; }
}

