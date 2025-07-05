// Script de inicialização do MongoDB para criar usuário específico da aplicação

// Conecta ao banco de dados da aplicação
db = db.getSiblingDB('cinema_ecommerce_ticket');

// Cria o usuário específico para a aplicação Cinema
db.createUser({
  user: "cinema_app_user",
  pwd: "cinema_secure_db_2025",
  roles: [
    {
      role: "readWrite",
      db: "cinema_ecommerce_ticket"
    }
  ]
});

// Opcional: Criar índices iniciais se necessário
// db.tickets.createIndex({ "ticketId": 1 }, { unique: true });
// db.tickets.createIndex({ "userId": 1 });
// db.tickets.createIndex({ "sessionId": 1 });

print("Usuário cinema_app_user criado com sucesso no banco cinema_ecommerce_ticket!");
