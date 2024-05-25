using System.ComponentModel.DataAnnotations;

namespace RegistroTecnico.Models
{
    public class Tipotecnicos
    {
        [Key]

        public int TipoId { get; set; }
        [Required(ErrorMessage = "El campo no esta lleno")]
        public string Descripcion { get; set; }
    }
}
