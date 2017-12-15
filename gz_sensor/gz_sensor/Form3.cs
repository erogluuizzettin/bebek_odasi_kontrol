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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        MySqlConnection baglan = new MySqlConnection("Server=localhost;Database=gz_proje;uid=root;Password=12345678;");
        MySqlDataReader dr;
        MySqlCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand cmd = new MySqlCommand("Insert into kullaniciadi(Ad,Sifre) Values ('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ekleme basarılı");
            
            this.Hide();
            Form2 fm = new Form2();
            fm.Show();




        }
    }
}
