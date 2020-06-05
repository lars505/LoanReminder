using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using LoanRimender.Models;

namespace LoanRimender.Data
{
    public class RimenderDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public RimenderDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Rimender>().Wait();
        }

        public Task<List<Rimender>> GetClientesAsync()
        {
            return _database.Table<Rimender>().ToListAsync();
        }

        public Task<Rimender> GetClientesAsync(int id)
        {
            return _database.Table<Rimender>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveClienteAsync(Rimender note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteClienteAsync(Rimender note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
