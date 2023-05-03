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


namespace PersonekKayit
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-GLOA13K; Initial Catalog = PersonelVeriTabani; Integrated Security = True");
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_yonetici where kullaniciadi=@p1 and sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txtkullaniciadi.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                frmanamenu fr=new frmanamenu();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı ya da şifre!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
