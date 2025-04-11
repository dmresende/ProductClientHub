# ProductClientHub API

Uma API Web desenvolvida em .NET 8 para gerenciamento de clientes.

## 🚀 Funcionalidades

- **Gerenciamento de Clientes:**
  - Cadastro de novos clientes
  - Atualização de informações de clientes
  - Listagem de todos os clientes
  - Busca de cliente por ID
  - Exclusão de clientes

## 🛠️ Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- C# 12.0

## 📋 Endpoints da API

### Clientes

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| POST | `/api/clients` | Cadastra um novo cliente |
| PUT | `/api/clients` | Atualiza informações do cliente |
| GET | `/api/clients` | Lista todos os clientes |
| GET | `/api/clients/{id}` | Busca cliente por ID |
| DELETE | `/api/clients` | Remove um cliente |

### Exemplo de Requisição

#### Cadastro de Cliente
{ "name": "João Silva", "email": "joao@exemplo.com" }


## 🚦 Códigos de Status da Resposta

- `201 Created` - Cliente cadastrado com sucesso
- `400 Bad Request` - Dados da requisição inválidos
- `200 OK` - Operação realizada com sucesso

## 🔧 Instalação

1. Clone o repositório
git clone [ProductClientHub](https://github.com/dmresende/ProductClientHub/)

2. Navegue até o diretório do projeto
dotnet restore

4. Execute a aplicação
 dotnet run


## 💻 Como Usar

A API estará disponível em `https://localhost:7000` (ou na porta configurada)


## 📝 Pré-requisitos

- SDK do .NET 8
- Visual Studio 2022 ou VS Code

## 🔍 Estrutura do Projeto
```
ProductClientHub.API/
├── Controllers/ 
│   └── ClientsController.cs 
├── UseCases/ 
│   └── Clients/ 
├── Communication/ 
│   ├── Requests/ 
│   └── Responses/
```


## 🤝 Como Contribuir

1. Faça um Fork do projeto
2. Crie uma Branch para sua Feature (`git checkout -b feature/AmazingFeature`)
3. Faça o Commit das suas alterações (`git commit -m 'Add some AmazingFeature'`)
4. Faça o Push para a Branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença [MIT](https://opensource.org/licenses/MIT).

## ✨ Próximos Passos

- Implementação de autenticação
- Validações avançadas
- Documentação com Swagger
- Testes unitários










