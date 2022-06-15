using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MobileAppDev.Models;
using Xamarin.Forms;

namespace MobileAppDev.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class BirdEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadBird(value);
            }
        }

        public BirdEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new BirdModel();
        }

        async void LoadBird(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                BirdModel Bird = await App.Database.GetNoteAsync(id);
                BindingContext = Bird;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load Sighting.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //Runs if either name or location filled-in
            if (!string.IsNullOrWhiteSpace(CommonEntry.Text) || !string.IsNullOrWhiteSpace(locationEntry.Text))
            {
                await App.Database.SaveNoteAsync(new BirdModel //Creates new Bird object & Saves to DB
                {
                    Species = SpeciesEntry.Text,
                    CommonName = CommonEntry.Text,
                    Location = locationEntry.Text,
                    DateSeen = datePicker.Date,
                    Notes = NotesEntry.Text
                });
                await Shell.Current.GoToAsync("..");
            }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var Birdobj = (BirdModel)BindingContext;
            await App.Database.DeleteNoteAsync(Birdobj);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}