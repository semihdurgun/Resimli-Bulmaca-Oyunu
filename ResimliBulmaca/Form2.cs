using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ResimliBulmaca          
{
    public partial class Form2 : Form
    {
        PictureBox first;
        private bool tiklama = true;
        int kalan = 20;
        Timer tSure = new Timer();
        Timer tSectirme = new Timer();
        public Form2()
        {
            Image myimage = new Bitmap(@"myImage.jpg");
            this.BackgroundImage = myimage;
            InitializeComponent();
            tSure.Interval = 1000;
            tSure.Tick += TSure_Tick;
            tSectirme.Interval = 1000;
            tSectirme.Tick += TSectirme_Tick;
        }
        private void TSure_Tick(object sender, EventArgs e)
        {
            tiklama = false;
            int sayac = Convert.ToInt32(label4.Text);
            sayac--;
            label4.Text = sayac.ToString();
            if(sayac == 0)
            {
                ResimleriGizle();
                tiklama = true;
                tSure.Stop();
                label4.Hide();
                label9.Hide();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            YenidenBaslat();
        }
        public void YenidenBaslat()
        {
            kalanKart.Text = kalan.ToString();
            label4.Text = "5";
            oyuncuSırası.Text = OyuncuSirasi.ToString();
            karistir();
            ResimleriGöster();
            tSure.Start();
        }
        int OyuncuSirasi = 1;
        public void OyuncuSirasiBelirleme()
        {
            if (OyuncuSirasi % 2 == 0)
            {
                oyuncuSırası.Text = "2";
            }
            if (OyuncuSirasi % 2 != 0)
            {
                oyuncuSırası.Text = "1";
            }
        }
        void puanlamasistemi()
        {
            int Oyuncubirskor = Convert.ToInt32(label5.Text);
            int Oyuncuikiskor = Convert.ToInt32(label6.Text);

            if (oyuncuSırası.Text == "1")
            {
                label5.Text = (Oyuncubirskor + 10).ToString();
            }
            if (oyuncuSırası.Text == "2")
            {
                label6.Text = (Oyuncuikiskor + 10).ToString();
            }
            if(label5.Text == "100" && label6.Text == "100")
            {
                MessageBox.Show("Berabere.Yeniden Başlamak İçin Tıklayınız..", "Oyun bitti");
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            if (label5.Text == "110")
            {
                MessageBox.Show("Tebrikler Oyuncu Bir Oyunu Kazandı, Yeniden Başlamak İçin Tıklayınız.","Oyun Bitti");
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            if (label6.Text == "110")
            {
                MessageBox.Show("Tebrikler Oyuncu İki Oyunu Kazandı, Yeniden Başlamak İçin Tıklayınız.","Oyun Bitti");
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
        }
        void ResimleriGizle()
        {
            PictureBox[] dizi = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8,
                                     pictureBox9, pictureBox10, pictureBox11,pictureBox12,pictureBox13,pictureBox14,pictureBox15,pictureBox16,
                                     pictureBox17,pictureBox18,pictureBox19,pictureBox20,pictureBox21,pictureBox22,pictureBox23,pictureBox24,
                                     pictureBox25,pictureBox26,pictureBox27,pictureBox28,pictureBox29,pictureBox30,pictureBox31,pictureBox32,
                                     pictureBox33,pictureBox34,pictureBox35,pictureBox36,pictureBox37,pictureBox38,pictureBox39,pictureBox40 };
            foreach (var i in dizi)
            {
                i.Image = ımageList1.Images[0];
            }
        }
        void ResimleriGöster()
        {
            PictureBox[] dizi = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8,
                                     pictureBox9, pictureBox10, pictureBox11,pictureBox12,pictureBox13,pictureBox14,pictureBox15,pictureBox16,
                                     pictureBox17,pictureBox18,pictureBox19,pictureBox20,pictureBox21,pictureBox22,pictureBox23,pictureBox24,
                                     pictureBox25,pictureBox26,pictureBox27,pictureBox28,pictureBox29,pictureBox30,pictureBox31,pictureBox32,
                                     pictureBox33,pictureBox34,pictureBox35,pictureBox36,pictureBox37,pictureBox38,pictureBox39,pictureBox40 };
            foreach (var i in dizi)
            {
                i.Image = ımageList1.Images[(int)i.Tag];
            }
        }
        void karistir()
        {
            PictureBox[] dizi = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8,
                                     pictureBox9, pictureBox10, pictureBox11,pictureBox12,pictureBox13,pictureBox14,pictureBox15,pictureBox16,
                                     pictureBox17,pictureBox18,pictureBox19,pictureBox20,pictureBox21,pictureBox22,pictureBox23,pictureBox24,
                                     pictureBox25,pictureBox26,pictureBox27,pictureBox28,pictureBox29,pictureBox30,pictureBox31,pictureBox32,
                                     pictureBox33,pictureBox34,pictureBox35,pictureBox36,pictureBox37,pictureBox38,pictureBox39,pictureBox40 };
            ArrayList tagler = new ArrayList();
            for (int i = 0; i < (ımageList1.Images.Count - 2)* 2; i++)
            {
                tagler.Add((i % 20) + 1);
            }
            Random rnd = new Random();

            foreach (var i in dizi)
            {
                int r = rnd.Next(tagler.Count);
                i.Tag = tagler[r];
                tagler.RemoveAt(r);
            }
        }
        private void TSectirme_Tick(object sender, EventArgs e)
        {
            int sayac = Convert.ToInt32(lsecimSuresi.Text);
            sayac--;
            lsecimSuresi.Text = sayac.ToString();
            if (sayac == 0)
            {
                lsecimSuresi.Text = "5";
                OyuncuSirasiBelirleme();
                ResimleriGizle();
                tSectirme.Stop();
                if (first != null)
                {
                    if (pic.Name == first.Name)
                    {
                        OyuncuSirasi = OyuncuSirasi + 1;
                        OyuncuSirasiBelirleme();
                    }
                }
                tiklama = true;
                first = null;
            }
        }
        PictureBox pic = new PictureBox();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pic = sender as PictureBox;
            
            if (!tiklama) return;
            if(first == null)
            {
                first = pic;
                pic.Image = ımageList1.Images[(int)pic.Tag];
                lsecimSuresi.Text = "5";
                tSectirme.Start();
                return;
            }
            pic.Image = ımageList1.Images[(int)pic.Tag];
            if (pic.Name == first.Name)
            {
                MessageBox.Show("Aynı resime tıkladınız. Birdahakine", "Uyarı");
                OyuncuSirasi = OyuncuSirasi + 1;
                tiklama = false;
            }
            else if ((int)pic.Tag == (int)first.Tag && pic.Name != first.Name)
            {
                pic.Visible = first.Visible = false;
                lsecimSuresi.Text = "1";
                kalanKart.Text = (--kalan).ToString();
                puanlamasistemi();
                tiklama = false;
            }            
            else
            {
                OyuncuSirasi = OyuncuSirasi + 1;
                tiklama = false;
                tSectirme.Start();
            }
            first = null;
        }
    }
}
