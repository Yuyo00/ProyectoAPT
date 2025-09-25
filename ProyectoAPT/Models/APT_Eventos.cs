namespace ProyectoAPT.Models
{
    public class APT_Eventos
    {
        public int ID_Evento { get; set; }
        public string COD_Usuario { get; set; }
        public DateTime DTTM_FechaEvento { get; set; }
        public bool FLG_Notificar { get; set; }
        public int COD_TipoNotificacion { get; set; }
        public string DESC_Nombre { get; set; }
        public int MNT_Porcentaje { get; set; }
    }
}
