package com.example.zivotinja.model;

import org.springframework.web.bind.annotation.RestController;

@RestController
public class RabbitMQController {

   /* @Autowired
    RabbitMQSender rabbitMQSender;

    @PostMapping("/send")
    public String sendMessage(@RequestBody Vakcina vakcina){
        rabbitMQSender.send(vakcina);
        return "Tip vakcine: " + vakcina.getTip() + ", revakcinacija: " + vakcina.getRevakcinacija();
    }*/
}
