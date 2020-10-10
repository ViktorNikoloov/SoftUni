using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public int GetDaysDifference(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            int result = (int)Math.Abs((start - end).TotalDays);

            return result;
        }
    }
}
