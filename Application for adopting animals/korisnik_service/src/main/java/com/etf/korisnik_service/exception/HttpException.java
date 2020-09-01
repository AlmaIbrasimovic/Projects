package com.etf.korisnik_service.exception;

import org.springframework.http.HttpStatus;

import java.util.Arrays;
import java.util.List;

public class HttpException {
    private HttpStatus status;
    private String message;
    private List<String> errors;

    public HttpException(HttpStatus status, String message, String error) {
        super();
        this.status = status;
        this.message = message;
        errors = Arrays.asList(error);
    }

    public HttpException(HttpStatus status, String message, List<String> error) {
        super();
        this.status = status;
        this.message = message;
        errors = error;
    }

    public HttpException() {
        super();
    }

    public List<String> getErrors() {
        return errors;
    }

    public String getMessage() {
        return message;
    }

    public HttpStatus getStatus() {
        return status;
    }

    public void setStatus(HttpStatus status) {
        this.status = status;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public void setErrors(String error) {
        errors = Arrays.asList(error);
    }

}
