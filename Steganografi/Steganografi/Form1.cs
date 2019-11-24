using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace Steganografi
{
    public partial class Form1 : Form
    {
        public Form1()
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
            OpenFileDialog d1 = new OpenFileDialog();
            d1.Filter = "Yazı Dosyası |*.txt*";
            if (d1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = d1.FileName.ToString();
            }
            StreamReader str = new StreamReader(textBox2.Text);
            richTextBox1.Text = str.ReadLine();
            str.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen istenenleri eksiksiz girin");
            }
            else { 
            Bitmap img = new Bitmap(textBox1.Text);
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = img.Width;
            for (int i = 0; i < img.Width; i++)
            {
                progressBar1.Value += 1;
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    if (i < 1 && j < richTextBox1.TextLength)
                    {
                        Console.WriteLine("R = [" + i + "][" + j + "] =" + pixel.R);
                        Console.WriteLine("G = [" + i + "][" + j + "] =" + pixel.G);
                        Console.WriteLine("B = [" + i + "][" + j + "] =" + pixel.B);

                        char harf = Convert.ToChar(richTextBox1.Text.Substring(j, 1));
                        int deger = Convert.ToInt32(harf);
                        Console.WriteLine("harf :" + harf + "deger :" + deger);

                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, deger));

                    }
                    if (i == img.Width - 1 && j == img.Height - 1)
                    {
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, richTextBox1.TextLength));
                    }

                }
            }
            SaveFileDialog kayit = new SaveFileDialog();
            kayit.Filter = "Resim Dosyası |*.png*";
            if (kayit.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = kayit.FileName.ToString();
                img.Save(textBox1.Text);

            }
        } }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
    }

