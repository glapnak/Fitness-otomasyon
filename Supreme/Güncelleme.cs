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

namespace Supreme
{
    public partial class Güncelleme : Form
    {
        public Güncelleme()
        {
            InitializeComponent();
        }

        /// //////////////////////////////////////SERVER BAĞLANTI YERİ////////////////////////////////////
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-UMFQTVC\GYM;Initial Catalog=I:\BigCon\Gym\Supreme\GYMVT.MDF;Integrated Security=True");
        /// //////////////////////////////////////SERVER BAĞLANTI YERİ////////////////////////////////////


        int key = 0;

        

        private void populate()
        {
            Con.Open();
            string query = "select Idb, ad, soyad, Telefon, Sporg, cikis, sureci from Gym ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            uyedgv.DataSource = null;
            uyedgv.Refresh();

            uyedgv.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || AdTb.Text == "" || SoyadTb.Text == "" || TelTb.Text == "" || SporgecmisTb.Text == "")
            {
                MessageBox.Show("Eksik bilgi");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "update Gym set ad='" + AdTb.Text + "', soyad='" + SoyadTb.Text + "', Telefon= '" + TelTb.Text + "', Sporg= '" + SporgecmisTb.Text + "', sureci= '" + SureTb.Text + "'where Idb=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üye güncellendi");
                    Con.Close();
                    AdTb.Text = "";
                    SoyadTb.Text = "";
                    TelTb.Text = "";
                    SporgecmisTb.Text = "";              
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Seçilen üye kaldırıldı");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "delete from Gym where Idb=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üye kaldırıldı");
                    Con.Close();
                    AdTb.Text = "";
                    SoyadTb.Text = "";
                    TelTb.Text = "";
                    SporgecmisTb.Text = "";
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu log = new Menu();
            log.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dokunma bana tikim var!", "Canavar uyandı",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void uyedgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(uyedgv.SelectedRows[0].Cells[0].Value.ToString());
            AdTb.Text = uyedgv.SelectedRows[0].Cells[1].Value.ToString();
            SoyadTb.Text = uyedgv.SelectedRows[0].Cells[2].Value.ToString();
            TelTb.Text = uyedgv.SelectedRows[0].Cells[3].Value.ToString();
            SporgecmisTb.Text = uyedgv.SelectedRows[0].Cells[4].Value.ToString();
            SureTb.Text = uyedgv.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void Güncelleme_Load(object sender, EventArgs e)
        {
            
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

    }
}
