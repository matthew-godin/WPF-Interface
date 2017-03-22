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
      const string READING_PATH = "../../Languages/";
      const string WRITING_PATH = "../../FilesModified/";
      const string FILE_SENT_NAME = "toXna.txt";

      public static bool ChoisirRenderDistance = true;

      const int LANGUAGE_BASE = 0; 
      const int FPS_BASE = 60;     
      const int RENDER_D_BASE = 500; 
      const int VOL_MUS_BASE = 50;   
      const int VOL_EFF_BASE = 50;   
      const int NUM_LEVELS_BASE = 0; 
      static TimeSpan TEMPS_BASE = new TimeSpan(0,0,0);  //pour nous, constante

      public static int Language { get; set; } // 0 = French || 1 = English || 2 = Spanish || 3 = japonais  
      public static int Fps { get; set; }    // 30,60,90,120
      public static int RenderDistance { get; set; } // 10,50,100,500,1000,5000,10000,50000,100000
      public static int MusicVolume { get; set; } // de 0 à 100
      public static int SoundEffectVolume { get; set; }  // de 0 à 100
      public static int FullscreenMode { get; set; } // 0 = false || 1 = true
      public static int KeyboardMode { get; set; }   // 0 = false || 1 = true
      public static int NbLevelxCompletes { get; set; } // 1,2,3
      public static bool FirstFile { get; set; }
      
      public static TimeSpan Temps { get; set; }

      public static List<string> FrenchList { get; private set; }
      public static List<string> EnglishList  { get; private set; }
      public static List<string> SpanishList { get; private set; }
      public static List<string> JapaneseList { get; private set; }
      public static List<int>  InfoReceivedList { get; private set; }

      static GameDataManager()
      {
         FrenchList = new List<string>();
         EnglishList  = new List<string>();
         SpanishList = new List<string>();
         JapaneseList = new List<string>();
         InfoReceivedList = new List<int>();

         

         ReadFile("En.txt");
         ReadFile("Es.txt");
         ReadFile("Jp.txt");
         ReadFile("Fr.txt");
         if (File.Exists("../../Languages/toMenu.txt"))
         {
            FirstFile = false;
            ReadFile("toMenu.txt");           
         }
         else
         {
            FirstFile = true;
         }
        
         SelectSettings();
      }

      static void ReadFile(string fileName)
      {
         StreamReader dataReader = new StreamReader(READING_PATH + fileName);
         while (!dataReader.EndOfStream)
         {
            switch (fileName)
            {
               case "Fr.txt":
                  FrenchList.Add(dataReader.ReadLine() + '\n');
                  break;
               case "En.txt":
                  EnglishList.Add(dataReader.ReadLine() + '\n');
                  break;
               case "Es.txt":
                  SpanishList.Add(dataReader.ReadLine() + '\n');
                  break;
               case "Jp.txt":
                  JapaneseList.Add(dataReader.ReadLine() + '\n');
                  break;
               case "toMenu.txt":
                  InfoReceivedList.Add(int.Parse(dataReader.ReadLine() + '\n'));
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

      static void SelectSettings()
      {
         if (FirstFile == true)
         {
            BasicSettings();
         }
         else
         {
            ModifiedSettings();
         }
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

      static void ModifiedSettings()
      {
         Language = InfoReceivedList[0];
         RenderDistance = InfoReceivedList[2];
         Fps = InfoReceivedList[1];
         MusicVolume = InfoReceivedList[3];
         SoundEffectVolume = InfoReceivedList[4];
         FullscreenMode = InfoReceivedList[5];
         KeyboardMode = InfoReceivedList[6];
         NbLevelxCompletes = InfoReceivedList[7];
         Temps = new TimeSpan(InfoReceivedList[8],InfoReceivedList[9],0);
      }
   }
}
