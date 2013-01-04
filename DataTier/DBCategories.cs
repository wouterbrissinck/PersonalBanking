using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace DataTier
{
    public class DBCategories
    {
        public ObjectSet<Categories> Categories
        {
            get { return Database.Current.Context.Categories; }
        }

        public void Add()
        {
            Categories newCategory = new Categories();
            newCategory.Name = "New Category";
            newCategory.Color = "#FF000000";
            Database.Current.Context.Categories.AddObject(newCategory);
            Database.Current.SaveChanges();
        }
        public Categories Default()
        {
            return Categories.FirstOrDefault();
        }

        public void Delete(Categories cat)
        {
            var transactions = from transact in Database.Current.Transactions
                               where transact.Category == cat.ID
                               select transact;
            foreach (var transact in transactions)
            {
                transact.Category = null;
            }

            Categories.DeleteObject(cat);

            Database.Current.SaveChanges();
        }
    }
}
