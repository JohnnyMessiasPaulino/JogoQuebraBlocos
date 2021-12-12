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
    public partial class frPedraPapelTesoura : Form
    {
        public frPedraPapelTesoura()
        {
            InitializeComponent();
        }

        int suaPontuacao, pcPontuacao = 0;

        private void pbTesoura_Click(object sender, EventArgs e)
        {
            Rodada(1);
        }

        private void pbPapel_Click(object sender, EventArgs e)
        {
            Rodada(2);
        }

        private void pbPedra_Click(object sender, EventArgs e)
        {
            Rodada(3);
        }

        private void Rodada(int seuNum)
        {
            Random rnd = new Random();
            int pcNum = rnd.Next(1, 4);

            SelecionaImagem(pbVoce, seuNum);
            SelecionaImagem(pbPC, pcNum);

            if (seuNum == pcNum)
            {
                lblResultado.Text = "Empate!";
                return;
            }

            switch (seuNum)
            {
                case 1:
                    if (pcNum == 2)
                        AtualizaPontuacao(true);
                    else
                        AtualizaPontuacao(false);
                    break;

                case 2:
                    if (pcNum == 3)
                        AtualizaPontuacao(true);
                    else
                        AtualizaPontuacao(false);
                    break;

                case 3:
                    if (pcNum == 1)
                        AtualizaPontuacao(true);
                    else
                        AtualizaPontuacao(false);
                    break;
            }
        }

        private void AtualizaPontuacao(bool JogadorVenceu)
        {
            if (JogadorVenceu)
            {
                suaPontuacao++;
                lblResultado.Text = "Vitória";
                lblJogadorPontucao.Text = suaPontuacao.ToString();
            }

            else
            {
                pcPontuacao++;
                lblResultado.Text = "Derrota!";
                lblPcPontuacao.Text = pcPontuacao.ToString();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pbPC_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pbVoce_Click(object sender, EventArgs e)
        {

        }

        private void lblJogadorPontucao_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblPcPontuacao_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frPedraPapelTesoura_Load(object sender, EventArgs e)
        {

        }

        private void SelecionaImagem(PictureBox pb, int img)
        {
            if (img == 1)
                pb.Image = global::JogoQuebraBlocosN2B2.Properties.Resources.Tesoura;
            if (img == 2)
                pb.Image = global::JogoQuebraBlocosN2B2.Properties.Resources.Papel;
            if (img == 3)
                pb.Image = global::JogoQuebraBlocosN2B2.Properties.Resources.Pedra;
        }
    }
}

