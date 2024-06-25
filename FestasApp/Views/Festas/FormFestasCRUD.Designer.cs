namespace FestasApp.Views.Festas
{
    partial class FormFestasCRUD
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
            pnlTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(895, 64);
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(3, 506);
            pnlRodape.Size = new Size(895, 36);
            // 
            // lblOperacao
            // 
            lblOperacao.Location = new Point(756, 0);
            // 
            // lblTitulo
            // 
            lblTitulo.Image = Resources.festa_balloons_36;
            // 
            // pnlCentral
            // 
            pnlCentral.Size = new Size(895, 439);
            // 
            // FormFestasCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 545);
            Name = "FormFestasCRUD";
            Text = "FormFestasCRUD";
            pnlTitulo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}