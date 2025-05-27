namespace ProjetoReservasSalas.Dtos
{
    public class CriarReservaDto
    {
        public int SalaId { get; set; } //VALIDACAO DE EXISTENCIA FEITA NO SERVICE
        public string Solicitante { get; set; }
        public DateTime Data { get; set; }
        public int DuracaoEmHoras { get; set; }
    }
}
