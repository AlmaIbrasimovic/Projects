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