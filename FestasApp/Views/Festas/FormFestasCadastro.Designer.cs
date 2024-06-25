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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlContainerDetalhesFesta = new Panel();
            pnlItensFestas = new Panel();
            tblItensFestas = new TableLayoutPanel();
            lblItensFestas = new Label();
            dtgItensFestas = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            pnlDetalhesFesta = new Panel();
            tblDetalhesFestas = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lblTotalPessoa = new Label();
            lblAdultos = new Label();
            lblCriancasPagantes = new Label();
            lblCriancasNaoPagantes = new Label();
            lblHoraInicio = new Label();
            lblHoraFim = new Label();
            lblContratoModelo = new Label();
            pnlObservacao = new Panel();
            tblObservacao = new TableLayoutPanel();
            label4 = new Label();
            lblObservacaoFestas = new Label();
            pnlSeparadorBotton = new Panel();
            panel3 = new Panel();
            pnlSeparadorTop = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblNomeCliente = new Label();
            label6 = new Label();
            lblTotalFestas = new Label();
            lblPeriodoFestas = new Label();
            dtgFestas = new myDataGridView();
            lblValorTotalFestas = new Label();
            label10 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            label12 = new Label();
            label11 = new Label();
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
            pnlSeparadorTop.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)dtgFestas).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.BorderStyle = BorderStyle.FixedSingle;
            pnlRodape.Controls.Add(tableLayoutPanel2);
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
            pnlMeio.Controls.Add(dtgFestas);
            pnlMeio.Controls.Add(pnlContainerDetalhesFesta);
            pnlMeio.Size = new Size(1166, 575);
            // 
            // pnlContainerDetalhesFesta
            // 
            pnlContainerDetalhesFesta.BackColor = Color.Transparent;
            pnlContainerDetalhesFesta.Controls.Add(pnlItensFestas);
            pnlContainerDetalhesFesta.Controls.Add(pnlDetalhesFesta);
            pnlContainerDetalhesFesta.Controls.Add(pnlSeparadorBotton);
            pnlContainerDetalhesFesta.Controls.Add(pnlSeparadorTop);
            pnlContainerDetalhesFesta.Dock = DockStyle.Bottom;
            pnlContainerDetalhesFesta.Location = new Point(0, 361);
            pnlContainerDetalhesFesta.Name = "pnlContainerDetalhesFesta";
            pnlContainerDetalhesFesta.Size = new Size(1166, 214);
            pnlContainerDetalhesFesta.TabIndex = 8;
            // 
            // pnlItensFestas
            // 
            pnlItensFestas.Controls.Add(tblItensFestas);
            pnlItensFestas.Dock = DockStyle.Fill;
            pnlItensFestas.Location = new Point(631, 25);
            pnlItensFestas.Name = "pnlItensFestas";
            pnlItensFestas.Size = new Size(535, 183);
            pnlItensFestas.TabIndex = 12;
            // 
            // tblItensFestas
            // 
            tblItensFestas.ColumnCount = 2;
            tblItensFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.30189F));
            tblItensFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.6981125F));
            tblItensFestas.Controls.Add(lblItensFestas, 0, 0);
            tblItensFestas.Controls.Add(dtgItensFestas, 0, 1);
            tblItensFestas.Dock = DockStyle.Fill;
            tblItensFestas.Location = new Point(0, 0);
            tblItensFestas.Name = "tblItensFestas";
            tblItensFestas.Padding = new Padding(0, 0, 0, 5);
            tblItensFestas.RowCount = 2;
            tblItensFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tblItensFestas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblItensFestas.Size = new Size(535, 183);
            tblItensFestas.TabIndex = 0;
            // 
            // lblItensFestas
            // 
            lblItensFestas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblItensFestas.ForeColor = Color.Black;
            lblItensFestas.Location = new Point(3, 0);
            lblItensFestas.Name = "lblItensFestas";
            lblItensFestas.Size = new Size(359, 25);
            lblItensFestas.TabIndex = 3;
            lblItensFestas.Text = "Itens Adicionais da Festa:";
            lblItensFestas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtgItensFestas
            // 
            dtgItensFestas.BackgroundColor = Color.White;
            dtgItensFestas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgItensFestas.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dtgItensFestas.Dock = DockStyle.Fill;
            dtgItensFestas.Location = new Point(0, 25);
            dtgItensFestas.Margin = new Padding(0);
            dtgItensFestas.Name = "dtgItensFestas";
            dtgItensFestas.Size = new Size(365, 153);
            dtgItensFestas.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Itens";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Qtde";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Valor";
            Column3.Name = "Column3";
            // 
            // pnlDetalhesFesta
            // 
            pnlDetalhesFesta.BackColor = Color.Transparent;
            pnlDetalhesFesta.Controls.Add(tblDetalhesFestas);
            pnlDetalhesFesta.Controls.Add(pnlObservacao);
            pnlDetalhesFesta.Dock = DockStyle.Left;
            pnlDetalhesFesta.Location = new Point(0, 25);
            pnlDetalhesFesta.Name = "pnlDetalhesFesta";
            pnlDetalhesFesta.Size = new Size(631, 183);
            pnlDetalhesFesta.TabIndex = 11;
            // 
            // tblDetalhesFestas
            // 
            tblDetalhesFestas.BackColor = Color.Transparent;
            tblDetalhesFestas.ColumnCount = 6;
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 205F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 76F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 99F));
            tblDetalhesFestas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDetalhesFestas.Controls.Add(label1, 1, 1);
            tblDetalhesFestas.Controls.Add(label2, 1, 2);
            tblDetalhesFestas.Controls.Add(label3, 3, 1);
            tblDetalhesFestas.Controls.Add(label5, 3, 2);
            tblDetalhesFestas.Controls.Add(label7, 3, 4);
            tblDetalhesFestas.Controls.Add(label8, 1, 3);
            tblDetalhesFestas.Controls.Add(label9, 1, 4);
            tblDetalhesFestas.Controls.Add(lblTotalPessoa, 2, 1);
            tblDetalhesFestas.Controls.Add(lblAdultos, 2, 2);
            tblDetalhesFestas.Controls.Add(lblCriancasPagantes, 2, 3);
            tblDetalhesFestas.Controls.Add(lblCriancasNaoPagantes, 2, 4);
            tblDetalhesFestas.Controls.Add(lblHoraInicio, 4, 1);
            tblDetalhesFestas.Controls.Add(lblHoraFim, 4, 2);
            tblDetalhesFestas.Controls.Add(lblContratoModelo, 4, 4);
            tblDetalhesFestas.Dock = DockStyle.Fill;
            tblDetalhesFestas.Location = new Point(0, 0);
            tblDetalhesFestas.Name = "tblDetalhesFestas";
            tblDetalhesFestas.RowCount = 6;
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblDetalhesFestas.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDetalhesFestas.Size = new Size(631, 124);
            tblDetalhesFestas.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(53, 10);
            label1.Name = "label1";
            label1.Size = new Size(199, 19);
            label1.TabIndex = 0;
            label1.Text = "Total de Pessoas:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(53, 38);
            label2.Name = "label2";
            label2.Size = new Size(199, 19);
            label2.TabIndex = 0;
            label2.Text = "Adultos:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(334, 10);
            label3.Name = "label3";
            label3.Size = new Size(134, 19);
            label3.TabIndex = 0;
            label3.Text = "Hora Início:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(334, 38);
            label5.Name = "label5";
            label5.Size = new Size(134, 19);
            label5.TabIndex = 0;
            label5.Text = "Hora Fim:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(334, 94);
            label7.Name = "label7";
            label7.Size = new Size(134, 19);
            label7.TabIndex = 0;
            label7.Text = "Contrato Modelo:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(53, 66);
            label8.Name = "label8";
            label8.Size = new Size(199, 19);
            label8.TabIndex = 0;
            label8.Text = "Crianças Pagantes:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(53, 94);
            label9.Name = "label9";
            label9.Size = new Size(199, 19);
            label9.TabIndex = 0;
            label9.Text = "Crianças Não Pagantes:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalPessoa
            // 
            lblTotalPessoa.Anchor = AnchorStyles.Left;
            lblTotalPessoa.BackColor = Color.White;
            lblTotalPessoa.BorderStyle = BorderStyle.FixedSingle;
            lblTotalPessoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalPessoa.ForeColor = Color.Black;
            lblTotalPessoa.Location = new Point(258, 9);
            lblTotalPessoa.Name = "lblTotalPessoa";
            lblTotalPessoa.Size = new Size(55, 22);
            lblTotalPessoa.TabIndex = 0;
            lblTotalPessoa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAdultos
            // 
            lblAdultos.Anchor = AnchorStyles.Left;
            lblAdultos.BackColor = Color.White;
            lblAdultos.BorderStyle = BorderStyle.FixedSingle;
            lblAdultos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdultos.ForeColor = Color.Black;
            lblAdultos.Location = new Point(258, 37);
            lblAdultos.Name = "lblAdultos";
            lblAdultos.Size = new Size(55, 22);
            lblAdultos.TabIndex = 0;
            lblAdultos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCriancasPagantes
            // 
            lblCriancasPagantes.Anchor = AnchorStyles.Left;
            lblCriancasPagantes.BackColor = Color.White;
            lblCriancasPagantes.BorderStyle = BorderStyle.FixedSingle;
            lblCriancasPagantes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCriancasPagantes.ForeColor = Color.Black;
            lblCriancasPagantes.Location = new Point(258, 65);
            lblCriancasPagantes.Name = "lblCriancasPagantes";
            lblCriancasPagantes.Size = new Size(55, 22);
            lblCriancasPagantes.TabIndex = 0;
            lblCriancasPagantes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCriancasNaoPagantes
            // 
            lblCriancasNaoPagantes.Anchor = AnchorStyles.Left;
            lblCriancasNaoPagantes.BackColor = Color.White;
            lblCriancasNaoPagantes.BorderStyle = BorderStyle.FixedSingle;
            lblCriancasNaoPagantes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCriancasNaoPagantes.ForeColor = Color.Black;
            lblCriancasNaoPagantes.Location = new Point(258, 93);
            lblCriancasNaoPagantes.Name = "lblCriancasNaoPagantes";
            lblCriancasNaoPagantes.Size = new Size(55, 22);
            lblCriancasNaoPagantes.TabIndex = 0;
            lblCriancasNaoPagantes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.Anchor = AnchorStyles.Left;
            lblHoraInicio.BackColor = Color.White;
            lblHoraInicio.BorderStyle = BorderStyle.FixedSingle;
            lblHoraInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHoraInicio.ForeColor = Color.Black;
            lblHoraInicio.Location = new Point(474, 9);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(89, 22);
            lblHoraInicio.TabIndex = 0;
            lblHoraInicio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHoraFim
            // 
            lblHoraFim.Anchor = AnchorStyles.Left;
            lblHoraFim.BackColor = Color.White;
            lblHoraFim.BorderStyle = BorderStyle.FixedSingle;
            lblHoraFim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHoraFim.ForeColor = Color.Black;
            lblHoraFim.Location = new Point(474, 37);
            lblHoraFim.Name = "lblHoraFim";
            lblHoraFim.Size = new Size(89, 22);
            lblHoraFim.TabIndex = 0;
            lblHoraFim.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblContratoModelo
            // 
            lblContratoModelo.Anchor = AnchorStyles.Left;
            lblContratoModelo.BackColor = Color.White;
            lblContratoModelo.BorderStyle = BorderStyle.FixedSingle;
            lblContratoModelo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContratoModelo.ForeColor = Color.Black;
            lblContratoModelo.Location = new Point(474, 93);
            lblContratoModelo.Name = "lblContratoModelo";
            lblContratoModelo.Size = new Size(55, 22);
            lblContratoModelo.TabIndex = 0;
            lblContratoModelo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlObservacao
            // 
            pnlObservacao.BackColor = Color.Transparent;
            pnlObservacao.Controls.Add(tblObservacao);
            pnlObservacao.Dock = DockStyle.Bottom;
            pnlObservacao.Location = new Point(0, 124);
            pnlObservacao.Name = "pnlObservacao";
            pnlObservacao.Size = new Size(631, 59);
            pnlObservacao.TabIndex = 6;
            // 
            // tblObservacao
            // 
            tblObservacao.BackColor = Color.Transparent;
            tblObservacao.ColumnCount = 3;
            tblObservacao.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblObservacao.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 549F));
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
            tblObservacao.Size = new Size(631, 59);
            tblObservacao.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(23, 0);
            label4.Name = "label4";
            label4.Size = new Size(543, 22);
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
            lblObservacaoFestas.Location = new Point(23, 22);
            lblObservacaoFestas.Name = "lblObservacaoFestas";
            lblObservacaoFestas.Size = new Size(543, 32);
            lblObservacaoFestas.TabIndex = 0;
            // 
            // pnlSeparadorBotton
            // 
            pnlSeparadorBotton.BackColor = Color.FromArgb(26, 32, 40);
            pnlSeparadorBotton.Controls.Add(panel3);
            pnlSeparadorBotton.Dock = DockStyle.Bottom;
            pnlSeparadorBotton.Location = new Point(0, 208);
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
            // pnlSeparadorTop
            // 
            pnlSeparadorTop.BackColor = Color.FromArgb(37, 46, 59);
            pnlSeparadorTop.Controls.Add(panel2);
            pnlSeparadorTop.Controls.Add(tableLayoutPanel1);
            pnlSeparadorTop.Dock = DockStyle.Top;
            pnlSeparadorTop.Location = new Point(0, 0);
            pnlSeparadorTop.Name = "pnlSeparadorTop";
            pnlSeparadorTop.Size = new Size(1166, 25);
            pnlSeparadorTop.TabIndex = 6;
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.1882839F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.8117142F));
            tableLayoutPanel1.Controls.Add(lblNomeCliente, 1, 0);
            tableLayoutPanel1.Controls.Add(label6, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1166, 25);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.Anchor = AnchorStyles.Left;
            lblNomeCliente.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeCliente.ForeColor = Color.White;
            lblNomeCliente.Location = new Point(296, 3);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(500, 19);
            lblNomeCliente.TabIndex = 0;
            lblNomeCliente.Text = "Nome do Cliente";
            lblNomeCliente.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 3);
            label6.Name = "label6";
            label6.Size = new Size(287, 19);
            label6.TabIndex = 0;
            label6.Text = "Detalhes da Festa.:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalFestas
            // 
            lblTotalFestas.BackColor = Color.FromArgb(37, 46, 59);
            lblTotalFestas.Dock = DockStyle.Fill;
            lblTotalFestas.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblTotalFestas.ForeColor = Color.White;
            lblTotalFestas.Location = new Point(343, 39);
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
            lblPeriodoFestas.Location = new Point(123, 39);
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
            dtgFestas.BorderStyle = BorderStyle.None;
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
            dtgFestas.Location = new Point(0, 0);
            dtgFestas.MultiSelect = false;
            dtgFestas.Name = "dtgFestas";
            dtgFestas.ReadOnly = true;
            dtgFestas.RowHeadersVisible = false;
            dtgFestas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgFestas.Size = new Size(1166, 361);
            dtgFestas.TabIndex = 9;
            // 
            // lblValorTotalFestas
            // 
            lblValorTotalFestas.BackColor = Color.FromArgb(37, 46, 59);
            lblValorTotalFestas.Dock = DockStyle.Fill;
            lblValorTotalFestas.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblValorTotalFestas.ForeColor = Color.White;
            lblValorTotalFestas.Location = new Point(563, 39);
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
            label10.Location = new Point(343, 8);
            label10.Name = "label10";
            label10.Size = new Size(194, 31);
            label10.TabIndex = 0;
            label10.Text = "Total de Festas";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 11;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 199F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(lblValorTotalFestas, 5, 1);
            tableLayoutPanel2.Controls.Add(label12, 5, 0);
            tableLayoutPanel2.Controls.Add(lblTotalFestas, 3, 1);
            tableLayoutPanel2.Controls.Add(lblPeriodoFestas, 1, 1);
            tableLayoutPanel2.Controls.Add(label10, 3, 0);
            tableLayoutPanel2.Controls.Add(label11, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(0, 8, 0, 8);
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1164, 78);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label12
            // 
            label12.BackColor = Color.FromArgb(26, 32, 40);
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(563, 8);
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
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(123, 8);
            label11.Name = "label11";
            label11.Size = new Size(194, 31);
            label11.TabIndex = 2;
            label11.Text = "Período";
            label11.TextAlign = ContentAlignment.MiddleCenter;
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
            pnlSeparadorTop.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((ISupportInitialize)dtgFestas).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlContainerDetalhesFesta;
        private Panel pnlSeparadorTop;
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
        private Label label6;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblValorTotalFestas;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label10;
        private Label label12;
        private Panel panel3;
        private Panel panel2;
        private Label label11;
        private Panel pnlItensFestas;
        private TableLayoutPanel tblItensFestas;
        private Label lblItensFestas;
        private DataGridView dtgItensFestas;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
    }
}