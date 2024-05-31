<h1 align="center">🚧 Projeto em construção... 🚧</h1>

<h1 align="center">DockerMicroservices</h1> 

<br>
<p>Projeto foi construído para aprendizagem na construção de microsserviços com Docker e na configuração do Docker Compose, está utilizando .NET 8.
Inseri bibliotecas como Refit para consumo de API,EntityFramework(ORM), AutoMapper e mensageria pelo RabbitMQ.</p>
<br>

<p> 👉 No que se baseia:
<br>
Crud simples no cadastro de produto, API de CadastroProduto pode ser consumida por outra API chamada de APIRefit.</p>
<br>

<p>👉 Serviços configurados no docker compose:
<br>
<br>
1-sqlserver: Microsoft SQL Server, é um sistema gerenciador de Banco de dados relacional, <b>aqui será criado nosso banco para persistência de dados.</b>
<br>
volumes: Cria um volume na pasta ./DockerMicroservices\volumes para que o que foi salvado no BD não se perca.
<br> 

2- apirefit: API com Refit configurado para consumir a API cadastroproduto.
<br>

3- cadastroproduto: API que irá persistir o e obter dados salvos no banco de dados.
<br>
<br>
<p>👉 Status 💻</p>
<br>
<p>Fazendo as seguintes mudanças.</p>
<p>1-Organizar solução separando projetos e itens por pastas: FEITO!</p>
<p>2-C# .gitignore: FEITO!</p>
<p>3-Trocar Dapper por Entity Framework: FEITO!</p>
<p>4-Criar uma API para gerar token JWT, método para gerar token e outro para validar</p>
<p>5-Remover serviço mssqltools, criação do banco deve ser por migrations: FEITO!</p>
<p>6-Criar Bootstrapper.cs</p>
<p>7-Implementar RabbitMQ</p>
<p>8-Implementar AutoMapper</p>
<br>

<p>🛠 Tecnologias utilizadas
<br>
As seguintes ferramentas foram usadas na construção do projeto:
<br>
.NET 8
<br>
Refit
<br>
Swagger
<br>
Docker
<br>
Entity Framework
<br>
JWT
<br>
AutoMapper
<br>
RabbitMQ
</p>

<br>
<p>👉 Baixe o código
Clone este repositório
<br>
$ git clone [https://github.com/richardvepogg/DockerMicroservices.git]
</p>
<br>

<p>🛠 Pré-Requisitos:
<br>
1-Instalar Docker Desktop: ao instalar marque a caixa "Install required Windows components for WSL2".
<br>  
2-Acesse a solução com Visual Studio.</p>
<br>

<p>💻 Passos para a criação dos containers
<br>  
1-Executar Docker Desktop.
<br>  
2-No depurador (Visual Studio) selecione o docker compose e execute.
<br>  
3-Banco de dados "Estoque" será criado pelo Migrations
<br>

</p>
<br>
<p>O servidor (CadastroProduto) inciará na porta:5010 - acesse http://localhost:5010/swagger
 
<br>  
O servidor (APIRefit) inciará na porta:5000 - acesse http://localhost:5000/swagger</p>
<br>
