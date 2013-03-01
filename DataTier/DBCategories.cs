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
        private ObjectSet<Categories> Categories
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

        public ObjectQuery<Categories> CategoriesAll
        {
            get { return (ObjectQuery<Categories>)from cat in Categories select cat; }
        }

        public SortedList<string, decimal> GetCategoryToAmount(DateTime i_start, DateTime i_end)
        {
            var expenses = from expense in Database.Current.RealTransactions
                           where expense.Date >= i_start
                           && expense.Date < i_end
                           select expense;

            // add up the amounts per category
            SortedList<string, decimal> toret = new SortedList<string, decimal>();
            foreach (var expense in expenses)
            {
                if (expense.Categories != null)
                {
                    if (!toret.ContainsKey(expense.Categories.Name))
                    {
                        toret[expense.Categories.Name] = 0;
                    }
                    toret[expense.Categories.Name] -= expense.Amount;

                }

            }

            return toret;
        }

    }
}
