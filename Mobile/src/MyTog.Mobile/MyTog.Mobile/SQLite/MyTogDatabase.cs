using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Kalinkin.MyTog.Mobile
{
    public class MyTogDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public MyTogDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (Database.TableMappings.All(m => m.MappedType.Name != typeof(LoginResult).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(LoginResult)).ConfigureAwait(false);
                    initialized = true;
                }
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
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(LoginResult item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
