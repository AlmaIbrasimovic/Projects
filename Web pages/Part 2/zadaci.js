function test() {
    var div = document.getElementById ("validator");
    var inputNaziv = document.getElementById("ime");
    var validacija = new Validacija(div);
    var prva = validacija.ime(inputNaziv);
    return prva;
}