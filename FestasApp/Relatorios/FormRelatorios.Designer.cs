namespace FestasApp.Views.Relatorios
{
    partial class FormRelatorios
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
            spltRelatorios = new SplitContainer();
            trvRelatorios = new TreeView();
            pnlVisualizador = new Panel();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            pnlTitulo.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlMeio.SuspendLayout();
            ((ISupportInitialize)spltRelatorios).BeginInit();
            spltRelatorios.Panel1.SuspendLayout();
            spltRelatorios.Panel2.SuspendLayout();
            spltRelatorios.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(0, 485);
            pnlRodape.Size = new Size(951, 80);
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(951, 34);
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(951, 34);
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Size = new Size(951, 80);
            // 
            // pnlTopo
            // 
            pnlTopo.Size = new Size(951, 46);
            // 
            // pnlMeio
            // 
            pnlMeio.Controls.Add(spltRelatorios);
            pnlMeio.Size = new Size(951, 355);
            // 
            // spltRelatorios
            // 
            spltRelatorios.Dock = DockStyle.Fill;
            spltRelatorios.Location = new Point(0, 0);
            spltRelatorios.Name = "spltRelatorios";
            // 
            // spltRelatorios.Panel1
            // 
            spltRelatorios.Panel1.Controls.Add(trvRelatorios);
            // 
            // spltRelatorios.Panel2
            // 
            spltRelatorios.Panel2.Controls.Add(pnlVisualizador);
            spltRelatorios.Size = new Size(951, 355);
            spltRelatorios.SplitterDistance = 217;
            spltRelatorios.TabIndex = 0;
            // 
            // trvRelatorios
            // 
            trvRelatorios.Cursor = Cursors.Hand;
            trvRelatorios.Location = new Point(93, 6);
            trvRelatorios.Name = "trvRelatorios";
            trvRelatorios.Size = new Size(111, 148);
            trvRelatorios.TabIndex = 0;
            // 
            // pnlVisualizador
            // 
            pnlVisualizador.Location = new Point(0, 0);
            pnlVisualizador.Name = "pnlVisualizador";
            pnlVisualizador.Size = new Size(244, 154);
            pnlVisualizador.TabIndex = 0;
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // FormRelatorios
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 565);
            Name = "FormRelatorios";
            Text = "FormRelatorios";
            pnlTitulo.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlMeio.ResumeLayout(false);
            spltRelatorios.Panel1.ResumeLayout(false);
            spltRelatorios.Panel2.ResumeLayout(false);
            ((ISupportInitialize)spltRelatorios).EndInit();
            spltRelatorios.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer spltRelatorios;
        private TreeView trvRelatorios;
        private Panel pnlVisualizador;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}