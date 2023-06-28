using CommonAPI.Data;
using CommonAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommonAPI.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        readonly DataContext _context;
        public UserController(DataContext context)
        {
            this._context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(){
            return await _context.users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int Id){
            return await _context.users.FindAsync(Id);
        }
    }
}