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
    public class ManageStudentController : ControllerBase
    {
        private readonly Context _context;

        public ManageStudentController(Context context)
        {
            _context = context;
        }

        // GET: api/Students/5
        [HttpGet("{id}/Assigments")]
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

        // PUT: api/AssigmentStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/Assigments")]
        public async Task<IActionResult> PutAssigmentStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                var st = _context.Student.Include(s => s.Assigments).Where(x => x.Id == student.Id).First();
                var asigment = (List<Assigment>)student.Assigments;
                if (asigment.Any())
                {
                    asigment.ForEach(item => st.Assigments.Add(item));
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssigmentStudentExists(id))
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

        [HttpPost("{id}/Assigments")]
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

        private bool AssigmentStudentExists(int id)
        {
            return _context.AssigmentStudent.Any(e => e.AssigmentId == id);
        }
    }
}
