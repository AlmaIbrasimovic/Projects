using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Uposlenici : IPrint
    {
        private int zagarantovanaPlata = 1000;

        public Uposlenici() {}

        public Uposlenici(int zagarantovanaPlata)
        {
            this.zagarantovanaPlata = zagarantovanaPlata;
        }
        public int ZagarantovanaPlata
        {
            get { return zagarantovanaPlata; }
            set { zagarantovanaPlata = value; }
        }
        public string ispisiString()
        {
            throw new NotImplementedException();
        }
    }
}
