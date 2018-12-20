using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WpfApp1.Model;
using System.IO;
using System.Windows.Forms;

namespace WpfApp1.ViewModel
{
    class MainWindowViewModel : BaseView
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { RaiseSetIfChanged(ref filePath, value); }
        }

        private string overallOvertime;

        public string OverallOvertime
        {
            get { return overallOvertime; }
            set { RaiseSetIfChanged(ref overallOvertime, value); }
        }



        #region ObservableCollections
        ObservableCollection<DayData> Daydata = new ObservableCollection<DayData>();

        #endregion

        #region ObservableCollectionviewSource
        public CollectionViewSource Daydatasource { get; } = new CollectionViewSource();
        #endregion

        #region ICommands
        private ICommand onLoad;

        public ICommand OnLoad
        {
            get { return onLoad ?? (new RelayCommand(() => WindowLoad())); }
        }

        private ICommand onFolderDialogClick;
        public ICommand OnFolderDialogClick
        {
            get { return onFolderDialogClick ?? (new RelayCommand(() => FolderDialogClick())); }
        }

        #endregion

        private void WindowLoad()
        {
            Daydatasource.Source = Daydata;
            Run();
        }

        private void Run()
        {
            Management mgmt = new Management();
            mgmt.Run(Daydata);
            OverallOvertime = $"Überstunden gesamt: { mgmt.tHandler.OverallOvertime(Daydata)}";
        }

        private void FolderDialogClick()
        {
            FolderBrowserDialog folderBrowserDia = new FolderBrowserDialog();
            if (folderBrowserDia.ShowDialog() == DialogResult.OK)
            {
                FilePath = folderBrowserDia.SelectedPath;
            }
        }
    }
}
