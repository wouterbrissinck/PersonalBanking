using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace DataTier
{
    abstract public class Importer
    {
        public void Load(String i_file)
        {
            LoadPrivate(i_file);
            Database.Current.SaveChanges();
            ApplyRules();
            Database.Current.SaveChanges();
            //SetInternals();
            //Database.Current.SaveChanges();
        }

        private void SetInternals()
        {
            var transactions = from trans in Database.Current.Transactions
                               select trans;
            foreach (var trans in transactions)
            {
                SetInternal(trans);
            }
        }


        abstract protected void LoadPrivate(String i_file);


        private void ApplyRules()
        {
            IQueryable<Transact> transactions = from transact in Database.Current.Context.Transact
                               where !transact.Category.HasValue
                               select transact;
            
            foreach (var rule in Database.Current.Rules.Rules)
            {
                Database.Current.Rules.Apply(rule.ID, transactions );
            }

        }


        protected void AddTransaction(Transact i_transaction)
        {
            var result = from trans in Database.Current.Context.Transact
                         where trans.Reference == i_transaction.Reference && trans.Account == i_transaction.Account
                         select trans;

            AddAccount(i_transaction);

            if (result.Count() == 0)
            {
                SetInternal(i_transaction);
                Database.Current.Context.Transact.AddObject(i_transaction);
            }
        }

        private void SetInternal(Transact i_transaction)
        {
            var accounts = from account in Database.Current.Context.Accounts
                           select account;
            foreach (var acc in accounts)
            {
                if (DBAccounts.IsEqual(i_transaction.Destinations, acc.AccountNr))
                {
                    i_transaction.Internal = true;
                }
            }
        }

        private void AddAccount(Transact i_transaction)
        {
            var result = from account in Database.Current.Context.Accounts
                         where account.AccountNr == i_transaction.Account
                         select account;

            if (result.Count() == 0)
            {
                Account acc = Account.CreateAccount(i_transaction.Account, 0);
                Database.Current.Context.Accounts.AddObject(acc);
                Database.Current.SaveChanges();
            }

            
        }

    }
}
