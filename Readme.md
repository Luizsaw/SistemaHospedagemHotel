# 🏨 Sistema de Hospedagem Hotel .NET

Um sistema de hotelaria simples desenvolvido em **C# com .NET**, executado via **terminal** (modo console), com foco em **boas práticas de orientação a objetos** e **organização modular**.

---

## Funcionalidades

-  Cadastro de Suítes
-  Cadastro de Hóspedes
-  Reservas com controle de capacidade
-  Cálculo de valor total com desconto de 10% para 10+ dias
-  Listagem de suítes disponíveis
-  Checkout com liberação da suíte
-  Validações robustas para entradas numéricas

---

## Regras de Negócio

- O sistema **não permite ultrapassar a capacidade** da suíte.
- Um hóspede recebe **10% de desconto** se reservar por **10 dias ou mais**.
- Cada suíte pode ser reservada apenas se estiver **disponível**.
- Checkout libera a suíte para nova reserva.

---

## Estrutura do Projeto

```
SistemaHotel/
│
├── Program.cs # Ponto de entrada
├── SistemaHotel.cs # Classe principal do sistema
│
└── Models/
├── Pessoa.cs # Representa o hóspede
├── Suite.cs # Representa a suíte
└── Reserva.cs # Representa a reserva (Pessoa + Suite)
```

---

## Requisitos

- .NET 7.0 ou superior
- Ubuntu ou qualquer sistema com suporte ao .NET Core

---

## Como Executar

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/SistemaHotel.git
cd SistemaHotel

# Restaure e execute
dotnet restore
dotnet run
```

## Exemplo de Uso
```
======= Sistema de Hospedagem =======
1 - Cadastrar Suíte
2 - Fazer Reserva
3 - Listar Reservas
4 - Listar Suítes Disponíveis
5 - Realizar Checkout
0 - Sair
```

## Aprendizados Aplicados

  - Princípios SOLID (Responsabilidade Única, Encapsulamento)

  -  Boas práticas com List<T>, FirstOrDefault, Where, Any

  -  Manipulação de entradas seguras com TryParse

  -  Código organizado, limpo e reutilizável