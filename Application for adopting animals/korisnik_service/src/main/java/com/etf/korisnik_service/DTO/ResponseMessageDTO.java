package com.etf.korisnik_service.DTO;

import java.util.HashMap;

public class ResponseMessageDTO {
    String message;

    public ResponseMessageDTO(String message) {
        this.message = message;
    }

    public HashMap<String,String> getHashMap() {
        HashMap<String, String> map = new HashMap<>();
        map.put("message", message);
        return map;
    }
}
