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
    public partial class frOpcoes : Form
    {
        public string som;

        public frOpcoes()
        {
            InitializeComponent();
        }
        string dificuldade;

        InfoOpcoes infoOpcoes = new InfoOpcoes();

        private void btnOpcoes_Click(object sender, EventArgs e)
        {
            if (rbLigaSom.Checked == true)
                som = "T";
            if (rbDesligaSom.Checked == true)
                som = "F";
            File.WriteAllText("Opcoes.txt", dificuldade, Encoding.UTF8);
            File.WriteAllText("OpcoesSom.txt", som, Encoding.UTF8);
            Close();
        }

        private void frOpcoes_Load(object sender, EventArgs e)
        {

        }

        private void rbDifFacil_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDifFacil.Checked)
            {
                infoOpcoes.dificuldade = "facil";
                dificuldade = "0";
            }

        }

        private void rbDifPadrao_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDifPadrao.Checked)
            {
                infoOpcoes.dificuldade = "padrao";
                dificuldade = "1";
            }
        }

        private void rbDifDificil_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDifDificil.Checked)
            {
                infoOpcoes.dificuldade = "dificil";
                dificuldade = "2";
            }
        }

        private void rbDifImpossivel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDifImpossivel.Checked)
            {
                infoOpcoes.dificuldade = "impossivel";
                dificuldade = "3";
            }
        }

        private void fechouopcoes(object sender, FormClosingEventArgs e)
        {
            if (rbLigaSom.Checked == true)
                som = "T";
            if (rbDesligaSom.Checked == true)
                som = "F";
            File.WriteAllText("Opcoes.txt", dificuldade, Encoding.UTF8);
            File.WriteAllText("OpcoesSom.txt", som, Encoding.UTF8);
            //Close();
        }
    }
}
