using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoIdentity.Models
{
    public class AccesoViewModel
    {
        [Required(ErrorMessage = "El EMAIL es Obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La CONTRASEÑA es Obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar datos?")]
        public bool RememberMe { get; set; }
    }
}
 