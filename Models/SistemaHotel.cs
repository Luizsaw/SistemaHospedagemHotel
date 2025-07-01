using SistemaHospedagemHotel.Models;

namespace SistemaHospedagemHotel
{
    public class SistemaHotel
    {
        private List<Suite> suites = new();
        private List<Reserva> reservas = new();
        private int proximoIdSuite = 1;

        public void Iniciar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======= Sistema de Hospedagem =======");
                Console.WriteLine("1 - Cadastrar Suíte");
                Console.WriteLine("2 - Fazer Reserva");
                Console.WriteLine("3 - Listar Reservas");
                Console.WriteLine("4 - Listar Suítes Disponíveis");
                Console.WriteLine("5 - Realizar Checkout");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": CadastrarSuite(); break;
                    case "2": FazerReserva(); break;
                    case "3": ListarReservas(); break;
                    case "4": ListarSuitesDisponiveis(); break;
                    case "5": RealizarCheckout(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione Enter para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CadastrarSuite()
        {
            Console.Clear();
            Console.WriteLine("== Cadastro de Suíte ==");

            Console.Write("Tipo da suíte: ");
            string tipo = Console.ReadLine();

            Console.Write("Capacidade: ");
            int capacidade = LerInteiro();

            Console.Write("Valor da diária: ");
            decimal valor = LerDecimal();

            suites.Add(new Suite
            {
                ID = proximoIdSuite++,
                TipoSuite = tipo,
                Capacidade = capacidade,
                ValorDiaria = valor,
                Disponibilidade = true
            });

            Console.WriteLine("Suíte cadastrada com sucesso! Pressione Enter...");
            Console.ReadKey();
        }

        private void FazerReserva()
        {
            Console.Clear();
            Console.WriteLine("== Fazer Reserva ==");

            var disponiveis = suites.Where(s => s.Disponibilidade).ToList();

            if (!disponiveis.Any())
            {
                Console.WriteLine("Não há suítes disponíveis.");
                Console.ReadKey();
                return;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Sobrenome: ");
            string sobrenome = Console.ReadLine();

            Console.Write("Quantidade de pessoas: ");
            int quantidade = LerInteiro();

            ListarSuitesDisponiveis();

            Console.Write("Digite o ID da suíte desejada: ");
            int id = LerInteiro();

            var suite = suites.FirstOrDefault(s => s.ID == id && s.Disponibilidade);

            if (suite == null)
            {
                Console.WriteLine("ID inválido ou suíte não disponível.");
                Console.ReadKey();
                return;
            }

            if (quantidade > suite.Capacidade)
            {
                Console.WriteLine("Capacidade da suíte insuficiente.");
                Console.ReadKey();
                return;
            }

            Console.Write("Quantidade de dias: ");
            int dias = LerInteiro();
            suite.DiasReservados = dias;

            reservas.Add(new Reserva
            {
                Hospede = new Pessoa(nome, sobrenome),
                SuiteReservada = suite
            });

            suite.Disponibilidade = false;
            Console.WriteLine("Reserva realizada com sucesso!");
            Console.ReadKey();
        }

        private void ListarReservas()
        {
            Console.Clear();
            Console.WriteLine("== Reservas Ativas ==");

            if (!reservas.Any())
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
            }
            else
            {
                foreach (var reserva in reservas)
                {
                    var total = reserva.CalcularValorTotal();
                    Console.WriteLine($"- Hóspede: {reserva.Hospede.NomeCompleto}, Suíte: {reserva.SuiteReservada.TipoSuite}, Dias: {reserva.DiasReservados}, Total: R$ {total:F2}");
                }
            }

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadKey();
        }

        private void ListarSuitesDisponiveis()
        {
            Console.Clear();
            Console.WriteLine("== Suítes Disponíveis ==");

            var disponiveis = suites.Where(s => s.Disponibilidade);

            if (!disponiveis.Any())
            {
                Console.WriteLine("Nenhuma suíte encontrada.");
            }
            else
            {
                foreach (var s in disponiveis)
                {
                    Console.WriteLine($"ID: {s.ID}, Tipo: {s.TipoSuite}, Capacidade: {s.Capacidade}, Diária: R$ {s.ValorDiaria:F2}");
                }
            }
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadKey();
        }

        private void RealizarCheckout()
        {
            Console.Clear();
            Console.WriteLine("== Checkout ==");

            Console.Write("Digite o ID da suíte para checkout: ");
            int id = LerInteiro();

            var reserva = reservas.FirstOrDefault(r => r.SuiteReservada.ID == id);

            if (reserva != null)
            {
                Console.WriteLine($"Checkout de {reserva.Hospede.NomeCompleto} realizado com sucesso!");
                Console.WriteLine($"Valor total: R$ {reserva.CalcularValorTotal():F2}");
                reserva.SuiteReservada.Disponibilidade = true;
                reservas.Remove(reserva);
            }
            else
            {
                Console.WriteLine("Reserva não encontrada.");
            }

            Console.ReadKey();
        }

        private int LerInteiro()
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor))
                Console.Write("Entrada inválida. Digite um número inteiro: ");
            return valor;
        }
        
        private decimal LerDecimal()
        {
            decimal valor;
            while (!decimal.TryParse(Console.ReadLine(), out valor))
                Console.Write("Entrada inválida. Digite um número decimal: ");
            return valor;
        }

    }
}