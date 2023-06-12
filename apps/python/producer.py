from kafka import KafkaProducer
import time

# Configuración del productor
bootstrap_servers = 'localhost:9092'  # Dirección y puerto de los brokers de Kafka

# Crear el productor
producer = KafkaProducer(bootstrap_servers=bootstrap_servers)

# Enviar mensajes al topic "mi-topic"
topic = 'lab-topic'
message_counter = 0
while True:
    message = f"Mensaje {message_counter}"
    producer.send(topic, value=message.encode('utf-8'))
    print(f"Mensaje enviado: {message}")
    message_counter += 1

    # Esperar un intervalo de tiempo antes de enviar el siguiente mensaje
    time.sleep(1)  # Esperar 1 segundo

# Cerrar el productor (Este código no se alcanza en este ejemplo, ya que el bucle while es infinito)
# producer.close()