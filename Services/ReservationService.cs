using Bibliotheek.Database;
using Bibliotheek.Models.Data;
using MongoDB.Bson;
using System;

namespace Bibliotheek.Services
{
    public interface IReservationService
    {
        void CreateReservation(ObjectId userId, ObjectId bookId);
    }

    public class ReservationService : IReservationService
    {
        private readonly MongoBase _database;
        private readonly ILendService _lendService;
        public ReservationService(MongoBase database, ILendService lendService)
        {
            _database = database;
            _lendService = lendService;
        }

        // TODO: return position.
        public void CreateReservation(ObjectId userId, ObjectId bookId)
        {
            // Check if book exists.
            if (_database.FindOneById<Book>(Book.CollectionName, bookId) == null)
            {
                return;
            }

            // Check for active lending.
            var lending = _lendService.GetCurrentLendingBook(bookId);
            if (lending == null)
            {
                // Book can be lend, so no need to create reservation.
                // TODO: Maybe return useful message?
                return;
            }

            var reservation = new Reservation(userId, bookId, DateTime.UtcNow);
            _database.Create(reservation, Reservation.CollectionName);
        }
    }
}
