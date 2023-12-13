namespace JSE_Daily_MTM.Infrastructure.Helpers;

public class FileDownloader
{
    private static readonly HttpClient httpClient = new();
    public static async Task DownloadAndSaveFilesAsync(List<string> fileUrls, string localFolder)
    {
        foreach (var fileUrl in fileUrls)
        {
            try
            {
                string fileName = Path.GetFileName(fileUrl);
                string localFilePath = Path.Combine(localFolder, fileName);
                string processedFileName = Path.Combine(localFolder, $"Processed_{fileName}");

                if (File.Exists(processedFileName))
                {
                    Console.WriteLine($"File has already been processed: Path - {processedFileName}");
                    continue;
                }

                using (HttpResponseMessage response = await httpClient.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    if (response.Content.Headers.ContentLength == 0) continue;
                    using Stream contentStream = await response.Content.ReadAsStreamAsync();
                    using FileStream fileStream = File.Create(localFilePath);
                    await contentStream.CopyToAsync(fileStream);
                }

                Console.WriteLine($"File downloaded and saved: {localFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file from {fileUrl}: {ex.Message}");
            }
        }
    }
}