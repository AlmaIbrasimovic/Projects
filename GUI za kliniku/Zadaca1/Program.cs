using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medicinskaSestra;

namespace Zadaca1
{
    class Program
    {
        static Klinika klinika17270_1 = new Klinika();
        static void Meni()
        {
            Console.WriteLine("1. Registruj/Briši pacijenta");
            Console.WriteLine("2. Prikaži raspored pregleda pacijenta");
            Console.WriteLine("3. Kreiranje kartona pacijenta");
            Console.WriteLine("4. Pretraga kartona pacijenta");
            Console.WriteLine("5. Registruj novi pregled");
            Console.WriteLine("6. Analiza sadržaja");
            Console.WriteLine("7. Naplata");
            Console.WriteLine("8. Izlaz");
        }
        static void BrisiRegistruj()
        {
            Temp:
            Console.WriteLine("Šta želite:");
            Console.WriteLine("1. Registrovati pacijenta");
            Console.WriteLine("2. Izbrisati pacijenta");
            int izbor;
            Int32.TryParse(Console.ReadLine(), out izbor);
            int izbor1;
          
            switch (izbor)
            {
                case 1:
                    Console.WriteLine("Kakvog pacijenta zelite registrovati: ");
                    Console.WriteLine("1. Hitnog pacijenta\n2. Normalni slucaj");
                    Int32.TryParse(Console.ReadLine(), out izbor1);
                    if (izbor1 == 1) RegistrujHitnog();
                    else if (izbor1 == 2) RegistrujNormalnog();
                    break;
                case 2:
                    Console.Write("Unesite JMBG  pacijenta kojeg zelite obrisati: ");
                    int jmbg;
                    Int32.TryParse(Console.ReadLine(), out jmbg);
                    klinika17270_1.izbrisiPacijenta(jmbg);
                    break;
                default: 
                    Console.WriteLine("Pogresan odabir.Pokusajte ponovo!");
                    goto Temp;
            }
        }

        static void RegistrujNormalnog()
        {
            Console.Write("Unesite ime pacijenta: ");
            string ime = Console.ReadLine();
            Console.Write("Unesite prezime pacijenta: ");
            string prezime = Console.ReadLine();
            Console.Write("Unesite datum rodjenja pacijenta:\nDan: ");
            int dan;
            Int32.TryParse(Console.ReadLine(), out dan);
            Console.Write("Mjesec: ");
            int mjesec;
            Int32.TryParse(Console.ReadLine(), out mjesec);
            Console.Write("Godina: ");
            int godina;
            Int32.TryParse(Console.ReadLine(), out godina);
            Console.Write("Unesite JMBG pacijenta: ");
            int jmbg;
            Int32.TryParse(Console.ReadLine(), out jmbg);
            string spol;
            do
            {
                Console.Write("Unesite spol pacijenta (Z) zensko, (M) musko: ");
                spol = Console.ReadLine();
                if (spol != "Z" && spol != "M") Console.WriteLine("Greska!");
            } while (spol != "Z" && spol != "M");
            Console.Write("Unesite datum prijema pacijenta:\nDan: ");
            int dan1;
            Int32.TryParse(Console.ReadLine(), out dan1);
            Console.Write("Mjesec: ");
            int mjesec1;
            Int32.TryParse(Console.ReadLine(), out mjesec1);
            Console.Write("Godina: ");
            int godina1;
            Int32.TryParse(Console.ReadLine(), out godina1);
            string bracno;
            do
            {
                Console.Write("Unesite bracno stanje pacijenta (brak) ako je u braku, (slobodan) ako nije: ");
                bracno = Console.ReadLine();
                if (bracno != "brak" && bracno != "slobodan") Console.WriteLine("Greska!");
            } while (bracno != "brak" && bracno != "slobodan");
            DateTime rodjenje = new DateTime(godina, mjesec, dan);
            DateTime prijem = new DateTime(godina1, mjesec1, dan1);
            NormalniSlucajevi pacijent17270_1 = new NormalniSlucajevi(ime, prezime, rodjenje, jmbg, spol, prijem, bracno);
            klinika17270_1.registrujNovogPacijenta(pacijent17270_1);
            Console.WriteLine("Pacijent uspjesno registrovan!\n");           
        }
        static void RegistrujHitnog()
        {
            Console.WriteLine("Navedite protokol prve pomoci koja je pruzena pacijentu (K za prekid): ");
            string pomoc;
            do
            {
                pomoc = Console.ReadLine();
                klinika17270_1.PrvaPomoc.Add(pomoc);
            } while (pomoc != "K");
            Console.Write("Unesite ime pacijenta: ");
            string ime = Console.ReadLine();
            Console.Write("Unesite prezime pacijenta: ");
            string prezime = Console.ReadLine();
            Console.Write("Unesite datum rodjenja pacijenta:\nDan: ");
            int dan;
            Int32.TryParse(Console.ReadLine(), out dan);
            Console.Write("Mjesec: ");
            int mjesec;
            Int32.TryParse(Console.ReadLine(), out mjesec);
            Console.Write("Godina: ");
            int godina;
            Int32.TryParse(Console.ReadLine(), out godina);
            Console.Write("Unesite JMBG pacijenta: ");
            int jmbg;
            Int32.TryParse(Console.ReadLine(), out jmbg);
            string spol = String.Empty;
            do
            {
                Console.Write("Unesite spol pacijenta (Z) zensko, (M) musko: ");
                spol = Console.ReadLine();
                if (spol != "Z" && spol != "M") Console.WriteLine("Greska!");
            } while (spol != "Z" && spol != "M");
            Console.Write("Unesite datum prijema pacijenta:\nDan: ");
            int dan1;
            Int32.TryParse(Console.ReadLine(), out dan1);
            Console.Write("Mjesec: ");
            int mjesec1;
            Int32.TryParse(Console.ReadLine(), out mjesec1);
            Console.Write("Godina: ");
            int godina1;
            Int32.TryParse(Console.ReadLine(), out godina1);
            string bracno;
            do
            {
                Console.Write("Unesite bracno stanje pacijenta (brak) ako je u braku, (slobodan) ako nije: ");
                bracno = Console.ReadLine();
                if (bracno != "brak" && bracno != "slobodan") Console.WriteLine("Greska!");
            } while (bracno != "brak" && bracno != "slobodan");
   
           
            DateTime rodjenje = new DateTime(godina, mjesec, dan);
            DateTime prijem = new DateTime(godina1, mjesec1, dan1);
            
            HitniSlucajevi pacijent17270_2 = new HitniSlucajevi(ime, prezime, rodjenje, jmbg, spol, prijem, bracno);
            klinika17270_1.registrujNovogPacijenta(pacijent17270_2);
            Console.WriteLine("Da li je pacijent preminuo: ");
            Console.Write("1. DA\n2. NE\n");
            int umro = Convert.ToInt32(Console.ReadLine());
            if (umro == 1)
            {
                Console.WriteLine("Unesite datum i vrijeme smrti: ");
                Console.Write("Dan: ");
                int d = Convert.ToInt32(Console.ReadLine());
                Console.Write("Mjesec: ");
                int m = Convert.ToInt32(Console.ReadLine());
                Console.Write("Godina: ");
                int g = Convert.ToInt32(Console.ReadLine());
                Console.Write("Sati: ");
                int s = Convert.ToInt32(Console.ReadLine());
                Console.Write("Minute: ");
                int min = Convert.ToInt32(Console.ReadLine());
                Console.Write("Sekunde: ");
                int sec = Convert.ToInt32(Console.ReadLine());
                DateTime vrijemeSmrti = new DateTime(g,m,d,s,min,sec);
                Console.Write("Unesite uzrok smrti: ");
                string uzrokSmrti = Console.ReadLine();
                Console.Write("Da li ce biti obdukcije:\n1. DA\n2. NE\n");
                int temp = Convert.ToInt32(Console.ReadLine());
                if (temp == 1)
                {
                    Console.WriteLine("Unesite datum i vrijeme obdukcije: ");
                    Console.Write("Dan: ");
                    int d1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Mjesec: ");
                    int m1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Godina: ");
                    int g1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Sati: ");
                    int s1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Minute: ");
                    int min1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Sekunde: ");
                    int sec1 = Convert.ToInt32(Console.ReadLine());
                    DateTime vrijemeObdukcije = new DateTime(g1, m1, d1, s1, min1, sec1);
                    klinika17270_1.ListaSmrti.Add(vrijemeObdukcije);
                }
                klinika17270_1.ListaSmrti.Add(vrijemeSmrti);
                klinika17270_1.ListaSmrti.Add(uzrokSmrti);
                klinika17270_1.Preminuo(jmbg);
            }
            if (umro == 2) Console.WriteLine("Pacijent uspjesno registrovan!\n");
        }

        static void RegistrujNoviPregled()
        {
                int odabir = 0;
                string tip = String.Empty;
                do
                {
                    Console.WriteLine("Unesite tip pregleda: ");
                    Console.WriteLine("1. Ortopedski");
                    Console.WriteLine("2. Kardioloski");
                    Console.WriteLine("3. Dermatoloski");
                    Console.WriteLine("4. Internisticki");
                    Console.WriteLine("5. Otorinolaringoloski");
                    Console.WriteLine("6. Oftamoloski");
                    Console.WriteLine("7. Labaratorijski");
                    Console.WriteLine("8. Stomatoloski");
                    Console.WriteLine("9. Pregled za voznju/posao");
                    Int32.TryParse(Console.ReadLine(), out odabir);
                    if (odabir == 1) tip = "Ortopedski";
                    else if (odabir == 2) tip = "Kardioloski";
                    else if (odabir == 3) tip = "Dermatoloski";
                    else if (odabir == 4) tip = "Internisticki";
                    else if (odabir == 5) tip = "Otorinolaringoloski";
                    else if (odabir == 6) tip = "Oftamoloski";
                    else if (odabir == 7) tip = "Labaratorijski";
                    else if (odabir == 8) tip = "Stomatoloski";
                    else tip = "Vozacki";
                    switch (odabir)
                    {
                        case 1:
                            Ortopedija orto = new Ortopedija();
                            if (!orto.daLiJeDostupna(odabir))
                                Console.WriteLine(
                                    "{0} pregled trenutno nije dostupan. Molimo odaberite drugi pregled!\n", tip);
                            break;
                        case 2:
                            Kardiologija kard = new Kardiologija();
                            if (!kard.daLiJeDostupna(odabir))
                                Console.WriteLine(
                                    "{0} pregled trenutno nije dostupan. Molimo odaberite drugi pregled!\n", tip);
                            break;
                        case 3:
                            Dermatologija derma = new Dermatologija();
                            if (!derma.daLiJeDostupna(odabir))
                                Console.WriteLine(
                                    "{0} pregled trenutno nije dostupan. Molimo odaberite drugi pregled!\n", tip);
                            break;
                        case 4:
                            Internisticka inter = new Internisticka();
                            if (!inter.daLiJeDostupna(odabir))
                                Console.WriteLine(
                                    "{0} pregled trenutno nije dostupan. Molimo odaberite drugi pregled!\n", tip);
                            break;
                        case 5:
                            Otorinolaringologija otoro = new Otorinolaringologija();
                            if (!otoro.daLiJeDostupna(odabir))
                                Console.WriteLine(
                                    "{0} pregled trenutno nije dostupan. Molimo odaberite drugi pregled!\n", tip);
                            break;
                        case 6:
                            Oftamologija ofta = new Oftamologija();
                            if (!ofta.daLiJeDostupna(odabir))
                                Console.WriteLine(
                                    "{0} pregled trenutno nije dostupan. Molimo odaberite drugi pregled!\n", tip);
                            break;
                        case 7:
                            Laboratorija lab = new Laboratorija();
                            if (!lab.daLiJeDostupna(odabir))
                                Console.WriteLine(
                                    "{0} pregled trenutno nije dostupan. Molimo odaberite drugi pregled!\n", tip);
                            break;
                        case 8:
                            Stomatologija stoma = new Stomatologija();
                            if (!stoma.daLiJeDostupna(odabir))
                                Console.WriteLine(
                                    "{0} pregled trenutno nije dostupan. Molimo odaberite drugi pregled!\n", tip);
                            break;
                    }

                } while (odabir == 3);
                Console.Write("Unesite datum pregleda\nDan: ");
                int dan;
                Int32.TryParse(Console.ReadLine(), out dan);
                Console.Write("Mjesec: ");
                int mjesec;
                Int32.TryParse(Console.ReadLine(), out mjesec);
                Console.Write("Godina: ");
                int godina;
                Int32.TryParse(Console.ReadLine(), out godina);
                Console.Write("Sati: ");
                int sati;
                Int32.TryParse(Console.ReadLine(), out sati);
                Console.Write("Minute: ");
                int minute;
                Int32.TryParse(Console.ReadLine(), out minute);
                DateTime datumPregleda = new DateTime(godina, mjesec, dan, sati, minute, 0);
                Console.Write("Unesite JMBG korisnika za kojeg zakazujete pregled: ");
                int jmbg;
                Int32.TryParse(Console.ReadLine(), out jmbg);
                Pregled pregled17270_1 = new Pregled(tip, datumPregleda, jmbg);
                bool ok = klinika17270_1.registrujNoviPregled(pregled17270_1);
            if (odabir != 8 && ok)
            {
                Console.WriteLine("Unesite nove terapije za pacijenta (K za prekid): ");
                List<string> listaBolesti = new List<string>();
                string bolesti;
                do
                {
                    bolesti = Console.ReadLine();
                    listaBolesti.Add(bolesti);
                } while (bolesti != "K");
                listaBolesti.Remove("K");
                klinika17270_1.azurirajTerapije(listaBolesti, jmbg);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Dobro došli! Odaberite jednu od opcija: ");
            string opcija;
            do
            {
                Meni();
                opcija = Console.ReadLine();
                if (opcija == "1") BrisiRegistruj();
                else if (opcija == "2") PrikaziPreglede();
                else if (opcija == "3") KreirajKarton();
                else if (opcija == "4") PretragaKartonaPacijenta();
                else if (opcija == "5") RegistrujNoviPregled();
                else if (opcija == "6") PrikaziAnalizu();
                else if (opcija == "7") ObracunajNaplata();
                if (opcija == "8") Console.WriteLine("Doviđenja!");      
            } while (opcija != "8");
            Console.ReadLine();
        }
        static void PrikaziAnalizu()
        {
            Console.Write("Najposjeceniji doktor: ");
            Console.WriteLine(klinika17270_1.favDoktor());
            string Zadro = klinika17270_1.vratiNajredovnijegPacijenta();
            Console.Write("Pacijent koji je posjetio kliniku najvise puta: {0} ", Zadro);
            string BilGates = klinika17270_1.najplacenijiDoka();
            Console.Write("Najplaceniji doktor: {0}", BilGates);

            Console.WriteLine("\n");
        }

        static void ObracunajNaplata()
        {
            Console.Write("Unesite JMBG pacijenta za kojeg zelite obracunati naplatu: ");
            int jmbg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Odaberite nacin placanja: ");
            Console.WriteLine("1. Gotovinsko placanje: ");
            Console.WriteLine("2. Karticno placanje: ");
            int odabir = Convert.ToInt32(Console.ReadLine());
            int brojRata = 0;
            if (odabir == 2)
            {
                Console.WriteLine("Na koliko rata zelite otplatu: ");
                Console.Write("1. 3 rate\n2. 6 rata\n3. 12 rata\n");
                brojRata = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Za sljedece preglede: ");
            klinika17270_1.prikaziTipPregleda(jmbg);
          
            Console.WriteLine("Pacijent treba platiti: {0} KM.\n", klinika17270_1.obracunajCijenePregleda(jmbg, odabir));
            if (odabir == 2)
            {
                double konacnaCijena = (klinika17270_1.obracunajCijenePregleda(jmbg, odabir)) / brojRata;

                Console.WriteLine("Iznos rate je: {0}\n", Math.Round(konacnaCijena,1));
            }
        }

        static void PrikaziPreglede()
        {
            Console.Write("Unesite JMBG pacijenta cije preglede zelite vidjeti: ");
            int jmbg;
            Int32.TryParse(Console.ReadLine(), out jmbg);
            Console.WriteLine(klinika17270_1.prikaziPreglede(jmbg));
        }

       static void PretragaKartonaPacijenta()
        {
            Console.Write("Unesite JMBG od pacijenta: ");
            int jmbg;
            Int32.TryParse(Console.ReadLine(), out jmbg);
            Console.WriteLine(klinika17270_1.pretragaKartona(jmbg));
        }

        static void KreirajKarton()
        {
            Console.Write("Unesite ime pacijenta: ");
            string ime = Console.ReadLine();
            Console.Write("Unesite prezime pacijenta: ");
            string prezime = Console.ReadLine();
            Console.Write("Unesite JMBG pacijenta: ");
            int JMBG;
            Int32.TryParse(Console.ReadLine(), out JMBG);
            Console.Write("Unesite spol pacijenta (Z) zensko (M) musko: ");
            string spol = Console.ReadLine();
            Console.Write("Unesite datum zadnjeg pregleda:\nDan: ");
            int dan;
            Int32.TryParse(Console.ReadLine(), out dan);
            Console.Write("Mjesec: ");
            int mjesec;
            Int32.TryParse(Console.ReadLine(), out mjesec);
            Console.Write("Godina: ");
            int godina;
            Int32.TryParse(Console.ReadLine(), out godina); 
            
            DateTime zadnjiPregled = new DateTime(godina, mjesec, dan);
            Console.WriteLine("Unesite prethodne bolesti pacijenta ('K' za prekid unosa): ");
            string bolesti;
            List<string> lBolesti = new List<string>();
            do
            {
                bolesti = Console.ReadLine(); 
                lBolesti.Add(bolesti);
            } while (bolesti != "K");
            Console.WriteLine("Unesite alergije pacijenta ('K' za prekid unosa): ");
            string alergije;
            List<string> lAlergija = new List<string>();
            do
            {
                alergije = Console.ReadLine();
                lAlergija.Add(alergije);
            } while (alergije != "K");
            Console.WriteLine("Unesite misljenja doktora za bolesti pacijenta ('K' za prekid unosa): ");
            string misljenja;
            List<string> lMisljenja = new List<string>();
            do
            {
                misljenja = Console.ReadLine();
                lMisljenja.Add(misljenja);
            } while (misljenja != "K");
            Console.WriteLine("Unesite dosadasnje terapije pacijenta ('K' za prekid unosa): ");
            string terapije;
            List<string> lTerapije = new List<string>();
            do
            {
                terapije = Console.ReadLine();
               
                lTerapije.Add(terapije);

            } while (terapije != "K");
            lTerapije.Remove("K");
            lMisljenja.Remove("K");
            lBolesti.Remove("K");
            lAlergija.Remove("K");
            Karton karton17270_1 = new Karton(ime, prezime, JMBG, spol,zadnjiPregled, lBolesti, lAlergija, lMisljenja, lTerapije);
            klinika17270_1.kreirajKarton(karton17270_1);
        }
    }
}
