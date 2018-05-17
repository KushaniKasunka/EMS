using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FEMS.Common
{
    public class DateValidate
    {
        private int year;
        private int month;
        private int day;

        public Boolean IsDateLessThanToday(string date)
        {
            year = Int32.Parse(date.Trim().Substring(0, 4));
            month = Int32.Parse(date.Trim().Substring(5, 2));
            day = Int32.Parse(date.Trim().Substring(8, 2));

            if (year < DateTime.Now.Year || month < DateTime.Now.Month || day < DateTime.Now.Date.Day)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}