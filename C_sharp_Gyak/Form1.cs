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

namespace Gyakorlás
{
    public partial class Form1 : Form
    {
        List<Jatek> jatekok = new List<Jatek>();
        int legdragabb = 0;
        public Form1()
        {
          
            List<string> kategoriak = new List<string>();
            string[] sorok = File.ReadAllLines("jatekok.txt");
            foreach (var item in sorok)
            {
                string[] adatok = item.Split(',');
                Jatek jat = new Jatek(adatok[0], adatok[1], adatok[2], adatok[3], adatok[4]);
                jatekok.Add(jat);
            }
           
            foreach (var j in jatekok)
            {
                if (j.ar > legdragabb)
                {
                    legdragabb = j.ar;
                }

               
            }

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int osszdb = 0;
            foreach (var j in jatekok)
            {              
                if (legdragabb == j.ar) {
                    dataGridView1.Rows.Add(j.kategoria, j.cim, j.ar);
                }
                if(!comboBox1.Items.Contains(j.kategoria))
                comboBox1.Items.Add(j.kategoria);

                osszdb += j.db;
            }

            label2.Text = ($"Az össz darabszám: {osszdb}");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (var j in jatekok) {
                if (comboBox1.SelectedItem.ToString() == j.kategoria) { 
                    listBox1.Items.Add($"Cim: {j.cim},Ár: {j.ar}, DB{j.db}");
                }
            }
            
        }
    }
}
