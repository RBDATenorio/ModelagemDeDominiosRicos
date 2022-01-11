# Modelagem de Domínios Ricos

## Descrição

Já ouviu falar em CQRS, Event Sourcing, Mediatr, Value Objects e Raízes de Agregação? Esses são temas abordados no conceito de Domínios Ricos e esse repositório foi construído seguindo o curso de [Modelagem de Domínios Ricos](https://desenvolvedor.io/curso-online-modelagem-de-dominios-ricos) do [Desenvolvedor.io](https://desenvolvedor.io/), e se baseia na implementação de conceitos de Domain Driven Design (DDD) com .NET. Houve adaptações do conteúdo ministrado, como por exemplo, implementação de duas bases de dados, uma para leitura e escrita (na aplicação do CQRS), uso do docker para subir os containers com os bancos de dados e não utilizei o SQL Server, mas sim o PostgreSQL.

## Utilização

Para rodar essa aplicação você ter o [Docker](https://www.docker.com/). Então vamos subir primeiro os containers, entre no diretório docker e no terminal rode:

```
docker compose up -d
```

E é isso, você já tem uma instância do postgresql que pode ser acessada pela porta 5432 e outra do mongodb rodando na porta 27107. Agora podemos partir para a aplicação.

Vamos buildar nossa solução, se você estiver utilizando o VisualStudio, clicando com o botão direito do mouse sobre o arquivo da solução vá para "compilar solução", se estiver usando pelo VS Code você efetua esse processo por linha de comando, digitando no terminal, na raiz da aplicação:

```
dotnet build
```
Com os pacotes devidamente instalados, podemos partir para a criação das tabelas no banco de dados. Aqui utilizei a técnica de Code First, ou seja, primeiro fiz a modelagem das entidades e por meio do Entity Framework fiz o mapeamento para o banco de dados.

Se você estiver utilizando o CLI do dotnet, vá para a pasta "Data" (por exemplo, ModelagemDeDomíniosRicos.Catalogo.Data) de cada prjeto e execute:

```
dotnet ef migrations add Initial
dotnet ef database update
```


Ou se for pelo VisualStudio, utilize o CLI do Nuget:

```
Add-Migration Initial
Update-Database
```

Pronto, já temos as tabelas criadas no banco que estamos rodando no docker!



