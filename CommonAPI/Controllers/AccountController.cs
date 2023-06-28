using System.Security.Cryptography;
using System.Text;
using CommonAPI.Data;
using CommonAPI.DTOs;
using CommonAPI.Entities;
using CommonAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommonAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        readonly DataContext _context;
        readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            this._context = context;
            this._tokenService = tokenService;
        }

        [HttpPost("register")] // POST: api/account/register
        public async Task<ActionResult<User>> RegisterUser(RegisterDto registerDto)
        {
            if (await UserExsits(registerDto.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = registerDto.Username.ToLower(),
                PwdHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PwsSalt = hmac.Key
            };

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        async Task<bool> UserExsits(string username)
        {
            return await _context.users.AnyAsync(x => x.UserName.Equals(username.ToLower()));
        }

        [HttpPost("login")] // POST: api/account/login
        public async Task<ActionResult<UserDto>> LoginUser(LoginDto loginDto)
        {
            var user = await _context.users.SingleOrDefaultAsync(
                x => x.UserName == loginDto.Username.ToLower()
            );

            if (user.Equals(null)) return Unauthorized();

            using var hmac = new HMACSHA512(user.PwsSalt);
            var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computerHash.Length; i++){
                if (computerHash[i] != user.PwdHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto{
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}