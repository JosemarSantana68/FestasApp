namespace FestasApp.ViewModels
{
    partial class FormBaseCRUD
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
            pnlTitulo = new Panel();
            tblTopoCRUD = new TableLayoutPanel();
            lblTitulo = new Label();
            lblOperacao = new Label();
            picLogoCrud = new PictureBox();
            pnlRodape = new Panel();
            toolStripCRUD = new ToolStrip();
            tstbtnCancel = new ToolStripButton();
            tstSeparadorCancelar = new ToolStripSeparator();
            tstbtnSalvar = new ToolStripButton();
            tstSeparadorSalvar = new ToolStripSeparator();
            pnlCentral = new Panel();
            pnlTitulo.SuspendLayout();
            tblTopoCRUD.SuspendLayout();
            ((ISupportInitialize)picLogoCrud).BeginInit();
            pnlRodape.SuspendLayout();
            toolStripCRUD.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.FromArgb(37, 46, 59);
            pnlTitulo.Controls.Add(tblTopoCRUD);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(3, 3);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(599, 64);
            pnlTitulo.TabIndex = 2;
            // 
            // tblTopoCRUD
            // 
            tblTopoCRUD.ColumnCount = 5;
            tblTopoCRUD.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblTopoCRUD.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tblTopoCRUD.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tblTopoCRUD.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblTopoCRUD.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblTopoCRUD.Controls.Add(lblTitulo, 2, 0);
            tblTopoCRUD.Controls.Add(lblOperacao, 3, 0);
            tblTopoCRUD.Controls.Add(picLogoCrud, 1, 0);
            tblTopoCRUD.Dock = DockStyle.Fill;
            tblTopoCRUD.Location = new Point(0, 0);
            tblTopoCRUD.Name = "tblTopoCRUD";
            tblTopoCRUD.RowCount = 1;
            tblTopoCRUD.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblTopoCRUD.Size = new Size(599, 64);
            tblTopoCRUD.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.ImageAlign = ContentAlignment.MiddleLeft;
            lblTitulo.Location = new Point(83, 3);
            lblTitulo.Margin = new Padding(3);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Padding = new Padding(20, 0, 0, 0);
            lblTitulo.Size = new Size(343, 58);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "C a d a s t r o  B a s e";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOperacao
            // 
            lblOperacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblOperacao.AutoSize = true;
            lblOperacao.ForeColor = Color.White;
            lblOperacao.Location = new Point(432, 3);
            lblOperacao.Margin = new Padding(3);
            lblOperacao.Name = "lblOperacao";
            lblOperacao.Size = new Size(143, 58);
            lblOperacao.TabIndex = 1;
            lblOperacao.Text = "O p e r a ç ã o";
            lblOperacao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLogoCrud
            // 
            picLogoCrud.Dock = DockStyle.Fill;
            picLogoCrud.Image = Resources.icono_cerrar;
            picLogoCrud.Location = new Point(30, 10);
            picLogoCrud.Margin = new Padding(10);
            picLogoCrud.Name = "picLogoCrud";
            picLogoCrud.Padding = new Padding(10);
            picLogoCrud.Size = new Size(40, 44);
            picLogoCrud.SizeMode = PictureBoxSizeMode.Zoom;
            picLogoCrud.TabIndex = 2;
            picLogoCrud.TabStop = false;
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(toolStripCRUD);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(3, 393);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(599, 32);
            pnlRodape.TabIndex = 3;
            // 
            // toolStripCRUD
            // 
            toolStripCRUD.AutoSize = false;
            toolStripCRUD.BackColor = Color.DarkGoldenrod;
            toolStripCRUD.Dock = DockStyle.Fill;
            toolStripCRUD.Items.AddRange(new ToolStripItem[] { tstbtnCancel, tstSeparadorCancelar, tstbtnSalvar, tstSeparadorSalvar });
            toolStripCRUD.Location = new Point(0, 0);
            toolStripCRUD.Name = "toolStripCRUD";
            toolStripCRUD.RightToLeft = RightToLeft.Yes;
            toolStripCRUD.Size = new Size(599, 32);
            toolStripCRUD.TabIndex = 0;
            toolStripCRUD.Text = "toolStrip1";
            // 
            // tstbtnCancel
            // 
            tstbtnCancel.Font = new Font("Segoe UI", 11F);
            tstbtnCancel.Image = Resources.fechar;
            tstbtnCancel.ImageTransparentColor = Color.Magenta;
            tstbtnCancel.Name = "tstbtnCancel";
            tstbtnCancel.Size = new Size(86, 29);
            tstbtnCancel.Text = "Cancelar";
            tstbtnCancel.TextImageRelation = TextImageRelation.TextBeforeImage;
            tstbtnCancel.Click += tstbtnCancel_Click;
            // 
            // tstSeparadorCancelar
            // 
            tstSeparadorCancelar.Name = "tstSeparadorCancelar";
            tstSeparadorCancelar.Size = new Size(6, 32);
            // 
            // tstbtnSalvar
            // 
            tstbtnSalvar.AutoSize = false;
            tstbtnSalvar.Font = new Font("Segoe UI", 11F);
            tstbtnSalvar.Image = Resources.check_mark;
            tstbtnSalvar.ImageTransparentColor = Color.Magenta;
            tstbtnSalvar.Name = "tstbtnSalvar";
            tstbtnSalvar.Size = new Size(86, 33);
            tstbtnSalvar.Text = "Salvar";
            tstbtnSalvar.TextImageRelation = TextImageRelation.TextBeforeImage;
            // 
            // tstSeparadorSalvar
            // 
            tstSeparadorSalvar.Name = "tstSeparadorSalvar";
            tstSeparadorSalvar.Size = new Size(6, 32);
            // 
            // pnlCentral
            // 
            pnlCentral.Dock = DockStyle.Fill;
            pnlCentral.Location = new Point(3, 67);
            pnlCentral.Name = "pnlCentral";
            pnlCentral.Size = new Size(599, 326);
            pnlCentral.TabIndex = 5;
            // 
            // FormBaseCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 428);
            Controls.Add(pnlCentral);
            Controls.Add(pnlRodape);
            Controls.Add(pnlTitulo);
            Font = new Font("Segoe UI", 10F);
            Name = "FormBaseCRUD";
            Padding = new Padding(3);
            Text = "FormBaseCRUD";
            pnlTitulo.ResumeLayout(false);
            tblTopoCRUD.ResumeLayout(false);
            tblTopoCRUD.PerformLayout();
            ((ISupportInitialize)picLogoCrud).EndInit();
            pnlRodape.ResumeLayout(false);
            toolStripCRUD.ResumeLayout(false);
            toolStripCRUD.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Panel pnlTitulo;
        public Panel pnlRodape;
        public ToolStrip toolStripCRUD;
        public ToolStripButton tstbtnSalvar;
        public Label lblOperacao;
        public Label lblTitulo;
        public ToolStripButton tstbtnCancel;
        public Panel pnlCentral;
        public ToolStripSeparator tstSeparadorCancelar;
        public ToolStripSeparator tstSeparadorSalvar;
        public PictureBox picLogoCrud;
        public TableLayoutPanel tblTopoCRUD;
    }
}