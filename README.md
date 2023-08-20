# API "Would You Rather"

#Frontend - ⛏️ 
#Backend - ✔️

Bem-vindo ao repositório da API "Would You Rather"! Este é um projeto que implementa uma API para um jogo típico de "Would You Rather", onde os jogadores são apresentados com perguntas hipotéticas e devem escolher uma das opções apresentadas. A API foi desenvolvida usando .NET Core, Entity Framework e SQL Server.

## Pré-requisitos

Certifique-se de ter o seguinte instalado antes de iniciar:

- [.NET Core SDK](https://dotnet.microsoft.com/download) - versão 6.0 ou superior
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - para armazenamento de dados

## Configuração do Projeto

1. Clone este repositório para o seu ambiente local:

```bash
git clone https://github.com/arthurferro/would-you-rather.git
```

2. Acesse o diretório do projeto:

```bash
cd would-you-rather
```

3. Configure a conexão com o banco de dados:
   
   No arquivo `appsettings.json`, você encontrará uma seção chamada "ConnectionStrings". Substitua os valores com as informações corretas para a sua instância do SQL Server.

4. Execute as migrações do Entity Framework para criar o esquema do banco de dados:

```bash
dotnet ef database update
```

5. Inicie a aplicação:

```bash
dotnet run
```

A API estará disponível em `http://localhost:20812` e você também pode consultar as rotas pelo swagger em `http://localhost:5127 ou https://localhost:7048)`.

## Rotas da API

A API oferece as seguintes rotas:

⛏️⛏️⛏️

## Contribuição

Se você deseja contribuir para o projeto, sinta-se à vontade para criar um fork do repositório, implementar  melhorias e enviar um pull request. Todas as contribuições são bem-vindas!

## Contato

- Autor: [Seu Nome](https://github.com/arthurferro)

## Licença

Este projeto está licenciado sob a Licença MIT - consulte o arquivo [LICENSE](https://github.com/arthurferro/would-you-rather/blob/master/LICENSE) para obter detalhes.
