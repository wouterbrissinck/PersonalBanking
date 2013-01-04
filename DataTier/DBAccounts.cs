using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class DBAccounts
    {
        public static bool IsEqual(string i_a,string i_b)
        {
            string a=i_a.Replace(" ","");
            a = a.Replace("-", "");
            string b = i_b.Replace(" ", "");
            b = b.Replace("-", "");

            int al=a.Length;
            int bl=b.Length;

            if (al < 12 || bl < 12)
                return false;
            for (int i = 1; i < 13; ++i)
            {
                if (a[al - i] != b[bl - i])
                    return false;
            }

            return true;
        }
    }
}
