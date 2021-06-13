using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest.Models;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssigmentsController : ControllerBase
    {
        private readonly Context _context;

        public AssigmentsController(Context context)
        {
            _context = context;
        }

        // GET: api/Assigments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assigment>>> GetAssigment()
        {
            return await _context.Assigment
                .Include(x => x.Students)
                .AsNoTracking()
                .IgnoreAutoIncludes<Assigment>()
                .ToListAsync();
        }

        // GET: api/Assigments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assigment>> GetAssigment(int id)
        {
            var assigment = await _context.Assigment
                .Include(x => x.Students)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (assigment == null)
            {
                return NotFound();
            }

            return assigment;
        }

        // PUT: api/Assigments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssigment(int id, Assigment assigment)
        {
            if (id != assigment.Id)
            {
                return BadRequest();
            }

            _context.Entry(assigment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssigmentExists(id))
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

        // POST: api/Assigments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assigment>> PostAssigment(Assigment assigment)
        {
            var st = _context.Assigment.Include(s => s.Students).Where(x => x.Id == assigment.Id).First();
            var asigment = (List<Student>)assigment.Students;
            if (asigment.Any())
            {
                asigment.ForEach(item => st.Students.Add(item)); 
            }

            return CreatedAtAction("GetAssigment", new { id = assigment.Id }, assigment);
        }

        // DELETE: api/Assigments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssigment(int id)
        {
            var assigment = await _context.Assigment.FindAsync(id);
            if (assigment == null)
            {
                return NotFound();
            }

            _context.Assigment.Remove(assigment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssigmentExists(int id)
        {
            return _context.Assigment.Any(e => e.Id == id);
        }
    }
}
