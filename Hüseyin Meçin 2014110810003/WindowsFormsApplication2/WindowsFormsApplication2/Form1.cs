using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resim Dosyaları|" + ".bmp;.jpg;*.gif;*.wmf;*.tif;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = null;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap gri = GriYap(image);

            pictureBox2.Image = gri;
        }

        private Bitmap GriYap(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;

                    Color renk;

                    renk = Color.FromArgb(deger, deger, deger);

                    bmp.SetPixel(j, i, renk);

                }
            }


            return bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap gri = GriYap2(image);

            pictureBox2.Image = gri;

            // G=(R*0.2125)+(G*0.7154)+(B*0.072) 

        }
        private Bitmap GriYap2(Bitmap bmp)
        {
            Bitmap greyscale = new Bitmap(bmp.Width, bmp.Height);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int grey = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap gri = GriYap3(image);

            pictureBox2.Image = gri;

            // G=(R*0.2125)+(G*0.7154)+(B*0.072) 
        }
        private Bitmap GriYap3(Bitmap bmp)
        {
            Bitmap greyscale = new Bitmap(bmp.Width, bmp.Height);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);

                    int grey = (int)(pixelColor.R * 0.2125 + pixelColor.G * 0.7154 + pixelColor.B * 0.072);
                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap gri = GriYap4(image);

            pictureBox2.Image = gri;
        }
        private Bitmap GriYap4(Bitmap bmp)
        {
            Bitmap greyscale = new Bitmap(bmp.Width, bmp.Height);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int a = 0;
                    if (pixelColor.R > pixelColor.G & pixelColor.R > pixelColor.B)
                        a = pixelColor.R;
                    if (pixelColor.G > pixelColor.R & pixelColor.G > pixelColor.B)
                        a = pixelColor.G;
                    if (pixelColor.B > pixelColor.R & pixelColor.B > pixelColor.G)
                        a = pixelColor.B;
                    int b = 0;
                    if (pixelColor.R < pixelColor.G & pixelColor.R < pixelColor.B)
                        b = pixelColor.R;
                    if (pixelColor.G < pixelColor.R & pixelColor.G < pixelColor.B)
                        b = pixelColor.G;
                    if (pixelColor.B < pixelColor.R & pixelColor.B < pixelColor.G)
                        b = pixelColor.B;

                    int grey = (int)((a + b) / 2);

                    greyscale.SetPixel(x, y, Color.FromArgb(pixelColor.A, grey, grey, grey));
                }
            }
            return greyscale;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap gri = GriYap5(image);

            pictureBox2.Image = gri;
        }
        private Bitmap GriYap5(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = (bmp.GetPixel(j, i).R | bmp.GetPixel(j, i).G | bmp.GetPixel(j, i).B);

                    Color renk;

                    renk = Color.FromArgb(deger, deger, deger);

                    bmp.SetPixel(j, i, renk);

                }
            }


            return bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(pictureBox2.Image);
            string kayit_adresi = @"C:\Users\Huseyin\Desktop\Gri Tonlama.png";
            bit.Save(kayit_adresi);
        }
    }
}

