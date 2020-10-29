using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.oledb.4.0; Data Source=database.mdb;");
        private void Form1_Load(object sender, EventArgs e)
        {
           this.ActiveControl = pictureBox1;
           textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEC");
           textBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEC"); 
           button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
           button1.ForeColor  = System.Drawing.ColorTranslator.FromHtml("#333464");
           button1.FlatAppearance.MouseOverBackColor  = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
           button1.FlatAppearance.MouseDownBackColor  = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult sor;
                sor = MessageBox.Show("Do you want to exit?","Exit",MessageBoxButtons.YesNo);
                if (sor == DialogResult.Yes)
                {
                    Close();
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text=="User Name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
          
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "User Name";
                textBox1.ForeColor = Color.Gray;
            }

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.UseSystemPasswordChar = false;
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox1.Text == "User Name")
            {
                MessageBox.Show("Please enter username");
            }
            else if (textBox2.Text == "" || textBox2.Text == "Password")
            {
                MessageBox.Show("Please enter password");
            }
            else
            {
                //veri tabanı giriş kısmı
                OleDbCommand sorgu = new OleDbCommand("select * from Admin where UserName='"+textBox1.Text+"' and Password='"+textBox2.Text+"'  ",baglan);
                baglan.Open();
                OleDbDataReader oku = sorgu.ExecuteReader();
                if(oku.Read())
                {
                    this.Hide();
                    Form2 gec = new Form2();
                    gec.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
                baglan.Close();
            }
        }
    }
}
