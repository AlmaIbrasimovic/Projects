var citanjeGodina = (function () {
    var konstruktor = function () {

        //Ovaj poziv šalje zahtjev za sve godine iz baze i upisuje ih u select na stranici
        var ajaxGodine = new XMLHttpRequest();
        ajaxGodine.open('GET', 'http://localhost:8080/addVjezba', true);
        ajaxGodine.setRequestHeader("Content-Type", "application/json");
        ajaxGodine.send();
        ajaxGodine.onreadystatechange = function () {
            if (ajaxGodine.readyState == 4 && ajaxGodine.status == 200) {
                var godineRes = JSON.parse(ajaxGodine.responseText);
                var godine = document.getElementsByName("sGodina")[0];
                for (var i = 0; i < godineRes.length; i++) {
                    var god = godineRes[i].nazivGod;
                    var element = document.createElement("option");
                    element.textContent = god; element.value = god;
                    godine.appendChild(element);

                }
            }
        }
    }
    return konstruktor;
}());

