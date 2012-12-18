using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DataTier;

namespace Presentation
{
    public class TransactionsPresenter:INotifyPropertyChanged
    {
        #region Lifetime
        public TransactionsPresenter()
        {
            CurrentExpense = Expenses.First();

        }
        #endregion

        #region bindable properties
        public IQueryable<Transact> Expenses
        {
            get { return Database.Current.Expenses; }
        }

        Transact m_current_expense;
        public Transact CurrentExpense
        {
            get { return m_current_expense; }
            set 
            {
                m_current_expense = value;
                NotifyPropertyChanged("CurrentExpense");
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


        public void SelectCategory(Categories i_selected)
        {
            CurrentExpense.Category = i_selected.ID;
            Database.Current.Context.SaveChanges();

            NotifyPropertyChanged("Expenses");
        }
    }
}
