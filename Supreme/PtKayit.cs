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
using System.IO;

namespace Supreme
{
    public partial class PtKayit : Form
    {
        public PtKayit()
        {
            InitializeComponent();
        }

        /// //////////////////////////////////////SERVER BAĞLANTI YERİ////////////////////////////////////
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-UMFQTVC\GYM;Initial Catalog=I:\BigCon\Gym\Supreme\GYMVT.MDF;Integrated Security=True");
        /// //////////////////////////////////////SERVER BAĞLANTI YERİ////////////////////////////////////




        private void button1_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || SoyadTb.Text == "" || SporgecmisTb.Text == "")
            {
                MessageBox.Show("Veri giriniz");
            }

            else
            {
                try
                {
                    Con.Open();

                    string query = "insert into Pt (ptad,ptsoyad,pttecrube,ptoncelik) values (@ptad,@ptsoyad,@pttecrube,@ptoncelik)";
                    SqlCommand cmd = new SqlCommand(query, Con);//sorgu tanımı
                    cmd.Parameters.AddWithValue("@ptad", AdTb.Text);
                    cmd.Parameters.AddWithValue("@ptsoyad", SoyadTb.Text);
                    cmd.Parameters.AddWithValue("@pttecrube", SporgecmisTb.Text);
                    cmd.Parameters.AddWithValue("@ptoncelik", comboBox2.SelectedItem);

                    cmd.ExecuteNonQuery();//sorgu yürütme
                    MessageBox.Show("Üye ekleme başarılı");
                    Con.Close();
                    AdTb.Text = "";
                    SoyadTb.Text = "";
                    SporgecmisTb.Text = "";

                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pt log = new Pt();
            log.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

        
    }
