using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;

namespace GitHubNotifier
{
    public class Options
    {
        private const string PathSection = "PATHS";
        private const string GeneralSection = "GENERAL";
        private const string PathToFeedKey = "PathToFeed";
        private const string UpdateIntervalKey = "UpdateInterval";

        private const int DefaultUpdateInterval = 30000;

        private string filePath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public Options(string filePath)
        {
            this.filePath = filePath;
        }

        private void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value.ToLower(), this.filePath);
        }

        private string Read(string section, string key)
        {
            StringBuilder SB = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, String.Empty, SB, 255, this.filePath);
            return SB.ToString();
        }

        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }

        public string PathToFeed;
        public int UpdateInterval = DefaultUpdateInterval;

        /// <summary>
        /// Reads options from INI file
        /// </summary>
        public void ReadOptions()
        {
            string str = string.Empty;

            // read paths section
            this.PathToFeed = Read(PathSection, PathToFeedKey);
            str = Read(GeneralSection, UpdateIntervalKey);
            
            if (string.Empty != str)
                this.UpdateInterval = Convert.ToInt32(str);
        }

        /// <summary>
        /// Writes options to INI file
        /// </summary>
        public void WriteOptions()
        {
            Write(PathSection, PathToFeedKey, this.PathToFeed);
            Write(GeneralSection, UpdateIntervalKey, this.UpdateInterval.ToString());
        }
    }
}

