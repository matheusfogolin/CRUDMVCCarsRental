# CRUDMVCCarsRental

## COMO RODAR O PROJETO

**Requisitos:**

- .NET Versão 7.0 ou mais atual;
- Entity Framework Core versão 7.0 ou mais atual;
- Microsoft SQL Server 2019 versão 15.0 ou mais atual.

**CRIAÇÃO DO BANCO DE DADOS**
**PASSO A PASSO**
- Abrir o prompt de comando e navegar até a raiz do projeto;
- Rodar o comando: dotnet ef Migrations add <NomeDaMigration> -o Data/Migrations;
- Após a execução da migration, chegou a hora de criar nosso banco, com o comando: dotnet ef database update;
- Pronto! Seu banco de dados do projeto está criado e pronto para ser populado.

**RODANDO O PROJETO**
**PASSO A PASSO**
- Abrir o prompt de comando e navegar até a raiz do projeto;
- Rodar o comando: dotnet build, para executar o build do projeto;
- Rodar o comando: dotnet run, para executar o projeto.
- Pronto! O projeto estará em execução no localhost:<porta>, conforme imagem abaixo
![image](https://github.com/matheusfogolin/CRUDMVCCarsRental/assets/57686224/c57c49da-40c5-4458-a7ae-57a2ea8e77be)


