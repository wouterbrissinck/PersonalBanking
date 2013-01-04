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
using Presentation;
using Microsoft.Win32;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for ImportTab.xaml
    /// </summary>
    public partial class ImportTab : UserControl
    {
        ImportPresenter Presenter { get; set; }

        public ImportTab()
        {
            InitializeComponent();
            Presenter = (App.Current as App).ImportPresenter;
            DataContext = Presenter;
        }

        private void Import(object sender, RoutedEventArgs e)
        {
            Presenter.Import();
        }
        private void Browse(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            Presenter.FileName = dlg.FileName;
        }


    }
}
