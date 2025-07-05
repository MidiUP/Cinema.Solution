// Script de inicialização do MongoDB para criar usuário específico da aplicação

// Conecta ao banco de dados admin para criar usuário com permissões globais
db = db.getSiblingDB('admin');

// Verifica se o usuário já existe
const existingUser = db.getUser("ecommerce_user");
if (existingUser) {
    print("Usuário ecommerce_user já existe, removendo para recriar...");
    db.dropUser("ecommerce_user");
}

// Cria o usuário específico para a aplicação Cinema Ecommerce Ticket
db.createUser({
  user: "ecommerce_user",
  pwd: "ecommerce_mongo_pass123",
  roles: [
    {
      role: "readWriteAnyDatabase",
      db: "admin"
    },
    {
      role: "dbAdminAnyDatabase", 
      db: "admin"
    },
    {
      role: "userAdminAnyDatabase",
      db: "admin"
    }
  ]
});

// Conecta ao banco específico da aplicação e garante que existe
db = db.getSiblingDB('cinema_ecommerce_ticket');

// Cria uma coleção inicial se não existir
if (!db.getCollectionNames().includes('tickets')) {
    db.createCollection('tickets');
    print("Coleção 'tickets' criada no banco cinema_ecommerce_ticket");
}

print("Usuário ecommerce_user criado com sucesso com permissões administrativas!");
