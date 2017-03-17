using System;
using System.Collections.Generic;
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
using System.Diagnostics;
using System.IO;

namespace Launching_Interface
{
    /// <summary>
    /// Interaction logic for NewGamePage.xaml
    /// </summary>
    public partial class NewGamePage : Page
    {
        List<string> LanguagesLoadPage { get; set; }
        public NewGamePage()
        {
            LanguagesLoadPage = new List<string>();
            InitializeComponent();
            if (GameDataManager.Language == 0) { LanguagesLoadPage = GameDataManager.FrenchList; }
            if (GameDataManager.Language == 1) { LanguagesLoadPage = GameDataManager.EnglishList; }
            if (GameDataManager.Language == 2) { LanguagesLoadPage = GameDataManager.SpanishList; }
            if (GameDataManager.Language == 3) { LanguagesLoadPage = GameDataManager.JapaneseList; }
            tbtitle.Text = LanguagesLoadPage[1];
            BackButton.Text = LanguagesLoadPage[0];
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void Save0Button_Click(object sender, RoutedEventArgs e)
        {
            CreateSave("0");
            //string path = "F:/programming/HyperV/HyperV/HyperV/HyperV/bin/x86/Debug/HyperV.exe";
            string path = "C:/Users/Matthew/Source/Repos/HyperV/HyperV/HyperV/bin/x86/Debug/HyperV.exe";
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = path;
            p.WorkingDirectory = System.IO.Path.GetDirectoryName(path);
            Process.Start(p);
            Application.Current.Shutdown();
            //Application.Current.MainWindow.Visibility = Visibility.Collapsed;
            //Application.Current.MainWindow.ShowInTaskbar = false;
            //this.NavigationService.Navigate(new InGameMenu());
        }

        void CreateSave(string saveNumber)
        {
            StreamWriter writer = new StreamWriter("../../Saves/save" + saveNumber + ".txt");

            writer.WriteLine("Level: 0");
            writer.WriteLine("Position: {X:5 Y:5 Z:5}");
            writer.WriteLine("Direction: {X:5 Y:5 Z:5}");
            //writer.WriteLine("Language: " + GameDataManager.Language);
            //writer.WriteLine("World: Lobby");
            //writer.WriteLine("Percentage: 0%");
            writer.WriteLine("Time Played: " + (new TimeSpan(0, 0, 0)).ToString());
            writer.Close();
            writer = new StreamWriter("../../Saves/save.txt");
         writer.WriteLine(saveNumber);
         writer.WriteLine("true");
            writer.Close();
        }

        private void Save1Button_Click(object sender, RoutedEventArgs e)
        {
            CreateSave("1");
            //string path = "F:/programming/HyperV/HyperV/HyperV/HyperV/bin/x86/Debug/HyperV.exe";
            string path = "C:/Users/Matthew/Source/Repos/HyperV/HyperV/HyperV/bin/x86/Debug/HyperV.exe";
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = path;
            p.WorkingDirectory = System.IO.Path.GetDirectoryName(path);
            Process.Start(p);
            Application.Current.Shutdown();
        }

        private void Save2Button_Click(object sender, RoutedEventArgs e)
        {
            CreateSave("2");
            //string path = "F:/programming/HyperV/HyperV/HyperV/HyperV/bin/x86/Debug/HyperV.exe";
            string path = "C:/Users/Matthew/Source/Repos/HyperV/HyperV/HyperV/bin/x86/Debug/HyperV.exe";
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = path;
            p.WorkingDirectory = System.IO.Path.GetDirectoryName(path);
            Process.Start(p);
            Application.Current.Shutdown();
        }

        private void Create0_Loaded(object sender, RoutedEventArgs e)
        {
            if (GameDataManager.Language == 0)
            {
                Create0.Source = new BitmapImage(new Uri(@"/Pictures/CreateFR.png", UriKind.Relative));
            }
            else if (GameDataManager.Language == 1)
            {
                Create0.Source = new BitmapImage(new Uri(@"/Pictures/Create.png", UriKind.Relative));
            }
            else if (GameDataManager.Language == 2)
            {
                Create0.Source = new BitmapImage(new Uri(@"/Pictures/CreateES.png", UriKind.Relative));
            }
            else if (GameDataManager.Language == 3)
            {
                Create0.Source = new BitmapImage(new Uri(@"/Pictures/CreateJA.png", UriKind.Relative));
            }
        }

        private void Create1_Loaded(object sender, RoutedEventArgs e)
        {
            if (GameDataManager.Language == 0)
            {
                Create1.Source = new BitmapImage(new Uri(@"/Pictures/CreateFR.png", UriKind.Relative));
            }
            else if (GameDataManager.Language == 1)
            {
                Create1.Source = new BitmapImage(new Uri(@"/Pictures/Create.png", UriKind.Relative));
            }
            else if (GameDataManager.Language == 2)
            {
                Create1.Source = new BitmapImage(new Uri(@"/Pictures/CreateES.png", UriKind.Relative));
            }
            else if (GameDataManager.Language == 3)
            {
                Create1.Source = new BitmapImage(new Uri(@"/Pictures/CreateJA.png", UriKind.Relative));
            }
        }

        private void Create2_Loaded(object sender, RoutedEventArgs e)
        {
            if (GameDataManager.Language == 0)
            {
                Create2.Source = new BitmapImage(new Uri(@"/Pictures/CreateFR.png", UriKind.Relative));
            }
            else if (GameDataManager.Language == 1)
            {
                Create2.Source = new BitmapImage(new Uri(@"/Pictures/Create.png", UriKind.Relative));
            }
            else if (GameDataManager.Language == 2)
            {
                Create2.Source = new BitmapImage(new Uri(@"/Pictures/CreateES.png", UriKind.Relative));
            }
            else if (GameDataManager.Language == 3)
            {
                Create2.Source = new BitmapImage(new Uri(@"/Pictures/CreateJA.png", UriKind.Relative));
            }
        }
    }
}
