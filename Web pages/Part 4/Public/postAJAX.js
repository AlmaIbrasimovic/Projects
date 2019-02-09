var postAJAX = (function(){
    var konstruktor = function(){ 
        return {
            ucitajUIndex:function(x){
                var godinaT = document.getElementsByName("sGodina")[0].value;
                var json = {godina:godinaT, studenti:x};
                var proba = new XMLHttpRequest();
                proba.open("POST","http://localhost:8080/student" ,true );
                proba.setRequestHeader("Content-Type", "application/json");
                proba.send(JSON.stringify(json));
                proba.onreadystatechange = function() {
                    if (proba.readyState == 4 && proba.status == 200) {
                        alert(proba.responseText);
                    }
                }
            }
        }
    }
    return konstruktor;
}());