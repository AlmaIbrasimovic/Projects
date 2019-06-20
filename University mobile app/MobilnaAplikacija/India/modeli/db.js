const Sequelize = require('sequelize');
const path = require('path')
const sequelize = new Sequelize(
    "TYQcLL35gV",   // database
    "TYQcLL35gV",   // username
    "BLysSj9ZrP",   // password
    {
        host:"37.59.55.185",
        dialect:"mysql",
        define: {
            timestamps: false
        }
    }
    );

const db={};
db.Sequelize = Sequelize;
db.sequelize = sequelize;

//import modela
db.StudentIspit = sequelize.import(path.join(__dirname, 'StudentIspit.js'));
db.Ispit = sequelize.import(path.join(__dirname, 'Ispit.js'));
db.Predmet = sequelize.import(path.join(__dirname, 'Predmet.js'));
db.Korisnik = sequelize.import(path.join(__dirname, 'Korisnik.js'));
db.Uloga = sequelize.import(path.join(__dirname, 'Uloga.js'));
db.Odsjek = sequelize.import(path.join(__dirname, 'Odsjek.js'));
db.AkademskaGodina = sequelize.import(path.join(__dirname, 'AkademskaGodina.js'));
db.predmet_student = sequelize.import(path.join(__dirname, 'PredmetStudent.js'));

module.exports = db;