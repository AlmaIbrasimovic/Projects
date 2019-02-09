var tabela;
function nacrtaj() {
    var mojDiv=document.getElementById("mojDiv");
    tabela = new CommitTabela(mojDiv,8);
}

function dodajCommit() { 
    if (tabela == null) alert("Potrebno je prvo nacrtati tabelu pa editovati!");
    var red = document.getElementById("dodavanjeRed").value;
    tabela.dodajCommit(red,document.getElementById("dodavanjeUrl").value);
}

function obrisiCommit() {
    if (tabela == null) alert("Potrebno je prvo nacrtati tabelu pa editovati!");
    var red = document.getElementById("brisanjeRed").value;
    var kolona = document.getElementById("brisanjeKolona").value;
    tabela.obrisiCommit(red,kolona);

}
function editovanjeCommit() {
    if (tabela == null) alert("Potrebno je prvo nacrtati tabelu pa editovati!");
    var red = document.getElementById("editovanjeRed").value;
    var kolona = document.getElementById("editovanjeKolona").value;
    tabela.editujCommit(red,kolona,document.getElementById("editovanjeUrl").value);
}