Passo a passo para rodar o projeto no Docker.

1) Mapeie o projeto que está no repositório do Github em um diretório através do comando abaixo:
-> git clone https://github.com/VictorOses/Api_ProdutoComponente.git

2) Em seguida, vá até a raíz do projeto "Api_ProdutoComponente".

3) Em seguida, para rodar os containers execute o comando abaixo:
-> docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

4) Para acessar o projeto, que está liberado na porta 5000, vá até no link abaixo:
-> http://localhost:5000/swagger/index.html

sdhasjkdbaskjdbsajkd