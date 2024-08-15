

using MyFramework.myControls.myButtons;

namespace FestasApp
{
    partial class FormMenuMain
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormMenuMain));
            PnlBarraTitulo = new Panel();
            pictureBox2 = new PictureBox();
            picMinimizar = new PictureBox();
            pnlMaxRest = new Panel();
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
            pictureLogoHome = new PictureBox();
            TmSubMenuFinanceiroTransition = new System.Windows.Forms.Timer(components);
            btnContasPagar = new myButtonMenu();
            btnFinanceiro = new myButtonMenu();
            btnContasReceber = new myButtonMenu();
            pnlTopoLogo = new Panel();
            pnlLogoHome = new Panel();
            pnlBtnMenuBar = new Panel();
            pnlBarraLateralMenu = new Panel();
            flowBarraLateral = new FlowLayoutPanel();
            btnFestas = new myButtonMenu();
            btnCliente = new myButtonMenu();
            btnCalendario = new myButtonMenu();
            btnFornecedor = new myButtonMenu();
            btnPacotesFestas = new myButtonMenu();
            ContainerSubFinanceiro = new FlowLayoutPanel();
            btnUsuarios = new myButtonMenu();
            btnRelatorios = new myButtonMenu();
            pnlStatusRodape = new Panel();
            lblStatusConn = new Label();
            PnlBarraTitulo.SuspendLayout();
            ((ISupportInitialize)pictureBox2).BeginInit();
            ((ISupportInitialize)picMinimizar).BeginInit();
            pnlMaxRest.SuspendLayout();
            ((ISupportInitialize)picRestaurar).BeginInit();
            ((ISupportInitialize)picMaximizar).BeginInit();
            ((ISupportInitialize)picFechar).BeginInit();
            ((ISupportInitialize)picLogo).BeginInit();
            pnlpictMenu.SuspendLayout();
            ((ISupportInitialize)picMenu).BeginInit();
            pnlbtnFornecedores.SuspendLayout();
            pnlBtnFestas.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((ISupportInitialize)picMenuBar).BeginInit();
            ((ISupportInitialize)pictureLogoHome).BeginInit();
            pnlTopoLogo.SuspendLayout();
            pnlLogoHome.SuspendLayout();
            pnlBtnMenuBar.SuspendLayout();
            pnlBarraLateralMenu.SuspendLayout();
            flowBarraLateral.SuspendLayout();
            ContainerSubFinanceiro.SuspendLayout();
            pnlStatusRodape.SuspendLayout();
            SuspendLayout();
            // 
            // PnlBarraTitulo
            // 
            PnlBarraTitulo.BackColor = Color.DarkGoldenrod;
            PnlBarraTitulo.Controls.Add(pictureBox2);
            PnlBarraTitulo.Controls.Add(picMinimizar);
            PnlBarraTitulo.Controls.Add(pnlMaxRest);
            PnlBarraTitulo.Controls.Add(picFechar);
            PnlBarraTitulo.Dock = DockStyle.Top;
            PnlBarraTitulo.Location = new Point(0, 0);
            PnlBarraTitulo.Name = "PnlBarraTitulo";
            PnlBarraTitulo.Size = new Size(1169, 30);
            PnlBarraTitulo.TabIndex = 0;
            PnlBarraTitulo.MouseDown += PnlBarraTitulo_MouseDown;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Image = Resources.park_image_full;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // picMinimizar
            // 
            picMinimizar.Cursor = Cursors.Hand;
            picMinimizar.Dock = DockStyle.Right;
            picMinimizar.Image = Resources.icono_minimizar;
            picMinimizar.Location = new Point(1079, 0);
            picMinimizar.Margin = new Padding(0);
            picMinimizar.Name = "picMinimizar";
            picMinimizar.Size = new Size(30, 30);
            picMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            picMinimizar.TabIndex = 0;
            picMinimizar.TabStop = false;
            picMinimizar.Click += PicMinimizar_Click;
            // 
            // pnlMaxRest
            // 
            pnlMaxRest.Controls.Add(picRestaurar);
            pnlMaxRest.Controls.Add(picMaximizar);
            pnlMaxRest.Dock = DockStyle.Right;
            pnlMaxRest.Location = new Point(1109, 0);
            pnlMaxRest.Name = "pnlMaxRest";
            pnlMaxRest.Size = new Size(30, 30);
            pnlMaxRest.TabIndex = 0;
            // 
            // picRestaurar
            // 
            picRestaurar.Cursor = Cursors.Hand;
            picRestaurar.Dock = DockStyle.Fill;
            picRestaurar.Image = Resources.icono_restaurar;
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
            picMaximizar.Image = Resources.icono_maximizar;
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
            picFechar.Image = Resources.icono_cerrar;
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
            tmSidebarTransition.Interval = 5;
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
            pictureBox1.Location = new Point(163, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 59);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
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
            picMenuBar.Image = Resources.menu3;
            picMenuBar.Location = new Point(157, 0);
            picMenuBar.Name = "picMenuBar";
            picMenuBar.Padding = new Padding(0, 0, 5, 0);
            picMenuBar.Size = new Size(43, 38);
            picMenuBar.SizeMode = PictureBoxSizeMode.Zoom;
            picMenuBar.TabIndex = 0;
            picMenuBar.TabStop = false;
            picMenuBar.Click += PicMenuBar_Click;
            // 
            // pictureLogoHome
            // 
            pictureLogoHome.Dock = DockStyle.Fill;
            pictureLogoHome.Image = Resources.home_36;
            pictureLogoHome.Location = new Point(0, 2);
            pictureLogoHome.Name = "pictureLogoHome";
            pictureLogoHome.Size = new Size(200, 43);
            pictureLogoHome.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogoHome.TabIndex = 0;
            pictureLogoHome.TabStop = false;
            // 
            // TmSubMenuFinanceiroTransition
            // 
            TmSubMenuFinanceiroTransition.Interval = 10;
            TmSubMenuFinanceiroTransition.Tick += TmSubMenuFinanceiroTransition_Tick;
            // 
            // btnContasPagar
            // 
            btnContasPagar._Image = Resources.cash_out_32;
            btnContasPagar.BackColor = Color.FromArgb(37, 46, 59);
            btnContasPagar.CorOnEnter = Color.Blue;
            btnContasPagar.FlatAppearance.BorderSize = 0;
            btnContasPagar.FlatStyle = FlatStyle.Flat;
            btnContasPagar.ForeColor = Color.White;
            btnContasPagar.Location = new Point(6, 49);
            btnContasPagar.Margin = new Padding(6, 3, 3, 3);
            btnContasPagar.Name = "btnContasPagar";
            btnContasPagar.Padding = new Padding(63, 0, 0, 0);
            btnContasPagar.Size = new Size(194, 40);
            btnContasPagar.TabIndex = 0;
            btnContasPagar.Text = "Contas a Pagar";
            btnContasPagar.TextAlign = ContentAlignment.MiddleLeft;
            btnContasPagar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContasPagar.UseVisualStyleBackColor = false;
            // 
            // btnFinanceiro
            // 
            btnFinanceiro._Image = Resources.cash_investimento_36;
            btnFinanceiro.BackColor = Color.FromArgb(26, 32, 40);
            btnFinanceiro.CorOnEnter = Color.Blue;
            btnFinanceiro.FlatAppearance.BorderSize = 0;
            btnFinanceiro.FlatStyle = FlatStyle.Flat;
            btnFinanceiro.ForeColor = Color.White;
            btnFinanceiro.Location = new Point(0, 3);
            btnFinanceiro.Margin = new Padding(0, 3, 3, 3);
            btnFinanceiro.Name = "btnFinanceiro";
            btnFinanceiro.Padding = new Padding(63, 0, 0, 0);
            btnFinanceiro.Size = new Size(200, 40);
            btnFinanceiro.TabIndex = 0;
            btnFinanceiro.Text = "Financeiro";
            btnFinanceiro.TextAlign = ContentAlignment.MiddleLeft;
            btnFinanceiro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFinanceiro.UseVisualStyleBackColor = false;
            btnFinanceiro.Click += BtnFinanceiro_Click;
            // 
            // btnContasReceber
            // 
            btnContasReceber._Image = Resources.cash_in_32;
            btnContasReceber.BackColor = Color.FromArgb(37, 46, 59);
            btnContasReceber.CorOnEnter = Color.Blue;
            btnContasReceber.FlatAppearance.BorderSize = 0;
            btnContasReceber.FlatStyle = FlatStyle.Flat;
            btnContasReceber.ForeColor = Color.White;
            btnContasReceber.Location = new Point(6, 95);
            btnContasReceber.Margin = new Padding(6, 3, 3, 3);
            btnContasReceber.Name = "btnContasReceber";
            btnContasReceber.Padding = new Padding(63, 0, 0, 0);
            btnContasReceber.Size = new Size(194, 40);
            btnContasReceber.TabIndex = 0;
            btnContasReceber.Text = "Contas a Receber";
            btnContasReceber.TextAlign = ContentAlignment.MiddleLeft;
            btnContasReceber.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContasReceber.UseVisualStyleBackColor = false;
            // 
            // pnlTopoLogo
            // 
            pnlTopoLogo.BackColor = Color.FromArgb(26, 32, 40);
            pnlTopoLogo.Controls.Add(pnlLogoHome);
            pnlTopoLogo.Controls.Add(pnlBtnMenuBar);
            pnlTopoLogo.Dock = DockStyle.Top;
            pnlTopoLogo.Location = new Point(0, 0);
            pnlTopoLogo.Name = "pnlTopoLogo";
            pnlTopoLogo.Size = new Size(200, 86);
            pnlTopoLogo.TabIndex = 14;
            // 
            // pnlLogoHome
            // 
            pnlLogoHome.Controls.Add(pictureLogoHome);
            pnlLogoHome.Dock = DockStyle.Fill;
            pnlLogoHome.Location = new Point(0, 38);
            pnlLogoHome.Name = "pnlLogoHome";
            pnlLogoHome.Padding = new Padding(0, 2, 0, 3);
            pnlLogoHome.Size = new Size(200, 48);
            pnlLogoHome.TabIndex = 15;
            // 
            // pnlBtnMenuBar
            // 
            pnlBtnMenuBar.BackColor = Color.FromArgb(26, 32, 40);
            pnlBtnMenuBar.Controls.Add(picMenuBar);
            pnlBtnMenuBar.Dock = DockStyle.Top;
            pnlBtnMenuBar.Location = new Point(0, 0);
            pnlBtnMenuBar.Name = "pnlBtnMenuBar";
            pnlBtnMenuBar.Size = new Size(200, 38);
            pnlBtnMenuBar.TabIndex = 14;
            // 
            // pnlBarraLateralMenu
            // 
            pnlBarraLateralMenu.BackColor = Color.FromArgb(26, 32, 40);
            pnlBarraLateralMenu.Controls.Add(flowBarraLateral);
            pnlBarraLateralMenu.Controls.Add(pnlTopoLogo);
            pnlBarraLateralMenu.Controls.Add(pnlStatusRodape);
            pnlBarraLateralMenu.Dock = DockStyle.Left;
            pnlBarraLateralMenu.Location = new Point(0, 30);
            pnlBarraLateralMenu.Name = "pnlBarraLateralMenu";
            pnlBarraLateralMenu.Size = new Size(200, 555);
            pnlBarraLateralMenu.TabIndex = 16;
            // 
            // flowBarraLateral
            // 
            flowBarraLateral.BackColor = Color.FromArgb(26, 32, 40);
            flowBarraLateral.Controls.Add(btnFestas);
            flowBarraLateral.Controls.Add(btnCliente);
            flowBarraLateral.Controls.Add(btnCalendario);
            flowBarraLateral.Controls.Add(btnFornecedor);
            flowBarraLateral.Controls.Add(btnPacotesFestas);
            flowBarraLateral.Controls.Add(ContainerSubFinanceiro);
            flowBarraLateral.Controls.Add(btnRelatorios);
            flowBarraLateral.Controls.Add(btnUsuarios);
            flowBarraLateral.Dock = DockStyle.Fill;
            flowBarraLateral.Location = new Point(0, 86);
            flowBarraLateral.Name = "flowBarraLateral";
            flowBarraLateral.Size = new Size(200, 446);
            flowBarraLateral.TabIndex = 16;
            // 
            // btnFestas
            // 
            btnFestas._Image = Resources.festa_balloons_36;
            btnFestas.BackColor = Color.FromArgb(26, 32, 40);
            btnFestas.CorOnEnter = Color.Blue;
            btnFestas.FlatAppearance.BorderSize = 0;
            btnFestas.FlatStyle = FlatStyle.Flat;
            btnFestas.ForeColor = Color.White;
            btnFestas.Location = new Point(0, 3);
            btnFestas.Margin = new Padding(0, 3, 3, 3);
            btnFestas.Name = "btnFestas";
            btnFestas.Padding = new Padding(63, 0, 0, 0);
            btnFestas.Size = new Size(200, 40);
            btnFestas.TabIndex = 0;
            btnFestas.Text = "Festas";
            btnFestas.TextAlign = ContentAlignment.MiddleLeft;
            btnFestas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFestas.UseVisualStyleBackColor = false;
            btnFestas.Click += btnFestas_Click;
            // 
            // btnCliente
            // 
            btnCliente._Image = Resources.pessoas_clientes_36;
            btnCliente.BackColor = Color.FromArgb(26, 32, 40);
            btnCliente.CorOnEnter = Color.Blue;
            btnCliente.FlatAppearance.BorderSize = 0;
            btnCliente.FlatStyle = FlatStyle.Flat;
            btnCliente.ForeColor = Color.White;
            btnCliente.Location = new Point(0, 49);
            btnCliente.Margin = new Padding(0, 3, 3, 3);
            btnCliente.Name = "btnCliente";
            btnCliente.Padding = new Padding(63, 0, 0, 0);
            btnCliente.Size = new Size(200, 40);
            btnCliente.TabIndex = 0;
            btnCliente.Text = "Clientes";
            btnCliente.TextAlign = ContentAlignment.MiddleLeft;
            btnCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCliente.UseVisualStyleBackColor = false;
            btnCliente.Click += btnCliente_Click;
            // 
            // btnCalendario
            // 
            btnCalendario._Image = Resources.calendar_edit;
            btnCalendario.BackColor = Color.FromArgb(26, 32, 40);
            btnCalendario.CorOnEnter = Color.Blue;
            btnCalendario.FlatAppearance.BorderSize = 0;
            btnCalendario.FlatStyle = FlatStyle.Flat;
            btnCalendario.ForeColor = Color.White;
            btnCalendario.Location = new Point(0, 95);
            btnCalendario.Margin = new Padding(0, 3, 3, 3);
            btnCalendario.Name = "btnCalendario";
            btnCalendario.Padding = new Padding(63, 0, 0, 0);
            btnCalendario.Size = new Size(200, 40);
            btnCalendario.TabIndex = 0;
            btnCalendario.Text = "Calendário";
            btnCalendario.TextAlign = ContentAlignment.MiddleLeft;
            btnCalendario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCalendario.UseVisualStyleBackColor = false;
            btnCalendario.Click += btnCalendario_Click;
            // 
            // btnFornecedor
            // 
            btnFornecedor._Image = Resources.pessoas_fornecedor_36;
            btnFornecedor.BackColor = Color.FromArgb(26, 32, 40);
            btnFornecedor.CorOnEnter = Color.Blue;
            btnFornecedor.FlatAppearance.BorderSize = 0;
            btnFornecedor.FlatStyle = FlatStyle.Flat;
            btnFornecedor.ForeColor = Color.White;
            btnFornecedor.Location = new Point(0, 141);
            btnFornecedor.Margin = new Padding(0, 3, 3, 3);
            btnFornecedor.Name = "btnFornecedor";
            btnFornecedor.Padding = new Padding(63, 0, 0, 0);
            btnFornecedor.Size = new Size(200, 40);
            btnFornecedor.TabIndex = 0;
            btnFornecedor.Text = "Fornecedores";
            btnFornecedor.TextAlign = ContentAlignment.MiddleLeft;
            btnFornecedor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFornecedor.UseVisualStyleBackColor = false;
            btnFornecedor.Click += btnFornecedor_Click;
            // 
            // btnPacotesFestas
            // 
            btnPacotesFestas._Image = Resources.festa_confete_36;
            btnPacotesFestas.BackColor = Color.FromArgb(26, 32, 40);
            btnPacotesFestas.CorOnEnter = Color.Blue;
            btnPacotesFestas.FlatAppearance.BorderSize = 0;
            btnPacotesFestas.FlatStyle = FlatStyle.Flat;
            btnPacotesFestas.ForeColor = Color.White;
            btnPacotesFestas.Location = new Point(0, 187);
            btnPacotesFestas.Margin = new Padding(0, 3, 3, 3);
            btnPacotesFestas.Name = "btnPacotesFestas";
            btnPacotesFestas.Padding = new Padding(63, 0, 0, 0);
            btnPacotesFestas.Size = new Size(200, 40);
            btnPacotesFestas.TabIndex = 0;
            btnPacotesFestas.Text = "Pacotes Festas";
            btnPacotesFestas.TextAlign = ContentAlignment.MiddleLeft;
            btnPacotesFestas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPacotesFestas.UseVisualStyleBackColor = false;
            btnPacotesFestas.Click += btnPacotesFestas_Click;
            // 
            // ContainerSubFinanceiro
            // 
            ContainerSubFinanceiro.BackColor = Color.FromArgb(26, 32, 40);
            ContainerSubFinanceiro.Controls.Add(btnFinanceiro);
            ContainerSubFinanceiro.Controls.Add(btnContasPagar);
            ContainerSubFinanceiro.Controls.Add(btnContasReceber);
            ContainerSubFinanceiro.Location = new Point(0, 230);
            ContainerSubFinanceiro.Margin = new Padding(0, 0, 0, 3);
            ContainerSubFinanceiro.Name = "ContainerSubFinanceiro";
            ContainerSubFinanceiro.Size = new Size(200, 40);
            ContainerSubFinanceiro.TabIndex = 18;
            // 
            // btnUsuarios
            // 
            btnUsuarios._Image = Resources.pessoas_funcionarios_36;
            btnUsuarios.BackColor = Color.FromArgb(26, 32, 40);
            btnUsuarios.CorOnEnter = Color.Blue;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(0, 322);
            btnUsuarios.Margin = new Padding(0, 3, 3, 3);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(63, 0, 0, 0);
            btnUsuarios.Size = new Size(200, 40);
            btnUsuarios.TabIndex = 0;
            btnUsuarios.Text = "Usuários";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnRelatorios
            // 
            btnRelatorios._Image = Resources.icons8_toy_train_36;
            btnRelatorios.BackColor = Color.FromArgb(26, 32, 40);
            btnRelatorios.CorOnEnter = Color.Blue;
            btnRelatorios.FlatAppearance.BorderSize = 0;
            btnRelatorios.FlatStyle = FlatStyle.Flat;
            btnRelatorios.ForeColor = Color.White;
            btnRelatorios.Location = new Point(0, 276);
            btnRelatorios.Margin = new Padding(0, 3, 3, 3);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Padding = new Padding(63, 0, 0, 0);
            btnRelatorios.Size = new Size(200, 40);
            btnRelatorios.TabIndex = 0;
            btnRelatorios.Text = "Relatórios";
            btnRelatorios.TextAlign = ContentAlignment.MiddleLeft;
            btnRelatorios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRelatorios.UseVisualStyleBackColor = false;
            btnRelatorios.Click += btnRelatorios_Click;
            // 
            // pnlStatusRodape
            // 
            pnlStatusRodape.BackColor = Color.Transparent;
            pnlStatusRodape.Controls.Add(lblStatusConn);
            pnlStatusRodape.Dock = DockStyle.Bottom;
            pnlStatusRodape.Location = new Point(0, 532);
            pnlStatusRodape.Name = "pnlStatusRodape";
            pnlStatusRodape.Size = new Size(200, 23);
            pnlStatusRodape.TabIndex = 17;
            // 
            // lblStatusConn
            // 
            lblStatusConn.Dock = DockStyle.Top;
            lblStatusConn.ForeColor = Color.Red;
            lblStatusConn.Location = new Point(0, 0);
            lblStatusConn.Name = "lblStatusConn";
            lblStatusConn.Size = new Size(200, 19);
            lblStatusConn.TabIndex = 0;
            lblStatusConn.Text = "Connection Off";
            lblStatusConn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMenuMain
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1169, 585);
            Controls.Add(pnlBarraLateralMenu);
            Controls.Add(PnlBarraTitulo);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormMenuMain";
            Text = "FormMenuBase";
            PnlBarraTitulo.ResumeLayout(false);
            ((ISupportInitialize)pictureBox2).EndInit();
            ((ISupportInitialize)picMinimizar).EndInit();
            pnlMaxRest.ResumeLayout(false);
            ((ISupportInitialize)picRestaurar).EndInit();
            ((ISupportInitialize)picMaximizar).EndInit();
            ((ISupportInitialize)picFechar).EndInit();
            ((ISupportInitialize)picLogo).EndInit();
            pnlpictMenu.ResumeLayout(false);
            ((ISupportInitialize)picMenu).EndInit();
            pnlbtnFornecedores.ResumeLayout(false);
            pnlBtnFestas.ResumeLayout(false);
            ((ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((ISupportInitialize)picMenuBar).EndInit();
            ((ISupportInitialize)pictureLogoHome).EndInit();
            pnlTopoLogo.ResumeLayout(false);
            pnlLogoHome.ResumeLayout(false);
            pnlBtnMenuBar.ResumeLayout(false);
            pnlBarraLateralMenu.ResumeLayout(false);
            flowBarraLateral.ResumeLayout(false);
            ContainerSubFinanceiro.ResumeLayout(false);
            pnlStatusRodape.ResumeLayout(false);
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
        private Panel pnlTopoLogo;
        private Panel pnlBtnMenuBar;
        private myButtonMenu btnContasReceber;
        private Panel pnlBarraLateralMenu;
        private FlowLayoutPanel flowBarraLateral;
        private myButtonMenu btnFestas;
        private myButtonMenu btnCliente;
        private myButtonMenu btnCalendario;
        private myButtonMenu btnFornecedor;
        private myButtonMenu btnPacotesFestas;
        private myButtonMenu btnUsuarios;
        private PictureBox pictureLogoHome;
        private System.Windows.Forms.Timer TmSubMenuFinanceiroTransition;
        private Panel pnlMaxRest;
        private myButtonMenu btnFinanceiro;
        private myButtonMenu btnContasPagar;
        private Panel pnlLogoHome;
        private FlowLayoutPanel ContainerSubFinanceiro;
        private Panel pnlStatusRodape;
        public Label lblStatusConn;
        private PictureBox pictureBox2;
        private myButtonMenu btnRelatorios;
    }
}
