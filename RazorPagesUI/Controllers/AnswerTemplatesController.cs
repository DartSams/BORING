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
    public class AnswerTemplatesController : ControllerBase
    {
        private readonly SurveyDbContext _context;

        public AnswerTemplatesController(SurveyDbContext context)
        {
            _context = context;
        }

        // GET: api/AnswerTemplates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerTemplate>>> GetAnswerTemplate()
        {
          if (_context.AnswerTemplate == null)
          {
              return NotFound();
          }
            return await _context.AnswerTemplate.ToListAsync();
        }

        // GET: api/AnswerTemplates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerTemplate>> GetAnswerTemplate(Guid id)
        {
          if (_context.AnswerTemplate == null)
          {
              return NotFound();
          }
            var answerTemplate = await _context.AnswerTemplate.FindAsync(id);

            if (answerTemplate == null)
            {
                return NotFound();
            }

            return answerTemplate;
        }

        // PUT: api/AnswerTemplates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerTemplate(Guid id, AnswerTemplate answerTemplate)
        {
            if (id != answerTemplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(answerTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerTemplateExists(id))
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

        // POST: api/AnswerTemplates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnswerTemplate>> PostAnswerTemplate(AnswerTemplate answerTemplate)
        {
          if (_context.AnswerTemplate == null)
          {
              return Problem("Entity set 'SurveyDbContext.AnswerTemplate'  is null.");
          }
            _context.AnswerTemplate.Add(answerTemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnswerTemplate", new { id = answerTemplate.Id }, answerTemplate);
        }

        // DELETE: api/AnswerTemplates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerTemplate(Guid id)
        {
            if (_context.AnswerTemplate == null)
            {
                return NotFound();
            }
            var answerTemplate = await _context.AnswerTemplate.FindAsync(id);
            if (answerTemplate == null)
            {
                return NotFound();
            }

            _context.AnswerTemplate.Remove(answerTemplate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswerTemplateExists(Guid id)
        {
            return (_context.AnswerTemplate?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
