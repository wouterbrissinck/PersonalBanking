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
            }
        }

        #endregion
        
        #region Operations
        public void AddCategory()
        {
            Categories newCategory=new Categories();
            newCategory.Name = "New Category";
            newCategory.Color = "#FF000000";
            Database.Current.Categories.AddObject(newCategory);
            Database.Current.Context.SaveChanges();

            CurrentCategory = Categories.First();
            NotifyPropertyChanged("Categories");
            NotifyPropertyChanged("CurrentCategory");
        }

        public void DeleteCategory()
        {
            Database.Current.Categories.DeleteObject(CurrentCategory);
            Database.Current.Context.SaveChanges();
            CurrentCategory = Categories.First();
            NotifyPropertyChanged("Categories");
            NotifyPropertyChanged("CurrentCategory");
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
