# Cinema Solution - Sistema de Cinema com Microserviços

Este projeto é uma solução completa de sistema de cinema construída com arquitetura de microserviços utilizando .NET Core, Docker e tecnologias modernas de desenvolvimento.

## 📋 Índice

- [Visão Geral](#visão-geral)
- [Arquitetura](#arquitetura)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Microserviços](#microserviços)
- [Infraestrutura](#infraestrutura)
- [Pré-requisitos](#pré-requisitos)
- [Instalação e Execução](#instalação-e-execução)
- [Configuração](#configuração)
- [Endpoints da API](#endpoints-da-api)
- [Monitoramento](#monitoramento)
- [Desenvolvimento](#desenvolvimento)
- [Troubleshooting](#troubleshooting)

## 🎯 Visão Geral

O Cinema Solution é um sistema completo para gerenciamento de cinema que inclui:

- **Catálogo de Filmes**: Integração com TMDB API para informações de filmes
- **E-commerce de Ingressos**: Sistema completo de venda de ingressos
- **API Gateway**: Ponto único de entrada para todos os serviços
- **Mensageria Assíncrona**: Comunicação entre serviços via RabbitMQ
- **Cache**: Redis para otimização de performance
- **Persistência**: MongoDB para dados de e-commerce

## 🏗️ Arquitetura

O sistema segue uma arquitetura de microserviços com os seguintes componentes:

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   API Gateway   │────│  Catalog API    │    │ ECommerce API   │
│    (Port 5000)  │    │   (Port 5002)   │    │   (Port 5001)   │
└─────────────────┘    └─────────────────┘    └─────────────────┘
         │                       │                       │
         └───────────────────────┼───────────────────────┘
                                 │
         ┌───────────────────────┼───────────────────────┐
         │                       │                       │
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│    RabbitMQ     │    │     MongoDB     │    │      Redis      │
│   (Port 5672)   │    │   (Port 27018)  │    │   (Port 6379)   │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

## 🛠️ Tecnologias Utilizadas

### Backend
- **.NET Core 8**: Framework principal para desenvolvimento das APIs
- **ASP.NET Core**: Para construção das APIs REST
- **C#**: Linguagem de programação principal

### Banco de Dados e Cache
- **MongoDB 7.0**: Banco de dados NoSQL para persistência de dados do e-commerce
- **Redis 7**: Cache em memória para otimização de performance

### Mensageria
- **RabbitMQ 3**: Message broker para comunicação assíncrona entre serviços

### Infraestrutura
- **Docker**: Containerização dos serviços
- **Docker Compose**: Orquestração dos containers

### APIs Externas
- **TMDB API**: The Movie Database para informações de filmes

## 🔧 Microserviços

### 1. API Gateway (`cinema-apigateway-api`)
- **Porta**: 5000
- **Responsabilidade**: Ponto único de entrada, roteamento e autenticação
- **Tecnologias**: ASP.NET Core
- **Comunicação**: HTTP com outros serviços, RabbitMQ para mensagens assíncronas

### 2. Catalog API (`cinema-catalog-api`)
- **Porta**: 5002
- **Responsabilidade**: Gerenciamento do catálogo de filmes
- **Tecnologias**: ASP.NET Core, integração com TMDB API
- **Funcionalidades**:
  - Busca de filmes
  - Informações detalhadas de filmes
  - Cache de dados de filmes

### 3. E-commerce Ticket API (`cinema-ecommerce-ticket-api`)
- **Porta**: 5001
- **Responsabilidade**: Gerenciamento de vendas de ingressos
- **Tecnologias**: ASP.NET Core, MongoDB, Redis, RabbitMQ
- **Funcionalidades**:
  - Criação de pedidos
  - Processamento de pagamentos
  - Gerenciamento de ingressos
  - Cache de sessões

## 🗄️ Infraestrutura

### RabbitMQ
- **Imagem**: `rabbitmq:3-management`
- **Portas**: 5672 (AMQP), 15672 (Management UI)
- **Credenciais**: admin/admin123
- **Filas Configuradas**:
  - `cinema-ecommerce-criacao-ticket`: Para criação de ingressos

### MongoDB
- **Imagem**: `mongo:7.0`
- **Porta**: 27018 (mapeada para 27017 interno)
- **Credenciais**: root/example
- **Databases**:
  - `cinema_ecommerce_ticket`: Dados do e-commerce
- **Collections**:
  - `tickets`: Armazenamento de ingressos

### Redis
- **Imagem**: `redis:7-alpine`
- **Porta**: 6379
- **Senha**: redispassword
- **Configuração**: Persistência habilitada com AOF

## 📋 Pré-requisitos

### Software Necessário
- [Docker](https://www.docker.com/get-started) (versão 20.10 ou superior)
- [Docker Compose](https://docs.docker.com/compose/install/) (versão 2.0 ou superior)
- [Git](https://git-scm.com/) para clonar o repositório

### Recursos do Sistema
- **RAM**: Mínimo 4GB (recomendado 8GB)
- **Espaço em Disco**: 5GB livres
- **CPU**: 2 cores (recomendado 4 cores)

### Portas Necessárias
Certifique-se de que as seguintes portas estejam livres:
- 5000 (API Gateway)
- 5001 (E-commerce API)
- 5002 (Catalog API)
- 5672 (RabbitMQ AMQP)
- 15672 (RabbitMQ Management)
- 6379 (Redis)
- 27018 (MongoDB)

## 🚀 Instalação e Execução

### 1. Clone o Repositório
```bash
git clone <url-do-repositorio>
cd Cinema.Solution
```

### 2. Verifique os Scripts de Inicialização
Certifique-se de que os seguintes arquivos existem:
- `scripts/rabbitmq-init.sh`: Script de inicialização do RabbitMQ
- `scripts/mongo-init.js`: Script de inicialização do MongoDB

### 3. Execute o Sistema
```bash
# Construir e iniciar todos os serviços
docker-compose up --build

# Para executar em background
docker-compose up --build -d

# Para visualizar logs em tempo real
docker-compose logs -f
```

### 4. Verificar o Status dos Serviços
```bash
# Verificar status de todos os containers
docker-compose ps

# Verificar logs de um serviço específico
docker-compose logs cinema-apigateway-api
```

### 5. Parar o Sistema
```bash
# Parar todos os serviços
docker-compose down

# Parar e remover volumes (ATENÇÃO: apaga dados persistidos)
docker-compose down -v
```

## ⚙️ Configuração

### Variáveis de Ambiente

#### API Gateway
```env
RabbitMq__Host=rabbitmq
RabbitMq__Port=5672
RabbitMq__Username=apigateway_user
RabbitMq__Password=apigateway_pass123
EcommerceTicketApi__BaseUrl=http://cinema-ecommerce-ticket-api:5000/api/
CatalogApi__BaseUrl=http://cinema-catalog-api:5000/api/
```

#### E-commerce Ticket API
```env
RabbitMq__Host=rabbitmq
RabbitMq__Username=ecommerce_user
RabbitMq__Password=ecommerce_pass123
MongoDb__ConnectionString=mongodb://ecommerce_user:ecommerce_mongo_pass123@mongodb:27017/cinema_ecommerce_ticket?authSource=admin
Redis__ConnectionString=redis:6379,password=redispassword
```

#### Catalog API
```env
TmdbApi__BaseUrl=https://api.themoviedb.org/3/
TmdbApi__ApiKey=1f54bd990f1cdfb230adb312546d765d
```

### Configuração do TMDB API
1. Registre-se em [The Movie Database](https://www.themoviedb.org/)
2. Obtenha sua API Key
3. Atualize as variáveis `TmdbApi__ApiKey` e `TmdbApi__AuthToken`

## 🌐 Endpoints da API

### API Gateway (http://localhost:5000)
```
GET    /api/health                                   # Health check
GET    /api/v1/catalog/movies                        # Buscar filmes via gateway
POST   /api/v1/ecommerceticket/check-in              # Criar ticket via gateway
GET    /api/v1/ecommerceticket/tickets/{customerId}  # Buscar tickets de um cliente via gateway
```

### Catalog API (http://localhost:5002)
```
GET    /api/health                   # Health check
GET    /api/v1/movies                   # Listar filmes
GET    /api/v1/movies/{id}              # Detalhes do filme
```

### E-commerce Ticket API (http://localhost:5001)
```
GET    /api/health                   # Health check
GET    /api/v1/tickets{customerId}   # Buscar tickets de um cliente
```

## 📊 Monitoramento

### RabbitMQ Management Interface
- **URL**: http://localhost:15672
- **Usuário**: admin
- **Senha**: admin123
- **Funcionalidades**:
  - Monitor de filas
  - Estatísticas de mensagens
  - Gerenciamento de exchanges e bindings

### Health Checks
Todos os serviços possuem health checks configurados:
- **RabbitMQ**: `rabbitmq-diagnostics ping`
- **MongoDB**: `db.runCommand("ping").ok`
- **Redis**: `redis-cli --raw incr ping`

### Logs
```bash
# Ver logs de todos os serviços
docker-compose logs

# Ver logs de um serviço específico
docker-compose logs cinema-apigateway-api

# Ver logs em tempo real
docker-compose logs -f cinema-ecommerce-ticket-api
```

## 👨‍💻 Desenvolvimento

### Estrutura do Projeto
```
Cinema.Solution/
├── Cinema.APIGateway/
│   └── src/Cinema.APIGateway.API/
├── Cinema.EcommerceTicket/
│   └── src/Cinema.EcommerceTicket.API/
├── Cinema.Catalog/
│   └── src/Cinema.Catalog.API/
├── scripts/
│   ├── rabbitmq-init.sh
│   └── mongo-init.js
├── docker-compose.yml
└── README.md
```

### Desenvolvimento Local

#### 1. Executar Apenas a Infraestrutura
```bash
# Executar apenas MongoDB, Redis e RabbitMQ
docker-compose up rabbitmq mongodb redis
```

#### 2. Executar APIs Localmente
```bash
# No diretório de cada projeto
dotnet run --project src/{NomeDoProjeto}.API
```

#### 3. Debug no Visual Studio/VS Code
1. Configure as variáveis de ambiente locais
2. Ajuste as connection strings para localhost
3. Execute cada projeto individualmente

### Padrões de Código
- **Arquitetura**: Clean Architecture
- **Padrões**: Repository Pattern, DDD, SOLID, Facade, Adapter, etc...
- **Logging**: Structured logging com Serilog
- **Validação**: Validação de domínio
- **Mapeamento**: AutoMapper de domínio

## 🐛 Troubleshooting

### Problemas Comuns

#### 1. Erro "Port already in use"
```bash
# Verificar processos usando as portas
netstat -ano | findstr :5000
netstat -ano | findstr :5672

# Parar containers em execução
docker-compose down
```

#### 2. Erro de Conexão com MongoDB
```bash
# Verificar se o MongoDB está rodando
docker-compose logs mongodb

# Conectar diretamente ao MongoDB
docker exec -it cinema-mongodb mongosh -u root -p example
```

#### 3. Erro de Conexão com RabbitMQ
```bash
# Verificar status do RabbitMQ
docker-compose logs rabbitmq

# Acessar o container do RabbitMQ
docker exec -it cinema-rabbitmq bash
```

#### 4. APIs não se comunicam
```bash
# Verificar a rede Docker
docker network ls
docker network inspect cinema_app_network

# Verificar conectividade entre containers
docker exec cinema-apigateway-api ping cinema-catalog-api
```

### Comandos Úteis de Debug

```bash
# Verificar todos os containers
docker ps -a

# Verificar uso de recursos
docker stats

# Limpar recursos não utilizados
docker system prune

# Reconstruir containers
docker-compose build --no-cache

# Verificar logs detalhados
docker-compose logs --details
```

### Reset Completo do Ambiente
```bash
# Parar todos os serviços
docker-compose down

# Remover volumes (ATENÇÃO: apaga todos os dados)
docker-compose down -v

# Remover imagens
docker-compose down --rmi all

# Reconstruir tudo
docker-compose up --build
```

### Padrões de Commit
- `feat`: Nova funcionalidade
- `fix`: Correção de bug
- `docs`: Atualização de documentação
- `style`: Mudanças de formatação
- `refactor`: Refatoração de código
- `test`: Adição ou modificação de testes

---

**Desenvolvido com ❤️ por Mateus Mendes**
