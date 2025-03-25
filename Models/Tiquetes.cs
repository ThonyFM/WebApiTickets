using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiTickets.Models
{
    public class Tiquetes
    {
        [Key]
        public int ti_identificador { get; set; }

        [Required, MaxLength(255)]
        public string ti_solucion { get; set; }

        [Required, MaxLength(150)]
        public string ti_asunto { get; set; }

        [Required, MaxLength(150)]
        public string ti_categoria { get; set; }

        [Required, MaxLength(150)]
        public string ti_urgencia { get; set; }

        [Required, MaxLength(150)]
        public string ti_importancia { get; set; }

        [Required, MaxLength(1)]
        public string ti_estado { get; set; }

        [Required]
        public DateTime ti_fecha_adicion { get; set; } = DateTime.Now;

        [Required, MaxLength(10)]
        public string ti_adicionado_por { get; set; }

        [Required]
        public DateTime? ti_fecha_modificacion { get; set; } = DateTime.Now;

        [Required, MaxLength(10)]
        public string? ti_modificado_por { get; set; }

        [ForeignKey("Roles")]
        public int ti_us_id_asigna { get; set; }
        public Roles Roles { get; set; }
    }
}
