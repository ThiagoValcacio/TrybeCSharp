using Microsoft.AspNetCore.Mvc;
using ProjetoReservasSalas.Dtos;

namespace ProjetoReservasSalas.Controllers
{
    [ApiController]
    [Route("salas")]
    public class SalaController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> CriarSala([FromBody] CriarSalaDto dto)
        {
            if (dto.Capacidade < 1)
                return BadRequest("Capacidade mínima é 1");

            return Ok($"Sala '{dto.Nome}' recebida com capacidade {dto.Capacidade}");
        }

        [HttpGet]
        public ActionResult<List<string>> ListarSalas()
        {
            // Simulação de resposta
            var salasFake = new List<string> { "Sala Azul", "Sala Reunião 2", "Sala Grande" };
            return Ok(salasFake);
        }

        [HttpGet("{id}/reservas")]
        public ActionResult<List<string>> ListarReservasPorSala(int id)
        {
            // Simulação de resposta
            var reservasFake = new List<string>
            {
                $"Reserva 1 da sala {id}",
                $"Reserva 2 da sala {id}"
            };
            return Ok(reservasFake);
        }
    }
}
