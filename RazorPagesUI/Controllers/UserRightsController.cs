using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPagesUI.Data;

namespace RazorPagesUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRightsController : ControllerBase
    {
        private readonly SurveyDbContext _context;

        public UserRightsController(SurveyDbContext context)
        {
            _context = context;
        }

        // GET: api/UserRights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRight>>> GetUserRight()
        {
          if (_context.UserRight == null)
          {
              return NotFound();
          }
            return await _context.UserRight.ToListAsync();
        }

        // GET: api/UserRights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRight>> GetUserRight(Guid id)
        {
          if (_context.UserRight == null)
          {
              return NotFound();
          }
            var userRight = await _context.UserRight.FindAsync(id);

            if (userRight == null)
            {
                return NotFound();
            }

            return userRight;
        }

        // PUT: api/UserRights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRight(Guid id, UserRight userRight)
        {
            if (id != userRight.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userRight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserRights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRight>> PostUserRight(UserRight userRight)
        {
          if (_context.UserRight == null)
          {
              return Problem("Entity set 'SurveyDbContext.UserRight'  is null.");
          }
            _context.UserRight.Add(userRight);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserRightExists(userRight.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserRight", new { id = userRight.UserId }, userRight);
        }

        // DELETE: api/UserRights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRight(Guid id)
        {
            if (_context.UserRight == null)
            {
                return NotFound();
            }
            var userRight = await _context.UserRight.FindAsync(id);
            if (userRight == null)
            {
                return NotFound();
            }

            _context.UserRight.Remove(userRight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRightExists(Guid id)
        {
            return (_context.UserRight?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
