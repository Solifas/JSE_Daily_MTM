namespace JSE_Daily_MTM.Domain.Interfaces;

public interface IAppSettings
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string FilesPath { get; set; }
    public string ConnectionString { get; set; }
}