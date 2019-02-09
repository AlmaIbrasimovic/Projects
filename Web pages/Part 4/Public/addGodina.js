function test() {
    var div = document.getElementById ("validator");
    var inputNaziv = document.getElementById("prvi");
    var validacija = new Validacija(div);
    var prva = validacija.godina(inputNaziv);
    var druga = validacija.repozitorij(document.getElementById("drugi"),/[A-Za-z]+/);
    var treca = validacija.repozitorij(document.getElementById("treci"),/[A-Za-z]+/);
    if (prva == true && druga == true && treca == true) return true;
    return false;
}
function pozoviAJAX() {
    var div = document.getElementById("glavniSadrzaj");
    var ajax = new GodineAjax(div);
}