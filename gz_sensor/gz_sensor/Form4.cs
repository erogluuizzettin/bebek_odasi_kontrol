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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        
        MySqlConnection baglan = new MySqlConnection("Server=localhost;Database=gz_proje;uid=root;Password=12345678;");
        MySqlDataReader dr;
        MySqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            cmd = new MySqlCommand("Delete from kullaniciadi where Ad='"+textBox1.Text+"'",baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı silindi");
            this.Hide();
            Form2 fm = new Form2();
            fm.Show();
            baglan.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
