//--------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação deste Módulo: 09/07/2024
//   Ultima Alteração: 09/07/2024
//   
//   FORMULÁRIO PRINCIPAL PARA AS TABELAS AUXILIARES
//
//--------------------------------------------------------------
//
using FestasApp.Views.FestasContratos;

namespace FestasApp.Views.TabelasAuxiliares
{
    public partial class FormAuxiliaresMain : FormBaseCadastro
    {
        /// <summary>
        /// Instância de TabelaAuxiliarManager para gerenciar as tabelas auxiliares
        /// </summary>
        private readonly TabelaAuxiliarManager _tabelaAuxiliarManager = new();
        private readonly ControlConfigurator _controlConfigurator;
        private readonly DataGridManager _dataGridManager;
        public readonly DataLoader _dataLoader; // public

        /// <summary>
        /// objetos para o painel de visualização de contratos modelos
        /// </summary>
        public Panel? pnlVisualizacao;
        public WebBrowser? pdfViewer;

        /// <summary>
        /// entidade do Entity Framework
        /// </summary>
        ///private clsFestasContext _context = new();

        /// <summary>
        /// 1.0. construtor
        /// </summary>
        public FormAuxiliaresMain()
        {
            InitializeComponent();
            _controlConfigurator = new ControlConfigurator(this);
            _dataGridManager = new DataGridManager(this);
            _dataLoader = new DataLoader(this);

            SuspendLayout();
                SetThisForm();
                SetControls();
                AddEventHandlers();
            ResumeLayout();
        }
        /// <summary>
        /// 1.1. configurações deste formulário
        /// </summary>
        private void SetThisForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            // Adicione aqui as configurações específicas para o formulário
            lblTitulo.Text = "C a d a s t r o s  d a s  T a b e l a s  A u x i l i a r e s";
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }
        /// <summary>
        /// 1.2. configurações iniciais de controles
        /// </summary>
        private void SetControls()
        {
            _controlConfigurator.ConfigureControls();
            _dataGridManager.ConfigureDataGrids();
        }
        /// <summary>
        /// 1.3. adiciona eventos Handlers
        /// </summary>
        private void AddEventHandlers()
        {
            // Adiciona o manipulador de eventos para os botões do ToolStrip
            this.tstbtnNovo.Click += TstbtnNovo_Click;
            this.tstbtnEditar.Click += TstbtnEditar_Click;
            this.tstbtnConsultar.Click += TstbtnConsultar_Click;
            this.tstbtnExcluir.Click += TstbtnExcluir_Click;
            this.Load += FormAuxiliaresMain_Load;

            _dataGridManager.AddEventHandlers();
        }
        /// <summary>
        /// 2.0. Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAuxiliaresMain_Load(object? sender, EventArgs e)
        {
            _dataLoader.PopularDtgTabelasAuxiliares();
        }
        //
        // métodos ToolStripEventHandler para os itens selecionados em dtgRegistrosTabelasAuxiliares
        //
        /// <summary>
        /// btn excluir registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EXCLUIR;
            AbrirFormCRUD(operacao);
        }
        /// <summary>
        /// btn consultar registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.CONSULTAR;
            AbrirFormCRUD(operacao);
        }
        /// <summary>
        /// btn editar registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EDITAR;
            AbrirFormCRUD(operacao);
        }
        /// <summary>
        /// btn novo registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            AbrirFormCRUD(operacao);
        }
        /// <summary>
        /// abrir fórmulario CRUD de acordo com tabela selecionada
        /// </summary>
        /// <param name="operacao"></param>
        private async void AbrirFormCRUD(OperacaoCRUD operacao)
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
                            await FormMenuMain.ShowModalOverlay(frm);
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
                            await FormMenuMain.ShowModalOverlay(frm);
                        }
                    }
                } 
                // contratos
                else if (_tabelaAuxiliarManager.IsTabelaContratosSelecionada(dtgTabelasAuxiliares))
                {
                    if (_dataLoader.idRegistro.IsValid())
                    {
                        // se painel de visualização aberto, fechar!
                        _dataLoader.FecharPanelVisualizacao();

                        // Abra o formulário CRUD para edição 
                        using (FormContratosFestas frm = new(_dataLoader.idRegistro, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            await FormMenuMain.ShowModalOverlay(frm);
                        }
                    }
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
                            await FormMenuMain.ShowModalOverlay(frm);
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
                            await FormMenuMain.ShowModalOverlay(frm);
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
                            await FormMenuMain.ShowModalOverlay(frm);
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
                            await FormMenuMain.ShowModalOverlay(frm);
                        }
                    }
                }
                //
                _dataLoader.CarregarRegistrosDaTabela();
            }
        }
        //

    } // end class FormAuxiliaresMain : FormBaseCadastro
} // end namespace FestasApp.Views.TableAuxiliares
