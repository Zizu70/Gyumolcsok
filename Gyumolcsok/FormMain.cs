using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gyumolcsok
{
    
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e) // Betöltés
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Betöltés fájlból";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string adatFile = openFileDialog.FileName;
                listBox1.Items.Clear();

                try
                {
                    using (StreamReader sr = new StreamReader(adatFile))
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] sor = sr.ReadLine().Split(';');
                           
                            Gyumolcs ujgyumi = new Gyumolcs(ulong.Parse(sor[0]), sor[1], int.Parse(sor[2]));
                            listBox1.Items.Add(ujgyumi);
                        }
                    }
                    MessageBox.Show("Sikeres adatbetöltés!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt a betöltés során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //Mentés
        {
            if (listBox1.Items.Count == 0) 
            {
                MessageBox.Show("Nincs menthető adat!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";  
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Mentés fájlba";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
                        
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filename = saveFileDialog.FileName;

                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        foreach (Gyumolcs item in listBox1.Items)
                        {
                            writer.Write(item.toTxt() + "\n"); 
                        }
                        writer.Flush();
                    }
                    MessageBox.Show("Adatok sikeresen mentve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { 
                    MessageBox.Show($"Hiba történt a mentés során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)  //Felvitel
        {
            FormGyumolcs formGyumolcs = new FormGyumolcs("insert");
            formGyumolcs.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)  //Módosítás
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kiválasztott gyümölcs!");
                return;
            }
            Gyumolcs gyumolcs = (Gyumolcs)listBox1.SelectedItem; 

            FormGyumolcs formGyumolcs = new FormGyumolcs("update", gyumolcs);  
            formGyumolcs.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e) //Törlés
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kiválasztott gyümölcs!");
                return;
            }
            Gyumolcs gyumolcs = (Gyumolcs)listBox1.SelectedItem;
            listBox1.Items.Remove(gyumolcs);
        }


        //******************* NEM KELL ***************************//
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        //******************* NEM KELL ***************************//

    }
}
