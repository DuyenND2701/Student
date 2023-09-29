using Microsoft.AspNetCore.Mvc;
namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
    
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var FindStudent = await _context.Students.FindAsync(id);
            if (FindStudent == null) 
                return BadRequest("Student is not found.");
            return Ok(FindStudent);
        }

        [HttpPost]
          public async Task<ActionResult<List<Student>>> AddStudent(Student student)
          {
              _context.Students.Add(student);
              await _context.SaveChangesAsync();
              return Ok(await _context.Students.ToListAsync());
          }

          [HttpPut]
          public async Task<ActionResult<List<Student>>> UpdateStudentById(Student request)
          {
              var FindStudent = await _context.Students.FindAsync(request.ID);
              if (FindStudent == null) return BadRequest("Student is not found;");
              else
              {
                  FindStudent.StudentName = request.StudentName;
                  FindStudent.StudentAddress = request.StudentAddress;
                  FindStudent.Phone = request.Phone;
                  FindStudent.Class = request.Class;
              };
            await _context.SaveChangesAsync();
              return Ok(await _context.Students.ToListAsync());
          }
          [HttpDelete("id")]
          public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
          {
              var FindStudent = await _context.Students.FindAsync(id);
              if (FindStudent == null) return BadRequest("Student is not found.");
              else
              {
                  _context.Students.Remove(FindStudent);
                await _context.SaveChangesAsync();
                  return Ok(await _context.Students.ToListAsync());

              } 

          }
    }
}
