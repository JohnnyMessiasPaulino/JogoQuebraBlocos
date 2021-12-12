using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace JogoQuebraBlocosN2B2
{
    public partial class frNovoJogo : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public frNovoJogo()
        {
            InitializeComponent();
            ObtemDificuldade();
            ObtemMaiorRecorde();
            TocaSom();
        }

        string dificuldade = File.ReadAllText("opcoes.txt", Encoding.UTF8);
        string dif;
        string som = File.ReadAllText("opcoesSom.txt", Encoding.UTF8);
        string maiorRecorde;

        bool moverDireita;
        bool moverEsquerda;
        bool trapaca = false;

        int velocidade; //Quantidade de pixels por ciclo do movimento do Jogador
        int chances; 
        int movimentoBolaX; //Quantidade de pixels para mover na horizontal
        int movimentoBolaY; //Quantidade de pixels para mover na vertical
        int pontuacao = 0;
        int ptosDificuldade;
        int numBlocosRestantes = 30;

        public void ObtemDificuldade()
        {
            switch (dificuldade)
            {
                case "0":
                    velocidade = 10;
                    chances = 3;
                    movimentoBolaX = 7;
                    movimentoBolaY = 7;
                    btnJogador.Width = 200;
                    ptosDificuldade = 1;
                    dif = "Facil";

                    break;

                case "1":
                    velocidade = 10;
                    chances = 2;
                    movimentoBolaX = 10;
                    movimentoBolaY = 10;
                    btnJogador.Width = 150;
                    ptosDificuldade = 2;
                    dif = "Normal";

                    break;
                case "2":
                    velocidade = 10;
                    chances = 1;
                    movimentoBolaX = 12;
                    movimentoBolaY = 12;
                    btnJogador.Width = 100;
                    ptosDificuldade = 3;
                    dif = "Dificil";

                    break;

                case "3":
                    velocidade = 16;
                    chances = 0;
                    movimentoBolaX = 16;
                    movimentoBolaY = 16;
                    btnJogador.Width = 75;
                    ptosDificuldade = 4;
                    dif = "Impossivel";

                    break;

            }



        }

        private void TocaSom()
        {
            if(som == "T")
            {
                if(dificuldade == "0")
                {
                    player.URL = "Fácil.mp3";
                    player.settings.setMode("loop", true);
                }
                else if (dificuldade == "1")
                {
                    player.URL = "Normal.mp3";
                    player.settings.setMode("loop", true);
                }
                else if (dificuldade == "2")
                {
                    player.URL = "hard.mp3";
                    player.settings.setMode("loop", true);
                }
                else
                {
                    player.URL = "impossivel.mp3";
                    player.settings.setMode("loop", true);
                }
            }
        }

        private void SomQuebrou()
        {
            if (som == "T")
            {
                timerJogo.Stop();
                SoundPlayer quebrou = new SoundPlayer();
                quebrou.SoundLocation = "quebrou.wav";
                quebrou.Play();
                timerJogo.Start();
            }
        }

        private void SomRebateu()
        {
            if (som == "T")
            {
                timerJogo.Stop();
                SoundPlayer rebateu = new SoundPlayer();
                rebateu.SoundLocation = "rebateu.wav";
                rebateu.Play();
                timerJogo.Start();
            }
        }

        private string ObtemMaiorRecorde()
        {
            if (File.Exists("pontuacao.txt"))
            {
                string[] listaPontuacao = File.ReadAllLines("pontuacao.txt", Encoding.UTF8);

                int maior = -1;

                for (int i = 0; i < listaPontuacao.Length; i++)
                {
                    if (Convert.ToInt32(listaPontuacao[i]) > maior)
                        maior = Convert.ToInt32(listaPontuacao[i]);
                }

                maiorRecorde = Convert.ToString(maior);
            }
            return maiorRecorde;
        }

        private Random rnd = new Random();


        private void frNovoJogo_Load(object sender, EventArgs e)
        {

        }

        private void ReiniciaJogo()
        {
            timerJogo.Stop();
            chances--;
            moverDireita = false;
            moverEsquerda = false;
            MessageBox.Show($" Errou! \n Voce tem mais {chances} chances ");
            pbBola.Location = new Point(300, 500);
            if (movimentoBolaY > 0)
                movimentoBolaY = -movimentoBolaY;

            timerJogo.Start();
        }


        /// <summary>
        /// Este método é acionado cada vez que o Timer completa um ciclo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerJogo_Tick(object sender, EventArgs e)
        {
            // Define o tempo do ciclo do Timer
            timerJogo.Interval = 12;

            timerJogo.Start();

            // Mover a bola horizontalmente a cada ciclo do Timer
            pbBola.Left += movimentoBolaX;

            // Mover a bola verticalmente a cada ciclo do Timer
            pbBola.Top += movimentoBolaY;

            // Atualizar a pontuação a cada ciclo do Timer
            lbPontos.Text = Convert.ToString(pontuacao);

            // Atualizar o numero de vidas a cada ciclo do Timer
            lbChances.Text = Convert.ToString(chances);

            // Mostra a dificuldade atual
            lbDificuldade.Text = dif;

            // Mostra o maior recorde registrado
            lbRecorde.Text = maiorRecorde;

            //lbBlocosRest.Text = Convert.ToString(numBlocosRestantes);

            // Se moverEsquerda for True, a posicao do jogador sera -10 pixels a cada ciclo do Timer
            // Fazendo o bloco se mover para esquerda
            if (moverEsquerda)
            {
                btnJogador.Left -= velocidade;
            }

            // Se moverDireita for True, a posicao do jogador sera +10 pixels a cada ciclo do Timer
            // Fazendo o bloco se mover para direita
            if (moverDireita)
            {
                btnJogador.Left += velocidade;
            }

            // Verifica a cada ciclo do Timer, se o bloco atingiu os limites da tela
            // se sim, moverEsquerda ou moverDireita vira false, parando o bloco
            if (btnJogador.Left < 0)
            {
                moverEsquerda = false;
            }
            else if (btnJogador.Left + btnJogador.Width > 920)
            {
                moverDireita = false;
            }

            // Este if verifica a posição da bola em relação aos limites horizontais da tela
            // Caso a bola atinja algum limite horizontal, o movimento da bola na horizontal é invertido
            if (pbBola.Left + pbBola.Width > ClientSize.Width || pbBola.Left < 0)
            {
                movimentoBolaX = -movimentoBolaX;
                SomRebateu();
            }

            // Este if verifica a posição da bola em relação ao limite superior da tela
            // Caso a bola atinja o limite superior, o movimento da bola na horizontal é invertido
            // Tambem verifica se a bola encosta no bloco do jogador, se sim, o movimento vertical é invertido
            if (pbBola.Top < 0 || pbBola.Bounds.IntersectsWith(btnJogador.Bounds))
            {
                movimentoBolaY = -movimentoBolaY;
            }

            // Este if verifica se a bola passou do limite inferior, se sim, Perdeu uma chance
            if (pbBola.Top + pbBola.Height > ClientSize.Height)
            {

                if (chances <= 0)
                {
                    timerJogo.Stop();
                    GameOver();
                    Close();
                }
                else
                {
                    ReiniciaJogo();
                }
            }


            foreach (Control x in this.Controls)
            {
                //Foreach para detectar todos os pictureBox com Tag = bloco
                //Cada bloco sera salvo na variavel x


                if (x is PictureBox && x.Tag == "bloco")
                {
                    
                    // Este if detecta o contato entre a bola e os blocos superiores
                    // Se a bola encostar no bloco:
                    // O bloco é removido, a pontuação aumenta, e o movimento vertical é invertido

                    if (pbBola.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        SomQuebrou();
                        movimentoBolaY = -movimentoBolaY;
                        pontuacao = pontuacao + ptosDificuldade;
                        numBlocosRestantes--;
                    }
                }
            }

            //Ifs para encerrar o jogo caso o jogador destrua todos os blocos 
            // e atinja a pontuação máxima conforme a dificuldade
            if (dificuldade == "0" && pontuacao >= 30)
            {
                timerJogo.Stop();
                player.controls.stop();
                GameOver();
                Close();
            }
            else if (dificuldade == "1" && pontuacao >= 60)
            {
                timerJogo.Stop();
                player.controls.stop();
                GameOver();
                Close();
            }
            else if (dificuldade == "2" && pontuacao >= 90)
            {
                timerJogo.Stop();
                player.controls.stop();
                GameOver();
                Close();
            }
            else if (dificuldade == "3" && pontuacao >= 120)
            {
                timerJogo.Stop();
                player.controls.stop();
                GameOver();
                Close();
            }
        }

        private void GameOver()
        {
            string dadosJogoAtual = pontuacao + Environment.NewLine + dif + Environment.NewLine + DateTime.Now.ToString();
            File.WriteAllText("DadosJogoAtual.txt", dadosJogoAtual, Encoding.UTF8);
            frGameOverCadastroPontuacao telaGameOver = new frGameOverCadastroPontuacao();
            player.controls.stop();
            telaGameOver.ShowDialog();
            Close();
        }

        /// <summary>
        /// Se o jogador fechar a janela, encerra o timer para parar o jogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fechoujogo(object sender, FormClosedEventArgs e)
        {
            timerJogo.Stop();
            player.controls.stop();
        }

        /// <summary>
        /// O método a seguir é acionado enquanto as teclas estão pressionadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teclapressionada(object sender, KeyEventArgs e)
        {
            // Enquanto a tecla das setas estiverem pressionadas, o bool de movimento sera true

            if (e.KeyCode == Keys.Left && btnJogador.Left > 0)
            {
                moverEsquerda = true;
            }

            if (e.KeyCode == Keys.Right && btnJogador.Left + btnJogador.Width < 900)
            {
                moverDireita = true;
            }

            //Truque Secreto
            if(e.KeyCode == Keys.Space && e.Shift)
            {
                chances++;
                trapaca = true;
            }
        }

        /// <summary>
        /// O método a seguir é acionado enquanto as teclas NÃO estão pressionadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teclanaopressionada(object sender, KeyEventArgs e)
        {
            /*Enquanto a tecla seta para direita não estiver pressionada, o bool moverDireita
             * sera false 
             */

            if (e.KeyCode == Keys.Right)
            {
                moverDireita = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                moverEsquerda = false;
            }
        }
    }
}
