const express = require('express');
const bodyParser = require('body-parser');
const moment = require('moment');
const db = require('./modeli/db.js');
const sequelize = require('sequelize');
var app = express();
const port=31909;
const StudentIspit = db.sequelize.import(__dirname+'/modeli/StudentIspit.js');
const Ispit = db.sequelize.import(__dirname+'/modeli/Ispit.js');
const Predmet = db.sequelize.import(__dirname+'/modeli/Predmet.js');
const Korisnik = db.sequelize.import(__dirname+'/modeli/Korisnik.js');
const Uloga = db.sequelize.import(__dirname+'/modeli/Uloga.js');
const Odsjek = db.sequelize.import(__dirname+'/modeli/Odsjek.js');
const AkademskaGodina = db.sequelize.import(__dirname+'/modeli/AkademskaGodina.js');
const PredmetStudent = db.sequelize.import(__dirname+'/modeli/PredmetStudent.js');

db.sequelize.sync()
.then(() => console.log('Konektovano na bazu'))
.catch(e => console.log(e));

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}))
//app.use(cors());

var dajIspitStudent = function(id) {
    return new Promise(function(resolve, reject)  {
        db.StudentIspit.findAll({where: {StudentId: id}}).then(function(ispiti){
            resolve(ispiti);
        }).catch(e => reject(e));
    });
}

var dajIspitPoId = function(idIspit) {
    return new Promise(function(resolve, reject) {
        db.Ispit.findOne({where: {idIspit: idIspit}}).then(function(ispit) {
            resolve(ispit);
        }).catch(e => reject(e));
    })
}

var dajNazivPredmeta = function(idPredmeta) {
    return new Promise(function(resolve, reject) {
        db.Predmet.findOne({where: {id: idPredmeta}}).then(function(predmet2) {
            resolve(predmet2);
        }).catch(e => reject(e));  
    });
}

//kupljenje svih prijavljenih ispita studenta 
app.get('/student/:id/prijavljeni',  function(req, res) {
    var id = req.params.id;
    var niz = [];
    res.contentType('application/json');
    let greska = { 'poruka': 'Nije pronađen ni na jedan ispit'};
    dajIspitStudent(id).then(function(rez) {
        if(rez.length == 0) res.send(greska);
        else {
            let brojac = rez.length;
            rez.forEach(red => {
                dajIspitPoId(red.ispitId).then(function(ispit) {
                    dajNazivPredmeta(ispit.idPredmet).then(function(vracenoImePredmeta) {
                        brojac--;
                        niz.push({ predmet: vracenoImePredmeta.naziv, tip: ispit.tipIspita, rokPrijave: ispit.rokPrijave, datumIspita: ispit.termin, napomena: ispit.napomena, prijavljen: 1, popunjen: ispit.kapacitet});

                        if(brojac == 0)
                            res.send(niz);
                    });  
                });
            });
        }   
    });
});

var dajPredmetStudent = function(id) {
    return new Promise(function(resolve, reject)  {
        db.predmet_student.findAll({where: {idStudent: id}}).then(function(predmeti) {
            resolve(predmeti);
        }).catch(e => reject(e));
    });
}

var dajIspitePredmet = function(idPredmeta) {
    return new Promise(function(resolve, reject) {
        db.Ispit.findAll({where: {idPredmet: idPredmeta}}).then(function(ispiti){
            resolve(ispiti);
        }).catch(e => reject(e));
    });
}

var vratiIspis = function(ispitiOdgovor, datetime) {
    var niz = [];
    return new Promise(function(resolve, reject) {
        let ispitiOdgovorFilter = ispitiOdgovor.filter(ispit => ispit.rokPrijave != null && new Date(ispit.rokPrijave) > new Date(datetime));
        if(ispitiOdgovorFilter.length == 0) resolve(niz);
        else { 
            let brojac = ispitiOdgovorFilter.length; 
            ispitiOdgovorFilter.forEach(objekt => {
                dajNazivPredmeta(objekt.idPredmet).then(function(vracenoImePredmeta) {
                    niz.push({ predmet: vracenoImePredmeta.naziv, tip: objekt.tipIspita, rokPrijave: objekt.rokPrijave, datumIspita: objekt.termin, napomena: objekt.napomena, prijavljen: 0, popunjen: objekt.kapacitet});
                    brojac--;
                    if (brojac == 0) {
                        resolve(niz);
                    }
                }).catch(e => reject(e));  
            });
        }
    });
}

//kupljenje svih aktivnih ispita
app.get('/student/:id/aktivni', function(req, res) {
    var id = req.params.id;
    var datetime = moment().format();
    datetime = datetime.slice(0,19) + 'Z';
    
    var niz = [];
    res.contentType('application/json');
    let greska = { 'poruka': 'Nije pronađen ni na jedan ispit'};
    dajPredmetStudent(id).then(function(odgovor) {
        
        if (odgovor.length == 0) res.send(greska);
        else {
            let brojac = odgovor.length;
            odgovor.forEach(elementOdgovora => {
                dajIspitePredmet(elementOdgovora.idPredmet).then(function(ispitiOdgovor) {
                    vratiIspis(ispitiOdgovor, datetime).then(function(izlazniNiz) {
                        
                        if (izlazniNiz.length == 0) { res.send(niz); }
                        else {
                            izlazniNiz.forEach(objektNiza => {
                                brojac--;
                                niz.push(objektNiza);
                            })
                            
                            if (brojac <= 0 || izlazniNiz.length == 0) { res.send(niz); }
                        }
                    })
                });
            });
        
        }
    });
 
});
//POTVRDE NA KOJE CEKA STUDENT
app.get('/izdanepotvrde/:id', function(req, res)
{
    var id1 = req.params.id;
    var podaci2 = [];

        ZahtjevZaPotvrdu.findAll({where: {idStudenta:id1}}).then(function(potvrde){
            potvrde.forEach(potvrda => {
                SvrhaPotvrde.findOne({where: {id: potvrda.idSvrhe}}).then(function(svrhica){
                podaci2.push(svrhica.nazivSvrhe);
                podaci2.push(potvrda.datumZahtjeva);
                podaci2.push(potvrda.obradjen);
            });
        });
    });

        res.send(podaci2);

    });

// DANASNJE ZADACE ZA RASPORED
app.get('/danasnjezadace/:id/:dan', function(req, res) {
//dodati studentid u zadace i pretrazivati po njemu!!
    var zadacice = [];
    var today = dan;

  Zadaca.findAll({where: {rokZaPredaju: today}}).then(function(zadace){
    zadace.forEach(zadaca => {
        zadacice.push(zadaca.naziv);
        Predmet.findOne({where: {id: zadaca.idPredmet}}).then(function(predmet){
        zadacice.push(predmet.naziv);
    });
});
});

    res.send(zadacice);

});
//PRI OBRADI ZAHTJEVA
app.get('/obradjenZahtjev/:id', function(req, res) {

    var id1 = req.params.id;


    ZahtjevZaPotvrdu.Update({obradjen: 1}, {where: {id:id1}}).then(function(zahtjevcic){
    
        Student.findOne({where: {id:zahtjevcic.idStudenta}}).then(function(studentic){
            var broj = studentic.brojbesplatnih-1;
        Student.Update({brojbesplatnih: broj}, {where: {id:zahtjevcic.idStudenta}});
        
        SvrhaPotvrde.findOne({where: {id: zahtjevcic.idSvrhe}}).then(function(svrhica){
        alert("Uspješno je obrađen zahtjev" + svrhica.naziv);
            });
        });
    });
});

//DANASNJI ISPITI

app.get('/danasnjiispiti/:id/:dan', function(req, res) {

        var ispiti = [];
        var today = dan;
        var student = req.params.id;
    
      Ispiti.findAll({where: {datumIspita: today}}).then(function(ispit){
      idpred = ispit.idPredmeta;
       if(PredmetStudent.findOne({
           where: {
        idStudent: {student},
        idPredmet: {idpred}
            }
        }))
         {
        ispiti.push(ispit);
        }
        
    });
    
        res.send(ispiti);
    
    });
//UPDATE TERMINA ISPITA
app.get('/termin/:id/:dan', function(req, res) {

    var novi = dan;
    var ispit = req.params.id;

  Ispiti.Update({datumIspita: novi}, {where: {id: ispit}}).then(function(ispit){
    Predmet.findOne({where: {id: ispit.idPredmet}}).then(function(predmet){
      alert("Novi termin ispita " + predmet.naziv + " je " + novi)
    });
});

});

//NOVA ZADACA
//dodati tabelu studentzadaca!!

app.get('/novazadaca/:id/:zad', function(req, res) {

    var student = id;
    var zadaca = zad;

    studentzadaca.create({    
        idstudenta: student,
        idzadace: zadaca
})
});

//URADJENE ZADACE
app.get('/jeliuradjena/:id/:zad', function(req, res) {

    var student = id;
    var zadaca = zad;

if (studentzadaca.findOne({
    where: {
        idstudenta: {student},
        idzadace: {zadaca}
    }
    })) {
        res.send("Poslano!");
    }
else {
    res.send("Nije poslano!");
}

});


app.listen(port, () => console.log(`Server pokrenut na portu ${port}!`))