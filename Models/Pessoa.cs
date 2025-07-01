namespace SistemaHospedagemHotel.Models
{
    public class Pessoa
    {
        public Pessoa() { }

        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome não pode ser vazio.");
                _nome = value;
            }
        }

        private string _sobrenome;
        public string Sobrenome
        {
            get => _sobrenome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Sobrenome não pode ser vazio.");
                _sobrenome = value;
            }
        }

        public string NomeCompleto => $"{Nome} {Sobrenome}";
    }
}
