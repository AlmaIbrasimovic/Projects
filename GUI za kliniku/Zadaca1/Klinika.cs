using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Klinika : IPrint
    { 
        private List<Pacijent> listaPacijenata17270 = new List<Pacijent>();
        private List<Pregled> listaPregleda17270 = new List<Pregled>();
        private List<Karton> listaKartona17270 = new List<Karton>();
        private List<Uposlenici> listaUposlenika17270 = new List<Uposlenici>();
        private List<string>  prvaPomoc = new List<string>();
        private List<object> listaSmrti = new List<object>();
        private  List<Ordinacije> listaOrdinacija = new List<Ordinacije>();
        public List<Pregled> ListaPregleda { get => listaPregleda17270; set => listaPregleda17270 = value; }
        public List<Pacijent> ListaPacijenata { get => listaPacijenata17270; set => listaPacijenata17270 = value; }
        public List<Karton> ListaKartona { get => listaKartona17270; set => listaKartona17270 = value; }
        public List<Uposlenici> ListaUposlenika17270 { get => listaUposlenika17270; set => listaUposlenika17270 = value; }
        public List<string> PrvaPomoc { get => prvaPomoc; set => prvaPomoc = value; }
        public List<object> ListaSmrti { get => listaSmrti; set => listaSmrti = value; }
        public List<Ordinacije> ListaOrdinacija { get => listaOrdinacija; set => listaOrdinacija = value; }


        public void registrujNovogPacijenta(Pacijent noviPacijent)
        {
            if (ListaPacijenata.Any(pacijent=> pacijent._JMBG == noviPacijent._JMBG))
            {
                int index = listaPacijenata17270.FindIndex(x => x._JMBG == noviPacijent._JMBG);
                listaPacijenata17270[index].BrojPosjeta++;
            }
            if (!(ListaPacijenata.Any(pacijent => pacijent._JMBG == noviPacijent._JMBG))) listaPacijenata17270.Add(noviPacijent);
            Console.WriteLine("Pacijent uspjesno registrovan!\n");
        }

        public string vratiNajredovnijegPacijenta()
        {
            int maxPosjeta = ListaPacijenata[0].BrojPosjeta;
            int gdjeJe = 0;
            for (int i = 0; i < ListaPacijenata.Count; i++)
            {
                if (ListaPacijenata[i].BrojPosjeta > maxPosjeta)
                {
                    maxPosjeta = ListaPacijenata[i].BrojPosjeta;
                    gdjeJe = i;
                }
            }
            return String.Format(ListaPacijenata[gdjeJe]._Ime + " " + ListaPacijenata[gdjeJe]._Prezime);
        }
        public bool registrujNoviPregled(Pregled noviPregled)
        {
            /*if (listaPregleda17270.Count > 0 &&
                (listaPregleda17270.Any(pregled => pregled._datumPregleda == noviPregled._datumPregleda) && listaPregleda17270.Any(pregled => pregled.jmbg == noviPregled.jmbg)))
            {
                Console.WriteLine("Vec je registrovan pregled za tog pacijenta na taj datum i vrijeme!");
                return; 
            }*/
          /*  for (int i = 0; i < ListaKartona.Count; i++)
            {
                if (listaKartona17270.Count == 0) return false;
            }*/
           /* bool ima = false;
            if (listaPacijenata17270.Count != 0)
            {
                for (int i = 0; i < ListaPacijenata.Count; i++)
                {
                    if (ListaPacijenata[i]._JMBG == noviPregled.jmbg && ListaKartona[i].Jmbg == noviPregled.jmbg)
                        ima = true;
                }
            }
            if (ima)
            {*/
            if (ListaPacijenata.Any(pacijent => pacijent._JMBG == noviPregled.jmbg))
            {
                listaPregleda17270.Add(noviPregled);
                Pregled nP = noviPregled;
                nP.redCekanja(noviPregled);
                listaPregleda17270.Sort(delegate(Pregled c1, Pregled c2)
                {
                    return (c1.cekanje(noviPregled).CompareTo(c2.cekanje(noviPregled)));
                });
                Console.WriteLine("Pregled za tog pacijenta dodan!\n");
                return true;
            }
            else
            {
                Console.WriteLine("Ne postoji pacijent za tim JMBG-om!\n");
                return false;
            }
            //}
            // return ima;

        }
        public void izbrisiPacijenta(int jmbg)
        {
            if (listaPacijenata17270.Any(pacijent => pacijent._JMBG == jmbg))
            {
                int index = listaPacijenata17270.FindIndex(x => x._JMBG == jmbg);
                listaPacijenata17270.RemoveAt(index);
                Console.WriteLine("Pacijent sa JMBG {0} je uklonjen iz baze!\n\n", jmbg);
            }
            else { 
                Console.WriteLine("Pacijent sa tim JMBG ne postoji u bazi!\n\n");
                return;   
            }
            if (listaKartona17270.Any(karton => karton.Jmbg == jmbg))
            {
                int index = listaKartona17270.FindIndex(x => x.Jmbg == jmbg);
                listaKartona17270.RemoveAt(index);
            }
        }
        public string pretragaKartona(int jmbg)
        {
            bool pronaden = false;
            string rez = " ";
            for (int i = 0; i < listaKartona17270.Count; i++)
            {
                if (listaKartona17270[i].Jmbg == jmbg)
                {
                    rez = listaKartona17270[i].ispisiString();
                    pronaden = true; 
                }
            }
            if (!pronaden) { 
                Console.Write("Ne postoji karton za pacijenta sa datim JMBG-om!\n");
                //return;
            }
            return rez;
        }
        public void azurirajTerapije(List<string> noveTerapije, int jmbg)
        {
            int index = 0;
            if (listaPregleda17270.Any(pregled => pregled.jmbg == jmbg))
            {
                if (ListaKartona.Count != 0)
                {
                    for (int i = 0; i < ListaKartona.Count; i++)
                    {
                        if (ListaKartona[i].Jmbg == jmbg) index = i;
                    }
                    for (int i = 0; i < noveTerapije.Count; i++)
                        listaKartona17270[index].ListaTerapija.Add(noveTerapije[i]);
                }
                else Console.WriteLine("Nema kartona za tog pacijenta!\n");

            }
           
        }
        public void kreirajKarton(Karton noviKarton)
        {
       
            if (listaPacijenata17270.Any(karton => karton._JMBG == noviKarton.Jmbg))
            {
                listaKartona17270.Add(noviKarton);
                
            }
            else
            {
                Console.WriteLine("Ne postoji pacijent sa tim JMBG-om!\n");
            }
        }
     /*   public static void ispisiString()
        {
            throw new NotImplementedException();
        }*/
        public double obracunajCijenePregleda(int jmbg, int tip)
        {
            List<Pregled> tempListaPregleda = new List<Pregled>();
            bool pronaden = false;
            double cijena = 0D;
            int index = listaPacijenata17270.FindIndex(x => x._JMBG == jmbg);
            for (int j = 0; j < listaPregleda17270.Count; j++)
            {
                if (listaPregleda17270[j].jmbg == jmbg)
                {
                    tempListaPregleda.Add(listaPregleda17270[j]);
                    pronaden = true;
                }
            }
            double dodatnaCijena = 0.15D;
            double smanjenaCijena = 0.1D;
            //tip == 1 gotovinsko else karticno
            for (int i = 0; i < tempListaPregleda.Count; i++)
            {
                Pregled nP = tempListaPregleda[i];
                cijena += nP.cijenePregleda(tempListaPregleda[i]);
            }
            if (listaPacijenata17270[index] is HitniSlucajevi)
            {
                if (listaPacijenata17270[index].BrojPosjeta > 3)
                {
                    if (tip == 1) cijena -= cijena * smanjenaCijena;
                    else if (tip == 2) cijena = cijena;
                }
                else
                {
                    if (tip == 1) cijena = cijena;
                    else if (tip == 2) cijena += cijena * dodatnaCijena;
                }
            }
            if (listaPacijenata17270[index] is NormalniSlucajevi)
            {
                if (listaPacijenata17270[index].BrojPosjeta > 3)
                {
                    if (tip == 1) cijena -= cijena * smanjenaCijena;
                    else if (tip == 2) cijena = cijena;
                }
                else
                {
                    if (tip == 1) cijena = cijena;
                    else if (tip == 2) cijena += cijena * dodatnaCijena;
                }
            }

            if (!pronaden)
            {
                Console.WriteLine("Nije pronaden pacijent sa tim JMBG-om!");
                return -1;
            }
            return cijena;
        }
        public string prikaziPreglede(int jmbg)
        {
            List<Pregled> tempListaPregleda = new List<Pregled>();
            Boolean pronaden = false;
            string rez = String.Empty;
            for (int j = 0; j < listaPregleda17270.Count; j++)
            {
                if (listaPregleda17270[j].jmbg == jmbg)
                {
                    tempListaPregleda.Add(listaPregleda17270[j]);
                    pronaden = true;
                }
            }
            for (int i = 0; i < tempListaPregleda.Count; i++)
            {
                rez += tempListaPregleda[i].ispisiString();
            }
            if (!pronaden)
            {
                Console.WriteLine("Nije pronaden pacijent sa unesenim JMBG-om!\n");
               // return;
            }
            return rez;
        }
        public void prikaziTipPregleda(int jmbg)
        {
            List<Pregled> tempListaPregleda = new List<Pregled>();
            Boolean pronaden = false;
            for (int j = 0; j < listaPregleda17270.Count; j++)
            {
                if (listaPregleda17270[j].jmbg == jmbg)
                {
                    tempListaPregleda.Add(listaPregleda17270[j]);
                    pronaden = true;
                }
            }
            for (int i = 0; i < tempListaPregleda.Count; i++)
            {
                Pregled nP = tempListaPregleda[i];
                Console.WriteLine(nP.vratiTipPregleda(tempListaPregleda[i]));
            }
            if (!pronaden)
            {
                Console.WriteLine("Nije pronaden pacijent sa unesenim JMBG-om!\n");
                return;
            }
        }
        public string favDoktor()
        {
            List<int> listaDoc = new List<int>();
            listaDoc.Add(globalnaKlasa.ortoDoktori); listaDoc.Add(globalnaKlasa.dermaDoktori);
            listaDoc.Add(globalnaKlasa.interDoktori); listaDoc.Add(globalnaKlasa.labDoktori);
            listaDoc.Add(globalnaKlasa.otoroDoktori); listaDoc.Add(globalnaKlasa.kardDoktori);
            listaDoc.Add(globalnaKlasa.stomaDoktori); listaDoc.Add(globalnaKlasa.oftaDoktori);
            int max = listaDoc.Max();
            int index = listaDoc.FindIndex(x=>x == max);
            switch (index)
            {
                case 0: return "Ortoped";
                case 1: return "Dermatolog";
                case 2: return "Internista";
                case 3: return "Laborant";
                case 4: return "Otorinolaringolog";
                case 5: return "Kardiolog";
                case 6: return "Stomatolog";
                case 7: return "Oftamolog";
            }
            return "ok";
        }

        public string najplacenijiDoka()
        {
            string richDoc = favDoktor();
            switch (richDoc)
            {
                case "Ortoped": return "N N";
                case "Dermatolog": return "Miki Maus";
                case "Internista": return "Dr House";
                case "Laborant": return "Red Bull";
                case "Otorinolaringolog": return "Hana Bezdrob";
                case "Kardiolog": return "Adnan Arnautovic";
                case "Stomatolog": return "Niko Nikic";
                case "Oftamolog": return "Neko Nekic";
            }
            return "ok";

        }
        public double plataDoktora(string tipDoktora)
        {
            Doktori doc = new Doktori(tipDoktora);
            return  doc.plataDoktora(tipDoktora);
        }
        public void Preminuo(int jmbg)
        {
            izbrisiPacijenta(jmbg);
        }
        public void izbrisiKarton(int jmbg)
        {
            if (listaKartona17270.Any(pacijent => pacijent.Jmbg== jmbg))
            {
                int index = listaKartona17270.FindIndex(x => x.Jmbg == jmbg);
                listaKartona17270.RemoveAt(index);
                Console.WriteLine("Karton pacijenta sa JMBG {0} je uklonjen iz baze!\n\n", jmbg);
            }
            else
            {
                Console.WriteLine("Pacijent sa tim JMBG ne postoji u bazi!\n\n");
                return;
            }
        }
        public string ispisiString()
        {
            throw new NotImplementedException();
        }

 }
}

