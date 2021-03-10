using MongoDB.Bson;

namespace Bibliotheek.Models.Data
{
    public abstract class DataModelBase
    {
        public ObjectId Id { get; private set; }
    }
}
