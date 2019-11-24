using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganografi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Resim Dosyası |*.png*";
            if (d.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = d.FileName.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen istenenleri eksiksiz girin");
            }
            else
            {
                Bitmap img = new Bitmap(textBox1.Text);
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = img.Width;
                string mesaj = "";

                Color sonp = img.GetPixel(img.Width - 1, img.Height - 1);
                int muzunluk = sonp.B;

                for (int i = 0; i < img.Width; i++)
                {
                    progressBar1.Value += 1;
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);

                        if (i < 1 && j < muzunluk)
                        {
                            int deger = pixel.B;
                            char c = Convert.ToChar(deger);
                            string harf = System.Text.Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });

                            mesaj = mesaj + harf;
                        }
                    }
                }
                richTextBox1.Text = mesaj;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }
    }
}
