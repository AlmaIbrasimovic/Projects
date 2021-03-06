﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public partial class Pregled : IPrint
    {
        private string tipPregleda17270;
        private DateTime datumPregleda17270;
        private string JMBGPacijenta17270;
        private List<Doktori> listaDoktora17270 = new List<Doktori>();
        private double cijena;
        public Pregled(string tip, DateTime datum, string _jmbg, double cijena = 50)
        {
            _tipPregleda = tip;
            _datumPregleda = datum;
            jmbg = _jmbg;
            Cijena = cijena;
        }
        public string _tipPregleda
        {
            get { return tipPregleda17270; }
            set { tipPregleda17270 = value; }
        }
        public DateTime _datumPregleda
        {
            get { return datumPregleda17270; }
            set { datumPregleda17270 = value; }
        }
        public string jmbg
        {
            get { return JMBGPacijenta17270; }
            set { JMBGPacijenta17270 = value; }
        }

        public List<Doktori> ListaDoktora17270 { get => listaDoktora17270; set => listaDoktora17270 = value; }
        public double Cijena { get => cijena; set => cijena = value; }

        public void redCekanja(Pregled noviPregled)
        {
            
            if (noviPregled._tipPregleda == "Ortopedski")
            {
                globalnaKlasa.ortoDoktori++;
                //ListaDoktora17270.Add(new Doktori("N","N",1000, globalnaKlasa.ortoDoktori++, "Ortoped"));
                globalnaKlasa.orto++;
            }
            else if (noviPregled._tipPregleda == "Kardioloski")
            {
                globalnaKlasa.kardDoktori++;
                globalnaKlasa.kard++;
              //  ListaDoktora17270.Add(new Doktori("Miki","Maus",1000, globalnaKlasa.kardDoktori++, "Kardiolog"));
            }
            else if (noviPregled._tipPregleda == "Dermatoloski")
            {
                globalnaKlasa.dermaDoktori++;
              //  ListaDoktora17270.Add(new Doktori("Dr,","House",1000, globalnaKlasa.dermaDoktori++, "Dermatolog"));
                globalnaKlasa.derma++;
            }
            else if (noviPregled._tipPregleda == "Internisticki")
            {
                globalnaKlasa.interDoktori++;
              //  ListaDoktora17270.Add(new Doktori("Red","Bull", 1000, globalnaKlasa.interDoktori++, "Internista"));
                globalnaKlasa.inter++;
            }
            else if (noviPregled._tipPregleda == "Otorinolaringoloski")
            {
                globalnaKlasa.otoroDoktori++;
              //  ListaDoktora17270.Add(new Doktori("Hana", "Bezdrob", 1000, globalnaKlasa.otoroDoktori++, "Otorinolaringolog"));
                globalnaKlasa.otoro++;
            }
            else if (noviPregled._tipPregleda == "Oftamoloski")
            {
                globalnaKlasa.oftaDoktori++;
               // ListaDoktora17270.Add(new Doktori("Adnan", "Arnautovic",1000, globalnaKlasa.oftaDoktori++, "Oftamolog"));
                globalnaKlasa.ofta++;
            }
            else if (noviPregled._tipPregleda == "Labaratorijski")
            {
                globalnaKlasa.labDoktori++;
               // ListaDoktora17270.Add(new Doktori("Niko","Nikic",1000, globalnaKlasa.labDoktori++, "Laborant"));
                globalnaKlasa.lab++;
            }
            else
            {
                globalnaKlasa.stomaDoktori++;
                //ListaDoktora17270.Add(new Doktori("Neko", "Nekic", 1000, globalnaKlasa.stomaDoktori++, "Stomatolog"));
                globalnaKlasa.stoma++;
            }
        }
        public int cekanje(Pregled noviPregled)
        {
            if (noviPregled._tipPregleda == "Ortopedski") return globalnaKlasa.orto;
            if (noviPregled._tipPregleda == "Kardioloski") return globalnaKlasa.kard;
            if (noviPregled._tipPregleda == "Dermatoloski") return globalnaKlasa.derma;  
            if (noviPregled._tipPregleda == "Internisticki") return globalnaKlasa.inter;
            if (noviPregled._tipPregleda == "Otorinolaringoloski") return globalnaKlasa.otoro;
            if (noviPregled._tipPregleda == "Oftamoloski") return globalnaKlasa.ofta;
            if (noviPregled._tipPregleda == "Labaratorijski") return globalnaKlasa.lab;
            return globalnaKlasa.stoma;
        }
        public string imeDoktora(string tip )
        {
            if (tip == "Ortopedski") return "Bogo Moljka";
            if (tip == "Kardioloski") return "Veljko Kunić";
            if (tip == "Dermatoloski") return "Lili Štriga";
            if (tip == "Internisticki") return "Toni Grgeč";
            if (tip == "Otorinolaringoloski") return "Florijan Gavran";
            if (tip == "Oftamoloski") return "Ante Guzina";
            if (tip == "Labaratorijski") return "sestra Helga";
            return "Franjo Slaviček";
        }

    }
}
