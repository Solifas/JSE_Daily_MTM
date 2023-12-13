using JSE_Daily_MTM.Domain.Interfaces;

namespace JSE_Daily_MTM.Infrastructure.Helpers;

public class AppSettings : IAppSettings
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string FilesPath { get; set; } = string.Empty;
}
