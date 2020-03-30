# BankNet

    Microserviço que realiza operações bancárias.

## Software

* BankNet.Api - WebApi responsável por realizar transações bancárias.

### Endpoints

`POST /transfer` será responsável por realizar a transferência entre contas.

Corpo da requisição

```json
{
    "destinyaccount": "1234567",
    "originaccount": "7654321",
    "dateTransaction": "2020-03-30T01:47:51.630Z",
    "valuetransaction": 10.50
}
```

As informações dos usuários deve estar previamente cadastrado.

Exemplo:

```http
Request
POST /transfer HTTP/1.1
Content-Type: application/json
{
    "destinyaccount": "1234567",
    "originaccount": "7654321",
    "dateTransaction": "2020-03-30T01:47:51.630Z",
    "valuetransaction": 10.50
}
```

```http
Response:
{
    "success": true,
    "data": "Transferência realizado com sucesso!"
}
```