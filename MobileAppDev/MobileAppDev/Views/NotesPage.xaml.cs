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

        //This method is called when the page loads, creating and populating the list with any existing notes
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();

            var files = Directory.EnumerateFiles(App.Folderpath, "*notes.txt");
            foreach (var filename in files)
            {
                notes.Add(new Note
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                }
                    );
            }

            collectionView.ItemsSource = notes
                .OrderBy(d => d.Date)
                .ToList();
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
            if (e.CurrentSelection !=null)
            {
                // navigates to to NoteEntryPage passing the filename

                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)} ?{nameof(NoteEntryPage.ItemId)} = {note.Filename}");
            }
        }
    }
}