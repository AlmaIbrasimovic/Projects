
function test() {
    var div = document.getElementById ("validator");
    var inputNaziv = document.getElementById("prvi");
    var validacija = new Validacija(div);
    var prva = validacija.naziv(inputNaziv);
    var god = document.getElementById ("godinaSelect");
    var druga = validacija.godina(god);
    if (prva == true && druga == true) return true;
    return false;
}

function testPrvi() {
    var div = document.getElementById ("validatorA");
    var god = document.getElementById("godinaSel");
    var validacija = new Validacija(div);
    return validacija.godina(god);
}

function citanjeBaze() {
    var godine = document.getElementById("godinaSel");
    var godineNove = document.getElementById("godinaSelect");
    var vjezbe = document.getElementById("vjezbe");
    var ajax = new citanjeIzBazeAjax();
}


function funkcija() {
    var ime = document.getElementsByName("sVjezbe")[1].value;
    var ajax = new citanjeZadatakaBaza(ime);
}

function promijeni() {
    var temp = document.getElementsByName("sVjezbe")[1].value;
    document.getElementsByName('fPoveziZadatak')[0].action = '/vjezba/:' + temp  + '/zadatak';
}