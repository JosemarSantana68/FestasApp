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
            cbbClientes = new MyFramework.myControls.myComboBox();
            lblCliente = new Label();
            picAddCliente = new MyFramework.myControls.myPictureBox();
            tableLayoutPanel9 = new TableLayoutPanel();
            lblVendedor = new Label();
            label1 = new Label();
            cbbVendedor = new MyFramework.myControls.myComboBox();
            txtDataVenda = new myTextBoxDatas();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            lblStatus = new Label();
            txtDataFesta = new myTextBoxDatas();
            picAddStatus = new MyFramework.myControls.myPictureBox();
            cbbEspacos = new MyFramework.myControls.myComboBox();
            cbbTemas = new MyFramework.myControls.myComboBox();
            label9 = new Label();
            lblTema = new Label();
            lblEspaco = new Label();
            cbbPacotes = new MyFramework.myControls.myComboBox();
            picAddTema = new MyFramework.myControls.myPictureBox();
            txtHoraInicio = new myTextBoxHora();
            txtHoraFim = new myTextBoxHora();
            picAddEspaco = new MyFramework.myControls.myPictureBox();
            label8 = new Label();
            cbbTiposEvento = new MyFramework.myControls.myComboBox();
            lblTipoEvento = new Label();
            lblPacote = new Label();
            picAddPacote = new MyFramework.myControls.myPictureBox();
            picAddTipoEvento = new MyFramework.myControls.myPictureBox();
            cbbStatus = new MyFramework.myControls.myComboBox();
            panel3 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            lblContrato = new Label();
            txtTotalPessoa = new myTextBoxNumericos();
            txtTotalAdultos = new myTextBoxNumericos();
            txtPessoasAMais = new myTextBoxNumericos();
            txtCriancasPagantes = new myTextBoxNumericos();
            txtCriancasNaoPagantes = new myTextBoxNumericos();
            cbbContratos = new MyFramework.myControls.myComboBox();
            panel4 = new Panel();
            dtgItens = new DataGridView();
            tableLayoutPanel5 = new TableLayoutPanel();
            label20 = new Label();
            lblValorTotalIntens = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            cbbItemFesta = new MyFramework.myControls.myComboBox();
            label17 = new Label();
            txtItemQtde = new myTextBoxNumericos();
            btnAddItem = new MyFramework.myControls.myPictureBox();
            txtItemValor = new myTextBoxNumericos();
            label19 = new Label();
            label18 = new Label();
            label22 = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            txtDescontosFesta = new myTextBoxNumericos();
            lblValorTotalFesta = new Label();
            label24 = new Label();
            label25 = new Label();
            lblValorAdicionais = new Label();
            label26 = new Label();
            lblValorPacote = new Label();
            tableLayoutPanel7 = new TableLayoutPanel();
            label23 = new Label();
            txtObservacao = new myTextBox();
            pnlCentral.SuspendLayout();
            ((ISupportInitialize)picLogoCrud).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)picAddCliente).BeginInit();
            tableLayoutPanel9.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((ISupportInitialize)picAddStatus).BeginInit();
            ((ISupportInitialize)picAddTema).BeginInit();
            ((ISupportInitialize)picAddEspaco).BeginInit();
            ((ISupportInitialize)picAddPacote).BeginInit();
            ((ISupportInitialize)picAddTipoEvento).BeginInit();
            panel3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel4.SuspendLayout();
            ((ISupportInitialize)dtgItens).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((ISupportInitialize)btnAddItem).BeginInit();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
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
            pnlCentral.Controls.Add(tableLayoutPanel7);
            pnlCentral.Controls.Add(tableLayoutPanel6);
            pnlCentral.Controls.Add(panel4);
            pnlCentral.Controls.Add(panel3);
            pnlCentral.Controls.Add(panel2);
            pnlCentral.Controls.Add(panel1);
            pnlCentral.Padding = new Padding(0, 3, 0, 3);
            pnlCentral.Size = new Size(774, 583);
            pnlCentral.TabIndex = 0;
            // 
            // picLogoCrud
            // 
            picLogoCrud.Image = Resources.festa_balloons_36;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(tableLayoutPanel9);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 0, 10, 0);
            panel1.Size = new Size(774, 84);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 463F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
            tableLayoutPanel1.Controls.Add(cbbClientes, 2, 0);
            tableLayoutPanel1.Controls.Add(lblCliente, 1, 0);
            tableLayoutPanel1.Controls.Add(picAddCliente, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 43);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(762, 39);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // cbbClientes
            // 
            cbbClientes.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbClientes.BackColor = Color.White;
            cbbClientes.Font = new Font("Segoe UI", 10F);
            cbbClientes.ForeColor = Color.Black;
            cbbClientes.FormattingEnabled = true;
            cbbClientes.Location = new Point(163, 5);
            cbbClientes.Name = "cbbClientes";
            cbbClientes.Size = new Size(457, 25);
            cbbClientes.Sorted = true;
            cbbClientes.TabIndex = 2;
            // 
            // lblCliente
            // 
            lblCliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(23, 8);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(134, 19);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Nome do Cliente:";
            lblCliente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // picAddCliente
            // 
            picAddCliente._CorOnEnter = Color.Empty;
            picAddCliente._ImageFocus = Resources.add_blue_focus_50;
            picAddCliente.Image = Resources.add;
            picAddCliente.Location = new Point(626, 3);
            picAddCliente.Name = "picAddCliente";
            picAddCliente.Size = new Size(23, 26);
            picAddCliente.SizeMode = PictureBoxSizeMode.Zoom;
            picAddCliente.TabIndex = 11;
            picAddCliente.TabStop = false;
            picAddCliente.Click += picAddCliente_Click;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 6;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 177F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 179F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 143F));
            tableLayoutPanel9.Controls.Add(lblVendedor, 3, 1);
            tableLayoutPanel9.Controls.Add(label1, 1, 1);
            tableLayoutPanel9.Controls.Add(cbbVendedor, 4, 1);
            tableLayoutPanel9.Controls.Add(txtDataVenda, 2, 1);
            tableLayoutPanel9.Dock = DockStyle.Top;
            tableLayoutPanel9.Location = new Point(0, 0);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 28.7356319F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 71.2643661F));
            tableLayoutPanel9.Size = new Size(762, 43);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // lblVendedor
            // 
            lblVendedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(269, 18);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(171, 19);
            lblVendedor.TabIndex = 1;
            lblVendedor.Text = "Vendedor:";
            lblVendedor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(23, 18);
            label1.Name = "label1";
            label1.Size = new Size(134, 19);
            label1.TabIndex = 0;
            label1.Text = "Data da Venda:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbbVendedor
            // 
            cbbVendedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbVendedor.BackColor = Color.White;
            cbbVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbVendedor.Font = new Font("Segoe UI", 10F);
            cbbVendedor.ForeColor = Color.Black;
            cbbVendedor.FormattingEnabled = true;
            cbbVendedor.Location = new Point(446, 15);
            cbbVendedor.Name = "cbbVendedor";
            cbbVendedor.Size = new Size(173, 25);
            cbbVendedor.Sorted = true;
            cbbVendedor.TabIndex = 1;
            // 
            // txtDataVenda
            // 
            txtDataVenda.CharacterCasing = CharacterCasing.Upper;
            txtDataVenda.ExibirMensagemAlerta = false;
            txtDataVenda.Location = new Point(163, 15);
            txtDataVenda.MyDataAtual = true;
            txtDataVenda.Name = "txtDataVenda";
            txtDataVenda.Size = new Size(100, 25);
            txtDataVenda.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 87);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 0, 10, 0);
            panel2.Size = new Size(774, 146);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 185F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 162F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 185F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label3, 1, 1);
            tableLayoutPanel2.Controls.Add(lblStatus, 4, 4);
            tableLayoutPanel2.Controls.Add(txtDataFesta, 2, 1);
            tableLayoutPanel2.Controls.Add(picAddStatus, 6, 4);
            tableLayoutPanel2.Controls.Add(cbbEspacos, 5, 2);
            tableLayoutPanel2.Controls.Add(cbbTemas, 5, 3);
            tableLayoutPanel2.Controls.Add(label9, 1, 3);
            tableLayoutPanel2.Controls.Add(lblTema, 4, 3);
            tableLayoutPanel2.Controls.Add(lblEspaco, 4, 2);
            tableLayoutPanel2.Controls.Add(cbbPacotes, 5, 1);
            tableLayoutPanel2.Controls.Add(picAddTema, 6, 3);
            tableLayoutPanel2.Controls.Add(txtHoraInicio, 2, 2);
            tableLayoutPanel2.Controls.Add(txtHoraFim, 2, 3);
            tableLayoutPanel2.Controls.Add(picAddEspaco, 6, 2);
            tableLayoutPanel2.Controls.Add(label8, 1, 2);
            tableLayoutPanel2.Controls.Add(cbbTiposEvento, 2, 4);
            tableLayoutPanel2.Controls.Add(lblTipoEvento, 1, 4);
            tableLayoutPanel2.Controls.Add(lblPacote, 4, 1);
            tableLayoutPanel2.Controls.Add(picAddPacote, 6, 1);
            tableLayoutPanel2.Controls.Add(picAddTipoEvento, 3, 4);
            tableLayoutPanel2.Controls.Add(cbbStatus, 5, 4);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(762, 144);
            tableLayoutPanel2.TabIndex = 2;
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
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(378, 107);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(156, 19);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status da Festa:";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDataFesta
            // 
            txtDataFesta.CharacterCasing = CharacterCasing.Upper;
            txtDataFesta.ExibirMensagemAlerta = false;
            txtDataFesta.Location = new Point(163, 8);
            txtDataFesta.MyDataAtual = false;
            txtDataFesta.Name = "txtDataFesta";
            txtDataFesta.Size = new Size(100, 25);
            txtDataFesta.TabIndex = 3;
            // 
            // picAddStatus
            // 
            picAddStatus._CorOnEnter = Color.Empty;
            picAddStatus._ImageFocus = Resources.add_blue_focus_50;
            picAddStatus.Image = Resources.add;
            picAddStatus.Location = new Point(725, 104);
            picAddStatus.Name = "picAddStatus";
            picAddStatus.Size = new Size(23, 26);
            picAddStatus.SizeMode = PictureBoxSizeMode.Zoom;
            picAddStatus.TabIndex = 11;
            picAddStatus.TabStop = false;
            picAddStatus.Click += picAddStatus_Click;
            // 
            // cbbEspacos
            // 
            cbbEspacos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbEspacos.BackColor = Color.White;
            cbbEspacos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbEspacos.Font = new Font("Segoe UI", 10F);
            cbbEspacos.ForeColor = Color.Black;
            cbbEspacos.FormattingEnabled = true;
            cbbEspacos.Location = new Point(540, 40);
            cbbEspacos.Name = "cbbEspacos";
            cbbEspacos.Size = new Size(179, 25);
            cbbEspacos.Sorted = true;
            cbbEspacos.TabIndex = 8;
            // 
            // cbbTemas
            // 
            cbbTemas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbTemas.BackColor = Color.White;
            cbbTemas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTemas.Font = new Font("Segoe UI", 10F);
            cbbTemas.ForeColor = Color.Black;
            cbbTemas.FormattingEnabled = true;
            cbbTemas.Location = new Point(540, 72);
            cbbTemas.Name = "cbbTemas";
            cbbTemas.Size = new Size(179, 25);
            cbbTemas.Sorted = true;
            cbbTemas.TabIndex = 9;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(23, 75);
            label9.Name = "label9";
            label9.Size = new Size(134, 19);
            label9.TabIndex = 0;
            label9.Text = "Hora Final:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTema
            // 
            lblTema.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTema.AutoSize = true;
            lblTema.Location = new Point(378, 75);
            lblTema.Name = "lblTema";
            lblTema.Size = new Size(156, 19);
            lblTema.TabIndex = 0;
            lblTema.Text = "Tema da Festa:";
            lblTema.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblEspaco
            // 
            lblEspaco.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblEspaco.AutoSize = true;
            lblEspaco.Location = new Point(378, 43);
            lblEspaco.Name = "lblEspaco";
            lblEspaco.Size = new Size(156, 19);
            lblEspaco.TabIndex = 0;
            lblEspaco.Text = "Espaço:";
            lblEspaco.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbbPacotes
            // 
            cbbPacotes.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbPacotes.BackColor = Color.White;
            cbbPacotes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbPacotes.Font = new Font("Segoe UI", 10F);
            cbbPacotes.ForeColor = Color.Black;
            cbbPacotes.FormattingEnabled = true;
            cbbPacotes.Location = new Point(540, 8);
            cbbPacotes.Name = "cbbPacotes";
            cbbPacotes.Size = new Size(179, 25);
            cbbPacotes.Sorted = true;
            cbbPacotes.TabIndex = 7;
            // 
            // picAddTema
            // 
            picAddTema._CorOnEnter = Color.Empty;
            picAddTema._ImageFocus = Resources.add_blue_focus_50;
            picAddTema.Image = Resources.add;
            picAddTema.Location = new Point(725, 72);
            picAddTema.Name = "picAddTema";
            picAddTema.Size = new Size(23, 26);
            picAddTema.SizeMode = PictureBoxSizeMode.Zoom;
            picAddTema.TabIndex = 11;
            picAddTema.TabStop = false;
            picAddTema.Click += picAddTema_Click;
            // 
            // txtHoraInicio
            // 
            txtHoraInicio.CharacterCasing = CharacterCasing.Upper;
            txtHoraInicio.ExibirMensagemAlerta = false;
            txtHoraInicio.HoraAtual = false;
            txtHoraInicio.Location = new Point(163, 40);
            txtHoraInicio.Name = "txtHoraInicio";
            txtHoraInicio.Size = new Size(100, 25);
            txtHoraInicio.TabIndex = 4;
            // 
            // txtHoraFim
            // 
            txtHoraFim.CharacterCasing = CharacterCasing.Upper;
            txtHoraFim.ExibirMensagemAlerta = false;
            txtHoraFim.HoraAtual = false;
            txtHoraFim.Location = new Point(163, 72);
            txtHoraFim.Name = "txtHoraFim";
            txtHoraFim.Size = new Size(100, 25);
            txtHoraFim.TabIndex = 5;
            // 
            // picAddEspaco
            // 
            picAddEspaco._CorOnEnter = Color.Empty;
            picAddEspaco._ImageFocus = Resources.add_blue_focus_50;
            picAddEspaco.Image = Resources.add;
            picAddEspaco.Location = new Point(725, 40);
            picAddEspaco.Name = "picAddEspaco";
            picAddEspaco.Size = new Size(23, 26);
            picAddEspaco.SizeMode = PictureBoxSizeMode.Zoom;
            picAddEspaco.TabIndex = 11;
            picAddEspaco.TabStop = false;
            picAddEspaco.Click += picAddEspaco_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(23, 43);
            label8.Name = "label8";
            label8.Size = new Size(134, 19);
            label8.TabIndex = 0;
            label8.Text = "Hora Início:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbbTiposEvento
            // 
            cbbTiposEvento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbTiposEvento.BackColor = Color.White;
            cbbTiposEvento.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTiposEvento.Font = new Font("Segoe UI", 10F);
            cbbTiposEvento.ForeColor = Color.Black;
            cbbTiposEvento.FormattingEnabled = true;
            cbbTiposEvento.Location = new Point(163, 104);
            cbbTiposEvento.Name = "cbbTiposEvento";
            cbbTiposEvento.Size = new Size(179, 25);
            cbbTiposEvento.Sorted = true;
            cbbTiposEvento.TabIndex = 6;
            // 
            // lblTipoEvento
            // 
            lblTipoEvento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTipoEvento.AutoSize = true;
            lblTipoEvento.Location = new Point(23, 107);
            lblTipoEvento.Name = "lblTipoEvento";
            lblTipoEvento.Size = new Size(134, 19);
            lblTipoEvento.TabIndex = 0;
            lblTipoEvento.Text = "Tipo do Evento:";
            lblTipoEvento.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPacote
            // 
            lblPacote.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblPacote.AutoSize = true;
            lblPacote.Location = new Point(378, 11);
            lblPacote.Name = "lblPacote";
            lblPacote.Size = new Size(156, 19);
            lblPacote.TabIndex = 0;
            lblPacote.Text = "Pacote da Festa:";
            lblPacote.TextAlign = ContentAlignment.MiddleRight;
            // 
            // picAddPacote
            // 
            picAddPacote._CorOnEnter = Color.Empty;
            picAddPacote._ImageFocus = Resources.add_blue_focus_50;
            picAddPacote.Image = Resources.add;
            picAddPacote.Location = new Point(725, 8);
            picAddPacote.Name = "picAddPacote";
            picAddPacote.Size = new Size(23, 26);
            picAddPacote.SizeMode = PictureBoxSizeMode.Zoom;
            picAddPacote.TabIndex = 11;
            picAddPacote.TabStop = false;
            picAddPacote.Click += picAddPacote_Click;
            // 
            // picAddTipoEvento
            // 
            picAddTipoEvento._CorOnEnter = Color.Empty;
            picAddTipoEvento._ImageFocus = Resources.add_blue_focus_50;
            picAddTipoEvento.Image = Resources.add;
            picAddTipoEvento.Location = new Point(348, 104);
            picAddTipoEvento.Name = "picAddTipoEvento";
            picAddTipoEvento.Size = new Size(23, 26);
            picAddTipoEvento.SizeMode = PictureBoxSizeMode.Zoom;
            picAddTipoEvento.TabIndex = 11;
            picAddTipoEvento.TabStop = false;
            picAddTipoEvento.Click += picAddTipoEvento_Click;
            // 
            // cbbStatus
            // 
            cbbStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbStatus.BackColor = Color.White;
            cbbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbStatus.Font = new Font("Segoe UI", 10F);
            cbbStatus.ForeColor = Color.Black;
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(540, 104);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(179, 25);
            cbbStatus.Sorted = true;
            cbbStatus.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(tableLayoutPanel3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 233);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(0, 0, 10, 0);
            panel3.Size = new Size(774, 103);
            panel3.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 196F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 207F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label11, 1, 1);
            tableLayoutPanel3.Controls.Add(label12, 1, 2);
            tableLayoutPanel3.Controls.Add(label13, 1, 3);
            tableLayoutPanel3.Controls.Add(label14, 3, 1);
            tableLayoutPanel3.Controls.Add(label15, 3, 2);
            tableLayoutPanel3.Controls.Add(lblContrato, 3, 3);
            tableLayoutPanel3.Controls.Add(txtTotalPessoa, 2, 1);
            tableLayoutPanel3.Controls.Add(txtTotalAdultos, 2, 2);
            tableLayoutPanel3.Controls.Add(txtPessoasAMais, 2, 3);
            tableLayoutPanel3.Controls.Add(txtCriancasPagantes, 4, 1);
            tableLayoutPanel3.Controls.Add(txtCriancasNaoPagantes, 4, 2);
            tableLayoutPanel3.Controls.Add(cbbContratos, 4, 3);
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
            tableLayoutPanel3.TabIndex = 3;
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
            label14.Location = new Point(272, 11);
            label14.Name = "label14";
            label14.Size = new Size(190, 19);
            label14.TabIndex = 0;
            label14.Text = "Crianças Pagantes:";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Location = new Point(272, 43);
            label15.Name = "label15";
            label15.Size = new Size(190, 19);
            label15.TabIndex = 0;
            label15.Text = "Crianças Não Pagantes:";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblContrato
            // 
            lblContrato.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblContrato.AutoSize = true;
            lblContrato.Location = new Point(272, 75);
            lblContrato.Name = "lblContrato";
            lblContrato.Size = new Size(190, 19);
            lblContrato.TabIndex = 0;
            lblContrato.Text = "Contrato Modelo:";
            lblContrato.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTotalPessoa
            // 
            txtTotalPessoa.CharacterCasing = CharacterCasing.Upper;
            txtTotalPessoa.ExibirMensagemAlerta = false;
            txtTotalPessoa.ForeColor = Color.Black;
            txtTotalPessoa.Location = new Point(198, 8);
            txtTotalPessoa.MyCasasDecimais = 2;
            txtTotalPessoa.MyColorirNegativo = true;
            txtTotalPessoa.MyForcarFormatacao = false;
            txtTotalPessoa.MyMoeda = false;
            txtTotalPessoa.MyPermitirNegativo = false;
            txtTotalPessoa.MyPermitirZerado = true;
            txtTotalPessoa.Name = "txtTotalPessoa";
            txtTotalPessoa.Size = new Size(68, 25);
            txtTotalPessoa.TabIndex = 11;
            txtTotalPessoa.TextAlign = HorizontalAlignment.Right;
            // 
            // txtTotalAdultos
            // 
            txtTotalAdultos.CharacterCasing = CharacterCasing.Upper;
            txtTotalAdultos.ExibirMensagemAlerta = false;
            txtTotalAdultos.ForeColor = Color.Black;
            txtTotalAdultos.Location = new Point(198, 40);
            txtTotalAdultos.MyCasasDecimais = 2;
            txtTotalAdultos.MyColorirNegativo = true;
            txtTotalAdultos.MyForcarFormatacao = false;
            txtTotalAdultos.MyMoeda = false;
            txtTotalAdultos.MyPermitirNegativo = false;
            txtTotalAdultos.MyPermitirZerado = true;
            txtTotalAdultos.Name = "txtTotalAdultos";
            txtTotalAdultos.Size = new Size(68, 25);
            txtTotalAdultos.TabIndex = 12;
            txtTotalAdultos.TextAlign = HorizontalAlignment.Right;
            // 
            // txtPessoasAMais
            // 
            txtPessoasAMais.CharacterCasing = CharacterCasing.Upper;
            txtPessoasAMais.ExibirMensagemAlerta = false;
            txtPessoasAMais.ForeColor = Color.Black;
            txtPessoasAMais.Location = new Point(198, 72);
            txtPessoasAMais.MyCasasDecimais = 2;
            txtPessoasAMais.MyColorirNegativo = true;
            txtPessoasAMais.MyForcarFormatacao = false;
            txtPessoasAMais.MyMoeda = false;
            txtPessoasAMais.MyPermitirNegativo = false;
            txtPessoasAMais.MyPermitirZerado = true;
            txtPessoasAMais.Name = "txtPessoasAMais";
            txtPessoasAMais.Size = new Size(68, 25);
            txtPessoasAMais.TabIndex = 13;
            txtPessoasAMais.TextAlign = HorizontalAlignment.Right;
            // 
            // txtCriancasPagantes
            // 
            txtCriancasPagantes.CharacterCasing = CharacterCasing.Upper;
            txtCriancasPagantes.ExibirMensagemAlerta = false;
            txtCriancasPagantes.ForeColor = Color.Black;
            txtCriancasPagantes.Location = new Point(468, 8);
            txtCriancasPagantes.MyCasasDecimais = 2;
            txtCriancasPagantes.MyColorirNegativo = true;
            txtCriancasPagantes.MyForcarFormatacao = false;
            txtCriancasPagantes.MyMoeda = false;
            txtCriancasPagantes.MyPermitirNegativo = false;
            txtCriancasPagantes.MyPermitirZerado = true;
            txtCriancasPagantes.Name = "txtCriancasPagantes";
            txtCriancasPagantes.Size = new Size(68, 25);
            txtCriancasPagantes.TabIndex = 14;
            txtCriancasPagantes.TextAlign = HorizontalAlignment.Right;
            // 
            // txtCriancasNaoPagantes
            // 
            txtCriancasNaoPagantes.CharacterCasing = CharacterCasing.Upper;
            txtCriancasNaoPagantes.ExibirMensagemAlerta = false;
            txtCriancasNaoPagantes.ForeColor = Color.Black;
            txtCriancasNaoPagantes.Location = new Point(468, 40);
            txtCriancasNaoPagantes.MyCasasDecimais = 2;
            txtCriancasNaoPagantes.MyColorirNegativo = true;
            txtCriancasNaoPagantes.MyForcarFormatacao = false;
            txtCriancasNaoPagantes.MyMoeda = false;
            txtCriancasNaoPagantes.MyPermitirNegativo = false;
            txtCriancasNaoPagantes.MyPermitirZerado = true;
            txtCriancasNaoPagantes.Name = "txtCriancasNaoPagantes";
            txtCriancasNaoPagantes.Size = new Size(68, 25);
            txtCriancasNaoPagantes.TabIndex = 15;
            txtCriancasNaoPagantes.TextAlign = HorizontalAlignment.Right;
            // 
            // cbbContratos
            // 
            cbbContratos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbContratos.BackColor = Color.White;
            cbbContratos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbContratos.Font = new Font("Segoe UI", 10F);
            cbbContratos.ForeColor = Color.Black;
            cbbContratos.FormattingEnabled = true;
            cbbContratos.Location = new Point(468, 72);
            cbbContratos.Name = "cbbContratos";
            cbbContratos.Size = new Size(201, 25);
            cbbContratos.Sorted = true;
            cbbContratos.TabIndex = 16;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(dtgItens);
            panel4.Controls.Add(tableLayoutPanel5);
            panel4.Controls.Add(tableLayoutPanel4);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 336);
            panel4.Name = "panel4";
            panel4.Size = new Size(427, 244);
            panel4.TabIndex = 3;
            // 
            // dtgItens
            // 
            dtgItens.BorderStyle = BorderStyle.None;
            dtgItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgItens.Dock = DockStyle.Fill;
            dtgItens.Location = new Point(0, 50);
            dtgItens.Name = "dtgItens";
            dtgItens.Size = new Size(425, 161);
            dtgItens.TabIndex = 20;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 276F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(label20, 0, 0);
            tableLayoutPanel5.Controls.Add(lblValorTotalIntens, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Bottom;
            tableLayoutPanel5.Location = new Point(0, 211);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel5.Size = new Size(425, 31);
            tableLayoutPanel5.TabIndex = 2;
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
            label20.Text = "Total de Adicionais da Festa:";
            label20.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorTotalIntens
            // 
            lblValorTotalIntens.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblValorTotalIntens.AutoSize = true;
            lblValorTotalIntens.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblValorTotalIntens.Location = new Point(279, 6);
            lblValorTotalIntens.Name = "lblValorTotalIntens";
            lblValorTotalIntens.Size = new Size(82, 19);
            lblValorTotalIntens.TabIndex = 0;
            lblValorTotalIntens.Text = "0,00";
            lblValorTotalIntens.TextAlign = ContentAlignment.MiddleRight;
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
            tableLayoutPanel4.Controls.Add(cbbItemFesta, 1, 1);
            tableLayoutPanel4.Controls.Add(label17, 1, 0);
            tableLayoutPanel4.Controls.Add(txtItemQtde, 3, 1);
            tableLayoutPanel4.Controls.Add(btnAddItem, 4, 1);
            tableLayoutPanel4.Controls.Add(txtItemValor, 2, 1);
            tableLayoutPanel4.Controls.Add(label19, 2, 0);
            tableLayoutPanel4.Controls.Add(label18, 3, 0);
            tableLayoutPanel4.Dock = DockStyle.Top;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(425, 50);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // cbbItemFesta
            // 
            cbbItemFesta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbbItemFesta.BackColor = Color.White;
            cbbItemFesta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbItemFesta.Font = new Font("Segoe UI", 10F);
            cbbItemFesta.ForeColor = Color.Black;
            cbbItemFesta.FormattingEnabled = true;
            cbbItemFesta.Location = new Point(23, 19);
            cbbItemFesta.Name = "cbbItemFesta";
            cbbItemFesta.Size = new Size(195, 25);
            cbbItemFesta.Sorted = true;
            cbbItemFesta.TabIndex = 17;
            cbbItemFesta.SelectedIndexChanged += CbbItemFesta_SelectedIndexChanged;
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
            // txtItemQtde
            // 
            txtItemQtde.CharacterCasing = CharacterCasing.Upper;
            txtItemQtde.ExibirMensagemAlerta = false;
            txtItemQtde.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtItemQtde.ForeColor = Color.Black;
            txtItemQtde.Location = new Point(299, 19);
            txtItemQtde.MyCasasDecimais = 0;
            txtItemQtde.MyColorirNegativo = false;
            txtItemQtde.MyForcarFormatacao = true;
            txtItemQtde.MyMoeda = false;
            txtItemQtde.MyPermitirNegativo = false;
            txtItemQtde.MyPermitirZerado = true;
            txtItemQtde.Name = "txtItemQtde";
            txtItemQtde.Size = new Size(69, 23);
            txtItemQtde.TabIndex = 19;
            txtItemQtde.TextAlign = HorizontalAlignment.Right;
            // 
            // btnAddItem
            // 
            btnAddItem._CorOnEnter = Color.Empty;
            btnAddItem._ImageFocus = Resources.add_iten_focus_48;
            btnAddItem.Image = Resources.add_iten_48;
            btnAddItem.Location = new Point(374, 19);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(23, 20);
            btnAddItem.SizeMode = PictureBoxSizeMode.Zoom;
            btnAddItem.TabIndex = 11;
            btnAddItem.TabStop = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // txtItemValor
            // 
            txtItemValor.CharacterCasing = CharacterCasing.Upper;
            txtItemValor.ExibirMensagemAlerta = false;
            txtItemValor.Font = new Font("Segoe UI", 9F);
            txtItemValor.ForeColor = Color.Black;
            txtItemValor.Location = new Point(224, 19);
            txtItemValor.MyCasasDecimais = 2;
            txtItemValor.MyColorirNegativo = true;
            txtItemValor.MyForcarFormatacao = true;
            txtItemValor.MyMoeda = false;
            txtItemValor.MyPermitirNegativo = false;
            txtItemValor.MyPermitirZerado = true;
            txtItemValor.Name = "txtItemValor";
            txtItemValor.Size = new Size(69, 23);
            txtItemValor.TabIndex = 18;
            txtItemValor.TextAlign = HorizontalAlignment.Right;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label19.Location = new Point(224, 0);
            label19.Name = "label19";
            label19.Size = new Size(69, 15);
            label19.TabIndex = 0;
            label19.Text = "Valor:";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label18.Location = new Point(299, 0);
            label18.Name = "label18";
            label18.Size = new Size(69, 15);
            label18.TabIndex = 0;
            label18.Text = "Qtde:";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label22.Location = new Point(22, 95);
            label22.Name = "label22";
            label22.Size = new Size(175, 19);
            label22.TabIndex = 0;
            label22.Text = "Valor Total da Festa:";
            label22.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 4;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.602649F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90.3973541F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 107F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
            tableLayoutPanel6.Controls.Add(txtDescontosFesta, 2, 3);
            tableLayoutPanel6.Controls.Add(label22, 1, 4);
            tableLayoutPanel6.Controls.Add(lblValorTotalFesta, 2, 4);
            tableLayoutPanel6.Controls.Add(label24, 1, 2);
            tableLayoutPanel6.Controls.Add(label25, 1, 3);
            tableLayoutPanel6.Controls.Add(lblValorAdicionais, 2, 2);
            tableLayoutPanel6.Controls.Add(label26, 1, 1);
            tableLayoutPanel6.Controls.Add(lblValorPacote, 2, 1);
            tableLayoutPanel6.Dock = DockStyle.Bottom;
            tableLayoutPanel6.Location = new Point(427, 452);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 6;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(347, 128);
            tableLayoutPanel6.TabIndex = 3;
            // 
            // txtDescontosFesta
            // 
            txtDescontosFesta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDescontosFesta.CharacterCasing = CharacterCasing.Upper;
            txtDescontosFesta.ExibirMensagemAlerta = false;
            txtDescontosFesta.Font = new Font("Segoe UI", 10F);
            txtDescontosFesta.ForeColor = Color.Black;
            txtDescontosFesta.Location = new Point(203, 67);
            txtDescontosFesta.MyCasasDecimais = 2;
            txtDescontosFesta.MyColorirNegativo = true;
            txtDescontosFesta.MyForcarFormatacao = false;
            txtDescontosFesta.MyMoeda = false;
            txtDescontosFesta.MyPermitirNegativo = false;
            txtDescontosFesta.MyPermitirZerado = true;
            txtDescontosFesta.Name = "txtDescontosFesta";
            txtDescontosFesta.Size = new Size(101, 25);
            txtDescontosFesta.TabIndex = 21;
            txtDescontosFesta.Text = "0";
            txtDescontosFesta.TextAlign = HorizontalAlignment.Right;
            // 
            // lblValorTotalFesta
            // 
            lblValorTotalFesta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblValorTotalFesta.AutoSize = true;
            lblValorTotalFesta.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblValorTotalFesta.Location = new Point(203, 94);
            lblValorTotalFesta.Name = "lblValorTotalFesta";
            lblValorTotalFesta.Size = new Size(101, 21);
            lblValorTotalFesta.TabIndex = 0;
            lblValorTotalFesta.Text = "0,00";
            lblValorTotalFesta.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label24.Location = new Point(22, 41);
            label24.Name = "label24";
            label24.Size = new Size(175, 19);
            label24.TabIndex = 0;
            label24.Text = "Adicionais da Festa:";
            label24.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label25.Location = new Point(22, 68);
            label25.Name = "label25";
            label25.Size = new Size(175, 19);
            label25.TabIndex = 0;
            label25.Text = "Descontos Festa:";
            label25.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorAdicionais
            // 
            lblValorAdicionais.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblValorAdicionais.AutoSize = true;
            lblValorAdicionais.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblValorAdicionais.Location = new Point(203, 40);
            lblValorAdicionais.Name = "lblValorAdicionais";
            lblValorAdicionais.Size = new Size(101, 20);
            lblValorAdicionais.TabIndex = 0;
            lblValorAdicionais.Text = "0,00";
            lblValorAdicionais.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label26.Location = new Point(22, 14);
            label26.Name = "label26";
            label26.Size = new Size(175, 19);
            label26.TabIndex = 0;
            label26.Text = "Pacote da Festa:";
            label26.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorPacote
            // 
            lblValorPacote.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblValorPacote.AutoSize = true;
            lblValorPacote.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblValorPacote.Location = new Point(203, 13);
            lblValorPacote.Name = "lblValorPacote";
            lblValorPacote.Size = new Size(101, 20);
            lblValorPacote.TabIndex = 0;
            lblValorPacote.Text = "0,00";
            lblValorPacote.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(label23, 0, 0);
            tableLayoutPanel7.Controls.Add(txtObservacao, 0, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(427, 336);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(347, 116);
            tableLayoutPanel7.TabIndex = 5;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Dock = DockStyle.Bottom;
            label23.Location = new Point(3, 1);
            label23.Name = "label23";
            label23.Size = new Size(341, 19);
            label23.TabIndex = 0;
            label23.Text = "Observação:";
            label23.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtObservacao
            // 
            txtObservacao.CharacterCasing = CharacterCasing.Upper;
            txtObservacao.Dock = DockStyle.Fill;
            txtObservacao.ExibirMensagemAlerta = false;
            txtObservacao.Location = new Point(3, 23);
            txtObservacao.Multiline = true;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(341, 90);
            txtObservacao.TabIndex = 20;
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
            ((ISupportInitialize)picAddCliente).EndInit();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((ISupportInitialize)picAddStatus).EndInit();
            ((ISupportInitialize)picAddTema).EndInit();
            ((ISupportInitialize)picAddEspaco).EndInit();
            ((ISupportInitialize)picAddPacote).EndInit();
            ((ISupportInitialize)picAddTipoEvento).EndInit();
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
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Label label3;
        private Label lblTipoEvento;
        private Label lblEspaco;
        private Label lblTema;
        private Label lblPacote;
        private Label label8;
        private Label label9;
        private Label lblStatus;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label lblContrato;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label17;
        private Label label18;
        private Label label19;
        private DataGridView dtgItens;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label20;
        private myTextBoxNumericos txtItemValor;
        private myTextBoxNumericos txtItemQtde;
        private myTextBoxNumericos txtTotalPessoa;
        private myTextBoxNumericos txtTotalAdultos;
        private myTextBoxNumericos txtPessoasAMais;
        private myTextBoxNumericos txtCriancasPagantes;
        private myTextBoxNumericos txtCriancasNaoPagantes;
        private MyFramework.myControls.myComboBox cbbTiposEvento;
        private Label lblVendedor;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label22;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label23;
        private myTextBox txtObservacao;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblCliente;
        private TableLayoutPanel tableLayoutPanel9;
        private Label label1;
        private Label lblValorTotalFesta;
        private Label label24;
        private Label label25;
        private Label lblValorAdicionais;
        private myTextBoxNumericos txtDescontosFesta;
        private MyFramework.myControls.myComboBox cbbItemFesta;
        private MyFramework.myControls.myPictureBox picAddTipoEvento;
        private MyFramework.myControls.myPictureBox btnAddItem;
        private MyFramework.myControls.myPictureBox picAddEspaco;
        private MyFramework.myControls.myPictureBox picAddTema;
        private MyFramework.myControls.myPictureBox picAddPacote;
        private MyFramework.myControls.myPictureBox picAddStatus;
        private MyFramework.myControls.myPictureBox picAddCliente;
        private Label lblValorTotalIntens;
        private Label label26;
        private Label lblValorPacote;
        private MyFramework.myControls.myComboBox cbbClientes;
        private MyFramework.myControls.myComboBox cbbEspacos;
        private MyFramework.myControls.myComboBox cbbTemas;
        private MyFramework.myControls.myComboBox cbbPacotes;
        private MyFramework.myControls.myComboBox cbbVendedor;
        private MyFramework.myControls.myComboBox cbbContratos;
        private MyFramework.myControls.myComboBox cbbStatus;
        private myTextBoxDatas txtDataFesta;
        private myTextBoxDatas txtDataVenda;
        private myTextBoxHora txtHoraFim;
        private myTextBoxHora txtHoraInicio;
    }
}