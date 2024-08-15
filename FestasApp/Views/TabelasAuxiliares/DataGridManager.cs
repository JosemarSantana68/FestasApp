//--------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação deste Módulo: 11/07/2024
//   Ultima Alteração: 11/07/2024
//   
//   Esta classe gerenciará a configuração e manipulação dos DataGridViews.
//
//--------------------------------------------------------------
namespace FestasApp.Views.TabelasAuxiliares
{
    public class DataGridManager
    {
        //public static DataGridView? dtgTabelasAuxiliares;
        //public DataGridView dtgTabelasAuxiliares { get; set; } // Torne este membro público para acesso

        /// <summary>
        /// Instância de FormAuxiliaresMain
        /// </summary>
        private readonly FormAuxiliaresMain _form;

        /// <summary>
        /// construtor padrão
        /// </summary>
        /// <param name="form"></param>
        public DataGridManager(FormAuxiliaresMain form)
        {
            _form = form;
        }
        /// <summary>
        /// método para configurar os dataGrids
        /// </summary>
        public void ConfigureDataGrids()
        {
            ConfigureDtgTabelasAuxiliares();
            ConfigureDtgRegistrosTabelasAuxiliares();
        }
        /// <summary>
        /// configurações do cabeçalho DtgTabelasAuxiliares
        /// </summary>
        private void ConfigureDtgTabelasAuxiliares()
        {
            DataGridView dtg = _form.dtgTabelasAuxiliares;

            // personaliza dtg
            SetDtgTabelasAuxiliares(dtg);

            // Configuração do cabeçalho
            dtg.ColumnHeadersVisible = true;
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            //dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGoldenrod;
            //this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // adiciona a coluna Tabelas
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "Tabelas", 194, "", padding: new Padding(5, 0, 0, 0));

            //dtg.Sort(dtg.Columns[0], ListSortDirection.Ascending);
        }
        //
        /// <summary>
        /// configurações gerais DtgTabelasAuxiliares
        /// </summary>
        /// <param name="dtg"></param>
        private void SetDtgTabelasAuxiliares(DataGridView dtg)
        {
            // Configurações de estilo das grades e bordas
            dtg.BorderStyle = BorderStyle.FixedSingle;
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dtg.BackgroundColor = Color.White; //this.BackColor;

            //dtg.DefaultCellStyle.SelectionBackColor = Color.LightGray; // backcolor linha selecionada
            dtg.DefaultCellStyle.SelectionForeColor = Color.White; // cor da linha selecionada

            // Configuração de linhas alternadas para melhor visualização
            //dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            // Oculta a coluna seletora de linhas
            dtg.RowHeadersVisible = false;

            // Configurações gerais do DataGridView
            dtg.ReadOnly = true;
            dtg.MultiSelect = false;
            dtg.AllowUserToAddRows = false;
            dtg.AllowUserToDeleteRows = false;
            dtg.AllowUserToOrderColumns = true;
            dtg.AllowUserToResizeColumns = true;
            dtg.AllowUserToResizeRows = false;

            // Seleção de linha inteira ao clicar
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configuração da altura geral das linhas
            dtg.RowTemplate.Height = 25;

            // Configuração geral das células
            //dtg.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dtg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Definir auto-gerar-colunas como false
            dtg.AutoGenerateColumns = false;
        }
        //
        /// <summary>
        /// algumas configurações para dtgRegistros...
        /// </summary>
        private void ConfigureDtgRegistrosTabelasAuxiliares()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.BackgroundColor = Color.White;
            //dtg.BorderStyle = BorderStyle.FixedSingle;
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter; // cabeçalho

        }
        //
        /// <summary>
        /// add eventos ao dtgTabelas
        /// </summary>
        public void AddEventHandlers()
        {
            _form.dtgTabelasAuxiliares.SelectionChanged += DtgTabelasAuxiliares_SelectionChanged;
        }
        //
        /// <summary>
        /// ao selecionar tabela em dtgTabelas, chama o método em DataLoader...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtgTabelasAuxiliares_SelectionChanged(object? sender, EventArgs e)
        {
            _form._dataLoader.HandleSelectionChanged(sender!, e);
        }
    }

}
