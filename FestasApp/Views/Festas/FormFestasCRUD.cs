//-------------------------------------------------------------------
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
//-------------------------------------------------------------------
//
namespace FestasApp.Views.Festas
{
    public partial class FormFestasCRUD : FormBaseCRUD
    {
        /// <summary>
        /// Declarar instâncias das classe para este form
        /// </summary>
        private clsFestas? _festa = new();
        private OperacaoCRUD operacao;
        /// <summary>
        /// 
        /// </summary>
        public clsParam FestaIdParam = new(); // para retornar para o datagriFesta
        private clsParam param = new(); // param para tratar as tabelas auxiliares

        //
        /// <summary>
        /// Construtor padrão, recebe o id da festa e a operação
        /// </summary>
        /// <param name="_festaId"></param>
        /// <param name="_operacao"></param>
        public FormFestasCRUD(clsParam _festaId, OperacaoCRUD _operacao)
        {
            InitializeComponent();
            this.FestaIdParam.Id = _festaId.Id;
            this.operacao = _operacao;
            //
            SuspendLayout();
                ConfigurarFormBaseCrud("F e s t a s", operacao);
                SetControls();
                AddEventHandlers();
            ResumeLayout();
        }
        //
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFestasCRUD_Load(object sender, EventArgs e)
        {
            SuspendLayout();
                this.BeginInvoke(new Action(() => txtDataVenda.Focus())); //
                txtDataVenda.SelectionStart = 0; // posiciona o cursor no inicio da data
                
                SetOperacao();
                MostraDadosFestaSelecionadaEF();
            ResumeLayout();
        }
        /// <summary>
        /// Adiciona eventosHandlers aos controles
        /// </summary>
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
            this.dtgItens.SelectionChanged += DtgItens_SelectionChanged;
            this.dtgItens.CellContentClick += DtgItens_CellContentClick;
            this.txtItemQtde.Validating += TxtItemQtde_Validating;
            this.txtDescontosFesta.Validating += TxtDescontosFesta_Validating;
        }
        //
        /// <summary>
        /// Configura o formulário com base na operação
        /// </summary>
        private void SetOperacao()
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
        /// <summary>
        /// Configura os controles deste formulário
        /// </summary>
        private void SetControls()
        {
            // definir os maxLenght dos controles

            // itens festas
            cbbItemFesta.Height = 18;
            txtItemQtde.Height = 18;
            txtItemValor.Height = 18;
            //
            lblValorTotalIntens.TextAlign = ContentAlignment.MiddleRight;
            lblValorTotalIntens.TabStop = false;
            //
            ConfigurarDtgItens();
            //
            ConfigurarAutoCompletarTxt();
        }
        /// <summary>
        /// Limpa os controles
        /// </summary>
        private void LimparControles()
        {
            // limpas os controles
            txtDataVenda.Text = DateTime.Now.ToShortDateString();
            txtDataFesta.Clear();

            LimpaControlesDetalhesFesta();
            
            LimparItensFesta();

            // limpa valores da festa
            lblValorPacote.Text = "0,00";
            lblValorAdicionais.Text = "0,00";
            txtDescontosFesta.Text = "0,00";
            lblValorTotalFesta.Text = "0,00";
        }
        /// <summary>
        /// Limpar Itens da Festa
        /// </summary>
        private void LimparItensFesta()
        {
            // limpa adicionais da festa
            txtItemQtde.Text = "0";
            txtItemValor.Text = "0,00";
            dtgItens.Rows.Clear();
            lblValorTotalIntens.Text = "0,00";
            cbbItemFesta.SelectedItem = -1;
        }
        //
        /// <summary>
        /// Tira a seleção dos comboboxes
        /// </summary>
        private void UnselectComboBoxes()
        {
            cbbVendedor.SelectedItem = -1; // mostrar usuario ativo
            //cbbVendedor.SelectionLength = 0; // desmarca seleção
            cbbClientes.SelectedItem = -1;
            cbbPacotes.SelectedItem = -1;
            cbbTemas.SelectedItem = -1;
            cbbEspacos.SelectedItem = -1;
            cbbStatus.SelectedItem = -1;
            cbbTiposEvento.SelectedItem = -1;
            cbbContratos.SelectedItem = -1;
            //
            cbbItemFesta.SelectedItem = -1;
        }
        /// <summary>
        /// Btn Salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TstbtnSalvar_Click(object? sender, EventArgs e)
        {
            // Testa a operacao e configura os controles...
            switch (operacao)
            {
                case OperacaoCRUD.NOVO:
                    await SalvarFestaEF();
                    break;
                case OperacaoCRUD.EDITAR:
                    await SalvarFestaEF(FestaIdParam.Id);
                    break;
                case OperacaoCRUD.EXCLUIR:
                    //await ExcluirFestaEF(festaId);
                    break;
            }
        }
        /// <summary>
        /// 1. Mostra no form, dados de festa selecionada
        /// </summary>
        private void MostraDadosFestaSelecionadaEF()
        {
            // editar, consultar, excluir
            if (FestaIdParam.IsValid() && operacao != OperacaoCRUD.NOVO)
            {
                using (clsFestasContext context = new())
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
                        .FirstOrDefault(f => f.fest_id == FestaIdParam.Id);

                    if (_festa != null)
                    {
                        // Preencha os controles do formulário com os dados da festa
                        cbbVendedor.SelectedValue = _festa.fest_user_id;
                        cbbClientes.SelectedValue = _festa.fest_cli_id;
                        cbbTiposEvento.SelectedValue = _festa.fest_tpEv_id;
                        cbbPacotes.SelectedValue = _festa.fest_pct_id;
                        cbbEspacos.SelectedValue = _festa.fest_espc_id;
                        cbbTemas.SelectedValue = _festa.fest_tema_id;
                        cbbStatus.SelectedValue = _festa.fest_stt_id;

                        txtDataVenda.Text = _festa.fest_dtVenda?.ToShortDateString();
                        txtDataFesta.Text = _festa.fest_dtFesta?.ToShortDateString();
                        lblValorTotalFesta.Text = _festa.fest_valor?.ToString("N2") ?? "0,00";

                        // 1.1. Obtém os DETALHES da festa selecionada, incluindo os itens relacionados
                        MostraDetalhesFestaSelecionada(); // utiliza id da festa atual

                        // 1.2. Obtém os ADICIONAIS da festa selecionada, incluindo os itens relacionados
                        MostraItensFestaSelecionadaEF(); // utiliza id da festa atual
                    }
                    else
                    {
                        MessageBox.Show("Festa não encontrada.\nCarregarDadosFestaEF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 1.1. Mostra detalhes da festa selecionada
        /// </summary>
        private void MostraDetalhesFestaSelecionada()
        {
            // declara uma nova instancia, não é estatica
            repDetalhesEF detalhesFesta = new();
            // busca detalhes da festa com idAtual, retorna um objeto
            var detalhesEncontrado = detalhesFesta.GetDetalhesFestaEF(_festa!.fest_id);

            if (detalhesEncontrado != null)
            {
                // trata horarios
                txtHoraInicio.Text = myDateTime.FormatTimeForDisplay(detalhesEncontrado.detfest_iniciohora, @"hh\:mm");
                txtHoraFim.Text = myDateTime.FormatTimeForDisplay(detalhesEncontrado.detfest_fimhora, @"hh\:mm");
                //
                txtTotalPessoa.Text = detalhesEncontrado.detfest_totalpessoas?.ToString() ?? "0";
                txtTotalAdultos.Text = detalhesEncontrado.detfest_adultos?.ToString() ?? "0";
                txtPessoasAMais.Text = detalhesEncontrado.detfest_pessoasamais?.ToString() ?? "0";
                txtCriancasPagantes.Text = detalhesEncontrado.detfest_criancaspagantes?.ToString() ?? "0";
                txtCriancasNaoPagantes.Text = detalhesEncontrado.detfest_criancasnaopagantes?.ToString() ?? "0";
                txtObservacao.Text = detalhesEncontrado.detfest_observacao ?? "";

                cbbContratos.SelectedValue = detalhesEncontrado.detfest_ctt_id ?? 1; // selecionar o "PADRAO"
            }
            else
            {
                // 1.1.1. Limpa os campos se não houver detalhes da festa
                LimpaControlesDetalhesFesta();
            }
        }
        /// <summary>
        /// 1.1.1.  Limpa os controles de detalhes da festa.
        /// </summary>
        private void LimpaControlesDetalhesFesta()
        {
            txtHoraInicio.Clear();
            txtHoraFim.Clear();
            txtTotalPessoa.Text = "0";
            txtTotalAdultos.Text = "0";
            txtPessoasAMais.Text = "0";
            txtCriancasPagantes.Text = "0";
            txtCriancasNaoPagantes.Text = "0";
            txtObservacao.Clear();
        }
        /// <summary>
        /// 1.2. Mostra itens adicionais da festa selecionada
        /// </summary>
        private void MostraItensFestaSelecionadaEF()
        {
            // busca detalhes da itensFesta com idAtual, retorna um objeto
            var adicionaisFesta = repAdicionaisEF.GetItensFestaEF(_festa!.fest_id);

            // Preencha o DataGridView Itens com os adicionais da festa
            if (adicionaisFesta != null)
            {
                dtgItens.Rows.Clear();

                foreach (var adicional in adicionaisFesta)
                {
                    // ajustar aqui para mostrar valores dos itens
                    dtgItens.Rows.Add(adicional.add_itensfest_id,
                                        adicional.ItensFestas?.itensfest_nome,
                                        adicional.add_qtde,
                                        adicional.add_valor); // * adicional.add_qtde);
                }
            }
            SomarValorTotalItens();
        }
        /// <summary>
        /// Travar controles só para exibição
        /// </summary>
        private void TravarControles()
        {
            // fatorar
        }
        /// <summary>
        /// Carregar comboboxes com valores das tabelas
        /// </summary>
        private void CarregarComboBoxesEF()
        {
            if (!myConnMySql.TestarConexao())
            {
                FormMenuMain.ShowMyMessageBox("Não foi possível carregar os dados, sem conexão com o banco de dados.\nEm: SetComboBoxesEF", "Falha");
                return;
            }

            using (clsFestasContext context = new())
            {
                SetComboBoxesEF(cbbVendedor, context.Usuarios.OrderBy(u => u.user_nome).ToList(), "user_nome", "user_id");
                SetComboBoxesEF(cbbClientes, context.Clientes.OrderBy(c => c.cli_nome).ToList(), "cli_nome", "cli_id");
                SetComboBoxesEF(cbbEspacos, context.Espacos.OrderBy(e => e.espc_nome).ToList(), "espc_nome", "espc_id");
                SetComboBoxesEF(cbbPacotes, context.Pacotes.OrderBy(p => p.pct_nome).ToList(), "pct_nome", "pct_id");
                SetComboBoxesEF(cbbStatus, context.Status.OrderBy(s => s.stt_status).ToList(), "stt_status", "stt_id");
                SetComboBoxesEF(cbbTemas, context.Temas.OrderBy(t => t.tema_nome).ToList(), "tema_nome", "tema_id");
                SetComboBoxesEF(cbbTiposEvento, context.TipoEvento.OrderBy(t => t.tpev_nome).ToList(), "tpev_nome", "tpev_id");
                SetComboBoxesEF(cbbItemFesta, context.ItensFestas.OrderBy(i => i.itensfest_nome).ToList(), "itensfest_nome", "itensfest_id");
                SetComboBoxesEF(cbbContratos, context.Contratos.OrderBy(c => c.ctt_nome).ToList(), "ctt_nome", "ctt_id");
            }

            // Adiciona eventos as comboboxes
            cbbItemFesta.SelectedIndexChanged += CbbItemFesta_SelectedIndexChanged;
            cbbPacotes.SelectedIndexChanged += CbbPacote_SelectedIndexChanged;
        }
        /// <summary>
        /// Método auxiliar ao preenchimento das comboboxes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cbb"></param>
        /// <param name="dataList"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        private void SetComboBoxesEF<T>(ComboBox cbb, List<T> dataList, string displayMember, string valueMember) where T : class
        {
            try
            {
                cbb.DataSource = null;  // Limpa o DataSource
                cbb.Items.Clear();      // Limpa os itens manualmente
                //
                cbb.DataSource = dataList;
                cbb.DisplayMember = displayMember;
                cbb.ValueMember = valueMember;
                cbb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                FormMenuMain.ShowMyMessageBox($"Erro ao carregar dados: {ex.Message}\nSetComboBoxesEF {cbb.Name}", "Falha");
            }
        }
        //
        /// <summary>
        /// Método captura valor do pacote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CbbPacote_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                if (cbbPacotes.SelectedValue is int selectedId)
                {
                    using (clsFestasContext context = new())
                    {
                        var item = await context.Pacotes
                                                    .Where(p => p.pct_id == selectedId)
                                                    .Select(p => new { p.pct_valor })
                                                    .FirstOrDefaultAsync();
                        if (item != null)
                        {
                            lblValorPacote.Text = ((decimal)item.pct_valor!).ToString("N2");
                            SomarValorTotalFesta();
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        //
        /// <summary>
        /// cbbItensFestas captura valor do item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CbbItemFesta_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbItemFesta.SelectedValue is int selectedId)
            {
                using (clsFestasContext context = new clsFestasContext())
                {
                    var item = await context.ItensFestas
                                            .Where(i => i.itensfest_id == selectedId)
                                            .Select(i => new { i.itensfest_valor })
                                            .FirstOrDefaultAsync();

                    if (item != null)
                    {
                        txtItemValor.Text = ((decimal)item.itensfest_valor!).ToString("N2"); // Formata como moeda
                        txtItemQtde.Text = "1";
                        txtItemQtde.Focus();
                    }
                }
            }
        }
        //
        /// <summary>
        /// Método para salvarFestas
        /// </summary>
        /// <param name="festaId"></param>
        /// <returns></returns>
        private async Task SalvarFestaEF(int? festaId = null)
        {
            // valida os controles do form
            bool isValid = await ValidarControles();
            if (!isValid)
                return;

            try
            {
                using (clsFestasContext context = new())
                {
                    // 1. instância de festa
                    clsFestas festa = await ObterOuCriarFesta(context, festaId);
                    // 1.1.- atualiza as propriedades da festa encontrada(para editar) ou nova
                    AtualizarPropriedadesFesta(festa);

                    // Salva a festa em <tblfestas> no banco de dados para garantir que o fest_id seja gerado
                    await context.SaveChangesAsync();

                    // 2. instância de detalhes festa - já com id da festa nova ou editada
                    clsFestasDetalhes detalhesFesta = await ObterOuCriarDetalhesFesta(context, festa.fest_id); // utilizar o id da festa (nova ou editada)
                    // 2.1. - atualiza as propriedades dos detalhesfesta encontrada(para editar) ou nova
                    AtualizarPropriedadesDetalhesFesta(detalhesFesta);

                    // 3. atualiza as propriedades dos itensAdicionaisFesta encontrada(para editar) ou nova
                    AtualizarPropriedadesAdicionaisFesta(context, festa.fest_id); // utilizar o id da festa (nova ou editada)

                    // 4. Salvar as alterações no banco de dados
                    await context.SaveChangesAsync();

                    FestaIdParam.Id = festa.fest_id; // para retornar para o dtgFesta
                }
                await myUtilities.myMessageBox(this, "Festa salva com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao salvar festa: {ex.Message}\nSalvarFestaEF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        /// <summary>
        /// 1. verifica se festa existe ou é uma nova festa
        /// </summary>
        /// <param name="context"></param>
        /// <param name="festaId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<clsFestas> ObterOuCriarFesta(clsFestasContext context, int? festaId)
        {
            // declara uma instancia festa vazia
            clsFestas? festa;

            // editar, consultar, excluir
            if (festaId.HasValue && operacao != OperacaoCRUD.NOVO)
            {
                // se festaId passado é válido, tenta localizar festa
                festa = await context.Festas.FindAsync(festaId.Value);
                if (festa == null)
                {
                    throw new Exception("Festa não encontrada.");
                }
            }
            else 
            {
                // novo
                festa = new clsFestas();
                context.Festas.Add(festa); // adiciona um novo objeto festa
            }
            return festa; // retorna festa-encontrada ou festa-nova
        }
        /// <summary>
        /// 1.1. atualiza as propriedades da instância festa com os valores do formulário
        /// </summary>
        /// <param name="festa"></param>
        private void AtualizarPropriedadesFesta(clsFestas festa)
        {
            festa.fest_user_id = (int)cbbVendedor.SelectedValue!; 
            festa.fest_cli_id = (int)cbbClientes.SelectedValue!; 
            festa.fest_tpEv_id = (int?)cbbTiposEvento.SelectedValue; 
            festa.fest_espc_id = (int?)cbbEspacos.SelectedValue; 
            festa.fest_pct_id = (int?)cbbPacotes.SelectedValue; 
            festa.fest_tema_id = (int?)cbbTemas.SelectedValue; 
            festa.fest_stt_id = (int?)cbbStatus.SelectedValue;

            // usando extensões personalizadas de MyFramework
            festa.fest_valor = lblValorTotalFesta.Text.ToDouble();
            festa.fest_dtVenda = txtDataVenda.Text.ToDate();
            festa.fest_dtFesta = txtDataFesta.Text.ToDate();
        }
        /// <summary>
        /// 2. verifica se há detalhes para a festa, ou cria novos detalhes
        /// </summary>
        /// <param name="context"></param>
        /// <param name="festaId"></param>
        /// <returns></returns>
        private async Task<clsFestasDetalhes> ObterOuCriarDetalhesFesta(clsFestasContext context, int festaId)
        {
            // declara uma instância vazia
            clsFestasDetalhes? detalhesFesta;
            
            if (operacao != OperacaoCRUD.NOVO)
            {
                // Busca os detalhes da festa pelo campo detfest_fest_id
                detalhesFesta = await context.Detalhes
                    .FirstOrDefaultAsync(d => d.detfest_fest_id == festaId);

                if (detalhesFesta == null)
                {
                    // Se não houver detalhes, cria um novo e associa o ID da festa
                    detalhesFesta = new clsFestasDetalhes { detfest_fest_id = festaId};
                    context.Detalhes.Add(detalhesFesta);
                }
            }
            else // novo
            {
                // Se operacaoNOVO, cria um novo e associa o ID da festa
                detalhesFesta = new clsFestasDetalhes { detfest_fest_id = festaId};
                context.Detalhes.Add(detalhesFesta);
            }

            return detalhesFesta;
        }
        /// <summary>
        /// 2.1. atualiza as propriedades da instância detalhesFesta com os valores do formulário
        /// </summary>
        /// <param name="detalhesFesta"></param>
        private void AtualizarPropriedadesDetalhesFesta(clsFestasDetalhes detalhesFesta)
        {
            detalhesFesta.detfest_iniciohora = myDateTime.FormatTimeToRap(txtHoraInicio.Text, @"hh\:mm");
            detalhesFesta.detfest_fimhora = myDateTime.FormatTimeToRap(txtHoraFim.Text, @"hh\:mm");
            detalhesFesta.detfest_totalpessoas = Convert.ToInt32(0 + txtTotalPessoa.Text); // somar com 0, evita exceçoes se controle null
            detalhesFesta.detfest_adultos = Convert.ToInt32(0 + txtTotalAdultos.Text);
            detalhesFesta.detfest_criancaspagantes = Convert.ToInt32(0 + txtCriancasPagantes.Text);
            detalhesFesta.detfest_criancasnaopagantes = Convert.ToInt32(0 + txtCriancasNaoPagantes.Text);
            detalhesFesta.detfest_pessoasamais = Convert.ToInt32(0 + txtPessoasAMais.Text);
            detalhesFesta.detfest_ctt_id = Convert.ToInt32(cbbContratos.SelectedValue);
            detalhesFesta.detfest_observacao = txtObservacao.Text;
        }
        /// <summary>
        /// 3. grava os dados do datagridItens nas propriedades de adicionais da festa repAdicionais
        /// </summary>
        /// <param name="contexto"></param>
        /// <param name="festaId"></param>
        private void AtualizarPropriedadesAdicionaisFesta(clsFestasContext context, int festaId)
        {
            // Limpa os adicionais existentes para evitar duplicações
            var adicionaisExistentes = context.Adicionais
                                                .Where(a => a.add_fest_id == festaId)
                                                .ToList();

            // apaga adicionais existentes para evitar duplicação
            foreach (var adicional in adicionaisExistentes)
            {
                context.Adicionais.Remove(adicional);
            }

            // Itera sobre as linhas do DataGridView e adiciona novos itens adicionais
            foreach (DataGridViewRow row in dtgItens.Rows)
            {
                if (row.IsNewRow) continue; // Ignora a linha de nova entrada
                                            
                var itemId = Convert.ToInt16(row.Cells[ColItemId].Value);
                var itemQtde = Convert.ToInt16(row.Cells[ColQtde].Value);
                var itemValor = Convert.ToDouble(row.Cells[ColValor].Value); // corrigir aqui, aparece o valor de qtde * valUnit

                if (itemId > 0)
                {
                    clsFestasAdicionais adicionalFesta = new()
                    {
                        add_fest_id = festaId,
                        add_itensfest_id = itemId,
                        add_qtde = itemQtde,
                        add_valor = itemValor
                    };
                    context.Adicionais.Add(adicionalFesta);
                }
            }
        }
        /// <summary>
        /// deletar-festa-selecionada
        /// </summary>
        /// <param name="festaId"></param>
        /// <returns></returns>
        private async Task ExcluirFestaEF(int festaId)
        {
            if (festaId <= 0)
            {
                await myUtilities.myMessageBox(this, $"Festa não encontrada! {festaId}", "Excluir Festa");
                return;
            }

            try
            {
                // Exibe a mensagem de confirmação usando MessageBox.Show
                var message = $"""
                        Deseja Excluir a Festa de {cbbClientes.Text}?

                        Esta ação não poderá ser desfeita!
                        """;
                var result = await myUtilities.myMessageBox(this, message, "Excluir Festa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (var contexto = new clsFestasContext())
                    {
                        // Buscar a festa existente no banco de dados
                        clsFestas? festa = await contexto.Festas.FindAsync(festaId);

                        if (festa == null)
                        {
                            throw new Exception("Festa não encontrada.");
                        }

                        // verificar se há registros da festas no financeiro, e não excluir se houver

                        // Remover a festa do contexto
                        contexto.Festas.Remove(festa);

                        // Remover detalhes da festa

                        // Remover Itens da festa

                        // Salvar as alterações no banco de dados
                        await contexto.SaveChangesAsync();
                    }

                    //await myUtilities.myMessageBox(this, "Festa excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao excluir festa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// auto-completar comboboxes
        /// </summary>
        private void ConfigurarAutoCompletarTxt()
        {
            //
            // Clientes
            //
            cbbClientes.DropDownStyle = ComboBoxStyle.DropDown;
            cbbClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbClientes.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cbbClientes.AutoCompleteCustomSource = CarregarNomesClientes();
            //
            // Usuarios
            //
            //cbbVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbbVendedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbbVendedor.AutoCompleteSource = AutoCompleteSource.ListItems;
            //txtUserNome.AutoCompleteCustomSource = CarregarNomesUsuarios();
            //
            // itens festas
            //
            //cbbItemFesta.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbbItemFesta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbbItemFesta.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cbbItemFesta.AutoCompleteCustomSource = CarregarItensFesta();
            //
            // Contratos
            //
            //cbbContratos.DropDownStyle = ComboBoxStyle.DropDownList;
            //cbbContratos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbbContratos.AutoCompleteSource = AutoCompleteSource.ListItems;
            //txtContrato.AutoCompleteCustomSource = CarregarNomesContratos();
        }
        //
        /// <summary>
        /// Validação dos controles do formulário
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ValidarControles()
        {
            //
            // 1. Validação de data de venda
            if (!myDateTime.ValidDate(txtDataVenda.Text))
            {
                await myUtilities.myMessageBox(this, "Data de venda inválida. Formato esperado: ddMMyyyy", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDataVenda.Focus();
                return false;
            }
            //
            // 2. Validação de usuário
            if (cbbVendedor.SelectedValue == null)
            {
                await myUtilities.myMessageBox(this, "Usuário inválido. Informe um Usuário!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbVendedor.Focus();
                return false;
            }
            //
            // 3. Validação de cliente
            if (cbbClientes.SelectedValue == null)
            {
                await myUtilities.myMessageBox(this, "Cliente inválido. Informe um Cliente!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbClientes.Focus();
                return false;
            }
            //
            // 4. Validação de data de festa
            if (!myDateTime.ValidDate(txtDataFesta.Text))
            {
                await myUtilities.myMessageBox(this, "Data da festa inválida. informe uma data válida!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDataFesta.Focus();
                return false;
            }
            // Validação de hora inicio
            if (!myDateTime.ValidTime(txtHoraInicio.Text, @"hh\:mm"))
            {
                await myUtilities.myMessageBox(this, "Hora Início da festa inválida. Formato esperado: hh:mm", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoraInicio.Focus();
                return false;
            }
            //
            // 5.Validação de hora fim
            if (!myDateTime.ValidTime(txtHoraFim.Text, @"hh\:mm"))
            {
                await myUtilities.myMessageBox(this, "Hora Final da festa inválida. Formato esperado: hh:mm", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoraFim.Focus();
                return false;
            }
            //
            // 6. tipo evento
            if (cbbTiposEvento.SelectedValue == null)
            {
                await myUtilities.myMessageBox(this, "Tipo de Evento inválido. Selecione um Evento!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbTiposEvento.Focus();
                return false;
            }
            //
            // 7. pacotes
            if (cbbPacotes.SelectedValue == null)
            {
                await myUtilities.myMessageBox(this, "Pacote inválido. Selecione um Pacote!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbPacotes.Focus();
                return false;
            }
            //
            // 8. espaço
            if (cbbEspacos.SelectedValue == null)
            {
                await myUtilities.myMessageBox(this, "Espaço inválido. Selecione um Espaço!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbEspacos.Focus();
                return false;
            }
            //
            // 9. tema
            if (cbbTemas.SelectedValue == null)
            {
                await myUtilities.myMessageBox(this, "Tema inválido. Selecione um Tema!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbTemas.Focus();
                return false;
            }
            //
            // 10. status
            if (cbbStatus.SelectedValue == null)
            {
                await myUtilities.myMessageBox(this, "Status inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbStatus.Focus();
                return false;
            }
            //
            // 11. Validação de contrato
            if (string.IsNullOrWhiteSpace(cbbContratos.Text) || cbbContratos.Text == string.Empty)
            {
                await myUtilities.myMessageBox(this, "Contrato inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbContratos.Focus();
                return false;
            }
            //
            // 12. Validação do valor da festa
            //if (string.IsNullOrWhiteSpace(lblValorFesta.Text) || !decimal.TryParse(lblValorFesta.Text, out _))
            //{
            //    await myUtilities.myMessageBox(this, "Valor da festa inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// <summary>
        /// constantes com Numeros das colunas
        /// </summary>
        private const int ColItemId = 0;
        private const int ColDescricao = 1;
        private const int ColQtde = 2;
        private const int ColValor = 3;
        private const int ColDelete = 4;
        /// <summary>
        /// Configura dtgItensFesta
        /// </summary>
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
            myFunctions.ConfigurarAdicionarColuna(dtg, ColItemId, "ID", 30, visible: false);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColDescricao, "Descrição", 200, "", alignment: DataGridViewContentAlignment.MiddleLeft);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColQtde, "Qtde", 80, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, ColValor, "Valor", 80, "", alignment: DataGridViewContentAlignment.MiddleRight);

            // Formatar coluna Valor como moeda
            dtg.Columns[ColDescricao].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dtg.Columns[ColValor].DefaultCellStyle.Format = "N2";

            // Adicionar coluna de exclusão
            DataGridViewImageColumn deleteColumn = new()
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
        /// <summary>
        /// Deletar itens em dtgItensFestas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DtgItens_CellContentClick(object? sender, DataGridViewCellEventArgs e)
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
                    var resultado = await myUtilities.myMessageBox(this, $"Tem certeza que deseja deletar {descricao}?", "Confirmação de Deleção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                //    await myUtilities.myMessageBox(this, "A linha selecionada está vazia e não pode ser deletada.", "Erro de Deleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
        }
        //
        private void DtgItens_SelectionChanged(object? sender, EventArgs e)
        {
            //txtValorTotalIntens.Text = SomarValorTotalItens().ToString("C2");
        }
        //
        private void TxtItemQtde_Validating(object? sender, CancelEventArgs e)
        {

        }
        //
        /// <summary>
        /// Adiciona itens no dtgItensFestas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAddItem_Click(object sender, EventArgs e)
        {
            // Validar os campos de entrada
            if (string.IsNullOrWhiteSpace(cbbItemFesta.Text) ||
                string.IsNullOrWhiteSpace(txtItemQtde.Text) ||
                string.IsNullOrWhiteSpace(txtItemValor.Text))
            {
                await myUtilities.myMessageBox(this, "Todos os campos devem ser preenchidos.", "Adicionais da Festa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbItemFesta.Focus();
                return;
            }
            // Tentar converter os valores de quantidade
            if (!int.TryParse(txtItemQtde.Text, out int quantidade))
            {
                await myUtilities.myMessageBox(this, "Quantidade deve ser um número inteiro válido.", "Adicionais da Festa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemQtde.Focus();
                return;
            }
            // Tentar converter os valores de valor
            if (!double.TryParse(txtItemValor.Text, out double valor))
            {
                await myUtilities.myMessageBox(this, "Valor deve ser um número válido.", "Adicionais da Festa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemValor.Focus();
                return;
            }
            //
            // Adicionar o item ao DataGridView
            //dtgItens.Rows.Add($"{cbbItemFesta.Text} ({valor.ToString("N2")})", quantidade, (valor * quantidade));
            dtgItens.Rows.Add(cbbItemFesta.SelectedValue, cbbItemFesta.Text, quantidade, (valor * quantidade));

            // soma total de itens
            SomarValorTotalItens();
            //
            LimparItensFesta();
            //// Limpar os campos de entrada
            //txtItemQtde.Clear();
            //txtItemValor.Clear();
            ////
            //cbbItemFesta.SelectedItem = -1;
            //
            cbbItemFesta.Focus();
        }
        //
        /// <summary>
        /// Valor total de itens
        /// </summary>
        private void SomarValorTotalItens()
        {
            double soma = 0;
            foreach (DataGridViewRow row in dtgItens.Rows)
            {
                double valor = row.Cells[ColValor].Value != null ? Convert.ToDouble(row.Cells[ColValor].Value) : 0.0;
                //double quantidade = row.Cells[ColQtde].Value != null ? Convert.ToDouble(row.Cells[ColValor].Value) : 0;
                soma += valor;
            }
            lblValorTotalIntens.Text = soma.ToString("N2");
            SomarValorTotalFesta();
        }
        /// <summary>
        /// Trata descontos da festa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtDescontosFesta_Validating(object? sender, CancelEventArgs e)
        {
            SomarValorTotalFesta();
        }
        /// <summary>
        /// Somar Valor Total das Festas
        /// </summary>
        private void SomarValorTotalFesta()
        {
            // valor-pacote
            //lblValorPacote.Text = "0,00";
            double pacote = Convert.ToDouble(lblValorPacote.Text);
            // valor-adicionais
            double valorAdicionais = Convert.ToDouble("0" + lblValorTotalIntens.Text);
            lblValorAdicionais.Text = valorAdicionais.ToString("N2");
            // desconto
            double desconto = Convert.ToDouble("0" + txtDescontosFesta.Text);
            // valor-total-festa
            lblValorTotalFesta.Text = ((pacote + valorAdicionais) - desconto).ToString("N2");
        }
        //
        /// <summary>
        /// Evento para mudar o cursor ao entrar na célula de exclusão
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Evento para mudar o cursor ao sair da célula de exclusão
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        //
        #region Trata as pic/btn-add, para chamar as tabelas-auxiliares
        /// <summary>
        /// picture add-Tipo-evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void picAddTipoEvento_Click(object sender, EventArgs e)
        {
            ComboBox cbb = cbbTiposEvento;
            // Armazenar o registro selecionado antes de abrir o formulário
            string registroSelecionado = cbb.Text;

            // Criar e abrir o formulário CRUD passando o objeto e a operação
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            using (FormTipoEvento frm = new(param, operacao))
            {
                // Usar a Modal para exibir o FormCRUD
                await myUtilities.CreateModalOverlayAsync(this, frmExibir: frm);

                // Verificar se um novo registro foi criado
                if (!string.IsNullOrEmpty(frm.TipoAtual.tpev_nome) && frm.TipoAtual.tpev_nome != registroSelecionado)
                {
                    // Atualizar ComboBox se houve mudanças
                    using (clsFestasContext context = new clsFestasContext())
                    {
                        SetComboBoxesEF(cbbTiposEvento, context.TipoEvento.OrderBy(t => t.tpev_nome).ToList(), "tpev_nome", "tpev_id");
                    }
                    // Atualizar o registro selecionado com o novo registro
                    registroSelecionado = frm.TipoAtual.tpev_nome;
                }
                if (!string.IsNullOrEmpty(registroSelecionado))
                {
                    // Selecionar o item que estava selecionado antes de abrir o formulário ou um novo
                    cbb.Text = registroSelecionado;
                }
            }
        }
        //
        /// <summary>
        /// picture add-espaco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void picAddEspaco_Click(object sender, EventArgs e)
        {
            ComboBox cbb = cbbEspacos;
            // Armazenar o registro selecionado antes de abrir o formulário
            string registroSelecionado = cbb.Text;

            // Criar e abrir o formulário CRUD passando o objeto e a operação
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            using (FormEspacosFestas frm = new(param, operacao))
            {
                // Usar a Modal para exibir o FormCRUD
                await myUtilities.CreateModalOverlayAsync(this, frmExibir: frm);

                // Verificar se um novo registro foi criado
                if (!string.IsNullOrEmpty(frm.EspacoAtual.espc_nome) && frm.EspacoAtual.espc_nome != registroSelecionado)
                {
                    // Atualizar ComboBox se houve mudanças
                    using (clsFestasContext context = new clsFestasContext())
                    {
                        SetComboBoxesEF(cbbEspacos, context.Espacos.OrderBy(e => e.espc_nome).ToList(), "espc_nome", "espc_id");
                    }
                    // Atualizar o registro selecionado com o novo registro
                    registroSelecionado = frm.EspacoAtual.espc_nome;
                }
                if (!string.IsNullOrEmpty(registroSelecionado))
                {
                    // Selecionar o item que estava selecionado antes de abrir o formulário ou um novo
                    cbb.Text = registroSelecionado;
                }
            }
        }
        //
        /// <summary>
        /// picture add-tema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void picAddTema_Click(object sender, EventArgs e)
        {
            ComboBox cbb = cbbTemas;
            // Armazenar o registro selecionado antes de abrir o formulário
            string registroSelecionado = cbb.Text;

            // Criar e abrir o formulário CRUD passando o objeto e a operação
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            using (FormTemasFestas frm = new(param, operacao))
            {
                // Usar a Modal para exibir o FormCRUD
                await myUtilities.CreateModalOverlayAsync(this, frmExibir: frm);

                // Verificar se um novo registro foi criado
                if (!string.IsNullOrEmpty(frm._temaAtual.tema_nome) && frm._temaAtual.tema_nome != registroSelecionado)
                {
                    // Atualizar ComboBox se houve mudanças
                    using (clsFestasContext context = new())
                    {
                        SetComboBoxesEF(cbbTemas, context.Temas.OrderBy(t => t.tema_nome).ToList(), "tema_nome", "tema_id");
                    }
                    // Atualizar o registro selecionado com o novo registro
                    registroSelecionado = frm._temaAtual.tema_nome;
                }
                if (!string.IsNullOrEmpty(registroSelecionado))
                {
                    // Selecionar o item que estava selecionado antes de abrir o formulário ou um novo
                    cbb.Text = registroSelecionado;
                }
            }
        }
        //
        /// <summary>
        /// picture add-pacote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void picAddPacote_Click(object sender, EventArgs e)
        {
            ComboBox cbb = cbbPacotes;
            // Armazenar o registro selecionado antes de abrir o formulário
            string registroSelecionado = cbb.Text;

            // Criar e abrir o formulário CRUD passando o objeto e a operação
            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            using (FormPacotesCRUD frm = new(param, operacao))
            {
                // Usar a Modal para exibir o FormCRUD
                await myUtilities.CreateModalOverlayAsync(this, frmExibir: frm);

                // Verificar se um novo registro foi criado
                if (!string.IsNullOrEmpty(frm.PacoteAtual.pct_nome) && frm.PacoteAtual.pct_nome != registroSelecionado)
                {
                    // Atualizar ComboBox se houve mudanças
                    using (clsFestasContext context = new())
                    {
                        SetComboBoxesEF(cbbPacotes, context.Pacotes.OrderBy(p => p.pct_nome).ToList(), "pct_nome", "pct_id");
                    }
                    // Atualizar o registro selecionado com o novo registro
                    registroSelecionado = frm.PacoteAtual.pct_nome;
                }
                if (!string.IsNullOrEmpty(registroSelecionado))
                {
                    // Selecionar o item que estava selecionado antes de abrir o formulário ou o novo
                    cbb.Text = registroSelecionado;
                }
            }
        }
        //
        /// <summary>
        /// picture add-status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void picAddStatus_Click(object sender, EventArgs e)
        {
            ComboBox cbb = cbbStatus;
            // armazena o registro slecionado antes de abrir o form auxiliar
            string registroSelecionado = cbb.Text;

            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            using (FormStatusCRUD frm = new(param, operacao))
            {
                // Usar a Modal para exibir o FormCRUD
                await myUtilities.CreateModalOverlayAsync(this, frmExibir: frm);

                // verifica se um novo registro foi criado
                if (!string.IsNullOrEmpty(frm.StatusAtual.stt_status) && frm.StatusAtual.stt_status != registroSelecionado)
                {
                    // atualizar combobox se houve mundanças
                    using (clsFestasContext context = new())
                    {
                        SetComboBoxesEF(cbbStatus, context.Status.OrderBy(s => s.stt_status).ToList(), "stt_status", "stt_id");
                    }
                    // atualiza o registro selecionado com o novo registro
                    registroSelecionado = frm.StatusAtual.stt_status;
                }

                if (!string.IsNullOrEmpty(registroSelecionado))
                {
                    // selecionar o item que estava selecionado antes de abrir o formulário, ou seleciona o novo
                    cbb.Text = registroSelecionado;
                }

            }
        }
        //
        /// <summary>
        /// picture add-cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void picAddCliente_Click(object sender, EventArgs e)
        {
            ComboBox cbb = cbbClientes;
            var registroSelecionado = cbb.ValueMember;

            OperacaoCRUD operacao = OperacaoCRUD.NOVO;
            using (FormClientesCRUD frm = new(param, operacao))
            {
                // Usar a Modal para exibir o FormCRUD
                await myUtilities.CreateModalOverlayAsync(this, frmExibir: frm);

                var novoCliente = frm._viewModel.ClienteSelecionado!.cli_id.ToString();

                // verifica se um novo registro foi criado
                if (!string.IsNullOrEmpty(novoCliente) && novoCliente != registroSelecionado)
                {
                    // atualizar combobox se houve mundanças
                    using (clsFestasContext context = new())
                    {
                        SetComboBoxesEF(cbbClientes, context.Clientes.OrderBy(c => c.cli_nome).ToList(), "cli_nome", "cli_id");
                    }
                    // atualiza o registro selecionado com o novo registro
                    registroSelecionado = novoCliente;
                }

                if (!string.IsNullOrEmpty(registroSelecionado))
                {
                    // selecionar o item que estava selecionado antes de abrir o formulário, ou seleciona o novo
                    cbb.ValueMember = registroSelecionado;
                }
            }
        }
        //
        #endregion
        //
        #region Códigos temporários, substítuidos para exclusão
        //*************************************************************
        //************************ SEM USO -- TEMP
        //// autocompletar-itens-festas
        //private AutoCompleteStringCollection CarregarItensFesta()
        //{
        //    AutoCompleteStringCollection itensFesta = new();

        //    using (var context = new clsFestasContext())
        //    {
        //        var itens = context.ItensFestas
        //                            .Select(i => i.itensfest_nome)
        //                            .ToList();

        //        itensFesta.AddRange(itens.ToArray());
        //    }
        //    return itensFesta;
        //}

        ////
        //// autocompletar-contratos
        //private AutoCompleteStringCollection CarregarNomesContratos()
        //{
        //    AutoCompleteStringCollection nomesContratos = new();

        //    using (clsFestasContext context = new())
        //    {
        //        var contratos = context.Contratos
        //                                .Select(ct => ct.ctt_nome)
        //                                .Where(nome => nome != null) // Filtra os valores nulos
        //                                .ToList();

        //        nomesContratos.AddRange(contratos.ToArray());
        //    }
        //    return nomesContratos;
        //}
        //
        // autocompletar-usuarios
        //private AutoCompleteStringCollection CarregarNomesUsuarios()
        //{
        //    AutoCompleteStringCollection nomesUsuarios = new();

        //    using (var context = new clsFestasContext())
        //    {
        //        var usuarios = context.Usuarios
        //                                .Select(u => u.user_nome)
        //                                .ToList();

        //        nomesUsuarios.AddRange(usuarios.ToArray());
        //    }
        //    return nomesUsuarios;
        //}
        //
        // autocompletar-clientes
        //private AutoCompleteStringCollection CarregarNomesClientes()
        //{
        //    // Crie uma instância do AutoCompleteStringCollection
        //    AutoCompleteStringCollection nomesClientes = new AutoCompleteStringCollection();

        //    // Carregar os nomes dos clientes do banco de dados
        //    using (clsFestasContext context = new())
        //    {
        //        var clientes = context.Clientes
        //                                .Select(c => c.cli_nome)
        //                                .ToList();

        //        // Adicionar os nomes dos clientes ao AutoCompleteStringCollection
        //        nomesClientes.AddRange(clientes.ToArray());
        //    }
        //    return nomesClientes;
        //}
        //
        //
        #endregion
        //

    } // end class FormFestasCRUD
} // end namespace FestasApp.Views.Festas
