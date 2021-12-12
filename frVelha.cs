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
    public partial class frVelha : Form
    {
        public frVelha()
        {
            InitializeComponent();
        }

        int Xpontos = 0, Opontos = 0, empates = 0, rodadas = 0;
        bool turno = true, fim_do_jogo = false;

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            btn.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            rodadas = 0;
            fim_do_jogo = false;
            for (int i = 0; i < 9; i++)
            {
                valor[i] = "";
            }
        }

        string[] valor = new string[9];

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frVelha_Load(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "" && fim_do_jogo == false)
            {
                if (turno)
                {
                    btn.Text = "X";
                    valor[btn.TabIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    valor[btn.TabIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(2);
                }
            }
        }

        void Ganhou(int vencedor)
        {
            fim_do_jogo = true;

            if (vencedor == 1)
            {
                Xpontos++;
                txtXpontos.Text = Xpontos.ToString();
                MessageBox.Show("O jogador X ganhou");
            }
            else
            {
                Opontos++;
                txtOpontos.Text = Opontos.ToString();
                MessageBox.Show("O jogador O ganhou");
            }
        }

        void Checagem(int checaJogador)
        {
            string suporte = "";

            if (checaJogador == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }

            //checagem horizontal
            for (int horizontal = 0; horizontal < 9; horizontal += 3)
            {
                if (suporte == valor[horizontal])
                {
                    if (valor[horizontal] == valor[horizontal + 1] && valor[horizontal] == valor[horizontal + 2])
                    {
                        Ganhou(checaJogador);
                        return;
                    }
                }
            }

            //checagem vertical
            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == valor[vertical])
                {
                    if (valor[vertical] == valor[vertical + 3] && valor[vertical] == valor[vertical + 6])
                    {
                        Ganhou(checaJogador);
                        return;
                    }
                }
            }

            if (valor[0] == suporte)
            {
                if (valor[0] == valor[4] && valor[0] == valor[8])
                {
                    Ganhou(checaJogador);
                    return;
                }
            }

            if (valor[2] == suporte)
            {
                if (valor[2] == valor[4] && valor[2] == valor[6])
                {
                    Ganhou(checaJogador);
                    return;
                }
            }

            if (rodadas == 9 && fim_do_jogo == false)
            {
                empates++;
                txtEmpates.Text = empates.ToString();
                MessageBox.Show("EMPATE!");
                fim_do_jogo = true;
                return;
            }
        }
    }
}

