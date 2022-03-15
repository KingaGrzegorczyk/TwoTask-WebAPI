using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.JwtHelpers;
using Microsoft.AspNetCore.Http;

namespace TwoTaskWebAPI.Extensions
{
    public static class UserExtension
    {
        public static Guid GetUserId(this HttpContext context)
        {
            return Guid.Parse(context.User.Claims.First(c => c.Type == "Id").Value);
        }
    }
}