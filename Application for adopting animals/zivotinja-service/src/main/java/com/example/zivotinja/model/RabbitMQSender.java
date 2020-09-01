package com.example.zivotinja.model;

import org.springframework.stereotype.Service;

@Service
public class RabbitMQSender {

   /* @Autowired
    private AmqpTemplate rabbitTemplate;

    public void send(Vakcina vakcina) {
        rabbitTemplate.convertAndSend(ConfigurationRabbitMQ.EXCHANGE_NAME, ConfigurationRabbitMQ.ROUTING_KEY, vakcina);
        System.out.println("Tip vakcine: " + vakcina.getTip() + ", revakcinacija: " + vakcina.getRevakcinacija());
    }*/
}
