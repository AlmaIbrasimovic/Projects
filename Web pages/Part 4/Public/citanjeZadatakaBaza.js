var citanjeZadatakaBaza = (function () {
    var konstruktor = function (ime) {

        //Ovaj poziv šalje zahtjev za sve vjezbe iz baze
        var ajaxGodine = new XMLHttpRequest();
        ajaxGodine.open('GET', 'http://localhost:8080/addVjezbaCitanjeVjezbi', true);
        ajaxGodine.setRequestHeader("Content-Type", "application/json");
        ajaxGodine.send();
        var vjezbeRes;
        ajaxGodine.onreadystatechange = function () {
            if (ajaxGodine.readyState == 4 && ajaxGodine.status == 200) {
                vjezbeRes = JSON.parse(ajaxGodine.responseText);
            }
        }

        //Dobavljanje podataka iz među tabele
        var medjuTabela = new XMLHttpRequest();
        medjuTabela.open('GET', 'http://localhost:8080/dajMedjuTabelu?id=' + ime, true);
        medjuTabela.send();
        var medjuRes;
        var c = [];
        medjuTabela.onreadystatechange = function() {
            if (medjuTabela.readyState == 4 && medjuTabela.status == 200) {
                medjuRes = JSON.parse(medjuTabela.responseText);
                var zadaci = new XMLHttpRequest();
                zadaci.open('GET', 'http://localhost:8080/dajZadatke', true);
                zadaci.send();
                var zad;
                var sviZadaci = [];
                zadaci.onreadystatechange = function() {
                    if (zadaci.readyState == 4 && zadaci.status == 200) {
                        zad = JSON.parse(zadaci.responseText);
                        var j=0;
                        for (var k=0; k < zad.length; ++k) {
                            if (medjuRes.indexOf(zad[k].id) == -1)
                                c[j++] = zad[k];
                        }
                        let selectZadaci = document.getElementsByName("sZadatak")[0];  
                        for (var z=0; z<selectZadaci.length-1; z++) {   
                            selectZadaci.remove(z);
                        }
                        for (var i = 0; i < c.length; i++) {
                            selectZadaci.remove(i);
                            let temp = c[i].naziv;
                            let elementic = document.createElement("option");
                            elementic.value = temp;
                            elementic.textContent = temp;
                            selectZadaci.appendChild(elementic);
                        }                                                        
                    }
                }
            }
        }
    }
    return konstruktor;
}());

