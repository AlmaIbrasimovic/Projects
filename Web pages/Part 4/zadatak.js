const Sequelize = require("sequelize");
module.exports = function(sequelize,DataTypes){
    const zadatak = sequelize.define("zadatak",{
        id:{
            type:Sequelize.INTEGER, 
            autoIncrement:true,
            primaryKey: true
        },
        naziv:{
            type:Sequelize.STRING,
            field:'naziv'
            
        },
        postavka:{
            type:Sequelize.STRING,
            field:'postavka'
        }
    })
    return zadatak;
};
