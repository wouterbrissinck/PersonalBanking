using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Distribution
    {
        public double[] P { set; get; }
        public decimal[] Min { set; get; }
        public decimal Total { get; set; }

        private bool[] enable { get; set; }
        public decimal[] R { get; set; }

        struct Order
        {
            public int i;
            public decimal sortval;
        }

        public bool Compute()
        {
            Sanity();
            IEnumerable<Order> order = Sort();
            Init();

            int i = 0;
            ComputeR();
            while (!Done() && i<P.Count()-1)
            {
                UpdateEnable(order,i);
                ComputeR();
                ++i;
            }

            return i < P.Count();
        
        }

        void UpdateEnable(IEnumerable<Order> order,int i)
        { 
            enable[order.ElementAt(i).i]=true;
        }

        void ComputeR()
        {
            decimal tot = Total;
            double p = 0;
            for (int i = 0; i < P.Count(); ++i)
            {
                if (enable[i])
                    tot -= Min[i];
                else
                    p += P[i];
            }

            tot = tot / (decimal)p;

            for (int i = 0; i < P.Count(); ++i)
            {
                if (enable[i])
                    R[i] = Min[i];
                else
                    R[i] = tot * (decimal)P[i];
            }

        }

        bool Done()
        {
            for (int i = 0; i < P.Count(); ++i)
            {
                if (R[i]<Min[i])
                    return false;
            }            

            return true;
        }

        void Init()
        {
            enable = new bool[P.Count()];
            R = new Decimal[P.Count()];
            for (int i = 0; i < P.Count(); ++i)
            {
                enable[i] = P[i]<=0;
                R[i] = 0;
            }
        }

        IOrderedEnumerable<Order> Sort()
        {
            List<Order> toret = new List<Order>() ;

            for (int i = 0; i < P.Count(); i++)
            {
                Order o;
                if (P[i]!=0)
                    o=new Order{i=i,sortval= Min[i] / ((decimal)P[i]) / Total};
                else
                    o=new Order{i=i,sortval= 0};
                toret.Add(o);
            }

            return toret.OrderBy( x => -x.sortval);
          
        }

        void Sanity()
        {
            if (P==null)
                throw new System.Exception();
            if (Min==null)
                throw new System.Exception();

            // sum of p's=1;
            double one = 1;
            foreach (double p in P)
            {
                one -= p;
            }
            if (one > 0.00001)
                throw new System.Exception();

            // lengths are all the same
            int size = P.Count();
            if (size != Min.Count())
                throw new System.Exception();

        }

    }
}
