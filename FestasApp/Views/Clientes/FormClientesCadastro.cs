//---------------------------------------------------------------
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
//---------------------------------------------------------------
//

namespace FestasApp.Views
{
    public partial class FormClientesCadastro : FormBaseCadastro
    {
        /// <summary>
        /// declaração de instâncias
        /// </summary>
        private clsParam _clienteId; 
        private DataTable dtClientes;
        private ClientesViewModel _viewModel;

        /// <summary>
        /// construtor
        /// </summary>
        public FormClientesCadastro()
        {
            InitializeComponent();
                _clienteId = new clsParam();
                dtClientes = new DataTable();
                _viewModel = new ClientesViewModel();

            SuspendLayout();
                SetThisForm();
                SetControls();
                AddEventHandlers();
            ResumeLayout(false);
        }    
        /// <summary>
        /// Evento disparado quando o formulário de cliente é carregado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClientesCadastro_Load(object? sender, EventArgs e)
        {
            // Configurações adicionais podem ser feitas aqui
            CarregarDtgClientesEF();
        }
        /// <summary>
        /// Configurações iniciais do formulário de cliente
        /// </summary>
        private void SetThisForm()
        {
            // Adicione aqui as configurações específicas para o formulário de cliente
            // Remove a borda do formulário
            this.FormBorderStyle = FormBorderStyle.None;
            lblTitulo.Text = "C a d a s t r o  d e  C l i e n t e s";
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }
        /// <summary>
        /// configura controles deste formulário
        /// </summary>
        private void SetControls()
        {
            // Configurar as colunas do DataGridView
            ConfigurarColunasDtgClientes();
            ConfigurarDtgFestasXCliente();
        }
        //
        /// <summary>
        /// adiciona eventos Handlers...
        /// </summary>
        private void AddEventHandlers()
        {
            // Adiciona o manipulador de eventos para os botões do ToolStrip
            this.tstbtnNovo.Click += TstbtnNovo_Click;
            this.tstbtnEditar.Click += TstbtnEditar_Click;
            this.tstbtnConsultar.Click += TstbtnConsultar_Click;
            this.tstbtnExcluir.Click += TstbtnExcluir_Click;
            this.Load += FormClientesCadastro_Load;
        }
        /// <summary>
        /// método selectionChanged dtgClientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtgClientes_SelectionChanged(object? sender, EventArgs e)
        {
            if (dtgClientes.SelectedRows.Count > 0)
            {
                var selectedRow = dtgClientes.SelectedRows[0]; // Obtém a linha selecionada
                _clienteId.Id = Convert.ToInt32(selectedRow.Cells[ColId].Value); // obtém o valor do Id da Festa da linha selecionada
                //
                _viewModel.FestasDoCliente = _viewModel.ObterFestasPorCliente(_clienteId.Id.Value);
                AtualizarDtgFestasXCli();
            }
            else
            {
                _clienteId.Id = 0; // Define como 0 se nenhuma linha estiver selecionada
            }
        }
        

        /// <summary>
        /// btn NOVO...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            //clsParam clienteId = new clsParam(0);
            _clienteId.Id = 0;
            AbrirFormCRUDEF(operacao);
        }
        /// <summary>
        /// btn EDITAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EDITAR;
            AbrirFormCRUDEF(operacao);
        }
        /// <summary>
        /// btn CONSULTAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.CONSULTAR;
            AbrirFormCRUDEF(operacao);
        }
        /// <summary>
        /// btn EXCLUIR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EXCLUIR;
            AbrirFormCRUDEF(operacao);
        }
        /// <summary>
        /// método para abrir o formCRUD
        /// </summary>
        /// <param name="operacao"></param>
        private async void AbrirFormCRUDEF(OperacaoCRUD operacao)
        {
            // Verifique se há uma ClientId selecionada no DataGridView
            if (_clienteId.IsValid())
            {
                try
                {
                    // Abre o formulário CRUD para edição passando o ID do cliente e a operação
                    using (FormClientesCRUD frm = new(_clienteId, operacao))
                    {
                        await FormMenuMain.ShowModalOverlay(frm); // Usar a Modal para exibir o FormCRUD

                        ////// Após o formulário CRUD ser fechado, verifique se há um cliente selecionado
                        //if (operacao == OperacaoCRUD.NOVO && _viewModel.ClienteSelecionado != null)
                        //{
                        //    // Aqui o ClienteSelecionado já deve ter o novo cliente adicionado
                            _clienteId.Id = frm._viewModel.ClienteSelecionado!.cli_id;
                        //}
                        //else
                        //{
                        //    _viewModel.ClienteSelecionado.cli_id = _clienteId.Id!.Value;
                        //}

                        // quando volta do CRUD, atualiza dataGrid
                        CarregarDtgClientesEF(); 
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
        /// <summary>
        /// Carrega dataGrid com dados da tabela tblclientes, através de ViewModel
        /// </summary>
        private void CarregarDtgClientesEF()
        {
            // testa a conexão
            if (!_viewModel.TestarConexao())
            {
                if (tstbtnNovo != null) tstbtnNovo.Enabled = false;
                TratarControles(habilitar: false); // Desabilita botões de CRUD em caso de erro
                return;
            }
            //
            DataGridView dtg = dtgClientes;

            // Captura o ID do cliente atualmente selecionado
            int? clienteIdSelecionado = null;

            if (dtg.SelectedRows.Count > 0)
            {
                clienteIdSelecionado = Convert.ToInt32(dtg.SelectedRows[0].Cells[0].Value);

                //if (_viewModel.ClienteSelecionado != null)
                //    clienteIdSelecionado = _viewModel.ClienteSelecionado?.cli_id;

                if (_clienteId.Id != clienteIdSelecionado)
                {
                    clienteIdSelecionado = _clienteId.Id;
                }
            }

            try
            {
                // Desassocia a fonte de dados para evitar o erro ao limpar as linhas
                //dtg.DataSource = null;

                // Limpa as linhas existentes sem alterar as colunas
                dtg.Rows.Clear();

                // reinicia com new() para garantir atualização da lista de clientes
                _viewModel = new();
                // Obtem a lista atualizada de clientes do ViewModel
                var listaClientes = _viewModel.Clientes;

                // Preenche o DataTable com os dados da lista
                if (listaClientes != null)
                {
                    foreach (var cliente in listaClientes)
                    {
                        // adiciona linhas com dados ao dtg
                        dtg.Rows.Add(
                            cliente.cli_id,
                            cliente.cli_nome,
                            cliente.cli_telefone1,
                            cliente.cli_telefone2,
                            cliente.cli_cpf,
                            cliente.cli_endereco,
                            cliente.cli_cep,
                            cliente.cli_cidade,
                            cliente.cli_uf
                        );
                    }
                }

                // Seleciona a linha correspondente ao cliente previamente selecionado
                if (clienteIdSelecionado.HasValue)
                {
                    foreach (DataGridViewRow row in dtg.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) == clienteIdSelecionado.Value)
                        {
                            row.Selected = true;
                            //dtg.FirstDisplayedScrollingRowIndex = row.Index; // Faz rolar até o cliente selecionado
                            dtg.CurrentCell = row.Cells[0]; // Define o foco na célula da linha selecionada
                            break;
                        }
                    }
                }
                else if (dtg.Rows.Count > 0)
                {
                    // rolar até a primeira linha para garantir que está visível
                    dtg.Rows[0].Selected = true;
                    dtg.FirstDisplayedScrollingRowIndex = 0;
                    //dtg.CurrentCell = row.Cells[0]; // Define o foco na célula da linha selecionada
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
        /// <summary>
        /// Configura o DataGridView para exibir os clientes.
        /// </summary>
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

            //dtg.Columns[ColCpf].DefaultCellStyle.Format = "___.___.___-__";

            // Adiciona o evento CellFormatting para formatação dos dados
            dtgClientes.CellFormatting += DtgClientes_CellFormatting;
            dtgClientes.SelectionChanged += DtgClientes_SelectionChanged;
            dtgClientes.CellContentDoubleClick += DtgClientes_CellContentDoubleClick;
        }
        /// <summary>
        /// Evento disparado para formatar as células do DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtgClientes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Formatar Telefone-1
            if (e.ColumnIndex == ColTelefone1 && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 11)
                {
                    e.Value = value.ToTelefone(); //String.Format("{0:(00)00000-0000}", Int64.Parse(value));
                    e.FormattingApplied = true;
                }
            }
            // Formatar Telefone-2
            if (e.ColumnIndex == ColTelefone2 && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 11)
                {
                    e.Value = value.ToTelefone(); //String.Format("{0:(00)00000-0000}", Int64.Parse(value));
                    e.FormattingApplied = true;
                }
            }
            //
            // Formatar CPF
            if (e.ColumnIndex == ColCpf && e.Value != null)
            {
                string? value = e.Value.ToString();

                if (!string.IsNullOrEmpty(value) && value.Length == 11)
                {
                    e.Value = value.ToCpf(); // $"{value.Substring(0, 3)}.{value.Substring(3, 3)}.{value.Substring(6, 3)}-{value.Substring(9, 2)}";
                    e.FormattingApplied = true;
                }
            }
            //
            // Formatar CEP
            if (e.ColumnIndex == ColCep && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 8)
                {
                    e.Value = value.ToCep(); //$"{value.Substring(0, 2)}.{value.Substring(2, 3)}-{value.Substring(5, 3)}";
                    e.FormattingApplied = true;
                }
            }
        }
        /// <summary>
        /// DuploClick dtgClientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtgClientes_CellContentDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            tstbtnEditar.PerformClick();
        }
        /// <summary>
        /// Configura o DataGridView para exibir as FestasXcliente.
        /// </summary>
        private const int ColDataFesta = 0;
        private const int ColTipoEvento = 1;
        private const int ColEspaco = 2;
        private const int ColTema = 3;
        private const int ColPacote = 4;
        private const int ColStatus = 5;
        private const int ColValor = 6;
        private void ConfigurarDtgFestasXCliente()
        {
            DataGridView dtg = dtgFestasXCli;
            dtg.Columns.Clear();

            // configurar colunas
            myFunctions.ConfigurarAdicionarColuna(dtg, ColDataFesta, "Data da Festa", 160, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColTipoEvento, "Tipo Evento", 160, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColEspaco, "Espaço", 160, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColTema, "Tema", 160, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColPacote, "Pacote", 160, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColStatus, "Status", 120, alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColValor, "Valor", 100, alignment: DataGridViewContentAlignment.MiddleCenter);

            dtg.Columns[ColValor].DefaultCellStyle.Format = "N2";

            // Configuração da altura geral das linhas
            dtg.RowTemplate.Height = 25;

            // Ativar modo de ajuste automático com base no conteúdo
            //dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //// Alternativamente, ajustar individualmente por coluna, se preferir
            //dtg.Columns[ColDataFesta].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtg.Columns[ColTipoEvento].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Essa coluna irá preencher o espaço restante
            //dtg.Columns[ColEspaco].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtg.Columns[ColTema].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtg.Columns[ColPacote].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtg.Columns[ColStatus].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtg.Columns[ColValor].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Configurar DataGridView como somente leitura
            dtg.ReadOnly = true;

            // Desmarcar seleção automática ao carregar dados
            dtg.ClearSelection();
        }
        /// <summary>
        /// 
        /// </summary>
        private void AtualizarDtgFestasXCli()
        {
            dtgFestasXCli.Rows.Clear();

            foreach (var festa in _viewModel.FestasDoCliente)
            {
                dtgFestasXCli.Rows.Add(
                    //festa.fest_id,
                    festa.fest_dtFesta?.ToString("dd/MM/yyyy"),
                    festa.TipoEvento?.tpev_nome,
                    festa.Espaco?.espc_nome,
                    festa.Tema?.tema_nome,
                    festa.Pacote?.pct_nome,
                    festa.Status?.stt_status,
                    festa.fest_valor?.ToString("C")
                );
            }
        }
        /// <summary>
        /// txtPesquisaCliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPesquisaCliente_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientesEF(txtPesquisaCliente.Text);
        }
        /// <summary>
        /// método para filtrar dtgCleientes
        /// </summary>
        /// <param name="nomeCliente"></param>
        private void FiltrarClientesEF(string nomeCliente)
        {
            DataGridView dtg = dtgClientes;
            // Limpa todas as linhas antes de adicionar as filtradas
            dtg.Rows.Clear();
            try
            {
                // Carregar os dados do DbSet<T>
                var listaClientes = _viewModel.Clientes;

                // Filtrar a lista de clientes com base no nome
                var clientesFiltrados = listaClientes
                    .Where(cliente => cliente.cli_nome!.Contains(nomeCliente, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Preenche o DataGridView com os dados filtrados
                if (clientesFiltrados != null)
                {
                    foreach (var cliente in clientesFiltrados)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dtg);
                        row.Cells[ColId].Value = cliente.cli_id;
                        row.Cells[ColNomeCliente].Value = cliente.cli_nome;
                        row.Cells[ColTelefone1].Value = cliente.cli_telefone1;
                        row.Cells[ColTelefone2].Value = cliente.cli_telefone2;
                        row.Cells[ColCpf].Value = cliente.cli_cpf;
                        row.Cells[ColEndereco].Value = cliente.cli_endereco;
                        row.Cells[ColCep].Value = cliente.cli_cep;
                        row.Cells[ColCidade].Value = cliente.cli_cidade;
                        row.Cells[ColUf].Value = cliente.cli_uf;
                        dtg.Rows.Add(row);
                    }
                }

                // Seleciona a primeira linha se houver linhas no DataGridView
                if (dtg.Rows.Count > 0)
                {
                    dtg.Rows[0].Selected = true;
                    dtg.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // Trata qualquer exceção que ocorra durante o processo de filtragem
                FormMenuMain.ShowMyMessageBox("Erro ao filtrar clientes: " + ex.Message, "Erro na Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //*********************** SEM USO temporários ***********************
        //
        // Método para filtrar clientes no DataGridView
        private void FiltrarClientesSEMUSO(string nomeCliente)
        {
            try
            {
                // Verifica se a fonte de dados é um BindingSource
                if (dtgClientes.DataSource is BindingSource bs)
                {
                    // Verifica se o campo de pesquisa não está vazio
                    if (!string.IsNullOrWhiteSpace(txtPesquisaCliente.Text))
                    {
                        // Monta a string para filtro
                        string filtro = string.Format("[{0}] LIKE '%{1}%'", "cli_nome", txtPesquisaCliente.Text);

                        // Aplica o filtro ao BindingSource
                        bs.Filter = filtro;
                    }
                    else
                    {
                        // Se o campo de pesquisa estiver vazio, remove o filtro
                        bs.RemoveFilter();
                    }
                }
                else
                {
                    throw new InvalidOperationException("A fonte de dados não é um BindingSource.");
                }
            }
            catch (Exception ex)
            {
                // Exibe a mensagem de erro
                FormMenuMain.ShowMyMessageBox("Erro ao filtrar clientes: " + ex.Message, "Pesquisa Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        // end FiltrarClientes
        //

    } // end class
} // end namespace
