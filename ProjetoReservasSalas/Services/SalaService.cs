using ProjetoReservasSalas.Models;
using ProjetoReservasSalas.Dtos;

namespace ProjetoReservasSalas.Services
{
    public class SalaService
    {
        private readonly List<Sala> _salas = new();
        private int _idAtual = 1;

        public Sala Criar(CriarSalaDto dto)
        {
            var sala = new Sala(_idAtual++, dto.Nome, dto.Capacidade, dto.Tipo);
            _salas.Add(sala);
            return sala;
        }

        public List<Sala> Listar() => _salas;

        public Sala? ObterPorId(int id) => _salas.FirstOrDefault(s => s.Id == id);
    }
}
