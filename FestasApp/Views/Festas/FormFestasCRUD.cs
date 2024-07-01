//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//  Inicio: 23/05/2024
//  Criação do Módulo: 24/06/2024
//  Ultima Alteração: 26/06/2024
//   
//   FORMULÁRIO DE FESTAS C.R.U.D.
//
//************************************************************
namespace FestasApp.Views.Festas
{
    public partial class FormFestasCRUD : FormBaseCRUD
    {
        // instanciar objetos das classe para este form
        private int? festaId;
        private clsFestas? _festa;
        private OperacaoCRUD operacao;
        //
        // CRIAÇÃO - Construtor que recebe um objeto da classe e a operação
        public FormFestasCRUD(int _festaId, OperacaoCRUD _operacao)
        {
            InitializeComponent();
            this.festaId = _festaId;
            this.operacao = _operacao;
            //
            SuspendLayout();
            ConfigurarFormBaseCrud("F e s t a s", operacao);
            SetThisForm();
            SetControls();
            CarregarDadosFestaEF();
            ResumeLayout();
        }
        // CARREGAMENTO - Load
        private void FormFestasCRUD_Load(object sender, EventArgs e)
        {

            this.BeginInvoke(new Action(() => msktxtDataVenda.Focus()));
            //msktxtDataVenda.SelectAll(); // Seleciona todo o texto
        }
        private void CarregarDadosFestaEF()
        {
            if (operacao != OperacaoCRUD.NOVO)
            {
                using (var context = new clsFestasContext())
                {
                    _festa = context.Festas
                        .Include(f => f.Cliente)
                        .Include(f => f.Usuario)
                        .Include(f => f.Pacote)
                        .Include(f => f.Tema)
                        .Include(f => f.Espaco)
                        .Include(f => f.Status)
                        .Include(f => f.TipoEvento)
                        .Include(f => f.Detalhes)
                        .Include(f => f.Adicionais)
                        .FirstOrDefault(f => f.fest_id == festaId.Value);

                    if (_festa != null)
                    {
                        // Preencha os controles do formulário com os dados da festa
                        txtClienteNome.Text = _festa.Cliente?.cli_nome ?? "Não especificado";
                        //txtNomeUsuario.Text = _festa.Usuario?.Nome ?? "Não especificado";
                        cbbPacote.Text = _festa.Pacote?.pct_nome ?? "Não especificado";
                        cbbTema.Text = _festa.Tema?.tema_nome ?? "Não especificado";
                        cbbEspaco.Text = _festa.Espaco?.espc_nome ?? "Não especificado";
                        cbbStatus.Text = _festa.Status?.stt_status ?? "Não especificado";
                        cbbTipoEvento.Text = _festa.TipoEvento?.tpev_nome ?? "Não especificado";
                        msktxtDataVenda.Text = _festa.fest_dtVenda.ToString(); // ?? DateTime.Now;
                        mskDataFesta.Text = _festa.fest_dtFesta.ToString(); // ?? DateTime.Now;
                                                                            //txtValorFesta.Text = _festa.fest_valor?.ToString("F2") ?? "0,00";

                        // Obtém os adicionais da festa selecionada, incluindo os itens relacionados
                        var adicionaisFesta = context.Adicionais 
                            .Include(a => a.ItensFestas)         
                            .Where(a => a.add_fest_id == _festa.fest_id) 
                            .ToList();

                        // Preencha o DataGridView Itens com os adicionais da festa
                        CarregarDtgItensFestaEF(adicionaisFesta);
                 
                    }
                    else
                    {
                        MessageBox.Show("Festa não encontrada.\nCarregarDadosFestaEF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
        }
        //
        private void CarregarDtgItensFestaEF(ICollection<clsFestasAdicionais> adicionais)
        {
            dtgItens.Rows.Clear();
            foreach (var adicional in adicionais)
            {
                dtgItens.Rows.Add(adicional.ItensFestas?.itensfest_nome ?? "Não especificado",
                                  adicional.add_qtde, 
                                  adicional.add_valor);
            }
        }
        //
        // Configura o formulário com base na operação
        private void SetThisForm()
        {
            // Testa a operacao e configura os controles...
            switch (operacao)
            {
                case OperacaoCRUD.NOVO:
                    CarregarComboBoxesEF();
                    break;
                case OperacaoCRUD.EDITAR:
                    CarregarComboBoxesEF();
                    PopularControles();
                    break;
                case OperacaoCRUD.EXCLUIR:
                    MostrarFesta();
                    TravarControles();
                    break;
                case OperacaoCRUD.CONSULTAR:
                    MostrarFesta();
                    TravarControles();
                    break;
            }
        }
        //
        private void TravarControles()
        {

        }
        //
        private void MostrarFesta()
        {

        }
        //
        private void PopularControles()
        {
            //msktxtDataVenda.Text = festa.fest_dtVenda.ToString();
            //txtClienteNome.Text = festa.ClienteNome;
            //msktxtDataFesta.Text = festa.DataFesta.ToString();

            //cbbTipoEvento.Text = festa.TipoEventoNome;

            // Verifica se há um item selecionado
            //if (cbbTipoEvento.Items.Count > 0)
            //{
            //    // Encontra o item correspondente ao tipo de evento da festa
            //    //var tipoEventoSelecionado = cbbTipoEvento.Items.Cast<DataRowView>()
            //    //                   .FirstOrDefault(item => (string)item[cbbTipoEvento.DisplayMember] == festa.TipoEventoNome);

            //    //if (tipoEventoSelecionado != null)
            //    //{
            //    //    // Define o item selecionado no ComboBox pelo ValueMember
            //    //    cbbTipoEvento.SelectedItem = tipoEventoSelecionado;
            //    //}
            //}
        }
        //
        // carregar comboboxes
        private void CarregarComboBoxesEF()
        {
            if (!FormMenuMain.ConexaoAtiva)
            {
                FormMenuMain.ShowMyMessageBox("Não foi possível carregar os dados, sem conexão com o banco de dados.\nSetComboBoxesEF", "Falha");
                return;
            }
            using (var context = new clsFestasContext())
            {
                SetComboBoxesEF(cbbEspaco, context.Espacos, "espc_nome", "espc_id");
                SetComboBoxesEF(cbbPacote, context.Pacotes, "pct_nome", "pct_id");
                SetComboBoxesEF(cbbStatus, context.Status, "stt_status", "stt_id");
                SetComboBoxesEF(cbbTema, context.Temas, "tema_nome", "tema_id");
                SetComboBoxesEF(cbbTipoEvento, context.TipoEvento, "tpev_nome", "tpev_id");
            }
        }
        //
        private void SetComboBoxesEF<T>(ComboBox cbb, DbSet<T> dbSet, string displayMember, string valueMember) where T : class
        {
            if (!FormMenuMain.ConexaoAtiva)
                return;
            try
            {
                using (var context = new clsFestasContext())
                {
                    cbb.DataSource = dbSet.ToList();
                    cbb.DisplayMember = displayMember;
                    cbb.ValueMember = valueMember;
                    cbb.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                FormMenuMain.ShowMyMessageBox($"Erro ao carregar dados: {ex.Message}\nSetComboBoxesEF {cbb.Name}", "Falha");
            }
        }
        //
        private void SetControls()
        {
            txtItemFesta.Height = 18;
            txtItemQtde.Height = 18;
            txtItemValor.Height = 18;
            //
            txtValorTotalIntens.TextAlign = HorizontalAlignment.Right;
            txtValorTotalIntens.ReadOnly = true;
            txtValorTotalIntens.TabStop = false;
            //
            ConfigurarDtgItens();
            this.dtgItens.CellContentClick += DtgItens_CellContentClick;

            //// Associa o evento GotFocus para cada ComboBox
            //cbbEspaco.GotFocus += cbb_GotFocus;
            //cbbPacote.GotFocus += cbb_GotFocus;
            //cbbStatus.GotFocus += cbb_GotFocus;
            //cbbTema.GotFocus += cbb_GotFocus;
            //cbbTipoEvento.GotFocus += cbb_GotFocus;
        }
        private void cbb_GotFocus(object sender, EventArgs e)
        {
            ComboBox? cbb = sender as ComboBox;
            if (cbb != null)
            {
                cbb.SelectionLength = 0; // Desativa a seleção de texto
            }
        }
        //
        //******************
        // salvarItens
        private void SalvarItens(int festaId)
        {
            foreach (DataGridViewRow row in dtgItens.Rows)
            {
                if (row.IsNewRow) continue;

                string descricao = row.Cells[ColDescricao].Value?.ToString() ?? string.Empty; // Verifica nulo e atribui string vazia se for nulo
                int quantidade = row.Cells[ColQtde].Value != null ? Convert.ToInt32(row.Cells[ColQtde].Value) : 0;
                double valor = row.Cells[ColValor].Value != null ? Convert.ToDouble(row.Cells[ColValor].Value) : 0.0;

                // Chamar método para salvar/atualizar item no banco de dados
                //clsFestasItens.SalvarItem(festaId, descricao, quantidade, valor);
            }
        }
        //
        //*******************
        // salvarFestas
        private void SalvarFesta()
        {
            try
            {
                // Salvar dados principais da festa
                //int festaId = clsFestas.Salvar(festa); // Implementar método para salvar festa e retornar o ID

                // Salvar itens da festa
                //SalvarItens(festaId);

                myUtilities.myMessageBox(this, "Festa salva com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Erro ao salvar festa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //***************************************************************************
        #region DataGridViews dtgItens
        //
        // DataGridViews
        // constantes com Numeros das colunas
        private const int ColDescricao = 0;
        private const int ColQtde = 1;
        private const int ColValor = 2;
        private const int ColDelete = 3;
        //
        private void ConfigurarDtgItens()
        {
            DataGridView dtg = dtgItens;

            // Configuração do cabeçalho
            dtg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dtg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtg.BackgroundColor = Color.White;

            // Configuração de linhas alternadas para melhor visualização
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

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
            dtg.RowTemplate.Height = 18;

            // Configuração geral das células
            dtg.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            //dtg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Limpar colunas existentes
            dtgItens.Columns.Clear();

            // adicionar configurar colunas
            myFunctions.ConfigurarAdicionarColuna(dtg, ColDescricao, "Descrição", 200, DataGridViewContentAlignment.MiddleLeft);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColQtde, "Qtde", 80, DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColValor, "Valor", 80, DataGridViewContentAlignment.MiddleRight);

            // Formatar coluna Valor como moeda
            dtg.Columns[ColDescricao].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dtg.Columns[ColValor].DefaultCellStyle.Format = "C2";

            // Adicionar coluna de exclusão
            DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn
            {
                Image = Properties.Resources.delete_18x18, // Certifique-se de ter um recurso de imagem chamado delete_18x18
                //Name = "Delete",
                //HeaderText = "Excluir",
                Width = 50
            };
            dtg.Columns.Add(deleteColumn);

            // Adicionar eventos
            dtg.CellMouseEnter += Dtg_CellMouseEnter;
            dtg.CellMouseLeave += Dtg_CellMouseLeave;

        } //end ConfigurarDtgItens
        //
        // deletar itens dtgItensFestas
        private void DtgItens_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Verifique se o clique foi na coluna de exclusão
            if (e.ColumnIndex == dtgItens.Columns[ColDelete].Index && e.RowIndex >= 0)
            {
                // Verifique se a linha não está vazia
                var currentRow = dtgItens.Rows[e.RowIndex];
                if (currentRow.Cells[ColDescricao].Value != null && !string.IsNullOrEmpty(currentRow.Cells[ColDescricao].Value.ToString()))
                {
                    string descricao = currentRow.Cells[ColDescricao].Value?.ToString() ?? string.Empty;
                    // Confirmar deleção
                    var resultado = myUtilities.myMessageBox(this, $"Tem certeza que deseja deletar {descricao}?", "Confirmação de Deleção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        // Remover a linha do DataGridView
                        dtgItens.Rows.RemoveAt(e.RowIndex);
                        // atualiza soma total de itens
                        txtValorTotalIntens.Text = SomarValorTotalItens().ToString("C2");
                        txtItemFesta.Focus();
                    }
                }
                //else
                //{
                //    // Exibir mensagem de erro se a linha estiver vazia
                //    myUtilities.myMessageBox(this, "A linha selecionada está vazia e não pode ser deletada.", "Erro de Deleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
        }
        //
        // adiciona itens no dtgItensFestas
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Validar os campos de entrada
            if (string.IsNullOrWhiteSpace(txtItemFesta.Text) ||
                string.IsNullOrWhiteSpace(txtItemQtde.Text) ||
                string.IsNullOrWhiteSpace(txtItemValor.Text))
            {
                myUtilities.myMessageBox(this, "Todos os campos devem ser preenchidos.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemFesta.Focus();
                return;
            }
            // Tentar converter os valores de quantidade
            if (!int.TryParse(txtItemQtde.Text, out int quantidade))
            {
                myUtilities.myMessageBox(this, "Quantidade deve ser um número inteiro válido.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemQtde.Focus();
                return;
            }
            // Tentar converter os valores de valor
            if (!double.TryParse(txtItemValor.Text, out double valor))
            {
                myUtilities.myMessageBox(this, "Valor deve ser um número válido.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemValor.Focus();
                return;
            }
            // Adicionar o item ao DataGridView
            dtgItens.Rows.Add($"{txtItemFesta.Text} ({valor.ToString("N2")})", quantidade, (valor * quantidade));
            // soma total de itens
            txtValorTotalIntens.Text = SomarValorTotalItens().ToString("C2");
            // Limpar os campos de entrada
            txtItemFesta.Clear();
            txtItemQtde.Clear();
            txtItemValor.Clear();
            txtItemFesta.Focus();
        }
        //
        // valor total de itens
        private double SomarValorTotalItens()
        {
            double soma = 0;
            foreach (DataGridViewRow row in dtgItens.Rows)
            {
                double valor = row.Cells[ColValor].Value != null ? Convert.ToDouble(row.Cells[ColValor].Value) : 0.0;
                //double quantidade = row.Cells[ColQtde].Value != null ? Convert.ToDouble(row.Cells[ColValor].Value) : 0;
                soma += valor;
            }
            return soma;
        }
        //
        // Evento para mudar o cursor ao entrar na célula de exclusão
        private void Dtg_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dtg)
            {
                if (e.ColumnIndex == dtg.Columns[ColDelete].Index && e.RowIndex >= 0)
                {
                    dtg.Cursor = Cursors.Hand;
                }
            }
        }
        //
        // Evento para mudar o cursor ao sair da célula de exclusão
        private void Dtg_CellMouseLeave(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dtg)
            {
                if (e.ColumnIndex == dtg.Columns[ColDelete].Index && e.RowIndex >= 0)
                {
                    dtg.Cursor = Cursors.Default;
                }
            }
        }
        #endregion
        //***************************************************************************
        private void CarregarComboBoxes()
        {
            // Primeira tentativa de carregar os ComboBoxes
            SetComboBoxes(cbbEspaco, "tblfestasespacos", "espc_id", "espc_nome");
            // Verifica o status da conexão após a primeira tentativa
            if (!FormMenuMain.ConexaoAtiva) return;

            SetComboBoxes(cbbPacote, "tblfestaspacotes", "pct_id", "pct_nome");
            SetComboBoxes(cbbStatus, "tblfestasstatus", "stt_id", "stt_status");
            SetComboBoxes(cbbTema, "tblfestastemas", "tema_id", "tema_nome");
            SetComboBoxes(cbbTipoEvento, "tblfestastipoevento", "tpev_id", "tpev_nome");
        }
        private void SetComboBoxes(ComboBox cbb, string tabela, string campoId, string campoNome)
        {
            if (!FormMenuMain.ConexaoAtiva)
            {
                FormMenuMain.ShowMyMessageBox($"Falha na conexão com banco de dados. Não foi possível carregar os dados para o combobox de {tabela}.", "Erro ao Carregar Dados");
                return;
            }

            var data = myFunctions.GetDataComboBox(tabela, campoId, campoNome);
            if (data != null)
            {
                cbb.DataSource = data;
                cbb.ValueMember = campoId; // Coluna "id" a ser associada ao valor selecionado
                cbb.DisplayMember = campoNome; // Coluna "nome" a ser exibida
                //cbb.Focus();
                //cbb.SelectedIndex = -1;
                //cbb.SelectionLength = 0;
                //cbb.Select(0, 0); 
            }
            else
            {
                // Se houver erro, limpa o ComboBox e exibe uma mensagem de erro
                cbb.DataSource = null;
                //myUtilities.myMessageBox(this, $"Erro ao carregar dados para o combobox de {tabela}.", "Erro ao Carregar Dados");
            }
        }
        private void CarregarComboBoxesEFcomLambdaERROCS1660()
        {
            //using (var context = new clsFestasContext())
            //{
            //    SetComboBoxesEF(cbbEspaco, context.Espacos, e => e.espc_nome, e => e.espc_id);
            //    SetComboBoxesEF(cbbPacote, context.Pacotes, p => p.pct_nome, p => p.pct_id);
            //    SetComboBoxesEF(cbbStatus, context.Status, s => s.stt_status, s => s.stt_id);
            //    SetComboBoxesEF(cbbTema, context.Temas, t => t.tema_nome, t => t.tema_id);
            //    SetComboBoxesEF(cbbTipoEvento, context.TipoEvento, te => te.tpev_nome, te => te.tpev_id);
            //}
        }
        private void SetComboBoxesEFcomLambdaERROCS1660<T>(ComboBox cbb, DbSet<T> dbSet, Func<T, object> displayMember, Func<T, object> valueMember) where T : class
        {
            if (!FormMenuMain.ConexaoAtiva)
            {
                FormMenuMain.ShowMyMessageBox("Não foi possível carregar os dados, sem conexão com o banco de dados.", "SetComboBoxesEFcomLambda");
                return;
            }

            try
            {
                using (var context = new clsFestasContext())
                {
                    var data = dbSet.ToList();
                    cbb.DataSource = data;
                    cbb.DisplayMember = displayMember.GetType().Name; // Para uso interno, não altera o comportamento
                    cbb.ValueMember = valueMember.GetType().Name;     // Para uso interno, não altera o comportamento
                    cbb.DisplayMember = "DisplayMember"; // Será resolvido pelo DisplayConverter
                    cbb.ValueMember = "ValueMember";     // Será resolvido pelo ValueConverter

                    cbb.DataSource = data.Select(d => new
                    {
                        DisplayMember = displayMember(d),
                        ValueMember = valueMember(d)
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                FormMenuMain.ShowMyMessageBox($"Erro ao carregar dados: {ex.Message}", "SetComboBoxesEFcomLambda");
            }
        }
        private void btnDeleteItem_ClickSEMUSO(object sender, EventArgs e)
        {
            // Verifique se uma linha está selecionada
            if (dtgItens.CurrentRow != null)
            {
                var resultado = myUtilities.myMessageBox(this, "Tem certeza que deseja deletar este item?", "Confirmação de Deleção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    // Remover a linha selecionada do DataGridView
                    dtgItens.Rows.RemoveAt(dtgItens.CurrentRow.Index);
                    // atualiza soma total de itens
                    txtValorTotalIntens.Text = SomarValorTotalItens().ToString("C2");
                }
            }
            else
            {
                myUtilities.myMessageBox(this, "Nenhuma linha está selecionada.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Criar e abrir o formulário CRUD passando o objeto e a operação
            using (Form frm = new FormBaseAuxilares())
            {
                // Usar a Modal para exibir o FormCRUD
                myUtilities.CreateModalOverlay(this, frmExibir: frm);
            }
        }
        //
    } // end class FormFestasCRUD
} // end namespace FestasApp.Views.Festas
