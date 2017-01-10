using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinatorics.Collections;
using System.Diagnostics;
namespace cw4
{
    class Apriori
    {
        private List<string> kombinacje = new List<string>();
        private string[][] system;
        private int progCzestosci;

        public Apriori(string[][] system, int progCzestosci)
        {
            this.system = system;
            this.progCzestosci = progCzestosci;
        }

        //Zwraca Listę zdażeń częstych dla kombinacji
        private List<List<string>> BudowanieZdazenCzesych(Combinations<string> zbior)
        {
            Dictionary<List<string>, int> slownikCzestosci = new Dictionary<List<string>, int>();
            List<List<string>> zdazeniaCzeste = new List<List<string>>();
            foreach (List<string> kombinacja in zbior)
            {
                for (int i = 0; i < system.Length; i++)
                {
                    if(CzyTransakcjaZawieraKombinacje(system[i], kombinacja))
                    {
                        if (!slownikCzestosci.ContainsKey(kombinacja))
                            slownikCzestosci.Add(kombinacja, 1);
                        else
                            slownikCzestosci[kombinacja]++;
                    }
                }
            }
            foreach (var item in slownikCzestosci)
            {
                if(item.Value >= progCzestosci)
                    zdazeniaCzeste.Add(item.Key);
            }
            return zdazeniaCzeste;
        }

        //Zwraca Listę zdażeń częstych dla kombinacji jedno elementowych
        private List<string> BudowanieZdazenCzesychF1(Combinations<string> zbior)
        {
            Dictionary<string, int> slownikCzestosci = new Dictionary<string, int>();
            List<string> zdazeniaCzeste = new List<string>();
            foreach (List<string> kombinacja in zbior)
            {
                for (int i = 0; i < system.Length; i++)
                {
                    if (system[i].Contains(kombinacja[0]))
                    {
                        if (!slownikCzestosci.ContainsKey(kombinacja[0]))
                            slownikCzestosci.Add(kombinacja[0],1);
                        else
                            slownikCzestosci[kombinacja[0]]++;
                    }
                }
            }
            foreach (var item in slownikCzestosci)
            {
                if (item.Value >= progCzestosci)
                    zdazeniaCzeste.Add(item.Key);
            }
            zdazeniaCzeste.Sort();
            return zdazeniaCzeste;
        }

        //Zwraca listę z kandydatami częstymi
        private List<List<string>> CzyKandydaciCzesci(List<List<string>> zbiorPoPrzecieciu)
        {
            List<List<string>> zbiorCzesty = new List<List<string>>();
            Dictionary<List<string>, int> slownikCzestosci = new Dictionary<List<string>, int>();
            //Dla kazdego kandydata sprawdzamy ile razy znajduje sie w systemie 
            foreach (var kandydat in zbiorPoPrzecieciu)
            {
                slownikCzestosci.Add(kandydat, 0);
                for (int i = 0; i < system.Length; i++)
                {
                    if(CzyTransakcjaZawieraKombinacje(system[i], kandydat))
                        slownikCzestosci[kandydat]++;
                }
            }
            //Dodawanie do koncowej listy tylko elementow z czestoscia >= progowiCzestosci
            foreach (var item in slownikCzestosci)
            {
                if (item.Value >= progCzestosci)
                    zbiorCzesty.Add(item.Key);
            }
            return zbiorCzesty;
        }

        public List<Regula> Algorytm()
        {
            List<Regula> reguly = new List<Regula>();

            Combinations<string> kombinacje = new Combinations<string>(systemToList(), 1);
            List<string> F1 = BudowanieZdazenCzesychF1(kombinacje);

            kombinacje = new Combinations<string>(F1, 2);
            List<List<string>> Fk = BudowanieZdazenCzesych(kombinacje);//F2
            reguly.AddRange(LiczenieRegul(Fk));

            int k = 3;
            List<List<string>> Ck;
            List<List<string>> CkPoPrzecieciu;

            do
            {
                Ck = LaczenieElementow(Fk, k);
                CkPoPrzecieciu = Przecinanie(Ck, Fk);
                Fk = CzyKandydaciCzesci(CkPoPrzecieciu);
                k++;
                reguly.AddRange(LiczenieRegul(Fk));
            } while (Fk.Count > 1);

            return reguly;
        }

        //Zwraca tylko tych kandydatów, których wszystkie kombinacje k-1 zawieraja się w zbiorze Fk-1
        private List<List<string>> Przecinanie(List<List<string>> kandydaci, List<List<string>> zbior)
        {
            int dlugosc = kandydaci[0].Count - 1;
            Combinations<string> kombinacje;
            List<List<string>> PoprawniKandydaci = new List<List<string>>();

            foreach (List<string> kandydat in kandydaci)//Dla każdego kandydata
            {
                kombinacje = new Combinations<string>(kandydat, dlugosc);
                int zawiera = 0;
                foreach (var kombinacja in kombinacje)//i każdej jego kombinacji k-1 elementowej
                {
                    for (int i = 0; i < zbior.Count; i++)
                    {
                        if (CzyTransakcjaZawieraKombinacje(zbior[i].ToArray(), kombinacja.ToList()))
                        {
                            zawiera++;//Jeśli transakcja zawiera kombinację to zwiekszamy licznik i nie sprzwdzamy dalszych transakcji
                            break;
                        }
                    }
                }

                if (zawiera == kandydat.Count)//Jesli dla kazdej transakcji zbioru znaleziono kombinacje
                    PoprawniKandydaci.Add(kandydat);
            }
            return PoprawniKandydaci;

        }

        //Łączy elementy zbiory Fk o k-2 pierwszych identycznych pozycjach
        private List<List<string>> LaczenieElementow(List<List<string>> zbior, int k)
        {
            int ileIdentycznych = k - 2;
            List<List<string>> lista = new List<List<string>>();

            for (int i = 0; i < zbior.Count; i++)
            {
                for (int j = i + 1; j < zbior.Count; j++)//Zawsze patrzymy na zbiory o indeksach wyższych od i
                {
                    List<string> listaTmp = new List<string>();
                    bool takieSame = false;

                    for (int m = 0; m < ileIdentycznych; m++)
                    {
                        string pozycja = zbior[i][m];//element zbioru
                        if (pozycja == zbior[j][m])
                            takieSame = true;
                        else
                            takieSame = false;
                    }
                    if (takieSame)
                    {
                        listaTmp.AddRange(zbior[i]);
                        listaTmp.AddRange(zbior[j]);
                    }

                    List<string> listaTmp2 = new List<string>();
                    foreach (var item in listaTmp)//Dla każdego elementu listy tymczasowej
                    {
                        if (!listaTmp2.Contains(item))//Jeśli lista tymczasowa 2 nie zawiera elementu
                            listaTmp2.Add(item);
                    }

                    if (listaTmp2.Count != 0)//Jeśli lista tmp2 nie jest pusta to dodajemy do listy głównej
                    {
                        lista.Add(listaTmp2);
                    }
                }
            }
            return lista;
        }

        //Zwraca true jeśli transakcja(rząd systemu decyzyjnego) zawiera podana kombinacje
        private bool CzyTransakcjaZawieraKombinacje(string[] transakcja, List<string> kombinacja)
        {
            int ile = 0;
            int zawieraInt = kombinacja.Count;
            foreach (string item in kombinacja)
            {
                for (int i = 0; i < transakcja.Length; i++)
                {
                    if (transakcja[i] == item)
                    {
                        ile++;
                        break;
                    }
                }
            }
            if (ile == zawieraInt)
                return true;
            return false;
        }
        

        //Konwertuje system do listy
        private List<string> systemToList()
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < system.Length; i++)
            {
                for (int j = 0; j < system[i].Length; j++)
                {
                    if (!lista.Contains(system[i][j]))
                        lista.Add(system[i][j]);
                }
            }
            return lista;
        }

        private List<Regula> LiczenieRegul(List<List<string>> Fk)
        {
            Combinations<string> kombinacje;
            List<Regula> reguly = new List<Regula>();
            foreach (List<string> kandydat in Fk)
            {
                int indeksDecyzji = kandydat.Count - 1;//Decyzją kandydata jest ostatni element
                kombinacje = new Combinations<string>(kandydat, kandydat.Count - 1);//Tworzymy kombinację z kandydata
                foreach (var kombinacja in kombinacje)//Dla kazdej kombinacji
                {
                    string decyzja = kandydat[indeksDecyzji];
                    Regula r = new Regula(decyzja, kombinacja.ToList());
                    ObliczWsparcieIUfnosc(r);
                    indeksDecyzji--;//To będzie zawsze nie wybrany element w kombinacji
                    reguly.Add(r);
                }                
            }
            return reguly;
        }

        //Oblicza wsparcie i ufność reguly
        private void ObliczWsparcieIUfnosc(Regula regula)
        {
            double licznik = 0;
            double liczbaObiektow = system.Length;
            double mianownikUfnosci = 0;
            for (int i = 0; i < system.Length; i++)
            {
                if(CzyTransakcjaZawieraKombinacje(system[i], regula.ZwrocReguleJakoListe()))
                {
                    licznik++;
                    mianownikUfnosci++;
                }
                else if(CzyTransakcjaZawieraKombinacje(system[i], regula.deskryptory))
                {
                    mianownikUfnosci++;
                }
            }

            regula.wsparcie = licznik / liczbaObiektow;
            regula.ufnosc = licznik / mianownikUfnosci;
        }
    }
}
