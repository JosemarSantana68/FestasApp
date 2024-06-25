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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            dtgUsuarios = new MyFramework.myControls.myDataGrids.myDataGridView();
            pnlTitulo.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlMeio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgUsuarios).BeginInit();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(0, 370);
            pnlRodape.Size = new Size(681, 80);
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(681, 30);
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(681, 30);
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Size = new Size(681, 80);
            // 
            // pnlTopo
            // 
            pnlTopo.Location = new Point(0, 30);
            pnlTopo.Size = new Size(681, 50);
            // 
            // pnlMeio
            // 
            pnlMeio.Controls.Add(dtgUsuarios);
            pnlMeio.Controls.Add(label1);
            pnlMeio.Size = new Size(681, 240);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 67);
            label1.Name = "label1";
            label1.Size = new Size(75, 19);
            label1.TabIndex = 0;
            label1.Text = "USUARIOS";
            // 
            // dtgUsuarios
            // 
            dtgUsuarios.AllowUserToAddRows = false;
            dtgUsuarios.AllowUserToDeleteRows = false;
            dtgUsuarios.AllowUserToOrderColumns = true;
            dtgUsuarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.LightGoldenrodYellow;
            dtgUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dtgUsuarios.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle5.BackColor = Color.DarkGoldenrod;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dtgUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dtgUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dtgUsuarios.DefaultCellStyle = dataGridViewCellStyle6;
            dtgUsuarios.Dock = DockStyle.Fill;
            dtgUsuarios.Location = new Point(0, 0);
            dtgUsuarios.MultiSelect = false;
            dtgUsuarios.Name = "dtgUsuarios";
            dtgUsuarios.ReadOnly = true;
            dtgUsuarios.RowHeadersVisible = false;
            dtgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgUsuarios.Size = new Size(681, 240);
            dtgUsuarios.TabIndex = 1;
            // 
            // FormUsuariosCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 450);
            ControlBox = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormUsuariosCadastro";
            Text = "FormUsuariosCadastro";
            pnlTitulo.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlMeio.ResumeLayout(false);
            pnlMeio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private MyFramework.myControls.myDataGrids.myDataGridView dtgUsuarios;
    }
}