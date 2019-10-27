using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GuildWars2BuildPaster
{
    /// <summary>
    /// Interaction logic for Warrior.xaml
    /// </summary>
    public partial class Warrior : Page
    {
        private List<Build> builds;

        public Warrior()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void ReadDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabasePath.databasePath))
            {
                conn.CreateTable<Build>();

                builds = (conn.Table<Build>().ToList()).Where(v => v.Profession.Equals("Warrior")).ToList();
            }

            if (builds != null)
            {
                lv_builds.ItemsSource = builds;
            }
        }

        private void lv_builds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Build copy = (Build)lv_builds.SelectedItem;

            if (copy != null)
            {
                Clipboard.SetText(copy.Code);
            }
        }

        private void NewBuildName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NewBuildName.Text == "Build Name")
            {
                NewBuildName.Text = "";

                NewBuildName.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void NewBuildName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NewBuildName.Text == "")
            {
                NewBuildName.Text = "Build Name";

                NewBuildName.Foreground = new SolidColorBrush(Colors.Silver);
            }
        }

        private void NewBuildCode_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NewBuildCode.Text == "[Build Code]")
            {
                NewBuildCode.Text = "";

                NewBuildCode.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void NewBuildCode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NewBuildCode.Text == "")
            {
                NewBuildCode.Text = "[Build Code]";

                NewBuildCode.Foreground = new SolidColorBrush(Colors.Silver);
            }
        }

        private void AcceptNewBuild(object sender, RoutedEventArgs e)
        {
            var nameReg = new Regex("^$");
            var nameReg2 = new Regex(@"Build Name");
            var codeReg = new Regex(@"\[[\s\S]*?\]");
            var codeReg2 = new Regex(@"\[Build Code\]");

            if (nameReg.IsMatch(NewBuildName.Text) || nameReg2.IsMatch(NewBuildName.Text))
            {
                MessageBox.Show("      Please enter a name for your build\n\n");
            }
            else if (!codeReg.IsMatch(NewBuildCode.Text) || codeReg2.IsMatch(NewBuildCode.Text))
            {
                MessageBox.Show("       Please enter valid build code\n\n");
            }
            else
            {
                Build build = new Build()
                {
                    Name = NewBuildName.Text,
                    Code = NewBuildCode.Text,
                    Profession = "Warrior",
                    Specialization = NewBuildSpe.Text
                };

                using (SQLiteConnection connection = new SQLiteConnection(DatabasePath.databasePath))
                {
                    connection.CreateTable<Build>();
                    connection.Insert(build);
                }
            }
            NewBuildName.Text = "Build Name";
            NewBuildName.Foreground = new SolidColorBrush(Colors.Silver);
            NewBuildCode.Text = @"[Build Code]";
            NewBuildCode.Foreground = new SolidColorBrush(Colors.Silver);

            ReadDatabase();
        }

        private void DeleteBuild_Click(object sender, RoutedEventArgs e)
        {
            Build build = (Build)lv_builds.SelectedItem;

            if (MessageBox.Show("Are you sure you want to delete: " + build.Name + "?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
            }
            else
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabasePath.databasePath))
                {
                    conn.Delete((Build)lv_builds.SelectedItem);

                    ReadDatabase();
                }
            }
        }
    }
}