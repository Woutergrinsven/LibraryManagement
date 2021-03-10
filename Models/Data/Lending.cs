using MongoDB.Bson;
using System;

namespace Bibliotheek.Models.Data
{
    public class Lending : DataModelBase
    {
        public static string CollectionName => "lendings";
        public ObjectId UserId { get; private set; }
        public ObjectId BookId { get; private set; }
        public DateTime StartDateUtc { get; private set; }
        public DateTime EndDateUtc { get; private set; }

        public Lending(ObjectId userId, ObjectId bookId, DateTime startDateUtc, DateTime endDateUtc)
        {
            UserId = userId;
            BookId = bookId;
            StartDateUtc = startDateUtc;
            EndDateUtc = endDateUtc;
        }
    }
}
