using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MobileAppDev.Models;
using Xamarin.Forms;

namespace MobileAppDev.Views
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        //This method is called when the page loads, creating and populating the list with any existing notes from the database
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }
        //This method is called when the add button is clicked and moves the user to the note entry page
        async void OnAddClicked(object sender, EventArgs e)
        {
            //will move to NoteEntryPage without passing any data
            await Shell.Current.GoToAsync(nameof(NoteEntryPage));
        }
        //This method is called if the user selects an existing note from the collectionview this method passes the data contained in the existing note
        //into the correct fields of the note entry page 
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)}?{nameof(NoteEntryPage.ItemId)}={note.ID.ToString()}");
            }
        }
    }
}