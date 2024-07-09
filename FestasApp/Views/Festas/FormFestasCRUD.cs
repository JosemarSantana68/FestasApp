//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//  Inicio: 23/05/2024
//  Criação do Módulo: 24/06/2024
//  Ultima Alteração: 03/07/2024
//   
//   FORMULÁRIO DE FESTAS C.R.U.D.
//
//************************************************************
using System.Diagnostics;
using System.Diagnostics.Contracts;
using FestasApp.Utilities;

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
        public FormFestasCRUD(int? _festaId, OperacaoCRUD _operacao)
        {
            InitializeComponent();
            this.festaId = _festaId;
            this.operacao = _operacao;
            //
            SuspendLayout();
            ConfigurarFormBaseCrud("F e s t a s", operacao);
            AddToolStripEventHandlers();
            ResumeLayout();
        }
        // CARREGAMENTO - Load
        private void FormFestasCRUD_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            this.BeginInvoke(new Action(() => msktxtDataVenda.Focus()));
            //msktxtDataVenda.SelectAll(); // Seleciona todo o texto
            SetThisForm();
            SetControls();
            MostraDadosFestaSelecionadaEF(festaId!.Value);
            ResumeLayout();
        }
        // Adiciona eventosHandlers aos controles
        private void AddToolStripEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
            this.dtgItens.SelectionChanged += DtgItens_SelectionChanged;
            this.dtgItens.CellContentClick += DtgItens_CellContentClick;
        }
        // Configura o formulário com base na operação
        private void SetThisForm()
        {
            // Testa a operacao e configura os controles...
            switch (operacao)
            {
                case OperacaoCRUD.NOVO:
                    CarregarComboBoxesEF();
                    UnselectComboBoxes();
                    LimparControles();
                    break;
                case OperacaoCRUD.EDITAR:
                    CarregarComboBoxesEF();
                    break;
                case OperacaoCRUD.EXCLUIR:
                    TravarControles();
                    break;
                case OperacaoCRUD.CONSULTAR:
                    TravarControles();
                    break;
            }
        }
        //
        private void SetControls()
        {
            /*
             Mask: Define a máscara que será usada pelo MaskedTextBox. No seu caso, a máscara é "00:00".
             
            CutCopyMaskFormat: Define o comportamento ao cortar e copiar o texto. MaskFormat.ExcludePromptAndLiterals faz com que apenas os caracteres de entrada do usuário sejam incluídos na operação de corte e cópia.
             
            TextMaskFormat: Define como a propriedade Text é manipulada. MaskFormat.ExcludePromptAndLiterals faz com que a leitura do texto exclua os prompts e literais. 
             */
            mskHoraInicio.Mask = "00:00";
            mskHoraInicio.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskHoraInicio.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            mskHoraFim.Mask = "00:00";
            mskHoraFim.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskHoraFim.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            
            //
            cbbItemFesta.Height = 18;
            txtItemQtde.Height = 18;
            txtItemValor.Height = 18;
            //
            txtValorTotalIntens.TextAlign = HorizontalAlignment.Right;
            txtValorTotalIntens.ReadOnly = true;
            txtValorTotalIntens.TabStop = false;
            //
            ConfigurarDtgItens();
            //
            ConfigurarAutoCompletarTxt();

            // desmarcar comboboxes
            //// Associa o evento GotFocus para cada ComboBox
            //cbbEspaco.GotFocus += cbb_GotFocus;
            //cbbPacote.GotFocus += cbb_GotFocus;
            //cbbStatus.GotFocus += cbb_GotFocus;
            //cbbTema.GotFocus += cbb_GotFocus;
            //cbbTipoEvento.GotFocus += cbb_GotFocus;
        }
        //
        private void LimparControles()
        {
            // limpas os controles
            msktxtDataVenda.Text = DateTime.Now.ToShortDateString();
            txtClienteNome.Clear();
            txtUserNome.Clear();
            mskDataFesta.Clear();
            lblValorTotalFesta.Text = string.Empty;
            txtTotalPessoa.Clear();
            txtTotalAdultos.Clear();
            txtPessoasAMais.Clear();
            txtCriancasPagantes.Clear();
            txtCriancasNaoPagantes.Clear();
            txtContrato.Clear();
            // limpa adicionais da festa
            txtItemQtde.Clear();
            txtItemValor.Clear();
            dtgItens.Rows.Clear();
            txtValorTotalIntens.Clear();
        }
        //
        private void UnselectComboBoxes()
        {
            cbbPacote.SelectedItem = -1;
            cbbTema.SelectedItem = -1;
            cbbEspaco.SelectedItem = -1;
            cbbStatus.SelectedItem = -1;
            cbbTipoEvento.SelectedItem = -1;
            cbbItemFesta.SelectedItem = -1;

        }
        //
        private async void TstbtnSalvar_Click(object? sender, EventArgs e)
        {
            //// Validar os controles antes de prosseguir
            //if (!ValidarControles())
            //{
            //    return; // Se a validação falhar, interrompa o processo de salvar
            //}

            // Testa a operacao e configura os controles...
            switch (operacao)
            {
                case OperacaoCRUD.NOVO:
                    await SalvarFestaEF();
                    break;
                case OperacaoCRUD.EDITAR:
                    await SalvarFestaEF(festaId);
                    break;
                case OperacaoCRUD.EXCLUIR:
                    await ExcluirFestaEF(festaId);
                    break;
            }
        }
        // 1. mostra dados de festa selecionada
        private void MostraDadosFestaSelecionadaEF(int festaId)
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
                        .FirstOrDefault(f => f.fest_id == festaId);

                    if (_festa != null)
                    {
                        // Preencha os controles do formulário com os dados da festa
                        txtClienteNome.Text = _festa.Cliente?.cli_nome ?? "Não especificado";
                        txtUserNome.Text = _festa.Usuario?.user_nome ?? "Não especificado";
                        cbbPacote.Text = _festa.Pacote?.pct_nome ?? "Não especificado";
                        cbbTema.Text = _festa.Tema?.tema_nome ?? "Não especificado";
                        cbbEspaco.Text = _festa.Espaco?.espc_nome ?? "Não especificado";
                        cbbStatus.Text = _festa.Status?.stt_status ?? "Não especificado";
                        cbbTipoEvento.Text = _festa.TipoEvento?.tpev_nome ?? "Não especificado";
                        msktxtDataVenda.Text = _festa.fest_dtVenda.ToString(); // ?? DateTime.Now;
                        mskDataFesta.Text = _festa.fest_dtFesta.ToString(); // ?? DateTime.Now;
                        lblValorTotalFesta.Text = _festa.fest_valor?.ToString("F2") ?? "0,00";

                        // Obtém os DETALHES da festa selecionada, incluindo os itens relacionados
                        MostraDetalhesFestaSelecionada(context, festaId);

                        // Obtém os ADICIONAIS da festa selecionada, incluindo os itens relacionados
                        MostraItensFestaSelecionadaEF(context, festaId);
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
        // 2. mostra detalhes da festa selecionada
        private void MostraDetalhesFestaSelecionada(clsFestasContext context, int festa_id)
        {
            // instancia uma nova entidade...
            var detalhesFesta = new repFestasDetalhesEF();
            var detalhesEncontrado = detalhesFesta.GetDetalhesFestaEF(festa_id);

            if (detalhesEncontrado != null)
            {
                // trata horarios
                mskHoraInicio.Text = myDateTime.FormatTimeForDisplay(detalhesEncontrado.detfest_iniciohora);
                mskHoraFim.Text = myDateTime.FormatTimeForDisplay(detalhesEncontrado.detfest_fimhora);
                //
                txtTotalPessoa.Text = detalhesEncontrado.detfest_totalpessoas?.ToString() ?? "0";
                txtTotalAdultos.Text = detalhesEncontrado.detfest_adultos?.ToString() ?? "0";
                txtPessoasAMais.Text = detalhesEncontrado.detfest_pessoasamais?.ToString() ?? "0";
                txtCriancasPagantes.Text = detalhesEncontrado.detfest_criancaspagantes?.ToString() ?? "0";
                txtCriancasNaoPagantes.Text = detalhesEncontrado.detfest_criancasnaopagantes?.ToString() ?? "0";
                txtObservacao.Text = detalhesEncontrado.detfest_observacao ?? "";

                // obter nome contrato
                if (detalhesEncontrado.detfest_ctt_id != null)
                {
                    int idContrato = (int)detalhesEncontrado.detfest_ctt_id;
                    txtContrato.Text = ObterContratoNome(context, idContrato);
                }
            }
            else
            {
                // Limpa os campos se não houver detalhes da festa
                LimpaControlesDetalhesFesta();
            }
        }
        //
        // 2.1. obter nome contrato, passando o idContrato
        private string ObterContratoNome(clsFestasContext context, int IdContrato)
        {
            try
            {
                var contrato = context.Contratos.FirstOrDefault(c => c.ctt_id == IdContrato);
                var contratoNome = contrato?.ctt_nome ?? "Não informado";

                return contratoNome;
            }
            catch (Exception) { }

            return null; // aviso CS8603
        }
        //
        // 2.2.  Limpa os campos de detalhes da festa
        private void LimpaControlesDetalhesFesta()
        {
            mskHoraInicio.Clear();
            mskHoraFim.Clear();
            txtTotalPessoa.Text = "0";
            txtTotalAdultos.Text = "0";
            txtPessoasAMais.Text = "0";
            txtCriancasPagantes.Text = "0";
            txtCriancasNaoPagantes.Text = "0";
            txtObservacao.Clear();
            txtContrato.Text = "PADRAO";
        }
        //
        // 3. mostra itens adicionais da festa selecionada
        private void MostraItensFestaSelecionadaEF(clsFestasContext contexto, int festa_id)
        {
            var adicionaisFesta = repFestasEF.GetItensFestaEF(festa_id);

            // Preencha o DataGridView Itens com os adicionais da festa
            dtgItens.Rows.Clear();

            if (adicionaisFesta != null)
            {
                foreach (var adicional in adicionaisFesta)
                {
                    //sastring itenFestaValor = $"{adicional.ItensFestas?.itensfest_nome} ({adicional.add_valor}) ";

                    dtgItens.Rows.Add(adicional.ItensFestas?.itensfest_nome,
                                      adicional.add_qtde,
                                      adicional.add_valor * adicional.add_qtde);
                }
            }
            SomarValorTotalItens();
        }
        //
        private async Task<clsFestasContratos> ObterContratoId(clsFestasContext contexto, string nomeContrato)
        {
            var contratoId = await contexto.Contratos.FirstOrDefaultAsync(c => c.ctt_nome == nomeContrato);
            if (contratoId == null)
            {
                throw new Exception("Contrato não encontrado.");
            }
            return contratoId;
        }
        //
        private void TravarControles()
        {

        }
        //
        private void CarregarComboBoxesEF()
        {
            if (!myConnMySql.TestarConexao())
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
                SetComboBoxesEF(cbbItemFesta, context.ItensFestas, "itensfest_nome", "itensfest_id");
            }
        }
        //
        private void SetComboBoxesEF<T>(ComboBox cbb, DbSet<T> dbSet, string displayMember, string valueMember) where T : class
        {
            if (!myConnMySql.TestarConexao())
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
        // salvarItens REFAZER
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
        // salvarFestas
        private async Task SalvarFestaEF(int? festaId = null)
        {
            if (!ValidarControles())
                return;

            try
            {
                using (var contexto = new clsFestasContext())
                {
                    // 1. festa - está ok
                    clsFestas festa = await ObterOuCriarFesta(contexto, festaId);
                    // 1.1.- está ok
                    await AtualizarPropriedadesFesta(contexto, festa);

                    // 2. detalhes festa - está ok
                    clsFestasDetalhes detalhesFesta = await ObterOuCriarDetalhesFesta(contexto, festaId);
                    // 2.2. - está ok
                    AtualizarPropriedadesDetalhesFesta(contexto, detalhesFesta);

                    // 3. adicionais festa
                    AtualizarPropriedadesAdicionaisFesta(contexto, festaId!.Value);

                    // Salvar as alterações no banco de dados
                    await contexto.SaveChangesAsync();
                }

                myUtilities.myMessageBox(this, "Festa salva com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Erro ao salvar festa: {ex.Message}\nSalvarFestaEF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void AtualizarPropriedadesAdicionaisFesta(clsFestasContext contexto, int festaId)
        {
            // Limpa os adicionais existentes para evitar duplicações
            var adicionaisExistentes = contexto.Adicionais
                                                .Where(a => a.add_fest_id == festaId)
                                                .ToList();

            foreach (var adicional in adicionaisExistentes)
            {
                contexto.Adicionais.Remove(adicional);
            }
            // Salvar as alterações após a remoção dos adicionais existentes
            //contexto.SaveChanges();

            // Itera sobre as linhas do DataGridView e adiciona novos itens adicionais
            foreach (DataGridViewRow row in dtgItens.Rows)
            {
                if (row.IsNewRow) continue; // Ignora a linha de nova entrada

                var itemNome = row.Cells[ColDescricao].Value?.ToString();
                var itemQtde = Convert.ToInt32(row.Cells[ColQtde].Value);
                var itemValor = Convert.ToDouble(row.Cells[ColValor].Value);

                // Obtem o ID do item com base no nome do item (assumindo que há uma tabela de itens)
                var item = contexto.ItensFestas.FirstOrDefault(i => i.itensfest_nome == itemNome);

                if (item != null)
                {
                    var adicionalFesta = new clsFestasAdicionais
                    {
                        add_fest_id = festaId,
                        add_itensfest_id = item.itensfest_id,
                        add_qtde = itemQtde,
                        add_valor = itemValor
                    };

                    contexto.Adicionais.Add(adicionalFesta);
                }
            }
        }
        //
        private async Task<clsFestasAdicionais> ObterOuCriarAdicionaisFestaSEMUSO(clsFestasContext contexto, int? festaId)
        {
            clsFestasAdicionais adicionaisFesta;

            if (festaId.HasValue)
            {
                // busca adicionais da festa
                adicionaisFesta = await contexto.Adicionais
                                            .FirstOrDefaultAsync(a => a.add_fest_id == festaId); // aviso CS8600

                if (adicionaisFesta == null)
                {
                    // Se não houver adicionais, cria um novo e associa o ID da festa
                    adicionaisFesta = new clsFestasAdicionais { add_fest_id = festaId.Value};
                    contexto.Adicionais.Add(adicionaisFesta);
                }
            }
            else
            {
                adicionaisFesta = new clsFestasAdicionais();
                contexto.Adicionais.Add(adicionaisFesta);
            }
            return adicionaisFesta;
        }
        //
        private async Task<clsFestas> ObterOuCriarFesta(clsFestasContext contexto, int? festaId)
        {
            clsFestas festa;

            if (festaId.HasValue)
            {
                festa = await contexto.Festas.FindAsync(festaId.Value);
                if (festa == null)
                {
                    throw new Exception("Festa não encontrada.");
                }
            }
            else
            {
                festa = new clsFestas();
                contexto.Festas.Add(festa);
            }

            return festa;
        }
        //
        private async Task AtualizarPropriedadesFesta(clsFestasContext contexto, clsFestas festa)
        {
            var cliente = await ObterCliente(contexto, txtClienteNome.Text);
            festa.fest_cli_id = cliente.cli_id;

            var usuario = await ObterUsuario(contexto, txtUserNome.Text);
            festa.fest_user_id = usuario.user_id;

            festa.fest_tpEv_id = (int?)cbbTipoEvento.SelectedValue;
            festa.fest_espc_id = (int?)cbbEspaco.SelectedValue;
            festa.fest_pct_id = (int?)cbbPacote.SelectedValue;
            festa.fest_tema_id = (int?)cbbTema.SelectedValue;
            festa.fest_stt_id = (int?)cbbStatus.SelectedValue;
            festa.fest_valor = !string.IsNullOrWhiteSpace(lblValorTotalFesta.Text) ? (double?)Convert.ToDecimal(lblValorTotalFesta.Text) : 0;
            festa.fest_dtVenda = DateTime.ParseExact(msktxtDataVenda.Text, "ddMMyyyy", null);
            festa.fest_dtFesta = DateTime.ParseExact(mskDataFesta.Text, "ddMMyyyy", null);
        }
        //
        private async Task<clsFestasDetalhes> ObterOuCriarDetalhesFesta(clsFestasContext contexto, int? festaId)
        {
            clsFestasDetalhes detalhesFesta;

            if (festaId.HasValue)
            {
                // Busca os detalhes da festa pelo campo detfest_fest_id
                detalhesFesta = await contexto.Detalhes
                    .FirstOrDefaultAsync(d => d.detfest_fest_id == festaId.Value);

                if (detalhesFesta == null)
                {
                    // Se não houver detalhes, cria um novo e associa o ID da festa
                    detalhesFesta = new clsFestasDetalhes { detfest_fest_id = festaId.Value };
                    contexto.Detalhes.Add(detalhesFesta);
                }
            }
            else
            {
                // aasocia o ID da festa ao detalhe localizado
                detalhesFesta = new clsFestasDetalhes();
                contexto.Detalhes.Add(detalhesFesta);
            }

            return detalhesFesta;
        }
        //
        private void AtualizarPropriedadesDetalhesFesta(clsFestasContext contexto, clsFestasDetalhes detalhesFesta)
        {
            detalhesFesta.detfest_iniciohora = !string.IsNullOrWhiteSpace(mskHoraInicio.Text) ? TimeSpan.ParseExact(mskHoraInicio.Text, "hhmm", CultureInfo.InvariantCulture) : (TimeSpan?)null;
            detalhesFesta.detfest_fimhora = !string.IsNullOrWhiteSpace(mskHoraFim.Text) ? TimeSpan.ParseExact(mskHoraFim.Text, "hhmm", CultureInfo.InvariantCulture) : (TimeSpan?)null;

            detalhesFesta.detfest_totalpessoas = Convert.ToInt32(txtTotalPessoa.Text);
            detalhesFesta.detfest_adultos = Convert.ToInt32(txtTotalAdultos.Text);
            detalhesFesta.detfest_criancaspagantes = Convert.ToInt32(txtCriancasPagantes.Text);
            detalhesFesta.detfest_criancasnaopagantes = Convert.ToInt32(txtCriancasNaoPagantes.Text);    
            detalhesFesta.detfest_pessoasamais = Convert.ToInt32(txtPessoasAMais.Text);
            detalhesFesta.detfest_observacao = txtObservacao.Text;
            // obter id do contrato pelo nome
            var contrato = contexto.Contratos.FirstOrDefault(c => c.ctt_nome == txtContrato.Text);
            detalhesFesta.detfest_ctt_id = contrato?.ctt_id;
        }
        //
        private async Task<clsClientes> ObterCliente(clsFestasContext contexto, string nomeCliente)
        {
            var cliente = await contexto.Clientes.FirstOrDefaultAsync(c => c.cli_nome == nomeCliente);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado.");
            }
            return cliente;
        }
        //
        private async Task<clsUsuarios> ObterUsuario(clsFestasContext contexto, string nomeUsuario)
        {
            var usuario = await contexto.Usuarios.FirstOrDefaultAsync(u => u.user_nome == nomeUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            return usuario;
        }
        //
        private async Task ExcluirFestaEF(int? festaId)
        {
            if (festaId <= 0 || !festaId.HasValue)
            {
                myUtilities.myMessageBox(this, $"Festa não encontrada! {festaId.ToString()}", "Excluir Festa");
                return;
            }

            try
            {
                // Exibe a mensagem de confirmação usando MessageBox.Show
                var message = $"""
                        Deseja Excluir a Festa de?
                        {txtClienteNome.Text}

                        Esta ação não poderá ser desfeita!
                        """;
                var result = myUtilities.myMessageBox(this, message, "Excluir Festa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var contexto = new clsFestasContext())
                    {
                        // Buscar a festa existente no banco de dados
                        clsFestas festa = await contexto.Festas.FindAsync(festaId);
                        if (festa == null)
                        {
                            throw new Exception("Festa não encontrada.");
                        }

                        // Remover a festa do contexto
                        contexto.Festas.Remove(festa);

                        // Salvar as alterações no banco de dados
                        await contexto.SaveChangesAsync();
                    }

                    //myUtilities.myMessageBox(this, "Festa excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Erro ao excluir festa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void ConfigurarAutoCompletarTxt()
        {
            // Clientes
            txtClienteNome.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtClienteNome.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtClienteNome.AutoCompleteCustomSource = CarregarNomesClientes();
            // Usuarios
            txtUserNome.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUserNome.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtUserNome.AutoCompleteCustomSource = CarregarNomesUsuarios();
            //// itens festas
            //cbbItemFesta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbbItemFesta.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cbbItemFesta.AutoCompleteCustomSource = CarregarItensFesta();
            // Contratos
            txtContrato.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtContrato.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtContrato.AutoCompleteCustomSource = CarregarNomesContratos();
        }
        // itens festas
        private AutoCompleteStringCollection CarregarItensFesta()
        {
            AutoCompleteStringCollection itensFesta = new AutoCompleteStringCollection();

            using (var context = new clsFestasContext())
            {
                var itens = context.ItensFestas.Select(i => i.itensfest_nome).ToList();
                itensFesta.AddRange(itens.ToArray());
            }
            return itensFesta;
        }
        // contratos
        private AutoCompleteStringCollection CarregarNomesContratos()
        {
            AutoCompleteStringCollection nomesContratos = new AutoCompleteStringCollection();

            using (var context = new clsFestasContext())
            {
                var contratos = context.Contratos.Select(ct => ct.ctt_nome).ToList();
                nomesContratos.AddRange(contratos.ToArray());
            }
            return nomesContratos;
        }
        // usuarios
        private AutoCompleteStringCollection CarregarNomesUsuarios()
        {
            AutoCompleteStringCollection nomesUsuarios = new AutoCompleteStringCollection();

            using (var context = new clsFestasContext())
            {
                var usuarios = context.Usuarios.Select(u => u.user_nome).ToList();
                nomesUsuarios.AddRange(usuarios.ToArray());
            }
            return nomesUsuarios;
        }
        // clientes
        private AutoCompleteStringCollection CarregarNomesClientes()
        {
            AutoCompleteStringCollection nomesClientes = new AutoCompleteStringCollection();

            using (var context = new clsFestasContext())
            {
                var clientes = context.Clientes.Select(c => c.cli_nome).ToList();
                nomesClientes.AddRange(clientes.ToArray());
            }
            return nomesClientes;
        }
        //
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
        private bool ValidarControles()
        {
            // Validação de data de venda
            if (!myDateTime.ValidDate(msktxtDataVenda.Text))
            {
                myUtilities.myMessageBox(this, "Data de venda inválida. Formato esperado: ddMMyyyy", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                msktxtDataVenda.Focus();
                return false;
            }
                //if (!DateTime.TryParseExact(msktxtDataVenda.Text, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out _))
                //{
                //    myUtilities.myMessageBox(this, "Data de venda inválida. Formato esperado: ddMMyyyy", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}

            // Validação de usuário
            if (string.IsNullOrWhiteSpace(txtUserNome.Text))
            {
                myUtilities.myMessageBox(this, "Usuário inválido. Informe um Usuário!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserNome.Focus();
                return false;
            }

            // Validação de cliente
            if (string.IsNullOrWhiteSpace(txtClienteNome.Text))
            {
                myUtilities.myMessageBox(this, "Cliente inválido. Informe um Cliente!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClienteNome.Focus();
                return false;
            }

            // Validação de data de festa
            if (!myDateTime.ValidDate(mskDataFesta.Text))
            {
                myUtilities.myMessageBox(this, "Data da festa inválida. informe uma data válida!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDataFesta.Focus();
                return false;
            }
            //if (!DateTime.TryParseExact(mskDataFesta.Text, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out _))
            //{
            //    myUtilities.myMessageBox(this, "Data da festa inválida. Formato esperado: ddMMyyyy", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            // Validação dos ComboBoxes
            // tipo evento
            if (cbbTipoEvento.SelectedValue == null)
            {
                myUtilities.myMessageBox(this, "Tipo de Evento inválido. Selecione um Evento!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbTipoEvento.Focus();
                return false;
            }
            // espaço
            if (cbbEspaco.SelectedValue == null)
            {
                myUtilities.myMessageBox(this, "Espaço inválido. Selecione um Espaço!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbEspaco.Focus();
                return false;
            }
            // tema
            if (cbbTema.SelectedValue == null)
            {
                myUtilities.myMessageBox(this, "Tema inválido. Selecione um Tema!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbTema.Focus();
                return false;
            }
            // pacotes
            if (cbbPacote.SelectedValue == null)
            {
                myUtilities.myMessageBox(this, "Pacote inválido. Selecione um Pacote!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbPacote.Focus();
                return false;
            }
            //******************************************************************
            // Validação de hora inicio
            if (!myDateTime.ValidTime(mskHoraInicio.Text))
            {
                myUtilities.myMessageBox(this, "Hora Início da festa inválida. Formato esperado: hh:mm", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskHoraInicio.Focus();
                return false;
            }
            // Validação de hora fim
            if (!myDateTime.ValidTime(mskHoraFim.Text))
            {
                myUtilities.myMessageBox(this, "Hora Final da festa inválida. Formato esperado: hh:mm", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskHoraFim.Focus();
                return false;
            }

            // status
            if (cbbStatus.SelectedValue == null)
            {
                myUtilities.myMessageBox(this, "Status inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbStatus.Focus();
                return false;
            }

            // Validação de contrato
            if (string.IsNullOrWhiteSpace(txtContrato.Text) || txtContrato.Text == string.Empty)
            {
                myUtilities.myMessageBox(this, "Contrato inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrato.Focus();
                return false;
            }

            // Validação do valor da festa
            //if (string.IsNullOrWhiteSpace(lblValorFesta.Text) || !decimal.TryParse(lblValorFesta.Text, out _))
            //{
            //    myUtilities.myMessageBox(this, "Valor da festa inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            // se toda validação passar retorna true
            return true;
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
                        SomarValorTotalItens();
                        cbbItemFesta.Focus();
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
            if (string.IsNullOrWhiteSpace(cbbItemFesta.Text) ||
                string.IsNullOrWhiteSpace(txtItemQtde.Text) ||
                string.IsNullOrWhiteSpace(txtItemValor.Text))
            {
                myUtilities.myMessageBox(this, "Todos os campos devem ser preenchidos.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbItemFesta.Focus();
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
            //dtgItens.Rows.Add($"{cbbItemFesta.Text} ({valor.ToString("N2")})", quantidade, (valor * quantidade));
            dtgItens.Rows.Add(cbbItemFesta.Text, quantidade, (valor * quantidade));
            // soma total de itens
            SomarValorTotalItens();
            // Limpar os campos de entrada
            cbbItemFesta.SelectedItem = -1;
            txtItemQtde.Clear();
            txtItemValor.Clear();
            cbbItemFesta.Focus();
        }
        //
        private void DtgItens_SelectionChanged(object? sender, EventArgs e)
        {
            //txtValorTotalIntens.Text = SomarValorTotalItens().ToString("C2");
        }
        // valor total de itens
        private void SomarValorTotalItens()
        {
            double soma = 0;
            foreach (DataGridViewRow row in dtgItens.Rows)
            {
                double valor = row.Cells[ColValor].Value != null ? Convert.ToDouble(row.Cells[ColValor].Value) : 0.0;
                //double quantidade = row.Cells[ColQtde].Value != null ? Convert.ToDouble(row.Cells[ColValor].Value) : 0;
                soma += valor;
            }
            txtValorTotalIntens.Text = soma.ToString("C2");
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
        //
        private async Task SalvarFestaEFSEMUSO(int? festaId = null)
        {
            try
            {
                using (var contexto = new clsFestasContext())
                {
                    clsFestas festa;

                    if (festaId.HasValue)
                    {
                        // Buscar a festa existente no banco de dados
                        festa = await contexto.Festas.FindAsync(festaId.Value); // msn CS8600
                        if (festa == null)
                        {
                            throw new Exception("Festa não encontrada.");
                        }
                    }
                    else
                    {
                        // Criar uma nova instância de clsFestas se o ID não for fornecido
                        festa = new clsFestas();
                        contexto.Festas.Add(festa);
                    }

                    // Capturar o ID do CLIENTE com base no nome
                    var cliente = contexto.Clientes.FirstOrDefault(c => c.cli_nome == txtClienteNome.Text);
                    if (cliente != null)
                    {
                        festa.fest_cli_id = cliente.cli_id;
                    }
                    else
                    {
                        throw new Exception("Cliente não encontrado.");
                    }

                    // Capturar o ID do USUARIO com base no nome
                    var usuraio = contexto.Usuarios.FirstOrDefault(u => u.user_nome == txtUserNome.Text);
                    if (usuraio != null)
                    {
                        festa.fest_user_id = usuraio.user_id;
                    }
                    else
                    {
                        throw new Exception("Usuário não encontrado.");
                    }

                    // Atualizar as propriedades da festa com os dados do formulário
                    festa.fest_tpEv_id = (int?)cbbTipoEvento.SelectedValue; // Capturar o ID do tipo de evento do ComboBox
                    festa.fest_espc_id = (int?)cbbEspaco.SelectedValue; // Capturar o ID do espaço do ComboBox
                    festa.fest_pct_id = (int?)cbbPacote.SelectedValue; // Capturar o ID do pacote do ComboBox
                    festa.fest_tema_id = (int?)cbbTema.SelectedValue; // Capturar o ID do tema do ComboBox
                    festa.fest_stt_id = (int?)cbbStatus.SelectedValue; // Capturar o ID do status do ComboBox
                    festa.fest_valor = lblValorTotalFesta.Text != "" ? (double?)Convert.ToDecimal(lblValorTotalFesta.Text) : 0;
                    festa.fest_dtVenda = DateTime.ParseExact(msktxtDataVenda.Text, "ddMMyyyy", null);
                    festa.fest_dtFesta = DateTime.ParseExact(mskDataFesta.Text, "ddMMyyyy", null);

                    // Buscar detalhesfesta existente no banco de dados
                    clsFestasDetalhes detalhesFesta = await contexto.Detalhes.FindAsync(festaId!.Value) ?? new clsFestasDetalhes(); // msn CS8600
                    if (detalhesFesta.detfest_id == 0)
                    {
                        // Criar uma nova instância de clsFestas se o ID não for fornecido
                        contexto.Detalhes.Add(detalhesFesta);
                    }

                    detalhesFesta.detfest_iniciohora = TimeSpan.ParseExact(mskHoraInicio.Text, "hh\\:mm", null);
                    detalhesFesta.detfest_fimhora = TimeSpan.ParseExact(mskHoraFim.Text, "hh\\:mm", null);
                    detalhesFesta.detfest_totalpessoas = Convert.ToInt32(txtTotalPessoa.Text);
                    detalhesFesta.detfest_adultos = Convert.ToInt32(txtTotalAdultos.Text);
                    detalhesFesta.detfest_criancaspagantes = Convert.ToInt32(txtCriancasPagantes.Text);
                    detalhesFesta.detfest_criancasnaopagantes = Convert.ToInt32(txtCriancasNaoPagantes.Text);
                    detalhesFesta.detfest_pessoasamais = Convert.ToInt32(txtPessoasAMais.Text);
                    detalhesFesta.detfest_observacao = txtObservacao.Text;

                    // Capturar o ID do CONTRATO com base no nome
                    var contrato = contexto.Contratos.FirstOrDefault(c => c.ctt_nome == txtContrato.Text);
                    detalhesFesta.detfest_ctt_id = contrato?.ctt_id; // msm CS8602

                    // Salvar as alterações no banco de dados
                    await contexto.SaveChangesAsync();
                }
                myUtilities.myMessageBox(this, "Festa salva com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Erro ao salvar festa: {ex.Message}\nSalvarFestaEF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // end SalvarFestaEF
        private async Task SalvarFesta()
        {
            try
            {
                using (var contexto = new clsFestasContext())
                {
                    // Criar uma nova instância de clsFestas com os dados do formulário
                    clsFestas festa = new clsFestas();

                    // Capturar o ID do cliente com base no nome
                    var cliente = contexto.Clientes.FirstOrDefault(c => c.cli_nome == txtClienteNome.Text);
                    if (cliente != null)
                    {
                        festa.fest_cli_id = cliente.cli_id;
                    }
                    else
                    {
                        throw new Exception("Cliente não encontrado.");
                    }

                    festa.fest_user_id = Convert.ToInt32(txtUserNome.Text); //cbbUser.SelectedValue, // Capturar o ID do usuário do ComboBox

                    festa.fest_pct_id = (int?)cbbPacote.SelectedValue; // Capturar o ID do pacote do ComboBox
                    festa.fest_tema_id = (int?)cbbTema.SelectedValue; // Capturar o ID do tema do ComboBox
                    festa.fest_espc_id = (int?)cbbEspaco.SelectedValue; // Capturar o ID do espaço do ComboBox
                    festa.fest_stt_id = (int?)cbbStatus.SelectedValue; // Capturar o ID do status do ComboBox
                    festa.fest_tpEv_id = (int?)cbbTipoEvento.SelectedValue; // Capturar o ID do tipo de evento do ComboBox
                    festa.fest_valor = lblValorTotalFesta.Text != "" ? (double?)Convert.ToDecimal(lblValorTotalFesta.Text) : 0;

                    // Tratar a conversão das datas
                    if (DateTime.TryParseExact(msktxtDataVenda.Text, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataVenda))
                    {
                        festa.fest_dtVenda = dataVenda;
                    }
                    else
                    {
                        throw new Exception("Data de venda inválida. Formato esperado: ddMMyyyy");
                    }

                    if (DateTime.TryParseExact(mskDataFesta.Text, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataFesta))
                    {
                        festa.fest_dtFesta = dataFesta;
                    }
                    else
                    {
                        throw new Exception("Data da festa inválida. Formato esperado: ddMMyyyy");
                    }

                    // Adicionar a festa ao contexto e salvar no banco de dados
                    contexto.Festas.Add(festa);
                    await contexto.SaveChangesAsync();
                }

                myUtilities.myMessageBox(this, "Festa salva com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Erro ao salvar festa: {ex.Message}\nSalvarFesta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
        private void CarregarComboBoxes()
        {
            // Primeira tentativa de carregar os ComboBoxes
            SetComboBoxes(cbbEspaco, "tblfestasespacos", "espc_id", "espc_nome");
            // Verifica o status da conexão após a primeira tentativa
            if (!myConnMySql.TestarConexao()) return;

            SetComboBoxes(cbbPacote, "tblfestaspacotes", "pct_id", "pct_nome");
            SetComboBoxes(cbbStatus, "tblfestasstatus", "stt_id", "stt_status");
            SetComboBoxes(cbbTema, "tblfestastemas", "tema_id", "tema_nome");
            SetComboBoxes(cbbTipoEvento, "tblfestastipoevento", "tpev_id", "tpev_nome");
        }
        private void cbb_GotFocus(object sender, EventArgs e)
        {
            ComboBox? cbb = sender as ComboBox;
            if (cbb != null)
            {
                cbb.SelectionLength = 0; // Desativa a seleção de texto
            }
        }
        private void SetComboBoxes(ComboBox cbb, string tabela, string campoId, string campoNome)
        {
            if (!myConnMySql.TestarConexao())
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
            if (!myConnMySql.TestarConexao())
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
                    SomarValorTotalItens();
                }
            }
            else
            {
                myUtilities.myMessageBox(this, "Nenhuma linha está selecionada.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        //
    } // end class FormFestasCRUD
} // end namespace FestasApp.Views.Festas
