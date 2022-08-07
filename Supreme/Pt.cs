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
    public partial class Pt : Form
    {
        public Pt()
        {
            InitializeComponent();
        }





        /// //////////////////////////////////////SERVER BAĞLANTI YERİ////////////////////////////////////
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-UMFQTVC\GYM;Initial Catalog=I:\BigCon\Gym\Supreme\GYMVT.MDF;Integrated Security=True");
        /// //////////////////////////////////////SERVER BAĞLANTI YERİ////////////////////////////////////



        DataTable dt = new DataTable();
        string yeniyol = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı '_I__BigCon_Gym_Supreme_GYMVT_MDFDataSet6.Pt' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.ptTableAdapter.Fill(this._I__BigCon_Gym_Supreme_GYMVT_MDFDataSet6.Pt);
            doldur();

        }



        void doldur()
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                dt.Clear();
                SqlDataAdapter listele = new SqlDataAdapter("select * from Pt", Con);
                listele.Fill(dt);
                uyedgv.DataSource = dt;
                listele.Dispose();
                uyedgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                          
                Con.Close();
                AdTb.Text = "";
                SoyadTb.Text = "";
                SureTb.Text = "";              
                comboBox2.Text = "";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void populate()
        {
            Con.Open();
            string query = "select PtIdb, ptad, ptsoyad, pttecrube, ptoncelik from Pt ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            uyedgv.DataSource = null;
            uyedgv.Refresh();

            uyedgv.DataSource = ds.Tables[0];
            Con.Close();
        }


        int key = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || AdTb.Text == "" || SoyadTb.Text == "" || SureTb.Text == "")
            {
                MessageBox.Show("Eksik bilgi");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "update Pt set ptad='" + AdTb.Text + "', ptsoyad='" + SoyadTb.Text + "', pttecrube= '" + SureTb.Text + "', ptoncelik= '" + comboBox2.SelectedItem + "'where PtIdb=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üye güncellendi");
                    Con.Close();
                    AdTb.Text = "";
                    SoyadTb.Text = "";
                    SureTb.Text = "";
                    comboBox2.SelectedItem = "";
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PtKayit log = new PtKayit();
            log.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu log = new Menu();
            log.Show();
            this.Hide();
        }

        private void uyedgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(uyedgv.SelectedRows[0].Cells[0].Value.ToString());
            AdTb.Text = uyedgv.SelectedRows[0].Cells[1].Value.ToString();
            SoyadTb.Text = uyedgv.SelectedRows[0].Cells[2].Value.ToString();
            SureTb.Text = uyedgv.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.SelectedItem = uyedgv.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

  
    }
}
