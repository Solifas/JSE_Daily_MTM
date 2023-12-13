using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSE_Daily_MTM.Infrastructure.Helpers;

public class DateHelper
{
    public static List<string> GetDateRange(DateTime startDate, DateTime endDate)
    {
        var dates = new List<string>();
        var dateRange = Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
            .Select(offset => startDate.AddDays(offset))
            .ToList();
        foreach (var date in dateRange)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) continue;
            dates.Add(date.ToString("yyyyMMdd"));
        }

        return dates;
    }
}
