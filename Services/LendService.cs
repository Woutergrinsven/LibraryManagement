using Bibliotheek.Database;
using Bibliotheek.Models.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Bibliotheek.Services
{
    public interface ILendService
    {
        IEnumerable<Lending> GetLendingsBook(ObjectId bookId);
        Lending GetCurrentLendingBook(ObjectId bookId);
        void LendBook(ObjectId userId, ObjectId bookId, DateTime startDateUtc, DateTime endDateUtc);

    }

    public class LendService : ILendService
    {
        private static int _maximumLendingTimeInDays = 42;
        private readonly MongoBase _database;
        public LendService(MongoBase database)
        {
            _database = database;
        }

        public IEnumerable<Lending> GetLendingsBook(ObjectId bookId)
        {
            var filter = Builders<Lending>.Filter.Eq(x => x.BookId, bookId);
            var lendings = _database.FindMultipleByFilter(Lending.CollectionName, filter);
            return lendings;
        }

        /// <summary>
        /// Gets the current active lending for a book.
        /// Returns null if there is no active lending.
        /// </summary>
        public Lending GetCurrentLendingBook(ObjectId bookId)
        {
            var filterBuilder = Builders<Lending>.Filter;
            var filter = filterBuilder.Eq(x => x.BookId, bookId)
                & filterBuilder.Lt(x => x.StartDateUtc, new BsonDateTime(DateTime.UtcNow))
                & filterBuilder.Gt(x => x.EndDateUtc, new BsonDateTime(DateTime.UtcNow));
            var lending = _database.FindOneByFilter(Lending.CollectionName, filter);
            return lending;
        }

        public void LendBook(ObjectId userId, ObjectId bookId, DateTime startDateUtc, DateTime endDateUtc)
        {
            // Check if dates are logical.
            if (startDateUtc > endDateUtc)
            {
                return;
            }

            // Check if lending time is not exceeding maximum.
            var lendTime = endDateUtc.Subtract(startDateUtc);
            if (lendTime.TotalDays > _maximumLendingTimeInDays)
            {
                return;
            }

            // Check if book exists.
            if (_database.FindOneById<Book>(Book.CollectionName, bookId) == null)
            {
                return;
            }

            // Check if book is currently lent out.
            if (GetCurrentLendingBook(bookId) != null)
            {
                return;
            }

            // Create a new lending.
            var lending = new Lending(userId, bookId, startDateUtc, endDateUtc);
            _database.Create(lending, Lending.CollectionName);
        }
    }
}
