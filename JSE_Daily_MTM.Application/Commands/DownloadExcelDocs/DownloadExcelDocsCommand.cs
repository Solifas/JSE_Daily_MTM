using MediatR;

namespace JSE_Daily_MTM.Application.Commands.DownloadExcelDocs;

public class DownloadExcelDocsCommand : IRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
