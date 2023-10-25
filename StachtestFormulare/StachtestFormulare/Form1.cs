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

namespace StachtestFormulare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Color barva = Color.White;
        Font pismo;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            // NOVA HRA
            Form novahra = new Form(); 
            novahra.Show(); novahra.BackColor = barva;
            novahra.Font = pismo;
            TextBox zadanijmena = new TextBox();
            zadanijmena.Size = new Size(100, 100);
            zadanijmena.Location = new Point(15, 15);
            Button potvrzeni = new Button();
            potvrzeni.Size = new Size(100, 100);
            potvrzeni.Location = new Point(15, 50);
            potvrzeni.Text = "Potvrzeni";
            potvrzeni.Name = "potvrzeni";
            potvrzeni.DialogResult = DialogResult.OK;
            novahra.Controls.Add(potvrzeni);
            novahra.Controls.Add(zadanijmena);
            novahra.Visible = false;
            if (novahra.ShowDialog() == DialogResult.OK)
            {

                Form ulozeno = new Form();
                ulozeno.Show();
                ulozeno.BackColor = barva;
                ulozeno.Font = pismo;
                StreamWriter sw = new StreamWriter("hra.txt");
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                sw.WriteLine(dt.ToString() + " Jmeno: " + zadanijmena.Text);
                Label label = new Label();
                label.Text = dt.ToString() + " Jmeno: " + zadanijmena.Text;
                label.Size = new Size(200, 200);
                label.Location = new Point(15, 50);
                ulozeno.Controls.Add(label);
                sw.Close();
                ulozeno.Close();
                MessageBox.Show("Ulozeno " + dt.ToString() + " Jmeno: " + zadanijmena.Text);

            }
            novahra.Close();
            
            this.Show();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // NASTAVENI

            Form nastaveni = new Form();
            nastaveni.Show();
            nastaveni.BackColor = barva;
            nastaveni.Font = pismo;
            ColorDialog cd = new ColorDialog();
            CheckBox fs = new CheckBox();
            fs.Text = "fullscreen";
            fs.Location = new Point(20, 30);
            fs.Size = new Size(100,100);
            nastaveni.Controls.Add(fs);
            if(fs.Checked == true)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            if (cd.ShowDialog() == DialogResult.OK)
            {
                barva = cd.Color;
                BackColor = cd.Color;
            }

            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                pismo = fontDialog.Font;
                Font = fontDialog.Font;
            }

            //Button ulozit = new Button();
            //Button zpet = new Button();
            //ulozit.Size = new Size(50, 20);
            //ulozit.Text = "Ulozit";
            //ulozit.Location = new Point(20, 60);
            //nastaveni.Controls.Add(ulozit);
            

            //zpet.Size = new Size(50, 20);
            //zpet.Text = "Zpet";
            //zpet.Location = new Point(60, 60);
            
            //nastaveni.Controls.Add(zpet);

        }

        private void button4_Click(object sender, EventArgs e)
        {


            ///         UKONCENI HRY

            Form ukonceni = new Form();
            ukonceni.Show();
            ukonceni.Font = pismo;
            ukonceni.BackColor = barva;
            Label text = new Label();
            text.Text = "Opravdu chcete ukocnit hru?";
            text.Location = new Point(20, 20);
            text.Size = new Size(200, 200);
            Button ano = new Button();
            ano.Size = new Size(50, 30);
            ano.Text = "Ano";
            ano.DialogResult = DialogResult.Yes;
            ano.Location = new Point(30, 100);

            Button ne = new Button();
            ne.Size = new Size(50, 30);
            ne.Text = "Ne";
            ne.DialogResult = DialogResult.No;
            ne.Location = new Point(100, 100);
            ukonceni.Controls.Add(ne);
            ukonceni.Controls.Add(ano);
            ukonceni.Controls.Add(text);
            ukonceni.Visible = false;
            if(ukonceni.ShowDialog() == DialogResult.Yes)
            {
                Application.Exit();
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form nacisthru = new Form();
            nacisthru.Show();
            nacisthru.BackColor = barva;
            nacisthru.Font = pismo;
            StreamReader sr = new StreamReader("hra.txt");
            string hra = string.Empty;
            while (!sr.EndOfStream)
            {                         
                hra =  sr.ReadLine();

            }
            Label text = new Label();
            text.Text = hra;
            text.Location = new Point(20, 20);
            text.Size = new Size(200, 200);
            nacisthru.Controls.Add(text);

            sr.Close();

        }
    }
}
