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

        public decimal MonthlyAmount
        {
            get 
            {
                if (!Amount.HasValue)
                    return 0;

                int divisor=0;
                switch ((DBRules.ERecurrence)Period)
                {
                    case DBRules.ERecurrence.monthly:divisor=1;break;
                    case DBRules.ERecurrence.bimonthly:divisor=2;break;
                    case DBRules.ERecurrence.threemonthly:divisor=3;break;
                    case DBRules.ERecurrence.sixmonthly:divisor=6;break;
                    case DBRules.ERecurrence.yearly:divisor=12;break;
                    default: divisor = 1; break;
                }
                return Amount.Value / (decimal)divisor;

            }
        }


    }
}
