using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DataTier;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Presentation.CategoryPresenter CategoryPresenter { get; set; }
        public Presentation.TransactionsPresenter TransactionPresenter { get; set; }


        void App_Startup(object sender, StartupEventArgs e)
        {
            CategoryPresenter = new Presentation.CategoryPresenter();
            TransactionPresenter = new Presentation.TransactionsPresenter();
        }

        private void Application_Deactivated(object sender, EventArgs e)
        {

        }

        private void App_Activated(object sender, EventArgs e)
        {

        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Database.Current.Context.SaveChanges();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            String outerMessage=e.Exception.Message;
            String innerMessage = e.Exception.InnerException.Message;
            MessageBox.Show(outerMessage + " --- " + innerMessage);

            Application.Current.Shutdown();
        }



    }
}
