using MongoDB.Bson;
using MongoDB.Driver;
using source.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace source.Service.Data
{
    public sealed class NoSql : INoSql
    {
        private readonly MongoClient client;
        private readonly string _databaseName;
        private bool disposedValue = false;

        public NoSql()
        {
            client = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            _databaseName = "QueroDoar";
        }

        private IMongoCollection<T> GetCollection<T>()
        {
            string _nameCollection = typeof(T).Name;
            var database = client.GetDatabase(_databaseName);
            var collection = database.GetCollection<T>(_nameCollection);

            return collection;
        }

        public async Task<T> InsertOrUpdateAsync<T>(T value) where T : IModelBase
        {
            var collection = this.GetCollection<T>();

            if (value._id != ObjectId.Empty)
            {
                value = await collection.FindOneAndUpdateAsync<T>(m => m._id == value._id,
                    new ObjectUpdateDefinition<T>(value),
                    new FindOneAndUpdateOptions<T, T>()
                    {
                        IsUpsert = true
                    });
            }
            else
            {
                await collection.InsertOneAsync(value);
            }

            return value;
        }

        public async Task<IEnumerable<T>> GetDocumentsByFilter<T>(Expression<Func<T, bool>> filter) where T : IModelBase
        {
            var collection = this.GetCollection<T>();

            var _data = await collection.FindAsync<T>(filter);
            var _list = await _data.ToListAsync();
            return _list;
        }

        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> filter) where T : IModelBase
        {
            var collection = this.GetCollection<T>();

            var _data = await collection.FindAsync<T>(filter);
            var _item = await _data.FirstOrDefaultAsync();
            return _item;
        }

        public async Task<T> GetDocumentByID<T>(string _id) where T : IModelBase
        {
            var collection = this.GetCollection<T>();

            var _resultado = await collection.FindAsync<T>(m => m._id == new ObjectId(_id));
            var _result = await _resultado.FirstOrDefaultAsync();
            return _result;
        }

        public async Task<IEnumerable<T>> GetAllDocument<T>() where T : IModelBase
        {
            var collection = this.GetCollection<T>();

            var _data = await collection.FindAsync<T>(FilterDefinition<T>.Empty);
            var _list = await _data.ToListAsync();
            return _list;
        }

        public void Dispose()
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}