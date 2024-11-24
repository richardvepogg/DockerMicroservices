<h1 align="center">🚧 Projeto em Construção... 🚧</h1>

<h1 align="center">DockerMicroservices</h1>

<p align="center"> <img src="https://img.shields.io/badge/.NET-8.0-blue" alt=".NET 8.0"> <img src="https://img.shields.io/badge/Docker-Compose-blue" alt="Docker Compose"> <img src="https://img.shields.io/badge/RabbitMQ-3.8.9-orange" alt="RabbitMQ"> </p>

<br><br>

📚 Sobre o Projeto
<p>Este projeto foi desenvolvido com o objetivo de aprender a construção de microsserviços utilizando Docker e Docker Compose, com a tecnologia .NET 8. O projeto integra diversas bibliotecas como Refit para consumo de APIs, Entity Framework (ORM), AutoMapper e RabbitMQ para mensageria.</p>

<br><br>

🚀 Funcionalidades
<p>CRUD de Produtos: API para cadastro e gerenciamento de produtos.</p> <p>Consumo de API: API de CadastroProduto consumida por outra API chamada APIRefit.</p> <p>Mensageria: Orquestração de mensagens entre microsserviços utilizando RabbitMQ.</p>

<br><br>

🗂️ Estrutura do Projeto
Serviços Configurados no Docker Compose
<p> <b>SQL Server</b>: Sistema gerenciador de banco de dados relacional. O banco de dados será criado para persistência de dados.<br> <b>Volumes</b>: Cria um volume na pasta <code>./DockerMicroservices/volumes</code> para garantir que os dados do banco não sejam perdidos. </p>

<p> <b>API Refit</b>: API configurada com Refit para consumir a API de CadastroProduto. </p>

<p> <b>CadastroProduto</b>: API responsável por persistir e obter dados salvos no banco de dados. </p>

<p> <b>RabbitMQ</b>: Container configurado com RabbitMQ para orquestração de mensagens entre os microsserviços. </p>

<br><br>

📈 Status do Projeto
<p>

[x] Organizar solução separando projetos e itens por pastas<br>

[x] Adicionar .gitignore para C#<br>

[x] Trocar Dapper por Entity Framework<br>

[x] Criar API para gerar e validar tokens JWT<br>

[x] Remover serviço mssqltools e criar banco por migrations<br>

[x] Implementar RabbitMQ<br>

[x] Implementar AutoMapper<br>

[ ] Criar microsserviço para consumir loja Amazon </p>

<br><br>

🛠 Tecnologias Utilizadas
<p align="left"> <img src="https://img.shields.io/badge/.NET-8.0-blue" alt=".NET 8.0"> <img src="https://img.shields.io/badge/Refit-5.0.0-blue" alt="Refit"> <img src="https://img.shields.io/badge/Swagger-3.0.0-green" alt="Swagger"> <img src="https://img.shields.io/badge/Docker-Compose-blue" alt="Docker Compose"> <img src="https://img.shields.io/badge/Entity%20Framework-6.0.0-green" alt="Entity Framework"> <img src="https://img.shields.io/badge/JWT-5.0.0-red" alt="JWT"> <img src="https://img.shields.io/badge/AutoMapper-10.0.0-yellow" alt="AutoMapper"> <img src="https://img.shields.io/badge/RabbitMQ-3.8.9-orange" alt="RabbitMQ"> </p>

<br><br>

📥 Clone o Repositório
```
$ git clone https://github.com/richardvepogg/DockerMicroservices.git
```
<br>
<br>
<br>
<br>
🛠 Pré-Requisitos
<p>

Instalar Docker Desktop: ao instalar marque a caixa "Install required Windows components for WSL2".<br>

Acessar a solução com Visual Studio. </p>

<br>
<br>
💻 Passos para a Criação dos Containers
<p>

Executar Docker Desktop.<br>

No Visual Studio, selecione o Docker Compose no depurador e execute.<br>

O banco de dados "Estoque" será criado pelo Migrations. </p>

<br><br>

🌐 Endpoints
<p> O servidor (CadastroProduto) iniciará na porta: 5010 - <a href="http://localhost:5010/swagger">acesse o Swagger</a><br> O servidor (APIRefit) iniciará na porta: 5000 - <a href="http://localhost:5000/swagger">acesse o Swagger</a> </p>
