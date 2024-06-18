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

using FestasApp.Views.Festas;
using FestasApp.Views.Usuarios;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing.Text;

namespace FestasApp.Views
{
    public partial class FormFestasCadastro : FormBaseCadastro
    {     

        public FormFestasCadastro()
        {
            InitializeComponent();
            ConfigurarFormFestas();
        }
       
        private void FormFestas_Load(object sender, EventArgs e)
        {
            // Outras configurações de carregamento podem ser adicionadas aqui, se necessário
        }

        // Configurações iniciais do formulário de cliente
        private void ConfigurarFormFestas()
        {
            // Adicione aqui as configurações específicas para o formulário de cliente
            this.FormBorderStyle = FormBorderStyle.None;
            lblTitulo.Text = "C a d a s t r o  d e  F e s t a s";
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            CarregarDtgFestas();
        }
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
                }
                else
                {
                    FormMenuBase.ShowMyMessageBox("Nenhuma Festa encontrado.", "Carregar Festas", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ConfigurarDtgFestas()
        {
            DataGridView dtg = dtgFestas;
            //dtgUsuarios.Columns.Clear(); // Limpa quaisquer colunas existentes
            //-----------------------------------------
            // Colunas
            //
            int col = 0; // 0
            dtg.Columns[col].HeaderText = "ID";
            dtg.Columns[col].Width = 30;
            dtg.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 1
            dtg.Columns[col].HeaderText = "ClienteId";
            dtg.Columns[col].Width = 80;
            dtg.Columns[col].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            col++;   // 2
            dtg.Columns[col].HeaderText = "UsuarioId";
            dtg.Columns[col].Width = 80;
            //dtgUsuarios.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 3
            dtg.Columns[col].HeaderText = "PacoteId";
            dtg.Columns[col].Width = 80;
            //dtgUsuarios.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 4
            dtg.Columns[col].HeaderText = "TemaId";
            dtg.Columns[col].Width = 80;
            dtg.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 5
            dtg.Columns[col].HeaderText = "EspacoId";
            dtg.Columns[col].Width = 80;
            dtg.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 6
            dtg.Columns[col].HeaderText = "StatusId";
            dtg.Columns[col].Width = 80;
            dtg.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 7
            dtg.Columns[col].HeaderText = "TipoEventoId";
            dtg.Columns[col].Width = 80;
            dtg.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 8
            dtg.Columns[col].HeaderText = "DataVenda";
            dtg.Columns[col].Width = 60;
            dtg.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 9
            dtg.Columns[col].HeaderText = "DataFesta";
            dtg.Columns[col].Width = 60;
            dtg.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            col++;   // 10
            dtg.Columns[col].HeaderText = "Valor";
            dtg.Columns[col].Width = 60;
            dtg.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            // ordenar datagrid - Nome
            dtg.Sort(dtg.Columns[1], ListSortDirection.Ascending);

            // Adiciona o evento CellFormatting para formatação dos dados
            //dtg.CellFormatting += Dtg_CellFormatting;
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

        private void TstbtnExcluir_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TstbtnConsultar_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TstbtnEditar_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TstbtnNovo_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



        // Evento disparado ao clicar no botão de fechar
        private void tstbtnFechar_Click(object sender, EventArgs e)
        {
            // Fecha o formulário atual
            this.Close();
        }

    } // end class FormFestas
} // end namespace
