/* jshint indent: 2 */

module.exports = function(sequelize, DataTypes) {
    return sequelize.define('Predmet', {
      id: {
        type: DataTypes.INTEGER(10),
        allowNull: false,
        primaryKey: true
      },
      idAsistent: {
        type: DataTypes.INTEGER(10),
        allowNull: true,
        references: {
          model: 'Korisnik',
          key: 'id'
        }
      },
      idProfesor: {
        type: DataTypes.INTEGER(10),
        allowNull: true,
        references: {
          model: 'Korisnik',
          key: 'id'
        }
      },
      naziv: {
        type: DataTypes.STRING(255),
        allowNull: false
      },
      ects: {
        type: DataTypes.INTEGER(10),
        allowNull: false
      },
      brojPredavanja: {
        type: DataTypes.INTEGER(10),
        allowNull: false
      },
      brojVjezbi: {
        type: DataTypes.INTEGER(10),
        allowNull: false
      },
      opis: {
        type: DataTypes.STRING(1024),
        allowNull: false
      }
    }, {
      tableName: 'Predmet'
    });
  };