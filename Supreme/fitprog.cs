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
using System.Data.OleDb;
using Quartz.Impl;
using Quartz.Impl.Matchers;


namespace Supreme
{
    public partial class fitprog : Form
    {
        public fitprog()
        {
            InitializeComponent();
        }

        /// //////////////////////////////////////SERVER BAĞLANTI YERİ/////////////////////////////////////
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-UMFQTVC\GYM;Initial Catalog=I:\BigCon\Gym\Supreme\GYMVT.MDF;Integrated Security=True");
        /// //////////////////////////////////////SERVER BAĞLANTI YERİ////////////////////////////////////
        int key = 0;





        private void fitprog_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı '_I__BigCon_Gym_Supreme_GYMVT_MDFDataSet9.Gym' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.gymTableAdapter5.Fill(this._I__BigCon_Gym_Supreme_GYMVT_MDFDataSet9.Gym);




            SqlCommand query = new SqlCommand("select Idb,ad,soyad from Gym", Con);
            Con.Open();
            SqlDataReader dr = query.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())   

            {



                comboBox1.Items.Add(dr.GetInt32(0));
                //comboBox1.Items.Add(dr["Idb"] +" "+dr["ad"] +" "+dr["soyad"]);


            }
            dr.Close();
           

        }

        


        private void button3_Click(object sender, EventArgs e)
        {
            Menu log = new Menu();
            log.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        DataTable tablo = new DataTable();

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
              
                Con.Open();
                string query = "select ad,soyad,omuz, gogus, kol, bel, quad, program from Gym where Idb=' " + comboBox1.SelectedItem + " ' ";

                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
 
                uyedgv.DataSource = null;
                uyedgv.Refresh();

                uyedgv.DataSource = ds.Tables[0];
                

                Con.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void uyedgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
      
       
        public void uyedgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (key == 0 || omuztb.Text == "" || gogustb.Text == "" || koltb.Text == "" || beltb.Text == "" || quadtb.Text == "" || programtb.Text == "")
            {
                MessageBox.Show("Eksik bilgi");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "update Gym set omuz='" + omuztb.Text + "', gogus='" + gogustb.Text + "', kol= '" + koltb.Text + "', bel= '" + beltb.Text + "', quad= '" + quadtb.Text + "', program= '" + programtb.Text + "'where Idb=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üye güncellendi");
                    Con.Close();
                    omuztb.Text = "";
                    gogustb.Text = "";
                    koltb.Text = "";
                    beltb.Text = "";
                    quadtb.Text = "";
                    programtb.Text = "";

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }


        }
        private void uyedgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(uyedgv.SelectedRows[0].Cells[0].Value.ToString());
            omuztb.Text = uyedgv.SelectedRows[0].Cells[3].Value.ToString();
            gogustb.Text = uyedgv.SelectedRows[0].Cells[4].Value.ToString();
            koltb.Text = uyedgv.SelectedRows[0].Cells[5].Value.ToString();
            beltb.Text = uyedgv.SelectedRows[0].Cells[6].Value.ToString();
            quadtb.Text = uyedgv.SelectedRows[0].Cells[7].Value.ToString();
            programtb.Text = uyedgv.SelectedRows[0].Cells[8].Value.ToString();
             

        }
    }
}
