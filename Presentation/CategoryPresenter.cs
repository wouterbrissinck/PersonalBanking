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
            get { return Database.Current.CategoriesView; }
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
                    return from expense in Database.Current.Expenses
                           where expense.Category == CurrentCategory.ID
                           select expense;
                }
                else
                {
                    return from expense in Database.Current.Expenses
                           select expense;
                }
            }
        }
        public Transact CurrentExpense
        {
            get;
            set;
        }
        #endregion
        
        #region Operations
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

        public void CategorySelected(Categories i_selected)
        {
            CurrentExpense.Category = i_selected.ID;
            Database.Current.SaveChanges();
        }
    }
}
