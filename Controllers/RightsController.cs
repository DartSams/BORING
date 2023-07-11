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
    public class RightsController : ControllerBase
    {
        private readonly SurveyDbContext _context;

        public RightsController(SurveyDbContext context)
        {
            _context = context;
        }

        // GET: api/Rights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Right>>> GetRight()
        {
          if (_context.Right == null)
          {
              return NotFound();
          }
            return await _context.Right.ToListAsync();
        }

        // GET: api/Rights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Right>> GetRight(int id)
        {
          if (_context.Right == null)
          {
              return NotFound();
          }
            var right = await _context.Right.FindAsync(id);

            if (right == null)
            {
                return NotFound();
            }

            return right;
        }

        // PUT: api/Rights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRight(int id, Right right)
        {
            if (id != right.Id)
            {
                return BadRequest();
            }

            _context.Entry(right).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RightExists(id))
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

        // POST: api/Rights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Right>> PostRight(Right right)
        {
          if (_context.Right == null)
          {
              return Problem("Entity set 'SurveyDbContext.Right'  is null.");
          }
            _context.Right.Add(right);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRight", new { id = right.Id }, right);
        }

        // DELETE: api/Rights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRight(int id)
        {
            if (_context.Right == null)
            {
                return NotFound();
            }
            var right = await _context.Right.FindAsync(id);
            if (right == null)
            {
                return NotFound();
            }

            _context.Right.Remove(right);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RightExists(int id)
        {
            return (_context.Right?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
