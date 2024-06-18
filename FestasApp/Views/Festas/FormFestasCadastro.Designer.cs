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
            dtgFestas = new MyFramework.myControls.myDataGridView();
            pnlTitulo.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlMeio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgFestas).BeginInit();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(0, 370);
            pnlRodape.Size = new Size(800, 80);
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(800, 30);
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(800, 30);
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Size = new Size(800, 80);
            // 
            // pnlTopo
            // 
            pnlTopo.Location = new Point(0, 30);
            pnlTopo.Size = new Size(800, 50);
            // 
            // pnlMeio
            // 
            pnlMeio.BackColor = Color.White;
            pnlMeio.Controls.Add(dtgFestas);
            pnlMeio.Size = new Size(800, 240);
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
            dtgFestas.Location = new Point(0, 0);
            dtgFestas.MultiSelect = false;
            dtgFestas.Name = "dtgFestas";
            dtgFestas.ReadOnly = true;
            dtgFestas.RowHeadersVisible = false;
            dtgFestas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgFestas.Size = new Size(800, 240);
            dtgFestas.TabIndex = 0;
            // 
            // FormFestasCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormFestasCadastro";
            Text = "FormFestas";
            pnlTitulo.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlMeio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgFestas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MyFramework.myControls.myDataGridView dtgFestas;
    }
}