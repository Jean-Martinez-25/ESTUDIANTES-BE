using System.ComponentModel.DataAnnotations.Schema;

namespace ESTUDIANTES_BE.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Programa { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Fecha_nacimiento { get; set; }
        public string Estado { get; set; }
        public int Vigencia { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
    public class Nota
    {
        public int Id { get; set; }
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public int IdInstructor { get; set; }
        public int Calificacion { get; set; }
        public int Creditos { get; set; }
        public int Vigencia { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
    public class Instructor
    {
        public int Id { get; set; }
        public int IdInstructor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
