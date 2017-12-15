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
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=gz_proje;User Id=root;password=12345678");
        int i;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from kullaniciadi where Ad='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0) {
                label3.Visible = true;
                label3.Text = "sifre hatalı";
            }
            else
            {
                this.Hide();
                Form2 fm = new Form2();
                fm.Show();
            }
            

            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
    }
}
