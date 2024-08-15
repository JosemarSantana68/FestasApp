namespace FestasApp.Views.FestasContratos
{
    partial class FormContratosFestas
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
            lblNome = new Label();
            txtNome = new myTextBox();
            lblPath = new Label();
            txtPath = new myTextBox();
            btnPath = new Button();
            btnUpload = new Button();
            pnlCentral.SuspendLayout();
            ((ISupportInitialize)picLogoCrud).BeginInit();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(740, 64);
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(3, 247);
            pnlRodape.Size = new Size(740, 32);
            // 
            // lblOperacao
            // 
            lblOperacao.Location = new Point(531, 3);
            lblOperacao.Size = new Size(186, 58);
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(442, 58);
            // 
            // pnlCentral
            // 
            pnlCentral.Controls.Add(btnUpload);
            pnlCentral.Controls.Add(btnPath);
            pnlCentral.Controls.Add(txtPath);
            pnlCentral.Controls.Add(lblPath);
            pnlCentral.Controls.Add(txtNome);
            pnlCentral.Controls.Add(lblNome);
            pnlCentral.Size = new Size(740, 180);
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(35, 40);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(128, 19);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome do Contrato:";
            lblNome.TextAlign = ContentAlignment.TopRight;
            // 
            // txtNome
            // 
            txtNome.CharacterCasing = CharacterCasing.Upper;
            txtNome.ExibirMensagemAlerta = false;
            txtNome.Location = new Point(169, 37);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(212, 25);
            txtNome.TabIndex = 0;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(48, 76);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(115, 19);
            lblPath.TabIndex = 0;
            lblPath.Text = "Local do Arquivo:";
            lblPath.TextAlign = ContentAlignment.TopRight;
            // 
            // txtPath
            // 
            txtPath.CharacterCasing = CharacterCasing.Upper;
            txtPath.ExibirMensagemAlerta = false;
            txtPath.Location = new Point(169, 73);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(537, 25);
            txtPath.TabIndex = 1;
            // 
            // btnPath
            // 
            btnPath.FlatAppearance.BorderSize = 0;
            btnPath.FlatStyle = FlatStyle.Flat;
            btnPath.Image = Resources.folder_open;
            btnPath.Location = new Point(169, 104);
            btnPath.Name = "btnPath";
            btnPath.Size = new Size(75, 52);
            btnPath.TabIndex = 2;
            btnPath.UseVisualStyleBackColor = true;
            btnPath.Click += btnPath_Click;
            // 
            // btnUpload
            // 
            btnUpload.FlatAppearance.BorderSize = 0;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Image = Resources.folder_open;
            btnUpload.Location = new Point(250, 104);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(75, 52);
            btnUpload.TabIndex = 3;
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // FormContratosFestas
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 282);
            Name = "FormContratosFestas";
            Text = "FormContratos";
            pnlCentral.ResumeLayout(false);
            pnlCentral.PerformLayout();
            ((ISupportInitialize)picLogoCrud).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private myTextBox txtNome;
        private Label lblNome;
        private myTextBox txtPath;
        private Label lblPath;
        private Button btnPath;
        private Button btnUpload;
    }
}