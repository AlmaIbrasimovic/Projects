package com.etf.systemevents;
import io.grpc.Server;
import io.grpc.ServerBuilder;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import java.io.IOException;

@SpringBootApplication
public class SystemEventsApplication {

    private static final Logger log = LoggerFactory.getLogger(SystemEventsApplication.class);

    @Autowired
    private static ActionRepository actionRepository;

    public static void main(String[] args) throws IOException, InterruptedException {
        SpringApplication.run(SystemEventsApplication.class, args);
        Server server = ServerBuilder.forPort(8083).addService(new SystemEventsService(actionRepository)).build();
        server.start();
        System.out.println("gRPC server runing on port " + server.getPort());
        server.awaitTermination();
    }
}
