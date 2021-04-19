using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoABMC.Models
{
    public class Telefono
    {
        [Key]
        public int TelefonoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [ForeignKey(nameof(Persona))]
        [Display(Name = "Id de Persona")]
        public int PersonaID { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud máxima del campo es de 200 caracteres")]
        [Display(Name = "Numero de Telefono")]
        public string NroTelefono { get; set; }
    }
}
