using Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class OfferRepository
    {
        private readonly IMongoCollection<Offer> _collection;

        public OfferRepository(NoSqlDataContext context)
        {
            _collection = context.Offers;
        }


        public async Task<Offer> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Offer>> GetOffersByLocationAsync(string location)
        {
            var filter = Builders<Offer>.Filter.Eq(o => o.Location, location);
            var offers = await _collection.Find(filter).ToListAsync();
            return offers;
        }

        public async Task<IEnumerable<Offer>> GetAllAsync()
        {
            return await _collection.Find(filter: _ => true).ToListAsync();
        }

        public async Task InsertAsync(Offer offer)
        {
            await _collection.InsertOneAsync(offer);
        }

        public async Task UpdateAsync(string id, Offer offer)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, offer);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
