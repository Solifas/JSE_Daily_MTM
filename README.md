# JSE_Daily_MTM

## Description
Developed an application capable of being executed to fetch Excel (.xls) files from the JSE website and store the content of the files into a SQL database.

This project includes a file downloader that downloads files from specific URLs and saves them to a specified path. The URLs are generated based on a date range provided in the `DownloadExcelDocsCommand` request.

### Dependencies
* Did not employ Microsoft Interop for Excel on MacOS; instead, I utilized a different approach, using EPPs Package. 

* Describe any prerequisites, libraries, OS version, etc., needed before installing program.


### Executing program

* Pull the repo
* Add Connection string to the AppDbContext.cs file
* Update the AppSettings.json file
  * FromDate - start date to download the JSE file
  * EndDate - end date to download the JSE file
  * FilesPath - the path for where the downloaded files should be

## Assignment 2 is in a file called SP_Total_Contracts_Traded_Report
