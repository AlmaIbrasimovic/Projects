const express = require('express');
const bodyParser = require('body-parser');
var app = express();
var fs = require('fs');
app.use (express.static("Public"));
const csv = require('csv-writer').createObjectCsvWriter;
app.set('views', (__dirname+'/views'));
app.set('view engine', 'pug');
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

app.post('/addGodina', function(req, res) {
    let podaci = req.body;
    let uslov = false; 

    //Kreiranje CSV-writer
    const csvWriter = csv({
        path: 'godine.csv',
        header: [
            {id: 'godina', title: 'Naziv godine'},
            {id: 'vjezbe', title: 'Naziv repozitorija vjezbe'},
            {id: 'spirala', title: 'Naziv repozitorija spiralae'}
        ],
        encoding: 'utf-8',
        append: true
    });

 
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
        res.render("index", {
            greskaIspis: function() {
                return "Vec postoji godina sa istim nazivom. Vratite se nazad i pokusajte ponovo!";
            }
        });
    }
});
app.listen(8080);
