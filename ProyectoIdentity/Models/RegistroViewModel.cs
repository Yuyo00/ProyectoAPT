using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoIdentity.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El EMAIL es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La CONTRASEÑA es obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe estar entre al menos {2} caracteres de longitud", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La CONFIRMACION DE CONTRASEÑA es obligatoria")]
        [Compare("Password", ErrorMessage = "La CONTRASEÑA y la CONFIRMACION no coinciden")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El NOMBRE es obligatorio")]
        public string Nombre { get; set; }
        public string Url { get; set; }

        [Display(Name = "Código País")]
        public Int32 CodigoPais { get; set; }
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El PAIS es obligatorio")]
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Dirección { get; set; }

        [Required(ErrorMessage = "la FECHA DE NACIMIENTO es obligatoria")]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public bool Estado { get; set; }
    }
}
