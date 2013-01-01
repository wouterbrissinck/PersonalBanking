using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using DataTier;


namespace Presentation
{
    public class TransactionsPresenter:INotifyPropertyChanged
    {
        #region commands
        public class SelectCategoryCommand : ICommand 
        {
            public SelectCategoryCommand(TransactionsPresenter i_presenter)
            {
                Presenter = i_presenter;
            }
            TransactionsPresenter Presenter { get; set; }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Presenter.CurrentExpense.Category = (parameter as DataTier.Categories).ID;
                Database.Current.Context.SaveChanges();
                Presenter.NotifyPropertyChanged("Expenses");
            }
        }
        #endregion

        #region Lifetime
        public TransactionsPresenter()
        {
            CurrentExpense = Expenses.First();
            SelectCategory = new SelectCategoryCommand(this);

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

        #region Commands
        public ICommand SelectCategory { get; set; }
        #endregion
    }
}
