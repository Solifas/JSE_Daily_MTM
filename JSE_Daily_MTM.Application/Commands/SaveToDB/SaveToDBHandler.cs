using MediatR;
using JSE_Daily_MTM.Domain.Interfaces;
using JSE_Daily_MTM.Infrastructure.Data;

namespace JSE_Daily_MTM.Application.Commands.SaveToDB;

public class SaveToDBHandler : IRequestHandler<SaveToDBCommand>
{

    public readonly IAppDbContext _dbContext;
    public readonly IAppSettings _appSettings;
    public readonly IExtractDataService _extractDataService;
    public SaveToDBHandler(IAppDbContext dbContext, IAppSettings appSettings, IExtractDataService extractDataService)
    {
        _dbContext = dbContext;
        _appSettings = appSettings;
        _extractDataService = extractDataService;
    }

    public async Task Handle(SaveToDBCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var files = Directory.GetFiles(_appSettings.FilesPath, "*.xls");

            foreach (var filePath in files)
            {
                if (filePath.Contains("Processed_")) continue;
                var dailyMTMs = await _extractDataService.ExtractDataFromExcel(filePath);
                if (dailyMTMs == null) continue;
                _dbContext.DailyMTM.AddRange(dailyMTMs);
                _dbContext.SaveChanges();
                UpdateProcessedFileName(filePath);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("There was an error saving files to the database", ex);
        }
    }

    private static void UpdateProcessedFileName(string filePath)
    {
        var fileName = Path.GetFileNameWithoutExtension(filePath);
        if (fileName.Contains("Processed_")) return;
        var newFileName = $"Processed_{fileName}.xls";
        File.Move(filePath, Path.Combine(Path.GetDirectoryName(filePath)!, newFileName));
    }
}
