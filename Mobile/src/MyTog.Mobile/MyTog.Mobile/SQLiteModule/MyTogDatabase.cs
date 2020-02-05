using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace Kalinkin.MyTog.Mobile.SQLiteModule
{
    public class MyTogDatabase
    {
        private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        private static bool initialized;

        public MyTogDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        private static SQLiteAsyncConnection Database => lazyInitializer.Value;

        private async Task InitializeAsync()
        {
            if (!initialized)
                if (Database.TableMappings.All(m => m.MappedType.Name != typeof(LoginResult).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(LoginResult)).ConfigureAwait(false);
                    initialized = true;
                }
        }

        public Task<List<LoginResult>> GetItemsAsync()
        {
            return Database.Table<LoginResult>().ToListAsync();
        }

        public Task<List<LoginResult>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<LoginResult>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<LoginResult> GetItemAsync(int id)
        {
            return Database.Table<LoginResult>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(LoginResult item)
        {
            if (item.ID != 0)
                return Database.UpdateAsync(item);
            return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(LoginResult item)
        {
            return Database.DeleteAsync(item);
        }
    }
}