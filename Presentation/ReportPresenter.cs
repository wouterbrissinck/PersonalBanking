using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;
using DataTier;
using System.Windows.Forms.DataVisualization;

namespace Presentation
{
    public class ReportPresenter : INotifyPropertyChanged
    {
        public ReportPresenter()
        {
            Periods = new SortedList<string, TimeSpan>();
            Periods["Last year"] = TimeSpan.FromDays(365);
            Periods["Last 6 months"] = TimeSpan.FromDays(365 / 2);
            Periods["Last 3 months"] = TimeSpan.FromDays(365 / 4);
            Periods["Last month"] = TimeSpan.FromDays(365/12);
            Period = Periods.First();

            category_distribution = new ObservableCollection<KeyValuePair<string, double>>();
        }

        #region Data
        ObservableCollection<KeyValuePair<string, double>> category_distribution;
        #endregion

        #region INotifyProperyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public KeyValuePair<string, TimeSpan> Period { get; set; }
        public SortedList<string, TimeSpan> Periods { get; set; }
        public void PeriodSelected()
        {
            NotifyPropertyChanged("CategoryDistribution");
        }

        private void ComputeCategoryDistribution()
        {

            // limit expenses to the relevant onces
            DateTime today = DateTime.Now;
            TimeSpan period = Period.Value;
            DateTime start = today.Subtract(period);

            var expenses = from expense in Database.Current.Expenses
                           where expense.Date > start
                           select expense;

            // add up the amountsper category
            SortedList<string, decimal> CategoryToAmount = new SortedList<string, decimal>();
            foreach (var expense in expenses)
            {
                if (expense.Categories != null)
                {
                    if (!CategoryToAmount.ContainsKey(expense.Categories.Name))
                    {
                        CategoryToAmount[expense.Categories.Name] = 0;
                    }
                    CategoryToAmount[expense.Categories.Name] -= expense.Amount;
                
                }

            }


            // sort it
            var pie_list = (from element in CategoryToAmount
                           orderby element.Value descending
                           select element).Take(15);

            // create pie data
            Random rand = new Random(5);
            category_distribution.Clear();
            foreach (var amount in pie_list)
            {
                category_distribution.Add(new KeyValuePair<string, double>(amount.Key,(double)amount.Value ));
            }
        }
        public ObservableCollection<KeyValuePair<string, double>> CategoryDistribution
        {
            get
            {
                ComputeCategoryDistribution();
                return category_distribution;
            }
        }
    }
}
