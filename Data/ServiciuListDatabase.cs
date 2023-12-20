using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programare_Clinica.Models;
using SQLite;

namespace Programare_Clinica.Data
{
    public class ServiciuListDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ServiciuListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ServiciuList>().Wait();
        }

        public Task<List<ServiciuList>> GetServiciuListsAsync()
        {
            return _database.Table<ServiciuList>().ToListAsync();
        }

        public Task<ServiciuList> GetServiciuListAsync(int id)
        {
            return _database.Table<ServiciuList>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveServiciuListAsync(ServiciuList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }

        public Task<int> DeleteServiciuListAsync(ServiciuList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
