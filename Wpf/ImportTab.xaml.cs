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
    /// Interaction logic for ImportTab.xaml
    /// </summary>
    public partial class ImportTab : UserControl
    {
        public ImportTab()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            FortisImporter.Load(m_ImportFileName.Text);
        }


    }
}
