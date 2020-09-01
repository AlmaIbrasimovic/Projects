package com.example.systemevents;
import com.example.systemevents.PetFriend.Request;
import com.example.systemevents.PetFriend.Response;
import io.grpc.stub.StreamObserver;
import org.lognet.springboot.grpc.GRpcService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@GRpcService
public class SystemEventsService extends SystemEventsGrpc.SystemEventsImplBase {


   final ActionRepository actionRepository;

   public SystemEventsService(ActionRepository actionRepository) {
       this.actionRepository = actionRepository;
   }

    @Override
    public void logAction(Request request, StreamObserver<Response> responseObserver) {
        StringBuilder Odgovor = new StringBuilder()
                .append("Vrijeme:" + request.getTimeStampAkcije())
                .append("Naziv mikroservisa: " + request.getNazivMikroservisa())
                .append("\n")
                .append("Tip akcije: " + request.getAkcija())
                .append("\n")
                .append("Naziv resursa: " + request.getNazivResursa())
                .append("\n");

        Response response = Response.newBuilder()
                .setPorukaOdgovora(Odgovor.toString())
                .build();
        System.out.println(request.getNazivMikroservisa());

        Action zapis = new Action(request.getNazivMikroservisa(),request.getKorisnik(),request.getAkcija(),response.getPorukaOdgovora());
        actionRepository.save(zapis);

        responseObserver.onNext(response);
        responseObserver.onCompleted();
    }


}
