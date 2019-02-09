function test() {
    var div = document.getElementById ("validator");
    var inputNaziv = document.getElementById("ime");
    var validacija = new Validacija(div);
    var prva = validacija.ime(inputNaziv);
    var druga = validacija.index(document.getElementById("index"));
    var god = document.getElementById("godinaSelect");
    var treca = validacija.godina(god);
    if (prva == true && druga == true && treca == true) return true;
    return false;
}
function drugiTest() {
    var div = document.getElementById ("validatorA");
    var god = document.getElementById("godinaSel");
    var validacija = new Validacija(div);
    return validacija.godina(god);
}