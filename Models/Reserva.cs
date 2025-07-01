namespace SistemaHospedagemHotel.Models
{
    public class Reserva
    {
        public Pessoa Hospede { get; set; }
        public Suite SuiteReservada { get; set; }
        public int DiasReservados => SuiteReservada.DiasReservados;

        public decimal CalcularValorTotal() => SuiteReservada.CalcularValorTotal();
    }
}