using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace Launching_Interface
{
   /// <summary>
   /// Interaction logic for LoadGamePage.xaml
   /// </summary>
   public partial class LoadGamePage : Page
   {
      List<string> LanguagesLoadPage { get; set; }
      List<string> ElementsToShowList { get; set; }


      public LoadGamePage()
      {
         Refresh();
      }

      void Refresh()
      {
         LanguagesLoadPage = new List<string>();
         ElementsToShowList = new List<string>();

         InitializeComponent();
         switch (GameDataManager.Language)
         {
            case GameDataManager.Languages.French:
               LanguagesLoadPage = GameDataManager.FrenchList;
               tbtitle.Margin = new Thickness(-40, 13, 42, 5);
               BackButton.Margin = new Thickness(28, 17, 113, 52);
               break;
            case GameDataManager.Languages.English:
               LanguagesLoadPage = GameDataManager.EnglishList;
               tbtitle.Margin = new Thickness(-30, 13, 49, 5);
               BackButton.Margin = new Thickness(28, 17, 113, 52);
               break;
            case GameDataManager.Languages.Spanish:
               LanguagesLoadPage = GameDataManager.SpanishList;
               tbtitle.Margin = new Thickness(-40, 13, 42, 5);
               BackButton.Margin = new Thickness(24, 17, 118, 52);
               break;
            case GameDataManager.Languages.Japanese:
               LanguagesLoadPage = GameDataManager.JapaneseList;
               tbtitle.Margin = new Thickness(-30, 13, 49, 5);
               BackButton.Margin = new Thickness(28, 17, 113, 52);
               break;

         }
         tbtitle.Text = LanguagesLoadPage[32];
         BackButton.Text = LanguagesLoadPage[0];
         PlaceContent();
      }

      private void PlaceContent()
      {
         for (int i = 0; i < 3; ++i)
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
               slotA.Text = LanguagesLoadPage[2];
               Level0.Text =LanguagesLoadPage[4] + " " + GameDataManager.NumLevelsCompleted(i) + "/" + GameDataManager.NumTotalLevels(i).ToString();
               Time0.Text = LanguagesLoadPage[3] + " " + ElementsToShowList[3];
               break;
            case 1:
               image1.Source = src;
               image1.Margin = new Thickness(30);
               slotB.Text = LanguagesLoadPage[5];
               Level1.Text = LanguagesLoadPage[4] + " " + GameDataManager.NumLevelsCompleted(i) + "/" + GameDataManager.NumTotalLevels(i).ToString();
               Time1.Text = LanguagesLoadPage[3] + " " + ElementsToShowList[3];
               break;
            case 2:
               image2.Source = src;
               image2.Margin = new Thickness(30);
               slotC.Text =LanguagesLoadPage[8];
               Level2.Text = LanguagesLoadPage[4] + " " + GameDataManager.NumLevelsCompleted(i) + "/" + GameDataManager.NumTotalLevels(i).ToString();
               Time2.Text = LanguagesLoadPage[3] + " " + ElementsToShowList[3];
               break;
         }


         OrganizeCharacteristicMargins();
         MakeTextRed(i);
      }

      void MakeTextRed(int i)
      {
         switch (i)
         {
            case 0:
               slotA.Foreground = Brushes.Red;
               Load0Button.BorderBrush = Brushes.Red;
               break;
            case 1:
               slotB.Foreground = Brushes.Red;
               Load1Button.BorderBrush = Brushes.Red;
               break;
            case 2:
               slotC.Foreground = Brushes.Red;
               Load2Button.BorderBrush = Brushes.Red;
               break;
         }
      }

      void ChangeBorderBrushColor(int i)
      {
         switch (i)
         {
            case 0:
               Load0Button.BorderBrush = Brushes.Black;//DarkBlue;
               break;
            case 1:
               Load1Button.BorderBrush = Brushes.Black;//DarkBlue;
               break;
            case 2:
               Load2Button.BorderBrush = Brushes.Black;//DarkBlue;
               break;
         }
      }


      void OrganizeCharacteristicMargins()
      {
         switch (GameDataManager.Language)
         {
            case GameDataManager.Languages.French:
               LanguagesLoadPage = GameDataManager.FrenchList;
               tbtitle.Margin = new Thickness(-38, 13, 43, 5);
               BackButton.Margin = new Thickness(36, 17, 105, 50);
               slotA.Margin = slotB.Margin = slotC.Margin = new Thickness(15, -11, 15, 10);
               Level0.Margin = Level1.Margin = Level2.Margin = new Thickness(5, -5, 5, 5);
               Time0.Margin = Time1.Margin = Time2.Margin = new Thickness(20, 0, 20, 0);

               break;
            case GameDataManager.Languages.English:
               LanguagesLoadPage = GameDataManager.EnglishList;
               tbtitle.Margin = new Thickness(-35, 13, 49, 5);
               BackButton.Margin = new Thickness(36, 17, 105, 50);
               slotA.Margin = slotB.Margin = slotC.Margin = new Thickness(33, -11, 33, 10);
               Level0.Margin = Level1.Margin = Level2.Margin = new Thickness(5, -5, 5, 5);
               Time0.Margin = Time1.Margin = Time2.Margin = new Thickness(20, 0, 20, 0);
               break;
            case GameDataManager.Languages.Spanish:
               LanguagesLoadPage = GameDataManager.SpanishList;
               tbtitle.Margin = new Thickness(-39, 13, 42, 5);
               BackButton.Margin = new Thickness(33, 17, 107, 52);
               slotA.Margin = slotB.Margin = slotC.Margin = new Thickness(27, -11, 27, 10);
               Level0.Margin = Level1.Margin = Level2.Margin = new Thickness(5, -5, 5, 5);
               Time0.Margin = Time1.Margin = Time2.Margin = new Thickness(20, 0, 20, 0);
               break;
            case GameDataManager.Languages.Japanese:
               LanguagesLoadPage = GameDataManager.JapaneseList;
               tbtitle.Margin = new Thickness(-41, 13, 53, 5);
               BackButton.Margin = new Thickness(36, 17, 105, 52);
               slotA.Margin = slotB.Margin = slotC.Margin = new Thickness(26, -11, 26, 10);
               Level0.Margin = Level1.Margin = Level2.Margin = new Thickness(14, -5, 14, 5);
               Time0.Margin = Time1.Margin = Time2.Margin = new Thickness(20, 0, 20, 0);
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
         ChangeBorderBrushColor(i);
         ResetButtons(i);
      }

      private void CreateImage(Grid l)
      {
         Create e = new Create();
         switch (GameDataManager.Language)
         {
            case GameDataManager.Languages.French:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/EmptyFR.png", UriKind.Relative));
               break;
            case GameDataManager.Languages.English:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/Empty.png", UriKind.Relative));
               break;
            case GameDataManager.Languages.Spanish:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/EmptyES.png", UriKind.Relative));
               break;
            case GameDataManager.Languages.Japanese:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/EmptyJA.png", UriKind.Relative));
               break;
         }
         e.Image.Margin = new Thickness(0, -90, 0, -350);
         l.Children.Add(e);
      }

      void ResetButtons(int i)
      {
         switch (i)
         {
            case 0:
               slotA.Text = Time0.Text = Level0.Text = "";
               break;
            case 1:
               slotB.Text = Time1.Text = Level1.Text = "";
               break;
            case 2:
               slotC.Text = Time2.Text = Level2.Text = "";
               break;
         }
      }

      //----------------------------------------------------------------------------------------------------------

      private void BackButton_Click(object sender, RoutedEventArgs e)
      {
         this.NavigationService.Navigate(new MainPage());
      }

      void DeleteSave(string saveNumber)
      {
         StreamWriter writer = new StreamWriter("../../Saves/save" + saveNumber + ".txt");
         writer.WriteLine();
         writer.Close();
         GameDataManager.RefreshSaves();
         image0.Source = null;
         image1.Source = null;
         image2.Source = null;
         Refresh();
      }

      private void Load1Button_Click(object sender, RoutedEventArgs e)
      {
         DeleteSave("0");
      }

      private void Load2Button_Click(object sender, RoutedEventArgs e)
      {
         DeleteSave("1");
      }

      private void Load3Button_Click(object sender, RoutedEventArgs e)
      {
         DeleteSave("2");
      }
   }
}
