namespace JSE_Daily_MTM.Infrastructure.Helpers.Tests
{
    public class FileDownloaderHelperTests
    {
        [Fact]
        public async Task DownloadAndSaveFilesAsync_FileDoesNotExist_FileDownloadedAndSaved()
        {
            // Arrange
            var fileUrls = new List<string> { "http://example.com/file1.txt", "http://example.com/file2.txt" };
            var localFolder = "/Users/solifassalimu/Projects/JSE_Daily_MTM/JSE_Daily_MTM.Console/bin/";

            // Act
            await FileDownloader.DownloadAndSaveFilesAsync(fileUrls, localFolder);

            // Assert
            foreach (var fileUrl in fileUrls)
            {
                string fileName = Path.GetFileName(fileUrl);
                string localFilePath = Path.Combine(localFolder, fileName);
                Assert.True(File.Exists(localFilePath), $"File not found: {localFilePath}");
            }
        }

        [Fact]
        public async Task DownloadAndSaveFilesAsync_FileExists_FileSkipped()
        {
            // Arrange
            var fileUrls = new List<string> { "http://example.com/file1.txt", "http://example.com/file2.txt" };
            var localFolder = "/Users/solifassalimu/Projects/JSE_Daily_MTM/JSE_Daily_MTM.Console/bin/";

            // Create dummy files
            foreach (var fileUrl in fileUrls)
            {
                string fileName = Path.GetFileName(fileUrl);
                string localFilePath = Path.Combine(localFolder, fileName);
                File.Create(localFilePath).Close();
            }

            // Act
            await FileDownloader.DownloadAndSaveFilesAsync(fileUrls, localFolder);

            // Assert
            foreach (var fileUrl in fileUrls)
            {
                string fileName = Path.GetFileName(fileUrl);
                string localFilePath = Path.Combine(localFolder, fileName);
                Assert.True(File.Exists(localFilePath), $"File should have been skipped: {localFilePath}");
            }
        }
    }
}