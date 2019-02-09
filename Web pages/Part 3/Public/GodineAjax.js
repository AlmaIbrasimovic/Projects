var GodineAjax = (function(){
    var konstruktor = function(divSadrzaj){
       var ajax = new XMLHttpRequest();
       ajax.open ("GET", "http://localhost:8080/godine", true);
       ajax.setRequestHeader("Content-Type", "application/json");
       ajax.send();
    
       ajax.onreadystatechange = function() {
       if (ajax.readyState == 4 && ajax.status == 200) {
                var godine = JSON.parse(ajax.responseText);
                var ispis = ""
                for (var i = 0; i<godine.length; i++) {
                    ispis += `
                    <div class ="godina">
                    <div class = "naslov">` + godine[i].nazivGod + `</div>
                        <div class = "vrijednosti">
                            <p><strong>Vjezba: </strong>` + godine[i].nazivRepVje + `</p>
                            <p><strong>Spirala: </strong>` + godine[i].nazivRepSpi + `</p>
                        </div>
                    </div>`            
                }
                divSadrzaj.innerHTML = ispis;
            }
        }
         return {
             osvjezi:function(){
                 var novi = new XMLHttpRequest();
                 novi.open ("GET", "http://localhost:8080/godine", true);
                 novi.send();        
             }
         }
    }
    return konstruktor; 
}());