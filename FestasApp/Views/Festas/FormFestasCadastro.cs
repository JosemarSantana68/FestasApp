//--------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 06/07/2024
//   
//   FORMULÁRIO DE FESTAS
//--------------------------------------------------------------

namespace FestasApp.Views
{
    public partial class FormFestasCadastro : FormBaseCadastro
    {
        // DataGridFestas
        private DataTable dtFestas = new DataTable();
        // dependências: instancia objetos das classes...
        private clsFestas festa = new clsFestas();
        private clsFestasContext _context = new clsFestasContext();
        private clsFestasDetalhes festasDetalhes = new clsFestasDetalhes();
        // variavels para gravar o id da festa selecionada
        //private int? festaId;
        private clsParam festaId = new();
        //
        // criação - construtor - no ...new Form();
        public FormFestasCadastro()
        {
            /* Aqui é o lugar ideal para configurar:
            1.Inicialização de componentes: Configuração básica dos controles que estarão no formulário (definição de propriedades visuais e comportamentais).
            2.Event Handlers: Associação de eventos aos seus respectivos manipuladores, como clique de botão, alteração de texto, etc.
            3.Definição de propriedades estáticas: Propriedades que não vão depender de nenhuma lógica dinâmica ou de dados que precisam ser carregados de fontes externas.
             */

            SuspendLayout();
            InitializeComponent();
            SetThisForm();
            SetControls();
            AddToolStripEventHandlers();
            ResumeLayout(false);
        }
         // carregamento - no .Show();
        private void FormFestasCadastro_Load(object sender, EventArgs e)
        {
            /* Aqui é o lugar ideal para configurar:
            1.Carregamento de dados: Busca e carregamento de dados de fontes externas, como bancos de dados ou arquivos.
            2.Inicialização de lógica de negócio: Qualquer lógica de inicialização que dependa de dados ou estado do sistema.
            3.Configuração dinâmica: Configuração de controles com base em dados carregados dinamicamente ou estado da aplicação.
             */
            SuspendLayout();
            //SetControls();
            CarregarDtgFestasEF();
            ResumeLayout(false);

        }
        //
        // Configurações iniciais do formulário de cliente
        private void SetThisForm()
        {
            // Adicione aqui as configurações específicas para o formulário
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
            // testa a conexão
            if (!myConnMySql.TestarConexao())
            {
                if (tstbtnNovo != null) tstbtnNovo.Enabled = false;
                TratarControles(true); // Desabilita botões de CRUD em caso de erro
                return;
            }

            DataGridView dtg = dtgFestas;
            dtg.Rows.Clear();

            try
            {
                // carregar dados do clsFestaContext : DbSet,  .OrderBy(f => f.fest_dtFesta) // ordena por data de festas
                var listaFestas = repFestasEF.GetFestasEF();

                if (listaFestas != null)
                {
                    foreach (var festa in listaFestas)
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
                    CalcularDataGridEF();
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
        //
        private void CalcularDataGridEF()
        {
            using (var context = new clsFestasContext())
            {
                // Total de registros
                int totalRegistros = context.Festas.Count();

                // Menor data de festa
                DateTime? menorData = context.Festas.Min(f => (DateTime?)f.fest_dtFesta);

                // Maior data de festa
                DateTime? maiorData = context.Festas.Max(f => (DateTime?)f.fest_dtFesta);

                // Soma do valor das festas
                decimal somaColuna = context.Festas.Sum(f => (decimal?)(f.fest_valor) ?? 0);

                // Exibir os resultados em labels
                lblTotalFestas.Text = totalRegistros.ToString();

                lblPeriodoFestas.Text = menorData.HasValue && maiorData.HasValue
                    ? $"{menorData.Value.ToString("dd/MM/yyyy")} à {maiorData.Value.ToString("dd/MM/yyyy")}" : "N/A";

                lblValorTotalFestas.Text = somaColuna.ToString("C", new CultureInfo("pt-BR"));
            }
        }
        //
        // DataGridFestas
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
            myFunctions.ConfigurarAdicionarColuna(dtg, ColId, "ID", 30, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColDataFesta, "Data da Festa", 120, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColClienteNome, "Nome do Cliente", 200, "", padding: new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarAdicionarColuna(dtg, ColPacote, "Pacote", 120, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, ColTema, "Tema", 120, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, ColEspaco, "Espaco", 120, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, ColStatus, "Status", 120, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, ColTipo, "Tipo Evento", 120, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, ColValor, "Valor Total", 120, "", alignment: DataGridViewContentAlignment.MiddleRight);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColUserNome, "Vendedor", 120, "", padding: new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarAdicionarColuna(dtg, ColDataVenda, "Data da Venda", 120, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            
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
        // adiciona eventos aos stripsButtons...
        private void AddToolStripEventHandlers()
        {
            // Adiciona o manipulador de eventos para os botões do ToolStrip
            this.tstbtnNovo.Click += TstbtnNovo_Click;
            this.tstbtnEditar.Click += TstbtnEditar_Click;
            this.tstbtnConsultar.Click += TstbtnConsultar_Click;
            this.tstbtnExcluir.Click += TstbtnExcluir_Click;
            this.Load += FormFestasCadastro_Load!;

            // para o datagrid
            this.dtgFestas.SelectionChanged += DtgFestas_SelectionChanged;
        }
        //
        
        private void DtgFestas_SelectionChanged(object? sender, EventArgs e)
        {
            if (dtgFestas.SelectedRows.Count > 0)
            {
                var selectedRow = dtgFestas.SelectedRows[0]; // Obtém a linha selecionada
                festaId.Id = Convert.ToInt32(selectedRow.Cells[ColId].Value); // obtém o valor do Id da Festa da linha selecionada
                
                LimparCamposDetalhesEF();
                SetControlsDetalhesFestaEF();
            }
            else
            {
                festaId.Id = 0; // Define festaId como 0 se nenhuma linha estiver selecionada
            }
        }
        //
        // DataGridItens
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
            myFunctions.ConfigurarAdicionarColuna(dtgItem, ItemNome, "Descrição", 220, "");
            myFunctions.ConfigurarAdicionarColuna(dtgItem, ItemQtde, "Qtde", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtgItem, ItemValor, "Valor", 80, "", alignment: DataGridViewContentAlignment.MiddleRight);

            // Configurar DataPropertyName para mapear colunas do DataTable
            dtgItem.Columns[ItemNome].DataPropertyName = "itensfest_nome"; // corresponde ao nome do campo na tabela
            dtgItem.Columns[ItemQtde].DataPropertyName = "add_qtde"; // corresponde ao nome do campo na tabela
            dtgItem.Columns[ItemValor].DataPropertyName = "add_valor"; // corresponde ao nome do campo na tabela

            // Formatar coluna Valor como moeda
            dtgItem.Columns[ItemNome].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dtgItem.Columns[ItemValor].DefaultCellStyle.Format = "C2";
            //
            // Configuração da altura geral das linhas
            dtgItem.RowTemplate.Height = 25;
        }
        //
        // método utiliza entity framework para popular controles dos detalhes da festa no form
        private async void SetControlsDetalhesFestaEF()
        {
            if (festaId.IsValid())
            {
                // cria nova entidade context
                using (var context = new clsFestasContext())
                {
                    // Carrega a festa com os detalhes e as entidades relacionadas
                    var festa = context.Festas
                        .Include(f => f.TipoEvento)
                        .Include(f => f.Status)
                        .Include(f => f.Detalhes)
                        .FirstOrDefault(f => f.fest_id == festaId.Id);

                    // se encontrar registros na tabela para a festa
                    if (festa != null)
                    {
                        // nome do cliente direto do dtgFestas.
                        lblNomeCliente.Text = dtgFestas.SelectedRows[0].Cells[ColClienteNome].Value?.ToString() ?? string.Empty;
                        lblNomeCliente.ForeColor = Color.DarkGoldenrod;

                        // Atribui os valores às labels
                        lblTipoEvento.Text = festa.TipoEvento?.tpev_nome ?? string.Empty;
                        lblStatusFesta.Text = festa.Status?.stt_status ?? string.Empty;

                        // Verifica se existem detalhes da festa
                        var detalhesFesta = festa.Detalhes?.FirstOrDefault();
                        if (detalhesFesta != null)
                        {
                            lblHoraInicio.Text = myDateTime.FormatTimeForDisplay(detalhesFesta.detfest_iniciohora);
                            lblHoraFim.Text = myDateTime.FormatTimeForDisplay(detalhesFesta.detfest_fimhora);
                            lblCriancasPagantes.Text = detalhesFesta.detfest_criancaspagantes?.ToString() ?? string.Empty;
                            lblCriancasNaoPagantes.Text = detalhesFesta.detfest_criancasnaopagantes?.ToString() ?? string.Empty;
                            lblAdultos.Text = detalhesFesta.detfest_adultos?.ToString() ?? string.Empty;
                            lblTotalPessoa.Text = detalhesFesta.detfest_totalpessoas?.ToString() ?? string.Empty;
                            lblObservacaoFestas.Text = detalhesFesta.detfest_observacao ?? string.Empty;
                            lblPessoasAMais.Text = detalhesFesta.detfest_pessoasamais?.ToString() ?? string.Empty;

                            // contrato
                            var contrato = await context.Contratos.FirstOrDefaultAsync(c => c.ctt_id == detalhesFesta.detfest_ctt_id);
                            if (contrato != null)
                            {
                                lblContratoModelo.Text = contrato.ctt_nome; // ERRO TRATAR
                            }

                        }
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
            // informações do dtgItensFesta
            int alturaLinha = 25;
            int alturaMaxima = 140;

            if (festaId.IsValid())
            {
                // cria nova entidade context
                using (var context = new clsFestasContext())
                {
                    // Obtém os adicionais da festa selecionada, incluindo os itens relacionados
                    var adicionaisFesta = repAdicionaisEF.GetItensFestaEF(festaId.Id!.Value);
                   
                    // Limpa os dados existentes no DataGridView
                    dtgItensFestas.Rows.Clear();

                    if (adicionaisFesta != null)
                    {
                        foreach (var adicional in adicionaisFesta)
                        {
                            // Adiciona uma nova linha ao DataGridView
                            int rowIndex = dtgItensFestas.Rows.Add();
                            // Popula as células da linha com os dados dos itens adicionais

                            dtgItensFestas.Rows[rowIndex].Cells[ItemNome].Value = adicional.ItensFestas != null ? adicional.ItensFestas.itensfest_nome ?? "N/A" : "N/A";
                            dtgItensFestas.Rows[rowIndex].Cells[ItemQtde].Value = adicional.add_qtde;

                            dtgItensFestas.Rows[rowIndex].Cells[ItemValor].Value = adicional.add_valor;
                        }
                        // Desmarcar seleção
                        dtgItensFestas.ClearSelection();

                        // Calcula a altura necessária
                        int alturaNecessaria = (adicionaisFesta.Count * alturaLinha) + 25; // acrescentar 25 do cabeçalho
                        // Define a altura do DataGridView
                        if (alturaNecessaria <= alturaMaxima)
                        {
                            //dtgItensFestas.Height = alturaNecessaria < alturaLinha ? alturaLinha : alturaNecessaria;
                            dtgItensFestas.Height = alturaNecessaria;
                        }
                        else
                        {
                            dtgItensFestas.Height = alturaMaxima;
                            dtgItensFestas.ScrollBars = ScrollBars.Vertical;
                        }
                    }
                }
            }
        }
        //
        private void LimparCamposDetalhesEF()
        {
            lblNomeCliente.Text = string.Empty;
            lblTipoEvento.Text = string.Empty;
            lblHoraInicio.Text = string.Empty;
            lblHoraFim.Text = string.Empty;
            lblCriancasPagantes.Text = string.Empty;
            lblCriancasNaoPagantes.Text = string.Empty;
            lblAdultos.Text = string.Empty;
            lblTotalPessoa.Text = string.Empty;
            lblContratoModelo.Text = string.Empty;
            lblObservacaoFestas.Text = string.Empty;
            lblPessoasAMais.Text = string.Empty;
            // Limpa os dados existentes no DataGridView
            dtgItensFestas.Rows.Clear();
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
        }
        //
        // 
        private void AbrirFormCRUDEF(OperacaoCRUD operacao)
        {
            // Verifique se há uma festaId selecionada no DataGridView
            if (festaId.IsValid() || operacao == OperacaoCRUD.NOVO)
            {
                try
                {
                    // Abra o formulário CRUD para edição passando o ID da festa e a operação
                    using (FormFestasCRUD frm = new FormFestasCRUD(festaId.Id, operacao))
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
        //
        //*************************************************************************
        // métodos SEM USO anteriores sem EF (no Backup)

    } // end class FormFestas
} // end namespace
