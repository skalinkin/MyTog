using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using SQLite;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    public class BaseRepository<TEntity,TRecord> : IRepository<TEntity> where TRecord : class, new()
    {
        private readonly IMapper _mapper;

        private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer =
            new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags));

        private static bool _initialized;

        public BaseRepository(IMapper mapper)
        {
            _mapper = mapper;
            InitializeAsync().SafeFireAndForget(false);
        }

        private static SQLiteAsyncConnection Database => lazyInitializer.Value;

        public async Task<bool> AddItem(TEntity item)
        {
            var record = _mapper.Map<TRecord>(item);
            return IsSuccess(await Database.InsertAsync(record));
        }

        public async Task<bool> DeleteItem(TEntity item)
        {
            var record = _mapper.Map<TRecord>(item);
            return IsSuccess(await Database.DeleteAsync(record));
        }

        public async Task<IEnumerable<TEntity>> FindItems(Expression<Func<TEntity, bool>> predicate)
        {
            var converter = new ExpressionConverter<TEntity,TRecord>();
            var recordPredicate = converter.Convert(predicate);
            var records = await Database.Table<TRecord>().Where(recordPredicate).ToListAsync();
            return _mapper.Map<List<TEntity>>(records);
        }

        public async Task<IEnumerable<TEntity>> GetAllItems()
        {
            var records = await Database.Table<TRecord>().ToListAsync();
            return _mapper.Map<List<TEntity>>(records);
        }

        public async Task<TEntity> GetItem(string pk)
        {
            //return await Database.GetAsync<TRecord>(pk);
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetItem(Expression<Func<TEntity, bool>> predicate)
        {
            //return await Database.GetAsync(predicate);
            throw new NotImplementedException();
        }

        public async Task<bool> InsertItem(TEntity item)
        {
            return IsSuccess(await Database.InsertAsync(item));
        }

        public async Task<bool> InsertItems(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                await Database.InsertAsync(item);
            }

            return true;
        }

        public async Task<bool> UpdateItem(TEntity item)
        {
            return IsSuccess(await Database.InsertOrReplaceAsync(item));
        }

        private async Task InitializeAsync()
        {
            if (!_initialized)
            {
                if (Database.TableMappings.All(m => m.MappedType.Name != typeof(TRecord).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(TRecord)).ConfigureAwait(false);
                    _initialized = true;
                }
            }
        }

        private bool IsSuccess(int rowsAffected)
        {
            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}