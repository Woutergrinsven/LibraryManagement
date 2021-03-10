using Bibliotheek.Database;
using Bibliotheek.Models.Data;
using Bibliotheek.Models.DTO;
using Bibliotheek.Models.ViewModel.Book;
using Bibliotheek.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Bibliotheek.Controllers
{
    public class BookController : BaseController
    {
        private readonly MongoBase _database;
        private readonly IBookService _bookService;
        public BookController(MongoBase database, IBookService bookService) : base()
        {
            _database = database;
            _bookService = bookService;
        }

        // Views.
        public ActionResult Index()
        {
            var viewModel = new BookListViewModel
            {
                AllBooks = _database.GetCollection<Book>(Book.CollectionName)
            };
            return View(viewModel);
        }

        public ActionResult Details(string id)
        {
            var objectId = new ObjectId(id);
            var book = _database.FindOneById<Book>(Book.CollectionName, objectId);
            return View(new BookViewModel { Id = book.Id.ToString(), Author = book.Author, Title = book.Title });
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        // API.
        [HttpPut]
        public ActionResult Create([FromBody] BookCreateModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Title)
                    || string.IsNullOrEmpty(model.Author))
                {
                    var result = new ContentResult();
                    result.Content = "Invalid data.";
                    return result;
                }

                _bookService.Create(model.Title, model.Author);

                return Redirect("/Home/index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(BookEditModel newModel)
        {
            try
            {
                if (string.IsNullOrEmpty(newModel.Title)
                    || string.IsNullOrEmpty(newModel.Author))
                {
                    var result = new ContentResult();
                    result.Content = "Invalid data.";
                    return result;
                }

                _bookService.Edit(newModel.Id, newModel.Title, newModel.Author);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                _bookService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
