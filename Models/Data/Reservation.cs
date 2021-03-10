using MongoDB.Bson;
using System;

namespace Bibliotheek.Models.Data
{
    public class Reservation : DataModelBase
    {
        public static string CollectionName => "reservations";
        public ObjectId UserId { get; private set; }
        public ObjectId BookId { get; private set; }
        public DateTime ReservedAtUtc { get; private set; }

        public Reservation(ObjectId userId, ObjectId bookId, DateTime reservedAtUtc)
        {
            UserId = userId;
            BookId = bookId;
            ReservedAtUtc = reservedAtUtc;
        }
    }
}
