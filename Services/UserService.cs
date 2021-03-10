using Bibliotheek.Database;
using Bibliotheek.Help;
using Bibliotheek.Models.Data;
using Bibliotheek.Models.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bibliotheek.Services
{
    public interface IUserService
    {
        bool Register(UserRegistrationModel model);
        Task<bool> Login(HttpContext httpContext, UserLoginModel model);
        void Logout(HttpContext httpContext);
    }

    public class UserService : IUserService
    {
        private readonly MongoBase _database;

        public UserService(MongoBase database)
        {
            _database = database;
        }

        public bool Register(UserRegistrationModel model)
        {
            var filterBuilder = Builders<User>.Filter;
            var filter = filterBuilder.Eq(x => x.UserName, model.Username)
                | filterBuilder.Eq(x => x.Email, model.Email);
            var duplicateEntity = _database.FindOneByFilter(User.CollectionName, filter);

            // TODO: Return message that there is a duplicate and which one is duplicate.
            if (duplicateEntity != null)
            {
                return false;
            }

            string plainPassword = model.Password;
            string hashedPassword = HashHelp.GetSha512Hash(plainPassword);

            var user = new User(model.Username, hashedPassword, model.Email);
            _database.Create(user, User.CollectionName);

            return true;
        }

        public async Task<bool> Login(HttpContext httpContext, UserLoginModel model)
        {
            // Hash login password.
            string plainPassword = model.Password;
            string hashedPassword = HashHelp.GetSha512Hash(plainPassword);

            // Find user.
            var users = _database.GetCollection<User>(User.CollectionName);
            var foundUser = users.Where(u => u.UserName.Equals(model.UserName) && u.Password.Equals(hashedPassword)).FirstOrDefault();

            if (foundUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, foundUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, foundUser.UserName),
                    new Claim(ClaimTypes.Email, foundUser.Email)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Refreshing the authentication session should be allowed.
                    AllowRefresh = true,

                    // Set login cookie duration the same as sliding login configuration in start up.
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),

                    IsPersistent = true,
                    IssuedUtc = DateTimeOffset.UtcNow
                };

                await httpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return true;
            }
            return false;
        }

        public async void Logout(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
