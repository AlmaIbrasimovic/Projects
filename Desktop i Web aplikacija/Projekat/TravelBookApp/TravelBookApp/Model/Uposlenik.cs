using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
    public abstract class Uposlenik  : IPrint
    {
        private String imeUposlenika;
        private String prezimeUposlenika;
        private String jmbgUposlenika;
        private DateTime datumRodjenjaUposlenika;
        private Double plataUposlenika;
        public Uposlenik(String ime, String prezime, String jmbg, DateTime datumRodjenja, Double plata)
        {
            ImeUposlenika = ime;
            PrezimeUposlenika = prezime;
            JmbgUposlenika = jmbg;
            DatumRodjenjaUposlenika = datumRodjenja;
            PlataUposlenika = plata;
        }
        public string ImeUposlenika { get => imeUposlenika; set => imeUposlenika = value; }
        public string PrezimeUposlenika { get => prezimeUposlenika; set => prezimeUposlenika = value; }
        public string JmbgUposlenika { get => jmbgUposlenika; set => jmbgUposlenika = value; }
        public DateTime DatumRodjenjaUposlenika { get => datumRodjenjaUposlenika; set => datumRodjenjaUposlenika = value; }
        public double PlataUposlenika { get => plataUposlenika; set => plataUposlenika = value; }

        public virtual string IspisiString()
        {
            return string.Format("Ime: {0}" + Environment.NewLine +
                                 "Prezime: {1}" + Environment.NewLine +
                                 "Maticni broj: {2}" + Environment.NewLine +
                                 "Datum rođenja: {3}", ImeUposlenika, PrezimeUposlenika, JmbgUposlenika, DatumRodjenjaUposlenika);
        }
    }
}
