using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Reader
    {
        public void GetData()
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
                ReadDictionary(strList);
            }

        }

        private void ReadDictionary(Dictionary<int, List<string>> strList)
        {
            foreach (var row in strList)
            {
                DayData tempDay = new DayData();

                tempDay.Date = DateTime.ParseExact(row.Value[0], "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).Date;
                tempDay.Start = TimeSpan.Parse(row.Value[1]);
                tempDay.End = TimeSpan.Parse(row.Value[2]);
                tempDay.Hours = GetHours(tempDay.Start, tempDay.End);
                if (row.Value.Count >= 4)
                {
                    if (String.IsNullOrEmpty(row.Value[3]))
                    {
                        tempDay.BreakTime = 30;
                    }
                    else
                        tempDay.BreakTime = float.Parse(row.Value[3]);

                    if (row.Value.Count >= 5)
                    {
                        if (String.IsNullOrEmpty(row.Value[4]))
                        {
                            tempDay.Reason = "-";
                        }
                        else
                            tempDay.Reason = row.Value[4];
                    }
                    Utility.days_l.Add(tempDay);
                }
            }
        }

        TimeSpan GetHours(TimeSpan sta, TimeSpan end)
        {
            TimeSpan diff = end - sta;
            return diff;
        }
    }
}
