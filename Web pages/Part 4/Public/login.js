function test() {
    var div = document.getElementById ("validator");
    var inputNaziv = document.getElementById("username");
    var inputPass = document.getElementById("password");
    var validacija = new Validacija(div);
    var prva = validacija.ime(inputNaziv);
    var druga = validacija.password(inputPass);
    if (prva == true && druga == true) return true;
    return false;
}