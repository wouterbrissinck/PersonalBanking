using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace DataTier
{

    public class DBRules
    {
        public enum EField
        {
            description,
            destination,
            account
        }

        public enum ERecurrence
        { 
            undefined,
            monthly,
            bimonthly,
            threemonthly,
            sixmonthly,
            yearly
        }

        public ObjectQuery<Rules> Rules
        {
            get
            {
                var result = from rule in Database.Current.Context.Rules
                             orderby rule.Name
                             select rule;
                return (ObjectQuery<Rules>)result;
            }

        }

        public void DeleteRule(Guid i_id)
        {
            var victim= Database.Current.Context.Rules.FirstOrDefault(rule => rule.ID==i_id);
            Database.Current.Context.Rules.DeleteObject(victim);
            Database.Current.SaveChanges();
        }

        public Rules AddRule()
        {

            Rules rule = new DataTier.Rules();
            rule.ID = Guid.NewGuid();
            rule.Name = "New Rule";
            rule.FieldExt = EField.description;
            rule.substring = "xxx";
            rule.category = Database.Current.Categories.Default().ID;
            rule.Recurring = false;
            Database.Current.Context.Rules.AddObject(rule);
            Database.Current.SaveChanges();

            return rule;
        }

        Rules GetRule(Guid i_rule)
        {
            var rules=from a_rule in Rules
                        where a_rule.ID==i_rule
                        select a_rule;
            return rules.First();
        }

        public IEnumerable<Transact> GetTransactions(Guid i_rule)
        {
            return GetTransactions(i_rule, Database.Current.Expenses);
        }

        public IEnumerable<Transact> GetTransactions(Guid i_rule, IQueryable<Transact> i_transactions)
        { 
            var rule=GetRule(i_rule);

            IEnumerable<Transact> result=null;

            switch (rule.FieldExt)
            { 
                case EField.account:
                    {
                        result = from transact in i_transactions
                                 where transact.Account==rule.substring
                                 select transact;
                        break;
                    }
                case EField.description:
                    {
                        result = from transact in i_transactions
                                 where transact.Description.Contains(rule.substring)
                                 select transact;
                        break;
                    }
                case EField.destination:
                    {
                        result = from transact in i_transactions
                                 where transact.Destinations.Contains(rule.substring)
                                 select transact;
                        break;
                    }

            }

            return result;
        }
        public void Apply(Guid i_rule)
        {
            Apply(i_rule, Database.Current.Transactions);
            Database.Current.SaveChanges();

        }

        public void Apply(Guid i_rule, IQueryable<Transact> i_transactions)
        {
            Rules rule = GetRule(i_rule);
            foreach (var transaction in GetTransactions(i_rule,i_transactions))
            {
                transaction.Category = rule.category;                
            }
        }
    }
}
