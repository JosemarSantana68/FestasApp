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
        //
        // construtor
        public FormUsuariosCadastro()
        {
            // Configurações iniciais antes da inicialização dos componentes
            InitializeComponent();

            this.SuspendLayout();
                SetThisForm();
                AddToolStripEventHandlers();
            this.ResumeLayout();
        }
        //
        // Configurações iniciais do formulário
        private void SetThisForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            // Adicione aqui as configurações específicas para o formulário
            lblTitulo.Text = "C a d a s t r o  d e  U s u á r i o s";           
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            CarregarDtgUsuarios();
        }
        //
        // adiciona eventos aos stripsButtons...
        private void AddToolStripEventHandlers()
        {
            // Adiciona o manipulador de eventos para os botões do ToolStrip
            this.tstbtnNovo.Click += TstbtnNovo_Click;
            this.tstbtnEditar.Click += TstbtnEditar_Click;
            this.tstbtnConsultar.Click += TstbtnConsultar_Click;
            this.tstbtnExcluir.Click += TstbtnExcluir_Click;
        }
        //
        // btn NOVO (CREATE)
        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            // incrementar Lógica do evento do botão
            clsUsuarios usuario = new clsUsuarios(); // usuario para passar
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            FormUsuariosCRUD frm = new FormUsuariosCRUD(usuario, operacao);

            // Usar a CreateModalOverlay para exibir o FormClientesCRUD
            FormMenuMain.ShowModalOverlay(frm);

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
        //---------------------------------------------------------------
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
                operacao: operacao
            );
        }
        //-------------------------------
        // carregar/atualizar dataGrid com dados da tabela tblusuarios do banco de dados
        private DataTable dtUsuarios = new DataTable();
        private void CarregarDtgUsuarios()
        {
            try
            {
                // carrega datagrid com dados da tabela
                dtUsuarios = repUsuarios.ReadAllUsuario();

                if (dtUsuarios != null && dtUsuarios.Rows.Count > 0)
                {
                    dtgUsuarios.DataSource = dtUsuarios;
                    ConfigurarColunasDtgUsuarios();
                    TratarControles(desabilitar: false); // Habilita botões de CRUD
                }
                else
                {
                    FormMenuMain.ShowMyMessageBox("Nenhum Usuário encontrado.", "Carregar Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TratarControles(true); // Desabilita botões de CRUD
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                FormMenuMain.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TratarControles(true); // Desabilita botões de CRUD em caso de erro
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                FormMenuMain.ShowMyMessageBox($"Erro: {ex.Message}", "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TratarControles(true); // Desabilita botões de CRUD em caso de erro
            }
        }

        private void TratarControles(bool desabilitar)
        {
            // controles deste form
            //if (txtPesquisaCliente != null) txtPesquisaCliente.Enabled = !desabilitar;
            // controles do formBase
            TratarBtnCrud(desabilitar);
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
            // configurar colunas
            myFunctions.ConfigurarColuna(dtg, ColId, "ID", 30, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColNomeUser, "Nome Usuário", 200, padding: new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarColuna(dtg, ColLogin, "Login", 120);
            myFunctions.ConfigurarColuna(dtg, ColEmail, "Email", 120);
            myFunctions.ConfigurarColuna(dtg, ColSenha, "Senha", 100);
            myFunctions.ConfigurarColuna(dtg, ColAtivo, "Ativo", 100, DataGridViewContentAlignment.MiddleCenter);
            //
            // ordenar datagrid - Nome
            dtgUsuarios.Sort(dtgUsuarios.Columns[ColNomeUser], ListSortDirection.Ascending);

            // Adiciona o evento CellFormatting para formatação dos dados
            dtgUsuarios.CellFormatting += DtgUsuarios_CellFormatting;
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
                if (cellValue == "0" || cellValue == "1")
                {
                    int ativoValue = Convert.ToInt32(e.Value);
                    e.Value = ativoValue == 1 ? "SIM" : "NÃO";
                    e.FormattingApplied = true;
                }
            }
        }
     } // end class FormUsuariosCadastro
} // end namespace FestasApp.Views.Usuarios
