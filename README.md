# API Rest
Projeto desenvolvido na sprint 5 no programa de bolsas Compasso UOL
- API para gerenciar a relação de clientes e cidades
- Verbos HTTP: GET, POST, PUT e DELETE

## Tecnologias utilizadas
- .NET Framework 5.0
- Entity Framework Core
- SQL Server Local

## Como utilizar
### Clientes

```bash
# GET
- Retorna todos os resultados de clientes
```

```bash
# GET {id}
- Id: int
- Retorna um cliente específico
```

```bash
# PUT {id}
- Id: int
- Altera um cliente específico
- Requisitos: corpo e Cep válido

  Exemplo de esquema para corpo:
  {
    "nome": "string",
    "dataNascimento": "datetime",
    "cep": "string"
  }
```

```bash
# POST 
- Cadastra um novo cliente
- Requisitos: corpo e Cep válido 

  Exemplo de esquema para corpo:
  {
    "nome": "string",
    "dataNascimento": "datetime",
    "cep": "string"
  }
```

```bash
# DELETE {id}
- Id: int
- Remove um cliente específico
```

### Cidades

```bash
# GET
- Retorna todos os resultados de cidades
```

```bash
# GET {id}
- Id: int
- Retorna uma cidade específica
```

```bash
# PUT {id}
- Id: int
- Altera uma cidade específica
- Requisitos: corpo

  Exemplo de esquema para corpo:
  {
    "nome": "string",
    "estado": "string"
  }
```

```bash
# POST {cep}
- cep: string
- Cadastra uma nova cidade através de um Cep válido
```

```bash
# DELETE {id}
- Id: int
- Remove uma cidade específica
```
