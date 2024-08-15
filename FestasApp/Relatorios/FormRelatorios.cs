//---------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C# .NET
//
//   Inicio: 23/05/2024
//   Criação deste Módulo: 07/08/2024
//   Ultima Alteração: 07/08/2024
//   
//   Formulário para gerenciamento de Relatórios do Sistema
//
//----------------------------------------------------------------


namespace FestasApp.Views.Relatorios
{
    public partial class FormRelatorios : FormBaseCadastro
    {
        private Dictionary<string, Action> relatoriosActions = []; // declara um vazio

        /// <summary>
        /// construtor padrão
        /// </summary>
        public FormRelatorios()
        {
            InitializeComponent();

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
            lblTitulo.Text = "C a d a s t r o s  d e  R e l a t ó r i o s";
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }
        /// <summary>
        /// 1.2. configurações iniciais de controles
        /// </summary>
        private void SetControls()
        {
            //
            // splitContainer
            spltRelatorios.Dock = DockStyle.Fill;
            spltRelatorios.Panel1MinSize = 220;
            spltRelatorios.SplitterDistance = 220;
            //
            // treeView
            SetTreeView();
            //
            // pnlVisualizador
            pnlVisualizador.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Configurar TreeViewRelatórios
        /// </summary>
        private void SetTreeView()
        {
            // Configurar o treeView
            trvRelatorios.Dock = DockStyle.Fill;
            trvRelatorios.Nodes.Clear();
            // Ativa a ordenação dos nós
            trvRelatorios.Sorted = true;

            // Inicializa o dicionário para armazenar os tipos de relatórios
            relatoriosActions = new Dictionary<string, Action>();

            //
            // financeiros
            //
            TreeNode raizFinanceiros = trvRelatorios.Nodes.Add("Relatórios Financeiros");
                TreeNode contasPagar = raizFinanceiros.Nodes.Add("Contas a Pagar");
                TreeNode contasReceber = raizFinanceiros.Nodes.Add("Contas a Receber");
                TreeNode valorFestasPeriodo = raizFinanceiros.Nodes.Add("Festas no Período");
                TreeNode contasSituacao = raizFinanceiros.Nodes.Add("Contas por Situação");
            // financeiros Names 
            contasPagar.Name = "contasPagar";
            contasReceber.Name = "contasReceber";
            valorFestasPeriodo.Name = "valorFestasPeriodo";
            contasSituacao.Name = "contasSituacao";
            // financeiros dicionário
            //relatoriosActions.Add("contasPagar", ExibirMensagemTreeView);
            //relatoriosActions.Add("contasReceber", ExibirMensagemTreeView);
            //relatoriosActions.Add("valorFestasPeriodo", ExibirMensagemTreeView);
            //relatoriosActions.Add("contasSituacao", ExibirMensagemTreeView);

            //
            // festas
            //
            TreeNode raizFestas = trvRelatorios.Nodes.Add("Relatórios Festas");
                TreeNode festasPeriodo = raizFestas.Nodes.Add("Festas por Período");
                TreeNode festasClientes = raizFestas.Nodes.Add("Festas de Clientes");
                TreeNode festaPeriodo = raizFestas.Nodes.Add("Valor de Festas no Período");
                TreeNode festaTipos = raizFestas.Nodes.Add("Festas por Tipos");
                TreeNode festaContratos = raizFestas.Nodes.Add("Festas por Contratos");
                TreeNode festaSituacao = raizFestas.Nodes.Add("Festas por Situação");
            // festas Names 
            festasPeriodo.Name = "festasPeriodo";
            festasClientes.Name = "festasClientes";
            festaPeriodo.Name = "festaPeriodo";
            festaTipos.Name = "festaTipos";
            festaContratos.Name = "festaContratos";
            festaSituacao.Name = "festaSituacao";
            // festas dicionário
            //relatoriosActions.Add("festasPeriodo", ExibirMensagemTreeView);
            //relatoriosActions.Add("festasClientes", ExibirMensagemTreeView);
            //relatoriosActions.Add("festaPeriodo", ExibirMensagemTreeView);
            //relatoriosActions.Add("festaTipos", ExibirMensagemTreeView);
            //relatoriosActions.Add("festaContratos", ExibirMensagemTreeView);
            //relatoriosActions.Add("festaSituacao", ExibirMensagemTreeView);

            //
            // clientes
            //
            TreeNode raizClientes = trvRelatorios.Nodes.Add("Relatórios Clientes");
                TreeNode clientesGeral = raizClientes.Nodes.Add("Relação de Clientes Completa");
                TreeNode clientesTelefones = raizClientes.Nodes.Add("Relação de Clientes & Telefone");
                TreeNode clientesAniversarios = raizClientes.Nodes.Add("Relação de Aniversários"); // considerar mès do aniversário
            // clientes Names
            clientesGeral.Name = "clientesGeral";
            clientesTelefones.Name = "clientesTelefones";
            clientesAniversarios.Name = "clientesAniversarios";
            // clientes dicionário
            relatoriosActions.Add("clientesGeral", ExibirRelatorioClientesGeral);
            //relatoriosActions.Add("clientesTelefones", ExibirMensagemTreeView);
            //relatoriosActions.Add("clientesAniversarios", ExibirMensagemTreeView);

            //
            // funcionários
            //
            TreeNode raizFuncionarios = trvRelatorios.Nodes.Add("Relatórios Funcionários");
                TreeNode funcRelatorio = raizFuncionarios.Nodes.Add("Funcionários Cadastrados");
                TreeNode funcVendas = raizFuncionarios.Nodes.Add("Vendas por Funcionários");

            //
            // Expande todos os nós do TreeView
            trvRelatorios.ExpandAll();
            // adiciona eventos handlers
            trvRelatorios.AfterSelect += TrvRelatorios_AfterSelect;
        }

        /// <summary>
        /// Evento do TreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrvRelatorios_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            // Verifica se o relatório existe no dicionário e executa a ação correspondente
            if (e.Node != null && relatoriosActions.TryGetValue(e.Node.Name, out var action))
            {
                action.Invoke();
            }
            else
            {
                // Exibir uma mensagem padrão para outros relatórios
                pnlVisualizador.Controls.Clear();
                Label lblRelatorio = new Label
                {
                    Text = $"Exibindo: {e.Node!.Text}",
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlVisualizador.Controls.Add(lblRelatorio);
            }
        }

        /// <summary>
        /// Exibe o relatório "Relação de Clientes Completa" no painel visualizador
        /// </summary>
        private void ExibirRelatorioClientesGeral()
        {
            // limpa o painel visualizador
            pnlVisualizador.Controls.Clear();

            using (clsFestasContext context = new())
            {
                var listaClientes = context.Clientes.ToList();

                // Criar o DataTable e preencher com os dados dos clientes
                DataTable dtClientes = new ClientesDataSet.dtClientesDataTable();

                foreach (var cliente in listaClientes)
                {
                    // Adicionar uma nova linha ao DataTable

                    dtClientes.Rows.Add(cliente.cli_id, cliente.cli_nome, cliente.cli_telefone1,
                                        cliente.cli_telefone2, cliente.cli_cpf, cliente.cli_endereco,
                                        cliente.cli_cep, cliente.cli_cidade, cliente.cli_uf);

                    //var row = dtClientes.NewRow();
                    //row["cli_id"] = cliente.cli_id;
                    //row["cli_nome"] = cliente.cli_nome;
                    //row["cli_telefone1"] = cliente.cli_telefone1;
                    //row["cli_telefone2"] = cliente.cli_telefone2;
                    //row["cli_cpf"] = cliente.cli_cpf;
                    //row["cli_endereco"] = cliente.cli_endereco;
                    //row["cli_cep"] = cliente.cli_cep;
                    //row["cli_cidade"] = cliente.cli_cidade;
                    //row["cli_uf"] = cliente.cli_uf;
                    //dtClientes.Rows.Add(row);
                }

                // Configurar o ReportViewer
                ReportViewer reportViewer = new()
                {
                    Dock = DockStyle.Fill,
                    ProcessingMode = ProcessingMode.Local
                };

                // Configurar o caminho do relatório
                reportViewer.LocalReport.ReportEmbeddedResource = "FestasApp.Relatorios.ClientesRprt.rdlc";

                // Adicionar o DataTable como fonte de dados            ("nome-conjunto-de-dados", nome-data-table)     
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ClientesDataSet", dtClientes)); 

                // Renderizar o relatório
                reportViewer.RefreshReport();

                // Adicionar o ReportViewer ao painel
                pnlVisualizador.Controls.Add(reportViewer);
            }
        }
        /// <summary>
        /// 1.3. adiciona eventos Handlers
        /// </summary>
        private void AddEventHandlers()
        {
            //// Adiciona o manipulador de eventos para os botões do ToolStrip
            //this.tstbtnNovo.Click += TstbtnNovo_Click;
            //this.tstbtnEditar.Click += TstbtnEditar_Click;
            //this.tstbtnConsultar.Click += TstbtnConsultar_Click;
            //this.tstbtnExcluir.Click += TstbtnExcluir_Click;
            //this.Load += FormAuxiliaresMain_Load;
        }

    } // end class FormRelatorios : FormBaseCadastro
} // end namespace FestasApp.Views.Relatorios
