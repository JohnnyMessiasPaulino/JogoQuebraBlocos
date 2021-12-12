using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoQuebraBlocosN2B2
{
    public partial class frGameOverCadastroPontuacao : Form
    {
        public frGameOverCadastroPontuacao()
        {
            InitializeComponent();
            MostrarDadosListaRecord();
        }

        string[] dadosJogo = File.ReadAllLines("DadosJogoAtual.txt", Encoding.UTF8);

        private void btnGravarRecord_Click(object sender, EventArgs e)
        {
            string nome = " ", pontos, dificuldade, data, recorde;
            bool nomeValido = true;

            if (txtNomeRecord.Text.Length > 0)
                nome = txtNomeRecord.Text;
            else
            {
                MessageBox.Show("Digite um nome valido");
                nomeValido = false;
            }

            if (nomeValido)
            {
                dadosJogo = File.ReadAllLines("DadosJogoAtual.txt", Encoding.UTF8);
                pontos = dadosJogo[0];
                dificuldade = dadosJogo[1];
                data = dadosJogo[2];

                string conteudos = pontos + Environment.NewLine;
                File.AppendAllText("pontuacao.txt", conteudos);

                recorde = nome + "|" + pontos + "|" + dificuldade + "|" + data + Environment.NewLine;

                File.AppendAllText("recordes.txt", recorde, Encoding.UTF8);

                Close();
            }
        }
        private void MostrarDadosListaRecord()
        {

            if (File.Exists("recordes.txt"))
            {
                string[] dadosRecordes = new string[File.ReadAllLines("recordes.txt").Length];
                dadosRecordes = File.ReadAllLines("recordes.txt", Encoding.UTF8);

                if (OrdenaRecordes(out int[] pontos) != null)
                {
                    int n = 1;
                    int num = 0;
                    string[] ordenado = new string[pontos.Length];
                    string[] pontosRecordes = new string[pontos.Length];
                    int valor = 0;

                    //armazena a pontuação em um array
                    foreach (string linha in dadosRecordes)
                    {
                        int n1 = linha.IndexOf("|");
                        pontosRecordes[valor] = linha.Substring(n1, 3);
                        valor++;
                    }

                    int[] indices = new int[pontos.Length];
                    do
                    {
                        for (int i = 0; i < pontos.Length; i++)
                        {

                            if (pontosRecordes[i].IndexOf(pontos[num].ToString()) > -1)
                            {
                                //verifica se a string do array já foi utilizada
                                bool ver = true;
                                for (int v = 0; v < indices.Length; v++)
                                {
                                    if (i != 0)
                                    {
                                        if (indices[v] == i)
                                        {
                                            ver = false;
                                            break;
                                        }
                                    }
                                }

                                //reorganiza o array com base na pontuação
                                if (ver == true)
                                {
                                    indices[num] = i;
                                    ordenado[num] = dadosRecordes[i];
                                    num++;
                                    break;
                                }
                            }
                        }
                    } while (ordenado[pontos.Length - 1] == null);

                    for (int i2 = 0; i2 < pontos.Length; i2++)
                    {
                        string[] infAtual = ordenado[i2].Split('|');
                        lbNomes.Items.Add(infAtual[0]);
                        lbPontos.Items.Add(infAtual[1]);
                        lbDificuldades.Items.Add(infAtual[2]);
                        lbDatas.Items.Add(infAtual[3]);
                        lbPosicao.Items.Add(n++);
                    }
                }
            }
            else
            {
                File.WriteAllText("recordes.txt", "", Encoding.UTF8);
            }

            string pontosJogo = dadosJogo[0];
            string dif = dadosJogo[1];

            lbPtosJogoAtual.Text = pontosJogo;
            lbDifJogoAtual.Text = dif;

        }

        private int[] OrdenaRecordes(out int[] pontos)
        {
            if (File.Exists("pontuacao.txt"))
            {
                string[] arr = File.ReadAllLines("pontuacao.txt");
                pontos = Array.ConvertAll(arr, int.Parse);

                Array.Sort(pontos);
                Array.Reverse(pontos);
                return pontos;
            }
            else
            {
                File.WriteAllText("pontuacao.txt", "");
                return pontos = null;
            }
        }

        private void frGameOverCadastroPontuacao_Load(object sender, EventArgs e)
        {

        }
    }
}
