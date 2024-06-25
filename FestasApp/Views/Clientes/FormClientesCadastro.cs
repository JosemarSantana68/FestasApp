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
        private DataTable dtClientes = new DataTable();
        public FormClientesCadastro()
        {
            InitializeComponent();
            ConfigurarForm();
            AddToolStripEventHandlers();
        }
        //
        // Evento disparado quando o formulário de cliente é carregado
        private void FormCliente_Load(object sender, EventArgs e)
        {
            // Configurações adicionais podem ser feitas aqui

        }
        //
        // Configurações iniciais do formulário de cliente
        private void ConfigurarForm()
        {
            // Adicione aqui as configurações específicas para o formulário de cliente
            // Remove a borda do formulário
            this.FormBorderStyle = FormBorderStyle.None;
            lblTitulo.Text = "C a d a s t r o  d e  C l i e n t e s";
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            CarregarDtgClientes();
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
        // btn NOVO...
        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            // incrementar Lógica do evento do botão
            clsClientes cliente = new clsClientes(); // cliente para passar
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            FormClientesCRUD frm = new FormClientesCRUD(cliente, operacao);

            // Usar a CreateModalOverlay para exibir o FormClientesCRUD
            FormMenuBase.ShowModalOverlay(frm);

            // quando volta do CRUD, atualiza dataGrid com dados da tabela no BD
            CarregarDtgClientes();
        }
        //-----------------------------------------
        // Evento Click do botão EDITAR
        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EDITAR;
            AbrirFormClientesCRUD(operacao);
        }
        //-----------------------------------------
        // Evento Click do botão CONSULTAR
        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.CONSULTAR;
            AbrirFormClientesCRUD(operacao);
        }
        //-----------------------------------------
        // Evento Click do botão EXCLUIR
        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            OperacaoCRUD operacao = OperacaoCRUD.EXCLUIR;
            AbrirFormClientesCRUD(operacao);
        }
        //---------------------------------------------------------------
        private void AbrirFormClientesCRUD(OperacaoCRUD operacao)
        {
            // Verifique se há uma linha selecionada no DataGridView
            if (dtgClientes.CurrentRow != null)
            {
                // Pegue o índice da linha atual
                int rowIndex = dtgClientes.CurrentRow.Index;

                // Verifique se a célula da coluna desejada, ID, não é nula
                if (dtgClientes.Rows[rowIndex].Cells[ColId].Value != null)
                {
                    try
                    {
                        // carrega os dados do datagrid no objeto cliente...
                        clsClientes cliente = new clsClientes
                        {
                            // Tente converter o valor da célula para inteiro
                            Id = Convert.ToInt32(dtgClientes.Rows[rowIndex].Cells[0].Value),
                            // carrega os dados do datagrid no objeto clsCliente
                            Nome = dtgClientes.Rows[rowIndex].Cells[ColNomeCliente].Value.ToString(),
                            Telefone1 = dtgClientes.Rows[rowIndex].Cells[ColTelefone1].Value.ToString(),
                            Telefone2 = dtgClientes.Rows[rowIndex].Cells[ColTelefone2].Value.ToString(),
                            CPF = dtgClientes.Rows[rowIndex].Cells[ColCpf].Value.ToString(),
                            Endereco = dtgClientes.Rows[rowIndex].Cells[ColEndereco].Value.ToString(),
                            CEP = dtgClientes.Rows[rowIndex].Cells[ColCep].Value.ToString(),
                            Cidade = dtgClientes.Rows[rowIndex].Cells[Colcidade].Value.ToString(),
                            UF = dtgClientes.Rows[rowIndex].Cells[ColUf].Value.ToString()
                        };

                        // Abra o formulárioCRUD de edição de clientes passando o cliente e operação
                        using (FormClientesCRUD frm = new FormClientesCRUD(cliente, operacao))
                        {
                            // Usar a sombra para exibir o FormClientesCRUD
                            FormMenuBase.ShowModalOverlay(frm);
                            
                            // quando volta do CRUD, atualiza dataGrid com dados da tabela no BD
                            
                            CarregarDtgClientes();
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

        } // end AbrirFormClientesCRUD
        //
        // carregar dataGrid com dados da tabela tblclientes do banco de dados
        public void CarregarDtgClientes()
        {
            try
            {
                // carrega o datagrid com dados do banco de dados...
                dtClientes = clsClientes.ReadAllClientes();

                if (dtClientes != null && dtClientes.Rows.Count > 0)
                {
                    dtgClientes.DataSource = dtClientes;
                    ConfigurarColunasDtgClientes();
                    TratarControles(false); // Habilita botões de CRUD
                }
                else
                {
                    FormMenuBase.ShowMyMessageBox("Nenhum cliente encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //
        private void TratarControles(bool desabilitar)
        {
            // controles deste form
            if (txtPesquisaCliente != null) txtPesquisaCliente.Enabled = !desabilitar;
            // controles do formBase
            TratarBtnCrud(desabilitar);
        }
        //
        // Configura o DataGridView para exibir os clientes.
        //--------------------------------------------
        // DataGridViews
        //
        private const int ColId = 0;
        private const int ColNomeCliente = 1;
        private const int ColTelefone1 = 2;
        private const int ColTelefone2 = 3;
        private const int ColCpf = 4;
        private const int ColEndereco = 5;
        private const int ColCep = 6;
        private const int Colcidade = 7;
        private const int ColUf = 8;
        private void ConfigurarColunasDtgClientes()
        {
            DataGridView dtg = dtgClientes;
            // configurar colunas
            myFunctions.ConfigurarColuna(dtg, ColId, "ID", 30, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColNomeCliente, "Nome Cliente", 220, padding: new Padding(5, 0, 0, 0));
            myFunctions.ConfigurarColuna(dtg, ColTelefone1, "Telefone-1", 120, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColTelefone2, "Telefone-2", 120, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColCpf, "CPF", 100, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, ColEndereco, "Endereço", 220);
            myFunctions.ConfigurarColuna(dtg, ColCep, "CEP", 80, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarColuna(dtg, Colcidade, "Cidade", 120);
            myFunctions.ConfigurarColuna(dtg, ColUf, "UF", 80, DataGridViewContentAlignment.MiddleCenter);
            //
            // ordenar datagrid - Nome
            dtgClientes.Sort(dtgClientes.Columns[ColNomeCliente], ListSortDirection.Ascending);

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
                FormMenuBase.ShowMyMessageBox("Erro ao filtrar clientes: " + ex.Message, "Pesquisa Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // end FiltrarClientes

    } // end class
} // end namespace
