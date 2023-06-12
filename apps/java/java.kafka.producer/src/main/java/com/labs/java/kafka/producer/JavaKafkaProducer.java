/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 */

package com.labs.java.kafka.producer;

import java.util.Properties;
import org.apache.kafka.clients.producer.KafkaProducer;
import org.apache.kafka.clients.producer.ProducerRecord;

/**
 *
 * @author Andreslon
 */
public class JavaKafkaProducer {

    public static void main(String[] args) {
                // Configuración del productor
        Properties props = new Properties();
        props.put("bootstrap.servers", "localhost:9092"); // Dirección y puerto de los brokers de Kafka
        props.put("key.serializer", "org.apache.kafka.common.serialization.StringSerializer");
        props.put("value.serializer", "org.apache.kafka.common.serialization.StringSerializer");

        // Crear el productor
        KafkaProducer<String, String> producer = new KafkaProducer<>(props);

        // Enviar mensajes al topic "mi-topic" en un bucle
        String topic = "lab-topic";
        int messageCounter = 0;
        while (true) {
            String message = "Mensaje enviado desde java " + messageCounter;
            ProducerRecord<String, String> record = new ProducerRecord<>(topic, message);
            producer.send(record);
            System.out.println("Mensaje enviado desde java: " + message);
            messageCounter++;

            // Esperar un intervalo de tiempo antes de enviar el siguiente mensaje
            try {
                Thread.sleep(1000); // Esperar 1 segundo
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }

        // Cerrar el productor (Este código no se alcanza en este ejemplo, ya que el bucle while es infinito)
        // producer.close();
    }
}
