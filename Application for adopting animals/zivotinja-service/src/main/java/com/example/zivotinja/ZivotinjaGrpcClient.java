package com.example.zivotinja;
import com.example.systemevents.PetFriend;
import com.example.systemevents.SystemEventsGrpc;
import com.google.protobuf.Timestamp;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import java.time.Instant;

public class ZivotinjaGrpcClient {

    public static void main (String[] args) {
        ManagedChannel channel = ManagedChannelBuilder.forAddress("localhost", 8083).usePlaintext().build(); // PORT za gRPV server
        SystemEventsGrpc.SystemEventsBlockingStub blockStub = SystemEventsGrpc.newBlockingStub(channel);
        Instant time = Instant.now();
        Timestamp vrijeme = Timestamp.newBuilder().setSeconds(time.getEpochSecond())
                .setNanos(time.getNano()).build();

        PetFriend.Request zahtjev = PetFriend.Request.newBuilder()
                .setTimeStampAkcije(vrijeme)
                .setNazivMikroservisa("Zivotinja MS")
                .setKorisnik("Alma")
                .setNazivResursa("Zivotinja")
                .build();

        PetFriend.Response odgovor = blockStub.logAction(zahtjev);
        System.out.println (odgovor.getPorukaOdgovora());
        channel.shutdown();
    }
}
