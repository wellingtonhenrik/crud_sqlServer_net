 
# Projeto de CRUD de Empresas e Funcionários

Este é um projeto de console em C# que demonstra um CRUD (Create, Read, Update, Delete) básico para o gerenciamento de empresas e funcionários. O projeto é desenvolvido em camadas e utiliza o framework Dapper para acesso ao banco de dados. O SQL Server é usado como banco de dados e é necessário o Visual Studio 2022 para executar o projeto.

## Configuração do Banco de Dados

1. Crie um banco de dados no SQL Server.
2. No diretório raiz do projeto, você encontrará o arquivo `script.sql`. Execute esse script no seu banco de dados para criar as tabelas necessárias.

## Configuração da ConnectionString

1. Abra o arquivo `appsettings.json` localizado na pasta do projeto.
2. Localize a seção `ConnectionStrings` e substitua o valor de `YourConnectionString` pela Connection String do seu banco de dados recém-criado.

```json
"ConnectionStrings": {
  "DefaultConnection": "YourConnectionString"
}```

## Contato 

wellingtonhenrik13@gmail.com.
