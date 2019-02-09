var temp = 0;
var najveciBrojKolona = 0;
var najveciRed = 0;

/*OVU FUNKCIJU JE POTREBNO POZVATI NAKON KREIRANJE SVIH COMMITA DA BI SE KREIRALA ZADNJA PRAZNA KOLONA U REDU!!!!
U slučaju da se ne pozove, a ubaci se dodajCommit() kreira previše praznih kolona jer se svaki put pozove.*/
function popravi () {
    var tabela = document.getElementById("tabela");
    if (temp == 0) {
        for (var i=0; i<tabela.rows.length; i++) {
            var duzina = tabela.rows[i].cells.length;
            if (duzina != najveciBrojKolona && tabela.rows[i].cells[duzina-1].innerHTML != ""  && i != najveciRed ) {
                var stara = tabela.rows[i].cells[duzina-1];
                var nova = tabela.rows[i].insertCell(duzina);
                nova.setAttribute('colSpan',parseInt(najveciBrojKolona - duzina + 1));
                stara.setAttribute('colspan', parseInt(1));       
            }
        } 
    }
}
var CommitTabela=(function(){  
    var konstruktor=function(divElement,brojZadataka){

        //Kreiranje i uređivanje tabele
        var tabela = document.createElement('TABLE');
        tabela.id = "tabela";
        tabela.border = '1';
        tabela.width = "30%";
        tabela.style.borderCollapse = "collapse";
        
        //Umetanje <th> elemenata u tabelu
        var thead = document.createElement('thead');
        tabela.appendChild(thead);
        var th = document.createElement("th");
        th.setAttribute('id', 'zadaci');
        th.style.width= "100px";
        th.style.height= "30px";
        thead.appendChild(th).appendChild(document.createTextNode("Zadaci"));
        var th1 = document.createElement("th");
        th1.setAttribute('id', 'commiti');
        th1.style.width= "100px";
        thead.appendChild(th1).appendChild(document.createTextNode("Commiti"));
       
        //Umetanje redova u tabelu
        var red, celija, celija1;
        for (var i = 0; i<brojZadataka-1; i++) {
            red = tabela.insertRow(i);
            red.id = parseInt(i);
            celija = red.insertCell(0);
            celija1 = red.insertCell(1);
            celija1.setAttribute('id', 'celija' + parseInt(i+1));
            celija.innerHTML = "Zadatak " + parseInt(i+1);
            tabela.appendChild(red);    
        }
        divElement.appendChild(tabela);    
        
    return{
        dodajCommit:function(rbZadatka,url){
         
            //Ukoliko je red prazan,ne kreiramo novu ćeliju nego dodajemo commit u već postojeću 
            var nesto = document.getElementById("tabela").rows[rbZadatka];
            var broj = nesto.getElementsByTagName('a').length; 
            var sviPrazni;
            if (broj == 0) sviPrazni = true;
            else sviPrazni = false;
            if(sviPrazni) this.editujCommit(rbZadatka,1,url);
            else {
                var kolona = parseInt(tabela.rows[rbZadatka].cells.length);
                var temp = tabela.rows[rbZadatka].insertCell(kolona);
                var hyper = document.createElement('a');
                var text = document.createTextNode(parseInt(kolona));
                hyper.setAttribute('href', "http://"+url);
                hyper.appendChild(text);
                temp.appendChild(hyper); 
                for (var i=0; i<tabela.getElementsByTagName('tr').length; i++) {
                    if(tabela.rows[i].cells.length > najveciBrojKolona) {
                        najveciBrojKolona = tabela.rows[i].cells.length;
                        najveciRed = i;
                    }
                }
                document.getElementById("commiti").colSpan = parseInt(najveciBrojKolona-1); 
                for (var i=0; i<tabela.getElementsByTagName('tr').length; i++) {
                    duzina = tabela.rows[i].cells.length;
                    var proba = tabela.rows[i].cells[duzina-1];
                    proba.setAttribute('colSpan',najveciBrojKolona);
                    for (var j = 0; j<=duzina-2; j++) {
                        var temp = tabela.rows[i].cells[j];
                        temp.setAttribute('colSpan', "1");
                      
                    }
                }
            }
        },
        editujCommit:function(rbZadatka,rbCommita,url){
            if (rbZadatka > tabela.getElementsByTagName('tr').length || rbCommita > document.getElementById("tabela").rows[rbZadatka].cells[rbCommita]) return -1;
            if (tabela.rows[rbZadatka].cells[rbCommita].innerHTML = " ") {
                var hyper = document.createElement('a');
                var text = document.createTextNode(parseInt(rbCommita));
                hyper.setAttribute('href', "http://" + url);
                hyper.appendChild(text);
                tabela.rows[rbZadatka].cells[rbCommita].appendChild(hyper);
            }
            else tabela.rows[rbZadatka].getElementsByTagName('a')[rbCommita].setAttribute("href", "http://" + url);
        },
        obrisiCommit:function(rbZadatka,rbCommita){
            //Provjeravamo da li je je red prazan, tj, nema niti jednog commita u njemu
            if (rbCommita == 0) return -1;
            if (tabela.rows[rbZadatka].getElementsByTagName('a').length == 0) return -1;
            else if (tabela.rows[rbZadatka].getElementsByTagName('a').length == 1) {
                tabela.rows[rbZadatka].cells[rbCommita].innerHTML = "";
                return;
            }
            if (rbZadatka >= tabela.getElementsByTagName('tr').length || rbCommita >= tabela.rows[rbZadatka].cells.length) return -1;
            this.editujCommit(rbZadatka,rbCommita," ");
            tabela.rows[rbZadatka].deleteCell(rbCommita);
            var duzina = tabela.rows[rbZadatka].cells.length-1;
            for (var i = 0; i<duzina; i++) tabela.rows[rbZadatka].getElementsByTagName('a')[i].innerHTML = parseInt(i+1);
        }
    }
}
return konstruktor;
}());

/*Nakon svih kreiranja commita pozvati pomoćnu funkciju*/
//popravi();