using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using MobileAppDev.Models;

namespace MobileAppDev.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<BirdModel>().Wait();
        }

        public Task<List<BirdModel>> GetNotesAsync()
        {
            //Get all notes.
            return database.Table<BirdModel>().ToListAsync();
        }

        public Task<BirdModel> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<BirdModel>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(BirdModel item)
        {
            if (item.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(item);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteNoteAsync(BirdModel item)
        {
            // Delete a note.
            return database.DeleteAsync(item);
        }

        public async Task<ObservableCollection<BirdModel>> GetBirdsListAsync()
        {
            List<BirdModel> list = await database.Table<BirdModel>().ToListAsync();
            ObservableCollection<BirdModel> result = new ObservableCollection<BirdModel>(list);

            return result;
        }
    }
}
