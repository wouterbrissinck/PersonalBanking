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
            Periods = TimeSpans.Periods();
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

        public TimeSpans.Period Period { get; set; }
        public List<TimeSpans.Period> Periods { get; set; }
        public void PeriodSelected()
        {
            NotifyPropertyChanged("CategoryDistribution");
        }

        private void ComputeCategoryDistribution()
        {

            // limit expenses to the relevant onces
            DateTime today = DateTime.Now;
            TimeSpan period = Period.Span;
            DateTime start = today.Subtract(period);


            var category_2_amount = Database.Current.Categories.GetCategoryToAmount(start, DateTime.Now);

            // sort it
            var pie_list = (from element in category_2_amount
                            where element.Value>0
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
