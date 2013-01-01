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
    }
}
