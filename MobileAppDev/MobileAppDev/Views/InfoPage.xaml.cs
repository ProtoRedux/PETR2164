
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

        async void OnButtonNATTREKlicked(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://www.rspb.org.uk/birds-and-wildlife/wildlife-guides/birdwatching/");
        }
        async void OnButtonBSPOTClicked(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://www.rspb.org.uk/birds-and-wildlife/wildlife-guides/birdwatching/");
        }
    }
}