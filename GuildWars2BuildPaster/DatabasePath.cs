using System;
using System.Windows;

namespace GuildWars2BuildPaster
{
    public partial class DatabasePath : Application
    {
        private static string databaseName = "Builds.db";
        private static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}