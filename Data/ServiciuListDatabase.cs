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
            _database.CreateTableAsync<Serviciu>().Wait();

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
        public Task<int> SaveProgramareAsync(Programare Programare)
        {
            if (Programare.ID != 0)
            {
                return _database.UpdateAsync(Programare);
            }
            else
            {
                return _database.InsertAsync(Programare);
            }
        }
        public Task<int> DeleteProgramareAsync(Programare Programare)
        {
            return _database.DeleteAsync(Programare);
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
        public Task<List<Programare>> GetListProgramariAsync(int serviciulistid)
        {
            return _database.QueryAsync<Programare>(
        "select P.ID, P.Descriere from Programare P"
        + " inner join ListProgramare LP"
        + " on P.ID = LP.ProgramareID where LP.ServiciuListID = ?",
        serviciulistid);
        }
        public Task<List<Serviciu>> GetServiciiAsync()
        {
            return _database.Table<Serviciu>().ToListAsync();
        }
        public Task<int> SaveServiciuAsync(Serviciu serviciu)
        {
            if (serviciu.ID != 0)
            {
                return _database.UpdateAsync(serviciu);
            }
            else
            {
                return _database.InsertAsync(serviciu);
            }
        }
        public Task<int> DeleteServiciuAsync(Serviciu serviciu)
        {
            return _database.DeleteAsync(serviciu);
        }
    }
}
