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
            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(label4.Text) ||
                string.IsNullOrWhiteSpace(label6.Text) ||
                string.IsNullOrWhiteSpace(label9.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Eğer boş alan varsa işlemi durdur
            }

            try
            {
                baglanti.Open();

                double vki = Convert.ToDouble(label4.Text);
                double yagorani = Convert.ToDouble(label9.Text);

                SqlCommand komut = new SqlCommand("INSERT INTO Table_5 (Ad_Soyad, Boy, Kilo, VKI_Degeri, Cinsiyet, Tc_Kimlik, yagorani) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);
                komut.Parameters.AddWithValue("@p4", vki);
                komut.Parameters.AddWithValue("@p5", label6.Text);
                komut.Parameters.AddWithValue("@p6", textBox4.Text);
                komut.Parameters.AddWithValue("@p7", yagorani);

                komut.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Table_5 ORDER BY Eklenme_Tarihi ASC", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                MessageBox.Show("Girdiğiniz Bilgiler Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet9.Table_6' table. You can move, or remove it, as needed.
            this.table_6TableAdapter2.Fill(this.rumeysaOzenDataSet9.Table_6);
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet8.Table_6' table. You can move, or remove it, as needed.
            this.table_6TableAdapter1.Fill(this.rumeysaOzenDataSet8.Table_6);
            // TODO: This line of code loads data into the 'rumeysaOzenDataSet7.Table_6' table. You can move, or remove it, as needed.
            this.table_6TableAdapter.Fill(this.rumeysaOzenDataSet7.Table_6);
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

            // DataGridView Başlık Stili
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            // Alternatif Satır Renkleri
            dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Kenarlıklar
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;

            // Hücre Metni Ortalamak
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Satır Yüksekliği Ayarlama
            dataGridView2.RowTemplate.Height = 30;

            // Otomatik Sütun Genişliği
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void acilis()
        {
           
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Table_5 ORDER BY Eklenme_Tarihi ASC", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            
            
        }

        public void acilis2()
        {

            SqlDataAdapter df = new SqlDataAdapter("SELECT * FROM Table_6 ORDER BY AdSoyad ASC", baglanti);
            DataTable dc = new DataTable();
            df.Fill(dc);
            dataGridView2.DataSource = dc;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            acilis();
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Lütfen boy ve kilo bilgilerini giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }

            try
            {
                double vki;
                double boy = Convert.ToDouble(textBox2.Text);
                double kilo = Convert.ToDouble(textBox3.Text);

                // Boyun sıfır olup olmadığı kontrol ediliyor (Sıfıra bölme hatasını engellemek için)
                if (boy <= 0)
                {
                    MessageBox.Show("Boy bilgisi 0 veya negatif olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vki = kilo / ((boy / 100) * (boy / 100)); // VKI hesaplaması
                label4.Text = vki.ToString("0.000");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(label6.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }

            try
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

                label9.Text = yagorani.ToString("0.000");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            int sabah, ogle, aksam, alternatif, hedefkalori;
            int toplam;
            string adsoyad, durum;
            DateTime tarih;

            sabah = Convert.ToInt16(TxtSabah.Text);
            ogle = Convert.ToInt16(TxtOgle.Text);
            aksam = Convert.ToInt16(TxtAksam.Text);
            alternatif = Convert.ToInt16(TxtAlternatif.Text);
            adsoyad = textBox8.Text;
            tarih = dateTimePicker1.Value;
            hedefkalori = Convert.ToInt16(textBox9.Text);

           

            

            


            toplam = sabah + ogle + aksam + alternatif;

            if (hedefkalori < toplam)
            {
                durum = "Hedef Kalorinin Altında";
            }
            else if (hedefkalori > toplam)
            {
                durum = "Hedef Kalori Geçildi";
            }
            else
            {
                durum = "Hedef Kalori Tamamlandı";
            }

            label22.Text = toplam.ToString();




            label18.Text = toplam.ToString();
            durum = label23.Text;
            

            SqlCommand komut2 = new SqlCommand("INSERT INTO Table_6 (AdSoyad, Tarih, Sabah, Ogle, Aksam, Alternatif, HedefKalori, GunlukKaloriToplam, Durum ) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)", baglanti);

            komut2.Parameters.AddWithValue("@p1", adsoyad);
            komut2.Parameters.AddWithValue("@p2", tarih);
            komut2.Parameters.AddWithValue("@p3", sabah);
            komut2.Parameters.AddWithValue("@p4", ogle);
            komut2.Parameters.AddWithValue("@p5", aksam);
            komut2.Parameters.AddWithValue("@p6", alternatif);
            komut2.Parameters.AddWithValue("@p7", hedefkalori);  // yapılacak!
            komut2.Parameters.AddWithValue("@p8", toplam);
            komut2.Parameters.AddWithValue("@p9", durum); // YAPILACAK!

           
            

            komut2.ExecuteNonQuery();
            acilis2();

            baglanti.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("Delete From Table_6 Where AdSoyad=@k1", baglanti);

            komutsil.Parameters.AddWithValue("@k1", textBox8.Text);
            

            komutsil.ExecuteNonQuery();
            acilis2();

            MessageBox.Show("Kayıt Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);


            baglanti.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen2 = dataGridView2.SelectedCells[0].RowIndex;

            textBox8.Text = dataGridView2.Rows[secilen2].Cells[0].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView2.Rows[secilen2].Cells[1].Value);
            TxtSabah.Text = dataGridView2.Rows[secilen2].Cells[2].Value.ToString();
            TxtOgle.Text = dataGridView2.Rows[secilen2].Cells[3].Value.ToString();
            TxtAksam.Text = dataGridView2.Rows[secilen2].Cells[4].Value.ToString();
            TxtAlternatif.Text = dataGridView2.Rows[secilen2].Cells[5].Value.ToString();
        }
    }
}
