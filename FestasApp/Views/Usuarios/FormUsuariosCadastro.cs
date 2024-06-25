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
                this.FormBorderStyle = FormBorderStyle.None;
                ConfigurarForm();
                AddToolStripEventHandlers();
            this.ResumeLayout();
        }
        //
        // Configurações iniciais do formulário
        private void ConfigurarForm()
        {
            // Adicione aqui as configurações específicas para o formulário
            lblTitulo.Text = "C a d a s t r o  d e  U s u á r i o s";           
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            CarregarDtgUsuarios();
        }
        //----------------------------------------------
        // adiciona eventos aos stripsButtons...
        private void AddToolStripEventHandlers()
        {
            // Adiciona o manipulador de eventos para os botões do ToolStrip
            this.tstbtnNovo.Click += TstbtnNovo_Click;
            this.tstbtnEditar.Click += TstbtnEditar_Click;
            this.tstbtnConsultar.Click += TstbtnConsultar_Click;
            this.tstbtnExcluir.Click += TstbtnExcluir_Click;
        }
        //-----------------------------------------
        // Evento Click do botão NOVO...
        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            // incrementar Lógica do evento do botão
            clsUsuarios usuario = new clsUsuarios(); // usuario para passar
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            FormUsuariosCRUD frm = new FormUsuariosCRUD(usuario, operacao);

            // Usar a CreateModalOverlay para exibir o FormClientesCRUD
            FormMenuBase.ShowModalOverlay(frm);

            // quando volta do CRUD, atualiza dataGrid com dados da tabela no BD
            CarregarDtgUsuarios();
        }
        //-----------------------------------------
        // Evento Click do botão EDITAR
        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EDITAR;
            AbrirFormCRUD(operacao);
        }
        //-----------------------------------------
        // Evento Click do botão CONSULTAR
        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.CONSULTAR;
            AbrirFormCRUD(operacao);
        }
        //-----------------------------------------
        // Evento Click do botão EXCLUIR
        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EXCLUIR;
            AbrirFormCRUD(operacao);
        }
        //---------------------------------------------------------------
        // Abrir Formulário CRUD
        private void AbrirFormCRUD(OperacaoCRUD operacao)
        {
            // Declarar o datagrid
            var dtg = dtgUsuarios;

            // Verifique se há uma linha selecionada no DataGridView
            if (dtg.CurrentRow != null)
            {
                // Pegue o índice da linha atual
                int rowIndex = dtg.CurrentRow.Index;

                // Verifique se a célula da coluna desejada, ID, não é nula
                if (dtg.Rows[rowIndex].Cells[0].Value != null)
                {
                    try
                    {
                        // carrega os dados da linha selecionada no objeto usuario...
                        clsUsuarios usuario = new clsUsuarios
                        {
                            // Tente converter o valor da célula para inteiro
                            Id = Convert.ToInt32(dtgUsuarios.Rows[rowIndex].Cells[0].Value),
                            //
                            Nome = dtg.Rows[rowIndex].Cells[1].Value.ToString(),
                            Login = dtg.Rows[rowIndex].Cells[2].Value.ToString(),
                            Email = dtg.Rows[rowIndex].Cells[3].Value.ToString(),
                            Senha = dtg.Rows[rowIndex].Cells[4].Value.ToString(),
                            Ativo = Convert.ToInt32(dtg.Rows[rowIndex].Cells[5].Value) == 1 // Aqui convertendo 0 ou 1 para bool
                        };

                        // Abra o formulárioCRUD para edição passando a calsse e operação
                        using (FormUsuariosCRUD frm = new FormUsuariosCRUD(usuario, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            FormMenuBase.ShowModalOverlay(frm);

                            // quando volta do CRUD, atualiza dataGrid com dados da tabela no BD
                            CarregarDtgUsuarios();
                        }
                    }
                    catch (FormatException)
                    {
                        FormMenuBase.ShowMyMessageBox("O valor na primeira coluna não é um número válido.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidCastException)
                    {
                        FormMenuBase.ShowMyMessageBox("Não foi possível converter o valor na primeira coluna para um número inteiro.", "Erro de Conversão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        FormMenuBase.ShowMyMessageBox("Erro ao carregar dados do cliente: " + ex.Message);
                    }
                }
                else
                {
                    FormMenuBase.ShowMyMessageBox("A célula da primeira coluna está vazia.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                FormMenuBase.ShowMyMessageBox("Nenhuma linha está selecionada.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        } // end AbrirFormCRUD
        //-------------------------------
        // carregar dataGrid com dados da tabela tblusuarios do banco de dados
        private DataTable dtUsuarios = new DataTable();
        private void CarregarDtgUsuarios()
        {
            try
            {
                // carrega datagrid com dados da tabela
                dtUsuarios = clsUsuarios.ReadAllUsuario();

                if (dtUsuarios != null && dtUsuarios.Rows.Count > 0)
                {
                    dtgUsuarios.DataSource = dtUsuarios;
                    ConfigurarColunasDtgUsuarios();
                }
                else
                {
                    FormMenuBase.ShowMyMessageBox("Nenhum Usuário encontrado.", "Carregar Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                FormMenuBase.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                FormMenuBase.ShowMyMessageBox($"Erro: {ex.Message}", "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------------------------------------------
        // DataGridViews
        //
        private const int ColId = 0;
        private const int ColNomeUser = 1;
        private const int ColLogin = 2;
        private const int ColEmail = 3;
        private const int ColSenha = 4;
        private const int ColAtivo = 5;
        private void ConfigurarColunasDtgUsuarios()
        {
            //-----------------------------------------
            // Colunas
            //
            DataGridView dtg = dtgUsuarios;
            // configurar colunas
            myFunctions.ConfigurarColuna(dtg, ColId, "ID", 30, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColNomeUser, "Nome Usuário", 200, padding: new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarColuna(dtg, ColLogin, "Login", 12);
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
