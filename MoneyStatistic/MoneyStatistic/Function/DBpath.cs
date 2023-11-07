using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyStatistic.Function
{
    public class DBpath
    {
        public static string getPath(string DbName)
        {
            string path = string.Empty;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                path = Path.Combine(path, DbName);
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = Path.Combine(path, "..", "Library", DbName);
            }

            return path;
        }


    }
}
