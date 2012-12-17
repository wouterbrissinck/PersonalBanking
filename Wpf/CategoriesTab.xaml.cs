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
using Presentation;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for CategoriesTab.xaml
    /// </summary>
    public partial class CategoriesTab : UserControl
    {
        Presentation.CategoryPresenter Presenter { get; set; }

        public CategoriesTab()
        {
            InitializeComponent();
            Presenter= (App.Current as App).CategoryPresenter;
            DataContext = Presenter;
            m_categorySelector.DataContext = Presenter;
        }


        private void OnClickAdd(object sender, RoutedEventArgs e)
        {
            Presenter.AddCategory();
        }
        private void OnClickDelete(object sender, RoutedEventArgs e)
        {
            Presenter.DeleteCategory();
        }

    }
}
