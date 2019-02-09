var express = require ("express");
var app = express();
app.use (express.static("Public"));
app.listen(8080);