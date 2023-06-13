/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 */

package com.labs.java.kafka.producer;

import java.util.Properties;
import org.apache.kafka.clients.producer.KafkaProducer;
import org.apache.kafka.clients.producer.ProducerRecord;
import org.apache.kafka.common.security.plain.PlainLoginModule;

/**
 *
 * @author Andreslon
 */
public class JavaKafkaProducer {

    public static void main(String[] args) {
        // Configuración del productor
        Properties props = new Properties();
        // props.put("bootstrap.servers", "localhost:9092"); // Dirección y puerto de
        // los brokers de Kafka

        props.put("bootstrap.servers", "pkc-56d1g.eastus.azure.confluent.cloud:9092");
        props.put("security.protocol", "SASL_SSL");
        props.put("sasl.mechanism", "PLAIN");
        String KAFKA_USER = "NUVO7A4A3VURIXYX";
        String KAFKA_PASSWORD = "0nGK5ZhpgAZQnhyem16DSE1zGhQH/ybH81YcHTXBPS4AGdnLdie29UtSCiC8dOVC";
        props.put("sasl.jaas.config", PlainLoginModule.class.getName() + " required username=\"" + KAFKA_USER
                + "\" password=\"" + KAFKA_PASSWORD + "\";");

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

        // Cerrar el productor (Este código no se alcanza en este ejemplo, ya que el
        // bucle while es infinito)
        // producer.close();
    }
}
