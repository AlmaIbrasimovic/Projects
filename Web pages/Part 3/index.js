const express = require('express');
const bodyParser = require('body-parser');
var app = express();
app.use (express.static("Public"));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.set('views', (__dirname+'/views'));
app.set('view engine', 'pug');
var multer  = require('multer');
var fs = require('fs');
const csvR = require('csv-writer').createObjectCsvWriter;
var csv = require ('csv-reader');
var XMLWriter = require('xml-writer');
var path = require('path');

//uploads je folder gdje se spremaju svi .pdf i json fajlovi koji se uploaduju preko forme

//1. ZADATAK
app.get(/\w+\.html$/, function(req, res) {
    let stranica = req.url.substr(1, req.url.length);
    res.contentType ("text/html");
    res.sendFile (__dirname + '/Public/' + stranica, null,function(err) {
        if (err) res.send("HTML fajl ne postoji!");
    }); 
});

//2. ZADATAK

//Kreiranje destinacija za spremanje fajla
var storage = multer.diskStorage({
    destination: function (req, file, cb) {
        cb(null, 'uploads/')
    },
    filename: function (req, file, cb) {
        var ime = req.body.naziv;
        cb(null, ime + ".pdf");
    }
    
});
var upload = multer({ 
    storage: storage,
    
    //Provjera da li je .pdf i da li postoji fajl sa istim imenom
    fileFilter: function (req, file, cb) {
        var ext = file.mimetype;
        var uslov = fs.existsSync("uploads/" + req.body.naziv + ".pdf");
        if (uslov == true) {
             req.fileValidationError = "Postoji fajl sa istim imenom";
             return cb(null, false, req.fileValidationError);
       }
       if(ext != 'application/pdf') {
           req.fileValidationError = "Zabranjena ekstenzija";
           return cb(null, false, req.fileValidationError);
       }
       cb(null, true);
   }
 });

 //Download fajla nakon upload-a
app.get(/.*pdf$/, (req, res) => {
    var imeFajla = req.url;
    var fajl =fs.readFileSync("uploads" + imeFajla);
    res.contentType("application/pdf");
    res.send(fajl);
});

//Spremanje fajla ukoliko je .pdf i kreiranje JSON objekta, ukoliko nije .pdf ispisuje grešku
app.post('/addZadatak',upload.single("postavka"),(req, res) => {
   
    //Ispis poruke ukoliko dođe do greške
    if (req.fileValidationError) {
        res.render("greska", {
            greskaIspis: function() {
                if (req.fileValidationError == "Zabranjena ekstenzija") return "Tip datoteke mora biti .pdf. Vratite se nazad i pokusajte ponovo!";
                return "Vec postoji datoteka sa istim imenom. Vratite se nazad i pokusajte ponovo!";
            }
        });
    }
   else {
        var jsonObjekat = {naziv : req.body.naziv, postavka :"http://localhost:8080/" + req.body.naziv + ".pdf"};
        var json = JSON.stringify(jsonObjekat);
        fs.writeFileSync("uploads/"+req.body.naziv + "Zad.json",json,  function (err) {
            if (err) res.send("Došlo je do neke greške!");
        });
        res.contentType("application/json");
        res.write(json);
        res.end();
   }
});

//3. ZADATAK
app.get ('/zadatak', (req, res) => {
    var url = require('url');
    let parametri = new url.URLSearchParams(req.url);
    let imeFajla = parametri.get("/zadatak?naziv");
    var uslov = fs.existsSync("uploads/" + imeFajla + ".pdf");
    let imalPDF = imeFajla.substr(imeFajla.length-4, 4);
    if (imalPDF == ".pdf") {
        var uslov = fs.existsSync("uploads/" + imeFajla);
        if (uslov == true) {
            var fajl = fs.readFileSync("uploads/" + imeFajla);
            res.contentType("application/pdf");
            res.send(fajl);
        }
        else if (uslov == false) res.send ("Traženi fajl ne postoji! Popravite URL!")
    }
    else {
        var uslov = fs.existsSync("uploads/" + imeFajla + ".pdf");
        if (uslov == true) {
            fajl = fs.readFileSync("uploads/" + imeFajla + ".pdf");
            res.contentType("application/pdf");
            res.send(fajl);
        }
        else if (uslov == false) res.send ("Traženi fajl ne postoji! Popraviti URL!");
    }
});

//4. ZADATAK
app.post('/addGodina', function(req, res) {
    let podaci = req.body;
    let uslov = false; 

    //Kreiranje CSV-writer
    const csvWriter = csvR({
        path: 'godine.csv',
        header: [
            {id: 'godina', title: 'Naziv godine'},
            {id: 'vjezbe', title: 'Naziv repozitorija vjezbe'},
            {id: 'spirala', title: 'Naziv repozitorija spiralae'}
        ],
        encoding: 'utf-8',
        append: true
    });

    //Provjera da li ima godina sa istim imenom
    var sadrzajDatoteka = fs.readFileSync('godine.csv');
    nizJSon = sadrzajDatoteka.toString('utf8').split('\n');
    for(var el in nizJSon) {
        var rijec = nizJSon[el].split(',');
        if (rijec[0] == podaci['nazivGod']) {
            uslov = true;
        }
    }

    //Upis u CSV datoteku ukoliko nema godina sa istim imenom
    if (uslov == false) {
        let datotekaUpis = [
            {godina: podaci['nazivGod'], vjezbe: podaci['nazivRepVje'], spirala : podaci['nazivRepSpi']}
        ];
        csvWriter.writeRecords(datotekaUpis)
        .then(() => {
            res.sendFile (__dirname + '/Public/addGodina.html');
        });
    }
    else {
        res.render("greska", {
            greskaIspis: function() {
                return "Vec postoji godina sa istim nazivom. Vratite se nazad i pokusajte ponovo!";
            }
        });
    }
});
app.get('/addGodina', function(req, res) {
    res.sendFile (__dirname + '/Public/addGodina.html');
})
//5. ZADATAK
app.get('/godine', function(req, res) {
    var niz = [];
    var citanje = fs.createReadStream('godine.csv', 'utf8');
    citanje 
        .pipe(csv({parseNumbers: true, parseBooleans: true, trim: true}))
        .on ('data', function(red) {
            if (red[0] != "NazivVjezbe") {
                var jsonObjekat = {nazivGod : red[0], nazivRepVje : red[1], nazivRepSpi : red[2]};
                niz.push(jsonObjekat);
            }
        })
        .on ('end', function(data) {
            res.setHeader("Content-Type", "application/json");
            res.send(JSON.stringify(niz)); 
            res.end();
        })
});
/*6. ZADATAK 
Urađen GodineAjax.js */

//7. ZADATAK
app.get ('/zadaci', (req, res) => {
    var fajlovi = [];
    var xmlFajlovi = [];
    var header = req.headers.accept;
   
    var sviHeaderi = header.split(", ");
    
    var json = false;
    var xml = false;
    var csv = false;
    var j;

    //Provjera koje ACCEPT header-e smo poslali
    for (j = 0; j<sviHeaderi.length; j++) {
        if (sviHeaderi[j] == "application/json" || sviHeaderi[j] == "*/*") json = true;
        if (sviHeaderi[j] == "application/xml" || sviHeaderi[j] == "text/xml") xml = true;
        if (sviHeaderi[j] == "text/csv") csv = true;
    }
    if (json == false && xml == false && csv == false) json = true;

    //Čitanje svih fajlova iz odgovarajućeg foldera
    const folder = './uploads';
    fs.readdirSync(folder).forEach(file => {
        var tip = file.substr(file.length-3, 3);
        if (tip == "pdf") fajlovi.push(file);
    })

    //Kreiranje potrebnih fajlova za odgovor
    var jsonArray = [];
    var stringCSV = "";
    var xw = new XMLWriter(true);
    xw.startDocument(version = '1.0',encoding = "UTF-8");
    xw.startElement('zadaci');
    for(var i in fajlovi) {
        var ime = fajlovi[i].substr(0, fajlovi[i].length-4);
        //JSON response
        if (json) {
            var jsonRes = {naziv : ime, postavka : "http://localhost:8080/" + fajlovi[i]};
            jsonArray.push(jsonRes);
        }
        //XML response
        if (xml) {
            xw.startElement('zadatak').writeElement('naziv', ime).writeElement('postavka', "http://localhost:8080/" + fajlovi[i]).endElement();
            xmlFajlovi.push(xw);
        }
        //CSV response
        if (csv) {
            stringCSV += ime + ",http://localhost:8080/" + fajlovi[i] + "\n";   
        }
    }

    if(json) {
        res.setHeader("Content-Type", "application/json");
        res.send(JSON.stringify(jsonArray));
    }

    else if(xml && !json) {
        res.setHeader("Content-Type", "application/xml");
        if (xmlFajlovi.length != 0) res.send(xmlFajlovi[0].toString());
        else {
            res.send('<?xml version="1.0" encoding="UTF-8"?><zadaci></zadaci>');
        }
    }
    else {
        res.setHeader("Content-Type","text/csv");
        res.send(stringCSV);
    }
    res.end();
});
app.listen(8080);
