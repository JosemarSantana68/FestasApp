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
            lblOperacao = new Label();
            lblTitulo = new Label();
            pnlRodape = new Panel();
            toolStripCRUD = new ToolStrip();
            tstbtnCancel = new ToolStripButton();
            tstSeparadorCancelar = new ToolStripSeparator();
            tstbtnSalvar = new ToolStripButton();
            tstSeparadorSalvar = new ToolStripSeparator();
            pnlCentral = new Panel();
            pnlTitulo.SuspendLayout();
            pnlRodape.SuspendLayout();
            toolStripCRUD.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.FromArgb(37, 46, 59);
            pnlTitulo.Controls.Add(lblOperacao);
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(3, 3);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Padding = new Padding(30, 0, 0, 0);
            pnlTitulo.Size = new Size(599, 64);
            pnlTitulo.TabIndex = 2;
            // 
            // lblOperacao
            // 
            lblOperacao.Dock = DockStyle.Right;
            lblOperacao.ForeColor = Color.White;
            lblOperacao.Location = new Point(460, 0);
            lblOperacao.Name = "lblOperacao";
            lblOperacao.Padding = new Padding(0, 0, 18, 0);
            lblOperacao.Size = new Size(139, 64);
            lblOperacao.TabIndex = 1;
            lblOperacao.Text = "O p e r a ç ã o";
            lblOperacao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Left;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.ImageAlign = ContentAlignment.MiddleLeft;
            lblTitulo.Location = new Point(30, 0);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Padding = new Padding(30, 0, 0, 0);
            lblTitulo.Size = new Size(424, 64);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "C a d a s t r o  B a s e";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(toolStripCRUD);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(3, 389);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(599, 36);
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
            toolStripCRUD.Size = new Size(599, 36);
            toolStripCRUD.TabIndex = 0;
            toolStripCRUD.Text = "toolStrip1";
            // 
            // tstbtnCancel
            // 
            tstbtnCancel.Font = new Font("Segoe UI", 11F);
            tstbtnCancel.Image = Properties.Resources.Cancel_48;
            tstbtnCancel.ImageTransparentColor = Color.Magenta;
            tstbtnCancel.Name = "tstbtnCancel";
            tstbtnCancel.Size = new Size(86, 33);
            tstbtnCancel.Text = "Cancelar";
            tstbtnCancel.TextImageRelation = TextImageRelation.TextBeforeImage;
            tstbtnCancel.Click += tstbtnCancel_Click;
            // 
            // tstSeparadorCancelar
            // 
            tstSeparadorCancelar.Name = "tstSeparadorCancelar";
            tstSeparadorCancelar.Size = new Size(6, 36);
            // 
            // tstbtnSalvar
            // 
            tstbtnSalvar.AutoSize = false;
            tstbtnSalvar.Font = new Font("Segoe UI", 11F);
            tstbtnSalvar.Image = Properties.Resources.Check_Mark_48;
            tstbtnSalvar.ImageTransparentColor = Color.Magenta;
            tstbtnSalvar.Name = "tstbtnSalvar";
            tstbtnSalvar.Size = new Size(86, 33);
            tstbtnSalvar.Text = "Salvar";
            tstbtnSalvar.TextImageRelation = TextImageRelation.TextBeforeImage;
            // 
            // tstSeparadorSalvar
            // 
            tstSeparadorSalvar.Name = "tstSeparadorSalvar";
            tstSeparadorSalvar.Size = new Size(6, 36);
            // 
            // pnlCentral
            // 
            pnlCentral.Dock = DockStyle.Fill;
            pnlCentral.Location = new Point(3, 67);
            pnlCentral.Name = "pnlCentral";
            pnlCentral.Size = new Size(599, 322);
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
    }
}