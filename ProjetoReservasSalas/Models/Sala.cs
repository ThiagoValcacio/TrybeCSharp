

namespace ProjetoReservasSalas.Models
{
    public class Sala
    {
        public int Id { get; private set; } //Somente get é publico
        public string Nome { get; private set; } //ENCAPSULAMENTO
        public int Capacidade { get; private set; }
        public string Tipo { get; private set; }

        public Sala(int id, string nome, int capacidade, string tipo)
        {
            if (capacidade < 1) //REGRA DE NEGÓCIO
                throw new ArgumentException("Capacidade deve ser no mínimo 1");

            Id = id;
            Nome = nome;
            Capacidade = capacidade;
            Tipo = tipo;
        }
    }
}
