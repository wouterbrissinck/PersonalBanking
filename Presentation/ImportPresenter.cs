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
using System.IO;

namespace Presentation
{
    public class ImportPresenter : INotifyPropertyChanged
    {
        #region lifetime
        public ImportPresenter()
        {
            Importer = new DataTier.FortisImporter();
        }
        #endregion

        #region commands
        public void Import()
        {
            Importer.Load(FileName);
        }
        #endregion

        #region Bindable properties

        public string FileName 
        {
            get
            {
                return m_file_name;
            }
            set
            {
                m_file_name = value;
                NotifyPropertyChanged("FileName");
                NotifyPropertyChanged("CanImport");
            }
        }

        public bool CanImport
        { 
            get
            {
                return System.IO.File.Exists(FileName);
            }
        }

        #endregion

        #region properties
        public DataTier.Importer Importer { get; set; }
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
        string m_file_name;
        #endregion
    }
}
