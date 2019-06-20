/* jshint indent: 2 */

module.exports = function(sequelize, DataTypes) {
    return sequelize.define('Uloga', {
      idUloga: {
        type: DataTypes.INTEGER(10),
        allowNull: false,
        primaryKey: true
      },
      naziv: {
        type: DataTypes.STRING(25),
        allowNull: true
      }
    }, {
      tableName: 'Uloga'
    });
  };