using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using System.ComponentModel;

namespace Presentation
{
    public class PlanPresenter : INotifyPropertyChanged
    {
        #region inner classes
        public class CategoryInfo
        {
            public string Name { get; set; }
            public string Color { get; set; }
            public float PatternPercent { get; set; }
            public decimal FixedExpense { get; set; }
            public decimal AverageExpense { get; set; }
            public decimal Proposed { get; set; }
            public bool Override { get; set; }
            public decimal ThisMonthExpense { get; set; }
            public decimal Saved { get; set; }
            public decimal CumulatedSaved { get; set; }
        }
        #endregion

        #region Lifetime
        public PlanPresenter()
        {
            RecentMonths = TimeSpans.RecentMonths();
            ActiveMonth = RecentMonths[0];
            Periods = TimeSpans.Periods();
            PeriodConsidered = Periods[3];
            Savings = 0;
        }
        #endregion

        #region Bindable Properties
        public System.Collections.ObjectModel.ObservableCollection<CategoryInfo> Infos { get; private set; }
        SortedList<string, float> SpendingPattern {get;set;}
        SortedList<string, decimal> AverageSpending {get;set;}
        public decimal FixedIncome{get;set;}
        public List<TimeSpans.Month> RecentMonths{get;set;}
        TimeSpans.Month _ActiveMonth;
        public TimeSpans.Month ActiveMonth 
        {
            get { return _ActiveMonth; }
            set { _ActiveMonth = value; Recompute(); }
        }
        public List<TimeSpans.Period> Periods{get;set;}
        public SortedList<string,SortedList<string,decimal>> MonthlySpending{get;set;} // category -> (month -> spending)

        TimeSpans.Period _PeriodConsidered;
        public TimeSpans.Period PeriodConsidered 
        { 
            get{return _PeriodConsidered;}
            set { _PeriodConsidered = value; Recompute(); } 
        }

        decimal _savings;
        public decimal Savings
        {
            get { return _savings; }
            set
            {
                _savings = value;
                Recompute();
            }
        }
        public CategoryInfo totals { get; set; }
        #endregion

        #region private methods
        void Recompute()
        {
            ComputeSpendingPattern();
            ComputeFixedIncome();
            ComputeInfos();
            ComputeTotals();
            NotifyPropertyChanged("Infos");
            NotifyPropertyChanged("totals");
        }


        void ComputeTotals()
        {
            CategoryInfo tot = new CategoryInfo();
            foreach (var info in Infos)
            {
                tot.AverageExpense += info.AverageExpense;
                tot.FixedExpense += info.FixedExpense;
                tot.PatternPercent += info.PatternPercent;
                tot.Proposed += info.Proposed;
                tot.ThisMonthExpense += info.ThisMonthExpense;
                tot.Saved+= info.Saved;
                tot.CumulatedSaved+= info.CumulatedSaved;
            }

            totals = tot;
        
        }


        void ComputeInfos()
        {
            Infos = new System.Collections.ObjectModel.ObservableCollection<CategoryInfo>();
            List<CategoryInfo> to_sort = new List<CategoryInfo>();

            var rule_expense = Database.Current.Rules.Category2FixedExpense;


            foreach (var cat in Database.Current.Categories.CategoriesAll)
            {
                if (SpendingPattern.ContainsKey(cat.Name))
                { 
                    CategoryInfo info=new CategoryInfo();
                    info.Name = cat.Name;
                    info.Color = cat.Color;
                    info.PatternPercent = SpendingPattern[cat.Name];
                    info.FixedExpense = rule_expense.ContainsKey(cat.Name) ? -rule_expense[cat.Name] : 0;
                    //info.AverageExpense = AverageSpending[cat.Name];
                    if (MonthlySpending.ContainsKey(cat.Name) && MonthlySpending[cat.Name].ContainsKey(ActiveMonth.Name))
                        info.ThisMonthExpense = MonthlySpending[cat.Name][ActiveMonth.Name];
                    else
                        info.ThisMonthExpense = 0;
                    to_sort.Add(info);
                }
            }

            ComputeProposedExpenses(to_sort);
            ComputeSaved(to_sort);
            ComputeCummulatedSaved(to_sort);


            to_sort.Sort((x, y) => x.CumulatedSaved < y.CumulatedSaved? -1 : (x.CumulatedSaved== y.CumulatedSaved? 0 : 1));
            foreach (var info in to_sort)
            {
                Infos.Add(info);
            }

        }

        private void ComputeSaved(List<CategoryInfo> i_infos)
        {
            foreach (var info in i_infos)
            {
                info.Saved = info.Proposed - info.ThisMonthExpense;

            }
        }


        private void ComputeCummulatedSaved(List<CategoryInfo> i_infos)
        {
            foreach (var info in i_infos)
            {
                info.CumulatedSaved = 0;
                bool thismonth = (ActiveMonth.Date == RecentMonths[0].Date);
                for (int i=1;i<PeriodConsidered.Months;++i)
                {
                    TimeSpans.Month month= RecentMonths[i];
                    decimal expense;
                    if (MonthlySpending.ContainsKey(info.Name) && MonthlySpending[info.Name].ContainsKey(month.Name))
                    {
                        expense = MonthlySpending[info.Name][month.Name];
                    }
                    else
                    {
                        expense=0;
                    }
                    info.CumulatedSaved += (info.Proposed - expense);                    

                }
            }
        }

        private void ComputeProposedExpenses(List<CategoryInfo> i_infos)
        {
            Distribution D=new Distribution();
            D.P = new double[i_infos.Count];
            D.Min = new decimal[i_infos.Count];

            for (int i = 0; i < i_infos.Count(); ++i)
            {
                D.P[i] = i_infos[i].PatternPercent;
                D.Min[i] = i_infos[i].FixedExpense >0 ? i_infos[i].FixedExpense : 0;
            }
            D.Total = FixedIncome - Savings;

            D.Compute();

            for (int i = 0; i < i_infos.Count(); ++i)
            {
                if (i_infos[i].FixedExpense <0)
                    i_infos[i].Proposed = i_infos[i].FixedExpense;
                else
                    i_infos[i].Proposed = D.R[i];
            }


        }



        void ComputeSpendingPattern()
        {
            // get last years spendings per category
            DateTime end = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            TimeSpan sixmonths = new TimeSpan(365 / 2, 0, 0, 0, 0);
            DateTime start = end.Subtract(sixmonths);

            var cat2amount = DataTier.Database.Current.Categories.GetCategoryToAmount(start, end);


            // compute total expense
            decimal total = 0;
            foreach (var pair in cat2amount)
            {
                if (pair.Value > 0) 
                    total += pair.Value;
            }

            SpendingPattern = new SortedList<string, float>();
            foreach (var pair in cat2amount)
            {
                if (pair.Value>0)
                    SpendingPattern.Add(pair.Key, (float)pair.Value / (float)total);
                else
                    SpendingPattern.Add(pair.Key, 0);

            }

            ComputeMonthlySpending();
                
        }

        private void ComputeMonthlySpending()
        {
            MonthlySpending = new SortedList<string, SortedList<string, decimal>>();
            foreach (var category in SpendingPattern)
            {
                SortedList<string, decimal> expense = new SortedList<string, decimal>(); // month to amount
                MonthlySpending.Add(category.Key, expense);
            }

            foreach (var month in RecentMonths)
            {
                DateTime end = new DateTime(month.Date.Year,month.Date.Month,25);
                

                int begin_month = end.Month - 1;
                int begin_year = end.Year;
                if (begin_month ==0)
                {
                    begin_month = 12;
                    begin_year--;
                }
                DateTime begin = new DateTime(begin_year, begin_month, end.Day);
                var amounts = DataTier.Database.Current.Categories.GetCategoryToAmount(begin, end);
                foreach (var pair in amounts)
                {
                    if (MonthlySpending.ContainsKey(pair.Key) && amounts.ContainsKey(pair.Key))
                        MonthlySpending[pair.Key].Add(month.Name, amounts[pair.Key]);
                }

            }
        }


        void ComputeFixedIncome()
        {
            IQueryable<Rules> rules = DataTier.Database.Current.Rules.RecurrentRules;
            FixedIncome = 0;
            foreach (var rule in rules)
            {
                if(rule.Amount>0)
                    FixedIncome += rule.MonthlyAmount;
            }
        }
        #endregion

        #region INotifyProperyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

}
