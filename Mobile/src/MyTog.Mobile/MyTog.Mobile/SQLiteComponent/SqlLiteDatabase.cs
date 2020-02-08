using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    public class SqlLiteDatabase<T> where T : IRecord, new()
    {
        private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer =
            new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags));

        private static bool initialized;

        public SqlLiteDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        private static SQLiteAsyncConnection Database => lazyInitializer.Value;

        private async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (Database.TableMappings.All(m => m.MappedType.Name != typeof(T).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(T)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<T>> GetItemsAsync()
        {
            return Database.Table<T>().ToListAsync();
        }

        public Task<List<T>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<T>($"SELECT * FROM [{typeof(T).Name}] WHERE [Done] = 0");
        }

        public Task<T> GetItemAsync(int id)
        {
            return Database.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(T item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }

            return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(T item)
        {
            return Database.DeleteAsync(item);
        }
    }
}