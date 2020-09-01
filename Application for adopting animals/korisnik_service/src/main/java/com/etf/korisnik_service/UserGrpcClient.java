package com.etf.korisnik_service;

import com.etf.systemevents.PetFriend;
import com.etf.systemevents.SystemEventsGrpc;
import com.google.protobuf.Timestamp;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import org.springframework.context.annotation.Configuration;

import java.time.Instant;

public class UserGrpcClient {

    public static void main (String[] args) {
        ManagedChannel channel = ManagedChannelBuilder.forAddress("localhost", 8083).usePlaintext().build(); // PORT za gRPV server
        SystemEventsGrpc.SystemEventsBlockingStub blockStub = SystemEventsGrpc.newBlockingStub(channel);
        Instant time = Instant.now();
        Timestamp vrijeme = Timestamp.newBuilder().setSeconds(time.getEpochSecond())
                .setNanos(time.getNano()).build();

        PetFriend.Request zahtjev = PetFriend.Request.newBuilder()
                .setTimeStampAkcije(vrijeme)
                .setNazivMikroservisa("Korisnik MS")
                .setKorisnik("Zlata")
                .setNazivResursa("Korisnik")
                .build();

        PetFriend.Response odgovor = blockStub.logAction(zahtjev);
        System.out.println (odgovor.getPorukaOdgovora());
        channel.shutdown();
    }
}
