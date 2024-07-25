namespace FestasApp.Views.Usuarios
{
    partial class FormUsuariosCadastro
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
            dtgUsuarios = new myDataGridView();
            pnlTitulo.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlMeio.SuspendLayout();
            ((ISupportInitialize)dtgUsuarios).BeginInit();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(0, 405);
            pnlRodape.Size = new Size(894, 80);
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(894, 30);
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(894, 30);
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Size = new Size(894, 80);
            // 
            // pnlTopo
            // 
            pnlTopo.Location = new Point(0, 30);
            pnlTopo.Size = new Size(894, 50);
            // 
            // pnlMeio
            // 
            pnlMeio.Controls.Add(dtgUsuarios);
            pnlMeio.Size = new Size(894, 275);
            // 
            // dtgUsuarios
            // 
            dtgUsuarios.AllowUserToAddRows = false;
            dtgUsuarios.AllowUserToDeleteRows = false;
            dtgUsuarios.AllowUserToOrderColumns = true;
            dtgUsuarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightGoldenrodYellow;
            dtgUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgUsuarios.DefaultCellStyle = dataGridViewCellStyle3;
            dtgUsuarios.Dock = DockStyle.Fill;
            dtgUsuarios.Location = new Point(0, 0);
            dtgUsuarios.MultiSelect = false;
            dtgUsuarios.Name = "dtgUsuarios";
            dtgUsuarios.ReadOnly = true;
            dtgUsuarios.RowHeadersVisible = false;
            dtgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgUsuarios.Size = new Size(894, 275);
            dtgUsuarios.TabIndex = 3;
            // 
            // FormUsuariosCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 485);
            ControlBox = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormUsuariosCadastro";
            Text = "FormUsuariosCadastro";
            pnlTitulo.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlMeio.ResumeLayout(false);
            ((ISupportInitialize)dtgUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private myDataGridView dtgUsuarios;
    }
}