using Bibliotheek.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Bibliotheek.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Create([FromRoute] string bookId)
        {
            if (string.IsNullOrEmpty(bookId))
            {
                return BadRequest("No book id was provided in the Url.");
            }

            var bookObjectId = new ObjectId(bookId);
            _reservationService.CreateReservation(LoggedInUserId, bookObjectId);
            return Ok();
        }
    }
}
