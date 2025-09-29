using Microsoft.AspNetCore.Identity;

namespace ProyectoAPT.Models
{
    public class AppUsuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Url { get; set; }
        public bool EsUniversitario { get; set; }
        public string Institucion { get; set; }
        public bool Estado { get; set; }
        public string Telefono { get; set; }
    }
}