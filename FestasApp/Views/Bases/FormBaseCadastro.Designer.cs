namespace FestasApp.Views
{
    partial class FormBaseCadastro
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
            tstpMenuTop = new ToolStrip();
            tstbtnFechar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tstbtnNovo = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tstbtnEditar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            tstbtnConsultar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tstbtnExcluir = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            pnlRodape = new Panel();
            pnlTitulo = new Panel();
            panel1 = new Panel();
            lblTitulo = new Label();
            pnlCabecalho = new Panel();
            pnlTopo = new Panel();
            pnlMeio = new Panel();
            tstpMenuTop.SuspendLayout();
            pnlTitulo.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            SuspendLayout();
            // 
            // tstpMenuTop
            // 
            tstpMenuTop.AutoSize = false;
            tstpMenuTop.BackColor = SystemColors.Control;
            tstpMenuTop.Font = new Font("Segoe UI", 10F);
            tstpMenuTop.Items.AddRange(new ToolStripItem[] { tstbtnFechar, toolStripSeparator1, tstbtnNovo, toolStripSeparator2, tstbtnEditar, toolStripSeparator4, tstbtnConsultar, toolStripSeparator3, tstbtnExcluir, toolStripSeparator5 });
            tstpMenuTop.Location = new Point(0, 0);
            tstpMenuTop.Name = "tstpMenuTop";
            tstpMenuTop.Size = new Size(958, 50);
            tstpMenuTop.TabIndex = 0;
            tstpMenuTop.Text = "toolStrip1";
            // 
            // tstbtnFechar
            // 
            tstbtnFechar.Image = Resources.fechar;
            tstbtnFechar.ImageTransparentColor = Color.Magenta;
            tstbtnFechar.Name = "tstbtnFechar";
            tstbtnFechar.Size = new Size(53, 47);
            tstbtnFechar.Text = "Fechar";
            tstbtnFechar.TextImageRelation = TextImageRelation.ImageAboveText;
            tstbtnFechar.Click += tstbtnFechar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 50);
            // 
            // tstbtnNovo
            // 
            tstbtnNovo.Image = Resources.add;
            tstbtnNovo.ImageTransparentColor = Color.Magenta;
            tstbtnNovo.Name = "tstbtnNovo";
            tstbtnNovo.Size = new Size(46, 47);
            tstbtnNovo.Text = "Novo";
            tstbtnNovo.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 50);
            // 
            // tstbtnEditar
            // 
            tstbtnEditar.Image = Resources.editar;
            tstbtnEditar.ImageTransparentColor = Color.Magenta;
            tstbtnEditar.Name = "tstbtnEditar";
            tstbtnEditar.Size = new Size(48, 47);
            tstbtnEditar.Text = "Editar";
            tstbtnEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 50);
            // 
            // tstbtnConsultar
            // 
            tstbtnConsultar.Image = Resources.folder_open;
            tstbtnConsultar.ImageTransparentColor = Color.Magenta;
            tstbtnConsultar.Name = "tstbtnConsultar";
            tstbtnConsultar.Size = new Size(72, 47);
            tstbtnConsultar.Text = "Consultar";
            tstbtnConsultar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 50);
            // 
            // tstbtnExcluir
            // 
            tstbtnExcluir.Image = Resources.fechar_close;
            tstbtnExcluir.ImageTransparentColor = Color.Magenta;
            tstbtnExcluir.Name = "tstbtnExcluir";
            tstbtnExcluir.Size = new Size(51, 47);
            tstbtnExcluir.Text = "Excluir";
            tstbtnExcluir.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 50);
            // 
            // pnlRodape
            // 
            pnlRodape.BackColor = SystemColors.Control;
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 458);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(958, 80);
            pnlRodape.TabIndex = 1;
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.FromArgb(37, 46, 59);
            pnlTitulo.Controls.Add(panel1);
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(958, 34);
            pnlTitulo.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGoldenrod;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(5, 34);
            panel1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(958, 34);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "C a d a s t r o  B a s e";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.BackColor = SystemColors.Control;
            pnlCabecalho.Controls.Add(pnlTopo);
            pnlCabecalho.Controls.Add(pnlTitulo);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 50);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(958, 80);
            pnlCabecalho.TabIndex = 4;
            // 
            // pnlTopo
            // 
            pnlTopo.Dock = DockStyle.Fill;
            pnlTopo.Location = new Point(0, 34);
            pnlTopo.Name = "pnlTopo";
            pnlTopo.Size = new Size(958, 46);
            pnlTopo.TabIndex = 2;
            // 
            // pnlMeio
            // 
            pnlMeio.Dock = DockStyle.Fill;
            pnlMeio.Location = new Point(0, 130);
            pnlMeio.Name = "pnlMeio";
            pnlMeio.Size = new Size(958, 328);
            pnlMeio.TabIndex = 5;
            // 
            // FormBaseCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 538);
            Controls.Add(pnlMeio);
            Controls.Add(pnlCabecalho);
            Controls.Add(tstpMenuTop);
            Controls.Add(pnlRodape);
            Font = new Font("Segoe UI", 10F);
            Name = "FormBaseCadastro";
            Text = "FormCadastro";
            tstpMenuTop.ResumeLayout(false);
            tstpMenuTop.PerformLayout();
            pnlTitulo.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public Panel pnlRodape;
        public Panel pnlTitulo;
        public Label lblTitulo;
        private Panel panel1;
        public ToolStrip tstpMenuTop;
        public ToolStripButton tstbtnNovo;
        public ToolStripButton tstbtnConsultar;
        public ToolStripButton tstbtnExcluir;
        public ToolStripButton tstbtnEditar;
        public ToolStripButton tstbtnFechar;
        public ToolStripSeparator toolStripSeparator1;
        public ToolStripSeparator toolStripSeparator2;
        public ToolStripSeparator toolStripSeparator4;
        public ToolStripSeparator toolStripSeparator3;
        public ToolStripSeparator toolStripSeparator5;
        public Panel pnlCabecalho;
        public Panel pnlTopo;
        public Panel pnlMeio;
    }
}