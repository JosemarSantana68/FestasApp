//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 16/06/2024
//   
//   FORMULÁRIO DE USUARIOS
//
//************************************************************

namespace FestasApp.Views.Usuarios
{
    public partial class FormUsuariosCadastro : FormBaseCadastro
    {
        private DataTable dtUsuarios = new DataTable();

        //
        // construtor
        public FormUsuariosCadastro()
        {
            // Configurações iniciais antes da inicialização dos componentes
            InitializeComponent();

            this.SuspendLayout();
                SetThisForm();
                SetControls();
                AddEventHandlers();
            this.ResumeLayout();
        }
        //
        private void SetControls()
        {
            ConfigurarColunasDtgUsuarios();
        }
        //
        private void FormUsuariosCadastro_Load(object? sender, EventArgs e)
        {
            CarregarDtgUsuarios();
        }
        //
        // Configurações iniciais do formulário
        private void SetThisForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            // Adicione aqui as configurações específicas para o formulário
            lblTitulo.Text = "C a d a s t r o  d e  U s u á r i o s";           
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }
        //
        // adiciona eventos aos stripsButtons...
        private void AddEventHandlers()
        {
            // Adiciona o manipulador de eventos para os botões do ToolStrip
            this.tstbtnNovo.Click += TstbtnNovo_Click;
            this.tstbtnEditar.Click += TstbtnEditar_Click;
            this.tstbtnConsultar.Click += TstbtnConsultar_Click;
            this.tstbtnExcluir.Click += TstbtnExcluir_Click;
            this.Load += FormUsuariosCadastro_Load;
        }
        //
        // btn NOVO (CREATE)
        private async void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            // incrementar Lógica do evento do botão
            clsUsuarios usuario = new clsUsuarios(); // usuario para passar
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            FormUsuariosCRUD frm = new FormUsuariosCRUD(usuario, operacao);

            // Usar a CreateModalOverlayAsync para exibir o FormClientesCRUD
            await FormMenuMain.ShowModalOverlay(frm);

            // quando volta do CRUD, atualiza dataGrid com dados da tabela no BD
            CarregarDtgUsuarios();
        }
        //
        // btn CONSULTAR (READ)
        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.CONSULTAR;
            AbrirFormCRUD(operacao);
        }
        //-----------------------------------------
        // btn EDITAR (UPDATE)
        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EDITAR;
            AbrirFormCRUD(operacao);
        }
        //-----------------------------------------
        // btn EXCLUIR (DELETE)
        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EXCLUIR;
            AbrirFormCRUD(operacao);
        }
        //-----------------------
        // Abrir Formulário CRUD
        private void AbrirFormCRUD(OperacaoCRUD operacao)
        {
            AbrirFormCRUDGenerico(
                dtg: dtgUsuarios,
                colIdIndex: ColId,
                mapper: row => new clsUsuarios //Func<DataGridViewRow, T> mapper,
                {
                    user_id = Convert.ToInt32(row.Cells[0].Value),
                    user_nome = row.Cells[ColNomeUser].Value.ToString(),
                    user_login = row.Cells[ColLogin].Value.ToString(),
                    user_email = row.Cells[ColEmail].Value.ToString(),
                    user_senha = row.Cells[ColSenha].Value.ToString(),
                    user_ativo = Convert.ToInt32(row.Cells[ColAtivo].Value) == 1 // Aqui convertendo 0 ou 1 para bool
                },
                reloadGrid: CarregarDtgUsuarios,
                formFactory: (usuario, op) => new FormUsuariosCRUD(usuario, op),
                operacao: operacao,
                delay: 1000
            );
        }
        //-------------------------------
        // carregar/atualizar dataGrid com dados da tabela tblusuarios do banco de dados
        private void CarregarDtgUsuarios()
        {
            dtgUsuarios.Rows.Clear(); // Limpa todas as linhas existentes no DataGridView

            try
            {
                // Obtém a lista de usuários usando o Entity Framework
                var listaUsuarios = repUsuarios.GetUsuariosEF();
                               
                if (listaUsuarios != null)
                {
                    // Adiciona os dados linha a linha no DataGridView
                    foreach (var usuario in listaUsuarios)
                    {
                        dtgUsuarios.Rows.Add(
                            usuario.user_id,
                            usuario.user_nome,
                            usuario.user_login,
                            usuario.user_email,
                            usuario.user_senha,
                            usuario.user_ativo
                            );
                    }
                    TratarControles(habilitado: true); // Habilita botões de CRUD
                }
                else
                {
                    FormMenuMain.ShowMyMessageBox("Nenhum Usuário encontrado.\nCarregarDtgUsuarios", "Carregar Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TratarControles(habilitado: false); // Desabilita botões de CRUD
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                FormMenuMain.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}\nCarregarDtgUsuarios", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TratarControles(habilitado: false); // Desabilita botões de CRUD em caso de erro
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                FormMenuMain.ShowMyMessageBox($"Erro: {ex.Message}\nCarregarDtgUsuarios", "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TratarControles(habilitado: false); // Desabilita botões de CRUD em caso de erro
            }
        }
        //
        private void TratarControles(bool habilitado)
        {
            // controles deste form
            //if (txtPesquisa != null) txtPesquisa.Enabled = !desabilitar;
            // controles do formBase
            TratarBtnCrud(habilitado);
        }

        //--------------------------------------------
        // DataGridViews
        // constantes
        private const int ColId = 0;
        private const int ColNomeUser = 1;
        private const int ColLogin = 2;
        private const int ColEmail = 3;
        private const int ColSenha = 4;
        private const int ColAtivo = 5;
        private void ConfigurarColunasDtgUsuarios()
        {
            DataGridView dtg = dtgUsuarios;

            dtg.AutoGenerateColumns = false;
            dtg.Columns.Clear();

            // configurar colunas
            myFunctions.ConfigurarAdicionarColuna(dtg, ColId, "ID", 30, "user_id", DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColNomeUser, "Nome Usuário", 200, "user_nome", padding: new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarAdicionarColuna(dtg, ColLogin, "Login", 120, "user_login");
            myFunctions.ConfigurarAdicionarColuna(dtg, ColEmail, "Email", 120, "user_email");
            myFunctions.ConfigurarAdicionarColuna(dtg, ColSenha, "Senha", 100, "user_senha");
            myFunctions.ConfigurarAdicionarColuna(dtg, ColAtivo, "Ativo", 100, "user_ativo", DataGridViewContentAlignment.MiddleCenter);
            //

            // Adiciona o evento CellFormatting para formatação dos dados
            dtg.CellFormatting += DtgUsuarios_CellFormatting;
        }
        //-----------------------------------------------------------
        // Evento disparado para formatar as células do DataGridView.
        private void DtgUsuarios_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Formatar Ativo
            if (dtgUsuarios.Columns[e.ColumnIndex].HeaderText == "Ativo" && e.Value != null)
            {
                // Verifica se o valor da célula é "0" ou "1"
                string? cellValue = e.Value.ToString();
                if (cellValue == "False" || cellValue == "True")
                {
                    int ativoValue = Convert.ToInt32(e.Value);
                    e.Value = ativoValue == 1 ? "SIM" : "NÃO";
                    e.FormattingApplied = true;
                }
            }
        }
     } // end class FormUsuariosCadastro
} // end namespace FestasApp.Views.Usuarios
