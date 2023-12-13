using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using JSE_Daily_MTM.Domain;
using JSE_Daily_MTM.Domain.Entities;
using JSE_Daily_MTM.Domain.Interfaces;

namespace JSE_Daily_MTM.Infrastructure.Services;

public class ExtractDataService : IExtractDataService
{
    public Task<List<DailyMTM>?> ExtractDataFromExcel(string filePath)
    {
        try
        {
            List<DailyMTM>? dailyMTMs = new();
            using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook workbook = new(fileStream);
            ISheet sheet = workbook.GetSheetAt(0);

            for (int rowIndex = 5; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row != null)
                {
                    DailyMTM dailyMTM = CreateDailyMTMObject(row);

                    if (dailyMTM.Contract == null || dailyMTM.Contract == "")
                    {
                        return Task.FromResult(dailyMTMs);
                    }
                    dailyMTMs.Add(dailyMTM);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        throw new Exception("There was an error extracting data from the excel file");
    }

    private static DailyMTM CreateDailyMTMObject(IRow row)
    {
        int lastCellIndex = row.LastCellNum;
        string[] rowValues = new string[lastCellIndex];

        foreach (ICell cell in row)
        {
            rowValues[cell.ColumnIndex] = GetCellValue(cell);
        }

        var dailyMTM = new DailyMTM
        {
            FileDate = DateTime.UtcNow,
            Contract = rowValues[ColumnNames.Contract],
            ExpiryDate = double.TryParse(rowValues[ColumnNames.ExpiryDate], out double expiryDate) ? DateTime.FromOADate(expiryDate).Date : DateTime.MinValue,
            Classification = rowValues[ColumnNames.Classification],
            Strike = decimal.TryParse(rowValues[ColumnNames.Strike], out decimal strikeDecimal) ? strikeDecimal : 0M,
            CallPut = rowValues[ColumnNames.CallPut],
            MTMYield = decimal.TryParse(rowValues[ColumnNames.MTMYield], out decimal mTMYield) ? mTMYield : 0M,
            MarkPrice = decimal.TryParse(rowValues[ColumnNames.MarkPrice], out decimal markPrice) ? markPrice : 0M,
            SpotRate = decimal.TryParse(rowValues[ColumnNames.SpotRate], out decimal spotRate) ? spotRate : 0M,
            PreviousMTM = decimal.TryParse(rowValues[ColumnNames.PreviousMTM], out decimal previousMTM) ? previousMTM : 0M,
            PreviousPrice = decimal.TryParse(rowValues[ColumnNames.PreviousPrice], out decimal previousPrice) ? previousPrice : 0M,
            PremiumOnOption = decimal.TryParse(rowValues[ColumnNames.PremiumOnOption], out decimal premiumOnOption) ? premiumOnOption : 0M,
            Volatility = decimal.TryParse(rowValues[ColumnNames.Volatility], out decimal volatility) ? volatility : 0M,
            Delta = decimal.TryParse(rowValues[ColumnNames.Delta], out decimal delta) ? delta : 0M,
            DeltaValue = decimal.TryParse(rowValues[ColumnNames.DeltaValue], out decimal deltaValue) ? deltaValue : 0M,
            ContractsTraded = int.TryParse(rowValues[ColumnNames.ContractsTraded], out int contractsTraded) ? contractsTraded : 0,
            OpenInterest = int.TryParse(rowValues[ColumnNames.OpenInterest], out int openInterest) ? openInterest : 0
        };
        return dailyMTM;
    }

    private static string GetCellValue(ICell cell)
    {
        if (cell != null)
        {
            return cell.CellType switch
            {
                CellType.Numeric => cell.NumericCellValue.ToString(),
                CellType.String => cell.StringCellValue,
                _ => string.Empty,
            };
        }

        return string.Empty;
    }
}
