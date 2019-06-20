module.exports = function(sequelize, DataTypes) {
    return sequelize.define('Korisnik', {
      id: {
        type: DataTypes.INTEGER(10),
        allowNull: false,
        primaryKey: true
      },
      idOdsjek: {
        type: DataTypes.INTEGER(10),
        allowNull: true,
        references: {
          model: 'Odsjek',
          key: 'idodsjek'
        }
      },
      idUloga: {
        type: DataTypes.INTEGER(10),
        allowNull: true,
        references: {
          model: 'Uloga',
          key: 'iduloga'
        }
      },
      ime: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      prezime: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      datumRodjenja: {
        type: DataTypes.DATEONLY,
        allowNull: true
      },
      JMBG: {
        type: DataTypes.STRING(13),
        allowNull: true
      },
      email: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      mjestoRodjenja: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      kanton: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      drzavljanstvo: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      telefon: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      spol: {
        type: DataTypes.BOOLEAN,
        allowNull: true
      },
      imePrezimeMajke: {
        type: DataTypes.STRING(100),
        allowNull: true
      },
      imePrezimeOca: {
        type: DataTypes.STRING(100),
        allowNull: true
      },
      adresa: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      username: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      password: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      linkedin: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      website: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      fotografija: {
        type: "BLOB",
        allowNull: true
      },
      indeks: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      ciklus: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      semestar: {
        type: DataTypes.STRING(50),
        allowNull: true
      },
      titula: {
        type: DataTypes.STRING(50),
        allowNull: true
      }
    }, {
      tableName: 'Korisnik'
    });
  };