using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibros.Models
{
    [Table("Autor")]
    public class Autor
    {
        public int Id { get; set; }
       
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        [Range(18,110, ErrorMessage ="Solo se aceptan valores entre 18 y 110")]
        public int Edad { get; set; }

        public List<Libro> Libros { get; set; }

    }
}
