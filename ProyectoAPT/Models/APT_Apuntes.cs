namespace ProyectoAPT.Models
{
    public class APT_Apuntes
    {
        public int ID_Apunte { get; set; }
        public int COD_Ramo { get; set; }
        public string DESC_Texto { get; set; }
        public string DESC_Titulo { get; set; }
        public DateTime DTTM_FechaClase { get; set; }
    }
}
