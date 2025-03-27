using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Globalization;

namespace WindowsFormsApp4
{
    public partial class Form1: Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-NINNCP6\\SQLEXPRESS; Initial Catalog = RumeysaOzen; Integrated Security=True;Encrypt=False");
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            double vki = Convert.ToDouble(label4.Text);  // label4.Text'teki değeri double'a çevir
            double yagorani = Convert.ToDouble(label9.Text);
            
            

            SqlCommand komut = new SqlCommand("insert into Table_5 (Ad_Soyad, Boy, Kilo, VKI_Degeri, Cinsiyet, Tc_Kimlik, yagorani) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", vki);
            komut.Parameters.AddWithValue("@p5", label6.Text);
            komut.Parameters.AddWithValue("@p6", textBox4.Text);
            komut.Parameters.AddWithValue("@p7", yagorani);



            komut.ExecuteNonQuery();
            this.table_5TableAdapter.Fill(this.rumeysaOzenDataSet.Table_5);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Table_5 ORDER BY Eklenme_Tarihi ASC", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();

            MessageBox.Show("Girdiğiniz Bilgiler Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet6.Table_5' table. You can move, or remove it, as needed.
            this.table_5TableAdapter6.Fill(this.rumeysaOzenDataSet6.Table_5);
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet5.Table_5' table. You can move, or remove it, as needed.
            this.table_5TableAdapter5.Fill(this.rumeysaOzenDataSet5.Table_5);
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet4.Table_5' table. You can move, or remove it, as needed.
            this.table_5TableAdapter4.Fill(this.rumeysaOzenDataSet4.Table_5);
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet3.Table_5' table. You can move, or remove it, as needed.
            this.table_5TableAdapter3.Fill(this.rumeysaOzenDataSet3.Table_5);

            // DataGridView Başlık Stili
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            // Alternatif Satır Renkleri
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Kenarlıklar
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            // Hücre Metni Ortalamak
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Satır Yüksekliği Ayarlama
            dataGridView1.RowTemplate.Height = 30;

            // Otomatik Sütun Genişliği
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void acilis()
        {
           
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Table_5 ORDER BY Eklenme_Tarihi ASC", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Table_5 ORDER BY Eklenme_Tarihi ASC", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double vki;
            double boy;
            double kilo;

            boy = Convert.ToDouble(textBox2.Text);
            kilo = Convert.ToDouble(textBox3.Text);

            vki = kilo / (boy/100 * boy/100);

            label4.Text = vki.ToString("0.000");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("Delete From Table_5 Where Ad_Soyad=@k1", baglanti);

            komutsil.Parameters.AddWithValue("@k1", textBox1.Text);
            acilis();

            komutsil.ExecuteNonQuery();
            
            MessageBox.Show("Kayıt Silindi!");


            baglanti.Close();
        }

        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "Kadın";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "Erkek";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox4.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            label6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            label9.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double belcevresi, yagorani, kilo, boyuncevresi, boy, kalca;
            kilo = Convert.ToDouble(textBox3.Text);
            belcevresi = Convert.ToDouble(textBox5.Text);
            boyuncevresi = Convert.ToDouble(textBox6.Text);
            boy = Convert.ToDouble(textBox2.Text);

            kalca = Convert.ToDouble(textBox7.Text);
           
            if (label6.Text == "Erkek")
            {

                yagorani = 495 / (1.0324 - 0.19077 * Math.Log10(belcevresi - boyuncevresi) + 0.15456 * Math.Log10(boy)) - 450;
            }

            else
            {


                yagorani = 495 / (1.29579 - 0.35004 * Math.Log10(belcevresi + kalca - boyuncevresi) + 0.22100 * Math.Log10(boy)) - 450;
            }
            
            label9.Text = label9.Text.Replace(",", ".");

            label9.Text = yagorani.ToString("0.000");

            







        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
