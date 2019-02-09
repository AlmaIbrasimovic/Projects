const Sequelize = require("sequelize");
module.exports = function(sequelize,DataTypes){
    const student = sequelize.define("student",{
         id:{
           type:Sequelize.INTEGER, 
           autoIncrement:true,
           primaryKey: true
        },
        imePrezime:{
            type:Sequelize.STRING,
            field:'imePrezime'
        },
        index:{
            type:Sequelize.STRING,
            unique:true,
            field:'index'
        }
    })
    return student;
};
