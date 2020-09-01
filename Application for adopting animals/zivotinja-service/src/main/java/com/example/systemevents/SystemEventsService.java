package com.example.systemevents;

import com.example.systemevents.PetFriend.Response;
import io.grpc.stub.StreamObserver;

public class SystemEventsService extends SystemEventsGrpc.SystemEventsImplBase {


   private final ActionRepository actionRepository;

   public SystemEventsService(ActionRepository actionRepository) {
       this.actionRepository = actionRepository;
   }

    @Override
    public void logAction(PetFriend.Request request, StreamObserver<Response> responseObserver) {
        StringBuilder Odgovor = new StringBuilder()
                .append("Vrijeme:" + request.getTimeStampAkcije())
                .append("Naziv mikroservisa: " + request.getNazivMikroservisa())
                .append("\n")
                .append("Tip akcije: " + request.getAkcija())
                .append("\n")
                .append("Naziv resursa: " + request.getNazivResursa())
                .append("\n");

        PetFriend.Response response = Response.newBuilder()
                .setPorukaOdgovora(Odgovor.toString())
                .build();

        Action zapis = new Action(request.getNazivMikroservisa(),request.getKorisnik(),request.getAkcija(),response.getPorukaOdgovora());
        actionRepository.save(zapis);

        responseObserver.onNext(response);
        responseObserver.onCompleted();
    }
}
