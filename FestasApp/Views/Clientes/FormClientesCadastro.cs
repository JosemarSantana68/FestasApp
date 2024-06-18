//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 06/06/2024
//   
//   FORMULÁRIO DE CLIENTE
//
//************************************************************

using FestasApp.Views.Clientes;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using FestasApp.Enums;

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
                if (dtgClientes.Rows[rowIndex].Cells[0].Value != null)
                {

                    try
                    {
                        // carrega os dados do datagrid no objeto cliente...
                        clsClientes cliente = new clsClientes
                        {
                            // Tente converter o valor da célula para inteiro
                            Id = Convert.ToInt32(dtgClientes.Rows[rowIndex].Cells[0].Value),
                            //
                            Nome = dtgClientes.Rows[rowIndex].Cells[1].Value.ToString(),
                            Telefone1 = dtgClientes.Rows[rowIndex].Cells[2].Value.ToString(),
                            Telefone2 = dtgClientes.Rows[rowIndex].Cells[3].Value.ToString(),
                            CPF = dtgClientes.Rows[rowIndex].Cells[4].Value.ToString(),
                            Endereco = dtgClientes.Rows[rowIndex].Cells[5].Value.ToString(),
                            CEP = dtgClientes.Rows[rowIndex].Cells[6].Value.ToString(),
                            Cidade = dtgClientes.Rows[rowIndex].Cells[7].Value.ToString(),
                            UF = dtgClientes.Rows[rowIndex].Cells[8].Value.ToString()
                        };

                        // Abra o formulárioCRUD de edição de clientes passando o cliente e operação
                        using (FormClientesCRUD frm = new FormClientesCRUD(cliente, operacao))
                        {
                            // Usar a sombra para exibir o FormClientesCRUD
                            //if (FormMenuBase.Instance != null)
                            //myUtilities.CreateModalOverlay(FormMenuBase.Instance, null, frm);
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

        //-------------------------------
        // carregar dataGrid com dados da tabela tblclientes do banco de dados
        private void CarregarDtgClientes()
        {
            try
            {
                // carrega o datagrid com dados do banco de dados...
                dtClientes = clsClientes.ReadAllClientes();

                if (dtClientes != null && dtClientes.Rows.Count > 0)
                {
                    dtgClientes.DataSource = dtClientes;
                    ConfigurarColunasDtgClientes();
                }
                else
                {
                    FormMenuBase.ShowMyMessageBox("Nenhum cliente encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //--------------------------------------------------
        // Configura o DataGridView para exibir os clientes.
        private void ConfigurarColunasDtgClientes()
        {
            //dtgClientes.Columns.Clear(); // Limpa quaisquer colunas existentes
            //-----------------------------------------
            // Colunas
            //
            int col = 0; // 0
            dtgClientes.Columns[col].HeaderText = "ID";
            //dtgClientes.Columns[col].Visible = false;
            dtgClientes.Columns[col].Width = 30;
            dtgClientes.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 1
            dtgClientes.Columns[col].HeaderText = "Nome Cliente";
            dtgClientes.Columns[col].Width = 220;
            dtgClientes.Columns[col].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            col++;   // 2
            dtgClientes.Columns[col].HeaderText = "Telefone-1";
            dtgClientes.Columns[col].Width = 120;
            dtgClientes.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 3
            dtgClientes.Columns[col].HeaderText = "Telefone-2";
            dtgClientes.Columns[col].Width = 120;
            dtgClientes.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 4
            dtgClientes.Columns[col].HeaderText = "CPF";
            dtgClientes.Columns[col].Width = 100;

            col++;   // 5
            dtgClientes.Columns[col].HeaderText = "Endereço";
            dtgClientes.Columns[col].Width = 220;

            col++;   // 6
            dtgClientes.Columns[col].HeaderText = "CEP";
            dtgClientes.Columns[col].Width = 80;

            col++;   // 7
            dtgClientes.Columns[col].HeaderText = "Cidade";
            dtgClientes.Columns[col].Width = 80;

            col++;   // 8
            dtgClientes.Columns[col].HeaderText = "UF";
            dtgClientes.Columns[col].Width = 80;
            dtgClientes.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            // ordenar datagrid - Nome
            dtgClientes.Sort(dtgClientes.Columns[1], ListSortDirection.Ascending);

            // Adiciona o evento CellFormatting para formatação dos dados
            dtgClientes.CellFormatting += DtgClientes_CellFormatting;

        } // end ConfigurarDtgClientes

        //-----------------------------------------------------------
        // Evento disparado para formatar as células do DataGridView.
        private void DtgClientes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Formatar Telefone-1
            if (dtgClientes.Columns[e.ColumnIndex].HeaderText == "Telefone-1" && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 11)
                {
                    e.Value = String.Format("{0:(00)00000-0000}", Int64.Parse(value));
                    e.FormattingApplied = true;
                }
            }
            // Formatar Telefone-2
            if (dtgClientes.Columns[e.ColumnIndex].HeaderText == "Telefone-2" && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 11)
                {
                    e.Value = String.Format("{0:(00)00000-0000}", Int64.Parse(value));
                    e.FormattingApplied = true;
                }
            }
            // Formatar CPF
            if (dtgClientes.Columns[e.ColumnIndex].HeaderText == "CPF" && e.Value != null)
            {
                string? value = e.Value.ToString();
                if (!string.IsNullOrEmpty(value) && value.Length == 11)
                {
                    e.Value = $"{value.Substring(0, 3)}.{value.Substring(3, 3)}.{value.Substring(6, 3)}-{value.Substring(9, 2)}";
                    e.FormattingApplied = true;
                }
            }
            // Formatar CEP
            if (dtgClientes.Columns[e.ColumnIndex].HeaderText == "CEP" && e.Value != null)
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
