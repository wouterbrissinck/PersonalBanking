using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentation
{
    public class TimeSpans
    {
        public struct Period
        {
            public string Name { get; set; }
            public TimeSpan Span { get; set; }
            public int Months { get; set; }
        }
        static public List<Period> Periods()
        {
            List<Period> Periods = new List<Period>();
            Periods.Add(new Period{Name="Last three years" , Span=TimeSpan.FromDays(3 * 365),Months=36});
            Periods.Add(new Period { Name = "Last two years", Span = TimeSpan.FromDays(2 * 365), Months = 24 });
            Periods.Add(new Period { Name = "Last year", Span = TimeSpan.FromDays(1 * 365), Months = 12 });
            Periods.Add(new Period { Name = "Last 6 months", Span = TimeSpan.FromDays(365 / 2), Months = 6 });
            Periods.Add(new Period { Name = "Last 3 months", Span = TimeSpan.FromDays(365 / 4), Months = 3 });
            Periods.Add(new Period { Name = "Last 2 months", Span = TimeSpan.FromDays(365 / 6), Months = 2 });
            Periods.Add(new Period { Name = "Last month", Span = TimeSpan.FromDays(365 / 12), Months = 1 });

            return Periods;

        }

        public struct Month
        {
            public string Name { get; set; }
            public DateTime Date{ get; set; }        
        }

        static public List<Month> RecentMonths()
        {
            DateTime dd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            List<Month> toret = new List<Month>();

            int year = dd.Year;
            int month = dd.Month;

            for (int i = 0; i < 12; ++i)
            {
                string m = dd.ToString("MMMM");
                toret.Add(new Month {Name=m,Date=dd });

                month--;
                if (month == 0)
                {
                    month = 12;
                    year--;
                }
                dd = new DateTime(year, month, 1);
            }

            return toret;

        }
    }
}
