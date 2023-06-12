from kafka import KafkaConsumer

# Configuración del consumidor
bootstrap_servers = 'localhost:9092'  # Dirección y puerto de los brokers de Kafka
topic = 'lab-topic'  # Topic al que se suscribirá el consumidor

# Crear el consumidor
consumer = KafkaConsumer(topic, bootstrap_servers=bootstrap_servers)

# Leer los mensajes del topic
for message in consumer:
    print(f"Mensaje recibido: {message.value.decode('utf-8')}")

# Cerrar el consumidor
consumer.close()
