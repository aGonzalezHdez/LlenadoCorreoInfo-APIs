using AutoMapper;
using CRUDAPIs.Application.DTOs;
using CRUDAPIs.Application.Interfaces;
using CRUDAPIs.Domain.Domain.DataBase;

namespace CRUDAPIs.Application.Services;

public class ConsultasesService : IConsultasService
{
    private readonly IDBRepository<Consultas> _consultasRepository;
    private readonly IMapper _mapper;

    public ConsultasesService(IDBRepository<Consultas> consultasRepository,IMapper mapper)
    {
        _consultasRepository = consultasRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ConsultasDTO>> ObtenerTodasConsultasAsync()
    {
        var consultas = await _consultasRepository.GetAllAsync();   
        return _mapper.Map<IEnumerable<ConsultasDTO>>(consultas); // 🔥 Usa AutoMapper

    }

    public async Task<ConsultasDTO> ObtenetConsultaPorId(int id)
    {
        var consulta = await _consultasRepository.GetByIdAsync(id);
        return _mapper.Map<ConsultasDTO>(consulta);
    }

    public async Task BorrarConsultaAsync(int id)
    {
        await _consultasRepository.DeleteAsync(id);
    }

    public async Task ActualizarConsultaAsync(ConsultasDTO consultaDto)
    {
        var consulta = _mapper.Map<Consultas>(consultaDto);
        await _consultasRepository.UpdateAsync(consulta);
    }

    public async Task AgregarConsultaAsync(ConsultasDTO consultaDto)
    {
        var consulta = _mapper.Map<Consultas>(consultaDto);
        await _consultasRepository.AddAsync(consulta);
    }
    
    
}