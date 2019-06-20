module.exports = function(sequelize, DataTypes) {
    return sequelize.define('Ispit', {
      idIspit: {
        type: DataTypes.INTEGER(10),
        allowNull: false,
        primaryKey: true
      },
      idProfesor: {
        type: DataTypes.INTEGER(10),
        allowNull: false,
        references: {
          model: 'Korisnik',
          key: 'id'
        }
      },
      idPredmet: {
        type: DataTypes.INTEGER(11),
        allowNull: false,
        references: {
          model: 'Predmet',
          key: 'id'
        }
      },
      brojStudenata: {
        type: DataTypes.INTEGER(10),
        allowNull: true
      },
      tipIspita: {
        type: DataTypes.STRING(45),
        allowNull: true
      },
      rokPrijave: {
        type: DataTypes.DATE,
        allowNull: true
      },
      sala: {
        type: DataTypes.STRING(45),
        allowNull: true
      },
      termin: {
        type: DataTypes.DATE,
        allowNull: true
      },
      vrijemeTrajanja: {
        type: DataTypes.INTEGER(10),
        allowNull: true
      },
      kapacitet: {
        type: DataTypes.INTEGER(10),
        allowNull: true
      },
      napomena: {
        type: DataTypes.STRING(255),
        allowNull: true
      }
    }, {
      tableName: 'Ispit'
    });
  };