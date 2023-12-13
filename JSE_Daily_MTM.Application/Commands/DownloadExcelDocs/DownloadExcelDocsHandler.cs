using MediatR;
using JSE_Daily_MTM.Infrastructure.Helpers;
using JSE_Daily_MTM.Application.Commands.DownloadExcelDocs;
using JSE_Daily_MTM.Domain.Interfaces;

namespace JSE_Daily_MTM.Application.Commands;

public class DownloadExcelDocsHandler : IRequestHandler<DownloadExcelDocsCommand>
{
    private readonly IAppSettings _appSettings;
    public DownloadExcelDocsHandler(IAppSettings appSettings)
    {
        _appSettings = appSettings;
    }
    public async Task Handle(DownloadExcelDocsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var extrapolatedUrls = GetDMTMReportsUrls(request);
            await FileDownloader.DownloadAndSaveFilesAsync(extrapolatedUrls, _appSettings.FilesPath);
        }
        catch (Exception ex)
        {
            throw new Exception("There was an error downloading files", ex);
        }
    }

    private static List<string> GetDMTMReportsUrls(DownloadExcelDocsCommand request)
    {
        var extrapolatedDates = DateHelper.GetDateRange(request.StartDate, request.EndDate);
        var extrapolatedUrls = new List<string>();
        foreach (var url in extrapolatedDates)
        {
            extrapolatedUrls.Add($"https://clientportal.jse.co.za/_layouts/15/DownloadHandler.ashx?FileName=/YieldX/Derivatives/Docs_DMTM/{url}_D_Daily%20MTM%20Report.xls");
        }

        return extrapolatedUrls;
    }
}

