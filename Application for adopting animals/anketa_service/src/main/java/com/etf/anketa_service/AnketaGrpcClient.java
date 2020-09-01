package com.etf.anketa_service;

import com.etf.systemevents.PetFriend;
import com.etf.systemevents.SystemEventsGrpc;
import com.google.protobuf.Timestamp;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;

import java.time.Instant;

public class AnketaGrpcClient {
    public static void main (String[] args) {
        ManagedChannel channel = ManagedChannelBuilder.forAddress("localhost", 8083).usePlaintext().build();
        SystemEventsGrpc.SystemEventsBlockingStub blockStub = SystemEventsGrpc.newBlockingStub(channel);
        Instant time = Instant.now();
        Timestamp vrijeme = Timestamp.newBuilder().setSeconds(time.getEpochSecond())
                .setNanos(time.getNano()).build();

        PetFriend.Request zahtjev = PetFriend.Request.newBuilder()
                .setTimeStampAkcije(vrijeme)
                .setNazivMikroservisa("anketaService")
                .setNazivResursa("Probni zahtjev")
                .build();

        PetFriend.Response odgovor = blockStub.logAction(zahtjev);
        System.out.println(odgovor.getPorukaOdgovora());
        channel.shutdown();
    }
}

