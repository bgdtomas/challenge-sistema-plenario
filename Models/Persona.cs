using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoABMC.Models
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud máxima del campo es de 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(0, 999999999999999999.99)]
        [Display(Name = "Credito Maximo")]
        public int CreditoMaximo { get; set; }
    }
}
