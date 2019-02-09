var ZadaciAjax = (function(){
    var konstruktor = function(callbackFn){ 
        var ajax = new XMLHttpRequest();
        ajax.open ("GET", "http://localhost:8080/zadaci", true);
        return {
            dajXML:function(){
                ajax.setRequestHeader("Accept", "application/xml");
                ajax.send();
    
                ajax.onreadystatechange = function() {
                    if (ajax.readyState == 4 && ajax.status == 200) {
                        callbackFn("<xmp>"+ ajax.responseText + "</xmp>");
                    }
                }
            },
            dajCSV:function(){
                ajax.setRequestHeader("Accept", "text/csv");
                ajax.send();
                ajax.onreadystatechange = function() {
                    if (ajax.readyState == 4 && ajax.status == 200) {
                        var temp = ajax.responseText;   
                        var odgovor ="";
                        var niz = temp.split("\n");
                        for (var i = 0; i<niz.length; i++) {
                            var kolone = niz[i].split(",");
                            odgovor+=kolone + "<br>";
                        }
                        callbackFn(odgovor);
                    }
                }
            },
            dajJSON:function(){
                ajax.setRequestHeader("Accept", "application/json");
                ajax.send();
                ajax.onreadystatechange = function() {
                    if (ajax.readyState == 4 && ajax.status == 200) {
                        callbackFn(ajax.responseText);
                    }
                }
            }
        }
    }
    return konstruktor;
}());