using System;
using System.Collections.Generic;
using System.IO;

namespace Launching_Interface
{
   public static class GameDataManager
   {
      const string BASE_PATH = "../../";

      public static bool RD = true;
      //public const int NUM_LEVELS = 8;
      const int LANGUAGE_BASE = 0;
      const int FPS_BASE = 60;
      const int RENDER_D_BASE = 500;
      const int VOL_MUS_BASE = 50;
      const int VOL_EFF_BASE = 50;
      const int NUM_LEVELS_BASE = 0;
      const int NBRE_CARACTÉRISTIQUES = 7;
      static TimeSpan TEMPS_BASE = new TimeSpan(0,0,0);  //pour nous, constante

      enum Languages { French, English, Spanish, japonais }
      enum Fullscreen { yes,no }
      enum Controller { GameController, Keyboard}
      enum NbreLevelxFinis { Auncun,Un,Deux,Trois,Quatres,Cinq,Six,Sept,Huit}

      static int language;
      static int fullscreen;
      static int controller;
      static int nbreLevelxFinis;
  //    static TimeSpan time;

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
      public static int MusicVolume; // de 0 à 100
      public static int SoundEffectVolume; // de 0 à 100
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
      public static int KeyboardMode // 0 = false || 1 = true
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
      public static int NbLevelxCompletes // 1,2,3,4,5,6,7,8
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
      //{
      //   get { return time; }
      //   set
      //   {
      //      value = new TimeSpan(value.Hours, value.Minutes,int.Parse( string.Format("00", value.Seconds)));
      //      time = value;
      //      //a.Seconds = string.Format("00", value.Seconds);
      //      //if (value = strSeconds )
      //      //{
      //      //   language = value;
      //      //}
      //      //else
      //      //{
      //      //   //throw new ArgumentException("Language invalide");
      //      //   language = (int)Languages.French;
      //      //}
      //   }
      //}

      public static List<string> FrenchList { get; private set; }
      public static List<string> EnglishList  { get; private set; }
      public static List<string> SpanishList { get; private set; }
      public static List<string> JapaneseList { get; private set; }

      public static List<string> CharacteristicsToDisplayList0 { get; private set; }
      public static List<string> CharacteristicsToDisplayList1 { get; private set; }
      public static List<string> CharacteristicsToDisplayList2 { get; private set; }
      public static bool[] GameExists;

      public static void InitGameDataManager(StreamReader reader)
      {
         for (int i = 0; i < NBRE_CARACTÉRISTIQUES; i++)
         {
            string line = reader.ReadLine();
            string[] parts = line.Split(new string[] { ": " }, StringSplitOptions.None);
            int characteristic = int.Parse(parts[1]);

            switch (i)
            {
               case 0:
                  MusicVolume = characteristic;
                  break;
               case 1:
                  SoundEffectVolume = characteristic;
                  break;
               case 2:
                  Language = characteristic;
                  break;
               case 3:
                  RenderDistance = characteristic;
                  break;
               case 4:
                  Fps = characteristic;
                  break;
               case 5:
                  FullscreenMode = characteristic;
                  break;
               case 6:
                  KeyboardMode = characteristic;
                  break;
            }          
         }
         reader.Close();
      }

      static GameDataManager()
      {
         FrenchList = new List<string>();
         EnglishList  = new List<string>();
         SpanishList = new List<string>();
         JapaneseList = new List<string>();
         CharacteristicsToDisplayList0 = new List<string>();
         CharacteristicsToDisplayList1 = new List<string>();
         CharacteristicsToDisplayList2 = new List<string>();
            PlayerList = new List<Player>();
            //InitializeComplete();
            ReadFiles("Languages","En.txt");
         ReadFiles("Languages","Es.txt");
         ReadFiles("Languages","Jp.txt");
         ReadFiles("Languages","Fr.txt");


            RefreshSaves();
      }

        static void InitializeComplete()
        {
            Complete = new List<bool>[3];
            for (int i = 0; i < 3; ++i)
            {
                Complete[i] = new List<bool>();
            }
        }

        public static void RefreshSaves()
        {
            InitializeComplete();
            CheckForExistingGames();
            if (GameExists[0])
            {
                ReadFiles("Saves", "save0.txt");
            }

            if (GameExists[1])
            {
                ReadFiles("Saves", "save1.txt");
            }
            if (GameExists[2])
            {
                ReadFiles("Saves", "save2.txt");
            }
        }

        public static List<Player> PlayerList { get; private set; }

      static void ReadFiles(string folderName,string fileName)
      {
         StreamReader dataReader = new StreamReader(BASE_PATH + folderName+"/" + fileName);
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

      static void ManageSaveFiles(StreamReader dataReader,int i)
      {
         List<string> temporaryCharacteristicList = new List<string>();

         for (int j = 0; j < 6; j++)
         {
            string line_ = dataReader.ReadLine();
            string separatingSymbol = " ";
            

            switch (j)
            {
               case 0:
                  separatingSymbol = "l: ";
                  break;
               case 1:
                  separatingSymbol = "n: ";
                  break;
               case 2:
                  separatingSymbol = "n: ";
                  break;
               case 3:
                  separatingSymbol = "d: ";
                  break;
               case 4:
                  separatingSymbol = "e: ";
                  break;
               case 5:
                  separatingSymbol = "k: ";
                  break;
               //case 6:
               //   separatingSymbol = ";";
               //   break;
            }
            string[] parts_ = line_.Split(new string[] { separatingSymbol }, StringSplitOptions.None);
            temporaryCharacteristicList.Add(parts_[1]);

            //if (j == 3)
            //{

            //   string[] separator = parts[1].Split(new string[] { ":" }, StringSplitOptions.None);
            //   string timeFormater = separator[2].Remove(2);
            //   string aa = parts[1].Remove(6) + timeFormater;
            //   temporaryCharacteristicList.Add(aa);
            //}
            //else
            //{

            //}



         }

            //temporaryCharacteristicList.Add(dataReader.ReadLine());   //  name  (#8)
            string line = dataReader.ReadLine();
            string[] parts = line.Split(new char[] { ';' });
            for (int j = 0; j < parts.Length; ++j)
            {
                Complete[i].Add(bool.Parse(parts[j]));
            }
            //   string lineRead = dataReader.ReadLine();
            //   string[] timeSeparator = lineRead.Split(new string[] { ";" }, StringSplitOptions.None);
            //   for (int k = 0; k < NUM_LEVELS; k++)
            //{
            //   //string lineRead = dataReader.ReadLine();
            //   //string[] timeSeparator = lineRead.Split(new string[] { ";" }, StringSplitOptions.None);
            //   temporaryCharacteristicList.Add(timeSeparator[/*1*/k]);                       
            //}

            AssociateGoodListToDisplay(i,temporaryCharacteristicList);
      }
        // DÉBUT
        //static void ManageSaveFiles(StreamReader dataReader, int i)
        //{
        //    List<string> temporaryCharacteristicList = new List<string>();
        //    string separatingSymbol = " ", line = "";
        //    string[] parts;

        //    for (int j = 0; j < 7; j++)
        //    {
        //        line = dataReader.ReadLine();
        //        switch (j)
        //        {
        //            case 0:
        //                separatingSymbol = "l: ";
        //                break;
        //            case 1:
        //                separatingSymbol = "n: ";
        //                break;
        //            case 2:
        //                separatingSymbol = "n: ";
        //                break;
        //            case 3:
        //                separatingSymbol = "d: ";
        //                break;
        //            case 4:
        //                separatingSymbol = "e: ";
        //                break;
        //            case 5:
        //                separatingSymbol = "k: ";
        //                break;
        //            case 6:
        //                separatingSymbol = ";";
        //                break;
        //        }
        //        parts = line.Split(new string[] { separatingSymbol }, StringSplitOptions.None);
        //        if (i != 6)
        //        {
        //            temporaryCharacteristicList.Add(parts[1]);
        //        }
        //        else
        //        {
        //            temporaryCharacteristicList.Add(parts[0]);
        //            temporaryCharacteristicList.Add(parts[1]);
        //            temporaryCharacteristicList.Add(parts[2]);
        //        }
        //    }
        //    AssociateGoodListToDisplay(i, temporaryCharacteristicList);

        //    // temporaryCharacteristicList.Add(dataReader.ReadLine());   //  name  (#8)

        //    ManageTime(dataReader, dataReader.ReadLine());

        //}

        //static void AssociateGoodListToDisplay(int i, List<string> temporaryCharacteristicList)
        //{
        //    switch (i)
        //    {
        //        case 0:
        //            CharacteristicsToDisplayList0 = temporaryCharacteristicList;
        //            break;
        //        case 1:
        //            CharacteristicsToDisplayList1 = temporaryCharacteristicList;
        //            break;
        //        case 2:
        //            CharacteristicsToDisplayList2 = temporaryCharacteristicList;
        //            break;
        //    }
        //}

        //static void ManageTime(StreamReader dataReader, string namePlayer)
        //{
        //    string line;
        //    string[] timeSpanSeparator, parts;

        //    List<TimeSpan> temporaryTimeList = new List<TimeSpan>();
        //    for (int k = 0; k < NUM_LEVELS; k++)
        //    {
        //        line = dataReader.ReadLine();
        //        parts = line.Split(new string[] { ";" }, StringSplitOptions.None);
        //        timeSpanSeparator = parts[1].Split(new string[] { ":" }, StringSplitOptions.None);
        //        temporaryTimeList.Add(new TimeSpan(int.Parse(timeSpanSeparator[0]),
        //                                              int.Parse(timeSpanSeparator[1]),
        //                                              int.Parse(timeSpanSeparator[2])));
        //    }
        //    Player player = new Player(namePlayer, temporaryTimeList[0], temporaryTimeList[1],
        //                                          temporaryTimeList[2], temporaryTimeList[3],
        //                                          temporaryTimeList[4], temporaryTimeList[5],
        //                                          temporaryTimeList[6], temporaryTimeList[7]);
        //    PlayerList.Add(player);
        //}
        // FIN
        static List<bool>[] Complete { get; set; }

        public static int CountComplete(int i)
        {
            int numCompleted = 0;

            foreach (bool e in Complete[i])
            {
                if (e)
                {
                    ++numCompleted;
                }
            }
            return numCompleted;
        }

        public static int CountLevels(int i)
        {
            return Complete[i].Count;
        }

        static void AssociateGoodListToDisplay(int i,List<string> temporaryCharacteristicList)
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

      static void CheckForExistingGames()
      {
         StreamReader r;

         GameDataManager.GameExists = new bool[3];
         for (int i = 0; i < 3; ++i)
         {
            r = new StreamReader("../../Saves/save" + i + ".txt");
            GameDataManager.GameExists[i] = r.ReadLine() != "";
            r.Close();
         }
      }


      //string lineRead = dataReader.ReadLine();
      //string[] separator = lineRead.Split(new string[] { "l: " }, StringSplitOptions.None);
      //temporaryCharacteristicList.Add(separator[1]);

      //lineRead = dataReader.ReadLine();
      //separator = lineRead.Split(new string[] { "n: " }, StringSplitOptions.None);
      //temporaryCharacteristicList.Add(separator[1]);

      //lineRead = dataReader.ReadLine();
      //separator = lineRead.Split(new string[] { "n: " }, StringSplitOptions.None);
      //temporaryCharacteristicList.Add(separator[1]);

      //lineRead = dataReader.ReadLine();
      //separator = lineRead.Split(new string[] { "d: " }, StringSplitOptions.None);
      //temporaryCharacteristicList.Add(separator[1]);

      //lineRead = dataReader.ReadLine();
      //separator = lineRead.Split(new string[] { "e: " }, StringSplitOptions.None);   //   #5
      //temporaryCharacteristicList.Add(separator[1]);

      //lineRead = dataReader.ReadLine();
      //separator = lineRead.Split(new string[] { "k: " }, StringSplitOptions.None);
      //temporaryCharacteristicList.Add(separator[1]);


      //lineRead = dataReader.ReadLine();
      //separator = lineRead.Split(new string[] { ";" }, StringSplitOptions.None);    //   #7
      //temporaryCharacteristicList.Add(separator[1]);

      //-----------------------------------------------------------------------------------------------------------------
      // Caracteristiques du participant (1 name,8 time)
      //    temporaryCharacteristicList.Add(dataReader.ReadLine());   //  false;false;false
   }
}

