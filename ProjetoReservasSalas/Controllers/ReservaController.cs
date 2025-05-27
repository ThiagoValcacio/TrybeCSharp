using Microsoft.AspNetCore.Mvc;
using ProjetoReservasSalas.Dtos;

namespace ProjetoReservasSalas.Controllers
{
    [ApiController]
    [Route("reservas")]
    public class ReservaController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> CriarReserva([FromBody] CriarReservaDto dto)
        {
            if (dto.DuracaoEmHoras < 1 || dto.DuracaoEmHoras > 8)
                return BadRequest("Duração inválida. Permitido entre 1 e 8 horas.");

            return Ok($"Reserva simulada para sala {dto.SalaId} às {dto.Data}, por {dto.DuracaoEmHoras} horas.");
        }
    }
}
