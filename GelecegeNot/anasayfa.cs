using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing.Text;

namespace GelecegeNot
{
    public partial class anasayfa : Form
    {
        
       
        public anasayfa()
        {
            InitializeComponent();
            
            
        }
        // kullanacagım bazı değişkenleri aldım
        public string kullaniciad;
        public string sifre;
        public string geleceknot;
        DateTime hedef;
        DateTime noteDate;
        DateTime nowdate = DateTime.Now;

        // sql ile baglandım

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-3RVNUIO8\\SQLEXPRESS01;Initial Catalog=Gelecege_Not;Integrated Security=True");
        SqlDataAdapter ad;
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void btnnot_Click(object sender, EventArgs e)
        {
            geleceknot = txtglcknot.Text;//Kullanıcıya yeni bir not yazdırdım ve not hatırlatma tarihini seçtim 
             noteDate = dtmpck.Value;
           
            DateTime value = dtmpck.Value;
            
            baglanti.Open();
            string sorgu = "Insert into gelecege_not(Not_olusturma,Not_tarihi,Olusturulan_tarih)Values(@text,@notdate,@showdate)";//notları ve tarihleri veritabanına ekledim
            SqlCommand com = new SqlCommand(sorgu, baglanti);
            com.Parameters.AddWithValue("@text", geleceknot);
            com.Parameters.AddWithValue("@notdate", noteDate);
            com.Parameters.AddWithValue("@showdate", nowdate);
            com.ExecuteNonQuery();

            baglanti.Close();
            txtglcknot.Clear();//Not yazdıktan sonra texboxumu temizledim

            msjzmn.Start();//timerı başlattım


        }

        private void btnliste_Click(object sender, EventArgs e)
        {
            baglanti.Open();//Gelecek notları listemek için veritabanından tarihi geçmemiş notları istedim
            ad = new SqlDataAdapter("Select Not_olusturma from gelecege_not Where Not_tarihi >GETDATE() ",baglanti);
            DataTable de = new DataTable();
            ad.Fill(de);
            listeglck.DataSource = de;
            baglanti.Close();

            
            
        }

        private void txtliste_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

       

        private void lblkullaniad_Click(object sender, EventArgs e)
        {
           
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
           lblkullaniad.Text = kullaniciad;//Formuma kullanıcı adını ekledim
            kullaniciad = lblkullaniad.Text;
        }

        

        private void btnstop_Click(object sender, EventArgs e)
        {
            this.Hide();//uygulamadan çıkmak için bu butonu kullanıyoruz
        }

        private void btnile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lütfen 'elifasik25@gmail.com' adresine dilek ve şikayetlerinizi bildiriniz!!");//kullanıcının yaşadıgı zaman bu buton ile iletişim saglayacağı alana yönlenriyorum
        }

        private void listeglck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtglcknot_TextChanged(object sender, EventArgs e)
        {
          
          

        }

        private void dtmpck_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listegecmiis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listetarih_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btntrh_Click(object sender, EventArgs e)
        {
            baglanti.Open();//Gelecek tarihleri hatılatan bir liste
            ad = new SqlDataAdapter("Select Not_tarihi from gelecege_not Where Not_tarihi >GETDATE() ", baglanti);
            DataTable de = new DataTable();
            ad.Fill(de);
            listetarih.DataSource = de;
            baglanti.Close();
        }

        private void btngcm_Click(object sender, EventArgs e)
        {
            baglanti.Open();//geçmiş notları listeliyorum
            ad = new SqlDataAdapter("Select *from gelecege_not where Not_tarihi < GETDATE()",baglanti);
            DataTable de = new DataTable();
            ad.Fill(de);
            listegecmiis.DataSource = de;
            baglanti.Close();
        }

        private void msjzmn_Tick(object sender, EventArgs e)
        {
            DateTime simdi = DateTime.Now;//Etkinligin süresi geldiginde bu mesajı veriyorum
            TimeSpan kalan = hedef - simdi;
            if(simdi>= hedef)
            {
                msjzmn.Stop();
                
                MessageBox.Show("Etkinilik zamanınız geldi :\n" +geleceknot+"\n"+noteDate+"\n HATIRLATMA");
                
                hedef = DateTime.MinValue;

                klnzmn.Text = "Süre Doldu";
               

            }
            else
            {
               
                klnzmn.Text = "Kalan Zaman : " + kalan.ToString(@"hh\:mm\:ss");
            }


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;//bir numericupdown açıyorum
            this.Size = new Size(1, 60);

        }

        private void klnzmn_Click(object sender, EventArgs e)
        {
            // bu labela kalan zamanı yazdırıyorum
        }

      
        
    }
}
//Data Source=LAPTOP-3RVNUIO8\SQLEXPRESS01;Initial Catalog=Gelecege_Not;Integrated Security=True;Trust Server Certificate=True