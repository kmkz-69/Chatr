using Chatr.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Chatr
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                ViewModel.SplashScreen Splash = new ViewModel.SplashScreen();
                if (Settings.Show_SplashScreen)
                { Splash.Show(); }
              

                if (File.Exists(Settings.KeepMe) && File.Exists(Settings.SessionID) && File.Exists(Settings.UserID))
                {

                    string aa = File.ReadAllText(Settings.UserID);
                    string bb = File.ReadAllText(Settings.SessionID);
                    string dd = File.ReadAllText(Settings.KeepMe);
                    string TextID = aa.Replace("\r\n", "");
                    string sessionIDText = bb.Replace("\r\n", "");
                    string keepmeText = dd.Replace("\r\n", "");

                    if (keepmeText == "1" && sessionIDText != "" && TextID != "")
                    {
                        //MainForm Mainform = new MainForm();
                        //Thread.Sleep(1000);
                        Splash.Close();
                        MainWindow.Show();
                    }
                    else
                    {
                        MainWindow SignIn = new MainWindow();
                        Thread.Sleep(1000);
                        Splash.Close();
                        SignIn.ShowDialog();
                    }

                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(Settings.FolderDestination + "\\" + Settings.AppName);
                    string[] lines3 = { "0" }; System.IO.File.WriteAllLines(Settings.KeepMe, lines3);
                    string[] lines2 = { "" }; System.IO.File.WriteAllLines(Settings.SessionID, lines2);
                    string[] lines = { "" }; System.IO.File.WriteAllLines(Settings.UserID, lines);
                    MainWindow SignIn = new MainWindow();
                    SignIn.ShowDialog();
                }


            }
            catch { }

        }
    }
}
