using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using LoanRimender.Models;
using System.Linq.Expressions;
using LoanRimender.Modelos;

namespace LoanRimender.Data
{
    public class RimenderDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public RimenderDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Rimender>().Wait();
            _database.CreateTableAsync<Prestamo>().Wait();
        }

        public Task<List<Rimender>> GetClientesAsync()
        {
            return _database.Table<Rimender>().ToListAsync();
           
        }



        //metodo para cargar lista de clientes que no tienen prestamo activos.

        public Task<List<Prestamo>> GetListNewLoan()
        {
            return _database.QueryAsync<Prestamo>("select * from Prestamo where debe = false AND MontoF = 0");
        }
        public  Task<Rimender> GetNoteAsync(int id)
        {
            return _database.Table<Rimender>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();


        }


      

        //save costumers
        public Task<int> SaveClienteAsync(Rimender rimender)
        {
            if (rimender.ID != 0)
            {
                return _database.UpdateAsync(rimender);
            }
            else
            {
                return _database.InsertAsync(rimender);
            }
        }

        //save loan
        public Task<int> SavePrestamoAsync(Prestamo prestamo)
        {
            if (prestamo.ID != 0)
            {
                return _database.UpdateAsync(prestamo);
            }
            else
            {
                return _database.InsertAsync(prestamo);
            }
        }

        //Delete clientes
        public Task<int> DeleteClienteAsync(Rimender note)
        {
            return _database.DeleteAsync(note);
        }

        //
        



    }
}
