﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.IO;

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
         ElementsToShowList = new List<string>();

         InitializeComponent();

         switch (GameDataManager.Language)
         {
            case GameDataManager.Languages.French:
               LanguageNewPage = GameDataManager.FrenchList;
               tbtitle.Margin = new Thickness(-40, 13, 42, 5);
               BackButton.Margin = new Thickness(28, 17, 113, 52);
               break;
            case GameDataManager.Languages.English:
               LanguageNewPage = GameDataManager.EnglishList;
               tbtitle.Margin = new Thickness(-30, 13, 49, 5);
               BackButton.Margin = new Thickness(28, 17, 113, 52);
               break;
            case GameDataManager.Languages.Spanish:
               LanguageNewPage = GameDataManager.SpanishList;
               tbtitle.Margin = new Thickness(-40, 13, 42, 5);
               BackButton.Margin = new Thickness(24, 17, 118, 52);
               break;
            case GameDataManager.Languages.Japanese:
               LanguageNewPage = GameDataManager.JapaneseList;
               tbtitle.Margin = new Thickness(-30, 13, 49, 5);
               BackButton.Margin = new Thickness(28, 17, 113, 52);
               break;

         }
         tbtitle.Text = LanguageNewPage[1];
         BackButton.Text = LanguageNewPage[0];
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
               slotA.Text = LanguageNewPage[2];
               Level0.Text = LanguageNewPage[4] + " " + GameDataManager.NumLevelsCompleted(i) + "/" + GameDataManager.NumTotalLevels(i).ToString();
               Time0.Text = LanguageNewPage[3] + " " + ElementsToShowList[3];
               break;
            case 1:
               image1.Source = src;
               image1.Margin = new Thickness(30);
               slotB.Text = LanguageNewPage[5];
               Level1.Text = LanguageNewPage[4] + " " + GameDataManager.NumLevelsCompleted(i) + "/" + GameDataManager.NumTotalLevels(i).ToString();
               Time1.Text = LanguageNewPage[3] + " " + ElementsToShowList[3];
               break;
            case 2:
               image2.Source = src;
               image2.Margin = new Thickness(30);
               slotC.Text = LanguageNewPage[8];
               Level2.Text = LanguageNewPage[4] + " " + GameDataManager.NumLevelsCompleted(i) + "/" + GameDataManager.NumTotalLevels(i).ToString();
               Time2.Text = LanguageNewPage[3] + " " + ElementsToShowList[3];
               break;
         }

         OrganizeCharacteristicMargins();
         ChangeBorderBrushColor(i);
      }



      void OrganizeCharacteristicMargins()
      {
         switch (GameDataManager.Language)
         {
            case GameDataManager.Languages.French:
               LanguageNewPage = GameDataManager.FrenchList;
               tbtitle.Margin = new Thickness(-38, 13, 43, 5);
               BackButton.Margin = new Thickness(36, 17, 105, 50);
               slotA.Margin = slotB.Margin = slotC.Margin = new Thickness(15, -11, 15, 10);
               Level0.Margin = Level1.Margin = Level2.Margin = new Thickness(5, -5, 5, 5);
               Time0.Margin = Time1.Margin = Time2.Margin = new Thickness(20, 0, 20, 0);

               break;
            case GameDataManager.Languages.English:
               LanguageNewPage = GameDataManager.EnglishList;
               tbtitle.Margin = new Thickness(-35, 13, 49, 5);
               BackButton.Margin = new Thickness(36, 17, 105, 50);
               slotA.Margin = slotB.Margin = slotC.Margin = new Thickness(33, -11, 33, 10);
               Level0.Margin = Level1.Margin = Level2.Margin = new Thickness(5, -5, 5, 5);
               Time0.Margin = Time1.Margin = Time2.Margin = new Thickness(20, 0, 20, 0);
               break;
            case GameDataManager.Languages.Spanish:
               LanguageNewPage = GameDataManager.SpanishList;
               tbtitle.Margin = new Thickness(-39, 13, 42, 5);
               BackButton.Margin = new Thickness(33, 17, 107, 52);
               slotA.Margin = slotB.Margin = slotC.Margin = new Thickness(27, -11, 27, 10);
               Level0.Margin = Level1.Margin = Level2.Margin = new Thickness(5, -5, 5, 5);
               Time0.Margin = Time1.Margin = Time2.Margin = new Thickness(20, 0, 20, 0);
               break;
            case GameDataManager.Languages.Japanese:
               LanguageNewPage = GameDataManager.JapaneseList;
               tbtitle.Margin = new Thickness(-41, 13, 53, 5);
               BackButton.Margin = new Thickness(36, 17, 105, 52);
               slotA.Margin = slotB.Margin = slotC.Margin = new Thickness(26, -11, 26, 10);
               Level0.Margin = Level1.Margin = Level2.Margin = new Thickness(14, -5, 14, 5);
               Time0.Margin = Time1.Margin = Time2.Margin = new Thickness(20, 0, 20, 0);
               break;

         }
      }

      void ChangeBorderBrushColor(int i)
      {
         switch (i)
         {
            case 0:
               Save0Button.BorderBrush = Brushes.Black;//DarkBlue;
               break;
            case 1:
               Save1Button.BorderBrush = Brushes.Black;//DarkBlue;
               break;
            case 2:
               Save2Button.BorderBrush = Brushes.Black;//DarkBlue;
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
               CreateImage(Save0);
               break;
            case 1:
               CreateImage(Save1);
               break;
            case 2:
               CreateImage(Save2);
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
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/CreateFR.png", UriKind.Relative));
               break;
            case GameDataManager.Languages.English:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/Create.png", UriKind.Relative));
               break;
            case GameDataManager.Languages.Spanish:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/CreateES.png", UriKind.Relative));
               break;
            case GameDataManager.Languages.Japanese:
               e.Image.Source = new BitmapImage(new Uri(@"/Pictures/CreateJA.png", UriKind.Relative));
               break;
         }
         e.Image.Margin = new Thickness(0, -90, 0, -350);
         l.Children.Add(e);
      }

      void BackButton_Click(object sender, RoutedEventArgs e)
      {
         NavigationService.Navigate(new MainPage());
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

      }

      void CreateSave(string saveNumber)
      {
         StreamWriter writer = new StreamWriter("../../Saves/save" + saveNumber + ".txt");

         writer.WriteLine("Level: 0");
         writer.WriteLine("Position: {X:5 Y:5 Z:5}");
         writer.WriteLine("Direction: {X:5 Y:5 Z:5}");
         writer.WriteLine("Time Played: " + (new TimeSpan(0, 0, 0)).ToString());
         writer.WriteLine("Max Life: 300");
         writer.WriteLine("Attack: 0");
         writer.WriteLine("false;false;false;false;false;false;false;false");
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
