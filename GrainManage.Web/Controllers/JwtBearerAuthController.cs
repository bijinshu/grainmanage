using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GrainManage.Web.Controllers
{
    public class JwtBearerAuthController : Controller
    {
        [AllowAnonymous]
        public IActionResult Authenticate(string userName, string pwd)
        {
            var key = Encoding.ASCII.GetBytes(GlobalVar.JwtSecret);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(JwtClaimTypes.Audience,"api"),
                   new Claim(JwtClaimTypes.Issuer,"bijinshu"),
                   new Claim(JwtClaimTypes.Email,"bijs@axonj.com.cn")
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                access_token = tokenString,
                token_type = "Bearer"
            });
        }
        [Authorize]
        public IActionResult Test()
        {
            return Content($"Hellow-{Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4()}");
        }
    }
}