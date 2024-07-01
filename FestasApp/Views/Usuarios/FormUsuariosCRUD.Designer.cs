namespace FestasApp.Views.Usuarios
{
    partial class FormUsuariosCRUD
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lblID = new Label();
            txtUserNome = new myTextBox();
            txtUserLogin = new myTextBox();
            txtUserEmail = new myTextBox();
            txtUserSenha = new myTextBox();
            chkUserAtivo = new CheckBox();
            pnlCentral.SuspendLayout();
            ((ISupportInitialize)picLogoCrud).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(549, 64);
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(3, 332);
            pnlRodape.Size = new Size(549, 36);
            // 
            // lblOperacao
            // 
            lblOperacao.Location = new Point(383, 3);
            lblOperacao.Size = new Size(122, 58);
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(294, 58);
            // 
            // pnlCentral
            // 
            pnlCentral.Controls.Add(tableLayoutPanel1);
            pnlCentral.Size = new Size(549, 265);
            // 
            // picLogoCrud
            // 
            picLogoCrud.Image = Resources.pessoas_funcionarios_36;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.77686F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.22314F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 1, 3);
            tableLayoutPanel1.Controls.Add(label4, 1, 4);
            tableLayoutPanel1.Controls.Add(label5, 1, 5);
            tableLayoutPanel1.Controls.Add(label6, 1, 6);
            tableLayoutPanel1.Controls.Add(lblID, 2, 1);
            tableLayoutPanel1.Controls.Add(txtUserNome, 2, 2);
            tableLayoutPanel1.Controls.Add(txtUserLogin, 2, 3);
            tableLayoutPanel1.Controls.Add(txtUserEmail, 2, 4);
            tableLayoutPanel1.Controls.Add(txtUserSenha, 2, 5);
            tableLayoutPanel1.Controls.Add(chkUserAtivo, 2, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(549, 265);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(23, 42);
            label1.Name = "label1";
            label1.Size = new Size(130, 19);
            label1.TabIndex = 0;
            label1.Text = "ID";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(23, 74);
            label2.Name = "label2";
            label2.Size = new Size(130, 19);
            label2.TabIndex = 1;
            label2.Text = "Nome";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(23, 106);
            label3.Name = "label3";
            label3.Size = new Size(130, 19);
            label3.TabIndex = 2;
            label3.Text = "Login";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(23, 138);
            label4.Name = "label4";
            label4.Size = new Size(130, 19);
            label4.TabIndex = 3;
            label4.Text = "Email";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(23, 170);
            label5.Name = "label5";
            label5.Size = new Size(130, 19);
            label5.TabIndex = 4;
            label5.Text = "Senha";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(23, 202);
            label6.Name = "label6";
            label6.Size = new Size(130, 19);
            label6.TabIndex = 5;
            label6.Text = "Ativo";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            lblID.Anchor = AnchorStyles.Left;
            lblID.Location = new Point(159, 42);
            lblID.Name = "lblID";
            lblID.Size = new Size(63, 19);
            lblID.TabIndex = 9;
            lblID.Text = "ID";
            lblID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUserNome
            // 
            txtUserNome.CharacterCasing = CharacterCasing.Upper;
            txtUserNome.Font = new Font("Segoe UI", 10F);
            txtUserNome.ForeColor = Color.Black;
            txtUserNome.Location = new Point(159, 71);
            txtUserNome.Name = "txtUserNome";
            txtUserNome.Size = new Size(237, 25);
            txtUserNome.TabIndex = 10;
            // 
            // txtUserLogin
            // 
            txtUserLogin.CharacterCasing = CharacterCasing.Upper;
            txtUserLogin.Font = new Font("Segoe UI", 10F);
            txtUserLogin.ForeColor = Color.Black;
            txtUserLogin.Location = new Point(159, 103);
            txtUserLogin.Name = "txtUserLogin";
            txtUserLogin.Size = new Size(237, 25);
            txtUserLogin.TabIndex = 10;
            // 
            // txtUserEmail
            // 
            txtUserEmail.CharacterCasing = CharacterCasing.Upper;
            txtUserEmail.Font = new Font("Segoe UI", 10F);
            txtUserEmail.ForeColor = Color.Black;
            txtUserEmail.Location = new Point(159, 135);
            txtUserEmail.Name = "txtUserEmail";
            txtUserEmail.Size = new Size(237, 25);
            txtUserEmail.TabIndex = 11;
            // 
            // txtUserSenha
            // 
            txtUserSenha.CharacterCasing = CharacterCasing.Upper;
            txtUserSenha.Font = new Font("Segoe UI", 10F);
            txtUserSenha.ForeColor = Color.Black;
            txtUserSenha.Location = new Point(159, 167);
            txtUserSenha.Name = "txtUserSenha";
            txtUserSenha.Size = new Size(237, 25);
            txtUserSenha.TabIndex = 12;
            // 
            // chkUserAtivo
            // 
            chkUserAtivo.AutoSize = true;
            chkUserAtivo.Dock = DockStyle.Left;
            chkUserAtivo.Location = new Point(159, 199);
            chkUserAtivo.Name = "chkUserAtivo";
            chkUserAtivo.Padding = new Padding(5, 0, 0, 0);
            chkUserAtivo.Size = new Size(63, 26);
            chkUserAtivo.TabIndex = 13;
            chkUserAtivo.Text = "NÃO";
            chkUserAtivo.UseVisualStyleBackColor = true;
            chkUserAtivo.CheckedChanged += chkUserAtivo_CheckedChanged;
            // 
            // FormUsuariosCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 371);
            Name = "FormUsuariosCRUD";
            Text = "FormUsuariosCRUD";
            pnlCentral.ResumeLayout(false);
            ((ISupportInitialize)picLogoCrud).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblID;
        private myTextBox txtUserNome;
        private myTextBox txtUserLogin;
        private myTextBox txtUserEmail;
        private myTextBox txtUserSenha;
        private CheckBox chkUserAtivo;
    }
}