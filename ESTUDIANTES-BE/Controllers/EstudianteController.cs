using ESTUDIANTES_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESTUDIANTES_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public EstudianteController(AplicationDbContext context) {  _context = context;}
        //Metodos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEstudiantes = await _context.Estudiante.ToArrayAsync();
                return Ok(listEstudiantes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //findAsync busca la id en la tabla dada
                var estudiante = await _context.Estudiante.FindAsync(id);
                if (estudiante == null)
                {
                    return NotFound();
                }
                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Estudiante estudiante)
        {
            try
            {
                estudiante.FechaCreacion = DateTime.UtcNow;
                _context.Add(estudiante);

                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new {id = estudiante.Id}, estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Estudiante estudiante)
        {
            try
            {
                //Si la id que le enviamos no coincide con el cuerpo que se esta actializando envia un error.
                if(id != estudiante.Id) 
                { 
                    return BadRequest(); 
                }
                var estudianteItem = await _context.Estudiante.FindAsync(id);

                //Si no se encuentra el cuerpo en la base de datos retorna un no encontrado o not found.
                if (estudianteItem == null) {  return NotFound(); }
                estudianteItem.IdEstudiante = estudiante.IdEstudiante;
                estudianteItem.Nombre = estudiante.Nombre;
                estudianteItem.Apellido = estudiante.Apellido;
                estudianteItem.Programa = estudiante.Programa;
                estudianteItem.Telefono = estudiante.Telefono;
                estudianteItem.Email = estudiante.Email;
                estudianteItem.Fecha_nacimiento = estudiante.Fecha_nacimiento;
                estudianteItem.Estado = estudiante.Estado;
                estudianteItem.Vigencia = estudiante.Vigencia;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var estudiante = await _context.Estudiante.FindAsync(id);
                //Validamos que el estudiante exista
                if (estudiante == null) { return NotFound(); }
                //Lo removemos del contexto
                _context.Estudiante.Remove(estudiante);
                //Guardamos los cambios
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
