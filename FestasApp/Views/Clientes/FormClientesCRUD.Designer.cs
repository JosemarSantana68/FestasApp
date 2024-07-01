namespace FestasApp.Views.Clientes
{
    partial class FormClientesCRUD
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
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lblID = new Label();
            txtNome = new myTextBox();
            txtEndereco = new myTextBox();
            txtCidade = new myTextBox();
            txtUF = new myTextBox();
            txtTelefone1 = new MyFramework.myControls.myMaskedTextBox();
            txtTelefone2 = new MyFramework.myControls.myMaskedTextBox();
            txtCpf = new MyFramework.myControls.myMaskedTextBox();
            txtCep = new MyFramework.myControls.myMaskedTextBox();
            pnlCentral.SuspendLayout();
            ((ISupportInitialize)picLogoCrud).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(605, 64);
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(3, 383);
            pnlRodape.Size = new Size(605, 36);
            // 
            // lblOperacao
            // 
            lblOperacao.Location = new Point(422, 3);
            lblOperacao.Padding = new Padding(0, 0, 10, 0);
            lblOperacao.Size = new Size(139, 58);
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(333, 58);
            // 
            // pnlCentral
            // 
            pnlCentral.Controls.Add(tableLayoutPanel1);
            pnlCentral.Size = new Size(605, 316);
            // 
            // picLogoCrud
            // 
            picLogoCrud.Image = Resources.pessoas_clientes_36;
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
            tableLayoutPanel1.Controls.Add(label7, 1, 7);
            tableLayoutPanel1.Controls.Add(label8, 1, 8);
            tableLayoutPanel1.Controls.Add(label9, 1, 9);
            tableLayoutPanel1.Controls.Add(lblID, 2, 1);
            tableLayoutPanel1.Controls.Add(txtNome, 2, 2);
            tableLayoutPanel1.Controls.Add(txtEndereco, 2, 6);
            tableLayoutPanel1.Controls.Add(txtCidade, 2, 8);
            tableLayoutPanel1.Controls.Add(txtUF, 2, 9);
            tableLayoutPanel1.Controls.Add(txtTelefone1, 2, 3);
            tableLayoutPanel1.Controls.Add(txtTelefone2, 2, 4);
            tableLayoutPanel1.Controls.Add(txtCpf, 2, 5);
            tableLayoutPanel1.Controls.Add(txtCep, 2, 7);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 11;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(605, 316);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(145, 19);
            label1.TabIndex = 0;
            label1.Text = "ID";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(23, 52);
            label2.Name = "label2";
            label2.Size = new Size(145, 19);
            label2.TabIndex = 1;
            label2.Text = "Nome";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(23, 84);
            label3.Name = "label3";
            label3.Size = new Size(145, 19);
            label3.TabIndex = 2;
            label3.Text = "Telefone-1";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(23, 116);
            label4.Name = "label4";
            label4.Size = new Size(145, 19);
            label4.TabIndex = 3;
            label4.Text = "Telefone-2";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(23, 148);
            label5.Name = "label5";
            label5.Size = new Size(145, 19);
            label5.TabIndex = 4;
            label5.Text = "CPF";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(23, 180);
            label6.Name = "label6";
            label6.Size = new Size(145, 19);
            label6.TabIndex = 5;
            label6.Text = "Endereço";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(23, 212);
            label7.Name = "label7";
            label7.Size = new Size(145, 19);
            label7.TabIndex = 6;
            label7.Text = "CEP";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(23, 244);
            label8.Name = "label8";
            label8.Size = new Size(145, 19);
            label8.TabIndex = 7;
            label8.Text = "Cidade";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(23, 276);
            label9.Name = "label9";
            label9.Size = new Size(145, 19);
            label9.TabIndex = 8;
            label9.Text = "UF";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            lblID.Anchor = AnchorStyles.Left;
            lblID.Location = new Point(174, 20);
            lblID.Name = "lblID";
            lblID.Size = new Size(63, 19);
            lblID.TabIndex = 9;
            lblID.Text = "ID";
            lblID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNome
            // 
            txtNome.CharacterCasing = CharacterCasing.Upper;
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.ForeColor = Color.Black;
            txtNome.Location = new Point(174, 49);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(320, 25);
            txtNome.TabIndex = 0;
            // 
            // txtEndereco
            // 
            txtEndereco.CharacterCasing = CharacterCasing.Upper;
            txtEndereco.Font = new Font("Segoe UI", 10F);
            txtEndereco.ForeColor = Color.Black;
            txtEndereco.Location = new Point(174, 177);
            txtEndereco.MaxLength = 100;
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(320, 25);
            txtEndereco.TabIndex = 4;
            // 
            // txtCidade
            // 
            txtCidade.CharacterCasing = CharacterCasing.Upper;
            txtCidade.Font = new Font("Segoe UI", 10F);
            txtCidade.ForeColor = Color.Black;
            txtCidade.Location = new Point(174, 241);
            txtCidade.MaxLength = 100;
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(320, 25);
            txtCidade.TabIndex = 6;
            // 
            // txtUF
            // 
            txtUF.CharacterCasing = CharacterCasing.Upper;
            txtUF.Font = new Font("Segoe UI", 10F);
            txtUF.ForeColor = Color.Black;
            txtUF.Location = new Point(174, 273);
            txtUF.MaxLength = 20;
            txtUF.Name = "txtUF";
            txtUF.Size = new Size(63, 25);
            txtUF.TabIndex = 7;
            // 
            // txtTelefone1
            // 
            txtTelefone1.Font = new Font("Segoe UI", 10F);
            txtTelefone1.ForeColor = Color.Black;
            txtTelefone1.Location = new Point(174, 81);
            txtTelefone1.Mask = "(99) 00000-0000";
            txtTelefone1.Name = "txtTelefone1";
            txtTelefone1.Size = new Size(139, 25);
            txtTelefone1.TabIndex = 1;
            txtTelefone1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtTelefone2
            // 
            txtTelefone2.Font = new Font("Segoe UI", 10F);
            txtTelefone2.ForeColor = Color.Black;
            txtTelefone2.Location = new Point(174, 113);
            txtTelefone2.Mask = "(99) 00000-0000";
            txtTelefone2.Name = "txtTelefone2";
            txtTelefone2.Size = new Size(139, 25);
            txtTelefone2.TabIndex = 2;
            txtTelefone2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtCpf
            // 
            txtCpf.Font = new Font("Segoe UI", 10F);
            txtCpf.ForeColor = Color.Black;
            txtCpf.Location = new Point(174, 145);
            txtCpf.Mask = "000,000,000-00";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(139, 25);
            txtCpf.TabIndex = 3;
            txtCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtCep
            // 
            txtCep.Font = new Font("Segoe UI", 10F);
            txtCep.ForeColor = Color.Black;
            txtCep.Location = new Point(174, 209);
            txtCep.Mask = "00,000-999";
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(139, 25);
            txtCep.TabIndex = 5;
            txtCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // FormClientesCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 422);
            KeyPreview = true;
            Name = "FormClientesCRUD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormClientesCRUD";
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
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblID;
        private myTextBox txtNome;
        private myTextBox txtEndereco;
        private myTextBox txtCidade;
        private myTextBox txtUF;
        private MyFramework.myControls.myMaskedTextBox txtTelefone1;
        private MyFramework.myControls.myMaskedTextBox txtTelefone2;
        private MyFramework.myControls.myMaskedTextBox txtCpf;
        private MyFramework.myControls.myMaskedTextBox txtCep;
    }
}