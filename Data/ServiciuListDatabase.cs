using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Programare_Clinica.Models;

namespace Programare_Clinica.Data
{
    public class ServiciuListDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ServiciuListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ServiciuList>().Wait();
            _database.CreateTableAsync<Programare>().Wait();
            _database.CreateTableAsync<ListProgramare>().Wait();
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
        public Task<int> SaveProgramareAsync(Programare programare)
        {
            if (programare.ID != 0)
            {
                return _database.UpdateAsync(programare);
            }
            else
            {
                return _database.InsertAsync(programare);
            }
        }
        public Task<int> DeleteProgramareAsync(Programare programare)
        {
            return _database.DeleteAsync(programare);
        }
        public Task<List<Programare>> GetProgramariAsync()
        {
            return _database.Table<Programare>().ToListAsync();
        }
        public Task<int> SaveListProgramareAsync(ListProgramare listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Programare>> GetListProgramariAsync(int shoplistid)
        {
            return _database.QueryAsync<Programare>(
            "select P.ID, P.Descriere pentru Programare P"
            + " inner join ListProgramari LP"
            + " on P.ID = LP.ProgramareID where LP.ServiciuListID = ?",
            shoplistid);
        }
    }
}
