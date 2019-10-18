using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Class
{
    public class ReadINI
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        string filename = "";

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public ReadINI(string _filename = null)
        {
            filename = _filename;
        }


        public string GetDNS()
        {
            string _dns = string.Empty;
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Replace("file:///", "")) + "\\Config.INI"; StreamReader Sdr = new StreamReader(path);
            try
            {
                _dns = GetIniValue("Configuration", "DNS", path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dns;
        }

        private string GetIniValue(string section, string key, string filename, string defaultValue = "")
        {
            StringBuilder sb = new StringBuilder(500);
            if (GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, filename) > 0)
                return sb.ToString();
            else
                return defaultValue;
        }
    }
}
