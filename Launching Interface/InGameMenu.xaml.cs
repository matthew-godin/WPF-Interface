using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Launching_Interface
{
   /// <summary>
   /// Logic for InGameMenu
   /// </summary>
   public partial class InGameMenu : Page
   {
      bool IsFirstTimeBackground { get; set; }
      List<string> LanguagesList { get; set; }

      public InGameMenu()
      {
         RefreshData();
         IsFirstTimeBackground = true;
         LanguagesList = new List<string>();

         InitializeComponent();

         GoodScreenshot();
         ManageFPS();
         GameDataManager.RD = true;
         ManageLanguages();
         ManageRenderDistance();
         ManageSound();
         ManageButtons();
         ManageSettings();

      }

      private void RefreshData()
      {
         //StreamReader reader = new StreamReader("F:/programmation clg/quatrième session/WPFINTERFACE/Launching Interface/Saves/Settings.txt");
         //StreamReader reader = new StreamReader("C:/Users/Matthew/Source/Repos/WPFINTERFACE/Launching Interface/Saves/Settings.txt");
         StreamReader reader = new StreamReader("../../Saves/Settings.txt");
         string line = reader.ReadLine();
         string[] parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         GameDataManager.MusicVolume = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         GameDataManager.SoundEffectVolume = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         GameDataManager.Language = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         GameDataManager.RenderDistance = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         GameDataManager.Fps = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         GameDataManager.FullscreenMode = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         GameDataManager.KeyboardMode = int.Parse(parts[1]);
         reader.Close();
      }


      private void BackButton_Click(object sender, RoutedEventArgs e)
      {
         SaveSettings();
         // this.NavigationService.Navigate(new MainPage());

         PlaceMouseInTheCenter();
         Application.Current.Shutdown();
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

      [DllImport("User32.dll")]
      private static extern bool SetCursorPos(int X, int Y);

      void PlaceMouseInTheCenter()
      {
         SetCursorPos((int)(((Panel)Application.Current.MainWindow.Content).ActualWidth / 2), (int)(((Panel)Application.Current.MainWindow.Content).ActualHeight / 2));
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
            else if (value > 3.7 && value < 3.8)
            {
               GameDataManager.RenderDistance = 500;
               RDistanceSlider.Value = 3.75;
            }
            else if (value > 4.9 && value < 5.1)
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

        
      }

      private void ButFull_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.FullscreenMode = 1;
         ManageButtons();
      }

      private void ButCont_Unchecked(object sender, RoutedEventArgs e)
      {
         GameDataManager.KeyboardMode = 1;
         ManageButtons();
         Instructions();
      }

      private void ButCont_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.KeyboardMode = 0;
         ManageButtons();
         Instructions();
      }

      // Languages
      #region 

      private void RBes_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 2;
         LanguagesList = GameDataManager.SpanishList;
         
         ManageSettings();
      }
      private void RBjp_Checked(object sender, RoutedEventArgs e)
      {
         GameDataManager.Language = 3;
         LanguagesList = GameDataManager.JapaneseList;
         
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
      
         ManageSettings();
      }

      void ManageSettings()
      {
         Backtext.Text = LanguagesList[0];
         GMus.Text = LanguagesList[12];
         SEff.Text = LanguagesList[13];
         RBfr.Content = LanguagesList[14];
         RBan.Content = LanguagesList[15];
         RBes.Content = LanguagesList[16];
         RBjp.Content = LanguagesList[17];
         RenD.Text = LanguagesList[18];
         Perfo.Text = LanguagesList[19];
         Full.Text = LanguagesList[20];
         Inp.Text = LanguagesList[21];
         
         Lang.Text = LanguagesList[31];
         Resettext2.Text = LanguagesList[33];
         TitleSett.Text = LanguagesList[35];
         menuText.Text = LanguagesList[36];         
         saveText.Text = LanguagesList[37];

        
         switch(GameDataManager.Language)
         {
            case 0:
               Backtext.Margin = new Thickness(38, 19, 110, 88);
               Resettext2.Margin = new Thickness(113, 19, 28, 88);
               saveText.Margin = new Thickness(29, 60, 118, 48);
               break;
            case 1:
               Backtext.Margin = new Thickness(38, 19, 113, 88);
               Resettext2.Margin = new Thickness(107, 19, 33, 88);
               saveText.Margin = new Thickness(40, 64, 118, 48);
               break;
            case 2:
               Backtext.Margin = new Thickness(34, 19, 110, 88);
               Resettext2.Margin = new Thickness(111, 19, 30, 88);
               saveText.Margin = new Thickness(40, 64, 118, 48);
               break;
            case 3:
               Backtext.Margin = new Thickness(38, 19, 113, 88);
               Resettext2.Margin = new Thickness(107, 19, 33, 88);
               saveText.Margin = new Thickness(40, 64, 118, 48);

               break;
         }

         textP.Text = LanguagesList[35];
         textShift.Text = LanguagesList[38];
         textSpace.Text = LanguagesList[39];
         textWASD.Text = LanguagesList[40];
         textFleches.Text = LanguagesList[41];
         textE.Text = LanguagesList[42];

         Instructions();
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
         switch (GameDataManager.Fps)
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
         

         GameDataManager.FirstFile = true; //nothing for commit
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

      private void OnKeyDownHandler(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Escape)
         {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
            Application.Current.MainWindow.ShowInTaskbar = true;
         }
      }

      private void MenuButton_Click(object sender, RoutedEventArgs e)
      {
         SaveSettings();
         StreamWriter writer = new StreamWriter("../../Saves/save.txt");
         writer.WriteLine("0");
         writer.WriteLine("false");
         writer.Close();
         KillHyperV();
         this.NavigationService.Navigate(new MainPage());
      }

      void KillHyperV()
      {
         Process[] procs = Process.GetProcessesByName("HyperV");
         Process hypervProc = procs[0];

         hypervProc.Kill();

         //try
         //{
         //    procs = Process.GetProcessesByName("HyperV");

         //    Process hypervProc = procs[0];

         //    if (!hypervProc.HasExited)
         //    {
         //        hypervProc.Kill();
         //    }
         //}
         //finally
         //{
         //    if (procs != null)
         //    {
         //        foreach (Process p in procs)
         //        {
         //            p.Dispose();
         //        }
         //    }
         //}
      }

      void GoodScreenshot()
      {
         BitmapImage src = new BitmapImage();
         src.BeginInit();
         src.UriSource = new Uri(@"../../Saves/pendingscreenshot.png", UriKind.Relative);
         src.CacheOption = BitmapCacheOption.OnLoad;
         src.EndInit();
         ImageFond.Source = src;
      }

      void Instructions()
      {
         if (GameDataManager.KeyboardMode == 1)
         {
            ButCont.Content = LanguagesList[23];
            ButCont.IsChecked = false;
            ChangeKeyboardImages();
            ChangeKeyboardMargins();

            textL.Text = " ";
            textR.Text = " ";
         }
         else
         {
            ButCont.Content = LanguagesList[22];
            ButCont.IsChecked = true;
            ChangeGameControllerImages();
            ChangeGameControllerMargins();

            textL.Text = LanguagesList[43];
            textR.Text = LanguagesList[44];
         }
      }

      void ChangeKeyboardImages()
      {
         ImageInstructions.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/keyboard.png", UriKind.Relative));
         wasd.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/KeyboardKeys/WASD.png", UriKind.Relative));
         e.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/KeyboardKeys/E.png", UriKind.Relative));
         SpaceBar.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/KeyboardKeys/SpaceBar.png", UriKind.Relative));
         Shift.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/KeyboardKeys/Shift.png", UriKind.Relative));
         p.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/KeyboardKeys/P.png", UriKind.Relative));
         KeyboardArrows.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/KeyboardKeys/KeyboardArrows.png", UriKind.Relative));
      }

      void ChangeKeyboardMargins()
      {
         textWASD.Margin = new Thickness(110,8,-32,-3);
         textSpace.Margin = new Thickness(0);
         textFleches.Margin = new Thickness(0);
         textL.Margin = new Thickness(0);
         textR.Margin = new Thickness(0);

         wasd.Margin = new Thickness(50, -140, 500, -360);
         e.Margin = new Thickness(206, -280, 250, -212);
         p.Margin = new Thickness(165, -230, 275, -230);
         SpaceBar.Margin = new Thickness(-40, -210, 300, -184);
         Shift.Margin = new Thickness(166, -235, 213, -260);
         KeyboardArrows.Margin = new Thickness(10, -28, 400, -278);

         //switch (GameDataManager.Language)
         //{
         //   case 0:
         //      textFleches.Margin = new Thickness(-17, 0, 15, 0);
         //      textSpace.Margin = new Thickness(-22.5, 0, 20, 0);
         //      textWASD.Margin = new Thickness(-11, 0, -10, 0);
         //      break;
         //   case 1:
         //      textFleches.Margin = new Thickness(-17, 0, 15, 0);
         //      textSpace.Margin = new Thickness(-22, 0, 24, 0);
         //      textWASD.Margin = new Thickness(-8, 0, -8, 0);
         //      break;
         //   case 2:
         //      textFleches.Margin = new Thickness(-20, 0, 5, 0);
         //      textSpace.Margin = new Thickness(-22, 0, 23, 0);
         //      textWASD.Margin = new Thickness(-8, 0, -8, 0);
         //      break;
         //   case 3:
         //      textFleches.Margin = new Thickness(-10, 0, 5, 0);
         //      textSpace.Margin = new Thickness(-22.5, 0, 20, 0);
         //      textWASD.Margin = new Thickness(-8, 0, -8, 0);
         //      break;
         //}

      }

      void ChangeGameControllerImages()
      {
         ImageInstructions.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/Controller2Sides.png", UriKind.Relative));
         wasd.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/GameControllerButtons/Stick_Xbox.png", UriKind.Relative));
         e.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/GameControllerButtons/X_Xbox.png", UriKind.Relative));
         p.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/GameControllerButtons/Start_Xbox.png", UriKind.Relative));
         SpaceBar.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/GameControllerButtons/A_Xbox.png", UriKind.Relative));
         Shift.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/GameControllerButtons/LT_Xbox.png", UriKind.Relative));
         KeyboardArrows.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/GameControllerButtons/Stick_Xbox.png", UriKind.Relative));
      }

      void ChangeGameControllerMargins()
      {
         textWASD.Margin = new Thickness(-12, 0, -10, 0);
         wasd.Margin = new Thickness(1900, 500, 3900, -400);
         textL.Margin = new Thickness(8,3,10,0);
         textR.Margin = new Thickness(6,1.5,10,-0.5);         
         e.Margin = new Thickness(2840, 120, 5170, 420);
         p.Margin = new Thickness(170, -30, 660, -89);
         SpaceBar.Margin = new Thickness(2255, 910, 4050, -140);
         Shift.Margin = new Thickness(175, 35, 370, -37);
         KeyboardArrows.Margin = new Thickness(2100, 500, 3900, -380);

         switch(GameDataManager.Language)
         {
            case 0:
               textFleches.Margin = new Thickness(-17, 0, 15, 0);
               textSpace.Margin = new Thickness(-22.5, 0, 20, 0);
               textWASD.Margin = new Thickness(-11, 0, -10, 0);
               break;
            case 1:
               textFleches.Margin = new Thickness(-17, 0, 15, 0);
               textSpace.Margin = new Thickness(-22, 0, 24, 0);
               textWASD.Margin = new Thickness(-8, 0, -8, 0);
               break;
            case 2:
               textFleches.Margin = new Thickness(-20, 0, 5, 0);
               textSpace.Margin = new Thickness(-22, 0, 23, 0);
               textWASD.Margin = new Thickness(-8, 0, -8, 0);
               break;
            case 3:
               textFleches.Margin = new Thickness(-10, 0, 5, 0);
               textSpace.Margin = new Thickness(-22.5, 0, 20, 0);
               textWASD.Margin = new Thickness(-8, 0, -8, 0);
               break;
         }

      }

      void saveButton_Click(object sender, RoutedEventArgs e)
      {
         StreamReader r = new StreamReader("../../Saves/save.txt");
         int n = int.Parse(r.ReadLine());
         r.Close();
         File.Copy("../../Saves/pendingsave.txt", "../../Saves/save" + n + ".txt", true);
         File.Copy("../../Saves/pendingscreenshot.png", "../../Saves/screenshot" + n + ".png", true);
      }

      void ManageButtons()
      {
         if (GameDataManager.FullscreenMode == 1)
         {
            ButFull.IsChecked = true;
            ApplyBackground();
            ButFull.Content = LanguagesList[29];
         }
         else 
         {
            if(IsFirstTimeBackground == true) { IsFirstTimeBackground = false; }
            RemoveBackground();
            ButFull.Content = LanguagesList[30];
         }

         if (GameDataManager.KeyboardMode == 1)
         {
            ButCont.Content = LanguagesList[23];
            ImageInstructions.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/keyboard.png", UriKind.Relative));
         }
         else 
         {
            ButCont.Content = LanguagesList[22];
            ImageInstructions.Source = new BitmapImage(new Uri(@"/Pictures/Instructions/Controller2Sides.png", UriKind.Relative));
         }
      }

      void ApplyBackground()
      {
         if (IsFirstTimeBackground == true)
         {
            IsFirstTimeBackground = false;
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

      void RemoveBackground()
      {
         Application.Current.MainWindow.Height = 750;
         Application.Current.MainWindow.Width = 1400;
         
         Application.Current.MainWindow.WindowState = WindowState.Normal;
         Application.Current.MainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
         Application.Current.MainWindow.ResizeMode = ResizeMode.CanResize;
      }

      // Not used
      #region

      private void rdvalue_TextChanged(object sender, TextChangedEventArgs e)
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
   }
}
