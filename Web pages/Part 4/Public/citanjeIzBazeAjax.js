var citanjeIzBazeAjax = (function () {
    var konstruktor = function () {

        //Ovaj poziv šalje zahtjev za sve godine iz baze i upisuje ih u select na stranici
        var ajaxGodine = new XMLHttpRequest();
        ajaxGodine.open('GET', 'http://localhost:8080/addVjezba', true);
        ajaxGodine.setRequestHeader("Content-Type", "application/json");
        ajaxGodine.send();
        ajaxGodine.onreadystatechange = function () {
            if (ajaxGodine.readyState == 4 && ajaxGodine.status == 200) {
                var godineRes = JSON.parse(ajaxGodine.responseText);
                var godine = document.getElementById("godinaSel");
                var godineNove = document.getElementById("godinaSelect");
                for (var i = 0; i < godineRes.length; i++) {
                    var god = godineRes[i].nazivGod;
                    var element = document.createElement("option");
                    element.textContent = god; element.value = god;
                    var element2 = document.createElement("option");
                    element2.textContent = god; element2.value = god;
                    godine.appendChild(element);
                    godineNove.appendChild(element2);
                }
            }
        }

        //Ovaj poziv salje zahtjev za sve vježbe iz baze i popunjava određene selecte
        var ajaxVjezbe = new XMLHttpRequest();
        ajaxVjezbe.open('GET', 'http://localhost:8080/addVjezbaCitanjeVjezbi', true);
        ajaxVjezbe.setRequestHeader("Content-Type", "application/json");
        ajaxVjezbe.send();
        ajaxVjezbe.onreadystatechange = function () {
            if ( ajaxVjezbe.readyState == 4 &&  ajaxVjezbe.status == 200) {
                let vjezbe = JSON.parse( ajaxVjezbe.responseText);
                let selectVjezbiNova = document.getElementsByName("sVjezbe")[1];         
                let selectVjezbi = document.getElementsByName("sVjezbe")[0];  
                for (var i = 0; i < vjezbe.length; i++) {
                    let temp = vjezbe[i].naziv;
                    let elementic = document.createElement("option");
                    elementic.textContent = temp;
                    elementic.value = temp;
                    let elementic1 = document.createElement("option");
                    elementic1.textContent = temp;
                    elementic1.value = vjezbe[i].id;
                    selectVjezbi.appendChild(elementic);
                    selectVjezbiNova.appendChild(elementic1);
                }
                var selektovanaVjezba = document.getElementsByName('sVjezbe')[1].value;
                var nesto = new citanjeZadatakaBaza(selektovanaVjezba);
            }
            
   
        }
    }
    return konstruktor;
}());

