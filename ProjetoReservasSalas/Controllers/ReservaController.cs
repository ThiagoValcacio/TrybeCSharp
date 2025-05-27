using Microsoft.AspNetCore.Mvc;
using ProjetoReservasSalas.Dtos;
using ProjetoReservasSalas.Services;
using ProjetoReservasSalas.Models;

namespace ProjetoReservasSalas.Controllers
{
    [ApiController]
    [Route("reservas")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;
        private readonly SalaService _salaService;

        public ReservaController(ReservaService reservaService, SalaService salaService)
        {
            _reservaService = reservaService;
            _salaService = salaService;
        }

        [HttpPost]
        public ActionResult<Reserva> Criar([FromBody] CriarReservaDto dto)
        {
            var sala = _salaService.ObterPorId(dto.SalaId);
            if (sala == null) return NotFound("Sala não existe");

            try
            {
                var reservasExistentes = _reservaService.ListarPorSala(dto.SalaId);
                var reserva = _reservaService.Criar(dto, reservasExistentes);
                return Created("", reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
