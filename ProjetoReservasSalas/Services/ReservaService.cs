using ProjetoReservasSalas.Models;
using ProjetoReservasSalas.Dtos;

namespace ProjetoReservasSalas.Services
{
    public class ReservaService
    {
        private readonly List<Reserva> _reservas = new();
        private int _idAtual = 1;

        public Reserva Criar(CriarReservaDto dto, List<Reserva> reservasDaSala)
        {
            var novaDataFim = dto.Data.AddHours(dto.DuracaoEmHoras);

            var conflito = reservasDaSala.Any(r =>
                dto.Data < r.Data.AddHours(r.DuracaoEmHoras) &&
                novaDataFim > r.Data
            );

            if (conflito)
                throw new ArgumentException("Já existe uma reserva nesse horário.");

            var nova = new Reserva(_idAtual++, dto.SalaId, dto.Solicitante, dto.Data, dto.DuracaoEmHoras);
            _reservas.Add(nova);
            return nova;
        }

        public List<Reserva> ListarPorSala(int salaId) =>
            _reservas.Where(r => r.SalaId == salaId).ToList();
    }
}
