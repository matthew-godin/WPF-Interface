﻿using System;
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
using System.Windows.Shapes;
using System.IO;
using System.Resources;
using System.Reflection;

namespace Launching_Interface
{

   /// <summary>
   /// Logic for InGameMenu
   /// </summary>
   public partial class InGameMenu : Page
   {
      bool IsFirstTime { get; set; }
      List<string> LanguagesList { get; set; }
      List<int> DataListToSend { get; set; }
      
      

      int LanguageIndex { get; set; }
      public InGameMenu()
      {


         IsFirstTime = true;
         LanguagesList = new List<string>();
         DataListToSend = new List<int>();

         AssociateDataToSend();

         InitializeComponent();

         GoodScreenshot();

         ManageFPS();
         GameDataManager.AAAA = true;
         ManageLanguages();
         ManageRenderDistance();
         ManageSound();

         ManageSettings();

      }

      void AssociateDataToSend()
      {

         if (GameDataManager.FirstFile == true)
         {
            DataListToSend.Add(GameDataManager.Language);
            DataListToSend.Add(GameDataManager.Fps);
            DataListToSend.Add(GameDataManager.RenderDistance);
            DataListToSend.Add(GameDataManager.MusicVolume);
            DataListToSend.Add(GameDataManager.SoundEffectVolume);
            DataListToSend.Add(GameDataManager.FullscreenMode);
            DataListToSend.Add(GameDataManager.KeyboardMode);
         }
         else
         {
            DataListToSend = GameDataManager.ListeInfosRecus;
            DataListToSend[0] = GameDataManager.Language;
            DataListToSend[1] = GameDataManager.Fps;
            DataListToSend[2] = GameDataManager.RenderDistance;
            DataListToSend[3] = GameDataManager.MusicVolume;
            DataListToSend[4] = GameDataManager.SoundEffectVolume;
            DataListToSend[5] = GameDataManager.FullscreenMode;
            DataListToSend[6] = GameDataManager.KeyboardMode;
         }
      }

      private void BackButton_Click(object sender, RoutedEventArgs e)
      {
         // this.NavigationService.Navigate(new MainPage());

         DataListToSend[0] = GameDataManager.Language;
         DataListToSend[1] = GameDataManager.Fps;
         DataListToSend[2] = GameDataManager.RenderDistance;
         DataListToSend[3] = GameDataManager.MusicVolume;
         DataListToSend[4] = GameDataManager.SoundEffectVolume;
         DataListToSend[5] = GameDataManager.FullscreenMode;
         DataListToSend[6] = GameDataManager.KeyboardMode;

         GameDataManager.ÉcrireFichier(DataListToSend);

         Application.Current.Shutdown();
      }



      private void MusicVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {

      }

      private void SoundVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {

      }

      private void RenderDistanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {

      }

      private void RDistanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // Render Distance
      {
         double value = 0;
         if (GameDataManager.AAAA == true)
         {
            GameDataManager.AAAA = false;
            switch (GameDataManager.RenderDistance)
            {
               case 10:
                  value = 0;
                  break;
               case 50:
                  value = 1.25;
                  break;
               case 100:
                  value = 2.5;
                  break;
               case 500:
                  value = 3.75;
                  break;
               case 1000:
                  value = 5;
                  break;
               case 5000:
                  value = 6.25;
                  break;
               case 10000:
                  value = 7.5;
                  break;
               case 50000:
                  value = 8.75;
                  break;
               case 100000:
                  value = 10;
                  break;
            }
         }
         else
         {
            var slider = sender as Slider;
            value = slider.Value;
         }

         if (value <= 5.2)
         {
            if (value >= 0 && value <= 0.1)
            {
               GameDataManager.RenderDistance = 10;
               RDistanceSlider.Value = 0;
            }
            if (value > 1.2 && value < 1.3)
            {
               GameDataManager.RenderDistance = 50;
               RDistanceSlider.Value = 1.25;
            }
            if (value > 2.4 && value < 2.6)
            {
               GameDataManager.RenderDistance = 100;
               RDistanceSlider.Value = 2.5;
            }
            if (value > 3.7 && value < 3.8)
            {
               GameDataManager.RenderDistance = 500;
               RDistanceSlider.Value = 3.75;
            }
            if (value > 4.9 && value < 5.1)
            {
               GameDataManager.RenderDistance = 1000;
               RDistanceSlider.Value = 5;
            }
         }
         else
         {
            if (value > 6.2 && value < 6.3)
            {
               GameDataManager.RenderDistance = 5000;
               RDistanceSlider.Value = 6.25;
            }
            if (value > 7.4 && value < 7.6)
            {
               GameDataManager.RenderDistance = 10000;
               RDistanceSlider.Value = 7.5;
            }
            if (value > 8.7 && value < 8.8)
            {
               GameDataManager.RenderDistance = 50000;
               RDistanceSlider.Value = 8.75;
            }
            if (value > 9.9 && value <= 10)
            {
               GameDataManager.RenderDistance = 100000;
               RDistanceSlider.Value = 10;
            }
         }
         rdvalue.Text = GameDataManager.RenderDistance.ToString();

      }
      private void PerformanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         var slider = sender as Slider;
         double value = slider.Value;

         if (value >= 0 && value <= 0.5)
         {
            GameDataManager.Fps = 30;
            PerformanceSlider.Value = 0;
         }
         else if (value > 3.2 && value < 3.4)
         {
            GameDataManager.Fps = 60;
            PerformanceSlider.Value = 3.333333;
         }
         else if (value > 6.5 && value < 6.7)
         {
            GameDataManager.Fps = 90;
            PerformanceSlider.Value = 6.66666;
         }
         else if (value < 10 && value > 9.9)
         {
            GameDataManager.Fps = 120;
            PerformanceSlider.Value = 10;
         }
         perfValue.Text = GameDataManager.Fps.ToString() + " FPS";
      }
      private void ButFull_Unchecked(object sender, RoutedEventArgs e)
      {
         GameDataManager.FullscreenMode = 0;
         if (GameDataManager.FullscreenMode == 0)
         {
            ButFull.Content = LanguagesList[30];
         }
         else if (GameDataManager.FullscreenMode == 1)
         {
            ButFull.Content = LanguagesList[29];
         }

         Application.Current.MainWindow.WindowState = WindowState.Normal;
         Application.Current.MainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
         Application.Current.MainWindow.ResizeMode = ResizeMode.CanResize;
      }
      private void ButFull_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.FullscreenMode = 1;
         GameDataManager.FirstFile = false;

         if (GameDataManager.FullscreenMode == 0)
         {
            ButFull.Content = LanguagesList[30];
         }
         else if (GameDataManager.FullscreenMode == 1)
         {
            ButFull.Content = LanguagesList[29];
         }

         if(IsFirstTime == true)
         {
            IsFirstTime = false;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.WindowStyle = WindowStyle.None;
            Application.Current.MainWindow.ResizeMode = ResizeMode.NoResize;
         }
         else
         {
            Application.Current.MainWindow.WindowStyle = WindowStyle.None;
            Application.Current.MainWindow.ResizeMode = ResizeMode.NoResize;
            Application.Current.MainWindow.Left = 0;
            Application.Current.MainWindow.Top = 0;
            Application.Current.MainWindow.Width = SystemParameters.VirtualScreenWidth;
            Application.Current.MainWindow.Height = SystemParameters.VirtualScreenHeight;
            Application.Current.MainWindow.Topmost = true;
         }
      }
      private void ButCont_Unchecked(object sender, RoutedEventArgs e)
      {
         GameDataManager.KeyboardMode = 1;
         
         ManageSettings();
      }
      private void ButCont_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.KeyboardMode = 0;
         GameDataManager.FirstFile = false;
         ManageSettings();
      }

      // Languages
      #region 

      private void RBes_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 2;
         LanguagesList = GameDataManager.SpanishList;
         GameDataManager.FirstFile = false;
         ManageSettings();
      }
      private void RBjp_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 3;
         LanguagesList = GameDataManager.JapaneseList;
         GameDataManager.FirstFile = false;
         ManageSettings();
      }
      private void RBfr_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 0;
         LanguagesList = GameDataManager.FrenchList;
         ManageSettings();
      }
      private void RBan_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 1;
         LanguagesList = GameDataManager.EnglishList;
         GameDataManager.FirstFile = false;
         ManageSettings();
      }

      void ManageSettings()
      {

         Lang.Text = LanguagesList[31];

         RBan.Content = LanguagesList[15];
         RBfr.Content = LanguagesList[14];
         RBes.Content = LanguagesList[16];
         RBjp.Content = LanguagesList[17];

         SEff.Text = LanguagesList[13];
         GMus.Text = LanguagesList[12];

         TitleSett.Text = LanguagesList[35];
         Backtext.Text = LanguagesList[0];
         Resettext2.Text = LanguagesList[33];

         RenD.Text = LanguagesList[18];
         Perfo.Text = LanguagesList[19];
         Inp.Text = LanguagesList[21];
         Full.Text = LanguagesList[20];

         saveText.Text = LanguagesList[37];
         if (GameDataManager.Language == 0) { saveText.Margin = new Thickness(29, 60, 118, 48); }
         else { saveText.Margin = new Thickness(40,64,118,48); }

         menuText.Text = LanguagesList[36];

         if (GameDataManager.FullscreenMode == 1)
         {
            ButFull.Content = LanguagesList[29];
            ButFull.IsChecked = true;
         }
         else if (GameDataManager.FullscreenMode == 0)
         {
            ButFull.Content = LanguagesList[30];
            ButFull.IsChecked = false;
         }

         if (GameDataManager.KeyboardMode == 1)
         {
            ButCont.Content = LanguagesList[23];
            ImageInstructions.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/keyboard.png", UriKind.Relative));
            ButCont.IsChecked = false;
         }
         else if (GameDataManager.KeyboardMode == 0)
         {
            ButCont.Content = LanguagesList[22];
            ImageInstructions.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/Controller2Sides.png", UriKind.Relative));
            ButCont.IsChecked = true;
         }
      }

      void ManageLanguages()
      {
         if (GameDataManager.Language == 0)
         {
            LanguagesList = GameDataManager.FrenchList;
            RBfr.IsChecked = true;
            RBan.IsChecked = false;
            RBes.IsChecked = false;
            RBjp.IsChecked = false;
         }
         if (GameDataManager.Language == 1)
         {
            LanguagesList = GameDataManager.EnglishList;
            RBfr.IsChecked = false;
            RBan.IsChecked = true;
            RBes.IsChecked = false;
            RBjp.IsChecked = false;
         }
         if (GameDataManager.Language == 2)
         {
            LanguagesList = GameDataManager.SpanishList;
            RBfr.IsChecked = false;
            RBan.IsChecked = false;
            RBes.IsChecked = true;
            RBjp.IsChecked = false;
         }
         if (GameDataManager.Language == 3)
         {
            LanguagesList = GameDataManager.JapaneseList;
            RBfr.IsChecked = false;
            RBan.IsChecked = false;
            RBes.IsChecked = false;
            RBjp.IsChecked = true;
         }
      }
      //on s'en fou de ces trois la
      private void musicvalue_TextChanged(object sender, TextChangedEventArgs e)
      {

      }
      private void TitleSett_TextChanged(object sender, TextChangedEventArgs e)
      {

      }
      private void perfovalue_TextChanged(object sender, TextChangedEventArgs e)
      {

      }

      #endregion

      void ManageFPS()
      {
         if (GameDataManager.Fps == 30)
         {
            PerformanceSlider.Value = 0;
         }
         if (GameDataManager.Fps == 60)
         {
            PerformanceSlider.Value = 3.333333;
         }
         if (GameDataManager.Fps == 90)
         {
            PerformanceSlider.Value = 6.666666;
         }
         if (GameDataManager.Fps == 120)
         {
            PerformanceSlider.Value = 10;
         }
         if (PerformanceSlider.Value < 0.2) { perfValue.Text = "30 FPS"; }  // temporaire
      }
      void ManageRenderDistance()
      {
         int a = 500;
         if (GameDataManager.RenderDistance == 10) { a = 10; }
         if (GameDataManager.RenderDistance == 50) { a = 50; }
         if (GameDataManager.RenderDistance == 100) { a = 100; }
         if (GameDataManager.RenderDistance == 500) { a = 500; }
         if (GameDataManager.RenderDistance == 1000) { a = 1000; }
         if (GameDataManager.RenderDistance == 5000) { a = 5000; }
         if (GameDataManager.RenderDistance == 10000) { a = 10000; }
         if (GameDataManager.RenderDistance == 50000) { a = 50000; }
         if (GameDataManager.RenderDistance == 100000) { a = 100000; }
         RDistanceSlider.Value = a;
         GameDataManager.RenderDistance = a;
      }

      private void GameMusicSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         var slider = sender as Slider;
         double value = slider.Value;
         GameDataManager.MusicVolume = (int)Math.Round(value, 0);
         musicvalue.Text = GameDataManager.MusicVolume.ToString();
      }

      private void SoundEffectsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         var slider = sender as Slider;
         double value = slider.Value;
         GameDataManager.SoundEffectVolume = (int)Math.Round(value, 0);
         soundvalue.Text = GameDataManager.SoundEffectVolume.ToString();
      }

      private void ResetButton_Click(object sender, RoutedEventArgs e)
      {
         GameDataManager.FirstFile = true;
         GameDataManager.AAAA = true;
         GameDataManager.BasicSettings();
         ManageSettings();
         ManageFPS();
         ManageRenderDistance();
         ManageLanguages();
         ManageSound();

      }

      private void rdvalue_TextChanged(object sender, TextChangedEventArgs e)
      {

      }

      void ManageSound()
      {
         GameMusicSlider.Value = GameDataManager.MusicVolume;
         SoundEffectsSlider.Value = GameDataManager.SoundEffectVolume;
      }

      private void MenuButton_Click(object sender, RoutedEventArgs e)
      {
         StreamWriter writer = new StreamWriter("../../Saves/save.txt");
         writer.WriteLine();
         writer.WriteLine("false");
         this.NavigationService.Navigate(new MainPage());
      }

      void GoodScreenshot()
      {
         string nameImage = "";

         StreamReader dataReader = new StreamReader("../../Saves/save.txt");
         switch (dataReader.ReadLine())
         {
               case "0":
                  nameImage = "screenshot0.png";
                  break;
               case "1":
                  nameImage = "screenshot1.png";
                  break;
               case "2":
                  nameImage = "screenshot2.png";
                  break;
         }
         dataReader.Close();
            //ImageFond.Source = new BitmapImage(new Uri(@"Pictures/SavesScreenshots/save0.bmp", UriKind.Relative));
            //ImageFond.Source = new BitmapImage(new Uri(@"../../Saves/" + nameImage, UriKind.Relative));

            //ImageFond = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(@"../../Saves/" + nameImage, UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            ImageFond.Source = src;

            //BitmapImage src = new BitmapImage(new Uri(@"Saves/" + nameImage, UriKind.Relative));
            //src.CacheOption = BitmapCacheOption.OnLoad;
            //ImageFond.Source = src;
        }

      private void saveButton_Click(object sender, RoutedEventArgs e)
      {

      }
   }
}
