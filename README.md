<h1 align="center">🚧 Projeto em Construção... 🚧</h1>

<h1 align="center">DockerMicroservices</h1>

🛠 Tecnologias Utilizadas
<p align="left"> <img src="https://img.shields.io/badge/.NET-8.0-blue" alt=".NET 8.0"> <img src="https://img.shields.io/badge/Refit-5.0.0-blue" alt="Refit"> <img src="https://img.shields.io/badge/Swagger-3.0.0-green" alt="Swagger"> <img src="https://img.shields.io/badge/Docker-Compose-blue" alt="Docker Compose"> <img src="https://img.shields.io/badge/Entity%20Framework-6.0.0-green" alt="Entity Framework"> <img src="https://img.shields.io/badge/JWT-5.0.0-red" alt="JWT"> <img src="https://img.shields.io/badge/AutoMapper-10.0.0-yellow" alt="AutoMapper"> <img src="https://img.shields.io/badge/RabbitMQ-3.8.9-orange" alt="RabbitMQ"> </p>

<br><br>

📚 Sobre o Projeto
<p>Este projeto foi desenvolvido com o objetivo de aprender a construção e aperfeiçoar meu conhecimento na implementação de microsserviços utilizando Docker e Docker Compose, com a tecnologia .NET 8. O projeto integra diversas bibliotecas como Entity Framework (ORM), AutoMapper, RabbitMQ para mensageria, além de CQRS, Clean Architecture e Domain-Driven Design (DDD).</p>

<ul>
  <li><strong>CQRS (Command Query Responsibility Segregation)</strong>: Esta é uma abordagem de design de software que separa a lógica de leitura da lógica de escrita, permitindo que as consultas sejam otimizadas para leitura e os comandos para escrita. Isso pode melhorar a escalabilidade e a performance do sistema.</li>
  <li><strong>Clean Architecture</strong>: Este é um modelo arquitetural que promove a separação de preocupações e a organização do código em camadas, garantindo que a lógica de negócio fique independente de detalhes de implementação, como frameworks e interfaces de usuário. Isso facilita a manutenção e a escalabilidade do projeto.</li>
  <li><strong>Domain-Driven Design (DDD)</strong>: Este é um conjunto de princípios e padrões que ajudam a criar sistemas de software que refletem com precisão as regras e processos do domínio de negócios. Utiliza conceitos como Entidades, Agregados e Repositórios para modelar a lógica de negócio de forma coesa e compreensível.</li>
</ul>


<br><br>

🚀 Funcionalidades
<p> <b>CRUD de Produtos</b>: API para cadastro e gerenciamento de produtos.<br> <b>Consumo de API</b>: API de CadastroProduto consumida por outra API chamada APIRefit.<br> <b>Mensageria</b>: Orquestração de mensagens entre microsserviços utilizando RabbitMQ.<br> <b>Autenticação JWT</b>: API para autenticação de usuários utilizando JWT.<br> <b>Gerenciamento de Usuários</b>: API para gerenciamento de usuários.<br> <b>Comparativo de Preços</b>: RPA para pesquisar produtos no Mercado Livre e Amazon, gravando o menor preço na tabela de estoque. </p>
<br><br>

🗂️ Estrutura do Projeto
Serviços Configurados no Docker Compose
<p> <b>SQL Server</b>: Sistema gerenciador de banco de dados relacional. O banco de dados será criado para persistência de dados.<br> <b>Volumes</b>: Cria um volume na pasta <code>./DockerMicroservices/volumes</code> para garantir que os dados do banco não sejam perdidos. </p>
<p> <b>API AuthenticationService</b>: API para fazer login com usuário para fazer autenticação JWT</p>
<p> <b>API UserService</b>: API para fazer gerencimento de usuários</p>
<p> <b>API ProductService</b>: API responsável por persistir e obter dados salvos no banco de dados. </p>
<p> <b>RabbitMQ</b>: Container configurado com RabbitMQ para orquestração de mensagens entre os microsserviços. </p>
<p> <b>RPAMercadoLivreService</b>: RPA responsável por pesquisar produto no site do Mercado Livre e gravar o menos preço na tabela de estoque, usada para fazer comparativo de preço</p>
<br>
<br>

📈 Status do Projeto
<p>

[x] Organizar solução separando projetos e itens por pastas<br>

[x] Adicionar .gitignore para C#<br>

[x] Trocar Dapper por Entity Framework<br>

[x] Criar API para gerar e validar tokens JWT<br>

[x] Remover serviço mssqltools e criar banco por migrations<br>

[x] Implementar RabbitMQ<br>

[x] Implementar AutoMapper<br>

[X] Padrão CQRS <br>

[] Implementar Clean Architecture</p>
<br>
<br>


📥 Clone o Repositório
```
$ git clone https://github.com/richardvepogg/DockerMicroservices.git
```
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

<br>
<br>
<p><b>🗂️ Estrutura dos Containers</b></p>
<br>
<b>Redes:<b>
<br>
<p> <b>redemicrosservices</b>: Rede bridge com a sub-rede <code>172.18.0.0/16</code>. </p>
<br>
<b><p>Containers e Endpoints:</p></b>
<p> <b>SQL Server</b><br> <b>Imagem</b>: <code>mcr.microsoft.com/mssql/server:2022-latest</code><br> <b>Container Name</b>: <code>sqlserver</code><br> <b>Hostname</b>: <code>hostsqlserver</code><br> <b>Volumes</b>: <code>./volumes:/var/opt/mssql/data</code><br> <b>Portas</b>: <code>1433:1433</code><br> <b>Endereço IP</b>: <code>172.18.0.6</code><br> <b>Ambiente</b>:<br>

<code>ACCEPT_EULA: 'Y'</code><br>

<code>MSSQL_SA_PASSWORD: 'microservicos123!'</code><br>

<code>MSSQL_PID: 'Developer'</code> </p>

<p> <b>RabbitMQ</b><br> <b>Imagem</b>: <code>rabbitmq:3-management</code><br> <b>Container Name</b>: <code>rabbitmq</code><br> <b>Portas</b>: <code>5672:5672</code>, <code>15672:15672</code><br> <b>Endereço IP</b>: <code>172.18.0.9</code><br> <b>Ambiente</b>:<br>

<code>RABBITMQ_DEFAULT_USER: 'adm'</code><br>

<code>RABBITMQ_DEFAULT_PASS: '123'</code> </p>

<p> <b>UserService</b><br> <b>Imagem</b>: <code>api-usuarios</code><br> <b>Container Name</b>: <code>apiUsuarios</code><br> <b>Dockerfile</b>: <code>ProductService\UserService.WebApi\Dockerfile</code><br> <b>Portas</b>: <code>5020:5020</code><br> <b>Endereço IP</b>: <code>172.18.0.7</code><br> <b>Depende de</b>: <code>sqlserver</code> </p>

<p> <b>AuthenticationService</b><br> <b>Imagem</b>: <code>api-autenticacao</code><br> <b>Container Name</b>: <code>apiAutenticacao</code><br> <b>Dockerfile</b>: <code>AuthenticationService\AuthenticationService.WebApi\Dockerfile</code><br> <b>Portas</b>: <code>5030:5030</code><br> <b>Endereço IP</b>: <code>172.18.0.8</code><br> <b>Depende de</b>: <code>apiusuarios</code> </p>

<p> <b>RPAMercadoLivreService</b><br> <b>Imagem</b>: <code>console-rpamercadolivre</code><br> <b>Container Name</b>: <code>rpaMercadoLivre</code><br> <b>Dockerfile</b>: <code>RPAMercadoLivreService\RPAMercadoLivre.Console\Dockerfile</code><br> <b>Endereço IP</b>: <code>172.18.0.10</code><br> <b>Depende de</b>: <code>rabbitmq</code> </p>

<p> <b>ProductService</b><br> <b>Imagem</b>: <code>api-cadastroproduto</code><br> <b>Container Name</b>: <code>cadastroProduto</code><br> <b>Dockerfile</b>: <code>ProductService\ProductService.WebApi\Dockerfile</code><br> <b>Portas</b>: <code>5010:5010</code><br> <b>Endereço IP</b>: <code>172.18.0.5</code><br> <b>Depende de</b>: <code>sqlserver</code>, <code>rabbitmq</code> </p>
<br><br>


🌐 Endpoints
<p><b>(SQL Server)</b> iniciará na porta: <code>1433</code><br><b>(RabbitMQ)</b> iniciará nas portas: <code>5672</code> e <code>15672</code><br><b>(UserService)</b> iniciará na porta: <code>5020</code> - <code>http://localhost:5020/swagger</code><br><b>(AuthenticationService)</b> iniciará na porta: <code>5030</code> - <code>http://localhost:5030/swagger</code> <br><b>(ProductService)</b> iniciará na porta: <code>5010</code> - <code>http://localhost:5010/swagger</code><br><b>(RPAMercadoLivreService)</b> não possui porta exposta<br></p>
