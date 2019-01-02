using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TravelBookApp.Model
{
    public enum Kontinent { Afrika, Antartika, Azija, Evropa, JuznaAmerika, SjevernaAmerika, Australija };

    public class Destinacija
    {
        private int id;
        private String naziv;
        private String drzava;
        private Kontinent kontinent;
        private Image slikaDestinacije;

        public Destinacija(string naziv, String drzava, Kontinent kontinent, Image slikaDestinacije = null)
        {
            id = Globalna.idSvihDestinacija++;
            Naziv = naziv;
            Drzava = drzava;
            Kontinent = kontinent;
            SlikaDestinacije = slikaDestinacije;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public Image SlikaDestinacije { get => slikaDestinacije; set => slikaDestinacije = value; }
        public string Drzava { get => drzava; set => drzava = value; }
        public Kontinent Kontinent { get => kontinent; set => kontinent = value; }
        public int Id { get => id; }
    }
}
