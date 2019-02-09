function poziv() {
    var temp = new ZadaciAjax(function (ispis) {
        var div = document.getElementById("poruka");
        div.innerHTML = ispis;
    })
    temp.dajXML();
  //temp.dajJSON();
 // temp.dajCSV();
}