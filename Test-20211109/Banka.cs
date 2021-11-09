using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_20211109
{
    class Banka
    {
        public string jmeno;
        public float aktualniZustatek;
        public string cisloUctu;

        public int max = 200000;
        public int tydenniLimit = 1000;
        public int platebniLimit = 5000;

        public float kontokorentLimit = -200;
        public bool kontokorent;
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
                MessageBox.Show("Vložili jste: " + vklad.ToString());
            }
            else if (vklad + aktualniZustatek >= max)
            {
                MessageBox.Show("Překročili jste limit");
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
                MessageBox.Show("Bylo vybráno: " + vyber.ToString());
            }
            else if (vyber - aktualniZustatek > 0 && kontokorent == false)
            {
                MessageBox.Show("jste bez peněz :/");
            }
            else if (vyber - aktualniZustatek > kontokorentLimit && kontokorent == true)
            {
                aktualniZustatek -= vyber;
                MessageBox.Show("Bylo vybráno: " + vyber.ToString());
                if (aktualniZustatek <= kontokorentLimit)
                {
                    MessageBox.Show("Překročili jste limit");
                    aktualniZustatek = kontokorentLimit;
                }
            }
            else
            {
                MessageBox.Show("Výběr se nepodařil, překročili jste týdenní limit");
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
        
    }

}
