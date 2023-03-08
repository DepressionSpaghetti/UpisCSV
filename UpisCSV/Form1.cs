using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;

namespace UpisCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            List<Osoba> listOsoba = new List<Osoba>();
            try
            {
                Osoba osoba = new Osoba(txtIme.Text, txtPrezime.Text, txtEmail.Text, Convert.ToInt32(txtGodRod.Text));

                txtIme.Clear();
                txtPrezime.Clear();
                txtEmail.Clear();
                txtGodRod.Clear();

                DialogResult upit = MessageBox.Show("Zelite li unijeti jos podataka", "upit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (upit)
                {
                    case DialogResult.Yes:
                        {
                            listOsoba.Add(osoba);
                            break;
                        }
                    case DialogResult.No:
                        {
                            listOsoba.Add(osoba);
                            break;
                        }

                }
            }catch(Exception greska)
            {
                MessageBox.Show(greska.Message, "Pogresan unos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (var writer = new StreamWriter("filePersons.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(listOsoba);
            }
        }
    }
}
