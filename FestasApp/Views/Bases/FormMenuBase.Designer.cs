

namespace FestasApp
{
    partial class FormMenuBase
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuBase));
            PnlBarraTitulo = new Panel();
            picMinimizar = new PictureBox();
            panel3 = new Panel();
            picRestaurar = new PictureBox();
            picMaximizar = new PictureBox();
            picFechar = new PictureBox();
            btnPacotes = new Button();
            picLogo = new PictureBox();
            pnlpictMenu = new Panel();
            picMenu = new PictureBox();
            btnClientes = new Button();
            pnlBordaFestas = new Panel();
            pnlBordaPacotes = new Panel();
            pnlbtnFornecedores = new Panel();
            pnlBordaFornecedores = new Panel();
            tmSidebarTransition = new System.Windows.Forms.Timer(components);
            pnlBtnFestas = new Panel();
            pnlBordaClientes = new Panel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            picMenuBar = new PictureBox();
            pictureLogo = new PictureBox();
            TmSubMenuFinanceiroTransition = new System.Windows.Forms.Timer(components);
            timer = new System.Windows.Forms.Timer(components);
            pnlSubMenuFinanceiro = new Panel();
            btnContasPagar = new MyFramework.myControls.myButtonMenu();
            btnFinanceiro = new MyFramework.myControls.myButtonMenu();
            btnContasReceber = new MyFramework.myControls.myButtonMenu();
            pnlLogo = new Panel();
            pnlBtnMenu = new Panel();
            BarraLateralMenu = new Panel();
            flowBarraLateral = new FlowLayoutPanel();
            btnFestas = new MyFramework.myControls.myButtonMenu();
            btnCliente = new MyFramework.myControls.myButtonMenu();
            btnCalendario = new MyFramework.myControls.myButtonMenu();
            btnFornecedor = new MyFramework.myControls.myButtonMenu();
            btnPacotesFestas = new MyFramework.myControls.myButtonMenu();
            btnUsuarios = new MyFramework.myControls.myButtonMenu();
            PnlBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMinimizar).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRestaurar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlpictMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMenu).BeginInit();
            pnlbtnFornecedores.SuspendLayout();
            pnlBtnFestas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMenuBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            pnlSubMenuFinanceiro.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlBtnMenu.SuspendLayout();
            BarraLateralMenu.SuspendLayout();
            flowBarraLateral.SuspendLayout();
            SuspendLayout();
            // 
            // PnlBarraTitulo
            // 
            PnlBarraTitulo.BackColor = Color.DarkGoldenrod;
            PnlBarraTitulo.Controls.Add(picMinimizar);
            PnlBarraTitulo.Controls.Add(panel3);
            PnlBarraTitulo.Controls.Add(picFechar);
            PnlBarraTitulo.Dock = DockStyle.Top;
            PnlBarraTitulo.Location = new Point(0, 0);
            PnlBarraTitulo.Name = "PnlBarraTitulo";
            PnlBarraTitulo.Size = new Size(1169, 30);
            PnlBarraTitulo.TabIndex = 0;
            PnlBarraTitulo.MouseDown += PnlBarraTitulo_MouseDown;
            // 
            // picMinimizar
            // 
            picMinimizar.Cursor = Cursors.Hand;
            picMinimizar.Dock = DockStyle.Right;
            picMinimizar.Image = Properties.Resources.Icono_Minimizar;
            picMinimizar.Location = new Point(1079, 0);
            picMinimizar.Margin = new Padding(0);
            picMinimizar.Name = "picMinimizar";
            picMinimizar.Size = new Size(30, 30);
            picMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            picMinimizar.TabIndex = 0;
            picMinimizar.TabStop = false;
            picMinimizar.Click += PicMinimizar_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(picRestaurar);
            panel3.Controls.Add(picMaximizar);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1109, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(30, 30);
            panel3.TabIndex = 0;
            // 
            // picRestaurar
            // 
            picRestaurar.Cursor = Cursors.Hand;
            picRestaurar.Dock = DockStyle.Fill;
            picRestaurar.Image = Properties.Resources.Icono_Restaurar;
            picRestaurar.Location = new Point(0, 0);
            picRestaurar.Margin = new Padding(0);
            picRestaurar.Name = "picRestaurar";
            picRestaurar.Size = new Size(30, 30);
            picRestaurar.SizeMode = PictureBoxSizeMode.Zoom;
            picRestaurar.TabIndex = 1;
            picRestaurar.TabStop = false;
            picRestaurar.Visible = false;
            picRestaurar.Click += PicRestaurar_Click;
            // 
            // picMaximizar
            // 
            picMaximizar.Cursor = Cursors.Hand;
            picMaximizar.Dock = DockStyle.Fill;
            picMaximizar.Image = Properties.Resources.Icono_Maximizar;
            picMaximizar.Location = new Point(0, 0);
            picMaximizar.Margin = new Padding(0);
            picMaximizar.Name = "picMaximizar";
            picMaximizar.Size = new Size(30, 30);
            picMaximizar.SizeMode = PictureBoxSizeMode.Zoom;
            picMaximizar.TabIndex = 0;
            picMaximizar.TabStop = false;
            picMaximizar.Click += PicMaximizar_Click;
            // 
            // picFechar
            // 
            picFechar.Cursor = Cursors.Hand;
            picFechar.Dock = DockStyle.Right;
            picFechar.Image = Properties.Resources.Icono_cerrar_FN;
            picFechar.Location = new Point(1139, 0);
            picFechar.Margin = new Padding(0);
            picFechar.Name = "picFechar";
            picFechar.Size = new Size(30, 30);
            picFechar.SizeMode = PictureBoxSizeMode.Zoom;
            picFechar.TabIndex = 0;
            picFechar.TabStop = false;
            picFechar.Click += PicFechar_Click;
            // 
            // btnPacotes
            // 
            btnPacotes.BackColor = Color.FromArgb(26, 32, 40);
            btnPacotes.FlatAppearance.BorderSize = 0;
            btnPacotes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnPacotes.FlatStyle = FlatStyle.Flat;
            btnPacotes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPacotes.ForeColor = Color.White;
            btnPacotes.Image = Properties.Resources.icons8_confete_36;
            btnPacotes.ImageAlign = ContentAlignment.MiddleLeft;
            btnPacotes.Location = new Point(0, -16);
            btnPacotes.Name = "btnPacotes";
            btnPacotes.Padding = new Padding(20, 0, 0, 0);
            btnPacotes.Size = new Size(215, 70);
            btnPacotes.TabIndex = 8;
            btnPacotes.Text = "    Pacotes";
            btnPacotes.TextAlign = ContentAlignment.MiddleLeft;
            btnPacotes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPacotes.UseVisualStyleBackColor = false;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(0, 34);
            picLogo.Margin = new Padding(0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(220, 55);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // pnlpictMenu
            // 
            pnlpictMenu.BackColor = Color.FromArgb(26, 32, 40);
            pnlpictMenu.Controls.Add(picMenu);
            pnlpictMenu.Location = new Point(3, 3);
            pnlpictMenu.Name = "pnlpictMenu";
            pnlpictMenu.Size = new Size(215, 28);
            pnlpictMenu.TabIndex = 14;
            // 
            // picMenu
            // 
            picMenu.Cursor = Cursors.Hand;
            picMenu.Dock = DockStyle.Right;
            picMenu.Image = Properties.Resources.Mobile_Menu_Icon;
            picMenu.Location = new Point(190, 0);
            picMenu.Name = "picMenu";
            picMenu.Size = new Size(25, 28);
            picMenu.SizeMode = PictureBoxSizeMode.Zoom;
            picMenu.TabIndex = 1;
            picMenu.TabStop = false;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(26, 32, 40);
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 200);
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = Color.White;
            btnClientes.Image = Properties.Resources.pessoas_clientes_36;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(0, -14);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(20, 0, 0, 0);
            btnClientes.Size = new Size(217, 65);
            btnClientes.TabIndex = 4;
            btnClientes.Text = "    Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = false;
            // 
            // pnlBordaFestas
            // 
            pnlBordaFestas.BackColor = Color.DarkGoldenrod;
            pnlBordaFestas.Dock = DockStyle.Left;
            pnlBordaFestas.Location = new Point(0, 0);
            pnlBordaFestas.Name = "pnlBordaFestas";
            pnlBordaFestas.Size = new Size(5, 40);
            pnlBordaFestas.TabIndex = 3;
            // 
            // pnlBordaPacotes
            // 
            pnlBordaPacotes.BackColor = Color.DarkGoldenrod;
            pnlBordaPacotes.Dock = DockStyle.Left;
            pnlBordaPacotes.Location = new Point(0, 0);
            pnlBordaPacotes.Name = "pnlBordaPacotes";
            pnlBordaPacotes.Size = new Size(5, 40);
            pnlBordaPacotes.TabIndex = 3;
            // 
            // pnlbtnFornecedores
            // 
            pnlbtnFornecedores.Controls.Add(pnlBordaFornecedores);
            pnlbtnFornecedores.Location = new Point(3, 184);
            pnlbtnFornecedores.Name = "pnlbtnFornecedores";
            pnlbtnFornecedores.RightToLeft = RightToLeft.No;
            pnlbtnFornecedores.Size = new Size(217, 40);
            pnlbtnFornecedores.TabIndex = 3;
            // 
            // pnlBordaFornecedores
            // 
            pnlBordaFornecedores.BackColor = Color.DarkGoldenrod;
            pnlBordaFornecedores.Dock = DockStyle.Left;
            pnlBordaFornecedores.Location = new Point(0, 0);
            pnlBordaFornecedores.Name = "pnlBordaFornecedores";
            pnlBordaFornecedores.Size = new Size(5, 40);
            pnlBordaFornecedores.TabIndex = 3;
            // 
            // tmSidebarTransition
            // 
            tmSidebarTransition.Interval = 15;
            tmSidebarTransition.Tick += tmSidebarTransition_Tick;
            // 
            // pnlBtnFestas
            // 
            pnlBtnFestas.Controls.Add(pnlBordaFestas);
            pnlBtnFestas.Location = new Point(3, 92);
            pnlBtnFestas.Name = "pnlBtnFestas";
            pnlBtnFestas.RightToLeft = RightToLeft.No;
            pnlBtnFestas.Size = new Size(217, 40);
            pnlBtnFestas.TabIndex = 0;
            // 
            // pnlBordaClientes
            // 
            pnlBordaClientes.BackColor = Color.DarkGoldenrod;
            pnlBordaClientes.Dock = DockStyle.Left;
            pnlBordaClientes.Location = new Point(0, 0);
            pnlBordaClientes.Name = "pnlBordaClientes";
            pnlBordaClientes.Size = new Size(5, 40);
            pnlBordaClientes.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.Mobile_Menu_Icon;
            pictureBox1.Location = new Point(163, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 59);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(217, 59);
            panel1.TabIndex = 1;
            // 
            // picMenuBar
            // 
            picMenuBar.Cursor = Cursors.Hand;
            picMenuBar.Dock = DockStyle.Right;
            picMenuBar.Image = Properties.Resources.Menu3;
            picMenuBar.Location = new Point(177, 0);
            picMenuBar.Name = "picMenuBar";
            picMenuBar.Padding = new Padding(0, 0, 5, 0);
            picMenuBar.Size = new Size(43, 38);
            picMenuBar.SizeMode = PictureBoxSizeMode.Zoom;
            picMenuBar.TabIndex = 0;
            picMenuBar.TabStop = false;
            picMenuBar.Click += PicMenuBar_Click;
            // 
            // pictureLogo
            // 
            pictureLogo.Anchor = AnchorStyles.None;
            pictureLogo.Image = Properties.Resources.home_casa_36;
            pictureLogo.Location = new Point(72, 44);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(84, 50);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 0;
            pictureLogo.TabStop = false;
            // 
            // TmSubMenuFinanceiroTransition
            // 
            TmSubMenuFinanceiroTransition.Interval = 15;
            TmSubMenuFinanceiroTransition.Tick += TmSubMenuFinanceiroTransition_Tick;
            // 
            // pnlSubMenuFinanceiro
            // 
            pnlSubMenuFinanceiro.BackColor = Color.FromArgb(26, 32, 40);
            pnlSubMenuFinanceiro.Controls.Add(btnContasPagar);
            pnlSubMenuFinanceiro.Controls.Add(btnFinanceiro);
            pnlSubMenuFinanceiro.Controls.Add(btnContasReceber);
            pnlSubMenuFinanceiro.Location = new Point(0, 233);
            pnlSubMenuFinanceiro.Margin = new Padding(0, 3, 3, 0);
            pnlSubMenuFinanceiro.Name = "pnlSubMenuFinanceiro";
            pnlSubMenuFinanceiro.Size = new Size(220, 40);
            pnlSubMenuFinanceiro.TabIndex = 14;
            // 
            // btnContasPagar
            // 
            btnContasPagar._Image = Properties.Resources.cash_out_32;
            btnContasPagar.BackColor = Color.FromArgb(26, 32, 40);
            btnContasPagar.FlatAppearance.BorderSize = 0;
            btnContasPagar.FlatStyle = FlatStyle.Flat;
            btnContasPagar.ForeColor = Color.White;
            btnContasPagar.Location = new Point(9, 92);
            btnContasPagar.Margin = new Padding(0, 3, 3, 3);
            btnContasPagar.Name = "btnContasPagar";
            btnContasPagar.Padding = new Padding(50, 0, 0, 0);
            btnContasPagar.Size = new Size(211, 40);
            btnContasPagar.TabIndex = 0;
            btnContasPagar.Text = "Contas a Pagar";
            btnContasPagar.TextAlign = ContentAlignment.MiddleLeft;
            btnContasPagar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContasPagar.UseVisualStyleBackColor = false;
            // 
            // btnFinanceiro
            // 
            btnFinanceiro._Image = Properties.Resources.pasta_investimento_36;
            btnFinanceiro.BackColor = Color.FromArgb(26, 32, 40);
            btnFinanceiro.FlatAppearance.BorderSize = 0;
            btnFinanceiro.FlatStyle = FlatStyle.Flat;
            btnFinanceiro.ForeColor = Color.White;
            btnFinanceiro.Location = new Point(0, 0);
            btnFinanceiro.Margin = new Padding(0, 3, 3, 3);
            btnFinanceiro.Name = "btnFinanceiro";
            btnFinanceiro.Padding = new Padding(50, 0, 0, 0);
            btnFinanceiro.Size = new Size(220, 37);
            btnFinanceiro.TabIndex = 0;
            btnFinanceiro.Text = "Financeiro";
            btnFinanceiro.TextAlign = ContentAlignment.MiddleLeft;
            btnFinanceiro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFinanceiro.UseVisualStyleBackColor = false;
            btnFinanceiro.Click += BtnFinanceiro_Click;
            // 
            // btnContasReceber
            // 
            btnContasReceber._Image = Properties.Resources.cash_in_32;
            btnContasReceber.BackColor = Color.FromArgb(26, 32, 40);
            btnContasReceber.FlatAppearance.BorderSize = 0;
            btnContasReceber.FlatStyle = FlatStyle.Flat;
            btnContasReceber.ForeColor = Color.White;
            btnContasReceber.Location = new Point(9, 46);
            btnContasReceber.Margin = new Padding(0, 3, 3, 3);
            btnContasReceber.Name = "btnContasReceber";
            btnContasReceber.Padding = new Padding(50, 0, 0, 0);
            btnContasReceber.Size = new Size(211, 40);
            btnContasReceber.TabIndex = 0;
            btnContasReceber.Text = "Contas a Receber";
            btnContasReceber.TextAlign = ContentAlignment.MiddleLeft;
            btnContasReceber.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContasReceber.UseVisualStyleBackColor = false;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(26, 32, 40);
            pnlLogo.Controls.Add(pnlBtnMenu);
            pnlLogo.Controls.Add(pictureLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(220, 100);
            pnlLogo.TabIndex = 14;
            // 
            // pnlBtnMenu
            // 
            pnlBtnMenu.BackColor = Color.FromArgb(26, 32, 40);
            pnlBtnMenu.Controls.Add(picMenuBar);
            pnlBtnMenu.Dock = DockStyle.Top;
            pnlBtnMenu.Location = new Point(0, 0);
            pnlBtnMenu.Name = "pnlBtnMenu";
            pnlBtnMenu.Size = new Size(220, 38);
            pnlBtnMenu.TabIndex = 14;
            // 
            // BarraLateralMenu
            // 
            BarraLateralMenu.Controls.Add(flowBarraLateral);
            BarraLateralMenu.Controls.Add(pnlLogo);
            BarraLateralMenu.Dock = DockStyle.Left;
            BarraLateralMenu.Location = new Point(0, 30);
            BarraLateralMenu.Name = "BarraLateralMenu";
            BarraLateralMenu.Size = new Size(220, 555);
            BarraLateralMenu.TabIndex = 16;
            // 
            // flowBarraLateral
            // 
            flowBarraLateral.BackColor = Color.FromArgb(26, 32, 40);
            flowBarraLateral.Controls.Add(btnFestas);
            flowBarraLateral.Controls.Add(btnCliente);
            flowBarraLateral.Controls.Add(btnCalendario);
            flowBarraLateral.Controls.Add(btnFornecedor);
            flowBarraLateral.Controls.Add(btnPacotesFestas);
            flowBarraLateral.Controls.Add(pnlSubMenuFinanceiro);
            flowBarraLateral.Controls.Add(btnUsuarios);
            flowBarraLateral.Dock = DockStyle.Fill;
            flowBarraLateral.Location = new Point(0, 100);
            flowBarraLateral.Name = "flowBarraLateral";
            flowBarraLateral.Size = new Size(220, 455);
            flowBarraLateral.TabIndex = 16;
            // 
            // btnFestas
            // 
            btnFestas._Image = Properties.Resources.icons8_party_balloons_36;
            btnFestas.BackColor = Color.FromArgb(26, 32, 40);
            btnFestas.FlatAppearance.BorderSize = 0;
            btnFestas.FlatStyle = FlatStyle.Flat;
            btnFestas.ForeColor = Color.White;
            btnFestas.Location = new Point(0, 3);
            btnFestas.Margin = new Padding(0, 3, 3, 3);
            btnFestas.Name = "btnFestas";
            btnFestas.Padding = new Padding(50, 0, 0, 0);
            btnFestas.Size = new Size(220, 40);
            btnFestas.TabIndex = 0;
            btnFestas.Text = "Festas";
            btnFestas.TextAlign = ContentAlignment.MiddleLeft;
            btnFestas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFestas.UseVisualStyleBackColor = false;
            btnFestas.Click += btnFestas_Click;
            // 
            // btnCliente
            // 
            btnCliente._Image = Properties.Resources.pessoas_clientes_36;
            btnCliente.BackColor = Color.FromArgb(26, 32, 40);
            btnCliente.FlatAppearance.BorderSize = 0;
            btnCliente.FlatStyle = FlatStyle.Flat;
            btnCliente.ForeColor = Color.White;
            btnCliente.Location = new Point(0, 49);
            btnCliente.Margin = new Padding(0, 3, 3, 3);
            btnCliente.Name = "btnCliente";
            btnCliente.Padding = new Padding(50, 0, 0, 0);
            btnCliente.Size = new Size(220, 40);
            btnCliente.TabIndex = 0;
            btnCliente.Text = "Clientes";
            btnCliente.TextAlign = ContentAlignment.MiddleLeft;
            btnCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCliente.UseVisualStyleBackColor = false;
            btnCliente.Click += btnCliente_Click;
            // 
            // btnCalendario
            // 
            btnCalendario._Image = null;
            btnCalendario.BackColor = Color.FromArgb(26, 32, 40);
            btnCalendario.FlatAppearance.BorderSize = 0;
            btnCalendario.FlatStyle = FlatStyle.Flat;
            btnCalendario.ForeColor = Color.White;
            btnCalendario.Location = new Point(0, 95);
            btnCalendario.Margin = new Padding(0, 3, 3, 3);
            btnCalendario.Name = "btnCalendario";
            btnCalendario.Padding = new Padding(50, 0, 0, 0);
            btnCalendario.Size = new Size(220, 40);
            btnCalendario.TabIndex = 0;
            btnCalendario.Text = "Calendário";
            btnCalendario.TextAlign = ContentAlignment.MiddleLeft;
            btnCalendario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCalendario.UseVisualStyleBackColor = false;
            btnCalendario.Click += btnCalendario_Click;
            // 
            // btnFornecedor
            // 
            btnFornecedor._Image = Properties.Resources.pessoas_fornecedor_36;
            btnFornecedor.BackColor = Color.FromArgb(26, 32, 40);
            btnFornecedor.FlatAppearance.BorderSize = 0;
            btnFornecedor.FlatStyle = FlatStyle.Flat;
            btnFornecedor.ForeColor = Color.White;
            btnFornecedor.Location = new Point(0, 141);
            btnFornecedor.Margin = new Padding(0, 3, 3, 3);
            btnFornecedor.Name = "btnFornecedor";
            btnFornecedor.Padding = new Padding(50, 0, 0, 0);
            btnFornecedor.Size = new Size(220, 40);
            btnFornecedor.TabIndex = 0;
            btnFornecedor.Text = "Fornecedores";
            btnFornecedor.TextAlign = ContentAlignment.MiddleLeft;
            btnFornecedor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFornecedor.UseVisualStyleBackColor = false;
            btnFornecedor.Click += btnFornecedor_Click;
            // 
            // btnPacotesFestas
            // 
            btnPacotesFestas._Image = Properties.Resources.icons8_confete_36;
            btnPacotesFestas.BackColor = Color.FromArgb(26, 32, 40);
            btnPacotesFestas.FlatAppearance.BorderSize = 0;
            btnPacotesFestas.FlatStyle = FlatStyle.Flat;
            btnPacotesFestas.ForeColor = Color.White;
            btnPacotesFestas.Location = new Point(0, 187);
            btnPacotesFestas.Margin = new Padding(0, 3, 3, 3);
            btnPacotesFestas.Name = "btnPacotesFestas";
            btnPacotesFestas.Padding = new Padding(50, 0, 0, 0);
            btnPacotesFestas.Size = new Size(220, 40);
            btnPacotesFestas.TabIndex = 0;
            btnPacotesFestas.Text = "Pacotes Festas";
            btnPacotesFestas.TextAlign = ContentAlignment.MiddleLeft;
            btnPacotesFestas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPacotesFestas.UseVisualStyleBackColor = false;
            // 
            // btnUsuarios
            // 
            btnUsuarios._Image = Properties.Resources.pessoas_funcionarios_36;
            btnUsuarios.BackColor = Color.Transparent;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(0, 276);
            btnUsuarios.Margin = new Padding(0, 3, 3, 3);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(50, 0, 0, 0);
            btnUsuarios.Size = new Size(220, 40);
            btnUsuarios.TabIndex = 0;
            btnUsuarios.Text = "Usuários";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // FormMenuBase
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 585);
            Controls.Add(BarraLateralMenu);
            Controls.Add(PnlBarraTitulo);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormMenuBase";
            Text = "FormMenuBase";
            PnlBarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMinimizar).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picRestaurar).EndInit();
            ((System.ComponentModel.ISupportInitialize)picMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlpictMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMenu).EndInit();
            pnlbtnFornecedores.ResumeLayout(false);
            pnlBtnFestas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMenuBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            pnlSubMenuFinanceiro.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlBtnMenu.ResumeLayout(false);
            BarraLateralMenu.ResumeLayout(false);
            flowBarraLateral.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlBarraTitulo;
        private PictureBox picFechar;
        private PictureBox picMaximizar;
        private PictureBox picRestaurar;
        private PictureBox picMinimizar;
        private PictureBox picMenu;
        private Panel pnlBordaFestas;
        private Button btnPacotes;
        private Button btnClientes;
        private Panel pnlpictMenu;
        private PictureBox picLogo;
        private System.Windows.Forms.Timer tmSidebarTransition;
        private Panel pnlBtnFestas;
        private Panel pnlbtnFornecedores;
        private Panel pnlBordaFornecedores;
        private Panel pnlBordaPacotes;
        private Panel pnlBordaClientes;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox picMenuBar;
        private Panel pnlLogo;
        private Panel pnlBtnMenu;
        private MyFramework.myControls.myButtonMenu btnContasReceber;
        private Panel BarraLateralMenu;
        private FlowLayoutPanel flowBarraLateral;
        private MyFramework.myControls.myButtonMenu btnFestas;
        private MyFramework.myControls.myButtonMenu btnCliente;
        private MyFramework.myControls.myButtonMenu btnCalendario;
        private MyFramework.myControls.myButtonMenu btnFornecedor;
        private MyFramework.myControls.myButtonMenu btnPacotesFestas;
        private MyFramework.myControls.myButtonMenu btnUsuarios;
        private PictureBox pictureLogo;
        private System.Windows.Forms.Timer TmSubMenuFinanceiroTransition;
        private Panel panel3;
        private System.Windows.Forms.Timer timer;
        private Panel pnlSubMenuFinanceiro;
        private MyFramework.myControls.myButtonMenu btnFinanceiro;
        private MyFramework.myControls.myButtonMenu btnContasPagar;
    }
}
