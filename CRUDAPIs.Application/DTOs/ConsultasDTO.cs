namespace CRUDAPIs.Application.DTOs;

public class ConsultasDTO
{
    public int Id { get; set; }
    public string FechaLlegada { get; set; }
    public string HoraLlegada { get; set; }
    public string CorreoCliente { get; set; }
    public string TituloCorreo { get; set; }
    public int Partidas { get; set; }
    public string FechaCierre { get; set; }
    public string HoraCierre { get; set; }
    public int DiasRespuesta { get; set; }
    public string Referencia { get; set; }
    public string RazonSocial { get; set; }
    public int ClienteId { get; set; } 
    public int ComentariosId { get; set; }
    public int AtendidoPorId { get; set; }
   
}