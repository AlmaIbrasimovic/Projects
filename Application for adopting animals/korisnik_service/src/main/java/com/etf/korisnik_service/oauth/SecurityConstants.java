package com.etf.korisnik_service.oauth;


public class SecurityConstants {
    public static final String SECRET = "secret";
    public static final long EXPIRATION_TIME = 864_000_000; // 10 days
    public static final String TOKEN_PREFIX = "Bearer ";
    public static final String HEADER_STRING = "authorization";
    public static final String REGISTER_URL = "/oauth/korisnik";
    public static final String LOGIN_URL = "/oauth/korisnik/prijava";
    public static final String AUTH_URL = "/authenticate";
    public static final String VALIDATION_URL = "/validate-token";
    public static final String SWAGGER_URL = "/swagger-ui.html";
}
