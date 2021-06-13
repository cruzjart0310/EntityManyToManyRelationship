using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest.Models;
using ApiTest.DTOS;
using ApiTest.Utilities;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Context _context;

        public StudentsController(Context context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable =  _context.Student
                .Include(p => p.Profile)
                .Include(a => a.Address)
                    .ThenInclude(e => e.State)
                        .ThenInclude(c => c.City)
                .Include(x => x.Assigments)
                .AsNoTracking()
                //.IgnoreAutoIncludes<Student>()
                .AsQueryable();

            await HttpContext.InsertaParametrosPaginacionEnCabecera(queryable);
            return await queryable.OrderBy(x => x.Id).Paginar(paginacionDTO).ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Student
                .Include(x => x.Assigments)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var st = _context.Student.Include(s => s.Assigments).Where(x => x.Id == student.Id).First();
            var asigment = (List<Assigment>)student.Assigments;
            if (asigment.Any())
            {
                asigment.ForEach(item => st.Assigments.Add(item));
            }
            
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetStudent", new { id = student.Id }, st);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
