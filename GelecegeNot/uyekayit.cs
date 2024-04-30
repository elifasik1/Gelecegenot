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


namespace GelecegeNot
{
    public partial class uyekayit : Form
    {
        public uyekayit()
        {
            InitializeComponent();
           
        }
        // Sql ile baglantımı sagladım
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-3RVNUIO8\\SQLEXPRESS01;Initial Catalog=Gelecege_Not;Integrated Security=True");
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtname1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnuyeol_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into kayit(Kullanici_ad,Sifre)values(@kullanici,@sifre)";//kullanıcı ad ve şifre oluşturduktan sonra üyelik tamamlandı
            SqlCommand komut = new SqlCommand(sorgu,baglanti);
            komut.Parameters.AddWithValue("@kullanici",txtname1.Text);
            komut.Parameters.AddWithValue("@sifre", txtsifre1.Text);
            baglanti.Open();
            
            komut.ExecuteNonQuery();
            MessageBox.Show("KAYDINIZ BASARILI BIR SEKİLDE OLUSTURULDU");
            Form1 form = new Form1();
            form.Show();
            this.Hide();//Üyelik tamamlandıktan sonra tekrar giriş sayfasına yönlendirildi
        }

        private void txtsifre1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
//Data Source=LAPTOP-3RVNUIO8\SQLEXPRESS01;Initial Catalog=Gelecege_Not;Integrated Security=True;Trust Server Certificate=True