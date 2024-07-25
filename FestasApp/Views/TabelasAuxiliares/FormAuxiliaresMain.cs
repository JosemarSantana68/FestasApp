//--------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação deste Módulo: 09/07/2024
//   Ultima Alteração: 09/07/2024
//   
//   FORMULÁRIO PRINCIPAL PARA AS TABELAS AUXILIARES
//--------------------------------------------------------------


namespace FestasApp.Views.TabelasAuxiliares
{
    public partial class FormAuxiliaresMain : FormBaseCadastro
    {
        // Instância de TabelaAuxiliarManager para gerenciar as tabelas auxiliares
        private readonly TabelaAuxiliarManager _tabelaAuxiliarManager = new();
        private readonly ControlConfigurator _controlConfigurator;
        private readonly DataGridManager _dataGridManager;
        public readonly DataLoader _dataLoader; // public

        // objetos para o painel de visualização de contratos modelos
        public Panel? pnlVisualizacao;
        public WebBrowser? pdfViewer;
        // entidade do Entity Framework
        private clsFestasContext _context = new clsFestasContext();

        // 1.0. construtor
        public FormAuxiliaresMain()
        {
            InitializeComponent();
            _controlConfigurator = new ControlConfigurator(this);
            _dataGridManager = new DataGridManager(this);
            _dataLoader = new DataLoader(this, _context);

            SuspendLayout();
                SetThisForm();
                SetControls();
                AddEventHandlers();
            ResumeLayout();
        }
        // 1.1.
        private void SetThisForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            // Adicione aqui as configurações específicas para o formulário
            lblTitulo.Text = "C a d a s t r o s  d a s  T a b e l a s  A u x i l i a r e s";
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }
        // 1.2. configurações iniciais de controles
        private void SetControls()
        {
            _controlConfigurator.ConfigureControls();
            _dataGridManager.ConfigureDataGrids();

            //dtgRegistrosTabelasAuxiliares.Dock = DockStyle.Fill;
            //this.pnlCabecalho.Height = 50;

            //SetPanelVisualizacao();
            //ConfigurarDtgTabelasAuxiliares();
            //ConfigurarDtgRegistrosTabelasAuxiliares();
        }
        // 1.3. adiciona eventos Handlers
        private void AddEventHandlers()
        {
            // Adiciona o manipulador de eventos para os botões do ToolStrip
            this.tstbtnNovo.Click += TstbtnNovo_Click;
            this.tstbtnEditar.Click += TstbtnEditar_Click;
            this.tstbtnConsultar.Click += TstbtnConsultar_Click;
            this.tstbtnExcluir.Click += TstbtnExcluir_Click;
            this.Load += FormAuxiliaresMain_Load;

            _dataGridManager.AddEventHandlers();

            // adiciona EventHandlers para selecionar tabela
            //dtgTabelasAuxiliares.SelectionChanged += DtgTabelasAuxiliares_SelectionChanged;
            //dtgTabelasAuxiliares.KeyDown += new KeyEventHandler(dtgTabelasAuxiliares_KeyDown);
            //dtgRegistrosTabelasAuxiliares.SelectionChanged += DtgRegistrosTabelasAuxiliares_SelectionChanged;
        }
        // 2.0. Load
        private void FormAuxiliaresMain_Load(object? sender, EventArgs e)
        {
            _dataLoader.PopularDtgTabelasAuxiliares();
        }
        //
        // métodos ToolStripEventHandler para os itens selecionados em dtgRegistrosTabelasAuxiliares
        //
        // excluir registro
        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EXCLUIR;
            AbrirFormCRUD(operacao);
        }
        // consultar registro
        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.CONSULTAR;
            AbrirFormCRUD(operacao);
        }
        // editar registro
        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EDITAR;
            AbrirFormCRUD(operacao);
        }
        // novo registro
        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            AbrirFormCRUD(operacao);
        }
        //
        private void AbrirFormCRUD(OperacaoCRUD operacao)
        {
            if (dtgTabelasAuxiliares.SelectedRows.Count > 0)
            {
                // itens
                if (_tabelaAuxiliarManager.IsTabelaItensFestasSelecionada(dtgTabelasAuxiliares))
                {
                    if (_dataLoader.idRegistro.IsValid())
                    {
                        // Abra o formulário CRUD para edição 
                        using (FormItensFestasCRUD frm = new(_dataLoader.idRegistro, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            FormMenuMain.ShowModalOverlay(frm);
                        }
                    }
                } 
                // espaços
                else if (_tabelaAuxiliarManager.IsTabelaEspacosSelecionada(dtgTabelasAuxiliares))
                {
                    if (_dataLoader.idRegistro.IsValid())
                    {
                        // Abra o formulário CRUD para edição 
                        using (FormEspacosFestas frm = new(_dataLoader.idRegistro, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            FormMenuMain.ShowModalOverlay(frm);
                        }
                    }
                } 
                // contratos
                else if (_tabelaAuxiliarManager.IsTabelaContratosSelecionada(dtgTabelasAuxiliares))
                {
                   
                } 
                // pacotes
                else if (_tabelaAuxiliarManager.IsTabelaPacotesSelecionada(dtgTabelasAuxiliares))
                {
                    if (_dataLoader.idRegistro.IsValid())
                    {
                        // Abra o formulário CRUD para edição 
                        using (FormPacotesCRUD frm = new(_dataLoader.idRegistro, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            FormMenuMain.ShowModalOverlay(frm);
                        }
                    }
                } 
                // status
                else if (_tabelaAuxiliarManager.IsTabelaStatusSelecionada(dtgTabelasAuxiliares))
                {
                    if (_dataLoader.idRegistro.IsValid())
                    {
                        // Abra o formulário CRUD para edição 
                        using (FormStatusCRUD frm = new(_dataLoader.idRegistro, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            FormMenuMain.ShowModalOverlay(frm);
                        }
                    }
                } 
                // temas
                else if (_tabelaAuxiliarManager.IsTabelaTemasSelecionada(dtgTabelasAuxiliares))
                {
                    if (_dataLoader.idRegistro.IsValid())
                    {
                        // Abra o formulário CRUD para edição 
                        using (FormTemasFestas frm = new(_dataLoader.idRegistro, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            FormMenuMain.ShowModalOverlay(frm);
                        }
                    }
                } 
                // tipos eventos
                else if (_tabelaAuxiliarManager.IsTabelaTipoEventosSelecionada(dtgTabelasAuxiliares))
                {
                    if (_dataLoader.idRegistro.IsValid())
                    {
                        // Abra o formulário CRUD para edição 
                        using (FormTipoEvento frm = new(_dataLoader.idRegistro, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            FormMenuMain.ShowModalOverlay(frm);
                        }
                    }
                }
                _dataLoader.CarregarRegistrosDaTabela();
            }
        }

    } // end class FormAuxiliaresMain : FormBaseCadastro
} // end namespace FestasApp.Views.TableAuxiliares
