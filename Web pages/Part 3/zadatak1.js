const express = require('express');
const bodyParser = require('body-parser');
var app = express();
app.use (express.static("Public"));
app.use(bodyParser.json());

app.use(bodyParser.urlencoded({ extended: true }));
app.get(/.*html$/, function(req, res) {
    let stranica = req.url.substr(1, req.url.length);
    res.sendFile (__dirname + '/Public/' + stranica); 
});
app.listen(8080);
