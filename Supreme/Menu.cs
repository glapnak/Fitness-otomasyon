using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supreme
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Kayit kayit = new Kayit();
            kayit.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Güncelleme uyeler = new Güncelleme();
            uyeler.Show();
            this.Hide();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            fitprog fitprog = new fitprog();
            fitprog.Show();
            this.Hide();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Pt fitprog = new Pt();
            fitprog.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Benden daha kaslı arif tarafından yapıldım!", "Frankenstein",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
