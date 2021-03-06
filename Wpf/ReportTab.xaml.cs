﻿using System;
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
using PieControls;
using System.Collections.ObjectModel;
using Presentation;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for ReportTab.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        ReportPresenter Presenter { get; set; }

        public Report()
        {
            InitializeComponent();
            Presenter = (App.Current as App).ReportPresenter;
            DataContext = Presenter;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Presenter.PeriodSelected();
        }
    }
}
