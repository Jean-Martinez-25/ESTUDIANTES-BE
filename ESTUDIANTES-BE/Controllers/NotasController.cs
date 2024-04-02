using ESTUDIANTES_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESTUDIANTES_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public NotasController(AplicationDbContext context) { _context = context; }
        //Metodos
        [HttpGet("{idEstudiante}")]
        public async Task<IActionResult> GetNotasEstudiante(int idEstudiante)
        {
            try
            {
                var notas = await _context.Nota
                    .Where(n => n.IdEstudiante == idEstudiante)
                    .Join(
                        _context.Instructor,
                        nota => nota.IdInstructor,
                        instructor => instructor.Id,
                        (nota, instructor) => new
                        {
                            nota.Id,
                            nota.IdEstudiante,
                            nota.Nombre,
                            NombreInstructor = $"{instructor.Nombre} {instructor.Apellido}",
                            nota.Calificacion,
                            nota.Creditos,
                            nota.Vigencia,
                            nota.FechaCreacion
                        }
                    )
                    .ToListAsync();

                if (notas == null || !notas.Any())
                {
                    return NotFound();
                }

                return Ok(notas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
