# livrariadoluiz
Sistema de Livraria com as funções de Adicionar, Editar e Excluir Livros, Gêneros e Autores;

# Tecnologias
    C# .NET 8
    SQL Server
    Angular

# Executar Projeto
    No Arquivo DockerCompose iniciará três containers: um do banco de dados SQL Server, um do BackEnd e o ultimo do FrontEnd
    A migration para iniciar o banco será executada automaticamente. Após alguns segundos o sistema estará no ar.

    Executar o comando "docker-compose up"
    O backend estará executando na porta 5001 (http://localhost:5001);
    O frontend estará executando na porta 8091 (http://localhost:8091);

    Para Acessar o Sistema da Livraria:
    http://localhost:8091/

    Para Acessar o BackEnd:
    http://localhost:5001/swagger