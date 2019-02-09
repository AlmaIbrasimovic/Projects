function test() {
    var div = document.getElementById ("validator");
    var inputNaziv = document.getElementById("prvi");
    var validacija = new Validacija(div);
    var prva = validacija.naziv(inputNaziv);
    if (prva) return true;
    return false;
}