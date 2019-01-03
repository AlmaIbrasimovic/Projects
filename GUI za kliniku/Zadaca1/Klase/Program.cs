using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadaca1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PreminuliPacijenti pac1 = new PreminuliPacijenti("Kurt", "Cobain", new DateTime(1994, 4, 5), new DateTime(1967, 2, 20), "Samoubistvo", "Muško");
            PreminuliPacijenti pac2 = new PreminuliPacijenti("Emina", "Ćatić", new DateTime(2017, 12, 20), new DateTime(1997, 2, 14), "Popila strihnin", "Žensko");
            PreminuliPacijenti pac3 = new PreminuliPacijenti("Chester", "Bennington", new DateTime(2017, 7, 20), new DateTime(1976, 3, 20), "Samoubistvo", "Muško");
            PreminuliPacijenti pac4 = new PreminuliPacijenti("Kenan", "Bajrić", new DateTime(2015, 8, 16), new DateTime(1991, 5, 20), "Saobraćajna nesreća", "Muško");
            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac1);
            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac2);
            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac3);
            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac4);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
