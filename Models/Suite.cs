namespace SistemaHospedagemHotel.Models
{
    public class Suite
    {
        public int ID { get; set; }
        public string TipoSuite { get; set; }
        public decimal ValorDiaria { get; set; }
        public int Capacidade { get; set; }
        public bool Disponibilidade { get; set; } = true;
        public int DiasReservados { get; set; }

        public decimal CalcularValorTotal()
        {
            decimal total = ValorDiaria * DiasReservados;
            if (DiasReservados >= 10)
                total *= 0.90m;
            return total;
        }
    }
}