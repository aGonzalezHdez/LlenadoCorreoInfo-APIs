using CRUDAPIs.Application.DTOs;
using CRUDAPIs.Domain.Domain.DataBase;

namespace CRUDAPIs.Application.Interfaces;

public interface IConsultasService
{
    Task<IEnumerable<ConsultasDTO>> ObtenerTodasConsultasAsync();
    Task<ConsultasDTO> ObtenetConsultaPorId(int id);
    Task BorrarConsultaAsync(int id);
    Task ActualizarConsultaAsync(ConsultasDTO consulta);
    Task AgregarConsultaAsync(ConsultasDTO consulta);
}