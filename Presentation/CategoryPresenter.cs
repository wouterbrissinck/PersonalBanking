using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.ComponentModel;
using DataTier;

namespace Presentation
{
    public class CategoryPresenter : INotifyPropertyChanged
    {
        #region Lifetime
        public CategoryPresenter()
        {
            CurrentCategory = Categories.First();
            Database.Current.DataChanged += new DataChangedEvent(Current_DataChanged);
            End = DateTime.Now;
            Start=new DateTime(End.Year-1,End.Month,End.Day);
        }

        void Current_DataChanged()
        {
            NotifyPropertyChanged("Categories");
            NotifyPropertyChanged("Expenses");
        }
        #endregion

        #region bindable properties
        public IQueryable<Categories> Categories
        {
            get { return Database.Current.Categories.CategoriesAll ; }
        }

        Categories m_current_category;
        public Categories CurrentCategory
        {
            get { return m_current_category; }
            set 
            { 
                m_current_category = value;
                NotifyPropertyChanged("CurrentCategory");
                NotifyPropertyChanged("Expenses");
            }
        }

        public IEnumerable<Transact> Expenses
        {
            get 
            {
                if (CurrentCategory != null)
                {
                    return from expense in Database.Current.RealTransactions
                           where expense.Category == CurrentCategory.ID
                           && expense.Date<=End
                           && expense.Date>=Start
                           select expense;
                }
                else
                {
                    return from expense in Database.Current.RealTransactions
                           where expense.Date <= End
                           && expense.Date >= Start
                           select expense;
                }
            }
        }
        public Transact CurrentExpense
        {
            get;
            set;
        }

        DateTime _start;
        public DateTime Start 
        { get{return _start;} set{_start=value;NotifyPropertyChanged("Expenses"); }}
        
        DateTime _end;
        public DateTime End
        { get { return _end; } set { _end = value; NotifyPropertyChanged("Expenses"); } }

        #endregion
        
        #region Operations
        public void CategorySelected(Categories i_selected)
        {
            CurrentExpense.Category = i_selected.ID;
            Database.Current.SaveChanges();
        }

        public void AddCategory()
        {
            Database.Current.Categories.Add();

            CurrentCategory = Categories.First();
            NotifyPropertyChanged("Categories");
            NotifyPropertyChanged("CurrentCategory");
        }

        public void DeleteCategory()
        {
            Database.Current.Categories.Delete(CurrentCategory);
            CurrentCategory = Categories.First();
            NotifyPropertyChanged("Categories");
            NotifyPropertyChanged("CurrentCategory");
        }

        public void ClearCategory()
        {
            CurrentExpense.Category = null;
            Database.Current.SaveChanges();
        }

        #endregion

        #region INotifyProperyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(string propertyName)
        { 
            if (PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }
}
