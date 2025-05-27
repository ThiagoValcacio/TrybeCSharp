namespace ProjetoReservasSalas.Models
{
    public class Reserva
    {
        public int Id { get; private set; }
        public int SalaId { get; private set; }
        public string Solicitante { get; private set; }
        public DateTime Data { get; private set; }
        public int DuracaoEmHoras { get; private set; }

        public Reserva(int id, int salaId, string solicitante, DateTime data, int duracaoEmHoras)
        {
            if (duracaoEmHoras < 1 || duracaoEmHoras > 8) //REGRA DE NEGOCIO
                throw new ArgumentException("A duração deve ser entre 1 e 8 horas");

            Id = id;
            SalaId = salaId;
            Solicitante = solicitante;
            Data = data;
            DuracaoEmHoras = duracaoEmHoras;
        }

        public DateTime DataFim => Data.AddHours(DuracaoEmHoras);
    }
}
