using Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CarRepository
    {
        private readonly IMongoCollection<Car> _collection;

        public CarRepository(NoSqlDataContext context)
        {
            _collection = context.Cars;
        }


        public async Task<Car> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _collection.Find(filter: _ => true).ToListAsync();
        }

        public async Task InsertAsync(Car car)
        {
            await _collection.InsertOneAsync(car);
        }

        public async Task UpdateAsync(string id, Car car)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id,car);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
