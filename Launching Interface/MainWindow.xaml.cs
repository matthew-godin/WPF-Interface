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
using System.IO;

namespace Launching_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      public MainWindow()
      {
         
         InitializeComponent();
         List<string> ListReceived = new List<string>();

         StreamReader dataReader = new StreamReader("../../Saves/save.txt");
         while (!dataReader.EndOfStream)
         {
            ListReceived.Add( dataReader.ReadLine());           
         }
         dataReader.Close();

         if (ListReceived[1] == "true")
         {
            MainFrame.Navigate(new InGameMenu());
         }
         else
         {
            MainFrame.Navigate(new MainPage());
         }
          
         
      }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            MainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
         
        }
    }
}