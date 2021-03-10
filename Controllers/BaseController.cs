using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Security.Claims;

namespace Bibliotheek.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        public ObjectId LoggedInUserId
        {
            get
            {
                if (User == null) throw new ArgumentException();
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return new ObjectId(userId);
            }
        }
    }
}
