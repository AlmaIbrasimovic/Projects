const Sequelize = require("sequelize");
const sequelize = new Sequelize("wt2018","root","root",{
    host:"localhost",
    dialect:"mysql",
});
const db={};

db.Sequelize = Sequelize;  
db.sequelize = sequelize;

//Import modela u bazu podataka
db.student = sequelize.import(__dirname+'/student.js');
db.godina = sequelize.import(__dirname+'/godina.js');
db.zadatak = sequelize.import(__dirname+'/zadatak.js');
db.vjezba = sequelize.import(__dirname+'/vjezba.js');

//Veze između modela

// Veza 1-n više studenata na jednoj godini
db.godina.hasMany(db.student,{foreignKey:'studentGod',as:'studenti'});

//Veza n-m godina i vježbe
db.vjezbeNaGodini = db.vjezba.belongsToMany(db.godina, {as: 'godine', through:'godina_vjezba', foreignKey:'idvjezba'});
db.vjezbeNaGodini1 =db.godina.belongsToMany(db.vjezba, {as:'vjezbe', through:'godina_vjezba', foreignKey:'idgodina'});

//Veza više na više ----vježba i zadaci
db.zadaciNaGodini = db.zadatak.belongsToMany(db.vjezba, {as: 'vjezbe', through:'vjezba_zadatak', foreignKey:'idzadatak'});
db.zadaciNaGodini1 = db.vjezba.belongsToMany(db.zadatak, {as:'zadaci', through:'vjezba_zadatak', foreignKey:'idvjezba'});
module.exports=db;