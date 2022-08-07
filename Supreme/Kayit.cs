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
using System.Globalization;

namespace Supreme
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }


        /// //////////////////////////////////////SERVER BAĞLANTI YERİ////////////////////////////////////
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-UMFQTVC\GYM;Initial Catalog=I:\BigCon\Gym\Supreme\GYMVT.MDF;Integrated Security=True");
        /// //////////////////////////////////////SERVER BAĞLANTI YERİ////////////////////////////////////






        private void button1_Click(object sender, EventArgs e)
        {
            DateTime bugunTarihi = DateTime.UtcNow;
            DateTime bitisTarihi = giris.Value;
            textBox3.Text = bitisTarihi.ToString();
            textBox3.Text = giris.Value.Date.ToString("yyyy-MM-dd");

            TimeSpan st = bitisTarihi - bugunTarihi;

            textBox2.Text = st.Days.ToString();

            string myString = st.ToString();

            if (st.Days >= 1)
            {
                textBox1.Text = "Aktif";
            }
            else if (st.Days <= 0)
            {
                textBox1.Text = "Pasif";

            }
            else
            {
                textBox1.Text = "Pasif!";
            }

            /////////////////////////////////Aktif Pasif Gün///////////////////////////////////////////////////



            if (AdTb.Text == "" || SoyadTb.Text == "" || TelTb.Text == "" || SporgecmisTb.Text == "")
            {
                MessageBox.Show("Veri giriniz");
            }

            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Gym (ad,soyad,Telefon,Sporg,cikis,sureci,giris) values (@ad,@soyad,@Telefon,@Sporg,@cikis,@sureci,@giris)";
                    SqlCommand cmd = new SqlCommand(query, Con);//sorgu tanımı
                    cmd.Parameters.AddWithValue("@ad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@soyad", SoyadTb.Text);
                    cmd.Parameters.AddWithValue("@Telefon", TelTb.Text);
                    cmd.Parameters.AddWithValue("@Sporg", SporgecmisTb.Text);

                    cmd.Parameters.AddWithValue("@cikis", textBox1.Text);
                    cmd.Parameters.AddWithValue("@sureci", textBox2.Text);
                    cmd.Parameters.AddWithValue("@giris", textBox3.Text);
                    cmd.ExecuteNonQuery();//sorgu yürütme
                    MessageBox.Show("Üye ekleme başarılı");
                    Con.Close();
                    AdTb.Text = "";
                    SoyadTb.Text = "";
                    TelTb.Text = "";
                    SporgecmisTb.Text = "";
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Kayit_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu log = new Menu();
            log.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yumurtanın beyazını yiyorum sarısını martılara atıyorum!", "Frankenstein",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void giris_ValueChanged(object sender, EventArgs e)
        {


        }
    }
}
