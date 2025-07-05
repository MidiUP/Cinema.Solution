#!/bin/bash

# Aguarda o RabbitMQ inicializar
sleep 10

# Cria usuários específicos para cada aplicação
rabbitmqctl add_user apigateway_user apigateway_pass123
rabbitmqctl add_user ecommerce_user ecommerce_pass123

# Define permissões para os usuários (configure, write, read)
rabbitmqctl set_permissions -p / apigateway_user ".*" ".*" ".*"
rabbitmqctl set_permissions -p / ecommerce_user ".*" ".*" ".*"

# Define tags para os usuários
rabbitmqctl set_user_tags apigateway_user management
rabbitmqctl set_user_tags ecommerce_user management

echo "Usuários RabbitMQ criados com sucesso!"