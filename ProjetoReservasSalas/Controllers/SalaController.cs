using Microsoft.AspNetCore.Mvc;
using ProjetoReservasSalas.Dtos;
using ProjetoReservasSalas.Services;
using ProjetoReservasSalas.Models;

namespace ProjetoReservasSalas.Controllers
{
    [ApiController]
    [Route("salas")]
    public class SalaController : ControllerBase
    {
        private readonly SalaService _salaService;
        private readonly ReservaService _reservaService;

        public SalaController(SalaService salaService, ReservaService reservaService)
        {
            _salaService = salaService;
            _reservaService = reservaService;
        }

        [HttpPost]
        public ActionResult<Sala> Criar([FromBody] CriarSalaDto dto)
        {
            try
            {
                var sala = _salaService.Criar(dto);
                return Created("", sala);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Sala>> Listar()
        {
            return Ok(_salaService.Listar());
        }

        [HttpGet("{id}/reservas")]
        public ActionResult<List<Reserva>> ListarReservas(int id)
        {
            var sala = _salaService.ObterPorId(id);
            if (sala == null) return NotFound("Sala não encontrada");
            return Ok(_reservaService.ListarPorSala(id));
        }
    }
}
