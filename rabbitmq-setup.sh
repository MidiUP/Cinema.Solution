#!/bin/bash

# Script de inicialização do RabbitMQ para criar usuários específicos para cada aplicação

echo "Aguardando RabbitMQ estar pronto..."

# Aguarda o RabbitMQ estar completamente pronto
until rabbitmqctl node_health_check; do
  echo "RabbitMQ ainda não está pronto, aguardando..."
  sleep 3
done

echo "RabbitMQ está pronto! Configurando usuários das aplicações..."

# ============================
# USUÁRIO PARA API GATEWAY
# ============================
echo "Criando usuário para Cinema API Gateway..."
rabbitmqctl add_user apigateway_user apigateway_secure_2025

# Permissões para API Gateway (pode publicar e consumir mensagens)
rabbitmqctl set_permissions -p / apigateway_user "cinema-.*" "cinema-.*" "cinema-.*"

# Tag para identificar o usuário
rabbitmqctl set_user_tags apigateway_user gateway

# ============================
# USUÁRIO PARA ECOMMERCE TICKET
# ============================
echo "Criando usuário para Cinema Ecommerce Ticket..."
rabbitmqctl add_user ecommerce_user ecommerce_secure_2025

# Permissões para Ecommerce (pode consumir da fila específica)
rabbitmqctl set_permissions -p / ecommerce_user "cinema-ecommerce-.*" "cinema-ecommerce-.*" "cinema-ecommerce-.*"

# Tag para identificar o usuário
rabbitmqctl set_user_tags ecommerce_user service

# ============================
# CRIAÇÃO DAS FILAS
# ============================
echo "Criando filas necessárias..."

# Declara a fila para criação de tickets
rabbitmqctl eval '
rabbit_amqqueue:declare(
    {resource, <<"/">>, queue, <<"cinema-ecommerce-criacao-ticket">>},
    true,
    false,
    [],
    none
).'

echo "✅ Configuração do RabbitMQ concluída!"
echo "Usuários criados:"
echo "  - apigateway_user (para API Gateway)"
echo "  - ecommerce_user (para Ecommerce Ticket)"
echo "Filas criadas:"
echo "  - cinema-ecommerce-criacao-ticket"

# Lista usuários para confirmação
rabbitmqctl list_users
