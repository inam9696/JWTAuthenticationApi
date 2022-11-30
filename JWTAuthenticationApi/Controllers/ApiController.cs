using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWTAuthenticationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        //[Authorize]
        [HttpGet("getWithAny")]
        public IActionResult GetWithAny()
        {
            return Ok(new { Message = $"Hello to Code Maze {GetUsername()}" });
        }



        //[HttpGet("getWithSecondJwt")]
        //public IActionResult GetWithSecondJwt()
        //{
        //    return Ok(new { Message = $"Hello to Code Maze {GetUsername()}" });
        //}


        //[Authorize(Policy = "OnlyCookieScheme")]
        [HttpGet("getWithCookie")]
        public IActionResult GetWithCookie()
        {
            var userName = HttpContext.User.Claims
                    .Where(x => x.Type == ClaimTypes.Name)
                    .Select(x => x.Value)
                    .FirstOrDefault();

            return Content($"<p>Hello to Code Maze {userName}</p>");
        }



        [Authorize(Policy = "OnlySecondJwtScheme")]
        [HttpGet("getWithSecondJwt")]
        public IActionResult GetWithSecondJwt()
        {
            return Ok(new { Message = $"Hello to Code Maze {GetUsername()}" });
        }


       

        private string? GetUsername()
        {
            return HttpContext.User.Claims
                .Where(x => x.Type == ClaimTypes.Name)
                .Select(x => x.Value)
                .FirstOrDefault();
        }


        
    }
}
