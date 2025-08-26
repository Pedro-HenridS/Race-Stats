# Race-Stats
Race Stats é uma plataforma desenvolvida para aprimorar o data tracking no universo das corridas automobilísticas. Com uma interface clara e organizada, oferece visualizações precisas e intuitivas de estatísticas, permitindo que entusiastas e profissionais acompanhem de perto o desempenho, tendências e resultados do mundo da alta velocidade.

<p align="center">
  <img src="content/Captura%20de%20tela%202025-08-26%20161259.png" width="45%" />
  <img src="content/Captura%20de%20tela%202025-08-26%20161341.png" width="45%" />
</p>
---

## Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- MySQL 
- Git  

---

## Como baixar e rodar o projeto

1. No Windows: abra o “Prompt de Comando” ou o “PowerShell”.
No macOS/Linux: abra o “Terminal”.

2. Entre no MySQL (se ainda quiser interagir com o MySQL):

```bash
mysql -u seu_usuario -p
```

Depois ele vai pedir a senha.

3. Rodando direto o script .sql:
Basta navegar até a pasta seed do projeto no terminal e executar:

```bash
mysql -u seu_usuario -p < seed/seed.sql
```
Isso vai criar o banco, a tabela teams e inserir os registros que você colocou no arquivo.

4. Clonar o repositório
```bash
# Clonar o repositório
git clone https://github.com/usuario/nome-do-projeto.git
cd nome-do-projeto

#Acesse a pasta api, na rota 'backend/src', pelo terminal e inicie adicione o seguinte user-secret:
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Port=3306;Database=race_stats;User=root;Password=SUA SENHA DO BANCO DE DADOS";

# Na pasta raíz do projeto execute:
dotnet restore
dotnet build
```
5. Subir o backend
```
# Acesse a backend/src/api no terminal e execute o seguinte comando:
dotnet run
```
6. Subir o frontend
```
# Acesse a fronten/src/ no terminal e execute o seguinte comando:
dotnet run

# Neste momento, o Visual Studio irá te redirecionar para a página inicial do projeto: http://localhost:7002/
```

Neste ponto, tanto o a parte client-side quanto o server-side estão operantes e prontas para testes. A seguir.
---

## Endpoints do Backend (Swagger)
Para visualizar os endpoints e testá-los de forma interativa, acesse o Swagger. Após subir o backend, abra seu navegador e navegue até:

http://localhost:5076/swagger/index.html

Nessa interface, você poderá ver a documentação completa da API e realizar requisições de teste diretamente.

## Explicação das telas (Frontend)
1. Ranking
Esta tela exibe o ranking de pilotos por categoria. A barra de navegação no topo permite filtrar a visualização por diferentes categorias de corrida. A tela mostra o nome do piloto, a nacionalidade e a categoria a que pertence, com a possibilidade de ver mais detalhes de cada um.

2. Times
Nesta seção, é possível visualizar todos os times registrados e os pilotos associados a cada um. A barra de navegação superior permite filtrar os times individualmente. É uma visão focada na organização das equipes e na composição de seus membros.

3. Adicionar Piloto
Esta é a tela de formulário para adicionar um novo piloto à base de dados. O usuário preenche campos como nome, nacionalidade, peso, gênero, melhor volta, circuito, equipe e categoria. A interface é intuitiva e guia o usuário no processo de cadastro.

4. Detalhes do Piloto
Ao clicar em um piloto na tela de Ranking, esta tela de detalhes se expande. Ela fornece informações adicionais sobre o piloto, como peso, gênero, circuito e outros dados específicos, oferecendo uma visão mais aprofundada de suas estatísticas.

Requisitos Atendidos
Com base no desafio, os seguintes requisitos foram atendidos:

## Requisitos Mínimos:

- Tecnologias: Uso de Blazor e C#.
- Estrutura de Dados de Piloto: Implementação de um modelo de dados para piloto com as propriedades necessárias.
- Listagem de Pilotos: Exibição de uma lista de pilotos.
- Interface de Ranking: Apresentação dos pilotos de forma organizada.
- Funcionalidades de Filtragem: Implementação de filtros para os dados.

## Requisitos Adicionais:

- Pesquisa por Nome/Equipe: Adição de um campo de busca.
- Adição/Edição de Pilotos: Implementação da tela "Adicionar Piloto" para CRUD básico.

# Decisões de Design e Arquitetura
O projeto foi estruturado com base nos princípios SOLID e no padrão de design Domain-Driven Design (DDD). Esta abordagem foi escolhida para garantir a escalabilidade e a fácil manutenção do sistema, separando as responsabilidades de cada camada (backend e frontend).

Backend: O backend em ASP.NET Core Web API é responsável pela lógica de negócios e persistência de dados. A utilização do DDD nos permite manter o modelo de domínio isolado, facilitando futuras expansões ou migrações.

Frontend: No frontend, a escolha do Blazor com uma abordagem componentizada foi feita para criar uma interface de usuário reativa e modular. Isso garante que cada parte da UI (como os cards de pilotos e os filtros) seja um componente independente e reutilizável. O design foi inspirado no universo do automobilismo para criar uma experiência visual atraente e temática.

Dificuldades e Observações
Uma das principais dificuldades foi a implementação de filtros por meio de querys. Este desafio foi superado mediante estudo e pesquisa. 
