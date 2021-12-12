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
    public partial class frTelaInicial : Form
    {
        public frTelaInicial()
        {
            InitializeComponent();
        }

        InfoOpcoes infoOpcoes = new InfoOpcoes();
        public string dificuldade;

        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            frNovoJogo telaNovoJogo = new frNovoJogo();
            telaNovoJogo.ShowDialog();
        }

        private void btnComoJogar_Click(object sender, EventArgs e)
        {
            frComoJogar telaComoJogar = new frComoJogar();
            telaComoJogar.ShowDialog();
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            frSobre telaSobre = new frSobre();
            telaSobre.ShowDialog();
        }

        private void btnHabTrap_Click(object sender, EventArgs e)
        {
            frMiniGames telaMiniGames = new frMiniGames();
            telaMiniGames.ShowDialog();
        }

        private void btnOpcoes_Click(object sender, EventArgs e)
        {
            frOpcoes telaOpcoes = new frOpcoes();
            telaOpcoes.ShowDialog();
        }

        private void btnListaRecordes_Click(object sender, EventArgs e)
        {
            frListaRecordes telaListaRecordes = new frListaRecordes();
            telaListaRecordes.ShowDialog();
        }

        private void frTelaInicial_Load(object sender, EventArgs e)
        {

        }
    }
}
