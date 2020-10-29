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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.oledb.4.0; Data Source=database.mdb;");

        void listele()
        {
            DataTable tablo = new DataTable();
            OleDbDataAdapter veriler = new OleDbDataAdapter("select Baslik,Email,KullaniciAdi,Sifre,Tarih from Data", baglan);
            veriler.Fill(tablo);
            dataGridView1.DataSource = tablo;
            dataGridView2.DataSource = tablo;
        }
        void listele2()
        {
            DataTable tablo = new DataTable();
            OleDbDataAdapter veriler = new OleDbDataAdapter("select * from Data", baglan);
            veriler.Fill(tablo);
           
            dataGridView2.DataSource = tablo;
        }

        void duzeltmecek()
        {
            textBox1.AutoCompleteCustomSource.Clear();
            textBox6.AutoCompleteCustomSource.Clear();
            baglan.Open();
            OleDbCommand dcek = new OleDbCommand("select * from Data",baglan);
            OleDbDataReader doku = dcek.ExecuteReader();
            while(doku.Read())
            {
                textBox1.AutoCompleteCustomSource.Add(doku[1].ToString());
                textBox6.AutoCompleteCustomSource.Add(doku[1].ToString());
            }

            baglan.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
            duzeltmecek();
            listele2();
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[2].Width = 105;

            

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            panel4.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label9.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label10.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label11.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label12.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            label13.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");

            button4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            button5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            button5.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            button6.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            button7.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            button8.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFC25C");
            button6.ForeColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            button7.ForeColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            button8.ForeColor = System.Drawing.ColorTranslator.FromHtml("#424657");


            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#EBEBEC");
            tabPage1.BackColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            tabPage2.BackColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            tabPage3.BackColor = System.Drawing.ColorTranslator.FromHtml("#424657");
            dataGridView1.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#424657");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            tabControl1.SelectedTab = tabPage1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable tablo1 = new DataTable();
            OleDbDataAdapter veriler1 = new OleDbDataAdapter("select Baslik,Email,KullaniciAdi,Sifre,Tarih from Data where Baslik like '%" + textBox1.Text+"%'   ", baglan);
            veriler1.Fill(tablo1);
            dataGridView1.DataSource = tablo1;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                DialogResult sor;
                sor = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo);
                if (sor == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if((textBox2.Text=="") || (textBox4.Text == "") || (textBox5.Text == "") )
            {
                MessageBox.Show("Please enter text in required fields");
            }
            else
            {
                baglan.Open();
                OleDbCommand yaz = new OleDbCommand("Insert Into Data(Baslik,Email,KullaniciAdi,Sifre,Tarih) values('" + textBox2.Text + "','"+ textBox3.Text + "','"+ textBox4.Text + "','"+ textBox5.Text + "',now())", baglan);
              

                yaz.ExecuteNonQuery();
                baglan.Close();

                listele();
                duzeltmecek();
                listele2();
                MessageBox.Show("Save successful");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }




            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable tablo2 = new DataTable();
            OleDbDataAdapter veriler2 = new OleDbDataAdapter("select * from Data where Baslik like '%" + textBox6.Text + "%'   ", baglan);
            veriler2.Fill(tablo2);
            dataGridView2.DataSource = tablo2;
        }
        public static int istenenid;
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                istenenid = Convert.ToInt32(selectedRow.Cells["id"].Value);
                

                textBox7.Text= Convert.ToString(selectedRow.Cells[1].Value);
                textBox8.Text = Convert.ToString(selectedRow.Cells[2].Value);
                textBox9.Text = Convert.ToString(selectedRow.Cells[3].Value);
                textBox10.Text = Convert.ToString(selectedRow.Cells[4].Value);
                

            }
            }
            catch { }
            finally { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox9.Text == "") || (textBox10.Text == ""))
            {
                MessageBox.Show("Please enter text in required fields");
            }
            else
            {
                DialogResult sor;
                sor = MessageBox.Show("Bilgiler Güncellensin mi?","Güncelle",MessageBoxButtons.YesNo);
                if(sor == DialogResult.Yes)
                {
                    baglan.Open();
                    //Baslik,Email,KullaniciAdi,Sifre,Tarih
                    OleDbCommand guncel = new OleDbCommand("Update Data set Baslik='"+textBox7.Text+"', Email='"+textBox8.Text+"' , KullaniciAdi='"+textBox9.Text+"' , Sifre='"+textBox10.Text+"' , Tarih=Now() where id="+istenenid+" ",baglan);
                    guncel.ExecuteNonQuery();
                    MessageBox.Show("İşlem Başarılı");
                    
                    baglan.Close();
                    listele2();
                    listele();
                    duzeltmecek();
                }
            
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            DialogResult sor;
            sor = MessageBox.Show("Seçilen veri silinsin mi?", "Sil", MessageBoxButtons.YesNo);
            if (sor == DialogResult.Yes)
            {

                baglan.Open();
                OleDbCommand sil = new OleDbCommand("delete from data where id=" + istenenid + " ", baglan);
                sil.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Silme İşlemi Başarılı");
                listele2();
                listele();
                duzeltmecek();
            }
        }
    }
}
