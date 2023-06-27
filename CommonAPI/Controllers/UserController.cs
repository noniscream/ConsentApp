using CommonAPI.Data;
using CommonAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/user
    public class UserController
    {
        public readonly DataContext _context;
        public UserController(DataContext context)
        {
            this._context = context;
        }

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