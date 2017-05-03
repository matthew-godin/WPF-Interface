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
    public class Player
    {
        public TimeSpan TotalTime;


        public string Name { get; private set; }
        public List<TimeSpan> PlayerTimeList { get; private set; }


        public Player(string name, TimeSpan levelTime1, TimeSpan levelTime2, TimeSpan levelTime3,
                                  TimeSpan levelTime4, TimeSpan levelTime5, TimeSpan levelTime6,
                                  TimeSpan levelTime7, TimeSpan levelTime8)
        {
            PlayerTimeList = new List<TimeSpan>();
            Name = name;
            PlayerTimeList.Add(levelTime1);
            PlayerTimeList.Add(levelTime2);
            PlayerTimeList.Add(levelTime3);
            PlayerTimeList.Add(levelTime4);
            PlayerTimeList.Add(levelTime5);
            PlayerTimeList.Add(levelTime6);
            PlayerTimeList.Add(levelTime7);
            PlayerTimeList.Add(levelTime8);

            TotalTime = DetermineTotalTime();
        }

        TimeSpan DetermineTotalTime()
        {
            TimeSpan totalTime = TimeSpan.Zero;
            for (int i = 0; i < 8; i++)
            {
                totalTime += PlayerTimeList[i];
            }
            return totalTime;
        }


    }
}
