const express = require('express');
const bodyParser = require('body-parser');
var app = express();
var fs = require('fs');
app.use (express.static(__dirname + "/Public"));
app.set('views', (__dirname+'/views'));
app.set('view engine', 'pug');
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
var multer  = require('multer')

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
        res.render("index", {
            greskaIspis: function() {
                if (req.fileValidationError == "Zabranjena ekstenzija") return "Tip datoteke mora biti .pdf. Vratite se nazad i pokusajte ponovo!";
                return "Vec postoji datoteka sa istim imenom. Vratite se nazad i pokusajte ponovo!";
            }
        });
    }
   else {
        var jsonObjekat = {naziv : req.body.naziv, postavka :"http://localhost:8080/" + req.body.naziv + ".pdf"};
        var json = JSON.stringify(jsonObjekat);
        fs.writeFileSync(req.body.naziv + "zad.json",json,  function (err) {
            if (err) throw err;
        });
        res.write(json);
        res.end();
   }
});

app.listen(8080);

