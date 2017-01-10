using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw4
{
    class Regula
    {
        public List<string> deskryptory;//??
        public string decyzja;
        public double wsparcie;
        public double ufnosc;
        private double _jakosc;

        public double jakosc
        {
            get { return wsparcie*ufnosc; }
            set { _jakosc = value; }
        }


        public Regula(string decyzja, List<string> deskryptory)
        {
            this.decyzja = decyzja;
            this.deskryptory = deskryptory;
        }

        public List<string> ZwrocReguleJakoListe()
        {
            List<string> lista = new List<string>();
            lista.AddRange(deskryptory);
            lista.Add(decyzja);
            return lista;
        }

        public override string ToString()
        {
            string regula = "";
            foreach (string deskryptor in deskryptory)
            {
                regula += deskryptor + "^";               
            }
            regula = regula.TrimEnd('^');
            regula += "=>" + decyzja;
            regula += String.Format(" | wsparcie = {0:0.00}, ufność = {1:0.00}, jakość = {2:0.00}"
                , wsparcie, ufnosc, jakosc);
            return regula;
        }
    }
}
