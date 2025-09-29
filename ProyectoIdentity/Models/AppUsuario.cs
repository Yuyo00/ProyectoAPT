using Microsoft.AspNetCore.Identity;

namespace ProyectoIdentity.Models
{
    public class AppUsuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Url { get; set; }
        public Int32 CodigoPais { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Dirección { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Estado { get; set; }



    }
}
