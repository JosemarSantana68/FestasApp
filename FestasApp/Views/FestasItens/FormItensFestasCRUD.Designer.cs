namespace FestasApp.Views.TabelasAuxiliares
{
    partial class FormItensFestasCRUD
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
            ((ISupportInitialize)picLogoCrud).BeginInit();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(752, 64);
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(3, 362);
            pnlRodape.Size = new Size(752, 32);
            // 
            // lblOperacao
            // 
            lblOperacao.Location = new Point(539, 3);
            lblOperacao.Size = new Size(189, 58);
            lblOperacao.Text = "";
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(450, 58);
            lblTitulo.Text = "C a d a s t r o  A u x i l i a r e s";
            // 
            // pnlCentral
            // 
            pnlCentral.Size = new Size(752, 295);
            // 
            // picLogoCrud
            // 
            picLogoCrud.Image = Resources.add;
            // 
            // FormAuxilaresCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 397);
            Name = "FormAuxilaresCRUD";
            Text = "FormBaseAuxilares";
            ((ISupportInitialize)picLogoCrud).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}