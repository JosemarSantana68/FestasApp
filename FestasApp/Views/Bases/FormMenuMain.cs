//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Altera��o: 18/06/2024
//   
//   FORMUL�RIO PRINCIPAL
//
//************************************************************

namespace FestasApp
{
    public partial class FormMenuMain : Form
    {
        //private readonly clsFestasContext _context;
        // dicionario para os forms
        private Dictionary<Type, (Form form, bool manterAberto)> openForms = new Dictionary<Type, (Form form, bool manterAberto)>();

        // instancia formularios...
        public static FormMenuMain? Instance { get; private set; }

        // construtor
        public FormMenuMain()
        {
            /* Aqui � o lugar ideal para configurar:
            1.Inicializa��o de componentes: Configura��o b�sica dos controles que estar�o no formul�rio (defini��o de propriedades visuais e comportamentais).
            2.Event Handlers: Associa��o de eventos aos seus respectivos manipuladores, como clique de bot�o, altera��o de texto, etc.
            3.Defini��o de propriedades est�ticas: Propriedades que n�o v�o depender de nenhuma l�gica din�mica ou de dados que precisam ser carregados de fontes externas.
             */

            InitializeComponent();

            this.IsMdiContainer = true; // Define o formul�rio como container MDI

            Instance = this; // Atribui o valor dentro do construtor
            ConfigurarFrmMenu();
            // Testar a conex�o ao iniciar o formul�rio
            AtualizarStatusConexao();
            // Chama o m�todo para configurar propriedades MDI...
            MdiPropiedades();
        }
        //
        // evento load
        private void FormMenuBase_Load(object sender, EventArgs e)
        {
            /* Aqui � o lugar ideal para configurar:
            1.Carregamento de dados: Busca e carregamento de dados de fontes externas, como bancos de dados ou arquivos.
            2.Inicializa��o de l�gica de neg�cio: Qualquer l�gica de inicializa��o que dependa de dados ou estado do sistema.
            3.Configura��o din�mica: Configura��o de controles com base em dados carregados dinamicamente ou estado da aplica��o.
             */

        }
        // M�todo para atualizar o status da conex�o
        //public static bool ConexaoAtiva { get; private set; }
        private void AtualizarStatusConexao()
        {
            if (myConnMySql.TestarConexao())
            {
                lblStatusConn.Text = "Connection On";
                lblStatusConn.ForeColor = Color.Green;
                //ConexaoAtiva = true; // Conex�o est� ativa
            }
            else
            {
                lblStatusConn.Text = "Connection Off";
                lblStatusConn.ForeColor = Color.Red;
                //ConexaoAtiva = false; // Conex�o est� inativa
            }
        }
        //
        // Configura propriedades espec�ficas para o formul�rio MDI...
        private void MdiPropiedades()
        {
            // Utiliza o m�todo de extens�o ConfiguraBorda da classe clsMdiProperties
            // para remover a borda (bevel) do cliente MDI...
            this.ConfiguraBorda(show: false);

            // Verifica se existe algum controle do tipo MdiClient
            MdiClient? mdiClient = Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdiClient != null)
            {
                // Define a cor de fundo do MdiClient para um tom espec�fico...
                mdiClient.BackColor = Color.FromArgb(232, 234, 237);
                //mdiClient.BackColor = Color.White;
            }
        }
        // 
        //----------------------------------------------
        // Configura��es iniciais do formul�rio...
        private void ConfigurarFrmMenu()
        {
            // Configura��es de exibi��o do formul�rio
            this.FormBorderStyle = FormBorderStyle.None;

            // Ajusta o estado do formul�rio para maximizado
            this.WindowState = FormWindowState.Maximized;
            //
            picRestaurar.Visible = true;
            picMaximizar.Visible = false;
            //
            // Associa��es de eventos MouseEnter e MouseLeave para os PictureBox...
            AssociarPicEventosMouse(picMaximizar);
            AssociarPicEventosMouse(picMinimizar);
            AssociarPicEventosMouse(picRestaurar);
            AssociarPicEventosMouse(picFechar);
        }
        //
        // Associa os eventos MouseEnter e MouseLeave ao controle
        private void AssociarPicEventosMouse(PictureBox picture)
        {
            picture.MouseEnter += Pic_MouseEnter;
            picture.MouseLeave += Pic_MouseLeave;
        }
        //
        // Eventos para maximizar, minimizar, restaurar e fechar o formul�rio
        private void PicMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            picMaximizar.Visible = false;
            picRestaurar.Visible = true;
        }
        private void PicMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void PicRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picRestaurar.Visible = false;
            picMaximizar.Visible = true;
        }
        private void PicFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        // Evento MouseEnter para mudar a cor de fundo...
        private void Pic_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is PictureBox pic)
            {
                if (pic.Name == "picFechar")
                {
                    pic.BackColor = Color.Red;
                }
                else
                {
                    pic.BackColor = Color.FromArgb(120, 99, 20); // substitua pelos valores RGB desejados
                }
            }
        }
        // Evento MouseLeave para restaurar a cor de fundo original...
        private void Pic_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is PictureBox pic)
            {
                pic.BackColor = Color.Transparent; // ou a cor original que voc� deseja
            }
        }

        #region  m�todos mover formulario...
        //---------------------
        // M�todo e bibliotecas para mover o formul�rio...
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        // SUGEST�O GPT...
        //[LibraryImport("user32.DLL")]
        //private static partial void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // SUGEST�O GPT...
        //[LibraryImport("user32.DLL")]
        //private static partial void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

            // Verifica se o formul�rio mudou de maximizado para normal
            if (this.WindowState == FormWindowState.Normal)
            {
                picRestaurar.Visible = false;
                picMaximizar.Visible = true;
            }
        } // end mover formul�rio
        #endregion mover formul�rios.

        #region menu lateral e sub menu finaceiro responsivo
        //--------------------------------------------------------------------------
        // MENU RESPONSIVO...
        // Evento para ocultar ou mostrar o menu lateral ao clicar no bot�o btnMenu
        //
        // Indica se menu lateral est� expandido...
        private bool sidebarExpand = true;
        private void PicMenuBar_Click(object sender, EventArgs e)
        {
            tmSidebarTransition.Start();
        }
        //
        // Timer para movimentar o Menu barra Lateral...
        private void tmSidebarTransition_Tick(object sender, EventArgs e)
        {
            // se o menu est� expandido...
            if (sidebarExpand)
            {
                pnlBarraLateralMenu.Width -= 10;
                if (pnlBarraLateralMenu.Width <= 70)
                {
                    sidebarExpand = false;
                    tmSidebarTransition.Stop();
                }
            }
            // Se o menu est� retraido...
            else
            {
                pnlBarraLateralMenu.Width += 10;
                if (pnlBarraLateralMenu.Width >= 200)
                {
                    sidebarExpand = true;
                    tmSidebarTransition.Stop();
                }
            }
        } // end menu responsivo...
        //
        // Evento para ocultar ou mostrar o SUBMENU-financeiro ao clicar no btnFinanceiro...
        //
        // Indica se o submenu financeiro est� expandido...
        private bool subMenuFinanceiroExpand = false;
        private void BtnFinanceiro_Click(object sender, EventArgs e)
        {
            TmSubMenuFinanceiroTransition.Start();
            MudarCorBtnFinanceiro();
        }
        // submenu contas a pagar e contas a receber...
        private void TmSubMenuFinanceiroTransition_Tick(object sender, EventArgs e)
        {
            // expande
            if (subMenuFinanceiroExpand == false)
            {
                ContainerSubFinanceiro.Height += 10;
                if (ContainerSubFinanceiro.Height >= 132)
                {
                    TmSubMenuFinanceiroTransition.Stop();
                    subMenuFinanceiroExpand = true;
                }
            }
            else // esconde
            {
                ContainerSubFinanceiro.Height -= 10;
                if (ContainerSubFinanceiro.Height <= 46)
                {
                    TmSubMenuFinanceiroTransition.Stop();
                    subMenuFinanceiroExpand = false;
                }
            }
        } // end submenu-financeiro...
        private void MudarCorBtnFinanceiro()
        {
            // ao expandir
            if (subMenuFinanceiroExpand == false)
            {
                ContainerSubFinanceiro.BackColor = Color.FromArgb(37, 46, 59);
            }
            else // ao retrair
            {
                ContainerSubFinanceiro.BackColor = Color.FromArgb(26, 32, 40);
            }
        }
        #endregion menu lateral e sub menu finaceiro responsivo
        //
        // 
        // btn FESTAS...
        //
        private void btnFestas_Click(object sender, EventArgs e)
        {
            //using (var context = new clsFestasContext())
            //{
            AbrirFormulario(new FormFestasCadastro(), manterAberto: true);
            //}
        }
        //
        // CLIENTES...
        //
        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormClientesCadastro(), manterAberto: true);
        }
        //
        // CALENDARIO...
        //
        private void btnCalendario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormCalendario(), manterAberto: true);
        }
        //
        // FORNECEDOR
        //
        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            // chamar form fornecedor
        }
        //
        // USUARIOS...
        //
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Form frm = new FormUsuariosCadastro();

            // Verifica se o formul�rio FormUsuariosCadastro j� est� aberto antes de abrir um novo
            if (!IsFormOpen(typeof(FormUsuariosCadastro)))
            {
                // Chama o m�todo para abrir o formul�rio FormUsuariosCadastro
                AbrirFormulario(frm, manterAberto: false);
            }
            else
            {
                frm.Activate();
            }
        }
        //
        // M�todo que verifica se um formul�rio do tipo especificado est� aberto
        private bool IsFormOpen(Type formType)
        {
            // Verifica todos os formul�rios abertos na aplica��o
            foreach (Form openForm in Application.OpenForms)
            {
                // Se algum formul�rio aberto for do tipo especificado, retorna verdadeiro
                if (openForm.GetType() == formType)
                {
                    return true;
                }
            }
            // Se nenhum formul�rio aberto for do tipo especificado, retorna falso
            return false;
        }
        //
        // m�todo para ABRIR formul�rios
        private void AbrirFormulario(Form form, bool manterAberto = false)
        {
            Type formType = form.GetType();

            // Fecha todos os formul�rios que n�o precisam ser mantidos abertos
            foreach (var key in new List<Type>(openForms.Keys))
            {
                if (!openForms[key].manterAberto && openForms[key].form != null)
                {
                    openForms[key].form.Close(); // Fecha o formul�rio
                    openForms.Remove(key); // Remove do dicion�rio
                }
            }
            // Verifica se o formul�rio j� est� aberto e ativo
            if (openForms.ContainsKey(formType) && openForms[formType].form != null && !openForms[formType].form.IsDisposed)
            {
                openForms[formType].form.Activate(); // Ativa o formul�rio j� aberto
            }
            else
            {
                // Se o formul�rio j� estava no dicion�rio, mas foi fechado, recria a inst�ncia
                if (openForms.ContainsKey(formType) && openForms[formType].form != null && openForms[formType].form.IsDisposed)
                {
                    openForms.Remove(formType); // Remove a entrada do dicion�rio
                }
                // Configura o evento FormClosed para liberar recursos
                form.FormClosed += (sender, e) =>
                {
                    if (!manterAberto)
                    {
                        openForms.Remove(formType); // Remove do dicion�rio
                        form.Dispose(); // Libera recursos ao fechar
                    }
                    else
                    {
                        // Atualiza o dicion�rio para refletir que o formul�rio foi fechado
                        openForms[formType] = (null!, true); // Usa null-forgiving operator (!) para indicar que o valor pode ser null
                    }
                };

                // Define o formul�rio como filho MDI e exibe
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show(); // Exibe o formul�rio

                // Adiciona ou atualiza o formul�rio no dicion�rio
                openForms[formType] = (form, manterAberto);
            }
        }

        //***********************************************************************************************************
        // Para evitar a necessidade de verificar a nulidade de FormMenuBase.Instance repetidamente
        // antes de chamar myUtilities.myMessageBox,
        // criar um m�todo auxiliar dentro da classe FormMenuBase que encapsule essa verifica��o.
        // Dessa forma, centraliza a verifica��o em um �nico lugar e simplifica o c�digo em outras partes do programa.
        //***********************************************************************************************************
        public static void ShowMyMessageBox(string mensagem, string titulo = "Mensagem", MessageBoxButtons botoes = MessageBoxButtons.OK, MessageBoxIcon icone = MessageBoxIcon.Information, int opacidade = 60, Color cor = default)
        {
            if (Instance != null)
            {
                myUtilities.myMessageBox(Instance, mensagem, titulo, botoes, icone, opacidade, cor);
            }
            else
            {
                // Opcional: lan�ar uma exce��o ou logar o erro caso a Instance seja nula
                throw new InvalidOperationException("FormMenuBase.Instance n�o est� inicializada.");
            }
        }
        // m�todo auxiliar para exibir formularios CreateModalOverlay...
        public static void ShowModalOverlay(Form? frmExibir, Action? mostrarMensagem = null, int opacidade = 60, Color cor = default)
        {
            if (Instance != null)
            {
                myUtilities.CreateModalOverlay(Instance, mostrarMensagem, frmExibir, opacidade, cor);
            }
            else
            {
                // Opcional: lan�ar uma exce��o ou logar o erro caso a Instance seja nula
                throw new InvalidOperationException("FormMenuBase.Instance n�o est� inicializada.");
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var bd = new clsFestasContext();
        //    var tipoeventos = bd.FestasTipoEvento.Where(tpv => tpv.tpev_nome.Contains("A")).ToList();

        //    foreach (var item in tipoeventos)
        //    {
        //        MessageBox.Show(item.tpev_nome);
        //    }
        //}
    } // end class FormMenuBase...
} // end namespace

