const Sequelize = require("sequelize");
module.exports = function(sequelize,DataTypes){
    const vjezba = sequelize.define("vjezba",{
        id:{
            type:Sequelize.INTEGER,
            autoIncrement:true,
            primaryKey: true
        },
        naziv:{
            type: Sequelize.STRING,
            unique:true,
            field:'naziv'
        },
        spirala:{
            type:Sequelize.BOOLEAN,
            field:'spirala'
        }
    })
    return vjezba;
};
