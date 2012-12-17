using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BankTest
{
    class FortisImporter
    {
        public bool Dinges { get; set; }
        private BankTestDataSet m_dataset;
        public void Load(String i_file)
        {
            m_dataset = new BankTestDataSet();

            StreamReader reader = new StreamReader(i_file);
            String line = reader.ReadLine();  // throw away header
            line = reader.ReadLine();
            while (line != null)
            {
                String[] fields=line.Split(';');
                BankTestDataSet.TransactRow row=m_dataset.Transact.NewTransactRow();
                row.Reference=fields[0];
                row.Date=Convert.ToDateTime(fields[1]);
                row.Amount=Convert.ToDecimal(fields[3]);
                row.Destinations=fields[5];
                row.Description=fields[6];
                row.Account=fields[7];
                m_dataset.Transact.Rows.Add(row);

                line = reader.ReadLine();
            }
        }
        
    }
}
