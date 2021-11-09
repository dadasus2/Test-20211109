using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_20211109
{
    public class Banka
    {
        public string jmeno;
        public float aktualniZustatek;
        public string cisloUctu;
        public float kontokorentLimit = -200;
        public bool kontokorent;
        public int max = 200000;
        public int tydenniLimit = 10000;
        public int platebniLimit = 10000;


        public Banka(string jmeno, float aktualniZustatek, string cisloUctu)
        {
            this.jmeno = jmeno;
            this.aktualniZustatek = aktualniZustatek;
            this.cisloUctu = cisloUctu;
        }
        public void Vklad(float vklad)
        {
            if (vklad + aktualniZustatek <= max)
            {
                aktualniZustatek += vklad;
                MessageBox.Show("Bylo vloženo: " + vklad.ToString());
            }
            else if (vklad + aktualniZustatek >= max)
            {
                MessageBox.Show("Nepodařilo se vložit z důvodu překročení limitu");
                MessageBox.Show("Váš maximální limit je: " + max);
            }
        }
        public void Vypis()
        {
            MessageBox.Show("Číslo účtu: " + cisloUctu + Environment.NewLine + "Aktuální zůstatek: " + aktualniZustatek + Environment.NewLine + "Týdenní limit: " + tydenniLimit + Environment.NewLine + "Platební limit: " + platebniLimit);
        }

        public void Vyber(float vyber)
        {

            if (vyber - aktualniZustatek <= 0 && vyber <= tydenniLimit)
            {
                aktualniZustatek -= vyber;
                MessageBox.Show("vybrali ste: " + vyber.ToString());
            }
            else if (vyber - aktualniZustatek > 0 && kontokorent == false)
            {
                MessageBox.Show("ses bezdák");
            }
            else if (vyber - aktualniZustatek > kontokorentLimit && kontokorent == true)
            {
                aktualniZustatek -= vyber;
                MessageBox.Show("Bylo vybráno: " + vyber.ToString());
                if (aktualniZustatek <= kontokorentLimit)
                {
                    MessageBox.Show("Byl překročen imit");
                    aktualniZustatek = kontokorentLimit;
                }
            } 
            else
            {
                MessageBox.Show("Překročili jste týdenní limit!!");
            }
        }
        public void Navyseni(int navyseni)
        {
            if (navyseni > tydenniLimit)
            {
                tydenniLimit = navyseni;
                MessageBox.Show("Navýšili jste svůj výběr na: " + tydenniLimit);
            }
            if (navyseni < tydenniLimit)
            {
                tydenniLimit = navyseni;
                MessageBox.Show("Zmenšili jste svůj výber na: " + tydenniLimit);
            }
        }
        public void NavyseniPlatby(int navyseni)
        {
            if (navyseni > platebniLimit)
            {
                platebniLimit = navyseni;
                MessageBox.Show("Navýšili jste svůj platební limit na: " + platebniLimit);
            }
            if (navyseni < platebniLimit)
            {
                platebniLimit = navyseni;
                MessageBox.Show("Zmenšili jste svůj platební limit na: " + platebniLimit);
            }
        }
        public void Platba (float platba, string cisloUctu)
        {
            if (platba - aktualniZustatek <= 0 && platba <= platebniLimit)
            {
                aktualniZustatek -= platba;
                MessageBox.Show("Transakce byla provedena na číslo učtu: " + cisloUctu + " s částkou:" + platba);
                MessageBox.Show("Aktualní zůstatek na účtě: " + aktualniZustatek);
            }
            else if (platba - aktualniZustatek > 0)
            {
                MessageBox.Show("Nemáte dostatek peněz na provedení transakce");
            }
            else
            {
                MessageBox.Show("Nepodařilo se akci dokončit, došlo k překročení platebního limitu");
            }
        }
    }
}
