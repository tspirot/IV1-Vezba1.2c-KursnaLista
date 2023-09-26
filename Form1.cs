using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vezba1._2c
{
    public partial class Form1 : Form
    {
        Dictionary<string, double> kursevi = 
            new Dictionary<string, double>();
        BindingSource bs;
        public Form1()
        {
            InitializeComponent();
            //listBoxKursevi.Items.Add("USD");
        }
        // primer zadatka za genericku metodu

        private void Form1_Load(object sender, EventArgs e)
        {
            bs = new BindingSource(kursevi, null);
            listBoxKursevi.DataSource = bs;
            listBoxKursevi.DisplayMember = "Key";
            kursevi.Add("EUR",117.5);
            OsveziListBox();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            kursevi.Add(textBoxValuta.Text,
                double.Parse(textBoxKurs.Text));
            OsveziListBox();
        }
        public void OsveziListBox()
        {
            listBoxKursevi.Items.Clear();
            foreach (var item in kursevi)
            {
                listBoxKursevi.Items.Add(item);
            }
        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {
            if(listBoxKursevi.SelectedIndex == -1)
            {
                MessageBox.Show("Niste selektovali valutu");
                return;
            }
            string kljuc;
            kljuc = ((KeyValuePair<string, double>)listBoxKursevi.SelectedItem).Key;
            kursevi.Remove(kljuc);
            OsveziListBox();
        }

        private void listBoxKursevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxKursevi.SelectedIndex != -1)//ako je selektovano
            {
                textBoxValuta.Text = ((KeyValuePair<string, double>)
                    listBoxKursevi.SelectedItem).Key;
                textBoxKurs.Text = ((KeyValuePair<string, double>)
                    listBoxKursevi.SelectedItem).Value.ToString();
            }
            else //ako nije selektovano
            {
                textBoxValuta.Text = "";
                textBoxKurs.Text = "";
            }
        }
        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            if(listBoxKursevi.SelectedIndex == -1)
                MessageBox.Show("Niste selektovali valutu");
            else
            {
                string kljuc;
                kljuc = ((KeyValuePair<string, double>)
                                 listBoxKursevi.SelectedItem).Key;
                kursevi[kljuc] = double.Parse(textBoxKurs.Text);
                OsveziListBox();
            }
        }
    }
}
