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
using System.Data.Sql;
namespace GelecegeNot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            
        }
        // Sql kütüphanesini ekledikten sonra sql ile baglantı kurdum.
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-3RVNUIO8\\SQLEXPRESS01;Initial Catalog=Gelecege_Not;Integrated Security=True");
        public string kullaniciAd;
        public string Sifre;



        private void gizle_CheckedChanged(object sender, EventArgs e)
        {
            if (gizle.CheckState == CheckState.Checked) //Şifreyi gizlemek için bir checbox kullandım.
            {
                sifretxt.UseSystemPasswordChar = true;
                gizle.Text = "Şifreyi Gizle";
            }
            else if(gizle.CheckState ==CheckState.Unchecked)
            {
                sifretxt.UseSystemPasswordChar = false;
                gizle.Text = "Şifreyi Göster";
            }
        }

        public void btngrs_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();//Sql da kayıtlı olan kullanıcıların girişini gerçekleştirdim.
           SqlCommand komut = new SqlCommand("select *from kayit where Kullanici_ad='" + kullaniciAd + "'and Sifre ='" + Sifre+"'",baglanti);
           SqlDataReader oku = komut.ExecuteReader();
            if(oku.Read())
            {
                anasayfa ana = new anasayfa();
                ana.kullaniciad = kullaniciAd.ToString();
                ana.sifre = Sifre.ToString();
                ana.ShowDialog();
               

                this.Hide();
                
            }
            else
            {
                MessageBox.Show("LÜTFEN BİLGİLERİNİZİ DOĞRU GİRDİĞİNİZDEN EMİN OLUN!!!");
                txtname.Clear();
                sifretxt.Clear();
            }
            oku.Close();
            baglanti.Close();
           
            
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            
            kullaniciAd = txtname.Text;//kullanıcı adını yazdırdım
            txtname.Text = kullaniciAd;
        }

        private void uyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uyekayit uye = new uyekayit();// üye olmak için üye sayfasına yönlendirdim
            uye.Show();
            this.Hide();

        }

        private void sifretxt_TextChanged(object sender, EventArgs e)
        {
            
            Sifre = sifretxt.Text;//şifreyi yazdırdım
            sifretxt.Text = Sifre;
        }
    }
}
//Data Source=LAPTOP-3RVNUIO8\SQLEXPRESS01;Initial Catalog=Gelecege_Not;Integrated Security=True;Trust Server Certificate=True