using JSE_Daily_MTM.Domain.Entities;

namespace JSE_Daily_MTM.Domain.Interfaces;

public interface IExtractDataService
{
    public Task<List<DailyMTM>?> ExtractDataFromExcel(string filePath);
}