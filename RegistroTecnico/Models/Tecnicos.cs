using System.ComponentModel.DataAnnotations;

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



    }
}