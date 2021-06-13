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
    public class ManageAssigmentController : ControllerBase
    {
        private readonly Context _context;

        public ManageAssigmentController(Context context)
        {
            _context = context;
        }


        // GET: api/ManageAssigment/5
        [HttpGet("{id}/Students")]
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

        // PUT: api/ManageAssigment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/Students")]
        public async Task<IActionResult> PutAssigmentStudent(int id, Assigment  assigment)
        {
            if (id != assigment.Id)
            {
                return BadRequest();
            }

            _context.Entry(assigment).State = EntityState.Modified;

            try
            {
                _context.Assigment.Include(s => s.Students).Where(x => x.Id == assigment.Id).First();
                var asigment = (List<Student>)assigment.Students;
                if (asigment.Any())
                {


                    _context.Assigment.UpdateRange(assigment);
                    //asigment.ForEach(item => _context.AddOrUpdate(item)) ;
                }
                //_context.Attach(asigment);
                //_context.UpdateRange(asigment);
                //_context.Assigment.Attach(assigment);

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

        // POST: api/ManageAssigment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/Students")]
        public async Task<ActionResult<Student>> PostAssigment(Assigment assigment)
        {
            var st = _context.Assigment.Include(s => s.Students).Where(x => x.Id == assigment.Id).First();
            var asigment = (List<Student>)assigment.Students;
            if (asigment.Any())
            {
                asigment.ForEach(item => st.Students.Add(item));
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAssigment", new { id = assigment.Id }, st);
        }

        private bool AssigmentStudentExists(int id)
        {
            return _context.AssigmentStudent.Any(e => e.AssigmentId == id);
        }
    }
}
