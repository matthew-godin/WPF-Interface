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

namespace Launching_Interface
{
   /// <summary>
   /// Interaction logic for SettingsPage.xaml
   /// </summary>
   /// 

   public partial class SettingsPage : Page
   {
      List<string> LanguagesList { get; set; }
      List<int> ListeInfosÀEnvoyer { get; set; }
      


      int LanguageOficielle { get; set; }
      int Fps { get; set; }
      int RenderDistance { get; set; }
      double VolumeMusique { get; set; }
      double VolumeEffets { get; set; }

      bool choixFullscreen = false;
      bool choixController = false;

      public SettingsPage()
      {
         LanguagesList = new List<string>();
         ListeInfosÀEnvoyer = new List<int>();

         if(GameDataManager.FirstFile == true)
         {
            ListeInfosÀEnvoyer.Add(GameDataManager.Language);
            ListeInfosÀEnvoyer.Add(GameDataManager.Fps);
            ListeInfosÀEnvoyer.Add(GameDataManager.RenderDistance);
            ListeInfosÀEnvoyer.Add(GameDataManager.MusicVolume);
            ListeInfosÀEnvoyer.Add(GameDataManager.SoundEffectVolume);
            ListeInfosÀEnvoyer.Add(GameDataManager.FullscreenMode);
            ListeInfosÀEnvoyer.Add(GameDataManager.KeyboardMode);
         }
         else
         {
            ListeInfosÀEnvoyer = GameDataManager.ListeInfosRecus;

            ListeInfosÀEnvoyer[0] = GameDataManager.Language;
            ListeInfosÀEnvoyer[1] = GameDataManager.Fps;
            ListeInfosÀEnvoyer[2] = GameDataManager.RenderDistance;
            ListeInfosÀEnvoyer[3] = GameDataManager.MusicVolume;
            ListeInfosÀEnvoyer[4] = GameDataManager.SoundEffectVolume;
            ListeInfosÀEnvoyer[5] = GameDataManager.FullscreenMode;
            ListeInfosÀEnvoyer[6] = GameDataManager.KeyboardMode;
         }



         InitializeComponent();
         ManageLanguages();
         ManageFPS();
         ManageRenderDistance();

         ManageSettings();
      }
      private void BackButton_Click(object sender, RoutedEventArgs e)
      {
         this.NavigationService.Navigate(new MainPage());

         ListeInfosÀEnvoyer[0] = GameDataManager.Language;
         ListeInfosÀEnvoyer[1] = GameDataManager.Fps;
         ListeInfosÀEnvoyer[2] = GameDataManager.RenderDistance;
         ListeInfosÀEnvoyer[3] = GameDataManager.MusicVolume;
         ListeInfosÀEnvoyer[4] = GameDataManager.SoundEffectVolume;
         ListeInfosÀEnvoyer[5] = GameDataManager.FullscreenMode;
         ListeInfosÀEnvoyer[6] = GameDataManager.KeyboardMode;

         GameDataManager.ÉcrireFichier(ListeInfosÀEnvoyer);
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

      private void ControllerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {

      }

      private void RDistanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // Render Distance
      {
         var sliderA = sender as Slider;
         double value = sliderA.Value;

         if (value >= 0 && value <= 0.1)
         {
            RenderDistance = 10;
         }
         if (value > 1.2 && value < 1.3)
         {
            RenderDistance = 50;
         }
         if (value > 2.4 && value < 2.6)
         {
            RenderDistance = 100;
         }
         if (value > 3.7 && value < 3.8)
         {
            RenderDistance = 500;
         }
         if (value > 4.9 && value < 5.1)
         {
            RenderDistance = 1000;
         }
         if (value > 6.2 && value < 6.3)
         {
            RenderDistance = 5000;
         }
         if (value > 7.4 && value < 7.6)
         {
            RenderDistance = 10000;
         }
         if (value > 8.7 && value < 8.8)
         {
            RenderDistance = 50000;
         }
         if (value > 9.9 && value <= 10)
         {
            RenderDistance = 100000;
         }
         rdvalue.Text = RenderDistance.ToString();
         GameDataManager.RenderDistance = RenderDistance;
        
      }

      private void PerfSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)   // FPS
      {

         
      }

      private void RadioButton_Checked(object sender, RoutedEventArgs e)
      {

      }


      private void ButFull_Unchecked(object sender, RoutedEventArgs e)
      {
         ButFull.Content = LanguagesList[30];
         GameDataManager.FullscreenMode = 0;
         choixFullscreen = true;      
      }
      private void ButFull_Checked(object sender, RoutedEventArgs e)
      {
         ButFull.Content = LanguagesList[29];
         GameDataManager.FullscreenMode = 1;
         GameDataManager.FirstFile = false;
         choixFullscreen = true;
      }
      private void ButCont_Unchecked(object sender, RoutedEventArgs e)
      {
         ButCont.Content = LanguagesList[23];
         GameDataManager.KeyboardMode = 1;
         choixController = false;
         
      }
      private void ButCont_Checked(object sender, RoutedEventArgs e)
      {
         ButCont.Content = LanguagesList[22];
         GameDataManager.KeyboardMode = 0;
         GameDataManager.FirstFile = false;
         choixController = true;
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
         Lang.Text = LanguagesList[31]; RBan.Content = LanguagesList[15]; RBfr.Content = LanguagesList[14];
         RBes.Content = LanguagesList[16]; RBjp.Content = LanguagesList[17];
         SEff.Text = LanguagesList[13];
         GMus.Text = LanguagesList[12];

         TitleSett.Text = LanguagesList[11];
         Backtext.Text = LanguagesList[0];
         Resettext2.Text = LanguagesList[33];

         RenD.Text = LanguagesList[18];
         Perfo.Text = LanguagesList[19];
         Inp.Text = LanguagesList[21];
         Full.Text = LanguagesList[20];

         if (choixFullscreen == true)
         {
            ButFull.Content = LanguagesList[29];
         }
         else if (choixFullscreen == false)
         {
            ButFull.Content = LanguagesList[30];
         }

         if (choixController == true)
         {
            ButCont.Content = LanguagesList[22];
         }
         else if (choixController == false)
         {
            ButCont.Content = LanguagesList[23];
         }

      }

      void ManageLanguages()
      {
         if (GameDataManager.Language == 0) { LanguagesList = GameDataManager.FrenchList; }
         if (GameDataManager.Language == 1) { LanguagesList = GameDataManager.EnglishList; }
         if (GameDataManager.Language == 2) { LanguagesList = GameDataManager.SpanishList; }
         if (GameDataManager.Language == 3) { LanguagesList = GameDataManager.JapaneseList; }
      }

      #endregion

      void ManageFPS()
      {
         if (GameDataManager.Fps == 30) { Fps = 30; }
         if (GameDataManager.Fps == 60) { Fps = 60; }
         if (GameDataManager.Fps == 90) { Fps = 90; }
         if (GameDataManager.Fps == 120) { Fps = 120; }
      }
      void ManageRenderDistance()
      {
         if (GameDataManager.RenderDistance == 10)  { RenderDistance = 10; }
         if (GameDataManager.RenderDistance == 50)  { RenderDistance = 50; }
         if (GameDataManager.RenderDistance == 100) { RenderDistance = 100; }
         if (GameDataManager.RenderDistance == 500) { RenderDistance = 500; }
         if (GameDataManager.RenderDistance == 1000)  { RenderDistance = 1000; }
         if (GameDataManager.RenderDistance == 5000)  { RenderDistance = 5000; }
         if (GameDataManager.RenderDistance == 10000) { RenderDistance = 10000; }
         if (GameDataManager.RenderDistance == 50000) { RenderDistance = 50000; }
         if (GameDataManager.RenderDistance == 100000) { RenderDistance = 100000; }
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

      private void PerformanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         var slider = sender as Slider;
         double value = slider.Value;

         if (value >= 0 && value <= 0.5)
         {
            Fps = 30;
         }
         if (value > 3.2 && value < 3.4)
         {
            Fps = 60;
         }
         if (value > 6.5 && value < 6.7)
         {
            Fps = 90;
         }
         if (value < 10 && value > 9.9)
         {
            Fps = 120;
         }
         perfValue.Text = Fps.ToString() + " FPS";
      }

      private void GameMusicSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         var slider = sender as Slider;
         double value = slider.Value;
         VolumeMusique = value;
              musicvalue.Text = Math.Round(VolumeMusique,0).ToString();
      }

      private void SoundEffectsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         var slider = sender as Slider;
         double value = slider.Value;
         VolumeEffets = value;
         soundvalue.Text = Math.Round(VolumeEffets, 0).ToString();
      }

      private void ResetButton_Click(object sender, RoutedEventArgs e)
      {
         GameDataManager.FirstFile = true;
         GameDataManager.BasicSettings();         
      }

   }
}
