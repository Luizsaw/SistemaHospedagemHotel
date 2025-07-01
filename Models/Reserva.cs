namespace SistemaHospedagemHotel.Models
{
    public class Reserva
    {
        public Pessoa Hospede { get; set; }
        public Suite SuiteReservada { get; set; }
        public int DiasReservados => SuiteReservada.DiasReservados; /*propriedade de leitura (somente get) que usa expressão lambda (=>)
        para retornar diretamente o valor da propriedade DiasReservados de um objeto chamado SuiteReservada.*/

        public decimal CalcularValorTotal() => SuiteReservada.CalcularValorTotal();
    }
}