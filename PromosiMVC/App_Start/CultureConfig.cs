using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PromosiMVC.App_Start
{
    public class CultureConfig
    {
        public static void SetupCulture()
        {
            var polish = CultureInfo.GetCultureInfo("pl-PL");
            polish = (CultureInfo)polish.Clone();
            polish.DateTimeFormat.MonthNames =
                polish.DateTimeFormat.MonthNames
                    .Select(m => polish.TextInfo.ToTitleCase(m))
                    .ToArray();

            polish.DateTimeFormat.MonthGenitiveNames =
                polish.DateTimeFormat.MonthGenitiveNames
                    .Select(m => polish.TextInfo.ToTitleCase(m))
                    .ToArray();
            polish.DateTimeFormat.DayNames =
                polish.DateTimeFormat.DayNames.Select(d => polish.TextInfo.ToTitleCase(d))
                .ToArray();
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = polish;
        }
    }
}