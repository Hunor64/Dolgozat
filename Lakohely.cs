using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozatWPF
{
    class Lakohely
    {
        string varmegyeKod;
        string telepules;
        string tipus;
        int ferfiak;
        int nok;
        public Lakohely(string sor)
        {
            List<string> lista = sor.Split(';').ToList();
            this.varmegyeKod = lista[0];
            this.telepules = lista[1];
            this.tipus = lista[2];
            this.ferfiak = Convert.ToInt32(lista[3]);
            this.nok = Convert.ToInt32(lista[4]);
        }

        public string VarmegyeKod { get => varmegyeKod; }
        public string Telepules { get => telepules; }
        public string Tipus { get => tipus; }
        public int Ferfiak { get => ferfiak; }
        public int Nok { get => nok; }
    }
}
