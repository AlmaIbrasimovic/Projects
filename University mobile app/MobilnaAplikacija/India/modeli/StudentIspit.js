const Sequelize = require('sequelize')

module.exports = (sequelize, DataTypes) => {
    const StudentIspit = sequelize.define('StudentIspit', {
        /*id: {
            type: Sequelize.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },*/
        studentId: Sequelize.INTEGER, 
        ispitId: Sequelize.INTEGER
    })

    return StudentIspit;
}