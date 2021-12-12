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
    public partial class frMiniGames : Form
    {
        public frMiniGames()
        {
            InitializeComponent();
        }

        private void btnJogoVelha_Click(object sender, EventArgs e)
        {
            frVelha telaVelha = new frVelha();
            telaVelha.ShowDialog();
        }

        private void btnJogoMemoria_Click(object sender, EventArgs e)
        {
            frMemoria telaMemoria = new frMemoria();
            telaMemoria.ShowDialog();
        }

        private void btnPPT_Click(object sender, EventArgs e)
        {
            frPedraPapelTesoura telaPPT = new frPedraPapelTesoura();
            telaPPT.ShowDialog();
        }

        private void frMiniGames_Load(object sender, EventArgs e)
        {

        }
    }
}
