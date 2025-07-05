#!/bin/bash

RABBITMQ_HOST=${RABBITMQ_HOST:-rabbitmq}
RABBITMQ_ADMIN_USER=${RABBITMQ_ADMIN_USER:-admin}
RABBITMQ_ADMIN_PASS=${RABBITMQ_ADMIN_PASS:-admin123}

echo "Aguardando RabbitMQ Management API em $RABBITMQ_HOST:15672..."

# Aguarda a API de Management estar disponível
until curl -f -s -u $RABBITMQ_ADMIN_USER:$RABBITMQ_ADMIN_PASS http://$RABBITMQ_HOST:15672/api/overview >/dev/null 2>&1; do
    echo "Aguardando RabbitMQ Management API..."
    sleep 3
done

echo "RabbitMQ Management API disponível, criando usuários..."

# Criar usuário apigateway_user
echo "Criando usuário apigateway_user..."
curl -f -u $RABBITMQ_ADMIN_USER:$RABBITMQ_ADMIN_PASS \
  -X PUT \
  -H "Content-Type: application/json" \
  -d '{"password":"apigateway_pass123","tags":"management"}' \
  http://$RABBITMQ_HOST:15672/api/users/apigateway_user

# Definir permissões para apigateway_user
echo "Definindo permissões para apigateway_user..."
curl -f -u $RABBITMQ_ADMIN_USER:$RABBITMQ_ADMIN_PASS \
  -X PUT \
  -H "Content-Type: application/json" \
  -d '{"configure":".*","write":".*","read":".*"}' \
  http://$RABBITMQ_HOST:15672/api/permissions/%2F/apigateway_user

# Criar usuário ecommerce_user
echo "Criando usuário ecommerce_user..."
curl -f -u $RABBITMQ_ADMIN_USER:$RABBITMQ_ADMIN_PASS \
  -X PUT \
  -H "Content-Type: application/json" \
  -d '{"password":"ecommerce_pass123","tags":"management"}' \
  http://$RABBITMQ_HOST:15672/api/users/ecommerce_user

# Definir permissões para ecommerce_user
echo "Definindo permissões para ecommerce_user..."
curl -f -u $RABBITMQ_ADMIN_USER:$RABBITMQ_ADMIN_PASS \
  -X PUT \
  -H "Content-Type: application/json" \
  -d '{"configure":".*","write":".*","read":".*"}' \
  http://$RABBITMQ_HOST:15672/api/permissions/%2F/ecommerce_user

# Criar fila cinema-ecommerce-criacao-ticket
echo "Criando fila cinema-ecommerce-criacao-ticket..."
curl -f -u $RABBITMQ_ADMIN_USER:$RABBITMQ_ADMIN_PASS \
  -X PUT \
  -H "Content-Type: application/json" \
  -d '{"durable":true,"auto_delete":false}' \
  http://$RABBITMQ_HOST:15672/api/queues/%2F/cinema-ecommerce-criacao-ticket

echo "Configuração do RabbitMQ concluída com sucesso!"
echo "Usuários criados: apigateway_user, ecommerce_user"
echo "Fila criada: cinema-ecommerce-criacao-ticket"