using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnico.Models
{
    public class Tecnicos
    {
        [Key]

        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "El Campo Descripción es obligatorio ")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El Campo Descripción es obligatorio")]
        public float? Sueldohora { get; set; }

        [ForeignKey("TipoTecnico")]
        public int TipoId { get; set; }

        public int IncentivoId { get; set; }

        public Tipostecnicos? Tipotecnicos { get; set;}

        public string Descripcion { get; set; }
    }
}