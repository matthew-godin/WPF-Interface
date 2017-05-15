using System;
using System.Collections.Generic;
using System.IO;

namespace Launching_Interface
{
   public static class GameDataManager
   {
      const string BASE_PATH = "../../";

      public static bool RenderDistanceModified = true;
      public const int NUM_SAVES = 3,
                       FPS_BASE = 60,
                       RENDER_D_BASE = 500,
                       VOL_MUS_BASE = 50,
                       VOL_EFF_BASE = 50,
                       NUM_LEVELS_BASE = 0,
                       NUM_CHARACTERISTICS_SETTINGS = 7,
                       NUM_CHARACTERISTICS_HYPERV = 6,
                       NUM_RENDER_DISTANCE = 9,
                       NUM_FPS = 4;

      public enum Languages { French, English, Spanish, Japanese }
      public enum Fullscreen { yes, no }
      public enum Controller { GameController, Keyboard }

      static Languages language;
      static Fullscreen fullscreen;
      static Controller controller;

      public static Languages Language
      {
         get { return language; }
         set
         {
            if (value >= Languages.French && value <= Languages.Japanese)
            {
               language = value;
            }
            else
            {
               language = (int)Languages.French;
            }
         }
      }
      public static int Fps;   
      public static int RenderDistance; 
      public static int MusicVolume; 
      public static int SoundEffectVolume; 
      public static Fullscreen FullscreenMode 
      {
         get { return fullscreen; }
         set
         {
            if (value == Fullscreen.no || value == Fullscreen.yes)
            {
               fullscreen = value;
            }
            else
            {
               fullscreen = Fullscreen.yes;
            }
         }
      }
      public static Controller KeyboardMode 
      {
         get { return controller; }
         set
         {
            if (value == Controller.GameController || value == Controller.Keyboard)
            {
               controller = value;
            }
            else
            {
               controller = Controller.Keyboard;
            }
         }
      }
      public static bool FirstFile;

      public static List<string> FrenchList { get; private set; }
      public static List<string> EnglishList { get; private set; }
      public static List<string> SpanishList { get; private set; }
      public static List<string> JapaneseList { get; private set; }
      public static List<string> CharacteristicsToDisplayList0 { get; private set; }
      public static List<string> CharacteristicsToDisplayList1 { get; private set; }
      public static List<string> CharacteristicsToDisplayList2 { get; private set; }
      static List<bool>[] IsCompleted { get; set; }

      public static bool[] GameExists;


      public static void InitialiserGameDataManager(StreamReader dataReader)
      {
         string[] games;
         int[] characteristics = new int[NUM_CHARACTERISTICS_SETTINGS];
         string line;
         int cpt = 0;

         for (int i = 0; i < NUM_CHARACTERISTICS_SETTINGS; i++)
         {
            line = dataReader.ReadLine();
            games = line.Split(new string[] { ": " }, StringSplitOptions.None);
            characteristics[i] = int.Parse(games[1]);
         }

         MusicVolume = characteristics[cpt]; cpt++;
         SoundEffectVolume = characteristics[cpt]; cpt++;
         Language = (Languages)characteristics[cpt]; cpt++;
         RenderDistance = characteristics[cpt]; cpt++;
         Fps = characteristics[cpt]; cpt++;
         FullscreenMode = (Fullscreen)characteristics[cpt]; cpt++;
         KeyboardMode = (Controller)characteristics[cpt];

         dataReader.Close();
      }

      static GameDataManager()
      {
         FrenchList = new List<string>();
         EnglishList = new List<string>();
         SpanishList = new List<string>();
         JapaneseList = new List<string>();
         CharacteristicsToDisplayList0 = new List<string>();
         CharacteristicsToDisplayList1 = new List<string>();
         CharacteristicsToDisplayList2 = new List<string>();
         ReadFiles("Languages", "En.txt");
         ReadFiles("Languages", "Es.txt");
         ReadFiles("Languages", "Jp.txt");
         ReadFiles("Languages", "Fr.txt");
         RefreshSaves();
      }

      static void InitialisationIsCompleted()
      {
         IsCompleted = new List<bool>[NUM_SAVES];
         for (int i = 0; i < NUM_SAVES; ++i)
         {
            IsCompleted[i] = new List<bool>();
         }
      }

      public static void RefreshSaves()
      {
         InitialisationIsCompleted();
         VerifyGamesExistence();

         for (int i = 0; i < NUM_SAVES; i++)
         {
            if (GameExists[i])
            {
               ReadFiles("Saves", "save" + i + ".txt");
            }
         }
      }

      static void ReadFiles(string folderName, string fileName)
      {
         StreamReader dataReader = new StreamReader(BASE_PATH + folderName + "/" + fileName);
         while (!dataReader.EndOfStream)
         {
            switch (fileName)
            {
               case "Fr.txt":
                  FrenchList.Add(dataReader.ReadLine());
                  break;
               case "En.txt":
                  EnglishList.Add(dataReader.ReadLine());
                  break;
               case "Es.txt":
                  SpanishList.Add(dataReader.ReadLine());
                  break;
               case "Jp.txt":
                  JapaneseList.Add(dataReader.ReadLine());
                  break;
               case "save0.txt":
                  ManageSaveFiles(dataReader, 0);
                  break;
               case "save1.txt":
                  ManageSaveFiles(dataReader, 1);
                  break;
               case "save2.txt":
                  ManageSaveFiles(dataReader, 2);
                  break;
               default:
                  throw new Exception("No file has been read in the static class");
            }
         }
         dataReader.Close();
      }

      static void ManageSaveFiles(StreamReader dataReader, int i)
      {
         List<string> temporaryCharacteristicList = new List<string>();

         string[] games;
         string[] separatingSymbol = new string[NUM_CHARACTERISTICS_HYPERV] { "l: ", "n: ", "n: ", "d: ", "e: ", "k: " };
         string line;

         for (int j = 0; j < NUM_CHARACTERISTICS_HYPERV; j++)
         {
            line = dataReader.ReadLine();
            games = line.Split(new string[] { separatingSymbol[j] }, StringSplitOptions.None);
            temporaryCharacteristicList.Add(games[1]);
         }

         line = dataReader.ReadLine();
         games = line.Split(new char[] { ';' });
         for (int j = 0; j < games.Length; ++j)
         {
            IsCompleted[i].Add(bool.Parse(games[j]));
            temporaryCharacteristicList.Add(bool.Parse(games[j]).ToString());
         }
         AssociateGoodListToDisplay(i, temporaryCharacteristicList);

      }


      public static int NumLevelsCompleted(int i)
      {
         int numCompleted = 0;

         foreach (bool e in IsCompleted[i])
         {
            if (e)
            {
               ++numCompleted;
            }
         }
         return numCompleted;
      }

      public static int NumTotalLevels(int i)
      {
         return IsCompleted[i].Count;
      }

      static void AssociateGoodListToDisplay(int i, List<string> temporaryCharacteristicList)
      {
         switch (i)
         {
            case 0:
               CharacteristicsToDisplayList0 = temporaryCharacteristicList;
               break;
            case 1:
               CharacteristicsToDisplayList1 = temporaryCharacteristicList;
               break;
            case 2:
               CharacteristicsToDisplayList2 = temporaryCharacteristicList;
               break;
         }
      }

      public static void BasicSettings()
      {
         Language = Languages.French;
         RenderDistance = RENDER_D_BASE;
         Fps = FPS_BASE;
         MusicVolume = VOL_MUS_BASE;
         SoundEffectVolume = VOL_EFF_BASE;
         FullscreenMode = Fullscreen.yes;
         KeyboardMode = Controller.GameController;
      }

      static void VerifyGamesExistence()
      {
         StreamReader dataReader;
         GameExists = new bool[NUM_SAVES];
         for (int i = 0; i < NUM_SAVES; ++i)
         {
            dataReader = new StreamReader("../../Saves/save" + i + ".txt");
            GameExists[i] = dataReader.ReadLine() != "";
            dataReader.Close();
         }
      }

   }
}