using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class RecurrentRuleInfo
    {
        public class SpentPerMonth
        {
            public decimal[] Months{get;set;}

            public SpentPerMonth(IEnumerable<Transact> i_expenses,DateTime i_reference)
            {
                Months = new decimal[12];

                foreach (Transact expense in i_expenses)
                {
                    if (expense.Date.HasValue)
                    {
                        int month = expense.Date.Value.Month;
                        int ref_month = i_reference.Date.Month;

                        int index = ref_month - month;
                        if (index < 0)
                            index += 12;
                        Months[index] += expense.Amount;
                    }
                }
                
            }

            public decimal Average
            {
                get 
                {
                    return Months.Average();
                }
            }

            int FirstIndex
            { 
                get
                {
                    for (int i = 0; i < 12; ++i)
                    {
                        if (Months[i] != 0)
                            return i;
                    }
                    return 11;
                }
            }
            int LastIndex
            {
                get
                {
                    for (int i = 11; i >= 0; --i)
                    {
                        if (Months[i] != 0)
                            return i+1;
                    }
                    return 12;
                }
            }

            int NonZeroes
            {
                get
                {
                    int zeroes = 0;
                    for (int i = FirstIndex; i < LastIndex; ++i)
                    {
                        if (Months[i] == 0)
                            zeroes++;
                    }
                    return LastIndex-FirstIndex - zeroes;

                }
            }


            int Density
            {
                get 
                {

                    return (int)(100f*((float)NonZeroes / (LastIndex - FirstIndex)));
                }
            }

            public DBRules.ERecurrence RecurrenceGuess
            {
                get 
                {
                    if (NonZeroes == 1)
                        return DBRules.ERecurrence.yearly;
                    else if (Density == 100)
                        return DBRules.ERecurrence.monthly;
                    else if (Density > 51)
                        return DBRules.ERecurrence.bimonthly;
                    else if (Density > 39)
                        return DBRules.ERecurrence.threemonthly;
                    else
                        return DBRules.ERecurrence.sixmonthly;
                }
            }

            public decimal LastExpense
            {
                get 
                {
                    return Months[FirstIndex];
                }
            }
        
        }



        public RecurrentRuleInfo()
        { 
        
        }


    }
}
