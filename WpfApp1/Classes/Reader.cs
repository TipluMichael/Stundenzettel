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
            using (StreamReader sr = new StreamReader(@"...\...\Files\Stundezettel.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();

                    strArray = str.Split('/');

                    //DateTime Date = DateTime.ParseExact(strArray[0], "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture).Date;
                    //Console.WriteLine(Date);
                    DateTime Start = DateTime.Parse(strArray[1]);
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
    }
}
