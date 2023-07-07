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
    public class CampaignAssignmentsController : ControllerBase
    {
        private readonly SurveyDbContext _context;

        public CampaignAssignmentsController(SurveyDbContext context)
        {
            _context = context;
        }

        // GET: api/CampaignAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampaignAssignment>>> GetCampaignAssignment()
        {
          if (_context.CampaignAssignment == null)
          {
              return NotFound();
          }
            return await _context.CampaignAssignment.ToListAsync();
        }

        // GET: api/CampaignAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CampaignAssignment>> GetCampaignAssignment(Guid id)
        {
          if (_context.CampaignAssignment == null)
          {
              return NotFound();
          }
            var campaignAssignment = await _context.CampaignAssignment.FindAsync(id);

            if (campaignAssignment == null)
            {
                return NotFound();
            }

            return campaignAssignment;
        }

        // PUT: api/CampaignAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaignAssignment(Guid id, CampaignAssignment campaignAssignment)
        {
            if (id != campaignAssignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(campaignAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignAssignmentExists(id))
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

        // POST: api/CampaignAssignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CampaignAssignment>> PostCampaignAssignment(CampaignAssignment campaignAssignment)
        {
          if (_context.CampaignAssignment == null)
          {
              return Problem("Entity set 'SurveyDbContext.CampaignAssignment'  is null.");
          }
            _context.CampaignAssignment.Add(campaignAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampaignAssignment", new { id = campaignAssignment.Id }, campaignAssignment);
        }

        // DELETE: api/CampaignAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampaignAssignment(Guid id)
        {
            if (_context.CampaignAssignment == null)
            {
                return NotFound();
            }
            var campaignAssignment = await _context.CampaignAssignment.FindAsync(id);
            if (campaignAssignment == null)
            {
                return NotFound();
            }

            _context.CampaignAssignment.Remove(campaignAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampaignAssignmentExists(Guid id)
        {
            return (_context.CampaignAssignment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
