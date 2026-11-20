using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UtlvteMonolito.Web.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "La cédula debe contener exactamente 10 dígitos.")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres.")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo institucional es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido con formato institucional.")]
        [Display(Name = "Correo Institucional")]
        public string CorreoInstitucional { get; set; } = string.Empty;

        [Required(ErrorMessage = "La carrera es obligatoria.")]
        [Display(Name = "Carrera")]
        public string Carrera { get; set; } = "Ingeniería en Tecnologías de la Información";

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Display(Name = "Estado")]
        public bool EstadoActivo { get; set; } = true;

        // Conservamos la relación con la tabla de matrículas
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}