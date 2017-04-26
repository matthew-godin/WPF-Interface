using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace Launching_Interface
{
   //enum Language
   //{
   //    French, English, Spanish, Japanese
   //}

   //enum Input
   //{
   //    Controller, Keyboard
   //}

   /// <summary>
   /// Interaction logic for SettingsPage.xaml
   /// </summary>
   public partial class SettingsPage : Page
   {
      List<string> LanguagesList { get; set; }

      public SettingsPage()
      {
         LanguagesList = new List<string>();

         InitializeComponent();
         ManageFPS();
         GameDataManager.RD = true;
         ManageLanguages();
         ManageRenderDistance();
         ManageSound();
         ManageButtons();
         ManageSettings();
         
      }

      public void BackButton_Click(object sender, RoutedEventArgs e)
      {
         SaveSettings();
         this.NavigationService.Navigate(new MainPage());
      }

      private void SaveSettings()
      {
         StreamWriter w = new StreamWriter("../../Saves/Settings.txt");

         w.WriteLine("Music: " + GameDataManager.MusicVolume.ToString());
         w.WriteLine("Sound: " + GameDataManager.SoundEffectVolume.ToString());
         w.WriteLine("Language: " + GameDataManager.Language.ToString());
         w.WriteLine("Render Distance: " + GameDataManager.RenderDistance.ToString());
         w.WriteLine("Frame Rate: " + GameDataManager.Fps.ToString());
         w.WriteLine("Fullscreen: " + GameDataManager.FullscreenMode.ToString());
         w.WriteLine("Input: " + GameDataManager.KeyboardMode.ToString());
         w.Close();
      }
  
      private void RDistanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) 
      {
         double value = 0;
         if (GameDataManager.RD == true)
         {
            GameDataManager.RD = false;
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
            else if (value > 1.2 && value < 1.3)
            {
               GameDataManager.RenderDistance = 50;
               RDistanceSlider.Value = 1.25;
            }
            else if (value > 2.4 && value < 2.6)
            {
               GameDataManager.RenderDistance = 100;
               RDistanceSlider.Value = 2.5;
            }
           else  if (value > 3.7 && value < 3.8)
            {
               GameDataManager.RenderDistance = 500;
               RDistanceSlider.Value = 3.75;
            }
           else  if (value > 4.9 && value < 5.1)
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
            else if (value > 7.4 && value < 7.6)
            {
               GameDataManager.RenderDistance = 10000;
               RDistanceSlider.Value = 7.5;
            }
            else if (value > 8.7 && value < 8.8)
            {
               GameDataManager.RenderDistance = 50000;
               RDistanceSlider.Value = 8.75;
            }
            else if (value > 9.9 && value <= 10)
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
         ManageButtons();

         Application.Current.MainWindow.WindowState = WindowState.Normal;
         Application.Current.MainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
         Application.Current.MainWindow.ResizeMode = ResizeMode.CanResize;
      }

      private void ButFull_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.FullscreenMode = 1;
         ManageButtons();

         Application.Current.MainWindow.WindowStyle = WindowStyle.None;
         Application.Current.MainWindow.ResizeMode = ResizeMode.NoResize;
         Application.Current.MainWindow.Left = 0;
         Application.Current.MainWindow.Top = 0;
         Application.Current.MainWindow.Width = SystemParameters.VirtualScreenWidth;
         Application.Current.MainWindow.Height = SystemParameters.VirtualScreenHeight;
         Application.Current.MainWindow.Topmost = true;
      }

      private void ButCont_Unchecked(object sender, RoutedEventArgs e)
      {
         GameDataManager.KeyboardMode = 0;
         ManageButtons();
      }

      private void ButCont_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.KeyboardMode = 1;
         ManageButtons();
      }

      // Languages
      #region 

      private void RBes_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 2;
         LanguagesList = GameDataManager.SpanishList;

         ManageSettings();
         ManageButtons();
      }

      private void RBjp_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 3;
         LanguagesList = GameDataManager.JapaneseList;
         ManageSettings();
         ManageButtons();
      }

      private void RBfr_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 0;
         LanguagesList = GameDataManager.FrenchList;
         ManageSettings();
         ManageButtons();
      }

      private void RBan_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 1;
         LanguagesList = GameDataManager.EnglishList;
         ManageSettings();
         ManageButtons();
      }

      void ManageSettings()
      {
         Backtext.Text = LanguagesList[0];
         TitleSett.Text = LanguagesList[11];
         GMus.Text = LanguagesList[12];
         SEff.Text = LanguagesList[13];
         RBfr.Content = LanguagesList[14];
         RBan.Content = LanguagesList[15];
         RBes.Content = LanguagesList[16];
         RBjp.Content = LanguagesList[17];
         RenD.Text = LanguagesList[18];
         Perfo.Text = LanguagesList[19];
         Inp.Text = LanguagesList[21];
         Full.Text = LanguagesList[20];
         Lang.Text = LanguagesList[31];       
         Resettext2.Text = LanguagesList[33];

         ManageCharacteristics();
      }

      void ManageLanguages()
      {
         RBfr.IsChecked = false;
         RBan.IsChecked = false;
         RBes.IsChecked = false;
         RBjp.IsChecked = false;

         switch (GameDataManager.Language)
         {
            case 0:
               LanguagesList = GameDataManager.FrenchList;
               RBfr.IsChecked = true;
               break;
            case 1:
               LanguagesList = GameDataManager.EnglishList;
               RBan.IsChecked = true;
               break;
            case 2:
               LanguagesList = GameDataManager.SpanishList;
               RBes.IsChecked = true;
               break;
            case 3:
               LanguagesList = GameDataManager.JapaneseList;
               RBjp.IsChecked = true;
               break;
         }
      }

      #endregion

      void ManageFPS()
      {
         float perfValuermance = 0;
         switch(GameDataManager.Fps)
         {
            case 30:
               perfValuermance = 0;
            break;
            case 60:
               perfValuermance = 3.3333f;
               break;
            case 90:
               perfValuermance = 6.66666f;
               break;
            case 120:
               perfValuermance = 10f;
               break;
         }
         PerformanceSlider.Value = perfValuermance;
        
         if (PerformanceSlider.Value < 0.2) { perfValue.Text = "30 FPS"; } 
      }

      void ManageRenderDistance()
      {        
         RDistanceSlider.Value = GameDataManager.RenderDistance;       
      }

      void GameMusicSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         var slider = sender as Slider;
         double value = slider.Value;
         GameDataManager.MusicVolume = (int)Math.Round(value, 0);
         musicvalue.Text = GameDataManager.MusicVolume.ToString();
      }

      void SoundEffectsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         var slider = sender as Slider;
         double value = slider.Value;
         GameDataManager.SoundEffectVolume = (int)Math.Round(value, 0);
         soundvalue.Text = GameDataManager.SoundEffectVolume.ToString();

      }

      void ResetButton_Click(object sender, RoutedEventArgs e)
      {
         GameDataManager.RD = true;
         GameDataManager.BasicSettings();
         ManageSettings();
         ManageFPS();
         ManageRenderDistance();
         ManageLanguages();
         ManageSound();
         ManageButtons();

      } 

      void ManageSound()
      {
         GameMusicSlider.Value = GameDataManager.MusicVolume;
         SoundEffectsSlider.Value = GameDataManager.SoundEffectVolume;
      }

      void ManageButtons()
      {
         if (GameDataManager.FullscreenMode == 1)
         {
            ButFull.Content = LanguagesList[29];
            ButFull.IsChecked = true;
            
         }
         else
         {
            ButFull.Content = LanguagesList[30];
            ButFull.IsChecked = false;
           
         }

         if (GameDataManager.KeyboardMode == 0)
         {
            ButCont.Content = LanguagesList[23];
            ButCont.IsChecked = false;
         }
         else
         {
            GameDataManager.KeyboardMode = 1;
            ButCont.Content = LanguagesList[22];
            ButCont.IsChecked = true;
         }

      }

      void ManageCharacteristics()
      {
         switch(GameDataManager.Language)
         {
            case 0:
               Resettext2.Margin= new Thickness(33, 64, 126, 48);
               Backtext.Margin  = new Thickness(28, 19, 113, 88);
               TitleSett.Margin = new Thickness(-25, 11, 40, 11);
               break;
            case 1:
               Resettext2.Margin= new Thickness(43, 64, 126, 48);
               Backtext.Margin  = new Thickness(28, 19, 113, 88);
               TitleSett.Margin = new Thickness(-24, 11, 38, 11);
               break;
            case 2:
               Resettext2.Margin = new Thickness(37, 64, 122, 48);
               Backtext.Margin   = new Thickness(22, 19, 114, 88);
               TitleSett.Margin  = new Thickness(-21, 11, 35, 11);
               break;
            case 3:
               Resettext2.Margin= new Thickness(39, 64, 123, 48);
               Backtext.Margin  = new Thickness(28, 19, 113, 88);
               TitleSett.Margin = new Thickness(-14, 11, 44, 11);
               break;
         }
      }

      //Unused methods
      #region   

      private void rdvalue_TextChanged(object sender, TextChangedEventArgs e)
      {

      }
      private void musicvalue_TextChanged(object sender, TextChangedEventArgs e)
      {

      }
      private void TitleSett_TextChanged(object sender, TextChangedEventArgs e)
      {

      }
      private void perfovalue_TextChanged(object sender, TextChangedEventArgs e)
      {

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


      #endregion
   }
}

