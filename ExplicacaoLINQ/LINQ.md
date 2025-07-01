# O que é LINQ?

 - LINQ (Language Integrated Query) é um conjunto de recursos da linguagem C# que permite consultar, filtrar, ordenar, transformar e agregar dados de forma simples, legível e integrada à linguagem.

 - Em vez de usar loops longos com foreach e if, o LINQ deixa seu código mais curto, limpo e direto.

## LINQ funciona com:

    List<T> (listas)

    Arrays

    Bancos de dados (com Entity Framework)

    XML

    Objetos que implementam IEnumerable<T> ou IQueryable<T>

## Exemplo tradicional vs LINQ

### Sem LINQ (modo "manual"):

``` 
List<Suite> disponiveis = new List<Suite>();
foreach (var s in suites)
{
    if (s.Disponibilidade)
    {
        disponiveis.Add(s);
    }
}
```

### Com LINQ:
```
var disponiveis = suites.Where(s => s.Disponibilidade).ToList();
```
 - Mesmo resultado, mas com muito menos código.
 - Como o LINQ funciona?

## Ele usa expressões lambda como:
```
s => s.Disponibilidade
```

### Isso significa:
- "para cada item s na coleção, use a propriedade Disponibilidade como filtro ou critério".

## Métodos LINQ comuns (todos encadeáveis):

| Método                | O que faz                                |
| --------------------- | ---------------------------------------- |
| `Where()`             | Filtra dados com base em uma condição    |
| `Select()`            | Transforma cada item                     |
| `FirstOrDefault()`    | Retorna o primeiro item ou null          |
| `Any()`               | Verifica se existe pelo menos um item    |
| `Count()`             | Conta itens (opcionalmente com condição) |
| `OrderBy()`           | Ordena os itens (crescente)              |
| `OrderByDescending()` | Ordena os itens (decrescente)            |



## Principais métodos LINQ com exemplos simples que se aplicam diretamente ao seu sistema de hotelaria. Você já usa .Where() e .ToList(), agora vamos avançar com:
### 1-  .Any() — Verifica se existe ao menos um item que atenda uma condição
```
bool temDisponivel = suites.Any(s => s.Disponibilidade);
```
- Retorna true se alguma suíte estiver disponível.


### 2- .Count() — Conta quantos itens atendem uma condição
```
int totalDisponiveis = suites.Count(s => s.Disponibilidade);
```
- Retorna o número total de suítes disponíveis.

### 3- .FirstOrDefault() — Retorna o primeiro item que atende a condição (ou null se não achar)
```
Suite selecionada = suites.FirstOrDefault(s => s.ID == idDigitado);
```
- Retorna a suíte com ID igual ao digitado, ou null se não existir.

### Use com verificação:
```
if (selecionada != null)
{
    Console.WriteLine($"Suíte: {selecionada.TipoSuite}");
}
else
{
    Console.WriteLine("ID inválido.");
}
```
### 4- .Select() — Projeta (transforma) os dados da lista em outro formato
```
var nomes = hospedes.Select(h => h.NomeCompleto).ToList();
```
- Cria uma nova lista apenas com os nomes completos dos hóspedes.

### 5- .OrderBy() e .OrderByDescending() — Ordenação
```
var ordenadas = suites.OrderBy(s => s.ValorDiaria).ToList();
```
 - Ordena as suítes do mais barato para o mais caro.

### 6- Combinação com .Where()
```
var baratas = suites
    .Where(s => s.Disponibilidade)
    .OrderBy(s => s.ValorDiaria)
    .ToList();
```
- Lista de suítes disponíveis, ordenadas da mais barata à mais cara.