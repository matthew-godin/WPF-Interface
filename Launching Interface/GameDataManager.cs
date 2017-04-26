using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Launching_Interface
{
   public static class GameDataManager
   {
      const string READING_PATH = "../../";
      const string WRITING_PATH = "../../FilesModified/";
      const string FILE_SENT_NAME = "toXna.txt";

      public static bool RD = true;
      public static int NUM_LEVELS = 5;
      const int LANGUAGE_BASE = 0;
      const int FPS_BASE = 60;
      const int RENDER_D_BASE = 500;
      const int VOL_MUS_BASE = 50;
      const int VOL_EFF_BASE = 50;
      const int NUM_LEVELS_BASE = 0;
      static TimeSpan TEMPS_BASE = new TimeSpan(0,0,0);  //pour nous, constante

      enum Languages { French, English, Spanish, japonais }
      enum Fullscreen { yes,no }
      enum Controller { GameController, Keyboard}
      enum NbreLevelxFinis { Auncun,Un,Deux,Trois,Quatres,Cinq,Six,Sept,Huit}

      static int language;
      static int fullscreen;
      static int controller;
      static int nbreLevelxFinis;

      public static int Language
      {
         get { return language; }
         set
         {
            if (value >= (int)Languages.French && value <= (int)Languages.japonais)
            {
               language = value;
            }
            else
            {
               //throw new ArgumentException("Language invalide");
               language = (int)Languages.French;
            }
         }
      }
      public static int Fps;    // 30,60,90,120
      public static int RenderDistance; // 10,50,100,500,1000,5000,10000,50000,100000
      public static int MusicVolume;     // de 0 à 100
      public static int SoundEffectVolume;     // de 0 à 100
      public static int FullscreenMode // 0 = false || 1 = true
      {
         get { return fullscreen; }
         set
         {
            if (value == (int)Fullscreen.no || value == (int)Fullscreen.yes)
            {
               fullscreen = value;
            }
            else
            {
               fullscreen = (int)Fullscreen.yes;
            }
         }
      } 
      public static int KeyboardMode// 0 = false || 1 = true
      {
         get { return controller; }
         set
         {
            if (value == (int)Controller.GameController || value == (int)Controller.Keyboard)
            {
               controller = value;
            }
            else
            {
               controller = (int)Controller.Keyboard;
            }
         }
      }
      public static int NbLevelxCompletes// 1,2,3,4,5,6,7,8
      {
         get { return nbreLevelxFinis; }
         set
         {
            if (value >= (int)NbreLevelxFinis.Auncun && value <= (int)NbreLevelxFinis.Huit)
            {
               nbreLevelxFinis = value;
            }
            else
            {
               nbreLevelxFinis = (int)Languages.French;
            }
         }
      }     
      public static bool FirstFile;
      public static TimeSpan Temps;

      public static List<string> FrenchList { get; private set; }
      public static List<string> EnglishList { get; private set; }
      public static List<string> SpanishList { get; private set; }
      public static List<string> JapaneseList { get; private set; }

      public static bool[] GameExists;

      public static void InitGameDataManager(StreamReader reader)
      {
         string line = reader.ReadLine();
         string[] parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         MusicVolume = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         SoundEffectVolume = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         Language = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         RenderDistance = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         Fps = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         FullscreenMode = int.Parse(parts[1]);
         line = reader.ReadLine();
         parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
         KeyboardMode = int.Parse(parts[1]);
         reader.Close();
      }

      static GameDataManager()
      {
         FrenchList = new List<string>();
         EnglishList = new List<string>();
         SpanishList = new List<string>();
         JapaneseList = new List<string>();

         ReadFile("Languages/En.txt");
         ReadFile("Languages/Es.txt");
         ReadFile("Languages/Jp.txt");
         ReadFile("Languages/Fr.txt");
      }

      static void ReadFile(string fileName)
      {
         StreamReader dataReader = new StreamReader(READING_PATH + fileName);
         while (!dataReader.EndOfStream)
         {
            switch (fileName)
            {
               case "Languages/Fr.txt":
                  FrenchList.Add(dataReader.ReadLine() + '\n');
                  break;
               case "Languages/En.txt":
                  EnglishList.Add(dataReader.ReadLine() + '\n');
                  break;
               case "Languages/Es.txt":
                  SpanishList.Add(dataReader.ReadLine() + '\n');
                  break;
               case "Languages/Jp.txt":
                  JapaneseList.Add(dataReader.ReadLine() + '\n');
                  break;
            }
         }
         dataReader.Close();
      }

      public static void ÉcrireFichier(List<int> listeInfo)
      {
         StreamWriter ecrivainDonnees = new StreamWriter(WRITING_PATH + FILE_SENT_NAME);

         foreach (int info in listeInfo)
         {
            ecrivainDonnees.WriteLine(info.ToString());
         }
         ecrivainDonnees.Close();
      }

      public static void BasicSettings()
      {
         Language = LANGUAGE_BASE;
         RenderDistance = RENDER_D_BASE;
         Fps = FPS_BASE;
         MusicVolume = VOL_MUS_BASE;
         SoundEffectVolume = VOL_EFF_BASE;
         FullscreenMode = 1;
         KeyboardMode = 1;
         NbLevelxCompletes = NUM_LEVELS_BASE;
         Temps = TEMPS_BASE;
      }

      //static void ModifiedSettings()
      //{
      //   Language = InfoReceivedList[0];
      //   RenderDistance = InfoReceivedList[2];
      //   Fps = InfoReceivedList[1];
      //   MusicVolume = InfoReceivedList[3];
      //   SoundEffectVolume = InfoReceivedList[4];
      //   FullscreenMode = InfoReceivedList[5];
      //   KeyboardMode = InfoReceivedList[6];
      //   NbLevelxCompletes = InfoReceivedList[7];
      //   Temps = new TimeSpan(InfoReceivedList[8], InfoReceivedList[9], 0);
      //}

      //static void SelectSettings()
      //{
      //   if (FirstFile == true)
      //   {
      //      BasicSettings();
      //   }
      //   else
      //   {
      //      ModifiedSettings();
      //   }
      //}
   }
}

