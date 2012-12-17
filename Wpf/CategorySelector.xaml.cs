using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTier;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for CategorySelector.xaml
    /// </summary>
    public partial class CategorySelector : UserControl
    {
        public CategorySelector()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (CategorySelected != null)
                {
                    Categories item = m_list_view.SelectedItem as Categories;
                    CategorySelected(item);
                }
            }
        }


        public event CategorySelectorSelectEVent CategorySelected;

        //public int IconSize
        //{
        //    get { return this.m_rectangle.Height; }
        //    set 
        //    {
        //        this.m_list_view.ItemTemplate.
        //        m_rectangle.Height = value;
        //        m_rectangle.Width= value;             
        //    }
        //}
    }
}
