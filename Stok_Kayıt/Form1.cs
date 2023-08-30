using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Kayıt
{
    public partial class Form1 : Form
    {
        StokKayit StokKayit = new StokKayit();
        public Form1()
        {
            InitializeComponent();
        }
        public void SayiKontrol(TextBox tBox)
        {

            string gecici = tBox.Text;
            bool kontrol = true;
            for (int i = 0; i < gecici.Length; i++)
            {
                if (!Char.IsNumber(gecici[i]))
                {
                    kontrol = false;
                    break;
                }
            }
            if (!kontrol)
            {
                tBox.BackColor = Color.Red;
                MessageBox.Show("Lütfen sayı giriniz!");
                tBox.BackColor = Color.White;
                tBox.Text = "";


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Stok stok = new Stok();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && textBox4.Text != "" && textBox5.Text != "")
            {
                stok.StokKodu = Convert.ToInt32(textBox1.Text);
                stok.StokAdi = textBox2.Text;
                stok.MevcutStok = Convert.ToInt32(textBox3.Text);
                stok.birim = comboBox1.Text;
                stok.MinStok = Convert.ToInt32(textBox4.Text);
                stok.MaxStok = Convert.ToInt32(textBox5.Text);
                StokKayit.stok.Add(stok);
                StokKayit.SaveChanges();
                Goster();
            }
            else
            {
                MessageBox.Show("Önce alanları doldurunuz!");
            }

        }
        public void Goster()
        {
            var stoks = (from i in StokKayit.stok select i).ToList();
            listView1.Items.Clear();
            foreach (var stok in stoks)
            {
                listView1.Items.Add(stok.Id.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(stok.StokKodu.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(stok.StokAdi.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(stok.MevcutStok.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(stok.birim.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(stok.MinStok.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(stok.MaxStok.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Goster();
            comboBox1.SelectedIndex = 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            SayiKontrol(textBox3 as TextBox);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            SayiKontrol(textBox4 as TextBox);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            SayiKontrol(textBox5 as TextBox);
        }

        int kod = 0;


        private void button2_Click(object sender, EventArgs e)
        {
            if (kod == 0)
            {
                MessageBox.Show("Önce silinecek yeri seçin!");
            }
            else
            {
                var silinecek = StokKayit.stok.Find(kod);
                StokKayit.stok.Remove(silinecek);
                StokKayit.SaveChanges();
                Goster();
                kod = 0;



            }

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            kod = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            var secim = StokKayit.stok.Find(kod);
            textBox1.Text = secim.StokKodu.ToString();
            textBox2.Text = secim.StokAdi.ToString();
            textBox3.Text = secim.MevcutStok.ToString();
            comboBox1.Text = secim.birim.ToString();
            textBox4.Text = secim.MinStok.ToString();
            textBox5.Text = secim.MaxStok.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kod == 0)
            {
                MessageBox.Show("Önce düzeltilecek yeri seçiniz!");
            }
            else
            {
                var duzeltilecek = StokKayit.stok.Find(kod);

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && textBox4.Text != "" && textBox5.Text != "")
                {
                    duzeltilecek.StokKodu = Convert.ToInt32(textBox1.Text);
                    duzeltilecek.StokAdi = textBox2.Text;
                    duzeltilecek.MevcutStok = Convert.ToInt32(textBox3.Text);
                    duzeltilecek.birim = comboBox1.Text;
                    duzeltilecek.MinStok = Convert.ToInt32(textBox4.Text);
                    duzeltilecek.MaxStok = Convert.ToInt32(textBox5.Text);

                    StokKayit.SaveChanges();
                    Goster();
                }
                else
                {
                    MessageBox.Show("Önce alanları doldurunuz!");
                }
                kod = 0;
            }
        }
    }
}
