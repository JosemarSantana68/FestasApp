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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            msktxtDataVenda = new MyFramework.myControls.myMaskedTextBox();
            label1 = new Label();
            label2 = new Label();
            txtClienteNome = new myTextBox();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            cbbTipoEvento = new MyFramework.myControls.myComboBox();
            mskHoraFim = new MyFramework.myControls.myMaskedTextBox();
            mskDataFesta = new MyFramework.myControls.myMaskedTextBox();
            msktxtHoraInicio = new MyFramework.myControls.myMaskedTextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pictureBox2 = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            cbbEspaco = new ComboBox();
            cbbTema = new ComboBox();
            cbbPacote = new ComboBox();
            cbbStatus = new ComboBox();
            panel3 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            txtTotalPessoa = new myTextBoxNumericos();
            txtTotalAdultos = new myTextBoxNumericos();
            txtPessoasAMais = new myTextBoxNumericos();
            txtCriancasPagantes = new myTextBoxNumericos();
            txtCriancasNaoPagantes = new myTextBoxNumericos();
            txtContrato = new myTextBox();
            panel4 = new Panel();
            dtgItens = new DataGridView();
            tableLayoutPanel5 = new TableLayoutPanel();
            txtValorTotalIntens = new myTextBoxNumericos();
            label20 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            txtItemFesta = new myTextBox();
            txtItemValor = new myTextBoxNumericos();
            txtItemQtde = new myTextBoxNumericos();
            label17 = new Label();
            label19 = new Label();
            btnAddItem = new PictureBox();
            label18 = new Label();
            pnlCentral.SuspendLayout();
            ((ISupportInitialize)picLogoCrud).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((ISupportInitialize)pictureBox2).BeginInit();
            ((ISupportInitialize)pictureBox3).BeginInit();
            ((ISupportInitialize)pictureBox4).BeginInit();
            ((ISupportInitialize)pictureBox5).BeginInit();
            ((ISupportInitialize)pictureBox6).BeginInit();
            panel3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel4.SuspendLayout();
            ((ISupportInitialize)dtgItens).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((ISupportInitialize)btnAddItem).BeginInit();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(774, 64);
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(3, 650);
            pnlRodape.Size = new Size(774, 32);
            // 
            // lblOperacao
            // 
            lblOperacao.Location = new Point(554, 3);
            lblOperacao.Size = new Size(196, 58);
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(465, 58);
            // 
            // pnlCentral
            // 
            pnlCentral.Controls.Add(panel4);
            pnlCentral.Controls.Add(panel3);
            pnlCentral.Controls.Add(panel2);
            pnlCentral.Controls.Add(panel1);
            pnlCentral.Padding = new Padding(0, 3, 0, 3);
            pnlCentral.Size = new Size(774, 583);
            // 
            // picLogoCrud
            // 
            picLogoCrud.Image = Resources.festa_balloons_36;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 0, 10, 0);
            panel1.Size = new Size(774, 89);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 360F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 127F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(msktxtDataVenda, 2, 1);
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 2);
            tableLayoutPanel1.Controls.Add(txtClienteNome, 2, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(762, 87);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // msktxtDataVenda
            // 
            msktxtDataVenda.Font = new Font("Segoe UI", 10F);
            msktxtDataVenda.ForeColor = Color.Black;
            msktxtDataVenda.Location = new Point(163, 18);
            msktxtDataVenda.Mask = "00/00/0000";
            msktxtDataVenda.Name = "msktxtDataVenda";
            msktxtDataVenda.Size = new Size(100, 25);
            msktxtDataVenda.TabIndex = 0;
            msktxtDataVenda.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            msktxtDataVenda.ValidatingType = typeof(DateTime);
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(23, 21);
            label1.Name = "label1";
            label1.Size = new Size(134, 19);
            label1.TabIndex = 0;
            label1.Text = "Data da Venda:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(23, 53);
            label2.Name = "label2";
            label2.Size = new Size(134, 19);
            label2.TabIndex = 1;
            label2.Text = "Nome do Cliente:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtClienteNome
            // 
            txtClienteNome.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtClienteNome.CharacterCasing = CharacterCasing.Upper;
            txtClienteNome.Location = new Point(163, 50);
            txtClienteNome.Name = "txtClienteNome";
            txtClienteNome.Size = new Size(354, 25);
            txtClienteNome.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 92);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 0, 10, 0);
            panel2.Size = new Size(774, 146);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 203F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 29F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(cbbTipoEvento, 2, 2);
            tableLayoutPanel2.Controls.Add(mskHoraFim, 5, 3);
            tableLayoutPanel2.Controls.Add(mskDataFesta, 2, 1);
            tableLayoutPanel2.Controls.Add(msktxtHoraInicio, 5, 2);
            tableLayoutPanel2.Controls.Add(label3, 1, 1);
            tableLayoutPanel2.Controls.Add(label4, 1, 2);
            tableLayoutPanel2.Controls.Add(label5, 1, 3);
            tableLayoutPanel2.Controls.Add(label6, 1, 4);
            tableLayoutPanel2.Controls.Add(pictureBox2, 3, 4);
            tableLayoutPanel2.Controls.Add(label7, 4, 1);
            tableLayoutPanel2.Controls.Add(label8, 4, 2);
            tableLayoutPanel2.Controls.Add(label9, 4, 3);
            tableLayoutPanel2.Controls.Add(label10, 4, 4);
            tableLayoutPanel2.Controls.Add(pictureBox3, 3, 3);
            tableLayoutPanel2.Controls.Add(pictureBox4, 3, 2);
            tableLayoutPanel2.Controls.Add(pictureBox5, 6, 1);
            tableLayoutPanel2.Controls.Add(pictureBox6, 6, 4);
            tableLayoutPanel2.Controls.Add(cbbEspaco, 2, 3);
            tableLayoutPanel2.Controls.Add(cbbTema, 2, 4);
            tableLayoutPanel2.Controls.Add(cbbPacote, 5, 1);
            tableLayoutPanel2.Controls.Add(cbbStatus, 5, 4);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(762, 144);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // cbbTipoEvento
            // 
            cbbTipoEvento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbTipoEvento.BackColor = Color.White;
            cbbTipoEvento.FormattingEnabled = true;
            cbbTipoEvento.Location = new Point(163, 40);
            cbbTipoEvento.Name = "cbbTipoEvento";
            cbbTipoEvento.Size = new Size(197, 25);
            cbbTipoEvento.Sorted = true;
            cbbTipoEvento.TabIndex = 1;
            // 
            // mskHoraFim
            // 
            mskHoraFim.Font = new Font("Segoe UI", 10F);
            mskHoraFim.ForeColor = Color.Black;
            mskHoraFim.Location = new Point(559, 72);
            mskHoraFim.Mask = "00:00";
            mskHoraFim.Name = "mskHoraFim";
            mskHoraFim.Size = new Size(100, 25);
            mskHoraFim.TabIndex = 6;
            mskHoraFim.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskHoraFim.ValidatingType = typeof(DateTime);
            // 
            // mskDataFesta
            // 
            mskDataFesta.Font = new Font("Segoe UI", 10F);
            mskDataFesta.ForeColor = Color.Black;
            mskDataFesta.Location = new Point(163, 8);
            mskDataFesta.Mask = "00/00/0000";
            mskDataFesta.Name = "mskDataFesta";
            mskDataFesta.Size = new Size(100, 25);
            mskDataFesta.TabIndex = 0;
            mskDataFesta.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskDataFesta.ValidatingType = typeof(DateTime);
            // 
            // msktxtHoraInicio
            // 
            msktxtHoraInicio.Font = new Font("Segoe UI", 10F);
            msktxtHoraInicio.ForeColor = Color.Black;
            msktxtHoraInicio.Location = new Point(559, 40);
            msktxtHoraInicio.Mask = "00:00";
            msktxtHoraInicio.Name = "msktxtHoraInicio";
            msktxtHoraInicio.Size = new Size(100, 25);
            msktxtHoraInicio.TabIndex = 5;
            msktxtHoraInicio.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            msktxtHoraInicio.ValidatingType = typeof(DateTime);
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(23, 11);
            label3.Name = "label3";
            label3.Size = new Size(134, 19);
            label3.TabIndex = 0;
            label3.Text = "Data da Festa:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(23, 43);
            label4.Name = "label4";
            label4.Size = new Size(134, 19);
            label4.TabIndex = 0;
            label4.Text = "Tipo do Evento:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(23, 75);
            label5.Name = "label5";
            label5.Size = new Size(134, 19);
            label5.TabIndex = 0;
            label5.Text = "Espaço:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(23, 107);
            label6.Name = "label6";
            label6.Size = new Size(134, 19);
            label6.TabIndex = 0;
            label6.Text = "Tema da Festa:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Left;
            pictureBox2.Image = Resources.add;
            pictureBox2.Location = new Point(366, 106);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(22, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(399, 11);
            label7.Name = "label7";
            label7.Size = new Size(154, 19);
            label7.TabIndex = 0;
            label7.Text = "Pacote da Festa:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(399, 43);
            label8.Name = "label8";
            label8.Size = new Size(154, 19);
            label8.TabIndex = 0;
            label8.Text = "Hora Início:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(399, 75);
            label9.Name = "label9";
            label9.Size = new Size(154, 19);
            label9.TabIndex = 0;
            label9.Text = "Hora Final:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(399, 107);
            label10.Name = "label10";
            label10.Size = new Size(154, 19);
            label10.TabIndex = 0;
            label10.Text = "Status da Festa:";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Left;
            pictureBox3.Image = Resources.add;
            pictureBox3.Location = new Point(366, 74);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(22, 22);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Left;
            pictureBox4.Image = Resources.add;
            pictureBox4.Location = new Point(366, 42);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(22, 22);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Left;
            pictureBox5.Image = Resources.add;
            pictureBox5.Location = new Point(724, 10);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(22, 22);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 1;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Left;
            pictureBox6.Image = Resources.add;
            pictureBox6.Location = new Point(724, 106);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(22, 22);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 1;
            pictureBox6.TabStop = false;
            // 
            // cbbEspaco
            // 
            cbbEspaco.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbEspaco.FormattingEnabled = true;
            cbbEspaco.Location = new Point(163, 73);
            cbbEspaco.Name = "cbbEspaco";
            cbbEspaco.Size = new Size(197, 25);
            cbbEspaco.Sorted = true;
            cbbEspaco.TabIndex = 2;
            // 
            // cbbTema
            // 
            cbbTema.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbTema.FormattingEnabled = true;
            cbbTema.Location = new Point(163, 105);
            cbbTema.Name = "cbbTema";
            cbbTema.Size = new Size(197, 25);
            cbbTema.Sorted = true;
            cbbTema.TabIndex = 3;
            // 
            // cbbPacote
            // 
            cbbPacote.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbPacote.FormattingEnabled = true;
            cbbPacote.Location = new Point(559, 9);
            cbbPacote.Name = "cbbPacote";
            cbbPacote.Size = new Size(159, 25);
            cbbPacote.Sorted = true;
            cbbPacote.TabIndex = 4;
            // 
            // cbbStatus
            // 
            cbbStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(559, 105);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(159, 25);
            cbbStatus.Sorted = true;
            cbbStatus.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(tableLayoutPanel3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 238);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(0, 0, 10, 0);
            panel3.Size = new Size(774, 103);
            panel3.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 211F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label11, 1, 1);
            tableLayoutPanel3.Controls.Add(label12, 1, 2);
            tableLayoutPanel3.Controls.Add(label13, 1, 3);
            tableLayoutPanel3.Controls.Add(label14, 3, 1);
            tableLayoutPanel3.Controls.Add(label15, 3, 2);
            tableLayoutPanel3.Controls.Add(label16, 3, 3);
            tableLayoutPanel3.Controls.Add(txtTotalPessoa, 2, 1);
            tableLayoutPanel3.Controls.Add(txtTotalAdultos, 2, 2);
            tableLayoutPanel3.Controls.Add(txtPessoasAMais, 2, 3);
            tableLayoutPanel3.Controls.Add(txtCriancasPagantes, 4, 1);
            tableLayoutPanel3.Controls.Add(txtCriancasNaoPagantes, 4, 2);
            tableLayoutPanel3.Controls.Add(txtContrato, 4, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(762, 101);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(23, 11);
            label11.Name = "label11";
            label11.Size = new Size(169, 19);
            label11.TabIndex = 0;
            label11.Text = "Total de Pessoa:";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(23, 43);
            label12.Name = "label12";
            label12.Size = new Size(169, 19);
            label12.TabIndex = 0;
            label12.Text = "Adultos:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(23, 75);
            label13.Name = "label13";
            label13.Size = new Size(169, 19);
            label13.TabIndex = 0;
            label13.Text = "Pessoas a Mais:";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new Point(298, 11);
            label14.Name = "label14";
            label14.Size = new Size(164, 19);
            label14.TabIndex = 0;
            label14.Text = "Crianças Pagantes:";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Location = new Point(298, 43);
            label15.Name = "label15";
            label15.Size = new Size(164, 19);
            label15.TabIndex = 0;
            label15.Text = "Crianças Não Pagantes:";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Location = new Point(298, 75);
            label16.Name = "label16";
            label16.Size = new Size(164, 19);
            label16.TabIndex = 0;
            label16.Text = "Contrato Modelo::";
            label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTotalPessoa
            // 
            txtTotalPessoa.CharacterCasing = CharacterCasing.Upper;
            txtTotalPessoa.ForeColor = Color.Black;
            txtTotalPessoa.Location = new Point(198, 8);
            txtTotalPessoa.MyCasasDecimais = 2;
            txtTotalPessoa.MyColorirNegativo = true;
            txtTotalPessoa.MyForcarFormatacao = false;
            txtTotalPessoa.MyMoeda = false;
            txtTotalPessoa.MyPermitirNegativo = false;
            txtTotalPessoa.MyPermitirZerado = false;
            txtTotalPessoa.Name = "txtTotalPessoa";
            txtTotalPessoa.Size = new Size(94, 25);
            txtTotalPessoa.TabIndex = 0;
            txtTotalPessoa.TextAlign = HorizontalAlignment.Right;
            // 
            // txtTotalAdultos
            // 
            txtTotalAdultos.CharacterCasing = CharacterCasing.Upper;
            txtTotalAdultos.ForeColor = Color.Black;
            txtTotalAdultos.Location = new Point(198, 40);
            txtTotalAdultos.MyCasasDecimais = 2;
            txtTotalAdultos.MyColorirNegativo = true;
            txtTotalAdultos.MyForcarFormatacao = false;
            txtTotalAdultos.MyMoeda = false;
            txtTotalAdultos.MyPermitirNegativo = false;
            txtTotalAdultos.MyPermitirZerado = false;
            txtTotalAdultos.Name = "txtTotalAdultos";
            txtTotalAdultos.Size = new Size(94, 25);
            txtTotalAdultos.TabIndex = 1;
            txtTotalAdultos.TextAlign = HorizontalAlignment.Right;
            // 
            // txtPessoasAMais
            // 
            txtPessoasAMais.CharacterCasing = CharacterCasing.Upper;
            txtPessoasAMais.ForeColor = Color.Black;
            txtPessoasAMais.Location = new Point(198, 72);
            txtPessoasAMais.MyCasasDecimais = 2;
            txtPessoasAMais.MyColorirNegativo = true;
            txtPessoasAMais.MyForcarFormatacao = false;
            txtPessoasAMais.MyMoeda = false;
            txtPessoasAMais.MyPermitirNegativo = false;
            txtPessoasAMais.MyPermitirZerado = false;
            txtPessoasAMais.Name = "txtPessoasAMais";
            txtPessoasAMais.Size = new Size(94, 25);
            txtPessoasAMais.TabIndex = 2;
            txtPessoasAMais.TextAlign = HorizontalAlignment.Right;
            // 
            // txtCriancasPagantes
            // 
            txtCriancasPagantes.CharacterCasing = CharacterCasing.Upper;
            txtCriancasPagantes.ForeColor = Color.Black;
            txtCriancasPagantes.Location = new Point(468, 8);
            txtCriancasPagantes.MyCasasDecimais = 2;
            txtCriancasPagantes.MyColorirNegativo = true;
            txtCriancasPagantes.MyForcarFormatacao = false;
            txtCriancasPagantes.MyMoeda = false;
            txtCriancasPagantes.MyPermitirNegativo = false;
            txtCriancasPagantes.MyPermitirZerado = false;
            txtCriancasPagantes.Name = "txtCriancasPagantes";
            txtCriancasPagantes.Size = new Size(100, 25);
            txtCriancasPagantes.TabIndex = 3;
            txtCriancasPagantes.TextAlign = HorizontalAlignment.Right;
            // 
            // txtCriancasNaoPagantes
            // 
            txtCriancasNaoPagantes.CharacterCasing = CharacterCasing.Upper;
            txtCriancasNaoPagantes.ForeColor = Color.Black;
            txtCriancasNaoPagantes.Location = new Point(468, 40);
            txtCriancasNaoPagantes.MyCasasDecimais = 2;
            txtCriancasNaoPagantes.MyColorirNegativo = true;
            txtCriancasNaoPagantes.MyForcarFormatacao = false;
            txtCriancasNaoPagantes.MyMoeda = false;
            txtCriancasNaoPagantes.MyPermitirNegativo = false;
            txtCriancasNaoPagantes.MyPermitirZerado = false;
            txtCriancasNaoPagantes.Name = "txtCriancasNaoPagantes";
            txtCriancasNaoPagantes.Size = new Size(100, 25);
            txtCriancasNaoPagantes.TabIndex = 4;
            txtCriancasNaoPagantes.TextAlign = HorizontalAlignment.Right;
            // 
            // txtContrato
            // 
            txtContrato.CharacterCasing = CharacterCasing.Upper;
            txtContrato.Location = new Point(468, 72);
            txtContrato.Name = "txtContrato";
            txtContrato.Size = new Size(100, 25);
            txtContrato.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(dtgItens);
            panel4.Controls.Add(tableLayoutPanel5);
            panel4.Controls.Add(tableLayoutPanel4);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 341);
            panel4.Name = "panel4";
            panel4.Size = new Size(412, 239);
            panel4.TabIndex = 0;
            // 
            // dtgItens
            // 
            dtgItens.BorderStyle = BorderStyle.None;
            dtgItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgItens.Dock = DockStyle.Fill;
            dtgItens.Location = new Point(0, 50);
            dtgItens.Name = "dtgItens";
            dtgItens.Size = new Size(410, 156);
            dtgItens.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 276F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(txtValorTotalIntens, 1, 0);
            tableLayoutPanel5.Controls.Add(label20, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Bottom;
            tableLayoutPanel5.Location = new Point(0, 206);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel5.Size = new Size(410, 31);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // txtValorTotalIntens
            // 
            txtValorTotalIntens.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtValorTotalIntens.CharacterCasing = CharacterCasing.Upper;
            txtValorTotalIntens.Font = new Font("Segoe UI", 9F);
            txtValorTotalIntens.ForeColor = Color.Black;
            txtValorTotalIntens.Location = new Point(279, 4);
            txtValorTotalIntens.MyCasasDecimais = 2;
            txtValorTotalIntens.MyColorirNegativo = true;
            txtValorTotalIntens.MyForcarFormatacao = true;
            txtValorTotalIntens.MyMoeda = true;
            txtValorTotalIntens.MyPermitirNegativo = false;
            txtValorTotalIntens.MyPermitirZerado = true;
            txtValorTotalIntens.Name = "txtValorTotalIntens";
            txtValorTotalIntens.Size = new Size(82, 23);
            txtValorTotalIntens.TabIndex = 4;
            txtValorTotalIntens.TextAlign = HorizontalAlignment.Right;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label20.Location = new Point(3, 8);
            label20.Name = "label20";
            label20.Size = new Size(270, 15);
            label20.TabIndex = 0;
            label20.Text = "Total de Adicional da Festa:";
            label20.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 6;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 201F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(txtItemFesta, 1, 1);
            tableLayoutPanel4.Controls.Add(txtItemValor, 3, 1);
            tableLayoutPanel4.Controls.Add(txtItemQtde, 2, 1);
            tableLayoutPanel4.Controls.Add(label17, 1, 0);
            tableLayoutPanel4.Controls.Add(label19, 3, 0);
            tableLayoutPanel4.Controls.Add(btnAddItem, 4, 1);
            tableLayoutPanel4.Controls.Add(label18, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Top;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(410, 50);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // txtItemFesta
            // 
            txtItemFesta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtItemFesta.CharacterCasing = CharacterCasing.Upper;
            txtItemFesta.Font = new Font("Segoe UI", 9F);
            txtItemFesta.Location = new Point(23, 19);
            txtItemFesta.Name = "txtItemFesta";
            txtItemFesta.Size = new Size(195, 23);
            txtItemFesta.TabIndex = 0;
            // 
            // txtItemValor
            // 
            txtItemValor.CharacterCasing = CharacterCasing.Upper;
            txtItemValor.Font = new Font("Segoe UI", 9F);
            txtItemValor.ForeColor = Color.Black;
            txtItemValor.Location = new Point(299, 19);
            txtItemValor.MyCasasDecimais = 2;
            txtItemValor.MyColorirNegativo = true;
            txtItemValor.MyForcarFormatacao = true;
            txtItemValor.MyMoeda = false;
            txtItemValor.MyPermitirNegativo = false;
            txtItemValor.MyPermitirZerado = true;
            txtItemValor.Name = "txtItemValor";
            txtItemValor.Size = new Size(69, 23);
            txtItemValor.TabIndex = 2;
            txtItemValor.TextAlign = HorizontalAlignment.Right;
            // 
            // txtItemQtde
            // 
            txtItemQtde.CharacterCasing = CharacterCasing.Upper;
            txtItemQtde.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtItemQtde.ForeColor = Color.Black;
            txtItemQtde.Location = new Point(224, 19);
            txtItemQtde.MyCasasDecimais = 0;
            txtItemQtde.MyColorirNegativo = false;
            txtItemQtde.MyForcarFormatacao = true;
            txtItemQtde.MyMoeda = false;
            txtItemQtde.MyPermitirNegativo = false;
            txtItemQtde.MyPermitirZerado = true;
            txtItemQtde.Name = "txtItemQtde";
            txtItemQtde.Size = new Size(69, 23);
            txtItemQtde.TabIndex = 1;
            txtItemQtde.TextAlign = HorizontalAlignment.Right;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label17.Location = new Point(23, 0);
            label17.Name = "label17";
            label17.Size = new Size(195, 15);
            label17.TabIndex = 0;
            label17.Text = "Adicional da Festa:";
            label17.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label19.Location = new Point(299, 0);
            label19.Name = "label19";
            label19.Size = new Size(69, 15);
            label19.TabIndex = 0;
            label19.Text = "Valor:";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddItem
            // 
            btnAddItem.Anchor = AnchorStyles.Left;
            btnAddItem.Image = Resources.add;
            btnAddItem.Location = new Point(374, 19);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(22, 19);
            btnAddItem.SizeMode = PictureBoxSizeMode.Zoom;
            btnAddItem.TabIndex = 1;
            btnAddItem.TabStop = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label18.Location = new Point(224, 0);
            label18.Name = "label18";
            label18.Size = new Size(69, 15);
            label18.TabIndex = 0;
            label18.Text = "Qtde:";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormFestasCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 685);
            Name = "FormFestasCRUD";
            Text = "FormFestasCRUD";
            Load += FormFestasCRUD_Load;
            pnlCentral.ResumeLayout(false);
            ((ISupportInitialize)picLogoCrud).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((ISupportInitialize)pictureBox2).EndInit();
            ((ISupportInitialize)pictureBox3).EndInit();
            ((ISupportInitialize)pictureBox4).EndInit();
            ((ISupportInitialize)pictureBox5).EndInit();
            ((ISupportInitialize)pictureBox6).EndInit();
            panel3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel4.ResumeLayout(false);
            ((ISupportInitialize)dtgItens).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((ISupportInitialize)btnAddItem).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
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
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label17;
        private Label label18;
        private Label label19;
        private PictureBox btnAddItem;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private DataGridView dtgItens;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label20;
        private myTextBoxNumericos txtItemValor;
        private myTextBoxNumericos txtItemQtde;
        private myTextBox txtItemFesta;
        private myTextBoxNumericos txtValorTotalIntens;
        private ComboBox cbbEspaco;
        private ComboBox cbbTema;
        private ComboBox cbbPacote;
        private ComboBox cbbStatus;
        private myTextBox txtClienteNome;
        private myTextBoxNumericos txtTotalPessoa;
        private myTextBoxNumericos txtTotalAdultos;
        private myTextBoxNumericos txtPessoasAMais;
        private myTextBoxNumericos txtCriancasPagantes;
        private myTextBoxNumericos txtCriancasNaoPagantes;
        private myTextBox txtContrato;
        private MyFramework.myControls.myMaskedTextBox msktxtDataVenda;
        private MyFramework.myControls.myMaskedTextBox msktxtHoraInicio;
        private MyFramework.myControls.myMaskedTextBox mskDataFesta;
        private MyFramework.myControls.myMaskedTextBox mskHoraFim;
        private MyFramework.myControls.myComboBox cbbTipoEvento;
    }
}