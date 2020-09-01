## Preduslovi
Za uspješno pokretanje ovog projekta potrebno je imati instaliranu odgovarajuću verziju Jave, odnosno `Java 1.8`. 

Aplikacija se pokreće na portu `8081`, i sve rute počinju sa `/api`.

Korištena je Postgres baza podataka, te je potrebno skinuti `PostgreSQL 12`. Baza je konfigurisana na default-nom portu za Postgres - `5432`. Potrebno je napraviti bazu podataka kroz Postgres pod nazivom `anketa_service` i korisnika čiji je username `anketa_service` sa šifrom `ankete`. Pri pokretanju aplikacije, uvijek se ponovo kreira baza i puni podacima. To se može spriječiti postavljanjem `spring.jpa.hibernate.ddl-auto` u okviru `application.properties` na `update` ili `none`. Postavke za bazu zadane u sklopu `application.properties` su u nastavku:

```
spring.jpa.database-platform=org.hibernate.dialect.PostgreSQL10Dialect
spring.datasource.driverClassName=org.postgresql.Driver
spring.jpa.properties.hibernate.default_schema=public
spring.datasource.url=jdbc:postgresql://localhost:5432/anketa_service
spring.datasource.username=anketa_service
spring.datasource.password=ankete
spring.jpa.hibernate.ddl-auto=create
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
Da bi se projekat uspješno pokrenuo, potrebno se navigirati u root direktorij (folder `anketa_service`, gdje se može naći `pom.xml` file) i unijeti komandu `mvn spring-boot:run`.

## Pokretanje testova
Da bi se testovi uspješno pokrenuli, potrebno se navigirati u root direktorij testova (folder `anketa_service`, gdje se može naći `pom.xml` file) i unijeti komandu `mvn test -Dtest=ime fajla sa testovima#ime testne funkcije` (npr. mvn test -Dtest=AnimalControllerTests#getAllAnimals).

## Pristupanje swaggeru
Nakon što se projekat pokrene, omogućen je pregled i testiranje svih API servisa pomoću Swagger-a na sljedećem linku: http://localhost:8081/api/swagger-ui.html.
