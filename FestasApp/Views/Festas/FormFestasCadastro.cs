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
        // instancia um objeto da classe...
        private clsFestasDetalhes FestasDetalhes;

        // construtor
        public FormFestasCadastro()
        {
            InitializeComponent();
            // declara objeto
            FestasDetalhes = new clsFestasDetalhes();

            this.SuspendLayout();
              ConfigurarFormFestas();
              SetControls();
              AddToolStripEventHandlers();
            this.ResumeLayout(false);
        }
        //
        private void FormFestas_Load(object sender, EventArgs e)
        {
            // Outras configurações de carregamento podem ser adicionadas aqui, se necessário
        }
        //
        // Configurações iniciais do formulário de cliente
        private void ConfigurarFormFestas()
        {
            // Adicione aqui as configurações específicas para o formulário de cliente
            this.FormBorderStyle = FormBorderStyle.None;
            lblTitulo.Text = "C a d a s t r o  d e  F e s t a s";
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            CarregarDtgFestas();
        }
        private void SetControls()
        {
            //
            // txtObservacoes
            //
            //txtObservacoes.Multiline = true;
            //txtObservacoes.ScrollBars = ScrollBars.Vertical;
            //txtObservacoes.WordWrap = true;
            //txtObservacoes.Width = 300;
            //txtObservacoes.Height = 100;
            //
            //lblTotalFestas.TextAlign = ContentAlignment.MiddleCenter;
            //lblTotalFestas.AutoSize = true;
            //lblDataFim.TextAlign = ContentAlignment.MiddleCenter;
            //lblDataFim.AutoSize = true;
            //lblDataInicio.TextAlign = ContentAlignment.MiddleCenter;
            //lblDataInicio.AutoSize = true;
            //lblValorTotalFestas.TextAlign = ContentAlignment.MiddleRight;
            //lblValorTotalFestas.AutoSize = true;
            //
        }
        //
        // DataGridFestas
        private DataTable dtFestas = new DataTable();
        private void CarregarDtgFestas()
        {
            try
            {
                // carrega datagrid com dados da tabela
                dtFestas = clsFestas.ReadAllFestas();

                if (dtFestas != null && dtFestas.Rows.Count > 0)
                {
                    dtgFestas.DataSource = dtFestas;
                    ConfigurarDtgFestas();
                    CalcularDataGrid();
                    TratarControles(false); // Habilita botões de CRUD
                }
                else
                {
                    FormMenuBase.ShowMyMessageBox("Nenhuma Festa encontrado.", "Carregar Festas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TratarControles(true); // Desabilita botões de CRUD
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                FormMenuBase.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TratarControles(true); // Desabilita botões de CRUD em caso de erro
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                FormMenuBase.ShowMyMessageBox($"Erro: {ex.Message}", "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // constantes com Numeros das colunas
        private const int ColId = 0;
        private const int ColClienteId = 1;
        private const int ColClienteNome = 2;
        private const int ColUserId = 3;
        private const int ColUserNome = 4;
        private const int ColPacoteId = 5;
        private const int ColTemaId = 6;
        private const int ColEspacoId = 7;
        private const int ColStatusId = 8;
        private const int ColTipoEventoId = 9;
        private const int ColDataVenda = 10;
        private const int ColDataFesta = 11;
        private const int ColValor = 12;
        //
        private void ConfigurarDtgFestas()
        {
            DataGridView dtg = dtgFestas;
            // configurar colunas
            myFunctions.ConfigurarColuna(dtg, ColId, "ID", 30, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColClienteId, "ClienteId", 30, DataGridViewContentAlignment.MiddleLeft, new Padding(5, 0, 0, 0), false);
            myFunctions.ConfigurarColuna(dtg, ColClienteNome, "Nome do Cliente", 200, DataGridViewContentAlignment.MiddleLeft, new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarColuna(dtg, ColUserId, "UsuarioId", 30, visible: false);
            myFunctions.ConfigurarColuna(dtg, ColUserNome, "Nome do Usuário", 200, DataGridViewContentAlignment.MiddleLeft, new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarColuna(dtg, ColPacoteId, "PacoteId", 120);
            myFunctions.ConfigurarColuna(dtg, ColTemaId, "TemaId", 120, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColEspacoId, "EspacoId", 120, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColStatusId, "StatusId", 120, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColTipoEventoId, "TipoEventoId", 120, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColDataVenda, "DataVenda", 120, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColDataFesta, "DataFesta", 120, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColValor, "Valor", 120, DataGridViewContentAlignment.MiddleRight);
            // Ordenar datagrid por ClienteId
            dtg.Sort(dtg.Columns[ColClienteNome], ListSortDirection.Ascending);
            // Adiciona o evento CellFormatting para formatação dos dados
            dtg.CellFormatting += Dtg_CellFormatting;
        }
        // formatação dtgFestas
        private void Dtg_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar se a coluna é "Valor" e se o valor não é nulo
            if (e.ColumnIndex == ColValor && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (decimal.TryParse(e.Value.ToString(), out decimal decimalValue))
                {
                    e.Value = decimalValue.ToString("N2");
                    e.FormattingApplied = true;
                }
            }
        }
        //
        // Uso do método
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
        //----------------------------------------------
        // adiciona eventos aos stripsButtons...
        private void AddToolStripEventHandlers()
        {
            // Adiciona o manipulador de eventos para os botões do ToolStrip
            this.tstbtnNovo.Click += TstbtnNovo_Click;
            this.tstbtnEditar.Click += TstbtnEditar_Click;
            this.tstbtnConsultar.Click += TstbtnConsultar_Click;
            this.tstbtnExcluir.Click += TstbtnExcluir_Click;
            // para o datagrid
            this.dtgFestas.SelectionChanged += dtgFestas_SelectionChanged;
        }
        //
        // seleciona linha no dtgFestas
        private void dtgFestas_SelectionChanged(object? sender, EventArgs e)
        {
            if (dtgFestas.SelectedRows.Count > 0)
            {
                var selectedRow = dtgFestas.SelectedRows[0]; // Obtém a linha selecionada
                var IdFesta = Convert.ToInt32(selectedRow.Cells[ColId].Value); // obtém o valor do Id da Festa da linha selecionada
                FestasDetalhes.ReadOnlyOne(IdFesta); // carrega os detalhes da festa da tabela
                SetControlsDetalhesFesta(); // mostra no form os dados 
            }
        }
        //
        private void SetControlsDetalhesFesta()
        {
            lblNomeCliente.Text = dtgFestas.SelectedRows[0].Cells[ColClienteNome].Value?.ToString() ?? "N/A";
            lblNomeCliente.ForeColor = Color.DarkGoldenrod;
            lblHoraInicio.Text = FestasDetalhes.InicioHora?.ToString() ?? "N/A";
            lblHoraFim.Text = FestasDetalhes.FimHora?.ToString() ?? "N/A";
            lblCriancasPagantes.Text = FestasDetalhes.CriancasPagantes?.ToString() ?? "N/A";
            lblCriancasNaoPagantes.Text = FestasDetalhes.CriancasNaoPagantes?.ToString() ?? "N/A";
            lblAdultos.Text = FestasDetalhes.Adultos?.ToString() ?? "N/A";
            lblTotalPessoa.Text = FestasDetalhes.TotalPessoas?.ToString() ?? "N/A";
            lblContratoModelo.Text = FestasDetalhes.ContratoModeloId?.ToString() ?? "N/A";
            lblObservacaoFestas.Text = FestasDetalhes.Observacao ?? "N/A";
        }
        //
        // Evento Click do botão EXCLUIR...
        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }
        //
        // Evento Click do botão CONSULTAR...
        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        //
        // Evento Click do botão EDITAR...
        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            //OperacaoCRUD operacao = OperacaoCRUD.CONSULTAR;
            //AbrirFormCRUD(operacao); 
        }
        //
        // Evento Click do botão NOVO...
        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            // incrementar Lógica do evento do botão
            clsFestas festa = new clsFestas(); // festa para passar
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            FormFestasCRUD frm = new FormFestasCRUD(festa, operacao);

            // Usar a CreateModalOverlay para exibir o FormClientesCRUD
            FormMenuBase.ShowModalOverlay(frm);

            // quando volta do CRUD, atualiza dataGrid com dados da tabela no BD
            //CarregarDtgUsuarios();
        }

    } // end class FormFestas
} // end namespace
