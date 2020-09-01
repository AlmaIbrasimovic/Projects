## Preduslovi
Za uspješno pokretanje ovog projekta potrebno je imati instaliranu odgovarajuću verziju Jave, odnosno `Java 1.8`. 

`Eureka` se pokreće na portu `8761`. Postavke zadane u sklopu `application.properties` su u nastavku:

```
server.port=8761

eureka.client.register-with-eureka=false
eureka.client.fetch-registry=false

logging.level.com.netflix.eureka=OFF
logging.level.com.netflix.discovery=OFF
```

## Pokretanje projekta
Da bi se projekat uspješno pokrenuo, potrebno se navigirati u root direktorij (folder `eureka-service`, gdje se može naći `pom.xml` file) i unijeti komandu `mvn spring-boot:run`.
