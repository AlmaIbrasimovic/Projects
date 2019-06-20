/* jshint indent: 2 */

module.exports = function(sequelize, DataTypes) {
    return sequelize.define('predmet_student', {
      id: {
        type: DataTypes.INTEGER(10),
        allowNull: false,
        primaryKey: true
      },
      idStudent: {
        type: DataTypes.INTEGER(10),
        allowNull: false,
        references: {
          model: 'Korisnik',
          key: 'id'
        }
      },
      idPredmet: {
        type: DataTypes.INTEGER(10),
        allowNull: false,
        references: {
          model: 'Predmet',
          key: 'id'
        }
      },
      idAkademskaGodina: {
        type: DataTypes.INTEGER(11),
        allowNull: false,
        references: {
          model: 'AkademskaGodina',
          key: 'id'
        }
      },
      ocjena: {
        type: DataTypes.INTEGER(2),
        allowNull: true
      },
      datum_upisa: {
        type: DataTypes.DATEONLY,
        allowNull: true
      }
    }, {
      tableName: 'predmet_student'
    });
  };