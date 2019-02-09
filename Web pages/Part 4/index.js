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
var objekat = "";
const db = require('./db.js');
db.sequelize.sync();
//uploads je folder gdje se spremaju svi .pdf i json fajlovi koji se uploaduju preko forme


app.get('/addVjezba', function(req, res) {
    db.godina.findAll().then(godine=> {
        res.send(godine);
    })
})
app.get('/addVjezbaCitanjeVjezbi', function(req,res){
    db.vjezba.findAll().then(vjezbe => {
        res.send(vjezbe);
    })
})
app.get('/dajMedjuTabelu', function(req, res){
    let podaci = req.query;
    var niz = [];
    db.vjezba.count().then(broj => {
        if(broj != 0) {
            db.vjezba.findOne({where:{id:podaci['id']}}).then(function(vjezbaT){
                vjezbaT.getZadaci().then(function(resSet){      
                    resSet.forEach(zadatak => {
                        niz.push(zadatak.id);   
                    });
                    res.send(niz);
                });
            });
        }
    })
})
app.get('/studentiBaza', function(req, res) {
    db.student.findAll().then(studen => {
        res.send(studen);
    })
})

app.get('/dajZadatke', function(req, res) {
    db.zadatak.findAll().then(zadaci=>{
        res.send(zadaci);
    })
})
//1. ZADATAK SA SPIRALE 4

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
        var url = require('url');
        var uslov;
        var ime = req.body;
        let parametri = new url.URLSearchParams(req.url);
        let imeFajla = parametri.get("/zadatak?naziv");
        db.zadatak.findOne({ 
            where: {naziv: ime['naziv']}}).then(fajl => {
                if (fajl == null) {
                    uslov = false;
                   
                }
                else if (fajl != null) {
                    uslov = true;
                    req.fileValidationError = "Postoji fajl sa istim imenom";
                    return cb(null, false, req.fileValidationError);
                }
                if(ext != 'application/pdf') {
                    req.fileValidationError = "Zabranjena ekstenzija";
                    return cb(null, false, req.fileValidationError);
                } 
               cb(null, true);
            })    
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
        db.zadatak.create({naziv:req.body.naziv, postavka: "http://localhost:8080/" + req.body.naziv + ".pdf"});
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
    db.zadatak.findOne({ 
        where: {naziv: imeFajla}}).then(fajl => {
            if (fajl == null) {
                res.render("greska", {
                    greskaIspis: function() {
                        return "Traženi fajl ne postoji (ili ste dodali .pdf, a ne treba). Promijenite ime fajla u URL!";
                    }
                });
            }
            else {
                var dokument = fs.readFileSync("uploads/" + fajl.naziv + ".pdf");
                res.contentType("application/pdf");
                res.send(dokument);
            }
      })    
});

//4. ZADATAK
app.post('/addGodina', function(req, res) {
    let podaci = req.body;
    let kreiran = true;
    var godineArray = [];
    db.godina.findOrCreate({
        where: {nazivGod: podaci['nazivGod']}, 
        defaults: { nazivRepSpi:podaci['nazivRepSpi'], nazivRepVje:podaci['nazivRepVje']}}
        )
        .spread((user, created) => {
            kreiran = created;
            if (kreiran) res.sendFile (__dirname + '/Public/addGodina.html');
            else if (kreiran == false) {
                res.render("greska", {
                    greskaIspis: function() {
                        return "Vec postoji godina sa istim nazivom. Vratite se nazad i pokusajte ponovo!";
                    }
                });
            }
        });
});
app.get('/addGodina', function(req, res) {
    res.sendFile (__dirname + '/Public/addGodina.html');
})

//5. ZADATAK
app.get('/godine', function(req, res) {
    var niz = [];
    db.godina.findAll().then (sveGodine =>{
        for (var i = 0; i<sveGodine.length; i++) {
            var jsonObjekat = {nazivGod : sveGodine[i].nazivGod, nazivRepVje : sveGodine[i].nazivRepVje, nazivRepSpi : sveGodine[i].nazivRepSpi};
            niz.push(jsonObjekat);
        }
        res.setHeader("Content-Type", "application/json");
        res.send(JSON.stringify(niz));
        res.end;
    })
});

//ZADATAK 2
app.post('/addVjezba', (req, res) => {
    let podaci = req.body;
    //2a zadatak
    if (podaci['naziv'] == undefined) {
        db.godina.findOne({where:{nazivGod:podaci['sGodine']}}).then (god => {
            db.vjezba.findOne({where:{naziv:podaci['sVjezbe']}}).then(function(vj){
                god.addVjezbe([vj]).then(function() {
                    res.sendFile (__dirname + '/Public/addVjezba.html');
                });
            });
        })
    }
    //2b zadatak
    else {
        var spiralaDailiNe = false;
        if (podaci['spirala'] == 'on') spiralaDailiNe = true;
        db.vjezba.create({naziv:podaci['naziv'], spirala:spiralaDailiNe });
        db.godina.findOne({where:{nazivGod:podaci['sGodine']}}).then(k =>{
           db.vjezba.findOne({where:{naziv:podaci['naziv']}}).then(function(vf) {
               k.addVjezbe([vf]);
               res.sendFile (__dirname + '/Public/addVjezba.html');
           })
        })
    }
})

//2c zadatak
app.post ('/vjezba/:idVjezbe/zadatak', function(req, res) {
    let podaci = req.url;
    let temp = req.body
    var a = podaci.split(':')[1];
    var b =a.split('/')[0];
    db.vjezba.findOne({where:{id:b}}).then(k =>{
        db.zadatak.findOne({where: {naziv:temp['sZadatak']}}).then(function(v) {
            k.addZadaci([v]);
            res.redirect('/addVjezba.html');
        })
    });
})

//3a zadatak 
app.post('/student', async function (req, res) {
  
  //POMOĆNE SKRIPTE BitBucket.js i postAJAX.js (za slanje POST zahtjeva)
  var imeGodine = req.body['godina'];
  var {studenti} = req.body;
  var stari = 0;
  var novi = 0;
  let god = await db.godina.findOne({where: {nazivGod: req.body.godina}});
    for (var i = 0; i < studenti.length; i++) {
        var ime = studenti[i].imePrezime;
        var ind = studenti[i].index;
        let stud = await db.student.findOne({where: {index: studenti[i].index}});
        if (stud === null) {
            novi++;
            let noviStudent = await  db.student.create({imePrezime: ime, index: ind});
            god.addStudenti(noviStudent);
        } 
        else if (stud !== null) {
            stari++; 
            god.addStudenti(stud);
        }
    }
    res.set("Content-Type", "application/json");
    return res.status(200).send({
        message: "Dodano je " + novi + " novih studenata i upisano " + stari + " na godinu " + imeGodine
    });
});
/*6. ZADATAK 
Urađen GodineAjax.js */

//7. ZADATAK
app.get ('/zadaci', (req, res) => {
    var fajlovi = [];
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

    var xw = new XMLWriter(true);
    var stringCSV ="";

    //Čitanje svih fajlova iz baze
    db.zadatak.findAll().then(zadaci => {
        //JSON response
        if (json) {
            for (var i = 0; i<zadaci.length; i++) {
                objekat = {naziv : zadaci[i].naziv, postavka : zadaci[i].postavka};
                fajlovi.push(objekat);              
            }
            res.setHeader("Content-Type", "application/json");
            res.send(JSON.stringify(fajlovi));
            res.end();
        }
        //XML response
        else if (xml && !json) {
            for (var i = 0; i<zadaci.length; i++) {
                xw.startElement('zadatak').writeElement('naziv', zadaci[i].naziv).writeElement('postavka', zadaci[i].postavka).endElement();
                fajlovi.push(xw);              
            }
            res.setHeader("Content-Type", "application/xml");
            if (fajlovi.length != 0) res.send(fajlovi[0].toString());
            else {
                res.send('<?xml version="1.0" encoding="UTF-8"?><zadaci></zadaci>');
            }
            res.end();
        }
        //CSV response
        else {
            for (var i = 0; i<zadaci.length; i++) {
                stringCSV += zadaci[i].naziv + ","+ zadaci[i].postavka + "\n";              
            }
            res.setHeader("Content-Type","text/csv");
            res.send(stringCSV);
            res.end();
        }
    })
});
app.listen(8080);
