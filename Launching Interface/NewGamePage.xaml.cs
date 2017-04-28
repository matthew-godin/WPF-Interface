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
using System.Windows.Markup;

namespace Launching_Interface
{
   /// <summary>
   /// Interaction logic for NewGamePage.xaml
   /// </summary>
   public partial class NewGamePage : Page
   {

      List<string> LanguageNewPage { get; set; }
      List<string> ElementsToShowList { get; set; }

      public NewGamePage()
      {
         LanguageNewPage = new List<string>();
         ElementsToShowList  = new List<string>();

         InitializeComponent();

         switch (GameDataManager.Language)
         {
            case 0:
               LanguageNewPage = GameDataManager.FrenchList;
               tbtitle.Margin = new Thickness(-40, 13, 42, 5);
               BackButton.Margin = new Thickness(28, 17, 113, 52);
               break;
            case 1:
               LanguageNewPage = GameDataManager.EnglishList;
               tbtitle.Margin = new Thickness(-30, 13, 49, 5);
               BackButton.Margin = new Thickness(28, 17, 113, 52);
               break;
            case 2:
               LanguageNewPage = GameDataManager.SpanishList;
               tbtitle.Margin = new Thickness(-40, 13, 42, 5);
               BackButton.Margin = new Thickness(24, 17, 118, 52);
               break;
            case 3:
               LanguageNewPage = GameDataManager.JapaneseList;
               tbtitle.Margin = new Thickness(-30, 13, 49, 5);
               BackButton.Margin = new Thickness(28, 17, 113, 52);
               break;

         }
         tbtitle.Text = LanguageNewPage[1];
         BackButton.Text = LanguageNewPage[0];
      //   CheckForExistingGames();
         PlaceContent();
      }

      private void PlaceContent()
      {
         for (int i = 0; i < 3; ++i)
         {
            PlaceButtonsContent(i);
         }
         
      }

      private void PlaceButtonsContent(int i)
      {
         if (GameDataManager.GameExists[i])
         {
            PlaceRows(i);
         }
         else
         {
            PlaceCreateImage(i);
         }
      }

      private void PlaceRows(int i)
      {
         switch (i)
         {
            case 0:
               CreateRows(i);
               break;
            case 1:
               CreateRows(i);
               break;
            case 2:
               CreateRows(i);
               break;
         }
      }

      private void CreateRows(int i)
      {
         BitmapImage src = new BitmapImage();
         src.BeginInit();
         src.UriSource = new Uri(@"../../Saves/screenshot" + i + ".png", UriKind.Relative);
         src.CacheOption = BitmapCacheOption.OnLoad;
         src.EndInit();
      
         ReadNewGameInformation(i);

         switch (i)
         {
            case 0:
               image0.Source = src;
               image0.Margin = new Thickness(30);
               slotA.Text = ÉlementFichiersLanguages(2);
               Level0.Text= ÉlementFichiersLanguages(4) + " " + ElementsToShowList[0]+ "/" + GameDataManager.NBRE_NIVEAUX.ToString();
               Time0.Text = ÉlementFichiersLanguages(3) + " " + ElementsToShowList[3];     
               break;
            case 1:
               image1.Source = src;
               image1.Margin = new Thickness(30);
               slotB.Text = ÉlementFichiersLanguages(5);
               Level1.Text= ÉlementFichiersLanguages(4) + " " + ElementsToShowList[0] + "/" + GameDataManager.NBRE_NIVEAUX.ToString();
               Time1.Text = ÉlementFichiersLanguages(3) + " " + ElementsToShowList[3];
               break;
            case 2:
               image2.Source = src;
               image2.Margin = new Thickness(30);
               slotC.Text = ÉlementFichiersLanguages(8);
               Level2.Text= ÉlementFichiersLanguages(4) + " " + ElementsToShowList[0] + "/" + GameDataManager.NBRE_NIVEAUX.ToString();
               Time2.Text = ÉlementFichiersLanguages(3) + " " + ElementsToShowList[3];
               break;
         }

         OrganizeCharacteristicMargins();
         RendreBoutonsBleus(i);
      }

      string ÉlementFichiersLanguages(int i)
      {
         return LanguageNewPage[i].Replace("\n", string.Empty);
      }

      void OrganizeCharacteristicMargins()
      {
         Thickness margesSave =new Thickness( 0);
         Thickness margesLevel = new Thickness(0);

         if (GameDataManager.Language != 0)
         {
            margesSave = new Thickness(20, 0, 20, 0);
         }
         slotA.Margin = margesSave;
         slotB.Margin = margesSave;
         slotC.Margin = margesSave;

      
         if (GameDataManager.Language ==3)
         {
            margesLevel = new Thickness(10, 0, 10, 0);
         }
         Level0.Margin = margesLevel;
         Level1.Margin = margesLevel;
         Level2.Margin = margesLevel;


      }

      void RendreBoutonsBleus(int i)
      {
         switch (i)
         {
            case 0:
               Save0Button.BorderBrush = Brushes.DarkBlue;
               break;
            case 1:    
               Save1Button.BorderBrush = Brushes.DarkBlue;
               break;
            case 2:
               Save2Button.BorderBrush = Brushes.DarkBlue;
               break;
         }


      }

      void ReadNewGameInformation(int i)
      {
         switch (i)
         {
            case 0:
               ElementsToShowList = GameDataManager.CharacteristicsToDisplayList0;
               break;
            case 1:
               ElementsToShowList = GameDataManager.CharacteristicsToDisplayList1;
               break;
            case 2:
               ElementsToShowList = GameDataManager.CharacteristicsToDisplayList2;
               break;
          }
          

      }

      private void PlaceCreateImage(int i)
      {
         switch (i)
         {
            case 0:
               CreateImage(Load0);
               break;
            case 1:
               CreateImage(Load1);
               break;
            case 2:
               CreateImage(Load2);
               break;
         }
         ResetButtons(i);
      }

      private void CreateImage(Grid l)
      {
         Create e = new Create();
         switch (GameDataManager.Language)
         {
            case 0:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/CreateFR.png", UriKind.Relative));
               break;
            case 1:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/Create.png", UriKind.Relative));
               break;
            case 2:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/CreateES.png", UriKind.Relative));
               break;
            case 3:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/CreateJA.png", UriKind.Relative));
               break;
         }
         e.Image.Margin = new Thickness(0, -90, 0, -350);
         l.Children.Add(e);
      }

      //void CheckForExistingGames()
      //{
      //   StreamReader r;

      //   GameDataManager.GameExists = new bool[3];
      //   for (int i = 0; i < 3; ++i)
      //   {
      //      r = new StreamReader("../../Saves/save" + i + ".txt");
      //     GameDataManager. GameExists[i] = r.ReadLine() != "";
      //      r.Close();
      //   }
      //}

      void BackButton_Click(object sender, RoutedEventArgs e)
      {
         this.NavigationService.Navigate(new MainPage());
      }

      void Save0Button_Click(object sender, RoutedEventArgs e)
      {
         if (!GameDataManager.GameExists[0])
         {
            CreateSave("0");
         }
         LoadSave("0");
      }

      void LoadSave(string saveNumber)
      {
         ManagePause(saveNumber);
         //string path = "F:/programming/HyperV/HyperV/HyperV/HyperV/bin/x86/Debug/HyperV.exe";
         //string path = "C:/Users/Matthew/Source/Repos/HyperV/HyperV/HyperV/bin/x86/Debug/HyperV.exe";
         string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"../../../../bin/x86/Debug/HyperV.exe");
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
         File.Copy("../../Saves/startscreenshot.png", "../../Saves/screenshot" + saveNumber + ".png", true);
      }

      void ManagePause(string saveNumber)
      {
         StreamWriter writer = new StreamWriter("../../Saves/save.txt");
         writer.WriteLine(saveNumber);
         writer.WriteLine("true");
         writer.Close();
      }

      void Save1Button_Click(object sender, RoutedEventArgs e)
      {
         if (!GameDataManager.GameExists[1])
         {
            CreateSave("1");
         }
         LoadSave("1");
      }

      void Save2Button_Click(object sender, RoutedEventArgs e)
      {
         if (!GameDataManager.GameExists[2])
         {
            CreateSave("2");
         }
         LoadSave("2");
      }

      void ResetButtons(int i)
      {
         switch (i)
         {
            case 0:
               slotA.Text = "";
               Time0.Text = "";
               Level0.Text = "";
               break;
            case 1:
               slotB.Text = "";
               Time1.Text = "";
               Level1.Text = "";
               break;
            case 2:
               slotC.Text = "";
               Time2.Text = "";
               Level2.Text = "";
               break;
         }
      }

   }
}
