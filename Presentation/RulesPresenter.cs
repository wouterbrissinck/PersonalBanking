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
    public class RulesPresenter : INotifyPropertyChanged
    {
        #region inner classes
        public class EFieldTypeConverter : TypeConverter
        {
            static Dictionary<DataTier.DBRules.EField, string> StringList;
            static EFieldTypeConverter()
            {
                StringList = new Dictionary<DataTier.DBRules.EField, string>();
                StringList.Add(DataTier.DBRules.EField.description, "Description");
                StringList.Add(DataTier.DBRules.EField.destination, "Destination");
                StringList.Add(DataTier.DBRules.EField.account, "Account");

            }

            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                {
                    return true;
                }
                return base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string)
                {
                    string val = value as string;
                    foreach (var field in StringList)
                    {
                        if (field.Value == value as string)
                            return field.Key;
                    }
                }
                return base.ConvertFrom(context, culture, value);
            }

            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
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

        public class Category
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
        public class Rule
        {
            public Rule(RulesPresenter i_dad,DataTier.Rules i_data)
            {
                Data = i_data;
                Dad = i_dad;
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
                    EFieldTypeConverter conv = new EFieldTypeConverter();
                    return conv.ConvertTo(Field, typeof(String)) as String;
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

            public Guid ID
            {
                get { return Data.ID; }
                set { Data.ID = value; }
            }
            public string Substring
            {
                get { return Data.substring; }
                set { Data.substring = value; }
            }

            public IEnumerable<Category> AllCategories
            {
                get{return Dad.AllCategories;}
            }

            public int CategoryIndex
            {
                get 
                {
                    int index = 0;
                    foreach (Category cat in AllCategories)
                    {
                        if (cat.Id == Data.category)
                            return index;
                        index++;
                    }
                    return 0;
                }
                set 
                {
                    Data.category = AllCategories.ElementAt(value).Id;
                }
            }

            #region data
            private DataTier.Rules Data { get; set; }
            private RulesPresenter Dad{ get; set;}
            #endregion

        }
        #endregion

        #region Lifetime
        public RulesPresenter()
        {
            CreateRules();
            CreateAllCategories();
            CurrentExpense = Expenses.First();
        }
        #endregion

        #region privates
        private void CreateRules()
        {
            Rules = new ObservableCollection<Rule>();
            var result = from rule in Database.Current.Context.Rules
                         select rule;
            foreach (var rule in result)
            {
                Rules.Add(new Rule(this,rule));
            }
            CurrentRule = Rules.FirstOrDefault();

        }
        private void CreateAllCategories()
        {
            AllCategories= from cat in DataTier.Database.Current.Context.Categories
                   select new Category
                   {
                       Name = cat.Name,
                       Id = cat.ID
                   };
        }
        #endregion

        #region Operations
        public void Add()
        {
            Rules rule=Database.Current.Rules.AddRule();
            Rule presenter = new Rule(this, rule);
            Rules.Add(presenter);
            CurrentRule = presenter;
            NotifyPropertyChanged("CurrentRule");
        }
        public void Delete()
        {
            Database.Current.Rules.DeleteRule(CurrentRule.ID);
            Rules.Remove(CurrentRule);
            CurrentRule = Rules.FirstOrDefault();
            NotifyPropertyChanged("CurrentRule");
        }
        public void Apply()
        {

        }

        #endregion

        #region bindable properties
        public IEnumerable<Transact> Expenses
        {
            get { return Database.Current.Rules.GetTransactions(CurrentRule.ID); }
        }

        public ObservableCollection<Rule> Rules { get; set; }
        public Rule CurrentRule 
        {
            get { return m_current_rule; }
            set 
            { 
                m_current_rule = value;
                NotifyPropertyChanged("CurrentRule");
                NotifyPropertyChanged("Expenses");
            } 
        }

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

        #region data
        Rule m_current_rule;
        IEnumerable<Category> AllCategories { get; set; }
        Transact m_current_expense;
        #endregion
    }
}
