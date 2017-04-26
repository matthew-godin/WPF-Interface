using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Launching_Interface
{
   class Player
   {
      string Name { get; set; }
      public TimeSpan TempsLevel1 { get; private set; }
      public TimeSpan TempsLevel2 { get; private set; }
      public TimeSpan TempsLevel3 { get; private set; }

      
      public Player(string name, TimeSpan levelTime1, TimeSpan levelTime2, TimeSpan levelTime3)
      {
         Name = name;
         TempsLevel1 = levelTime1;
         TempsLevel2 = levelTime2;
         TempsLevel3 = levelTime3;
      }

      void ReadPlayerFile(int i)
      {
         StreamReader dataReader = new StreamReader("../../Saves/save" + i + ".txt");
         while (!dataReader.EndOfStream)
         {
            for (int j = 0; j < 5; j++)
            {
               dataReader.ReadLine();
            }
            

            string lineRead = dataReader.ReadLine();
           

            //lineRead = dataReader.ReadLine();
            //separator = lineRead.Split(new string[] { "k: " }, StringSplitOptions.None);
            //ElementsToShowList.Add(separator[1]);
         }
         dataReader.Close();
      }

   }
}
