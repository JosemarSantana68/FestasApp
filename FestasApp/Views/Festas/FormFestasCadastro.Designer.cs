namespace FestasApp.Views
{
    partial class FormFestasCadastro
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlContainerDetalhesFesta = new Panel();
            pnlItensFestas = new Panel();
            tblItensFestas = new TableLayoutPanel();
            lblItensFestas = new Label();
            dtgItensFestas = new myDataGridView();
            pnlDetalhesFesta = new Panel();
            tblDetalhesFestas = new TableLayoutPanel();
            label13 = new Label();
            lblTipoEvento = new Label();
            label5 = new Label();
            lblHoraFim = new Label();
            label3 = new Label();
            lblHoraInicio = new Label();
            label15 = new Label();
            lblStatusFesta = new Label();
            label1 = new Label();
            lblTotalPessoa = new Label();
            label2 = new Label();
            lblAdultos = new Label();
            label8 = new Label();
            lblCriancasPagantes = new Label();
            lblCriancasNaoPagantes = new Label();
            label9 = new Label();
            label7 = new Label();
            lblContratoModelo = new Label();
            label14 = new Label();
            lblPessoasAMais = new Label();
            pnlObservacao = new Panel();
            tblObservacao = new TableLayoutPanel();
            label4 = new Label();
            lblObservacaoFestas = new Label();
            pnlSeparadorBotton = new Panel();
            panel3 = new Panel();
            pnlSeparadorDetalhesFestas = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblNomeCliente = new Label();
            lblDetalhesFestas = new Label();
            lblTotalFestas = new Label();
            lblPeriodoFestas = new Label();
            dtgFestas = new myDataGridView();
            lblValorTotalFestas = new Label();
            label10 = new Label();
            tblRodape = new TableLayoutPanel();
            label12 = new Label();
            label11 = new Label();
            panel4 = new Panel();
            pnlRodape.SuspendLayout();
            pnlTitulo.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlMeio.SuspendLayout();
            pnlContainerDetalhesFesta.SuspendLayout();
            pnlItensFestas.SuspendLayout();
            tblItensFestas.SuspendLayout();
            ((ISupportInitialize)dtgItensFestas).BeginInit();
            pnlDetalhesFesta.SuspendLayout();
            tblDetalhesFestas.SuspendLayout();
            pnlObservacao.SuspendLayout();
            tblObservacao.SuspendLayout();
            pnlSeparadorBotton.SuspendLayout();
            pnlSeparadorDetalhesFestas.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)dtgFestas).BeginInit();
            tblRodape.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.BorderStyle = BorderStyle.FixedSingle;
            pnlRodape.Controls.Add(tblRodape);
            pnlRodape.Location = new Point(0, 705);
            pnlRodape.Size = new Size(1166, 80);
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(1166, 30);
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(26, 32, 40);
            lblTitulo.Size = new Size(1166, 30);
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Size = new Size(1166, 80);
            // 
            // pnlTopo
            // 
            pnlTopo.Location = new Point(0, 30);
            pnlTopo.Size = new Size(1166, 50);
            // 
            // pnlMeio
            // 
            pnlMeio.BackColor = Color.Transparent;
            pnlMeio.Controls.Add(panel4);
            pnlMeio.Controls.Add(pnlContainerDetalhesFesta);
            pnlMeio.Size = new Size(1166, 575);
            // 
            // pnlContainerDetalhesFesta
            // 
            pnlContainerDetalhesFesta.BackColor = Color.Transparent;
            pnlContainerDetalhesFesta.Controls.Add(pnlItensFestas);
            pnlContainerDetalhesFesta.Controls.Add(pnlDetalhesFesta);
            pnlContainerDetalhesFesta.Controls.Add(pnlSeparadorBotton);
            pnlContainerDetalhesFesta.Controls.Add(pnlSeparadorDetalhesFestas);
            pnlContainerDetalhesFesta.Dock = DockStyle.Bottom;
            pnlContainerDetalhesFesta.Location = new Point(0, 281);
            pnlContainerDetalhesFesta.Name = "pnlContainerDetalhesFesta";
            pnlContainerDetalhesFesta.Size = new Size(1166, 294);
            pnlContainerDetalhesFesta.TabIndex = 8;
            // 
            // pnlItensFestas
            // 
            pnlItensFestas.Controls.Add(tblItensFestas);
            pnlItensFestas.Dock = DockStyle.Fill;
            pnlItensFestas.Location = new Point(610, 25);
            pnlItensFestas.Name = "pnlItensFestas";
            pnlItensFestas.Size = new Size(556, 263);
            pnlItensFestas.TabIndex = 12;
            // 
            // tblItensFestas
            // 
            tblItensFestas.ColumnCount = 2;
            tblItensFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 360F));
            tblItensFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblItensFestas.Controls.Add(lblItensFestas, 0, 0);
            tblItensFestas.Controls.Add(dtgItensFestas, 0, 1);
            tblItensFestas.Dock = DockStyle.Fill;
            tblItensFestas.Location = new Point(0, 0);
            tblItensFestas.Name = "tblItensFestas";
            tblItensFestas.Padding = new Padding(0, 0, 0, 5);
            tblItensFestas.RowCount = 3;
            tblItensFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tblItensFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tblItensFestas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblItensFestas.Size = new Size(556, 263);
            tblItensFestas.TabIndex = 0;
            // 
            // lblItensFestas
            // 
            lblItensFestas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblItensFestas.ForeColor = Color.Black;
            lblItensFestas.Location = new Point(3, 0);
            lblItensFestas.Name = "lblItensFestas";
            lblItensFestas.Size = new Size(354, 25);
            lblItensFestas.TabIndex = 3;
            lblItensFestas.Text = "Itens Adicionais da Festa:";
            lblItensFestas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtgItensFestas
            // 
            dtgItensFestas.AllowUserToAddRows = false;
            dtgItensFestas.AllowUserToDeleteRows = false;
            dtgItensFestas.AllowUserToOrderColumns = true;
            dtgItensFestas.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.LightGoldenrodYellow;
            dtgItensFestas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dtgItensFestas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dtgItensFestas.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle5.BackColor = Color.DarkGoldenrod;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dtgItensFestas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dtgItensFestas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dtgItensFestas.DefaultCellStyle = dataGridViewCellStyle6;
            dtgItensFestas.Location = new Point(3, 28);
            dtgItensFestas.MultiSelect = false;
            dtgItensFestas.Name = "dtgItensFestas";
            dtgItensFestas.ReadOnly = true;
            dtgItensFestas.RowHeadersVisible = false;
            dtgItensFestas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgItensFestas.Size = new Size(354, 66);
            dtgItensFestas.TabIndex = 4;
            dtgItensFestas.TabStop = false;
            // 
            // pnlDetalhesFesta
            // 
            pnlDetalhesFesta.BackColor = Color.Transparent;
            pnlDetalhesFesta.Controls.Add(tblDetalhesFestas);
            pnlDetalhesFesta.Controls.Add(pnlObservacao);
            pnlDetalhesFesta.Dock = DockStyle.Left;
            pnlDetalhesFesta.Location = new Point(0, 25);
            pnlDetalhesFesta.Name = "pnlDetalhesFesta";
            pnlDetalhesFesta.Size = new Size(610, 263);
            pnlDetalhesFesta.TabIndex = 11;
            // 
            // tblDetalhesFestas
            // 
            tblDetalhesFestas.BackColor = Color.Transparent;
            tblDetalhesFestas.ColumnCount = 6;
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 174F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 151F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 191F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDetalhesFestas.Controls.Add(label13, 1, 1);
            tblDetalhesFestas.Controls.Add(lblTipoEvento, 2, 1);
            tblDetalhesFestas.Controls.Add(label5, 1, 4);
            tblDetalhesFestas.Controls.Add(lblHoraFim, 2, 4);
            tblDetalhesFestas.Controls.Add(label3, 1, 3);
            tblDetalhesFestas.Controls.Add(lblHoraInicio, 2, 3);
            tblDetalhesFestas.Controls.Add(label15, 1, 2);
            tblDetalhesFestas.Controls.Add(lblStatusFesta, 2, 2);
            tblDetalhesFestas.Controls.Add(label1, 3, 1);
            tblDetalhesFestas.Controls.Add(lblTotalPessoa, 4, 1);
            tblDetalhesFestas.Controls.Add(label2, 3, 2);
            tblDetalhesFestas.Controls.Add(lblAdultos, 4, 2);
            tblDetalhesFestas.Controls.Add(label8, 3, 3);
            tblDetalhesFestas.Controls.Add(lblCriancasPagantes, 4, 3);
            tblDetalhesFestas.Controls.Add(lblCriancasNaoPagantes, 4, 4);
            tblDetalhesFestas.Controls.Add(label9, 3, 4);
            tblDetalhesFestas.Controls.Add(label7, 1, 5);
            tblDetalhesFestas.Controls.Add(lblContratoModelo, 2, 5);
            tblDetalhesFestas.Controls.Add(label14, 3, 5);
            tblDetalhesFestas.Controls.Add(lblPessoasAMais, 4, 5);
            tblDetalhesFestas.Dock = DockStyle.Fill;
            tblDetalhesFestas.Location = new Point(0, 0);
            tblDetalhesFestas.Name = "tblDetalhesFestas";
            tblDetalhesFestas.RowCount = 7;
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblDetalhesFestas.Size = new Size(610, 175);
            tblDetalhesFestas.TabIndex = 0;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.ForeColor = Color.Black;
            label13.Location = new Point(18, 19);
            label13.Name = "label13";
            label13.Size = new Size(168, 19);
            label13.TabIndex = 0;
            label13.Text = "Tipo de Evento:";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTipoEvento
            // 
            lblTipoEvento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTipoEvento.BackColor = Color.White;
            lblTipoEvento.BorderStyle = BorderStyle.FixedSingle;
            lblTipoEvento.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTipoEvento.ForeColor = Color.Black;
            lblTipoEvento.Location = new Point(192, 18);
            lblTipoEvento.Name = "lblTipoEvento";
            lblTipoEvento.Size = new Size(145, 22);
            lblTipoEvento.TabIndex = 0;
            lblTipoEvento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(18, 103);
            label5.Name = "label5";
            label5.Size = new Size(168, 19);
            label5.TabIndex = 0;
            label5.Text = "Hora Fim:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHoraFim
            // 
            lblHoraFim.Anchor = AnchorStyles.Left;
            lblHoraFim.BackColor = Color.White;
            lblHoraFim.BorderStyle = BorderStyle.FixedSingle;
            lblHoraFim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHoraFim.ForeColor = Color.Black;
            lblHoraFim.Location = new Point(192, 102);
            lblHoraFim.Name = "lblHoraFim";
            lblHoraFim.Size = new Size(89, 22);
            lblHoraFim.TabIndex = 0;
            lblHoraFim.Text = "00:00";
            lblHoraFim.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(18, 75);
            label3.Name = "label3";
            label3.Size = new Size(168, 19);
            label3.TabIndex = 0;
            label3.Text = "Hora Início:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.Anchor = AnchorStyles.Left;
            lblHoraInicio.BackColor = Color.White;
            lblHoraInicio.BorderStyle = BorderStyle.FixedSingle;
            lblHoraInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHoraInicio.ForeColor = Color.Black;
            lblHoraInicio.Location = new Point(192, 74);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(89, 22);
            lblHoraInicio.TabIndex = 0;
            lblHoraInicio.Text = "00:00";
            lblHoraInicio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.ForeColor = Color.Black;
            label15.Location = new Point(18, 47);
            label15.Name = "label15";
            label15.Size = new Size(168, 19);
            label15.TabIndex = 0;
            label15.Text = "Status da Festa:";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStatusFesta
            // 
            lblStatusFesta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblStatusFesta.BackColor = Color.White;
            lblStatusFesta.BorderStyle = BorderStyle.FixedSingle;
            lblStatusFesta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatusFesta.ForeColor = Color.Black;
            lblStatusFesta.Location = new Point(192, 46);
            lblStatusFesta.Name = "lblStatusFesta";
            lblStatusFesta.Size = new Size(145, 22);
            lblStatusFesta.TabIndex = 0;
            lblStatusFesta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(343, 19);
            label1.Name = "label1";
            label1.Size = new Size(185, 19);
            label1.TabIndex = 0;
            label1.Text = "Total de Pessoas:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalPessoa
            // 
            lblTotalPessoa.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblTotalPessoa.BackColor = Color.White;
            lblTotalPessoa.BorderStyle = BorderStyle.FixedSingle;
            lblTotalPessoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalPessoa.ForeColor = Color.Black;
            lblTotalPessoa.Location = new Point(534, 18);
            lblTotalPessoa.Name = "lblTotalPessoa";
            lblTotalPessoa.Size = new Size(46, 22);
            lblTotalPessoa.TabIndex = 0;
            lblTotalPessoa.Text = "000";
            lblTotalPessoa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(343, 47);
            label2.Name = "label2";
            label2.Size = new Size(185, 19);
            label2.TabIndex = 0;
            label2.Text = "Adultos:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAdultos
            // 
            lblAdultos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblAdultos.BackColor = Color.White;
            lblAdultos.BorderStyle = BorderStyle.FixedSingle;
            lblAdultos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdultos.ForeColor = Color.Black;
            lblAdultos.Location = new Point(534, 46);
            lblAdultos.Name = "lblAdultos";
            lblAdultos.Size = new Size(46, 22);
            lblAdultos.TabIndex = 0;
            lblAdultos.Text = "000";
            lblAdultos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(343, 75);
            label8.Name = "label8";
            label8.Size = new Size(185, 19);
            label8.TabIndex = 0;
            label8.Text = "Crianças Pagantes:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCriancasPagantes
            // 
            lblCriancasPagantes.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCriancasPagantes.BackColor = Color.White;
            lblCriancasPagantes.BorderStyle = BorderStyle.FixedSingle;
            lblCriancasPagantes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCriancasPagantes.ForeColor = Color.Black;
            lblCriancasPagantes.Location = new Point(534, 74);
            lblCriancasPagantes.Name = "lblCriancasPagantes";
            lblCriancasPagantes.Size = new Size(46, 22);
            lblCriancasPagantes.TabIndex = 0;
            lblCriancasPagantes.Text = "000";
            lblCriancasPagantes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCriancasNaoPagantes
            // 
            lblCriancasNaoPagantes.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCriancasNaoPagantes.BackColor = Color.White;
            lblCriancasNaoPagantes.BorderStyle = BorderStyle.FixedSingle;
            lblCriancasNaoPagantes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCriancasNaoPagantes.ForeColor = Color.Black;
            lblCriancasNaoPagantes.Location = new Point(534, 102);
            lblCriancasNaoPagantes.Name = "lblCriancasNaoPagantes";
            lblCriancasNaoPagantes.Size = new Size(46, 22);
            lblCriancasNaoPagantes.TabIndex = 0;
            lblCriancasNaoPagantes.Text = "000";
            lblCriancasNaoPagantes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(343, 103);
            label9.Name = "label9";
            label9.Size = new Size(185, 19);
            label9.TabIndex = 0;
            label9.Text = "Crianças Não Pagantes:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(18, 131);
            label7.Name = "label7";
            label7.Size = new Size(168, 19);
            label7.TabIndex = 0;
            label7.Text = "Contrato Modelo:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblContratoModelo
            // 
            lblContratoModelo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblContratoModelo.BackColor = Color.White;
            lblContratoModelo.BorderStyle = BorderStyle.FixedSingle;
            lblContratoModelo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContratoModelo.ForeColor = Color.Black;
            lblContratoModelo.Location = new Point(192, 130);
            lblContratoModelo.Name = "lblContratoModelo";
            lblContratoModelo.Size = new Size(145, 22);
            lblContratoModelo.TabIndex = 0;
            lblContratoModelo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.ForeColor = Color.Black;
            label14.Location = new Point(343, 131);
            label14.Name = "label14";
            label14.Size = new Size(185, 19);
            label14.TabIndex = 0;
            label14.Text = "Pessoas a Mais:";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPessoasAMais
            // 
            lblPessoasAMais.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblPessoasAMais.BackColor = Color.White;
            lblPessoasAMais.BorderStyle = BorderStyle.FixedSingle;
            lblPessoasAMais.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPessoasAMais.ForeColor = Color.Black;
            lblPessoasAMais.Location = new Point(534, 130);
            lblPessoasAMais.Name = "lblPessoasAMais";
            lblPessoasAMais.Size = new Size(46, 22);
            lblPessoasAMais.TabIndex = 0;
            lblPessoasAMais.Text = "000";
            lblPessoasAMais.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlObservacao
            // 
            pnlObservacao.BackColor = Color.Transparent;
            pnlObservacao.Controls.Add(tblObservacao);
            pnlObservacao.Dock = DockStyle.Bottom;
            pnlObservacao.Location = new Point(0, 175);
            pnlObservacao.Name = "pnlObservacao";
            pnlObservacao.Size = new Size(610, 88);
            pnlObservacao.TabIndex = 6;
            // 
            // tblObservacao
            // 
            tblObservacao.BackColor = Color.Transparent;
            tblObservacao.ColumnCount = 3;
            tblObservacao.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
            tblObservacao.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 569F));
            tblObservacao.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblObservacao.Controls.Add(label4, 1, 0);
            tblObservacao.Controls.Add(lblObservacaoFestas, 1, 1);
            tblObservacao.Dock = DockStyle.Fill;
            tblObservacao.Location = new Point(0, 0);
            tblObservacao.Name = "tblObservacao";
            tblObservacao.Padding = new Padding(0, 0, 0, 5);
            tblObservacao.RowCount = 2;
            tblObservacao.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tblObservacao.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblObservacao.Size = new Size(610, 88);
            tblObservacao.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(18, 0);
            label4.Name = "label4";
            label4.Size = new Size(563, 22);
            label4.TabIndex = 0;
            label4.Text = "Observação:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblObservacaoFestas
            // 
            lblObservacaoFestas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblObservacaoFestas.BackColor = Color.White;
            lblObservacaoFestas.BorderStyle = BorderStyle.FixedSingle;
            lblObservacaoFestas.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObservacaoFestas.ForeColor = Color.Black;
            lblObservacaoFestas.Location = new Point(18, 22);
            lblObservacaoFestas.Name = "lblObservacaoFestas";
            lblObservacaoFestas.Size = new Size(563, 61);
            lblObservacaoFestas.TabIndex = 0;
            // 
            // pnlSeparadorBotton
            // 
            pnlSeparadorBotton.BackColor = Color.FromArgb(26, 32, 40);
            pnlSeparadorBotton.Controls.Add(panel3);
            pnlSeparadorBotton.Dock = DockStyle.Bottom;
            pnlSeparadorBotton.Location = new Point(0, 288);
            pnlSeparadorBotton.Name = "pnlSeparadorBotton";
            pnlSeparadorBotton.Size = new Size(1166, 6);
            pnlSeparadorBotton.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkGoldenrod;
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 6);
            panel3.TabIndex = 2;
            // 
            // pnlSeparadorDetalhesFestas
            // 
            pnlSeparadorDetalhesFestas.BackColor = Color.FromArgb(37, 46, 59);
            pnlSeparadorDetalhesFestas.Controls.Add(panel2);
            pnlSeparadorDetalhesFestas.Controls.Add(tableLayoutPanel1);
            pnlSeparadorDetalhesFestas.Dock = DockStyle.Top;
            pnlSeparadorDetalhesFestas.Location = new Point(0, 0);
            pnlSeparadorDetalhesFestas.Name = "pnlSeparadorDetalhesFestas";
            pnlSeparadorDetalhesFestas.Size = new Size(1166, 25);
            pnlSeparadorDetalhesFestas.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkGoldenrod;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(5, 25);
            panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(26, 32, 40);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblNomeCliente, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDetalhesFestas, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1166, 25);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.Anchor = AnchorStyles.Left;
            lblNomeCliente.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeCliente.ForeColor = Color.White;
            lblNomeCliente.Location = new Point(193, 3);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(500, 19);
            lblNomeCliente.TabIndex = 0;
            lblNomeCliente.Text = "Nome do Cliente";
            lblNomeCliente.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDetalhesFestas
            // 
            lblDetalhesFestas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblDetalhesFestas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetalhesFestas.ForeColor = Color.White;
            lblDetalhesFestas.Location = new Point(3, 3);
            lblDetalhesFestas.Name = "lblDetalhesFestas";
            lblDetalhesFestas.Size = new Size(184, 19);
            lblDetalhesFestas.TabIndex = 0;
            lblDetalhesFestas.Text = "Detalhes da Festa.:";
            lblDetalhesFestas.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalFestas
            // 
            lblTotalFestas.BackColor = Color.FromArgb(37, 46, 59);
            lblTotalFestas.Dock = DockStyle.Fill;
            lblTotalFestas.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblTotalFestas.ForeColor = Color.White;
            lblTotalFestas.Location = new Point(303, 39);
            lblTotalFestas.Name = "lblTotalFestas";
            lblTotalFestas.Size = new Size(194, 31);
            lblTotalFestas.TabIndex = 0;
            lblTotalFestas.Text = "0";
            lblTotalFestas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPeriodoFestas
            // 
            lblPeriodoFestas.BackColor = Color.FromArgb(37, 46, 59);
            lblPeriodoFestas.Dock = DockStyle.Fill;
            lblPeriodoFestas.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblPeriodoFestas.ForeColor = Color.White;
            lblPeriodoFestas.Location = new Point(83, 39);
            lblPeriodoFestas.Name = "lblPeriodoFestas";
            lblPeriodoFestas.Size = new Size(194, 31);
            lblPeriodoFestas.TabIndex = 0;
            lblPeriodoFestas.Text = "lblPeriodoFestas";
            lblPeriodoFestas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtgFestas
            // 
            dtgFestas.AllowUserToAddRows = false;
            dtgFestas.AllowUserToDeleteRows = false;
            dtgFestas.AllowUserToOrderColumns = true;
            dtgFestas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightGoldenrodYellow;
            dtgFestas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgFestas.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = Color.DarkGoldenrod;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgFestas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgFestas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgFestas.DefaultCellStyle = dataGridViewCellStyle3;
            dtgFestas.Dock = DockStyle.Fill;
            dtgFestas.Location = new Point(5, 0);
            dtgFestas.MultiSelect = false;
            dtgFestas.Name = "dtgFestas";
            dtgFestas.ReadOnly = true;
            dtgFestas.RowHeadersVisible = false;
            dtgFestas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgFestas.Size = new Size(1156, 276);
            dtgFestas.TabIndex = 9;
            // 
            // lblValorTotalFestas
            // 
            lblValorTotalFestas.BackColor = Color.FromArgb(37, 46, 59);
            lblValorTotalFestas.Dock = DockStyle.Fill;
            lblValorTotalFestas.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblValorTotalFestas.ForeColor = Color.White;
            lblValorTotalFestas.Location = new Point(523, 39);
            lblValorTotalFestas.Name = "lblValorTotalFestas";
            lblValorTotalFestas.Size = new Size(194, 31);
            lblValorTotalFestas.TabIndex = 0;
            lblValorTotalFestas.Text = "0,00";
            lblValorTotalFestas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(26, 32, 40);
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(303, 8);
            label10.Name = "label10";
            label10.Size = new Size(194, 31);
            label10.TabIndex = 0;
            label10.Text = "Total de Festas";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblRodape
            // 
            tblRodape.ColumnCount = 11;
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 199F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRodape.Controls.Add(lblValorTotalFestas, 5, 1);
            tblRodape.Controls.Add(label12, 5, 0);
            tblRodape.Controls.Add(lblTotalFestas, 3, 1);
            tblRodape.Controls.Add(lblPeriodoFestas, 1, 1);
            tblRodape.Controls.Add(label10, 3, 0);
            tblRodape.Controls.Add(label11, 1, 0);
            tblRodape.Dock = DockStyle.Fill;
            tblRodape.Location = new Point(0, 0);
            tblRodape.Margin = new Padding(0);
            tblRodape.Name = "tblRodape";
            tblRodape.Padding = new Padding(0, 8, 0, 8);
            tblRodape.RowCount = 2;
            tblRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRodape.Size = new Size(1164, 78);
            tblRodape.TabIndex = 0;
            // 
            // label12
            // 
            label12.BackColor = Color.FromArgb(26, 32, 40);
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(523, 8);
            label12.Name = "label12";
            label12.Size = new Size(194, 31);
            label12.TabIndex = 2;
            label12.Text = "Valor Total de Festas";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.BackColor = Color.FromArgb(26, 32, 40);
            label11.Dock = DockStyle.Fill;
            label11.FlatStyle = FlatStyle.Flat;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(83, 8);
            label11.Name = "label11";
            label11.Size = new Size(194, 31);
            label11.TabIndex = 2;
            label11.Text = "Período";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(dtgFestas);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5, 0, 5, 5);
            panel4.Size = new Size(1166, 281);
            panel4.TabIndex = 10;
            // 
            // FormFestasCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 785);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormFestasCadastro";
            Text = "FormFestas";
            pnlRodape.ResumeLayout(false);
            pnlTitulo.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlMeio.ResumeLayout(false);
            pnlContainerDetalhesFesta.ResumeLayout(false);
            pnlItensFestas.ResumeLayout(false);
            tblItensFestas.ResumeLayout(false);
            ((ISupportInitialize)dtgItensFestas).EndInit();
            pnlDetalhesFesta.ResumeLayout(false);
            tblDetalhesFestas.ResumeLayout(false);
            tblDetalhesFestas.PerformLayout();
            pnlObservacao.ResumeLayout(false);
            tblObservacao.ResumeLayout(false);
            pnlSeparadorBotton.ResumeLayout(false);
            pnlSeparadorDetalhesFestas.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((ISupportInitialize)dtgFestas).EndInit();
            tblRodape.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlContainerDetalhesFesta;
        private Panel pnlSeparadorDetalhesFestas;
        private Panel pnlSeparadorBotton;
        private Label lblTotalFestas;
        private Label lblPeriodoFestas;
        private Panel pnlDetalhesFesta;
        private TableLayoutPanel tblDetalhesFestas;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblTotalPessoa;
        private Label lblAdultos;
        private Label lblCriancasPagantes;
        private Label lblCriancasNaoPagantes;
        private Label lblHoraInicio;
        private Label lblHoraFim;
        private Label lblContratoModelo;
        private Panel pnlObservacao;
        private TableLayoutPanel tblObservacao;
        private Label label4;
        private Label lblObservacaoFestas;
        private myDataGridView dtgFestas;
        private Label lblNomeCliente;
        private Label lblDetalhesFestas;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblValorTotalFestas;
        private TableLayoutPanel tblRodape;
        private Label label10;
        private Label label12;
        private Panel panel3;
        private Panel panel2;
        private Label label11;
        private Panel pnlItensFestas;
        private TableLayoutPanel tblItensFestas;
        private Label lblItensFestas;
        private myDataGridView dtgItensFestas;
        private Label label13;
        private Label lblStatusFesta;
        private Label label15;
        private Label lblTipoEvento;
        private Label label14;
        private Label lblPessoasAMais;
        private Panel panel4;
    }
}