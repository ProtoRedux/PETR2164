using System;
using System.IO;
using Xamarin.Forms;


namespace MobileAppDev
{
    public partial class App : Application
    {
        //initialises the folderpath string used to store and recal notes.
        public static string Folderpath { get; private set; } 
        public App()
        {
            InitializeComponent();
            Folderpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
