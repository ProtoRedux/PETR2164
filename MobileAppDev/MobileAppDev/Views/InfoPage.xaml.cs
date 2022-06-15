
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }
        async void OnButtonRSPBClicked(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://www.rspb.org.uk/birds-and-wildlife/wildlife-guides/birdwatching/");
        }

        async void OnButtonNATTREKClicked(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://www.naturetrek.co.uk/tour-focus/beginner-birding");
        }
        async void OnButtonBSPOTClicked(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://www.birdspot.co.uk/bird-watching-for-beginners");
        }
    }
}