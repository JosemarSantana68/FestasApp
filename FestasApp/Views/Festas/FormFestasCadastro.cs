//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 12/06/2024
//   
//   FORMULÁRIO DE FESTAS
//
//************************************************************

namespace FestasApp.Views
{
    public partial class FormFestasCadastro : FormBaseCadastro
    {    
        // dependências: instancia objetos das classes...
        private clsFestasDetalhes festasDetalhes = new clsFestasDetalhes();
        private clsFestas festa = new clsFestas();
        private clsFestasContext _context = new clsFestasContext();

        

        // criação - construtor
        public FormFestasCadastro()
        {
            /* Aqui é o lugar ideal para configurar:
            1.Inicialização de componentes: Configuração básica dos controles que estarão no formulário (definição de propriedades visuais e comportamentais).
            2.Event Handlers: Associação de eventos aos seus respectivos manipuladores, como clique de botão, alteração de texto, etc.
            3.Definição de propriedades estáticas: Propriedades que não vão depender de nenhuma lógica dinâmica ou de dados que precisam ser carregados de fontes externas.
             */

            SuspendLayout();
            InitializeComponent();
            
            //_context = context;
            SetThisForm();
            SetControls();

            AddToolStripEventHandlers();
            CarregarDtgFestasEF();

            ResumeLayout(false);
        }
        // carregamento
        private void FormFestas_Load(object sender, EventArgs e)
        {
            /* Aqui é o lugar ideal para configurar:
            1.Carregamento de dados: Busca e carregamento de dados de fontes externas, como bancos de dados ou arquivos.
            2.Inicialização de lógica de negócio: Qualquer lógica de inicialização que dependa de dados ou estado do sistema.
            3.Configuração dinâmica: Configuração de controles com base em dados carregados dinamicamente ou estado da aplicação.
             */
            
        }
        //
        // Configurações iniciais do formulário de cliente
        private void SetThisForm()
        {
            // Adicione aqui as configurações específicas para o formulário de cliente
            this.FormBorderStyle = FormBorderStyle.None;
            lblTitulo.Text = "C a d a s t r o  d e  F e s t a s";
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);           
        }
        private void SetControls()
        {
            ConfigurarColunasDtgFestas();
            ConfigurarColunasDtgItensFestas();
        }
        //
        // DataGridFestas
        private DataTable dtFestas = new DataTable();
        //
        private void TratarControles(bool desabilitar)
        {
            // controles deste form
            
            //if (txtPesquisaCliente != null) txtPesquisaCliente.Enabled = !desabilitar;
            // controles do formBase
            TratarBtnCrud(desabilitar);
        }
        //
        // ENTITY FRAMEWORK
        private void CarregarDtgFestasEF()
        {
            DataGridView dtg = dtgFestas;
            dtg.Rows.Clear(); // Limpa linhas existentes no DataGridView
            try
            {
                var festas = _context.Festas
                    .Include(f => f.Cliente)
                    .Include(f => f.Pacote)
                    .Include(f => f.Tema)
                    .Include(f => f.Espaco)
                    .Include(f => f.Status)
                    .Include(f => f.TipoEvento)
                    .Include(f => f.Usuario)
                    .ToList();

                foreach (var festa in festas)
                {
                    dtg.Rows.Add(
                        festa.fest_id,
                        festa.fest_dtFesta?.ToString("dd/MM/yyyy"),
                        festa.Cliente?.cli_nome,
                        festa.Pacote?.pct_nome,
                        festa.Tema?.tema_nome,
                        festa.Espaco?.espc_nome,
                        festa.Status?.stt_status,
                        festa.TipoEvento?.tpev_nome,
                        festa.fest_valor,
                        festa.Usuario?.user_nome,
                        festa.fest_dtVenda?.ToString("dd/MM/yyyy")
                    );
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                FormMenuMain.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}\nCarregarDtgFestasEF", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tstbtnNovo != null) tstbtnNovo.Enabled = false;
                TratarControles(true); // Desabilita botões de CRUD em caso de erro
            }
            catch (Exception ex)
            {
                FormMenuMain.ShowMyMessageBox($"Erro ao carregar festas: {ex.Message}\nCarregarDtgFestasEF", "Erro de Conexão");
                if (tstbtnNovo != null) tstbtnNovo.Enabled = false;
                TratarControles(true); // Desabilita botões de CRUD em caso de erro
            }
        }
        //--------------------------------------------
        // DataGridViews
        // constantes com Numeros das colunas
        private const int ColId = 0;            // recebe clsFestas.Id
        private const int ColDataFesta = 1;     // clsFestas.DataFesta
        private const int ColClienteNome = 2;   // clsClientes.Nome
        private const int ColPacote = 3;        // clsFestasPacotes.Nome
        private const int ColTema = 4;          // clsFestasTemas.Nome
        private const int ColEspaco = 5;        // clsFestasEspacos.Nome
        private const int ColStatus = 6;        // clsFestasStatus.Nome
        private const int ColTipo = 7;          // clsTipoEvento.Nome
        private const int ColValor = 8;         // clsFestas.Valor
        private const int ColUserNome = 9;      // clsUsuarios.Nome
        private const int ColDataVenda = 10;    // clsFestas.DataVenda
        //
        private void ConfigurarColunasDtgFestas()
        {
            DataGridView dtg = dtgFestas;
            // Limpar colunas existentes
            //dtg.Columns.Clear();
            // configurar colunas
            myFunctions.ConfigurarAdicionarColuna(dtg, ColId, "ID", 30, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColDataFesta, "Data da Festa", 120, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColClienteNome, "Nome do Cliente", 200, padding: new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarAdicionarColuna(dtg, ColPacote, "Pacote", 120);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColTema, "Tema", 120);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColEspaco, "Espaco", 120);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColStatus, "Status", 120);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColTipo, "Tipo Evento", 120);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColValor, "Valor Total", 120, DataGridViewContentAlignment.MiddleRight);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColUserNome, "Vendedor", 120, padding: new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarAdicionarColuna(dtg, ColDataVenda, "Data da Venda", 120, DataGridViewContentAlignment.MiddleCenter);
            // Ordenar datagrid
            dtg.Sort(dtg.Columns[ColDataFesta], ListSortDirection.Ascending);
            dtg.Columns[ColValor].DefaultCellStyle.Format = "C2";

            // Adiciona o evento CellFormatting para formatação dos dados
            //dtg.CellFormatting += Dtg_CellFormatting;
        }
        // formatação dtgFestas
        private void Dtg_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar se a coluna é "Valor" e se o valor não é nulo
            if (e.ColumnIndex == ColValor && e.Value != null)
            {
                //string? value = e.Value.ToString();
                if (decimal.TryParse(e.Value.ToString(), out decimal decimalValue))
                {
                    e.Value = decimalValue.ToString("C2");
                    e.FormattingApplied = true;
                }
            }
        }
        //
        // Uso do método CalcularDataGridDatasSomas
        private void CalcularDataGrid()
        {
            myFunctions.CalcularDataGridDatasSomas(dtgFestas, ColDataFesta, ColValor, out int totalRegistros, out DateTime? menorData, out DateTime? maiorData, out decimal somaColuna);
            // Exibir os resultados em labels
            lblTotalFestas.Text = totalRegistros.ToString();

            lblPeriodoFestas.Text = menorData.HasValue && maiorData.HasValue
                 ? $"{menorData.Value.ToString("dd/MM/yyyy")} à {maiorData.Value.ToString("dd/MM/yyyy")}" : "N/A";

            //lblValorTotalFestas.Text = somaColuna.ToString("N2"); // Exibir a soma com separadores de milhar e duas casas decimais
            lblValorTotalFestas.Text = somaColuna.ToString("C", new CultureInfo("pt-BR"));
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
            // para o datagrid
            this.dtgFestas.SelectionChanged += DtgFestas_SelectionChanged;
        }
        //
        // variavels para gravar o id da festa selecionada
        private int? festaId;
        private void DtgFestas_SelectionChanged(object? sender, EventArgs e)
        {
            if (dtgFestas.SelectedRows.Count > 0)
            {
                var selectedRow = dtgFestas.SelectedRows[0]; // Obtém a linha selecionada
                festaId = Convert.ToInt32(selectedRow.Cells[ColId].Value); // obtém o valor do Id da Festa da linha selecionada
                
                SetControlsDetalhesFestaEF();
                //mostra em dtgItensFestas os itens da festa
                //CarregarDtgItensFestaEF();

                // método anterior a EF
                //festasDetalhes.ReadOnlyOne(IdFesta); // carrega os detalhes da festa da tabela em clsFestasDetalhes
                //SetControlsDetalhesFesta(); // mostra no form os dados dos detalhes carregados
                //CarregarDtgItensFesta(IdFesta); //mostra em dtgItensFestas os itens da festa
            }
            else
            {
                festaId = null; // Define festaId como null se nenhuma linha estiver selecionada
            }
        }
        //
        // DataGridViews
        // constantes com Numeros das colunas
        private const int ItemNome = 0;
        private const int ItemQtde = 1;
        private const int ItemValor = 2;
        private void ConfigurarColunasDtgItensFestas()
        {
            //ConfiguraCabecalhodtgItensFestas();
            DataGridView dtgItem = dtgItensFestas;
            // Limpar colunas existentes
            dtgItem.Columns.Clear();
            // configurar colunas
            myFunctions.ConfigurarAdicionarColuna(dtgItem, ItemNome, "Descrição", 220);
            myFunctions.ConfigurarAdicionarColuna(dtgItem, ItemQtde, "Qtde", 50, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtgItem, ItemValor, "Valor", 80, DataGridViewContentAlignment.MiddleRight);

            // Configurar DataPropertyName para mapear colunas do DataTable
            dtgItem.Columns[ItemNome].DataPropertyName = "itensfest_nome"; // corresponde ao nome do campo na tabela
            dtgItem.Columns[ItemQtde].DataPropertyName = "add_qtde"; // corresponde ao nome do campo na tabela
            dtgItem.Columns[ItemValor].DataPropertyName = "add_valor"; // corresponde ao nome do campo na tabela

            // Formatar coluna Valor como moeda
            dtgItem.Columns[ItemNome].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dtgItem.Columns[ItemValor].DefaultCellStyle.Format = "C2";
        }
        //
        // método utiliza entity framework para popular controles dos detalhes da festa no form
        private void SetControlsDetalhesFestaEF()
        {
            if (festaId.HasValue)
            {
                // cria nova entidade context
                using (var context = new clsFestasContext())
                {
                    // atribui a var os detalhes da festa selecionada
                    var detalhesFesta = context.Detalhes
                        .FirstOrDefault(d => d.detfest_fest_id == festaId.Value);

                    // se encontrar registros na tabela para a festa
                    if (detalhesFesta != null)
                    {
                        // nome do cliente direto do dtgFestas.
                        lblNomeCliente.Text = dtgFestas.SelectedRows[0].Cells[ColClienteNome].Value?.ToString() ?? string.Empty;
                        lblNomeCliente.ForeColor = Color.DarkGoldenrod;

                        lblHoraInicio.Text = detalhesFesta.detfest_iniciohora?.ToString(@"hh\:mm") ?? "Não especificado";
                        lblHoraFim.Text = detalhesFesta.detfest_fimhora?.ToString(@"hh\:mm") ?? "Não especificado";
                        lblCriancasPagantes.Text = detalhesFesta.detfest_criancaspagantes?.ToString() ?? "0";
                        lblCriancasNaoPagantes.Text = detalhesFesta.detfest_criancasnaopagantes?.ToString() ?? "0";
                        lblAdultos.Text = detalhesFesta.detfest_adultos?.ToString() ?? "0";
                        lblTotalPessoa.Text = detalhesFesta.detfest_totalpessoas?.ToString() ?? "0";
                        lblContratoModelo.Text = detalhesFesta.detfest_contratomodelo?.ToString() ?? "Não especificado";
                        lblObservacaoFestas.Text = detalhesFesta.detfest_observacao ?? "Sem observações";
                        // Pessoas a mais
                        //lblPessoasAMais.Text = detalhesFesta.detfest_pessoasamais?.ToString() ?? "0";

                        //mostra em dtgItensFestas os itens da festa
                        CarregarDtgItensFestaEF();
                    }
                    else
                    {
                        // Limpa os campos caso não haja detalhes
                        LimparCamposDetalhesEF();
                    }
                }
            }
            else
            {
                // Limpa os campos caso nenhuma linha esteja selecionada
                LimparCamposDetalhesEF();
            }
        }
        //
        // método utiliza entity framework para popular dtgItensFestas
        private void CarregarDtgItensFestaEF()
        {
            if (festaId.HasValue)
            {
                // cria nova entidade context
                using (var context = new clsFestasContext())
                {
                    // Obtém os adicionais da festa selecionada, incluindo os itens relacionados
                    var adicionaisFesta = context.Adicionais // tblFestasAdicionais
                        .Include(a => a.ItensFestas)    // tblFestasItens        
                        .Where(a => a.add_fest_id == festaId.Value) // filtra adicionais do id da festa
                        .ToList();

                    //var dataSource = adicionaisFesta.Select(a => new
                    //{
                    //    ItemNome = a.ItensFestas.itensfest_nome ?? "N/A",
                    //    ItemQtde = a.add_qtde,
                    //    ItemValor = a.add_valor
                    //}).ToList();
                    //dtgItensFestas.DataSource = dataSource;

                    // Limpa os dados existentes no DataGridView
                    dtgItensFestas.Rows.Clear();
                    foreach (var adicional in adicionaisFesta)
                    {
                        // Adiciona uma nova linha ao DataGridView
                        int rowIndex = dtgItensFestas.Rows.Add();
                        // Popula as células da linha com os dados dos itens adicionais
                        dtgItensFestas.Rows[rowIndex].Cells[ItemNome].Value = adicional.ItensFestas != null ? adicional.ItensFestas.itensfest_nome ?? "N/A" : "N/A";
                        dtgItensFestas.Rows[rowIndex].Cells[ItemQtde].Value = adicional.add_qtde;
                        dtgItensFestas.Rows[rowIndex].Cells[ItemValor].Value = adicional.add_valor;
                    }
                }
            }
        }       
        //
        private void LimparCamposDetalhesEF()
        {
            lblNomeCliente.Text = string.Empty; //"Não especificado";
            lblHoraInicio.Text = "Não especificado";
            lblHoraFim.Text = "Não especificado";
            lblCriancasPagantes.Text = "0";
            lblCriancasNaoPagantes.Text = "0";
            lblAdultos.Text = "0";
            lblTotalPessoa.Text = "0";
            lblContratoModelo.Text = "Não especificado";
            lblObservacaoFestas.Text = "Sem observações";
            //lblPessoasAMais.Text = "0";
        }
        //
        // botão EXCLUIR...
        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EXCLUIR;
            AbrirFormCRUDEF(operacao);
        }
        //
        // botão CONSULTAR...
        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.CONSULTAR;
            AbrirFormCRUDEF(operacao);
        }
        //
        // botão EDITAR...
        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EDITAR;
            AbrirFormCRUDEF(operacao); 
        }
        //
        // botão NOVO...
        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            AbrirFormCRUDEF(operacao);

            //// Se estiver criando uma nova festa, passe um ID inválido, como -1
            //int novoFestaId = -1;
            //FormFestasCRUD frm = new FormFestasCRUD(novoFestaId, operacao); // erro CS1503
            //// Usar a CreateModalOverlay para exibir o FormClientesCRUD
            //FormMenuMain.ShowModalOverlay(frm);
            //// quando volta do CRUD, atualiza dataGrid com dados da tabela no BD
            //CarregarDtgFestasEF();
        }
        //
        // 
        private void AbrirFormCRUDEF(OperacaoCRUD operacao)
        {
            // Verifique se há uma festaId selecionada no DataGridView
            if (festaId.HasValue)
            {
                try
                {
                    // Converta festaId para int
                    int festaIdInt = operacao == OperacaoCRUD.NOVO ? -1 :festaId.Value;
                    
                    // Determina o valor de festaIdInt com base na operação
                    //int festaIdInt = operacao == OperacaoCRUD.NOVO ? -1 : festaId.HasValue ? festaId.Value : throw new InvalidOperationException("Nenhuma festa selecionada.");

                    // Abra o formulário CRUD para edição passando o ID da festa e a operação
                    using (FormFestasCRUD frm = new FormFestasCRUD(festaIdInt, operacao))
                    {
                        // Usar a Modal para exibir o FormCRUD
                        FormMenuMain.ShowModalOverlay(frm);
                        // quando volta do CRUD, atualiza dataGrid com dados da tabela no BD
                        CarregarDtgFestasEF();
                    }
                }
                catch (InvalidCastException)
                {
                    FormMenuMain.ShowMyMessageBox("Não foi possível converter o valor na coluna ID para um número inteiro.\nAbrirFormCRUDEF", "Erro de Conversão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    FormMenuMain.ShowMyMessageBox($"Erro ao carregar dados da festa: {ex.Message}\nAbrirFormCRUDEF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                FormMenuMain.ShowMyMessageBox("Nenhuma linha está selecionada.\nAbrirFormCRUDEF", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //-------------------------------
        // métodos anteriores sem EF
        // DataGridItensFestas
        private DataTable dtItensFesta = new DataTable();
        private void CarregarDtgItensFesta(int festId)
        {
            try
            {
                // Limpa o DataGridView
                dtgItensFestas.DataSource = null;
                // Carrega os dados da tabela de adicionais da festa em clsFestasAdicionais
                dtItensFesta = clsFestasAdicionais.ReadAddItens(festId);
                // Verifica se há itens adicionais carregadas
                if (dtItensFesta != null && dtItensFesta.Rows.Count > 0)
                {
                    // Atribuir o DataTable ao DataGridView
                    dtgItensFestas.DataSource = dtItensFesta;
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                FormMenuMain.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                FormMenuMain.ShowMyMessageBox($"Erro: {ex.Message}", "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetControlsDetalhesFesta()
        {
            // popula os controles do form com dados da entidade festasDetalhes.
            lblNomeCliente.Text = dtgFestas.SelectedRows[0].Cells[ColClienteNome].Value?.ToString() ?? "N/A";
            lblNomeCliente.ForeColor = Color.DarkGoldenrod;
            lblHoraInicio.Text = festasDetalhes.detfest_iniciohora?.ToString() ?? "N/A";
            lblHoraFim.Text = festasDetalhes.detfest_fimhora?.ToString() ?? "N/A";
            lblCriancasPagantes.Text = festasDetalhes.detfest_criancaspagantes?.ToString() ?? "N/A";
            lblCriancasNaoPagantes.Text = festasDetalhes.detfest_criancasnaopagantes?.ToString() ?? "N/A";
            lblAdultos.Text = festasDetalhes.detfest_adultos?.ToString() ?? "N/A";
            lblTotalPessoa.Text = festasDetalhes.detfest_totalpessoas?.ToString() ?? "N/A";
            lblContratoModelo.Text = festasDetalhes.detfest_contratomodelo?.ToString() ?? "N/A";
            lblObservacaoFestas.Text = festasDetalhes.detfest_observacao ?? "N/A";
            // pessoas a mais????
        }
        private void CarregarDtgFestas()
        {
            try
            {
                // Verifica se a conexão está ativa antes de tentar carregar os dados
                if (FormMenuMain.ConexaoAtiva)
                {
                    // Carrega os dados da tabela de festas
                    dtFestas = clsFestas.ReadAllFestas();
                }
                else
                {
                    FormMenuMain.ShowMyMessageBox("A conexão com o banco de dados está inativa.\nCarregarDtgFestas", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TratarControles(true); // Desabilita botões de CRUD se a conexão estiver inativa
                    return; // Sai do método se a conexão não estiver ativa
                }
                // Verifica se há festas carregadas
                if (dtFestas != null && dtFestas.Rows.Count > 0)
                {
                    dtgFestas.DataSource = dtFestas;
                    CalcularDataGrid(); // soma coluna valor e pega as datas do periodo
                    TratarControles(false); // Habilita botões de CRUD
                }
                else
                {
                    FormMenuMain.ShowMyMessageBox("Nenhuma Festa encontrado.", "Carregar Festas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TratarControles(true); // Desabilita botões de CRUD
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                FormMenuMain.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}\nCarregarDtgFestas", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tstbtnNovo != null) tstbtnNovo.Enabled = false;
                TratarControles(true); // Desabilita botões de CRUD em caso de erro
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                FormMenuMain.ShowMyMessageBox($"Erro: {ex.Message}\nCarregarDtgFestas", "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tstbtnNovo != null) tstbtnNovo.Enabled = false;
                TratarControles(true); // Desabilita botões de CRUD em caso de erro
            }
        }
        private void CarregarDtgItensFestaEFSEMUSO(int festaId)
        {
            using (var context = new clsFestasContext())
            {

                // Obtém os adicionais da festa selecionada
                var adicionaisFesta = context.Adicionais
                    .Where(a => a.add_fest_id == festaId)
                    .Include(a => a.ItensFestas)
                    .ToList();

                // Cria uma tabela temporária para armazenar os dados dos itens adicionais
                DataTable dt = new DataTable();
                dt.Columns.Add("Nome do Item", typeof(string));
                dt.Columns.Add("Quantidade", typeof(int));
                dt.Columns.Add("Valor", typeof(double));

                foreach (var adicional in adicionaisFesta)
                {
                    DataRow row = dt.NewRow();
                    row["Nome do Item"] = adicional.ItensFestas?.itensfest_nome ?? "N/A";
                    row["Quantidade"] = adicional.add_qtde;
                    row["Valor"] = adicional.add_valor;
                    dt.Rows.Add(row);
                }
                dtgItensFestas.DataSource = dt;
            }
        }
        private void AbrirFormCRUD(OperacaoCRUD operacao)
        {
            // Declarar o datagrid
            var dtg = dtgFestas;
            //Form formOpen = FormFestasCRUD;

            // Verifique se há uma linha selecionada no DataGridView
            if (dtg.CurrentRow != null)
            {
                // Pegue o índice da linha atual
                int rowIndex = dtg.CurrentRow.Index;

                // Verifique se a célula da coluna desejada, ID, não é nula
                if (dtg.Rows[rowIndex].Cells[ColId].Value != null)
                {
                    try
                    {
                        // Inicializar o objeto clsFestas com os dados da linha selecionada
                        clsFestas festa = new clsFestas
                        {
                            // Tente converter o valor da célula para inteiro
                            fest_id = Convert.ToInt32(dtg.Rows[rowIndex].Cells[ColId].Value),
                            //
                            //fest_cli_id = Convert.ToInt32(dtg.Rows[rowIndex].Cells[ColClienteNome].Value),
                            //fest_user_id = Convert.ToInt32(dtg.Rows[rowIndex].Cells[ColUserNome].Value),
                            //fest_pct_id = Convert.ToInt32(dtg.Rows[rowIndex].Cells[ColPacote].Value),
                            //fest_tema_id = Convert.ToInt32(dtg.Rows[rowIndex].Cells[ColTema].Value),
                            //fest_espc_id = Convert.ToInt32(dtg.Rows[rowIndex].Cells[ColEspaco].Value),
                            //fest_stt_id = Convert.ToInt32(dtg.Rows[rowIndex].Cells[ColStatus].Value),
                            //fest_tpEv_id = Convert.ToInt32(dtg.Rows[rowIndex].Cells[ColTipo].Value),
                            //fest_dtVenda = Convert.ToDateTime(dtg.Rows[rowIndex].Cells[ColDataVenda].Value),
                            //fest_dtFesta = Convert.ToDateTime(dtg.Rows[rowIndex].Cells[ColDataFesta].Value),
                            //fest_valor = Convert.ToDouble(dtg.Rows[rowIndex].Cells[ColValor].Value)
                        };

                        // Abra o formulárioCRUD para edição passando a calsse e operação
                        using (FormFestasCRUD frm = new FormFestasCRUD(festa.fest_id, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            FormMenuMain.ShowModalOverlay(frm);
                            // quando volta do CRUD, atualiza dataGrid com dados da tabela no BD
                            CarregarDtgFestas();
                        }
                    }
                    catch (FormatException)
                    {
                        FormMenuMain.ShowMyMessageBox("O valor na coluna ID não é um número válido.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidCastException)
                    {
                        FormMenuMain.ShowMyMessageBox("Não foi possível converter o valor na coluna ID para um número inteiro.", "Erro de Conversão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        FormMenuMain.ShowMyMessageBox($"Erro ao carregar dados da festa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FormMenuMain.ShowMyMessageBox("A célula da coluna ID está vazia.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                FormMenuMain.ShowMyMessageBox("Nenhuma linha está selecionada.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } // end AbrirFormCRUD
        private void AbrirFormCRUD_GENERICO(OperacaoCRUD operacao)
        {
            var festaId = Convert.ToInt32(dtgFestas.SelectedRows[0].Cells[ColId].Value);
            //LoadFesta(festId);

            AbrirFormCRUDGenerico(
                dtg: dtgFestas,
                colIdIndex: ColId,
                mapper: row => new clsFestas //Func<DataGridViewRow, T> mapper,
                {
                    //Id = Convert.ToInt32(row.Cells[ColId].Value),
                    //Cliente = row.Cells[ColClienteNome].Value?.ToString() ?? string.Empty,
                    //Usuario = row.Cells[ColUserNome].Value?.ToString() ?? string.Empty,
                    //Pacote = row.Cells[ColPacote].Value?.ToString() ?? string.Empty,
                    //Tema = row.Cells[ColTema].Value?.ToString() ?? string.Empty,
                    //Espaco = row.Cells[ColEspaco].Value?.ToString() ?? string.Empty,
                    //Status = row.Cells[ColStatus].Value?.ToString() ?? string.Empty,
                    //TipoEvento = row.Cells[ColTipo].Value?.ToString() ?? string.Empty,

                    fest_dtVenda = row.Cells[ColDataVenda].Value != null ? Convert.ToDateTime(row.Cells[ColDataVenda].Value) : DateTime.MinValue,
                    fest_dtFesta = row.Cells[ColDataFesta].Value != null ? Convert.ToDateTime(row.Cells[ColDataFesta].Value) : DateTime.MinValue,
                    fest_valor = row.Cells[ColValor].Value != null ? Convert.ToDouble(row.Cells[ColValor].Value) : 0.0
                },
                reloadGrid: CarregarDtgFestas,
                formFactory: (festa, op) => new FormFestasCRUD(festaId, op),
                operacao: operacao
            );
        }


    } // end class FormFestas
} // end namespace
