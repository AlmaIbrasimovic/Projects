
var Validacija=(function(){
    var naziv = true;
    var index = true;
    var ime = true;
    var password = true;
    var godina = true;
    var rep = true;
    var url = true;
    
/*Funckija koja ispisuje greške na div.
Radi na sljedeći način: Prvo kreiramo mapu sa svim mogućim greškama i dodijelimo vrijednost 0 (znači nema greška tog tipa). Dalje provjeravamo da li postoji određena greška
ukoliko da, promijenimo vrijednost u mapi na 1 i samo ispišemo na ekran.*/
function ispisiGresku(divElementPoruke) {
    var poruka = "Sljedeća polja nisu validna: ";
    var mapa = new Map();
    mapa.set('ime', '0'); 
    mapa.set('godina', '0');
    mapa.set('repezitorij', '0');
    mapa.set('index', '0');
    mapa.set('naziv', '0');
    mapa.set('password', '0');
    mapa.set('url', '0');
    if (naziv == false) mapa.set('naziv', '1');
    if (url == false) mapa.set('url', '1');
    if (index == false) mapa.set ('index', '1')
    if (ime == false) mapa.set ('ime', '1')
    if (rep = false) mapa.set('repezirorij', '1');
    if (password == false) mapa.set ('password', '1')
    if (godina == false) mapa.set ('godina', '1')
    for (var [key, value] of mapa) if (value == '1') poruka += key + ',';
    var ispravni = true;
    for (var [key, value] of mapa) {
        if(value == '1') {
            ispravni = false;
            break;
        }
    }
    /*U slučaju kada se zarez nalazi iza zadnje riječi, a ne bi trebao, pa kreiramo pomoćni string koji je kopija naše poruke pa poredimo da li je zarez.
    Ukoliko je zarez, zamijenimo ga sa !*/
    var temp = poruka;
    var zadnji = temp.slice(-1);
    var pomocni;
    if (zadnji == ',') pomocni = poruka.replace(/.$/,"!")
    if (ispravni) poruka = "";
    divElementPoruke.textContent= pomocni;
}

    var konstruktor=function(divElementPoruke){
    return{
        ime:function(inputElement){
            var uslov = false;
            var imeRegex = /^([A-Z]{1}([a-z]|'(?!')){1,}([\s|-]|[a-zA-Z]?$){1}){1,4}$/g;
            if (imeRegex.test(inputElement.value) == false) {
                ime = false;
                inputElement.style.backgroundColor = "orangered";
                uslov = false;
            }
            else  {
                inputElement.style.backgroundColor = "white";
                ime = true;
                uslov = true;
            }
            ispisiGresku(divElementPoruke);
            return uslov;
        },
        godina:function(inputElement){ 
            var uslov = true;
            var regex = /^20[0-9]{2}\/20[0-9]{2}$/m ;
            var jelOK = regex.test(inputElement.value);
            var prvaGod = inputElement.value.substring(2,4);
            var drugaGod = inputElement.value.substring(7,9); 
            if((parseInt(drugaGod) - parseInt(prvaGod)) > 1 && jelOK == true) uslov = false;
            else if(parseInt(drugaGod) > parseInt(prvaGod) && jelOK == true) uslov= true;
            else uslov = false;
            if(uslov == false){
                inputElement.style.backgroundColor = "orangered";
                godina = false;
            }
            else {
                inputElement.style.backgroundColor = "white";
                godina = true;
            }
            ispisiGresku(divElementPoruke);
            return uslov;
        },
        repozitorij:function(inputElement,regex){
            var uslov = false;
            if (regex.test(inputElement.value) == false) {
                inputElement.style.backgroundColor = "orangered";
                uslov = false;
                rep = false;
            }
            else {
                inputElement.style.backgroundColor = "white";
                uslov = true;
                rep = true;
            }
            ispisiGresku(divElementPoruke);
            return uslov;
        },
        index:function(inputElement){
            var uslov = false;
            var indexRegex = /[1-2]{1}[0,4,5,6,7,8,9]{1}[0-9]{3}/;
            if (indexRegex.test(inputElement.value) == false) {
                index = false;
                inputElement.style.backgroundColor = "orangered";
                uslov = false;
            }
            else  {
                inputElement.style.backgroundColor = "white";
                index = true;
                uslov = true;
            }
            ispisiGresku(divElementPoruke);
            return uslov;
        },
        naziv:function(inputElement){   
            var uslov = false;    
            if (inputElement.length < 3) uslov = false;
            var regexNaziv = /^([a-zA-Z]([A-Z]|[0-9]|[a-z]|(\\|\/|-|"|'|!|\?|:|;|,))+([0-9|[a-z]))$/g;
            if (regexNaziv.test(inputElement.value) == false) {
                naziv = false;
                inputElement.style.backgroundColor = "orangered";
                uslov = false;
            }
            else  {
                inputElement.style.backgroundColor = "white";
                naziv = true;
                uslov = true;
            }
            ispisiGresku(divElementPoruke);
            return uslov;
        },
        password:function(inputElement){
           var uslov = false;
           if (inputElement.value.length == 0 || inputElement.value.length == 1 || inputElement.value.length<8 || ! /^[a-zA-Z0-9]+$/.test(inputElement.value)) {
               uslov = false;
               password = false;
            }
           else {
                var dtemp = RegExp('[0-9]'); //cifre
                var dVelika = RegExp('[A-Z]'); //velika
                var dMala = RegExp ('[a-z]'); //mala
                var m = false; var v = false; var b = false;
                if (dVelika.test(inputElement.value) == true) v = true;
                if (dMala.test(inputElement.value) == true)  m = true; 
                if (dtemp.test(inputElement.value) == true ) b = true;
                if (m == true && v== true) uslov = true;
                else if (m == true && b == true) uslov = true;
                else if (v == true && b == true) uslov = true;
           }
           
           if (uslov == true) {
               inputElement.style.backgroundColor = "white";
               password = true;
           }
           else if (uslov == false) {
               inputElement.style.backgroundColor = "orangered";
               password = false;
           }
           ispisiGresku(divElementPoruke);
           return uslov;
        },
        url:function(inputElement){
           var uslov = false;    
           var regexUrl = /(http|https|ftp|ssh)\:\/\/([A-Za-z\d])+(\.([A-Za-z\d])+)*/g;
           if (regexUrl.test(inputElement.value) == false) {
               url = false;
               inputElement.style.backgroundColor = "orangered";
               uslov = false;
           }
           else  {
               inputElement.style.backgroundColor = "white";
               url = true;
               uslov = true;
           }
           ispisiGresku(divElementPoruke);
           return uslov;
        }
        }
    }
    return konstruktor;
}());