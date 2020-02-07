using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
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
                if (Database.TableMappings.All(m => m.MappedType.Name != typeof(LoginResultRecord).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(LoginResultRecord)).ConfigureAwait(false);
                    initialized = true;
                }
        }

        public Task<List<LoginResultRecord>> GetItemsAsync()
        {
            return Database.Table<LoginResultRecord>().ToListAsync();
        }

        public Task<List<LoginResultRecord>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<LoginResultRecord>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<LoginResultRecord> GetItemAsync(int id)
        {
            return Database.Table<LoginResultRecord>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(LoginResultRecord item)
        {
            if (item.ID != 0)
                return Database.UpdateAsync(item);
            return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(LoginResultRecord item)
        {
            return Database.DeleteAsync(item);
        }
    }
}