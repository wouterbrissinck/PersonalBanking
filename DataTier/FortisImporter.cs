using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DataTier
{
    public class FortisImporter
    {
        static public void Load(String i_file)
        {
            StreamReader reader = new StreamReader(i_file);
            String line = reader.ReadLine();  // throw away header
            line = reader.ReadLine();
            while (line != null)
            {
                var default_cat = from cat in Database.Current.Context.Categories
                                  where cat.Name=="None"
                                  select cat;



                String[] fields = line.Split(';');

                Transact new_transact = Transact.CreateTransact(fields[0],fields[7],Convert.ToDecimal(fields[3]));
                new_transact.Date = Convert.ToDateTime(fields[1]);
                new_transact.Destinations = fields[5];
                new_transact.Description = fields[6];
                new_transact.CategoriesReference.Value = default_cat.First();
                Database.Current.Context.AddToTransact(new_transact);

                line = reader.ReadLine();
            }
        }

    }
}