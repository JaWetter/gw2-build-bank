using System.Windows;

namespace GuildWars2BuildPaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Elementalist();
        }

        private void EleButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Elementalist();
        }

        private void EngiButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Engineer();
        }

        private void GuardButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Guardian();
        }

        private void MesButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Mesmer();
        }

        private void NecroButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Necromancer();
        }

        private void RanButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Ranger();
        }

        private void RevButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Revenant();
        }

        private void ThiefButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Thief();
        }

        private void WarrButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Warrior();
        }
    }
}