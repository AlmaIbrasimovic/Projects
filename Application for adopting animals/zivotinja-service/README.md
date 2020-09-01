## Preduslovi za pokretanje projekta
Da bi se projekt uspješno pokrenuo potrebno je imati instaliranu verziju `Java 1.8`. Baza koja se trenutno koristi je `H2 Database Engine`. Postavke za bazu su sljedeće.
```
server.port=8080
spring.application.name=zivotinjaService
spring.h2.console.enabled=true
spring.datasource.username=mace
spring.datasource.password=cuke
eureka.client.serviceUrl.defaultZone=http://localhost:8761/eureka

```
Da bi se svi mikroservisi uspješno povezali, potrebno je konfigurisati `Eureka` lokalno.
```
server.port=8761
eureka.client.register-with-eureka=false
eureka.client.fetch-registry=false
logging.level.com.netflix.eureka=OFF
logging.level.com.netflix.discovery=OFF
```

Svi mikroservisi i Eureka moraju biti pokrenuti u isto vrijeme da bi se mogla ostvariti komunikacija.

## Pokretanje projekta
Da bi se projekat uspješno pokrenuo, potrebno se navigirati u root 
## Pokretanje testova
Da bi se testovi uspješno pokrenuli, potrebno se navigirati  u root direktorij `zivotinja-service` (gdje se nalazi `pom.xml` file)  i unijeti komandu mvn test `-Dtest=ime fajla sa testovima (npr. mvn test -Dtest=BolestControllerTest)`

## Pristupanje swaggeru
Nakon što se projekat pokrene, omogućen je pregleda svih API servisa pomoću Swagger-a na sljedećem linku: http://localhost:8080/swagger-ui.html

## Kreiranje Docker slike
Prvo je potrebno kreirati `jar` file projekta. To se radi sa naredbom `mvn clean package`. Nakon što se uspješno kreira `jar file`, potrebno je kreirati i Docker sliku. Potrebno je unijeti sljedeću naredbu u terminal `docker build -f Dockerfile -t zivotinja-service-docker .` Slika se može zasebno pokrenuti, bez ostalih projekata, sa naredbom `docker run -p 8080:8080`
