using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Input;
using System.Reflection;
using DataTier;

namespace Presentation
{
    public class RulesPresenter
    {
        #region inner classes
        public class EFieldTypeConverter: TypeConverter
        {
            static Dictionary<DataTier.DBRules.EField,string> StringList;
            static EFieldTypeConverter()
            {
                StringList=new Dictionary<DataTier.DBRules.EField,string>();
                StringList.Add(DataTier.DBRules.EField.description,"Description");
                StringList.Add(DataTier.DBRules.EField.destination,"Destination");
                StringList.Add(DataTier.DBRules.EField.account,"Account");

            }

           public override bool CanConvertFrom(ITypeDescriptorContext context,Type sourceType) 
            {
              if (sourceType == typeof(string)) {
                 return true;
              }
              return base.CanConvertFrom(context, sourceType);
            }

           public override object ConvertFrom(ITypeDescriptorContext context,CultureInfo culture, object value) 
           {
              if (value is string) 
              {
                  string val=value as string;
                  foreach (var field in StringList)
                  {
                    if (field.Value==value as string)
                        return field.Key;
                  }
              }
              return base.ConvertFrom(context, culture, value);
           }

            public override object ConvertTo(ITypeDescriptorContext context,CultureInfo culture, object value, Type destinationType) 
            {  
                if (destinationType == typeof(string)) 
                {
                    return StringList[(DataTier.DBRules.EField)value];
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

            static public IEnumerable<string> Values
            {
                get
                {
                    return StringList.Values;
                }
            }
        }

        public class Rule
        {
            public Rule(DataTier.Rules i_data)
            {
                Data = i_data;
            }

            public IEnumerable<string> PossibleFields
            {
                get
                {
                    return EFieldTypeConverter.Values;
                }
            }
            public string FieldStr 
            {
                get
                {
                    EFieldTypeConverter conv=new EFieldTypeConverter();
                    return conv.ConvertTo(Field,typeof(String)) as String;
                }
                set
                {
                    EFieldTypeConverter conv = new EFieldTypeConverter();
                    Field = (DataTier.DBRules.EField)conv.ConvertFrom(value);
                }
            }
            public DataTier.DBRules.EField Field
            {
                get { return Data.FieldExt; }
                set { Data.FieldExt = value; }
            }

            public string Name
            {
                get { return Data.Name; }
                set { Data.Name = value; }
            }

            public string Substring
            {
                get { return Data.substring; }
                set { Data.substring = value; }
            }



            #region data
            private DataTier.Rules Data { get; set; }
            #endregion

        }
        #endregion
        
        #region Lifetime
        public RulesPresenter()
        {
            CurrentExpense = Expenses.First();
            CreateRules();

        }
        #endregion

        #region bindable properties
        public IQueryable<Transact> Expenses
        {
            get { return Database.Current.Expenses; }
        }

        public ObservableCollection<Rule> Rules { get; set; }
        private void CreateRules()
        {
            Rules = new ObservableCollection<Rule>();
            var result = from rule in Database.Current.Context.Rules
                         select rule;
            foreach (var rule in result)
            {
                Rules.Add(new Rule(rule));
            }

        }

        Transact m_current_expense;
        public Transact CurrentExpense
        {
            get { return m_current_expense; }
            set
            {
                m_current_expense = value;
                NotifyPropertyChanged("CurrentExpense");
            }
        }
        #endregion

        #region INotifyProperyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
