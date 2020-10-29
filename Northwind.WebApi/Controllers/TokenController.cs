using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.UnitOfWork;
using Northwind.WebApi.Authentication;
using System;

namespace Northwind.WebApi.Controllers
{

    [Route("api/token")]
    public class TokenController: Controller 
    {

        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unitOfWork;

        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;

        }

        [HttpPost]

        public JsonWebToken Post ([FromBody]User userLogin)
        {
            var user = _unitOfWork.User.ValidateUser(userLogin.Email, userLogin.Password);

            if (user == null)

            {
                throw new UnauthorizedAccessException();


            }

            var token = new JsonWebToken
            {

                Acces_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480 //Min
            };

            return token;   

        }

    }
}
