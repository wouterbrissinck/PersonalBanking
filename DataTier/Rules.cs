using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace DataTier
{


    partial class Rules
    {
        public DBRules.EField FieldExt
        {
            get { return (DBRules.EField)field; }
            set { field = (int)value; }
        }

        public ObjectSet<Categories> AllCategories
        {
            get { return Database.Current.Context.Categories; }
        }

    }
}
