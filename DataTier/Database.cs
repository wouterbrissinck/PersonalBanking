using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace DataTier
{
    public delegate void DataChangedEvent();
    public class Database
    {
        #region lifetime
        static private Database m_current;
        static public Database Current
        {
            get 
            {
                if (m_current==null)
                    m_current=new Database();
                return m_current;
            }
        }

        public Database()
        {
            Context = new BankTestEntities1();
            try
            {
                Context.Connection.Open();
            }
            catch 
            {
                throw new Exception("Cannot connect to database");
            }

            Rules = new DBRules();
            Categories = new DBCategories();

        }

        public BankTestEntities1 Context { get; set; }
        #endregion

        public DBRules Rules
        {
            get;
            private set;
        }
        public DBCategories Categories
        {
            get;
            private set;
        }

        #region Direct access

        public ObjectSet<Transact> Transactions
        {
            get { return Context.Transact; }
        }

        public Transact GetTransaction(string Account,string Reference)
        {
            var result = from trans in Context.Transact
                        where (trans.Account == Account && trans.Reference == Reference)
                        select trans;
            return result.First();
        }
        #endregion

        #region Events
        public event DataChangedEvent DataChanged;
        #endregion


        #region Operations
        public void SaveChanges()
        {
            Context.SaveChanges();
            if (DataChanged != null)
                DataChanged();

        }
        #endregion

        #region Queries
        public ObjectQuery<Transact> Expenses
        {
            get
            {
                var result = from trans in Context.Transact
                             where trans.Amount < 0 && !trans.Internal.HasValue
                             select trans;
                return (ObjectQuery<Transact>)result;
            }

        }
        public ObjectQuery<Transact> UncatExpenses
        {
            get
            {
                var result = from trans in Context.Transact
                             where trans.Amount < 0
                             && !trans.Category.HasValue
                             && !trans.Internal.HasValue
                             select trans;
                return (ObjectQuery<Transact>)result;
            }

        }

        #endregion

        #region views
        public ObjectQuery<Categories> CategoriesView
        {
            get {return (ObjectQuery<Categories>) from cat in Context.Categories select cat; }
        }

        #endregion
    }
}
