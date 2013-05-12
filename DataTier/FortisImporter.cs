using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DataTier
{
    public class FortisImporter: Importer
    {
        protected override void LoadPrivate(String i_file)
        {
            StreamReader reader = new StreamReader(i_file);
            String line = reader.ReadLine();  // throw away header
            line = reader.ReadLine();
            while (line != null)
            {
                line=line.Replace('\"',' ');
                String[] fields = line.Split(';');
                if (fields.Length >= 8)
                {
                    for (int i = 0; i < fields.Length; ++i)
                    {
                        fields[i] = fields[i].Trim();
                    }

                    Transact new_transact = Transact.CreateTransact(fields[0], fields[7], Convert.ToDecimal(fields[3]));
                    new_transact.Date = Convert.ToDateTime(fields[1]);
                    new_transact.Destinations = fields[5];
                    new_transact.Description = fields[6];
                    new_transact.Category = null;

                    AddTransaction(new_transact);
                }

                line = reader.ReadLine();
            }
        }



    }
}