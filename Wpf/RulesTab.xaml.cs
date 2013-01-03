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
    /// Interaction logic for RulesTab.xaml
    /// </summary>
    public partial class RulesTab : UserControl
    {
        RulesPresenter Presenter { get; set; }

        public RulesTab()
        {
            InitializeComponent();
            Presenter = (App.Current as App).RulesPresenter;
            DataContext = Presenter;
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            Presenter.Add();
        }
        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Presenter.Delete();

        }
        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            Presenter.Apply();

        }
    }
}
