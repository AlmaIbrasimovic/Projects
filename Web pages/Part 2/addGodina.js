function test() {
    var div = document.getElementById ("validator");
    var inputNaziv = document.getElementById("prvi");
    var validacija = new Validacija(div);
    var prva = validacija.naziv(inputNaziv);
    var druga = validacija.naziv(document.getElementById("drugi"));
    var treca = validacija.naziv (document.getElementById("treci"));
    if (prva == true && druga == true && treca == true) return true;
    return false;
}