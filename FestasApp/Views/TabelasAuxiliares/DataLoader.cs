//---------------------------------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação deste Módulo: 11/07/2024
//   Ultima Alteração: 11/07/2024
//   
//   Esta classe será responsável por carregar dados das diferentes tabelas auxiliares.
//
//---------------------------------------------------------------------------------------

namespace FestasApp.Views.TabelasAuxiliares
{
    public class DataLoader
    {
        /// <summary>
        /// Instância de FormAuxiliaresMain para gerenciar as tabelas auxiliares
        /// </summary>
        private readonly FormAuxiliaresMain _form;
        //private readonly clsFestasContext _context;
        public clsParam idRegistro = new(); // Inicialize a instância publica

        // Instância de TabelaAuxiliarManager para gerenciar a seleção das tabelas auxiliares no dtg
        private readonly TabelaAuxiliarManager _tabelaAuxiliarManager = new(); // em: namespace FestasApp.Managers
        
        /// <summary>
        /// construtor padrão
        /// </summary>
        /// <param name="form"></param>
        /// <param name="context"></param>
        public DataLoader(FormAuxiliaresMain form) //, clsFestasContext context)
        {
            _form = form;
            //_context = context;
        }
        /// <summary>
        /// 1. Método para popular o DataGridView com as tabelas auxiliares
        /// </summary>
        public void PopularDtgTabelasAuxiliares()
        {
            // percorre a lista de tabelas auxiliares e preenche dtgTabelas
            foreach (var tabela in _tabelaAuxiliarManager.tabelasAuxiliares)
            {
                AdicionarTabela(tabela);
            }
            OrdenarESelecionarPrimeiraLinha();
        }
        /// <summary>
        /// 1.1. Método para adicionar uma tabela ao DataGridView
        /// </summary>
        /// <param name="tabela"></param>
        private void AdicionarTabela(string tabela)
        {
            if (_form.dtgTabelasAuxiliares != null)
            {
                _form.dtgTabelasAuxiliares.Rows.Add(tabela);
            }
        }
        //
        /// <summary>
        /// 1.2. Método para ordenar o DataGridView e selecionar a primeira linha
        /// </summary>
        private void OrdenarESelecionarPrimeiraLinha()
        {
            if (_form.dtgTabelasAuxiliares != null)
            {
                DataGridView dtg = _form.dtgTabelasAuxiliares;

                // Ordena o DataGridView pela primeira coluna
                dtg.Sort(dtg.Columns[0], ListSortDirection.Ascending);

                // Seleciona a primeira linha se houver linhas no DataGridView
                if (dtg.Rows.Count > 0)
                {
                    dtg.ClearSelection();
                    dtg.Rows[0].Selected = true;
                    dtg.CurrentCell = dtg.Rows[0].Cells[0];
                    dtg.Focus();
                }
            }
        }
        //
        /// <summary>
        ///  evento ao selecionar Tabela em dtgTabelas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dtg = (DataGridView)sender;

            // se houver tabelas no datagridviewTabelas
            if (dtg.SelectedRows.Count > 0)
            {
                // personaliza a seleção da tabela
                SetTabelaSelecionada(dtg);

                DataGridViewRow row = dtg.SelectedRows[0];
                // linha selecionada
                var tabelaSelecionada = row.Cells[0].Value.ToString();
                // mostra os registros da tabela selecionada no dtgRegistros
                if (!string.IsNullOrEmpty(tabelaSelecionada))
                {
                    CarregarRegistrosDaTabela();
                }
            }
        }
        /// <summary>
        /// personaliza tabela selecionada no datagridTabelas
        /// </summary>
        /// <param name="dtg"></param>
        private void SetTabelaSelecionada(DataGridView dtg)
        {
            // retorna configuração das linhas anteriormente selecionadas
            foreach (DataGridViewRow row in dtg.Rows)
            {
                //row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                row.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            }

            // Adicionar padding à linha atualmente selecionada
            if (dtg.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtg.SelectedRows[0];
                //selectedRow.DefaultCellStyle.ForeColor = Color.White;
                selectedRow.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                selectedRow.DefaultCellStyle.Padding = new Padding(30, 0, 0, 0); // Ajuste o valor conforme necessário

                // Forçar atualização do DataGridView
                dtg.InvalidateRow(selectedRow.Index);
                dtg.Update();

                // se tabela selecionada não for contratos, fecha painel de visualização
                if (!_tabelaAuxiliarManager.IsTabelaContratosSelecionada(_form.dtgTabelasAuxiliares))
                {
                    FecharPanelVisualizacao();
                }
            }
        }
        ///
        /// <summary>
        /// popular dtgRegistrosTabelas de acordo com a tabela selecionada
        /// </summary>
        public void CarregarRegistrosDaTabela()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Rows.Clear();
            // itens festas
            if (_tabelaAuxiliarManager.IsTabelaItensFestasSelecionada(_form.dtgTabelasAuxiliares))
            {
                var itens = repItensFestasEF.GetItensFestas();
                if (itens != null)
                {
                    SetDtgRegistrosParaItens();
                    foreach (var registro in itens)
                    {
                        dtg.Rows.Add(registro.itensfest_id, registro.itensfest_nome, registro.itensfest_tipo, registro.itensfest_descricao, registro.itensfest_valor);
                    }
                }
            } 
            // espaços
            else if (_tabelaAuxiliarManager.IsTabelaEspacosSelecionada(_form.dtgTabelasAuxiliares))
            {
                var espacos = repEspacosEF.GetEspacos();
                if (espacos != null)
                {
                    SetDtgRegistrosParaEspacos();
                    foreach (var registro in espacos)
                    {
                        dtg.Rows.Add(registro.espc_id, registro.espc_nome);
                    }
                }
            } 
            // contratos
            else if (_tabelaAuxiliarManager.IsTabelaContratosSelecionada(_form.dtgTabelasAuxiliares))
            {
                var contratos = repContratosEF.GetContratos();
                if (contratos != null)
                {
                    SetDtgRegistrosParaContratos();
                    foreach (var registro in contratos)
                    {
                        dtg.Rows.Add(registro.ctt_id, registro.ctt_nome, registro.ctt_caminho_arquivo);
                    }
                }
            } 
            // pacotes
            else if (_tabelaAuxiliarManager.IsTabelaPacotesSelecionada(_form.dtgTabelasAuxiliares))
            {
                var pacotes = repPacotesEF.GetPacotes();
                if (pacotes != null)
                {
                    SetDtgRegistrosParaPacotes();
                    foreach (var registro in pacotes)
                    {
                        dtg.Rows.Add(registro.pct_id, registro.pct_nome, registro.pct_descricao, registro.pct_duracao + "h", registro.pct_valor);
                    }
                }
            } 
            // status
            else if (_tabelaAuxiliarManager.IsTabelaStatusSelecionada(_form.dtgTabelasAuxiliares))
            {
                var status = repStatusEF.GetStatus();
                if (status != null)
                {
                    SetDtgRegistrosParaStatus();
                    foreach (var registro in status)
                    {
                        dtg.Rows.Add(registro.stt_id, registro.stt_status);
                    }
                }
            } 
            // temas
            else if (_tabelaAuxiliarManager.IsTabelaTemasSelecionada(_form.dtgTabelasAuxiliares))
            {
                var temas = repTemasEF.GetTemas();
                if (temas != null)
                {
                    SetDtgRegistrosParaTemas();
                    foreach (var registro in temas)
                    {
                        dtg.Rows.Add(registro.tema_id, registro.tema_nome, registro.tema_descricao);
                    }
                }
            } 
            // tipos eventos
            else if (_tabelaAuxiliarManager.IsTabelaTipoEventosSelecionada(_form.dtgTabelasAuxiliares))
            {
                var tpev = repTipoEventoEF.GetTipoEvento();
                if (tpev != null)
                {
                    SetDtgRegistrosParaTipoEvento();
                    foreach (var registro in tpev)
                    {
                        dtg.Rows.Add(registro.tpev_id, registro.tpev_nome);
                    }
                }
            }

           // Continue para outras tabelas...
        }
        //
        //******************************************************
        /// <summary>
        /// configurações específicas para dtg 1. TIPO de EVENTOS
        /// </summary>
        private void SetDtgRegistrosParaTipoEvento()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Tipo de Evento", 220, "");
            dtg.Sort(dtg.Columns["Tipo de Evento"], ListSortDirection.Ascending);
        }
        //------------------------------------------------------
        /// <summary>
        /// configurações específicas para dtg 2. TEMAS
        /// </summary>
        private void SetDtgRegistrosParaTemas()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Temas", 220, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 2, "Descrição", 220, "");
            dtg.Sort(dtg.Columns["Temas"], ListSortDirection.Ascending);

            // Ajustar a largura da coluna "Descrição" com um valor mínimo
            AjustarLarguraComMinimo(dtg.Columns["Descrição"], 220);

            // para ajustar a largura com base apenas no cabeçalho:
            //dtg.Columns["Descrição"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            //dtg.Sort(dtg.Columns["Temas"], ListSortDirection.Ascending);
        }
        //------------------------------------------------------
        /// <summary>
        /// configurações específicas para dtg 3. STATUS
        /// </summary>
        private void SetDtgRegistrosParaStatus()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Status", 220, "");
            dtg.Sort(dtg.Columns["Status"], ListSortDirection.Ascending);
        }
        //------------------------------------------------------
        /// <summary>
        /// configurações específicas para dtg 4. PACOTES
        /// </summary>
        private void SetDtgRegistrosParaPacotes()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Nome", 220, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 2, "Descrição", 220  , "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 3, "Duração", 100, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 4, "Valor", 100, "", alignment: DataGridViewContentAlignment.MiddleRight);
            dtg.Sort(dtg.Columns["Nome"], ListSortDirection.Ascending);
            dtg.Columns["Valor"].DefaultCellStyle.Format = "C2";

            // Ajustar a largura da coluna "Descrição" com um valor mínimo
            AjustarLarguraComMinimo(dtg.Columns["Descrição"], 220);
        }
        //------------------------------------------------------
        /// <summary>
        /// configurações específicas para dtg 5. ITENS
        /// </summary>
        private void SetDtgRegistrosParaItens()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Nome", 220, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 2, "Tipo", 100, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 3, "Descrição", 200, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 4, "Valor", 100, "", alignment: DataGridViewContentAlignment.MiddleRight);
            dtg.Sort(dtg.Columns["Nome"], ListSortDirection.Ascending);

            // Ajustar a largura da coluna "Descrição" com um valor mínimo
            AjustarLarguraComMinimo(dtg.Columns["Descrição"], 220);

            dtg.Columns["Valor"].DefaultCellStyle.Format = "C2";
        }
        //------------------------------------------------------
        /// <summary>
        /// configurações específicas para dtg 6. ESPAÇOS
        /// </summary>
        private void SetDtgRegistrosParaEspacos()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Nome", 220, "");
            dtg.Sort(dtg.Columns["Nome"], ListSortDirection.Ascending);
        }
        /// <summary>
        /// método para ajustar largura de uma coluna especifica
        /// </summary>
        /// <param name="coluna"></param>
        /// <param name="larguraMinima"></param>
        private void AjustarLarguraComMinimo(DataGridViewColumn coluna, int larguraMinima)
        {
            // ativa modo autosize
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // determina largura minima
            if (coluna.Width < larguraMinima)
            {
                coluna.Width = larguraMinima;
            }
        }
        //
        /// *********************************
        /// <summary>
        /// configura para dtg 7. CONTRATOS
        /// </summary>
        private void SetDtgRegistrosParaContratos()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Nome", 220, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 2, "Arquivo", 400, "", visible: false);

            // Adicionar coluna de visualizar pdf-contrato Col[3]
            DataGridViewImageColumn pdfColumn = new DataGridViewImageColumn
            {
                Image = Properties.Resources.folder_open, // Certifique-se de ter um \Resources da imagem
                Name = "PDF",
                HeaderText = "Pdf",
                Width = 50
            };
            dtg.Columns.Add(pdfColumn);

            // ordenar dtg por [1]"Nome"
            dtg.Sort(dtg.Columns["Nome"], ListSortDirection.Ascending);

            // Adicionar eventos
            _form.dtgRegistrosTabelasAuxiliares.CellContentClick += DtgRegistrosTabelasAuxiliares_CellContentClick;
            _form.dtgRegistrosTabelasAuxiliares.SelectionChanged += DtgRegistrosTabelasAuxiliares_SelectionChanged;
            _form.dtgRegistrosTabelasAuxiliares.CellMouseEnter += DtgRegistrosTabelasAuxiliares_CellMouseEnter;
            _form.dtgRegistrosTabelasAuxiliares.CellMouseLeave += DtgRegistrosTabelasAuxiliares_CellMouseLeave;
        }
        //
        /// <summary>
        /// ao selecionar - captura o idRegistro selecionado no dtgRegistros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtgRegistrosTabelasAuxiliares_SelectionChanged(object? sender, EventArgs e)
        {
            if (_form.dtgRegistrosTabelasAuxiliares.SelectedRows.Count > 0)
            {
                var selectedRow = _form.dtgRegistrosTabelasAuxiliares.SelectedRows[0]; // Obtém a linha selecionada
                idRegistro.Id = Convert.ToInt32(selectedRow.Cells[0].Value); // Atualiza o idRegistro
            }
            else
            {
                idRegistro.Id = null; // Define como null se nenhuma linha estiver selecionada
            }
        }
        //
        /// <summary>
        /// ao clicar, se tabela for contratos - mostrar arquivo-pdf-contrato em painel de visualização
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtgRegistrosTabelasAuxiliares_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = (DataGridView)sender!;

            // se a tabela selecionada for Contratos,
            if (_tabelaAuxiliarManager.IsTabelaContratosSelecionada(_form.dtgTabelasAuxiliares))
            {
                // Verifique se o clique foi na coluna de visualização
                if (dtg != null && e.RowIndex >= 0 && e.ColumnIndex == dtg.Columns["PDF"].Index)
                {
                    var currentRow = dtg.Rows[e.RowIndex];
                    // Verifique se a linha não está vazia e contém caminho-arquivo
                    if (currentRow.Cells["Arquivo"].Value != null && !string.IsNullOrEmpty(currentRow.Cells["Arquivo"].Value.ToString()))
                    {
                        var caminhoArquivo = currentRow.Cells["Arquivo"].Value?.ToString() ?? string.Empty;
                        // mostrar pdf-contrato
                        //ExibirPainelVisualizacao();
                        VisualizarArquivoContrato(caminhoArquivo);
                    }
                    else
                    {
                        FecharPanelVisualizacao(); // método testa, se estiver aberto fecha
                    }
                }
            }
        }
        //
        /// <summary>
        /// Mostrar painel de visualização se a tabela selecionada for "Contratos"
        /// </summary>
        private void ExibirPainelVisualizacao()
        {
            // se panel não existir ele cria novo panel
            if (_form.pnlVisualizacao == null) // erro CS0122 
            {
                CriarPanelVisualizacao();
            }
            //
            _form.pnlVisualizacao!.Visible = true;
            // ocupa o restante do pnlMeio com dtgRegistros
            //_form.dtgRegistrosTabelasAuxiliares.Dock = DockStyle.Fill;
        }
        /// <summary>
        /// método para fechar painel de visualizar contratos-pdf
        /// </summary>
        public void FecharPanelVisualizacao()
        {
            if (_form.pnlVisualizacao != null)
            {
                _form.pnlMeio.Controls.Remove(_form.pnlVisualizacao);
                _form.pnlVisualizacao.Dispose();
                _form.pnlVisualizacao = null;
                // retorna o tamanho do dtgRegistros
                _form.dtgRegistrosTabelasAuxiliares.Dock = DockStyle.Fill;
            }
        }

        //
        /// <summary>
        /// método para visualizar o arquivo de contrato em um WebBrowser
        /// </summary>
        /// <param name="filePath"></param>
        private async void VisualizarArquivoContrato(string filePath)
        {
            // se caminho estiver vazio return
            if (string.IsNullOrEmpty(filePath))
            {
                _form.pdfViewer!.Navigate("about:blank"); // Limpar a visualização em caso de erro
                return;
            }

            // Verificar se o arquivo existe
            if (File.Exists(filePath))
            {
                // se panel não existir ele cria novo panel
                if (_form.pnlVisualizacao == null)
                {
                    CriarPanelVisualizacao();
                }

                var viewerPath = string.Empty;
                // Obter os caminhos completos normalizados
                if (_form.pdfViewer!.Url?.LocalPath != null)
                {
                    // caminho do arquivo que está aberto no viewer
                    viewerPath = Path.GetFullPath(_form.pdfViewer!.Url?.LocalPath ?? string.Empty);
                }
                
                // caminho do arquivo salvo na tabela
                var normalizedFilePath = Path.GetFullPath(filePath);

                // Verificar se o arquivo já está aberto no pdfViewer
                if (!string.Equals(viewerPath, normalizedFilePath, StringComparison.OrdinalIgnoreCase))
                {
                    _form.pdfViewer.Navigate(filePath);
                }
            }
            else
            {
                await myUtilities.myMessageBox(FormMenuMain.InstanceFrmMain!, $"Arquivo do contrato {filePath} não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                FecharPanelVisualizacao();
                //_form.pdfViewer!.Navigate("about:blank"); // Limpar a visualização em caso de erro
            }
        }
        //
        /// <summary>
        /// configurações do painel de visualização
        /// </summary>
        private void CriarPanelVisualizacao()
        {
            // 1. cria painel
            _form.pnlVisualizacao = new Panel 
            {
                Dock = DockStyle.Right,
                Width = 800,
                Padding = new Padding(5,5,5,5),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray
            };
            // Adiciona o painel de visualização ao painel principal
            _form.pnlMeio.Controls.Add(_form.pnlVisualizacao);

            // 1.1. Cria o botão de fechar
            Button btnClose = new Button
            {
                Text = "Fechar",
                Height = 30,
                //Margin = new Padding(10,10,0,0),
                //Image = Properties.Resources.fechar,
                Cursor = Cursors.Hand,
            };
            btnClose.Click += BtnClosePnlVisualização_Click;

            // 1.2. cria visualizador de pdf
            _form.pdfViewer = new WebBrowser
            {
                Dock = DockStyle.Fill
            };

            // Adiciona o botão de fechar e o visualizador de PDF ao painel de visualização
            _form.pnlVisualizacao.Controls.Add(btnClose);
            _form.pnlVisualizacao.Controls.Add(_form.pdfViewer);

        }
        //
        /// <summary>
        /// Evento de clique do botão de fechar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClosePnlVisualização_Click(object? sender, EventArgs e)
        {
            FecharPanelVisualizacao();
        }
        //
        /// <summary>
        /// MouseEnter e MouseLeave para dar feedback visual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtgRegistrosTabelasAuxiliares_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            //if (TabelaSelecionadaContratos() && sender is DataGridView dtg && e.ColumnIndex >= 0 && e.RowIndex >= 0)
            if (_tabelaAuxiliarManager.IsTabelaContratosSelecionada(_form.dtgTabelasAuxiliares) && sender is DataGridView dtg && e.RowIndex >= 0)
            {
                if (dtg.Columns[e.ColumnIndex].Name == "PDF")
                {
                    dtg.Cursor = Cursors.Hand;
                }
            }
        }
        /// <summary>
        /// MouseEnter e MouseLeave para dar feedback visual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtgRegistrosTabelasAuxiliares_CellMouseLeave(object? sender, DataGridViewCellEventArgs e)
        {
            //if (TabelaSelecionadaContratos() && sender is DataGridView dtg && e.ColumnIndex >= 0 && e.RowIndex >= 0)
            if (_tabelaAuxiliarManager.IsTabelaContratosSelecionada(_form.dtgTabelasAuxiliares) && sender is DataGridView dtg && e.RowIndex >= 0)
            {
                if (dtg.Columns[e.ColumnIndex].Name == "PDF")
                {
                    dtg.Cursor = Cursors.Default;
                }
            }
        }
        //

    } // end class DataLoader
} // end namespace
