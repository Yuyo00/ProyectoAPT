using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoIdentity.Models
{
    public class OlvidoPasswordViewModel
    {
        [Required(ErrorMessage = "El EMAIL es Obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
 

