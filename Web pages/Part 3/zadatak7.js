const express = require('express');
const bodyParser = require('body-parser');
var app = express();
var fs = require('fs');
var XMLWriter = require('xml-writer');
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

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

    //Čitanje svih fajlova iz odgovarajućeg foldera
    const folder = './uploads';
    fs.readdirSync(folder).forEach(file => {
        fajlovi.push(file);
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
            var jsonRes = {naziv : ime, postavka : "/" + fajlovi[i]};
            jsonArray.push(jsonRes);
        }
        //XML response
        if (xml) {
            xw.startElement('zadatak').writeElement('naziv', ime).writeElement('postavka', "/" + fajlovi[i]).endElement();
            xmlFajlovi.push(xw);
        }
        //CSV response
        if (csv) {
            stringCSV += ime + ",/" + fajlovi[i] + "\n";   
        }
    }

    if(json) {
        res.setHeader("Content-Type", "application/json");
        res.send(JSON.stringify(jsonArray));
    }

    else if(xml && !json) {
        res.setHeader("Content-Type", "text/xml");
        res.send(xmlFajlovi[0].toString());
    }
    else {
        res.setHeader("Content-Type","text/csv");
        res.send(stringCSV);
    }
    res.end();
});
app.listen(8080);
 
 
