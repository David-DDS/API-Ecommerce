🛒 E-Commerce API
📌 Descrição
Esta API de E-Commerce foi desenvolvida para gerenciar clientes, produtos, pedidos, pagamentos e itens do pedido.
Ela permite realizar operações de CRUD (Create, Read, Update, Delete) e está otimizada para .NET 9, utilizando Entity Framework Core e injeção de dependência.

⚙️ Tecnologias Utilizadas
✅ .NET 9
✅ ASP.NET Core Web API
✅ Entity Framework Core
✅ SQL Server
✅ Swagger (OpenAPI)
✅ Injeção de Dependência

🚀 Instalação e Configuração
1️⃣ Clonar o Repositório
git clone https://github.com/David-DDS/ecommerce-api.git
cd ecommerce-api


2️⃣ Instalar Dependências
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Swashbuckle.AspNetCore


3️⃣ Configurar o Banco de Dados
Edite o appsettings.json para definir a conexão com o banco de dados:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ECommerceDB;Trusted_Connection=True;"
}


4️⃣ Executar as Migrações do Banco de Dados
dotnet ef migrations add InitialCreate
dotnet ef database update


5- Criar o CRUD
Cada entidade terá um CRUD completo, incluindo Controller, Repository e Interface.
Exemplo: Cliente
📌 Criamos:
- ClienteController.cs
- IClienteRepository.cs
- ClienteRepository.cs

6- Aplicando o método construtor (ctor);
  
7- Configurar a injeção de Dependência na program de todas as Entidades.

🔍 Entidades e Endpoints
🟢 Clientes
📍 Rota: /api/cliente
✅ Criar Cliente: POST /api/cliente
✅ Listar Clientes: GET /api/cliente
✅ Buscar Cliente por ID: GET /api/cliente/{id}
✅ Atualizar Cliente: PUT /api/cliente/{id}
✅ Deletar Cliente: DELETE /api/cliente/{id}

🔵 Produtos
📍 Rota: /api/produto
✅ Criar Produto: POST /api/produto
✅ Listar Produtos: GET /api/produto
✅ Buscar Produto por ID: GET /api/produto/{id}
✅ Atualizar Produto: PUT /api/produto/{id}
✅ Deletar Produto: DELETE /api/produto/{id}

🟡 Pedidos
📍 Rota: /api/pedido
✅ Criar Pedido: POST /api/pedido
✅ Listar Pedidos: GET /api/pedido
✅ Buscar Pedido por ID: GET /api/pedido/{id}
✅ Atualizar Pedido: PUT /api/pedido/{id}
✅ Deletar Pedido: DELETE /api/pedido/{id}

🟠 Pagamentos
📍 Rota: /api/pagamento
✅ Criar Pagamento: POST /api/pagamento
✅ Listar Pagamentos: GET /api/pagamento
✅ Buscar Pagamento por ID: GET /api/pagamento/{id}
✅ Atualizar Pagamento: PUT /api/pagamento/{id}
✅ Deletar Pagamento: DELETE /api/pagamento/{id}

🔴 Itens do Pedido
📍 Rota: /api/itempedido
✅ Criar Item do Pedido: POST /api/itempedido
✅ Listar Itens do Pedido: GET /api/itempedido
✅ Buscar Item do Pedido por ID: GET /api/itempedido/{id}
✅ Atualizar Item do Pedido: PUT /api/itempedido/{id}
✅ Deletar Item do Pedido: DELETE /api/itempedido/{id}

🛠️ Testando a API
1️⃣ Executar a API
configurar o Swagger na program.cs


2️⃣ Acessar Swagger para Testes
Após iniciar a API, acesse o Swagger para testar os endpoints de forma interativa:
📍 http://localhost:5000/swagger

🏗️ Estrutura do Projeto
ECommerceAPI/
│── Controllers/
│   ├── ClienteController.cs
│   ├── ProdutoController.cs
│   ├── PedidoController.cs
│   ├── PagamentoController.cs
│   ├── ItemPedidoController.cs
│── Models/
│   ├── Cliente.cs
│   ├── Produto.cs
│   ├── Pedido.cs
│   ├── Pagamento.cs
│   ├── ItemPedido.cs
│── Repositories/
│   ├── ClienteRepository.cs
│   ├── ProdutoRepository.cs
│   ├── PedidoRepository.cs
│   ├── PagamentoRepository.cs
│   ├── ItemPedidoRepository.cs
│── Interfaces/
│   ├── IClienteRepository.cs
│   ├── IProdutoRepository.cs
│   ├── IPedidoRepository.cs
│   ├── IPagamentoRepository.cs
│   ├── IItemPedidoRepository.cs
│── Database/
│   ├── AppDbContext.cs
│── Program.cs
│── appsettings.json
│── README.md



📌 Melhorias Futuras
🔹 Implementar autenticação e autorização (JWT)
🔹 Melhorar logging e monitoramento
🔹 Criar integração com gateways de pagamento
🔹 Desenvolver testes automatizados


