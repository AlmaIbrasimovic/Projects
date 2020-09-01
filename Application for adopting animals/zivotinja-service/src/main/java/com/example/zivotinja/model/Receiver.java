package com.example.zivotinja.model;

import com.example.zivotinja.model.ConfigurationRabbitMQ;
import com.example.zivotinja.repository.KorisnikRepository;
import org.springframework.amqp.core.AmqpTemplate;
import org.springframework.amqp.rabbit.annotation.RabbitHandler;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.beans.factory.annotation.Autowired;

@RabbitListener (queues = ConfigurationRabbitMQ.QUEUE_NAME)
public class Receiver {

    @Autowired
    private AmqpTemplate amqpTemplate;

    private String EXCHANGE_NAME = "korisnik-exchange";
    private String ROUTING_KEY = "korisnik";

    @Autowired
    private KorisnikRepository korisnikRepository;

    @RabbitHandler
    public void receive(String id) {
        /*
        System.out.println(" [x] Received '" + id + "'");
        Integer brojZivotinja = korisnikRepository.getZivotinja(Long.parseLong(id));
        Integer brojAnketa = korisnikRepository.getAnketa(Long.parseLong(id));
        if (brojZivotinja != 0) korisnikRepository.deleteMedjuTabela(Long.parseLong(id));
        if (brojAnketa != 0) korisnikRepository.deleteAnketa(Long.parseLong(id));
        korisnikRepository.deleteZivotinjaById(Long.parseLong(id));
        korisnikRepository.deleteById(Long.parseLong(id));
        amqpTemplate.convertAndSend(ConfigurationRabbitMQ.EXCHANGE_NAME, ConfigurationRabbitMQ.ROUTING_KEY, id);*/
    }
}
