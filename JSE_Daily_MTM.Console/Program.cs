// See https://aka.ms/new-console-template for more information
using MediatR;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JSE_Daily_MTM.Domain.Interfaces;
using JSE_Daily_MTM.Infrastructure.Data;
using JSE_Daily_MTM.Application.Commands;
using JSE_Daily_MTM.Infrastructure.Helpers;
using JSE_Daily_MTM.Infrastructure.Services;
using JSE_Daily_MTM.Application.Commands.SaveToDB;
using JSE_Daily_MTM.Application.Commands.DownloadExcelDocs;

#region Configuration
var configuration = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var appsettings = new AppSettings
{
    StartDate = DateTime.ParseExact(configuration["StartDate"], "yyyy/MM/dd", CultureInfo.InvariantCulture),
    EndDate = DateTime.ParseExact(configuration["EndDate"], "yyyy/MM/dd", CultureInfo.InvariantCulture),
    FilesPath = configuration["FilesPath"]
};

var serviceProvider = new ServiceCollection()
    .AddSingleton<IAppSettings>(appsettings)
    .AddDbContext<IAppDbContext, AppDbContext>()
    .AddScoped<IExtractDataService, ExtractDataService>()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(DownloadExcelDocsHandler).Assembly))
    .BuildServiceProvider();

#endregion

var startDate = appsettings.StartDate ?? DateTime.Now.AddDays(-1);
var endDate = appsettings.EndDate ?? DateTime.Now;

var mediator = serviceProvider.GetService<IMediator>();
await mediator.Send(new DownloadExcelDocsCommand { StartDate = startDate, EndDate = endDate });

await mediator.Send(new SaveToDBCommand());