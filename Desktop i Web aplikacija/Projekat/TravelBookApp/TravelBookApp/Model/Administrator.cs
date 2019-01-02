using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
    public class Administrator : Uposlenik
    {
        private String sifra;

        public Administrator(String ime, String prezime, String jmbg, DateTime datumRodjenja, Double plata):base(ime, prezime, jmbg, datumRodjenja, plata) {
            Sifra = "travel123";
        }

        public string Sifra { get => sifra; set => sifra = value; }

        public override string IspisiString()
        {
            return string.Format("Ime: {0}" + Environment.NewLine +
                                 "Prezime: {1}" + Environment.NewLine +
                                 "Maticni broj: {2}" + Environment.NewLine +
                                 "Datum rođenja: {3}", ImeUposlenika, PrezimeUposlenika, JmbgUposlenika, DatumRodjenjaUposlenika);
        }
    }
}
