using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using MySql.Data.MySqlClient;
using System.IO;


namespace gz_sensor
{
    public partial class Form5 : Form
    {
        string[] portlar = SerialPort.GetPortNames(); //Port Numaralarını ports isimli diziye atıyoruz.
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            baglan.Open();
            foreach (string port in portlar)
            {
                comboBox1.Items.Add(port); // Port isimlerini combobox1'de gösteriyoruz.
                comboBox1.SelectedIndex = 0;
            }
            comboBox2.Items.Add("2400");  // Baudrate'leri kendimiz combobox2'ye giriyoruz.
            comboBox2.Items.Add("4800");
            comboBox2.Items.Add("9600");
            comboBox2.Items.Add("19200");
            comboBox2.Items.Add("115200");
            comboBox2.SelectedIndex = 2;

            label1.Text = "Bağlantı Kapalı";   //Bu esnada bağlantı yok. 
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;Database=gz_proje;uid=root;Password=12345678;");
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
            {
                {
                    // Form kapandığında Seri Port Kapatılmış Olacak.
                    if (serialPort1.IsOpen == true)
                    {
                        serialPort1.Close();
                    }
                }
            }

            private void timer1_Tick(object sender, EventArgs e)
            {
                try
                {
                string sonuc = serialPort1.ReadLine();
                string[] pot = sonuc.Split('*');//Serial.print kodu ile gelen analog veriyi alıyoruz,string formatında sonuc'a atıyoruz
                                                //label2.Text = sonuc + ""; //Labele yazdırıyoruz.

                textBox1.Text = pot[0];
                textBox2.Text = pot[1];

                MySqlCommand cmd = new MySqlCommand("Insert into ses(SesDegeri) Values ('" + textBox1.Text + "')", baglan);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("Insert into sicaklik(Sicaklik) Values ('" + textBox2.Text + "')", baglan);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter adtr = new MySqlDataAdapter("Select * from ses", baglan);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;

                MySqlDataAdapter adtr2 = new MySqlDataAdapter("Select * from sicaklik", baglan);
                adtr.Fill(tablo2);
                dataGridView2.DataSource = tablo2;

                serialPort1.DiscardInBuffer();

            }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // basarısız olursa hata verecek.
                    timer1.Stop();
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                timer1.Start(); //250 ms olarak ayarladım timer'ı.
                if (serialPort1.IsOpen == false)
                {
                    if (comboBox1.Text == "")
                        return;
                    serialPort1.PortName = comboBox1.Text;  // combobox1'e zaten port isimlerini aktarmıştık.
                    serialPort1.BaudRate = Convert.ToInt16(comboBox2.Text); //Seri Haberleşme baudrate'i combobox2 'de seçilene göre belirliyoruz.
                    try
                    {
                        serialPort1.Open(); //Haberleşme için port açılıyor
                        label1.ForeColor = Color.Green;
                        label1.Text = "Bağlantı Açık";


                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Hata:" + hata.Message);
                    }
                }
                else
                {
                    label1.Text = "Bağlantı kurulu !!!";
                }
            }

            private void button2_Click(object sender, EventArgs e)
            {
                //BAĞLANTIYI KES BUTONU
                timer1.Stop();
            serialPort1.DiscardInBuffer();
            if (serialPort1.IsOpen == true)
                {
                    serialPort1.Close();
                    label1.ForeColor = Color.Red;
                    label1.Text = "Bağlantı Kapalı";
                }
            }

            


        }
    }