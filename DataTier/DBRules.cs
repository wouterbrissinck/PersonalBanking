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

        public ObjectQuery<Rules> Rules
        {
            get
            {
                var result = from rule in Database.Current.Context.Rules
                             select rule;
                return (ObjectQuery<Rules>)result;
            }

        }

        public void DeleteRule(Guid i_id)
        {
            var victim= Database.Current.Context.Rules.FirstOrDefault(rule => rule.ID==i_id);
            Database.Current.Context.Rules.DeleteObject(victim);
            Database.Current.Context.SaveChanges();
        }
        public Rules AddRule()
        {

            Rules rule = new DataTier.Rules();
            rule.ID = Guid.NewGuid();
            rule.Name = "New Rule";
            rule.FieldExt = EField.description;
            rule.substring = "xxx";
            rule.category = Database.Current.Categories.FirstOrDefault().ID;
            Database.Current.Context.Rules.AddObject(rule);
            Database.Current.Context.SaveChanges();

            return rule;
        }

        public IEnumerable<Transact> GetTransactions(Guid i_rule)
        { 
            var rules=from a_rule in Rules
                        where a_rule.ID==i_rule
                        select a_rule;
            var rule=rules.First();

            var result=from transact in Database.Current.Transactions
                       where transact.Description.Contains(rule.substring)
                select transact;

            return result;
        }
    }
}
