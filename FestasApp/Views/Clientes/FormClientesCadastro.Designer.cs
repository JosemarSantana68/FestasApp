namespace FestasApp.Views
{
    partial class FormClientesCadastro
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblCliente = new Label();
            txtPesquisaCliente = new TextBox();
            dtgClientes = new myDataGridView();
            dtgFestasXCli = new myDataGridView();
            pnlRodape.SuspendLayout();
            pnlTitulo.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlTopo.SuspendLayout();
            pnlMeio.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)dtgClientes).BeginInit();
            ((ISupportInitialize)dtgFestasXCli).BeginInit();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(dtgFestasXCli);
            pnlRodape.Location = new Point(0, 480);
            pnlRodape.Padding = new Padding(10);
            pnlRodape.Size = new Size(945, 118);
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(945, 30);
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Size = new Size(945, 30);
            lblTitulo.Text = "Cadastro de Clientes";
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Size = new Size(945, 80);
            // 
            // pnlTopo
            // 
            pnlTopo.Controls.Add(tableLayoutPanel1);
            pnlTopo.Location = new Point(0, 30);
            pnlTopo.Size = new Size(945, 50);
            // 
            // pnlMeio
            // 
            pnlMeio.Controls.Add(dtgClientes);
            pnlMeio.Padding = new Padding(5, 0, 5, 0);
            pnlMeio.Size = new Size(945, 350);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 275F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 319F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 303F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            tableLayoutPanel1.Controls.Add(lblCliente, 1, 0);
            tableLayoutPanel1.Controls.Add(txtPesquisaCliente, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(945, 50);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCliente
            // 
            lblCliente.Anchor = AnchorStyles.Right;
            lblCliente.Location = new Point(89, 10);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(203, 29);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente :";
            lblCliente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPesquisaCliente
            // 
            txtPesquisaCliente.Anchor = AnchorStyles.Left;
            txtPesquisaCliente.CharacterCasing = CharacterCasing.Upper;
            txtPesquisaCliente.Location = new Point(298, 12);
            txtPesquisaCliente.MaxLength = 50;
            txtPesquisaCliente.Name = "txtPesquisaCliente";
            txtPesquisaCliente.PlaceholderText = "Pesquisar Nome do Cliente";
            txtPesquisaCliente.Size = new Size(298, 25);
            txtPesquisaCliente.TabIndex = 1;
            txtPesquisaCliente.TextChanged += txtPesquisaCliente_TextChanged;
            // 
            // dtgClientes
            // 
            dtgClientes.AllowUserToAddRows = false;
            dtgClientes.AllowUserToDeleteRows = false;
            dtgClientes.AllowUserToOrderColumns = true;
            dtgClientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.LightGoldenrodYellow;
            dtgClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dtgClientes.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle5.BackColor = Color.DarkGoldenrod;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dtgClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dtgClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dtgClientes.DefaultCellStyle = dataGridViewCellStyle6;
            dtgClientes.Dock = DockStyle.Fill;
            dtgClientes.Location = new Point(5, 0);
            dtgClientes.MultiSelect = false;
            dtgClientes.Name = "dtgClientes";
            dtgClientes.ReadOnly = true;
            dtgClientes.RowHeadersVisible = false;
            dtgClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgClientes.Size = new Size(935, 350);
            dtgClientes.TabIndex = 1;
            // 
            // dtgFestasXCli
            // 
            dtgFestasXCli.AllowUserToAddRows = false;
            dtgFestasXCli.AllowUserToDeleteRows = false;
            dtgFestasXCli.AllowUserToOrderColumns = true;
            dtgFestasXCli.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightGoldenrodYellow;
            dtgFestasXCli.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgFestasXCli.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgFestasXCli.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgFestasXCli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgFestasXCli.DefaultCellStyle = dataGridViewCellStyle3;
            dtgFestasXCli.Dock = DockStyle.Fill;
            dtgFestasXCli.Location = new Point(10, 10);
            dtgFestasXCli.MultiSelect = false;
            dtgFestasXCli.Name = "dtgFestasXCli";
            dtgFestasXCli.ReadOnly = true;
            dtgFestasXCli.RowHeadersVisible = false;
            dtgFestasXCli.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgFestasXCli.Size = new Size(925, 98);
            dtgFestasXCli.TabIndex = 0;
            // 
            // FormClientesCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 598);
            FormBorderStyle = FormBorderStyle.Sizable;
            Name = "FormClientesCadastro";
            Text = "FormClientesCadastro";
            Load += FormClientesCadastro_Load;
            pnlRodape.ResumeLayout(false);
            pnlTitulo.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlTopo.ResumeLayout(false);
            pnlMeio.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((ISupportInitialize)dtgClientes).EndInit();
            ((ISupportInitialize)dtgFestasXCli).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblCliente;
        private TextBox txtPesquisaCliente;
        private MyFramework.myControls.myDataGrids.myDataGridView dtgClientes;
        private myDataGridView dtgFestasXCli;
    }
}