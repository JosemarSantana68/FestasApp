//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 18/06/2024
//   
//   FORMULÁRIO PRINCIPAL
//
//************************************************************

using FestasApp.Properties;
using FestasApp.Views;
using FestasApp.Views.Calendario;
using FestasApp.Views.Usuarios;
using MyFramework.myCodes;
using System.Runtime.InteropServices;

namespace FestasApp
{
    public partial class FormMenuBase : Form
    {
        // dicionario para os forms
        private Dictionary<Type, (Form form, bool manterAberto)> openForms = new Dictionary<Type, (Form form, bool manterAberto)>();

        // instancia formularios...
        public static FormMenuBase? Instance { get; private set; }
       
        // construtor
        public FormMenuBase()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Define o formulário como container MDI

            Instance = this; // Atribui o valor dentro do construtor
            ConfigurarFrmMenu();

            // Chama o método para configurar propriedades MDI...
            MdiPropiedades();
        }
        //
        // evento load
        private void FormMenuBase_Load(object sender, EventArgs e)
        {
            
        }
        //
        // Configura propriedades específicas para o formulário MDI...
        private void MdiPropiedades()
        {
            // Utiliza o método de extensão ConfiguraBorda da classe clsMdiProperties
            // para remover a borda (bevel) do cliente MDI...
            this.ConfiguraBorda(show: false);

            // Verifica se existe algum controle do tipo MdiClient
            MdiClient? mdiClient = Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdiClient != null)
            {
                // Define a cor de fundo do MdiClient para um tom específico...
                mdiClient.BackColor = Color.FromArgb(232, 234, 237);
                //mdiClient.BackColor = Color.White;
            }
        }
        // 
        //----------------------------------------------
        // Configurações iniciais do formulário...
        private void ConfigurarFrmMenu()
        {
            // Configurações de exibição do formulário
            this.FormBorderStyle = FormBorderStyle.None;

            // Ajusta o estado do formulário para maximizado
            this.WindowState = FormWindowState.Maximized;
            //
            picRestaurar.Visible = true;
            picMaximizar.Visible = false;
            //
            // Associações de eventos MouseEnter e MouseLeave para os PictureBox...
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
        // Eventos para maximizar, minimizar, restaurar e fechar o formulário
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
                pic.BackColor = Color.Transparent; // ou a cor original que você deseja
            }
        }

        #region  métodos mover formulario...
        //---------------------
        // Método e bibliotecas para mover o formulário...
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        // SUGESTÃO GPT...
        //[LibraryImport("user32.DLL")]
        //private static partial void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // SUGESTÃO GPT...
        //[LibraryImport("user32.DLL")]
        //private static partial void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

            // Verifica se o formulário mudou de maximizado para normal
            if (this.WindowState == FormWindowState.Normal)
            {
                picRestaurar.Visible = false;
                picMaximizar.Visible = true;
            }
        } // end mover formulário
        #endregion mover formulários.

        #region menu lateral e sub menu finaceiro responsivo
        //--------------------------------------------------------------------------
        // MENU RESPONSIVO...
        // Evento para ocultar ou mostrar o menu lateral ao clicar no botão btnMenu
        //
        // Indica se menu lateral está expandido...
        private bool sidebarExpand = true;
        private void PicMenuBar_Click(object sender, EventArgs e)
        {
            tmSidebarTransition.Start();
        }
        //
        // Timer para movimentar o Menu barra Lateral...
        private void tmSidebarTransition_Tick(object sender, EventArgs e)
        {
            // se o menu está expandido...
            if (sidebarExpand)
            {
                BarraLateralMenu.Width -= 5;
                if (BarraLateralMenu.Width <= 55)
                {
                    sidebarExpand = false;
                    tmSidebarTransition.Stop();
                }
            }
            // Se o menu está retraido...
            else
            {
                BarraLateralMenu.Width += 10;
                if (BarraLateralMenu.Width >= 220)
                {
                    sidebarExpand = true;
                    tmSidebarTransition.Stop();
                }
            }
        } // end menu responsivo...

        //----------------------
        // SUBMENU FINANCEIRO RESPONSIVO...
        // Evento para ocultar ou mostrar o SUBMENU-financeiro ao clicar no btnFinanceiro...
        //
        // Indica se o submenu financeiro está expandido...
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
                pnlSubMenuFinanceiro.Height += 10;
                if (pnlSubMenuFinanceiro.Height >= 138)
                {
                    TmSubMenuFinanceiroTransition.Stop();
                    subMenuFinanceiroExpand = true;
                }
            }
            else // esconde
            {
                pnlSubMenuFinanceiro.Height -= 10;
                if (pnlSubMenuFinanceiro.Height <= 49)
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
                pnlSubMenuFinanceiro.BackColor = Color.FromArgb(37, 46, 59);
                btnContasPagar.BackColor = Color.FromArgb(37, 46, 59);
                btnContasReceber.BackColor = Color.FromArgb(37, 46, 59);
                //btnFinanceiro.BackColor = Color.FromArgb(37, 46, 59);
            }
            else // ao retrair
            {
                pnlSubMenuFinanceiro.BackColor = Color.FromArgb(26, 32, 40);
                btnContasPagar.BackColor = Color.FromArgb(26, 32, 40);
                btnContasReceber.BackColor = Color.FromArgb(26, 32, 40);
                //btnFinanceiro.BackColor = Color.FromArgb(26, 32, 40);              
            }
        }
        #endregion menu lateral e sub menu finaceiro responsivo

        //
        // 
        // btn FESTAS...
        //
        private void btnFestas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormFestasCadastro(), manterAberto: true);
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

        }
        //
        // USUARIOS...
        //
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormUsuariosCadastro(), manterAberto: false);
        }
        //----------------------------------------------------------------
        // método para ABRIR formulários
        //
        private void AbrirFormulario(Form form, bool manterAberto = false)
        {
            Type formType = form.GetType();

            // Fecha todos os formulários que não precisam ser mantidos abertos
            foreach (var key in new List<Type>(openForms.Keys))
            {
                if (!openForms[key].manterAberto && openForms[key].form != null)
                {
                    openForms[key].form.Close();
                    openForms.Remove(key);
                }
            }
            // Verifica se o formulário já está aberto e ativo
            if (openForms.ContainsKey(formType) && openForms[formType].form != null && !openForms[formType].form.IsDisposed)
            {
                openForms[formType].form.Activate();
            }
            else
            {
                // Se o formulário já estava no dicionário, mas foi fechado, recria a instância
                if (openForms.ContainsKey(formType) && openForms[formType].form != null && openForms[formType].form.IsDisposed)
                {
                    openForms.Remove(formType);
                }

                // Configura o evento FormClosed para liberar recursos
                form.FormClosed += (sender, e) =>
                {
                    if (!manterAberto)
                    {
                        openForms.Remove(formType);
                        form.Dispose(); // Libera recursos ao fechar
                    }
                    else
                    {
                        // Atualiza o dicionário para refletir que o formulário foi fechado
                        openForms[formType] = (null!, true); // Usa null-forgiving operator (!) para indicar que o valor pode ser null
                    }
                };

                // Exibe form
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
                               
                // Adiciona ou atualiza o formulário no dicionário
                openForms[formType] = (form, manterAberto);
            }
        }

        //***************************************************************************************************************
        // Para evitar a necessidade de verificar a nulidade de FormMenuBase.Instance repetidamente
        // antes de chamar myUtilities.myMessageBox,
        // criar um método auxiliar dentro da classe FormMenuBase que encapsule essa verificação.
        // Dessa forma, centraliza a verificação em um único lugar e simplifica o código em outras partes do programa.
        public static void ShowMyMessageBox(string mensagem, string titulo = "Mensagem", MessageBoxButtons botoes = MessageBoxButtons.OK, MessageBoxIcon icone = MessageBoxIcon.Information, int opacidade = 60, Color cor = default)
        {
            if (Instance != null)
            {
                myUtilities.myMessageBox(Instance, mensagem, titulo, botoes, icone, opacidade, cor);
            }
            else
            {
                // Opcional: lançar uma exceção ou logar o erro caso a Instance seja nula
                throw new InvalidOperationException("FormMenuBase.Instance não está inicializada.");
            }
        }
        // método auxiliar para CreateModalOverlay...
        public static void ShowModalOverlay(Form? frmExibir, Action? mostrarMensagem = null, int opacidade = 60, Color cor = default)
        {
            if (Instance != null)
            {
                myUtilities.CreateModalOverlay(Instance, mostrarMensagem, frmExibir, opacidade, cor);
            }
            else
            {
                // Opcional: lançar uma exceção ou logar o erro caso a Instance seja nula
                throw new InvalidOperationException("FormMenuBase.Instance não está inicializada.");
            }
        }

    } // end class FormMenuBase...
} // end namespace

