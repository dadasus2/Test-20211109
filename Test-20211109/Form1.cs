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
    public partial class Form1 : Form
    {
        Banka banka;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            banka = new Banka("Pavel Soukup", 3000, "84845/45");
            labelJmeno.Text = banka.jmeno;
            labelCisloUctu.Text = banka.cisloUctu.ToString();
            labelAktualni.Text = banka.aktualniZustatek.ToString();

        }

        private void buttonVlozit_Click(object sender, EventArgs e)
        {
            float vklad = float.Parse(textBoxHodnota.Text);
            banka.Vklad(vklad);
            labelAktualni.Text = banka.aktualniZustatek.ToString();
        }

        private void buttonVybrat_Click(object sender, EventArgs e)
        {
            float vyber = float.Parse(textBoxHodnota.Text);
            banka.Vyber(vyber);
            labelAktualni.Text = banka.aktualniZustatek.ToString();
        }


        private void buttonVypis_Click(object sender, EventArgs e)
        {
            banka.Vypis();
        }

       

        

     










    }
}
