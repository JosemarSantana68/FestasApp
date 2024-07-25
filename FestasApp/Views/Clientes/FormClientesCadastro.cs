//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 06/06/2024
//   
//   FORMULÁRIO DE CLIENTES - CADASTRO
//
//************************************************************

namespace FestasApp.Views
{
    public partial class FormClientesCadastro : FormBaseCadastro
    {
        // declaração de instâncias
        private clsParam clienteId = new clsParam(); 
        private DataTable dtClientes = new DataTable();
        //
        // construtor
        public FormClientesCadastro()
        {
            InitializeComponent();
            SuspendLayout();
                SetThisForm();
                SetControls();
                AddEventHandlers();
            ResumeLayout(false);
        }    
        //
        // Evento disparado quando o formulário de cliente é carregado
        private void FormClientesCadastro_Load(object? sender, EventArgs e)
        {
            // Configurações adicionais podem ser feitas aqui
            CarregarDtgClientesEF();
        }
        //
        // Configurações iniciais do formulário de cliente
        private void SetThisForm()
        {
            // Adicione aqui as configurações específicas para o formulário de cliente
            // Remove a borda do formulário
            this.FormBorderStyle = FormBorderStyle.None;
            lblTitulo.Text = "C a d a s t r o  d e  C l i e n t e s";
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }
        //
        private void SetControls()
        {
            // Configurar as colunas do DataGridView
            ConfigurarColunasDtgClientes();
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
            this.Load += FormClientesCadastro_Load;
            dtgClientes.SelectionChanged += DtgClientes_SelectionChanged;
        }
        //
        private void DtgClientes_SelectionChanged(object? sender, EventArgs e)
        {
            if (dtgClientes.SelectedRows.Count > 0)
            {
                var selectedRow = dtgClientes.SelectedRows[0]; // Obtém a linha selecionada
                clienteId.Id = Convert.ToInt32(selectedRow.Cells[ColId].Value); // obtém o valor do Id da Festa da linha selecionada
            }
            else
            {
                clienteId.Id = 0; // Define como 0 se nenhuma linha estiver selecionada
            }
        }
        //
        // btn NOVO...
        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            //clsParam clienteId = new clsParam(0);
            clienteId.Id = 0;
            AbrirFormCRUDEF(operacao);
        }
        //
        // btn EDITAR
        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EDITAR;
            AbrirFormCRUDEF(operacao);
        }
        //
        // btn CONSULTAR
        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.CONSULTAR;
            AbrirFormCRUDEF(operacao);
        }
        //
        // btn EXCLUIR
        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EXCLUIR;
            AbrirFormCRUDEF(operacao);
        }
        //
        private void AbrirFormCRUDEF(OperacaoCRUD operacao)
        {
            // Verifique se há uma ClientId selecionada no DataGridView
            if (clienteId.IsValid())
            {
                try
                {
                    // Abre o formulário CRUD para edição passando o ID do cliente e a operação
                    using (FormClientesCRUD frm = new FormClientesCRUD(clienteId, operacao))
                    {
                        FormMenuMain.ShowModalOverlay(frm); // Usar a Modal para exibir o FormCRUD
                        CarregarDtgClientesEF(); // quando volta do CRUD, atualiza dataGrid
                    }
                }
                catch (Exception ex)
                {
                    FormMenuMain.ShowMyMessageBox($"Erro ao carregar dados do cliente: {ex.Message}\nAbrirFormCRUDEF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                FormMenuMain.ShowMyMessageBox("Nenhuma linha está selecionada.\nAbrirFormCRUDEF", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //
        // carregar dataGrid com dados da tabela tblclientes do banco de dados usando LINQ e EF
        private void CarregarDtgClientesEF()
        {
            // testa a conexão
            if (!myConnMySql.TestarConexao())
            {
                if (tstbtnNovo != null) tstbtnNovo.Enabled = false;
                TratarControles(habilitar: false); // Desabilita botões de CRUD em caso de erro
                return;
            }
            //
            DataGridView dtg = dtgClientes;
            dtg.Rows.Clear();

            try
            {
                // Carregar os dados do DbSet<T>
                var listaClientes = repClientesEF.GetClientesEF();

                //dtg.DataSource = listaClientes;
                if (listaClientes != null)
                {
                    foreach (var clientes in listaClientes)
                    {
                        dtg.Rows.Add(
                            clientes.cli_id,
                            clientes.cli_nome,
                            clientes.cli_telefone1,
                            clientes.cli_telefone2,
                            clientes.cli_cpf,
                            clientes.cli_endereco,
                            clientes.cli_cep,
                            clientes.cli_cidade,
                            clientes.cli_uf
                            );
                    }
                }
                // Seleciona a primeira linha se houver linhas no DataGridView
                if (dtg.Rows.Count > 0)
                {
                    dtg.Rows[0].Selected = true;
                    // Opcional: Pode rolar até a primeira linha para garantir que está visível
                    dtg.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                FormMenuMain.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}\nCarregarDtgClientesEF", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TratarControles(habilitar: false); // Desabilita botões de CRUD em caso de erro
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                FormMenuMain.ShowMyMessageBox($"Erro: {ex.Message}\nCarregarDtgClientesEF", "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TratarControles(habilitar: false); // Desabilita botões de CRUD em caso de erro
            }
        }
        //
        private void TratarControles(bool habilitar)
        {
            // controles deste form
            if (txtPesquisaCliente != null) txtPesquisaCliente.Enabled = habilitar;
            // controles do formBase
            TratarBtnCrud(habilitar);
        }
        //
        // Configura o DataGridView para exibir os clientes.
        //
        private const int ColId = 0;
        private const int ColNomeCliente = 1;
        private const int ColTelefone1 = 2;
        private const int ColTelefone2 = 3;
        private const int ColCpf = 4;
        private const int ColEndereco = 5;
        private const int ColCep = 6;
        private const int ColCidade = 7;
        private const int ColUf = 8;
        private void ConfigurarColunasDtgClientes()
        {
            DataGridView dtg = dtgClientes;
            dtg.Columns.Clear();

            // configurar colunas
            myFunctions.ConfigurarAdicionarColuna(dtg, ColId, "ID", 30, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColNomeCliente, "Nome Cliente", 220, padding: new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarAdicionarColuna(dtg, ColTelefone1, "Telefone-1", 120, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColTelefone2, "Telefone-2", 120, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColCpf, "CPF", 100, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColEndereco, "Endereço", 220);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColCep, "CEP", 80, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColCidade, "Cidade", 120);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColUf, "UF", 80, alignment: DataGridViewContentAlignment.MiddleCenter);

            // Adiciona o evento CellFormatting para formatação dos dados
            dtgClientes.CellFormatting += DtgClientes_CellFormatting;

        } // end ConfigurarDtgClientes
        //
        // Evento disparado para formatar as células do DataGridView.
        private void DtgClientes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Formatar Telefone-1
            if (e.ColumnIndex == ColTelefone1 && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 11)
                {
                    e.Value = String.Format("{0:(00)00000-0000}", Int64.Parse(value));
                    e.FormattingApplied = true;
                }
            }
            // Formatar Telefone-2
            if (e.ColumnIndex == ColTelefone2 && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 11)
                {
                    e.Value = String.Format("{0:(00)00000-0000}", Int64.Parse(value));
                    e.FormattingApplied = true;
                }
            }
            // Formatar CPF
            if (e.ColumnIndex == ColCpf && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 11)
                {
                    e.Value = $"{value.Substring(0, 3)}.{value.Substring(3, 3)}.{value.Substring(6, 3)}-{value.Substring(9, 2)}";
                    e.FormattingApplied = true;
                }
            }
            // Formatar CEP
            if (e.ColumnIndex == ColCep && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 8)
                {
                    e.Value = $"{value.Substring(0, 2)}.{value.Substring(2, 3)}-{value.Substring(5, 3)}";
                    e.FormattingApplied = true;
                }
            }
        }
        //
        // DuploClick dtgClientes...
        private void dtgClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tstbtnEditar.PerformClick();
        }
        //
        // txtPesquisaCliente
        private void txtPesquisaCliente_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }
        //
        // Método para filtrar clientes no DataGridView
        private void FiltrarClientes()
        {
            try
            {
                // Verifica se há uma fonte de dados
                if (dtgClientes.DataSource is DataTable dtlistaClientes)
                {
                    // Verifica se o campo de pesquisa não está vazio
                    if (!string.IsNullOrWhiteSpace(txtPesquisaCliente.Text))
                    {
                        // Monta a string para filtro
                        string filtro = string.Format("[{0}] LIKE '%{1}%'", "cli_nome", txtPesquisaCliente.Text);

                        // Aplica o filtro ao DataTable
                        dtlistaClientes.DefaultView.RowFilter = filtro;
                    }
                    else
                    {
                        // Se o campo de pesquisa estiver vazio, remove o filtro
                        dtlistaClientes.DefaultView.RowFilter = string.Empty;
                    }
                }
                else
                {
                    throw new InvalidOperationException("A fonte de dados não é um DataTable.");
                }
            }
            catch (Exception ex)
            {
                // Exibe a mensagem de erro
                FormMenuMain.ShowMyMessageBox("Erro ao filtrar clientes: " + ex.Message, "Pesquisa Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // end FiltrarClientes
    } // end class
} // end namespace
