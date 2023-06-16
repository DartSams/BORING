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
    public class SurveyAnswersController : ControllerBase
    {
        private readonly SurveyDbContext _context;

        public SurveyAnswersController(SurveyDbContext context)
        {
            _context = context;
        }

        // GET: api/SurveyAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyAnswer>>> GetSurveyAnswer()
        {
          if (_context.SurveyAnswer == null)
          {
              return NotFound();
          }
            return await _context.SurveyAnswer.ToListAsync();
        }

        // GET: api/SurveyAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyAnswer>> GetSurveyAnswer(Guid id)
        {
          if (_context.SurveyAnswer == null)
          {
              return NotFound();
          }
            var surveyAnswer = await _context.SurveyAnswer.FindAsync(id);

            if (surveyAnswer == null)
            {
                return NotFound();
            }

            return surveyAnswer;
        }

        // PUT: api/SurveyAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurveyAnswer(Guid id, SurveyAnswer surveyAnswer)
        {
            if (id != surveyAnswer.SurveyId)
            {
                return BadRequest();
            }

            _context.Entry(surveyAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyAnswerExists(id))
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

        // POST: api/SurveyAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SurveyAnswer>> PostSurveyAnswer(SurveyAnswer surveyAnswer)
        {
          if (_context.SurveyAnswer == null)
          {
              return Problem("Entity set 'SurveyDbContext.SurveyAnswer'  is null.");
          }
            _context.SurveyAnswer.Add(surveyAnswer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SurveyAnswerExists(surveyAnswer.SurveyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSurveyAnswer", new { id = surveyAnswer.SurveyId }, surveyAnswer);
        }

        // DELETE: api/SurveyAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurveyAnswer(Guid id)
        {
            if (_context.SurveyAnswer == null)
            {
                return NotFound();
            }
            var surveyAnswer = await _context.SurveyAnswer.FindAsync(id);
            if (surveyAnswer == null)
            {
                return NotFound();
            }

            _context.SurveyAnswer.Remove(surveyAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurveyAnswerExists(Guid id)
        {
            return (_context.SurveyAnswer?.Any(e => e.SurveyId == id)).GetValueOrDefault();
        }
    }
}
