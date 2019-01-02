using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp
{
    public static class Globalna
    {
        public static TravelBook nasaAgencija = new TravelBook();
        public static int prijavljenaAgencijaId = 0;
        public static bool trenutnaPutovanja = true;
        public static int idSvihAgencija = 0;
        public static int idSvihDestinacija = 0;
        public static int idSvihPutovanja = 0;
        public static int idSvihKartica = 0;
        public static int idSvihHotela = 0;
        public static int idSvihPrevoza = 0;
        public static int idSvihKorisnika = 0;
    }
}
