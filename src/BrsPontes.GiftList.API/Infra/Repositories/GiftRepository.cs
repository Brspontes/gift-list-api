using BrsPontes.GiftList.API.Application.Configurations;
using BrsPontes.GiftList.API.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BrsPontes.GiftList.API.Infra.Repositories
{
    public class GiftRepository : IGiftRepository
    {
        private readonly IMongoCollection<UserSelectGiftItem> mongoCollection;
        public GiftRepository(IOptions<GiftDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            mongoCollection = mongoDatabase.GetCollection<UserSelectGiftItem>(options.Value.GiftCollection);
        }

        public async Task<List<UserSelectGiftItem>> GetUnselectedItens()
        {
            var filter = Builders<UserSelectGiftItem>.Filter
                .Eq(item => item.IsSelected, false);

            var result = await mongoCollection.FindAsync(filter);
            return result.ToList();
        }

        public async Task SelectItemByUser(UserSelectGiftItem userSelectGiftItem)
        {
            var filter = Builders<UserSelectGiftItem>.Filter
            .Eq(item => item.Id, userSelectGiftItem.Id);

            var update = Builders<UserSelectGiftItem>.Update
                .Set(item => item.Gifter.Name, userSelectGiftItem.Gifter.Name)
                .Set(item => item.Gifter.Email, userSelectGiftItem.Gifter.Email)
                .Set(item => item.Gifter.Phone, userSelectGiftItem.Gifter.Phone)
                .Set(item => item.IsSelected, userSelectGiftItem.IsSelected);

            await mongoCollection.UpdateOneAsync(filter, update);
        }
    }
}
