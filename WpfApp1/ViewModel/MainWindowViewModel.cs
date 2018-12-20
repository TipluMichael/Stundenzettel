using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class MainWindowViewModel : BaseView
    {
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
        #endregion

        private void WindowLoad()
        {
            Daydatasource.Source = Daydata;
            Run();
        }

        private void Run()
        {
            Reader rdr = new Reader();
            rdr.GetData(Daydata);
        }
    }
}
