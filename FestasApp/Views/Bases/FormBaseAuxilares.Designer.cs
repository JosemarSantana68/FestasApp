namespace FestasApp.Views.Bases
{
    partial class FormBaseAuxilares
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
            myTextBox1 = new myTextBox();
            label1 = new Label();
            pnlCentral.SuspendLayout();
            ((ISupportInitialize)picLogoCrud).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Size = new Size(523, 64);
            // 
            // pnlRodape
            // 
            pnlRodape.Location = new Point(3, 161);
            pnlRodape.Size = new Size(523, 32);
            // 
            // lblOperacao
            // 
            lblOperacao.Location = new Point(379, 3);
            lblOperacao.Size = new Size(120, 58);
            lblOperacao.Text = "";
            // 
            // lblTitulo
            // 
            lblTitulo.Size = new Size(290, 58);
            lblTitulo.Text = "C a d a s t r o  A u x i l i a r e s";
            // 
            // pnlCentral
            // 
            pnlCentral.Controls.Add(tableLayoutPanel1);
            pnlCentral.Size = new Size(523, 94);
            // 
            // picLogoCrud
            // 
            picLogoCrud.Image = Resources.add;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.3892937F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.7184753F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.13783F));
            tableLayoutPanel1.Controls.Add(myTextBox1, 2, 1);
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(523, 94);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // myTextBox1
            // 
            myTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            myTextBox1.CharacterCasing = CharacterCasing.Upper;
            myTextBox1.Location = new Point(142, 34);
            myTextBox1.Name = "myTextBox1";
            myTextBox1.Size = new Size(234, 25);
            myTextBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(52, 39);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 1;
            label1.Text = "Descrição:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormBaseAuxilares
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 196);
            Name = "FormBaseAuxilares";
            Text = "FormBaseAuxilares";
            pnlCentral.ResumeLayout(false);
            ((ISupportInitialize)picLogoCrud).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private myTextBox myTextBox1;
        private Label label1;
    }
}