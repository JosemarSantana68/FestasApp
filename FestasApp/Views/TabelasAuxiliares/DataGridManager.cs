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

        private readonly FormAuxiliaresMain _form;
        //
        public DataGridManager(FormAuxiliaresMain form)
        {
            _form = form;
        }
        //
        public void ConfigureDataGrids()
        {
            ConfigureDtgTabelasAuxiliares();
            ConfigureDtgRegistrosTabelasAuxiliares();
        }
        //
        private void ConfigureDtgTabelasAuxiliares()
        {
            DataGridView dtg = _form.dtgTabelasAuxiliares;
            // personaliza dtg
            SetDtgTabelasAuxiliares(dtg);
            // colunas
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "Tabelas", 194, "", padding: new Padding(5, 0, 0, 0));
            //dtg.Sort(dtg.Columns[0], ListSortDirection.Ascending);
        }
        //
        // configurações do cabeçalho e gerais DtgTabelasAuxiliares
        private void SetDtgTabelasAuxiliares(DataGridView dtg)
        {
            // Configuração do cabeçalho
            dtg.ColumnHeadersVisible = true;
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            //dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGoldenrod;

            //this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //this.BackgroundColor = Color.White;

            // Configurações de estilo
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

            // Definir AutoGenerateColumns como false
            dtg.AutoGenerateColumns = false;
        }
        //
        private void ConfigureDtgRegistrosTabelasAuxiliares()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.BackgroundColor = Color.White;
            //dtg.BorderStyle = BorderStyle.FixedSingle;
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

        }
        //
        public void AddEventHandlers()
        {
            _form.dtgTabelasAuxiliares.SelectionChanged += DtgTabelasAuxiliares_SelectionChanged;
        }
        //
        private void DtgTabelasAuxiliares_SelectionChanged(object? sender, EventArgs e)
        {
            _form._dataLoader.HandleSelectionChanged(sender!, e);
        }
    }

}
