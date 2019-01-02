using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
    public class Putovanje
    {

        private int id;
        private DateTime datumPolaska;
        private DateTime datumPovratka;
        private int minimalniBrojPutnika;
        private int maximalniBrojPutnika;
        private String opisPutovanja;
        private Boolean istaknutoPutovanje;
        private int idAgencije;
        private Destinacija infoDestinacije;
        private Hotel infoHotela;
        private Prevoz infoPrevoza;
        private Double cijena;
        private int trenutniBrojPutnika = 0;

        public Putovanje(DateTime datumPolaska, DateTime datumPovratka, int minimalniBrojPutnika, int maximalniBrojPutnika, string opisPutovanja, bool istaknutoPutovanje, int idAgencije, Destinacija infoDestinacije, Hotel infoHotela, Prevoz infoPrevoza, Double cijenaPut)
        {
            id = Globalna.idSvihPutovanja++;
            DatumPolaska = datumPolaska;
            DatumPovratka = datumPovratka;
            MinimalniBrojPutnika = minimalniBrojPutnika;
            MaximalniBrojPutnika = maximalniBrojPutnika;
            OpisPutovanja = opisPutovanja;
            IstaknutoPutovanje = istaknutoPutovanje;
            IdAgencije = idAgencije;
            InfoDestinacije = infoDestinacije;
            InfoHotela = infoHotela;
            InfoPrevoza = infoPrevoza;
            Cijena = cijenaPut;
        }
        public int Id { get => id; }
        public DateTime DatumPolaska { get => datumPolaska; set => datumPolaska = value; }
        public DateTime DatumPovratka { get => datumPovratka; set => datumPovratka = value; }
        public int MinimalniBrojPutnika { get => minimalniBrojPutnika; set => minimalniBrojPutnika = value; }
        public int MaximalniBrojPutnika { get => maximalniBrojPutnika; set => maximalniBrojPutnika = value; }
        public string OpisPutovanja { get => opisPutovanja; set => opisPutovanja = value; }
        public bool IstaknutoPutovanje { get => istaknutoPutovanje; set => istaknutoPutovanje = value; }
        public int IdAgencije { get => idAgencije; set => idAgencije = value; }
        public Destinacija InfoDestinacije { get => infoDestinacije; set => infoDestinacije = value; }
        public Hotel InfoHotela { get => infoHotela; set => infoHotela = value; }
        public Prevoz InfoPrevoza { get => infoPrevoza; set => infoPrevoza = value; }
        public Double Cijena { get => cijena; set => cijena = value; }
        public int TrenutniBrojPutnika { get => trenutniBrojPutnika; set => trenutniBrojPutnika = value; }
    }
}
