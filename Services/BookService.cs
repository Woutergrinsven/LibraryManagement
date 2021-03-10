using Bibliotheek.Database;
using Bibliotheek.Models.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bibliotheek.Services
{
    public interface IBookService
    {
        void Create(string title, string author);
        void Edit(string id, string title, string author);
        void Delete(string id);
    }

    public class BookService : IBookService
    {
        private readonly MongoBase _database;

        public BookService(MongoBase database)
        {
            _database = database;
        }

        public void Create(string title, string author)
        {
            var book = new Book(title, author);
            _database.Create(book, Book.CollectionName);
        }

        public void Edit(string id, string title, string author)
        {
            var update = Builders<Book>.Update
                    .Set("Title", title)
                    .Set("Author", author);
            _database.UpdateOne(Book.CollectionName, new ObjectId(id), update);
        }

        public void Delete(string id)
        {
            _database.DeleteOne<Book>(Book.CollectionName, new ObjectId(id));
        }
    }
}
