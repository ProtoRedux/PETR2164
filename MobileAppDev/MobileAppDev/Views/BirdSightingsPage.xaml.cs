using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MobileAppDev.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileAppDev.Views;
using System.Collections.ObjectModel;


namespace MobileAppDev.Views
{
    public partial class BirdSightingsPage : ContentPage
    {
        //observable collection to allow list to update in realtime once a swipe delete action is carried out see in database for initial code
        public ObservableCollection<BirdModel> Listings { get; set; }
        //sets up initial views to allow for swipe menues
        List<SwipeView> SwipeViews { get; set; }

        public BirdSightingsPage()
        {
            InitializeComponent();
            //Creates a new list for swipeViews
            SwipeViews = new List<SwipeView>();
        }

        //This method is called when the page loads, creating and populating the list with any existing notes from the database
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the listings public Observable collection on line 17.
            Listings = await App.Database.GetBirdsListAsync();
            collectionView.ItemsSource = Listings; 
        }
        //Method to access the delete function via swiping rather than selecting the object and the pressing the delete button
        private void DeleteEntry_Swipe(object sender, EventArgs e)
        {
            //finds the instance that the user is touching and makes it the swipeitm
            SwipeItem currentswipe = sender as SwipeItem;
            //sets the current instance as the target for deletion
            BirdModel target = (BirdModel)currentswipe.CommandParameter;
            _ =App.Database.DeleteNoteAsync(target);
            _ = Listings.Remove(target);
        }

        //Closes open swipe views when swiping on a new item
        private void SwipeView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {

            if (SwipeViews.Count == 1)
            {
                SwipeViews[0].Close();
                _ = SwipeViews.Remove(SwipeViews[0]);
            }
        }

        private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            SwipeView swipeview = sender as SwipeView;
            SwipeViews.Add(swipeview);
        }



        //This method is called when the add button is clicked and moves the user to the entry page
        async void OnAddClicked(object sender, EventArgs e)
        {
            //will move to NoteEntryPage without passing any data
            await Shell.Current.GoToAsync(nameof(BirdEntryPage));
        }
        //This method is called if the user selects an existing note from the collectionview this method passes the data contained in the existing note
        //into the correct fields of the note entry page 
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                BirdModel target = (BirdModel)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(BirdEntryPage)}?{nameof(BirdEntryPage.ItemId)}={target.ID.ToString()}");
            }
        }

    }
}