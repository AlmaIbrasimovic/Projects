const express = require('express');
const bodyParser = require('body-parser');
var app = express();
var fs = require('fs');
var csv = require ('csv-reader');
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

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
app.listen(8080);
