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
        }
        #endregion

        #region Lifetime
        public PlanPresenter()
        {
            RecentMonths = TimeSpans.RecentMonths();
            ActiveMonth = RecentMonths[0];
            Periods = TimeSpans.Periods();
            PeriodConsidered = Periods[3];
            Savings = 200;
        }
        #endregion

        #region Bindable Properties
        public System.Collections.ObjectModel.ObservableCollection<CategoryInfo> Infos { get; private set; }
        SortedList<string, float> SpendingPattern {get;set;}
        SortedList<string, decimal> AverageSpending {get;set;}
        public decimal FixedIncome{get;set;}
        public List<TimeSpans.Month> RecentMonths{get;set;}
        public TimeSpans.Month ActiveMonth { get; set; }
        public List<TimeSpans.Period> Periods{get;set;}

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
                    info.AverageExpense = AverageSpending[cat.Name];
                    to_sort.Add(info);
                }
            }

            decimal budget = FixedIncome-Savings;
            float percent = 0;
            foreach (var info in to_sort)
            {
                info.Proposed = FixedIncome * (decimal)info.PatternPercent;
                if (info.Proposed < info.FixedExpense*(decimal)1.1)
                {
                    budget -= info.FixedExpense;
                    info.Override = true;
                }
                else 
                {
                    percent += info.PatternPercent;
                    info.Override = false;
                }

            }
            budget = budget / (decimal)percent;
            foreach (var info in to_sort)
            {
                info.Proposed = budget * (decimal)info.PatternPercent;
                if (info.Override)
                    info.Proposed = info.FixedExpense;

            }

            to_sort.Sort((x, y) => x.AverageExpense < y.AverageExpense? 1 : (x.AverageExpense == y.AverageExpense? 0 : -1));
            foreach (var info in to_sort)
            {
                Infos.Add(info);
            }
            
        }

        void ComputeSpendingPattern()
        {
            // get last years spendings per category
            DateTime start = DateTime.Now;
            start=start.Subtract(PeriodConsidered.Span);
            int months = PeriodConsidered.Months;

            var cat2amount = DataTier.Database.Current.Categories.GetCategoryToAmount(start, DateTime.Now);

            // only keep expenses, remove incomes
            var cat2expense = from pair in cat2amount
                              where pair.Value > 0
                              select pair;


            // compute total expense
            decimal total = 0;
            foreach (var pair in cat2expense)
            {
                total += pair.Value;
            }

            SpendingPattern = new SortedList<string, float>();
            foreach (var pair in cat2expense)
            {
                SpendingPattern.Add(pair.Key, (float)pair.Value / (float)total);
            }

            AverageSpending = new SortedList<string, decimal>();
            foreach (var pair in cat2expense)
            {
                AverageSpending.Add(pair.Key, pair.Value / (decimal)months);
            }
        }


        void ComputeFixedIncome()
        {
            IQueryable<Rules> rules = DataTier.Database.Current.Rules.RecurrentIncomeRules;
            FixedIncome = 0;
            foreach (var rule in rules)
            {
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
