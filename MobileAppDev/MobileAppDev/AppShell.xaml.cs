using Xamarin.Forms;
using MobileAppDev.Views;

namespace MobileAppDev
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            //As the Note Entry Page isn't needed by users until they wish to make a note the route the app needs is registered in here
            InitializeComponent();
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
        }
    }
}
