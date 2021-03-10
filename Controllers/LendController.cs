using Bibliotheek.Models.DTO;
using Bibliotheek.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Bibliotheek.Controllers
{
    public class LendController : BaseController
    {
        private readonly ILendService _lendService;
        public LendController(ILendService lendService) : base()
        {
            _lendService = lendService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Book(LendBookModel model)
        {
            if (model == null
                || string.IsNullOrEmpty(model.Id)
                || model.StartDate == null
                || model.EndDate == null)
            {
                return BadRequest("Invalid data was provided.");
            }

            var bookId = new ObjectId(model.Id);
            _lendService.LendBook(LoggedInUserId, bookId, model.StartDate.ToUniversalTime(), model.EndDate.ToUniversalTime());

            return Ok();
        }
    }
}
