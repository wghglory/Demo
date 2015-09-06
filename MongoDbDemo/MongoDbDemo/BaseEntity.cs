using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbDemo
{
    public abstract class BaseEntity 
    {
        /// <summary>
        /// Gets or sets the id for this object (the primary record for an entity)
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }
    }

   
}