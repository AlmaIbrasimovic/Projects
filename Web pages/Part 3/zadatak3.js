const express = require('express');
const bodyParser = require('body-parser');
var app = express();
var fs = require('fs');
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.get ('/zadatak', (req, res) => {
    var url = require('url');
    let parametri = new url.URLSearchParams(req.url);
    let imeFajla = parametri.get("/zadatak?naziv");
    let imalPDF = imeFajla.substr(imeFajla.length-4, 4);
    if (imalPDF == ".pdf") var fajl = fs.readFileSync("uploads/" + imeFajla);
    else fajl = fs.readFileSync("uploads/" + imeFajla + ".pdf");
    res.contentType("application/pdf");
    res.send(fajl);
});
app.listen(8080);
