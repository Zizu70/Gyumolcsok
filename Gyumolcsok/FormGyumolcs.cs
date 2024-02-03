using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gyumolcsok
{
    public partial class FormGyumolcs : Form
    {
        string operation;
        public FormGyumolcs(string operation, Object param=null)
        {
            InitializeComponent();

            this.operation = operation;

            switch (operation)
            {
                case "insert":
                    button1.Text = "Rögzítés";
                    this.Text = "Az új gyümölcs adatai";  
                    break;
                case "update":
                    button1.Text = "Módosít";
                    this.Text = "A gyümölcs adatainak módosítása";
                    Gyumolcs gyumolcs = (Gyumolcs)param;
                    textBox1.Text = gyumolcs.Termekkod.ToString();
                    textBox2.Text = gyumolcs.Gyumolcsneve.ToString();
                    textBox3.Text = gyumolcs.Mennyiseg.ToString();
                    break;
                default:
                    break;
            }
        }

        private void FormGyumolcs_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "insert":
                    insertGyumolcs();
                    break;
                case "update":
                    updateGyumolcs();
                    break;
            }
        }

        private void insertGyumolcs()
        {
            ulong termekkod = (ulong)(Program.openForm.listBox1.Items.Count + 1); 

            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gyumolcsneve = textBox2.Text;

            if (!int.TryParse(textBox3.Text, out int mennyiseg) || mennyiseg <= 0)                 

            {
                MessageBox.Show("Hibás formátum vagy adat a Mennyiség mezőben!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
/*            
            // ell., hogy csak betű van-e benne
            if (string.IsNullOrEmpty(textBox2.Text) || !textBox2.Text.All(char.IsLetter))   // Ez nem működik
            {
                MessageBox.Show("A név csak betűket tartalmazhat!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }
*/
           
            Gyumolcs ujgyumolcs = new Gyumolcs(termekkod, gyumolcsneve, mennyiseg);
            Program.openForm.listBox1.Items.Add(ujgyumolcs);
            this.Close();
        }
    

        private void updateGyumolcs()
        {
            ulong termekkod = ulong.Parse(textBox1.Text);

            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gyumolcsneve = textBox2.Text;

            if (!int.TryParse(textBox3.Text, out int mennyiseg) || mennyiseg <= 0)
            {
                MessageBox.Show("Hibás formátum vagy adat a Mennyiség mezőben!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            Gyumolcs gyumolcs = new Gyumolcs(termekkod, gyumolcsneve, mennyiseg);
            Program.openForm.listBox1.Items.Add(gyumolcs);
            this.Close();
        }

        

        //******************** NEM KELL *********************//
        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //***************************************************//
    }
}
