//---------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C# .NET
//
//   Inicio: 23/05/2024
//   Cria��o deste M�dulo: 23/05/2024
//   Ultima Altera��o: 18/06/2024
//   
//   FORMUL�RIO PRINCIPAL
//
//----------------------------------------------------------------

using MyFramework.Views;
using System.Windows.Forms;

namespace FestasApp
{
    public partial class FormMenuMain : Form
    {
        //private readonly clsFestasContext _context;
        // dicionario para os forms
        private Dictionary<Type, (Form form, bool manterAberto)> openForms = new Dictionary<Type, (Form form, bool manterAberto)>();

        // instancia formulários...
        public static FormMenuMain? InstanceFrmMain { get; private set; }

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

            InstanceFrmMain = this; // Atribui o valor dentro do construtor
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
        //
        private void AtualizarStatusConexao()
        {
            myConnMySql.TestarConexao();
        }
        //
        public void SetLabelStatusConexao(bool Online)
        {
            if (Online)
            {
                lblStatusConn.Text = "Connection On";
                lblStatusConn.ForeColor = Color.Green;
            }
            else
            {
                lblStatusConn.Text = "Connection Off";
                lblStatusConn.ForeColor = Color.Red;
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
        // Associa os eventos MouseEnter e MouseLeave aos controles icones do formulario
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
        //
        private void PicMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //
        private void PicRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            picRestaurar.Visible = false;
            picMaximizar.Visible = true;
        }
        //
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
        //
        // Evento MouseLeave para restaurar a cor de fundo original...
        private void Pic_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is PictureBox pic)
            {
                pic.BackColor = Color.Transparent; // ou a cor original que voc� deseja
            }
        }

        //
        #region  Métodos para mover formulario...
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
        #endregion mover formulários.

        //
        #region Menu lateral e Sub menu finaceiro responsivo
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
        #region Chamadas Para Abrir Formulários
        // 
        // btn FESTAS...
        private void btnFestas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormFestasCadastro(), manterAberto: true);
        }
        //
        // CLIENTES...
        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormClientesCadastro(), manterAberto: true);
        }
        //
        // CALENDARIO...
        private void btnCalendario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormCalendario(), manterAberto: true);
        }
        //
        // FORNECEDOR
        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            // chamar form fornecedor
        }
        //
        // PACOTES / TABELAS AUXILIARES...
        private void btnPacotesFestas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAuxiliaresMain(), manterAberto: false);
        }
        //
        // USUARIOS...
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(new FormUsuariosCadastro(), manterAberto: false);

            FormUsuariosCadastro frm = new();

            // Verifica se o formulário FormUsuariosCadastro já est� aberto antes de abrir um novo
            if (!IsFormOpen(typeof(FormUsuariosCadastro)))
            {
                // Chama o m�todo para abrir o formul�rio FormUsuariosCadastro
                AbrirFormulario(frm, manterAberto: false);
            }
            else
            {
                frm.TopMost = true;
                frm.Activate();
            }
        }
        #endregion

        //-----------------------------------------------------------------------
        // Método que verifica se um formul�rio do tipo especificado está aberto
        private static bool IsFormOpen(Type formType)
        {
            // Verifica todos os formulários abertos na aplicação
            foreach (Form openForm in Application.OpenForms)
            {
                // Se algum formulário aberto for do tipo especificado, retorna verdadeiro
                if (openForm.GetType() == formType)
                {
                    return true;
                }
            }
            // Se nenhum formulário aberto for do tipo especificado, retorna falso
            return false;
        }
        //------------------------------
        // método para ABRIR formulários
        private async void AbrirFormulario(Form form, bool manterAberto = false)
        {
            try
            {
                Type formType = form.GetType();

                // Fecha todos os formulários que náo precisam ser mantidos abertos
                foreach (var key in new List<Type>(openForms.Keys))
                {
                    if (!openForms[key].manterAberto && openForms[key].form != null)
                    {
                        openForms[key].form.Close(); // Fecha o formul�rio
                        openForms.Remove(key); // Remove do dicion�rio
                    }
                }

                // Verifica se o formulário já está aberto e ativo
                if (openForms.ContainsKey(formType) && openForms[formType].form != null && !openForms[formType].form.IsDisposed)
                {
                    openForms[formType].form.Activate(); // Ativa o formul�rio já aberto
                }
                else
                {
                    // Se o formulário já estava no dicionário, mas foi fechado, recria a instância
                    if (openForms.ContainsKey(formType) && openForms[formType].form != null && openForms[formType].form.IsDisposed)
                    {
                        openForms.Remove(formType); // Remove a entrada do dicion�rio
                    }

                    // Configura o evento FormClosed para liberar recursos
                    form.FormClosed += (sender, e) =>
                    {
                        if (!manterAberto)
                        {
                            openForms.Remove(formType); // Remove do dicionário
                            form.Dispose(); // Libera recursos ao fechar
                        }
                        else
                        {
                            // Atualiza o dicion�rio para refletir que o formulário foi fechado
                            openForms[formType] = (null!, true); // Usa null-forgiving operator (!) para indicar que o valor pode ser null
                        }
                    };

                    // Define o formulário como filho MDI e exibe
                    form.MdiParent = this;
                    form.Dock = DockStyle.Fill;

                    //form.Show();
                    await ShowModalOverlay(form, delay: 1000, modal: false);

                    // Adiciona ou atualiza o formulário no dicion�rio
                    openForms[formType] = (form, manterAberto);
                }
            }
            catch (Exception ex)
            {
                // Tratamento de exceções
                Console.WriteLine($"Erro ao abrir o formulário: {ex.Message}");
            }
        }
        //
        //------------------------------
        // método para ABRIR formulários
        private void AbrirFormularioOLD(Form form, bool manterAberto = false)
        {
            Type formType = form.GetType();
            
            // Cria e mostra o FormLoading
            using (FormLoading formLoading = new FormLoading(form, 5000))
            {
                formLoading.SetMessage("Carregando...");
                formLoading.StartTimer();

                //formLoading.MdiParent = this;
                formLoading.TopMost = true;
                formLoading.Show();

                // Fecha todos os formulários que náo precisam ser mantidos abertos
                foreach (var key in new List<Type>(openForms.Keys))
                {
                    if (!openForms[key].manterAberto && openForms[key].form != null)
                    {
                        openForms[key].form.Close(); // Fecha o formul�rio
                        openForms.Remove(key); // Remove do dicion�rio
                    }
                }

                // Verifica se o formulário já está aberto e ativo
                if (openForms.ContainsKey(formType) && openForms[formType].form != null && !openForms[formType].form.IsDisposed)
                {
                    openForms[formType].form.Activate(); // Ativa o formul�rio já aberto
                }
                else
                {
                    // Se o formul�rio já estava no dicionário, mas foi fechado, recria a instância
                    if (openForms.ContainsKey(formType) && openForms[formType].form != null && openForms[formType].form.IsDisposed)
                    {
                        openForms.Remove(formType); // Remove a entrada do dicion�rio
                    }

                    // Configura o evento FormClosed para liberar recursos
                    form.FormClosed += (sender, e) =>
                    {
                        if (!manterAberto)
                        {
                            openForms.Remove(formType); // Remove do dicionário
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

                    // Adiciona um handler para o evento Shown
                    form.Shown += (sender, e) =>
                    {
                        // Fecha o FormLoading ap�s o formul�rio estar completamente montado
                        formLoading.Close();
                    };

                    form.Show(); // Exibe o formulário
                    //formLoading.Close();

                    // Adiciona ou atualiza o formulário no dicion�rio
                    openForms[formType] = (form, manterAberto);
                }
            }
        }
        //
        //***********************************************************************************************************
        // Para evitar a necessidade de verificar a nulidade de FormMenuMain.Instance repetidamente
        // antes de chamar await myUtilities.myMessageBox,
        // esse método auxiliar dentro da classe FormMenuMain encapsula essa verificação.
        // Dessa forma, centraliza a verificação em um único lugar e simplifica o código em outras partes do programa.
        //***********************************************************************************************************
        //
        // Método auxiliar para exibir menssagens com bakground modal
        public async static void ShowMyMessageBox(string mensagem, 
                                            string titulo = "Mensagem", 
                                            MessageBoxButtons botoes = MessageBoxButtons.OK, 
                                            MessageBoxIcon icone = MessageBoxIcon.Information, 
                                            int opacidade = 60, 
                                            Color cor = default)
        {
            if (InstanceFrmMain != null)
            {
                await myUtilities.myMessageBox(InstanceFrmMain, mensagem, titulo, botoes, icone, opacidade, cor);
            }
            else
            {
                // Opcional: lan�ar uma exce��o ou logar o erro caso a InstanceFrmMain seja nula
                throw new InvalidOperationException("FormMenuMain.Instance não está inicializada.");
            }
        }

        //
        // método auxiliar para exibir formularios CreateModalOverlayAsync...
        public static async Task ShowModalOverlay(Form? frmExibir, 
                                            Action? mostrarMensagem = null, 
                                            int opacidade = 60, 
                                            Color cor = default,
                                            int delay = 1000,
                                            bool modal = true)
        {
            if (InstanceFrmMain != null)
            {
                // Mostra o formulário a ser carregado
                await myUtilities.CreateModalOverlayAsync(InstanceFrmMain, mostrarMensagem, frmExibir, opacidade, cor, delay, modal);
            }
            else
            {
                // Opcional: lan�ar uma exce��o ou logar o erro caso a InstanceFrmMain seja nula
                throw new InvalidOperationException("FormMenuMain.Instance não está inicializada.");
            }
        }
        //

    } // end class FormMenuBase...
} // end namespace

