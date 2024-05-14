<h1 align="center">🚧 Projeto em construção... 🚧</h1>

<h1 align="center">DockerMicroservices</h1> 

<br>
<p>Projeto foi construído para aprendizagem na construção de microsserviços com Docker e na configuração do Docker Compose, está utilizando .NET 8.
Inseri bibliotecas como Refit para consumo de API,EntityFramework(ORM) e AutoMapper.</p>
<br>

<p> 👉 No que se baseia:
<br>
Crud simples no cadastro de produto, API de cadastro de produto pode ser consumida por outra API chamada de APIRefit.</p>
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
<p>1-Organizar solução por pastas 

{octicons/issueClosed}

</p>

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
3-Esperar o serviço do mssqltools ser encerrado, esse serviço cria o banco de dados "Estoque"
<br>
  
![containermsqtoolsdesativado](https://github.com/richardvepogg/DockerMicroservices/assets/34971908/6689093b-d90a-480c-9034-aceae314d54f)
<br>
Encerramento do container pode ser observado no Docker Desktop
</p>
<br>
<p>O servidor (CadastroProduto) inciará na porta:5010 - acesse http://localhost:5010/swagger
 
<br>  
O servidor (APIRefit) inciará na porta:5000 - acesse http://localhost:5000/swagger</p>
<br>

<p>🛠 Solução de Problemas:</p> 
<br>
<p>1-Erro ao se conectar utilizando usuário "SA"</p>

![msqtoolsfalhaEstoque](https://github.com/richardvepogg/DockerMicroservices/assets/34971908/0a6da006-ebbd-472d-8b54-7d2c73d07d04)
<br>
Clicar em detalhes do container e depois na seção "Logs"
<br>
<p>O problema ocorre quando o serviço "sqlserver" não terminou de criar todos bancos de dados do sistema e o serviço mssqltools tenta criar o banco "Estoque",
<br>
<p>a-Acesse o arquivo do "docker-compose.yml"</p>
<p>b-No serviço "mssqltools" na seção "command" "../bin/bash -c "sleep 70..", aumente o tempo de espera, exemplo: de 70 para 100.</p>
<p>Assim o banco deve ser criado normalmente como no exemplo a seguir:</p>

![DetalhesContainerEstoqueOK](https://github.com/richardvepogg/DockerMicroservices/assets/34971908/e8231b66-ee4c-48f1-b27d-124baae87098)

<p>Caso o mensagem de erro de login persista, aumente o tempo.<p>
