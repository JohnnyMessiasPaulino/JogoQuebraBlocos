using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoQuebraBlocosN2B2
{
    public partial class frMemoria : Form
    {
        public frMemoria()
        {
            InitializeComponent();
        }

        bool clicado = false;
        PictureBox primeiroChute;
        Random rnd = new Random();
        Timer tempo = new Timer();
        int seg = 60;
        Timer timer = new Timer { Interval = 1000 };

        private PictureBox[] pictureBoxes
        {
            get
            {
                return Controls.OfType<PictureBox>().ToArray();
            }
        }

        private static IEnumerable<Image> images
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources.img1,
                    Properties.Resources.img2,
                    Properties.Resources.img3,
                    Properties.Resources.img4,
                    Properties.Resources.img5,
                    Properties.Resources.img6,
                    Properties.Resources.img7,
                    Properties.Resources.img8
                };
            }
        }

        private void IniciaTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                seg--;
                if (seg < 0)
                {
                    timer.Stop();
                    MessageBox.Show("Tempo Esgotado");
                    ResetaImages();
                }

                var sec = TimeSpan.FromSeconds(seg);
                lblSeg.Text = "00: " + seg.ToString();
            };
        }

        private void ResetaImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }

            EscondeImagens();
            RandomImagens();
            seg = 60;
            timer.Start();
        }

        private void EscondeImagens()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Image = Properties.Resources.question;
            }
        }

        private PictureBox EspacoVazio()
        {
            int num;

            do
            {
                num = rnd.Next(0, pictureBoxes.Count());
            } while (pictureBoxes[num].Tag != null);

            return pictureBoxes[num];
        }

        private void RandomImagens()
        {
            foreach (var image in images)
            {
                EspacoVazio().Tag = image;
                EspacoVazio().Tag = image;
            }
        }

        private void ClickTimer_TICK(object sender, EventArgs e)
        {
            EscondeImagens();

            clicado = true;
            tempo.Stop();
        }

        private void ClickImage(object sender, EventArgs e)
        {
            if (!clicado) return;

            var pic = (PictureBox)sender;

            if (primeiroChute == null)
            {
                primeiroChute = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }

            pic.Image = (Image)pic.Tag;

            if (pic.Image == primeiroChute.Image && pic != primeiroChute)
            {
                pic.Visible = primeiroChute.Visible = false;
                {
                    primeiroChute = pic;
                }
                EscondeImagens();
            }
            else
            {
                clicado = false;
                tempo.Start();
            }

            primeiroChute = null;
            if (pictureBoxes.Any(p => p.Visible)) return;
            timer.Stop();
            MessageBox.Show("Você ganhou, tente mais uma rodada");
            EscondeImagens();
        }

        private void btnJogo_Click(object sender, EventArgs e)
        {
            clicado = true;
            RandomImagens();
            EscondeImagens();
            IniciaTimer();
            timer.Interval = 1000;
            timer.Tick += ClickTimer_TICK;
            btnJogo.Enabled = false;
        }

        private void frMemoria_Load(object sender, EventArgs e)
        {

        }

        private void lblSeg_Click(object sender, EventArgs e)
        {

        }
    }
}
