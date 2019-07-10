using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Reader
    {
        public void GetData(ObservableCollection<DayData> vDayDataList)
        {
            int count = 0;
            Dictionary<int, List<string>> strList = new Dictionary<int, List<string>>();
            using (StreamReader sr = new StreamReader(@"...\...\Files\Stundezettel.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    count++;
                    List<string> tempRow = new List<string>();
                    string[] strArray;

                    string str = sr.ReadLine();
                    strArray = str.Split('/');
                    if (!str.StartsWith("#"))
                    {
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            tempRow.Add(strArray[i]);
                        }
                        strList.Add(count, tempRow);
                    }


                }
                ReadDictionary(strList, vDayDataList);
            }

        }

        private void ReadDictionary(Dictionary<int, List<string>> strList, ObservableCollection<DayData> vDayDataList)
        {
            foreach (var row in strList)
            {
                DayData tempDay = new DayData();

                tempDay.Date = DateTime.ParseExact(row.Value[0], "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).Date;
                int lenght = row.Value.Count;
                switch (lenght)
                {
                    //TODO: Mach ma
                    case 2:
                        tempDay.Start = TimeSpan.Parse(row.Value[1]);
                        tempDay.End = TimeSpan.Parse(row.Value[1]);
                        break;
                    case 3:
                        tempDay.BreakTime = 30;
                        tempDay.Start = TimeSpan.Parse(row.Value[1]);
                        tempDay.End = TimeSpan.Parse(row.Value[2]);
                        tempDay.Hours = GetHours(tempDay.Start, tempDay.End, tempDay.BreakTime);
                        break;
                    case 4:
                        if (String.IsNullOrEmpty(row.Value[3]))
                        {
                            tempDay.BreakTime = 30;
                        }
                        else
                        {
                            tempDay.Hours = GetHours(tempDay.Start, tempDay.End, tempDay.BreakTime);
                        }
                        tempDay.Start = TimeSpan.Parse(row.Value[1]);
                        tempDay.End = TimeSpan.Parse(row.Value[2]);

                        tempDay.Hours = GetHours(tempDay.Start, tempDay.End, tempDay.BreakTime);
                        tempDay.Reason = "-";
                        break;
                    case 5:
                        tempDay.Start = TimeSpan.Parse(row.Value[1]);
                        tempDay.End = TimeSpan.Parse(row.Value[2]);
                        tempDay.Hours = GetHours(tempDay.Start, tempDay.End, tempDay.BreakTime);
                        tempDay.BreakTime = double.Parse(row.Value[3]);
                        tempDay.Reason = row.Value[4];
                        break;
                    default:
                        break;
                }
                vDayDataList.Add(tempDay);
            }
        }

        TimeSpan GetHours(TimeSpan sta, TimeSpan end, double bT)
        {
            TimeSpan diff = (end - sta) - TimeSpan.FromMinutes(bT);
            return diff;
        }
    }
}
