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
            tbtitle.Text = LanguagesLoadPage[32];
            BackButton.Text = LanguagesLoadPage[0];
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void Save0Button_Click(object sender, RoutedEventArgs e)
        {
            CreateSave();
            //Process.Start("F:/programming/HyperV/HyperV/HyperV/HyperV/bin/x86/Debug/HyperV.exe");
            Application.Current.Shutdown();
        }

        void CreateSave()
        {
            StreamWriter writer = new StreamWriter("../../Saves/save0.txt");

            writer.WriteLine("Level: 0");
            writer.WriteLine("World: Lobby");
            writer.WriteLine("Position: {X:0 Y:0 Z:0}");
            writer.WriteLine("Percentage: 0%");
            writer.WriteLine("Time Played: " + (new TimeSpan(0, 0, 0)).ToString());
            writer.Close();
        }

        private void Save1Button_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new GamePage());
        }

        private void Save2Button_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new GamePage());
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
