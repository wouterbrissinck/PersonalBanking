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
    /// Interaction logic for TransactionsTab.xaml
    /// </summary>
    public partial class TransactionsTab : UserControl
    {
        TransactionsPresenter Presenter { get; set; }
        public TransactionsTab()
        {
            InitializeComponent();
            m_category_selector.DataContext = (App.Current as App).CategoryPresenter;
            Presenter=(App.Current as App).TransactionPresenter;
            DataContext = Presenter;
        }

        private void m_category_selector_CategorySelected(DataTier.Categories i_selected)
        {
            Presenter.SelectCategory.Execute(i_selected);
            m_expenses_selector.m_listbox.SelectedIndex++;
        }
    }
}
