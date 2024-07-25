namespace FestasApp.Views.TabelasAuxiliares
{
    partial class FormAuxiliaresMain
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
            dtgTabelasAuxiliares = new DataGridView();
            dtgRegistrosTabelasAuxiliares = new myDataGridView();
            pnlTitulo.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlMeio.SuspendLayout();
            ((ISupportInitialize)dtgTabelasAuxiliares).BeginInit();
            ((ISupportInitialize)dtgRegistrosTabelasAuxiliares).BeginInit();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(0, 514);
            pnlRodape.Size = new Size(1147, 80);
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(1147, 34);
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(1147, 34);
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Margin = new Padding(0);
            pnlCabecalho.Size = new Size(1147, 80);
            // 
            // pnlTopo
            // 
            pnlTopo.Margin = new Padding(0);
            pnlTopo.Size = new Size(1147, 46);
            // 
            // pnlMeio
            // 
            pnlMeio.BackColor = Color.White;
            pnlMeio.Controls.Add(dtgRegistrosTabelasAuxiliares);
            pnlMeio.Controls.Add(dtgTabelasAuxiliares);
            pnlMeio.Size = new Size(1147, 384);
            // 
            // dtgTabelasAuxiliares
            // 
            dtgTabelasAuxiliares.BackgroundColor = Color.Gray;
            dtgTabelasAuxiliares.BorderStyle = BorderStyle.None;
            dtgTabelasAuxiliares.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgTabelasAuxiliares.Dock = DockStyle.Left;
            dtgTabelasAuxiliares.Location = new Point(0, 0);
            dtgTabelasAuxiliares.Name = "dtgTabelasAuxiliares";
            dtgTabelasAuxiliares.Size = new Size(200, 384);
            dtgTabelasAuxiliares.TabIndex = 2;
            // 
            // dtgRegistrosTabelasAuxiliares
            // 
            dtgRegistrosTabelasAuxiliares.AllowUserToAddRows = false;
            dtgRegistrosTabelasAuxiliares.AllowUserToDeleteRows = false;
            dtgRegistrosTabelasAuxiliares.AllowUserToOrderColumns = true;
            dtgRegistrosTabelasAuxiliares.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightGoldenrodYellow;
            dtgRegistrosTabelasAuxiliares.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgRegistrosTabelasAuxiliares.BackgroundColor = Color.Silver;
            dtgRegistrosTabelasAuxiliares.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = Color.DarkGoldenrod;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgRegistrosTabelasAuxiliares.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgRegistrosTabelasAuxiliares.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgRegistrosTabelasAuxiliares.DefaultCellStyle = dataGridViewCellStyle3;
            dtgRegistrosTabelasAuxiliares.Dock = DockStyle.Left;
            dtgRegistrosTabelasAuxiliares.Location = new Point(200, 0);
            dtgRegistrosTabelasAuxiliares.MultiSelect = false;
            dtgRegistrosTabelasAuxiliares.Name = "dtgRegistrosTabelasAuxiliares";
            dtgRegistrosTabelasAuxiliares.ReadOnly = true;
            dtgRegistrosTabelasAuxiliares.RowHeadersVisible = false;
            dtgRegistrosTabelasAuxiliares.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgRegistrosTabelasAuxiliares.Size = new Size(600, 384);
            dtgRegistrosTabelasAuxiliares.TabIndex = 5;
            // 
            // FormAuxiliaresMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 594);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormAuxiliaresMain";
            Text = "FormAuxiliaresMain";
            pnlTitulo.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlMeio.ResumeLayout(false);
            ((ISupportInitialize)dtgTabelasAuxiliares).EndInit();
            ((ISupportInitialize)dtgRegistrosTabelasAuxiliares).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public DataGridView dtgTabelasAuxiliares;
        public myDataGridView dtgRegistrosTabelasAuxiliares;
    }
}