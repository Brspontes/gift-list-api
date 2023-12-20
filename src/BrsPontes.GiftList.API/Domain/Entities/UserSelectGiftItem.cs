using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BrsPontes.GiftList.API.Domain.Entities
{
    public class UserSelectGiftItem
    {
        public UserSelectGiftItem(string id, Gifter gifter, bool isSelected)
        {
            Id = id;
            Gifter = gifter;
            IsSelected = isSelected;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("images")]
        public List<string> Images { get; set; }

        [BsonElement("itemDescription")]
        public string ItemDescription { get; set; }

        [BsonElement("gifter")]
        public Gifter Gifter { get; set; }

        [BsonElement("isSelected")]
        public bool IsSelected { get; set; }
    }

    public class Gifter
    {
        public Gifter(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phoneNumber")]
        public string Phone { get; set; }
    }
}
