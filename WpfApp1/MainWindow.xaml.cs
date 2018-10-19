using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            using (StreamReader sr = new StreamReader(@"...\...\Files\Stundezettel.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();

                    strArray = str.Split('/');

                    DateTime Date = DateTime.ParseExact(strArray[0], "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).Date;
                    Console.WriteLine(Date);
                    string Start = strArray[1];
                    Console.WriteLine(Start);
                    //DayData tempDay = new DayData()
                    //{
                    //    Date = DateTime.ParseExact(strArray[0], "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture),

                    //    Start = DateTime.ParseExact(strArray[1], "HHmm",
                    //                   System.Globalization.CultureInfo.InvariantCulture),

                    //    End = DateTime.ParseExact(strArray[2], "HHmm",
                    //                   System.Globalization.CultureInfo.InvariantCulture),

                    //    Hours = GetHours(DateTime.ParseExact(strArray[1], "HHmm",
                    //                  System.Globalization.CultureInfo.InvariantCulture),

                    //                  DateTime.ParseExact(strArray[2], "HHmm",
                    //                  System.Globalization.CultureInfo.InvariantCulture))
                    ////};
                    //Utility.days_l.Add(tempDay);
                }
            }

        }
        TimeSpan GetHours(DateTime sta, DateTime end)
        {
            TimeSpan diff = sta - end;
            return diff;
        }

        private void GlobalGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = Utility.days_l;
        }
    }
}
