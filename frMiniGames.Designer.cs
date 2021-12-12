namespace JogoQuebraBlocosN2B2
{
    partial class frMiniGames
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frMiniGames));
            this.btnJogoVelha = new System.Windows.Forms.Button();
            this.btnPPT = new System.Windows.Forms.Button();
            this.btnJogoMemoria = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnJogoVelha
            // 
            this.btnJogoVelha.BackColor = System.Drawing.Color.Goldenrod;
            this.btnJogoVelha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogoVelha.Font = new System.Drawing.Font("MV Boli", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogoVelha.Location = new System.Drawing.Point(94, 325);
            this.btnJogoVelha.Name = "btnJogoVelha";
            this.btnJogoVelha.Size = new System.Drawing.Size(117, 47);
            this.btnJogoVelha.TabIndex = 3;
            this.btnJogoVelha.Text = "Jogo da Velha";
            this.btnJogoVelha.UseVisualStyleBackColor = false;
            this.btnJogoVelha.Click += new System.EventHandler(this.btnJogoVelha_Click);
            // 
            // btnPPT
            // 
            this.btnPPT.BackColor = System.Drawing.Color.Goldenrod;
            this.btnPPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPPT.Font = new System.Drawing.Font("MV Boli", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPPT.Location = new System.Drawing.Point(516, 325);
            this.btnPPT.Name = "btnPPT";
            this.btnPPT.Size = new System.Drawing.Size(117, 47);
            this.btnPPT.TabIndex = 5;
            this.btnPPT.Text = "Pedra Papel Tesoura";
            this.btnPPT.UseVisualStyleBackColor = false;
            this.btnPPT.Click += new System.EventHandler(this.btnPPT_Click);
            // 
            // btnJogoMemoria
            // 
            this.btnJogoMemoria.BackColor = System.Drawing.Color.Goldenrod;
            this.btnJogoMemoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogoMemoria.Font = new System.Drawing.Font("MV Boli", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogoMemoria.Location = new System.Drawing.Point(308, 325);
            this.btnJogoMemoria.Name = "btnJogoMemoria";
            this.btnJogoMemoria.Size = new System.Drawing.Size(117, 47);
            this.btnJogoMemoria.TabIndex = 4;
            this.btnJogoMemoria.Text = "Jogo da Memória";
            this.btnJogoMemoria.UseVisualStyleBackColor = false;
            this.btnJogoMemoria.Click += new System.EventHandler(this.btnJogoMemoria_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JogoQuebraBlocosN2B2.Properties.Resources._23981_catalogar_todos_os_jogos_eletronicos_696x0_1;
            this.pictureBox1.Location = new System.Drawing.Point(25, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(696, 304);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frMiniGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(745, 384);
            this.Controls.Add(this.btnPPT);
            this.Controls.Add(this.btnJogoMemoria);
            this.Controls.Add(this.btnJogoVelha);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frMiniGames";
            this.Text = "Mini Games";
            this.Load += new System.EventHandler(this.frMiniGames_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnJogoVelha;
        private System.Windows.Forms.Button btnPPT;
        private System.Windows.Forms.Button btnJogoMemoria;
    }
}