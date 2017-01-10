using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cw4
{
    public partial class Form1 : Form
    {
        string[][] systemDecyzyjny;

        public Form1()
        {
            InitializeComponent();
            cb_progJakosci.SelectedIndex = 0;
        }

        #region Wczytywanie Systemu
        private void btn_Wczytaj_Click(object sender, EventArgs e)
        {
            var wynik = ofd.ShowDialog();
            if (wynik != DialogResult.OK)
                return;

            if (wynik == DialogResult.OK)
            {

                tb_Sciezka.Text = ofd.FileName;
                string trescPliku = System.IO.File.ReadAllText(ofd.FileName);
                string[] poziomy = trescPliku.Split('\n');
               string[][] daneZPliku = new string[poziomy.Length][];

                for (int i = 0; i < poziomy.Length; i++)
                {
                    string poziom = poziomy[i].Trim();
                    string[] miejscaParkingowe = poziom.Split(' ');
                    daneZPliku[i] = new string[miejscaParkingowe.Length];
                    for (int j = 0; j < miejscaParkingowe.Length; j++)
                    {
                        daneZPliku[i][j] = miejscaParkingowe[j];

                    }
                }

                systemDecyzyjny = daneZPliku;
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            ofd.Filter = "Text (.txt) |*.txt";
        }

        private void btn_oblicz_Click(object sender, EventArgs e)
        {
            tb_wynik.Clear();
            double progJakosci = 0;
            switch (cb_progJakosci.SelectedIndex)
            {
                case 0:
                    progJakosci = ((double)1 / (double)10);
                    break;
                case 1:
                    progJakosci = ((double)2 / (double)10);
                    break;
                case 2:
                    progJakosci = ((double)3 / (double)10);
                    break;
                case 3:
                    progJakosci = ((double)4 / (double)10);
                    break;
                default:
                    progJakosci = ((double)1 / (double)3);
                    break;
            }

            Apriori ap = new Apriori(systemDecyzyjny, 2);
            List<Regula> reguly = ap.Algorytm();

            foreach (var item in reguly)
            {
                if(item.jakosc >= progJakosci){
                    tb_wynik.AppendText(item.ToString());
                    tb_wynik.AppendText(Environment.NewLine);
                    tb_wynik.AppendText(Environment.NewLine);
                }
            }
        }


    }
}
