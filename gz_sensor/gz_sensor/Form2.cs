using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gz_sensor
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 fm = new Form4();
            fm.Show();
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;Database=gz_proje;uid=root;Password=12345678;");
        DataTable tablo = new DataTable();

        public void listele()
        {
            MySqlDataAdapter adtr = new MySqlDataAdapter("Select * from kullaniciadi", baglan);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            listele();


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 fm = new Form5();
            fm.Show();
        }
    }
}

