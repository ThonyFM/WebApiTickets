using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiTickets.Models
{
    public class Usuarios
    {
        [Key]
        public int us_identificador { get; set; }

        [Required, MaxLength(150)]
        public string us_nombre_completo { get; set; }

        [Required, MaxLength(150)]
        public string us_correo { get; set; }

        [Required, MaxLength(255)]
        public string us_clave { get; set; }

        [Required]
        public string us_estado { get; set; }

        [Required]
        public DateTime us_fecha_adicion { get; set; } = DateTime.Now;

        [Required, MaxLength(10)]
        public string us_adicionado_por { get; set; }

        [Required]
        public DateTime? us_fecha_modificacion { get; set; } = DateTime.Now;

        [Required, MaxLength(10)]
        public string? us_modificado_por { get; set; }

        [ForeignKey("Roles")]
        public int us_ro_identificador { get; set; }
        public Roles Roles { get; set; }
    }

}
