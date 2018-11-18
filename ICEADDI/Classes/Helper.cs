using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ICEADDI
{
    public class Helper
    {

        public string GenerateNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 5; i++)
            {
                r += random.Next(0, 13).ToString();
            }
            return r;
        }

        public bool ValidateDate(string stringDateValue)
        {
            try
            {
                CultureInfo CultureInfoDateCulture = new CultureInfo("ja-JP");
                DateTime d = DateTime.ParseExact(stringDateValue, "yyyy/MM/dd", CultureInfoDateCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}