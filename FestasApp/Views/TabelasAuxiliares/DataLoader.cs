//--------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação deste Módulo: 11/07/2024
//   Ultima Alteração: 11/07/2024
//   
//   Esta classe será responsável por carregar dados das diferentes tabelas auxiliares.
//--------------------------------------------------------------

namespace FestasApp.Views.TabelasAuxiliares
{
    public class DataLoader
    {
        private readonly FormAuxiliaresMain _form;
        private readonly clsFestasContext _context;
        public clsParam idRegistro = new(); // Inicialize a instância publica

        // Instância de TabelaAuxiliarManager para gerenciar as tabelas auxiliares
        private readonly TabelaAuxiliarManager _tabelaAuxiliarManager = new();

        public DataLoader(FormAuxiliaresMain form, clsFestasContext context)
        {
            _form = form;
            _context = context;
        }
        //
        // Método para popular o DataGridView com as tabelas auxiliares
        public void PopularDtgTabelasAuxiliares()
        {
            foreach (var tabela in _tabelaAuxiliarManager.tabelasAuxiliares)
            {
                AdicionarTabela(tabela);
            }
            OrdenarESelecionarPrimeiraLinha();
        }
        //
        // Método para adicionar uma tabela ao DataGridView
        private void AdicionarTabela(string tabela)
        {
            if (_form.dtgTabelasAuxiliares != null)
            {
                _form.dtgTabelasAuxiliares.Rows.Add(tabela);
            }
        }
        //
        // Método para ordenar o DataGridView e selecionar a primeira linha
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
        //  evento ao selecionar Tabela em dtgTabelas
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
                // mostra os registros da tabela selecionada
                if (!string.IsNullOrEmpty(tabelaSelecionada))
                {
                    CarregarRegistrosDaTabela();
                }
            }
        }
        // personaliza tabela selecionada no datagrid
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

                if (!_tabelaAuxiliarManager.IsTabelaContratosSelecionada(_form.dtgTabelasAuxiliares))
                {
                    FecharPanelVisualizacao();
                }
            }
        }
        //
        private void FecharPanelVisualizacao()
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
            } // espaços
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
            } // contratos
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
            } // pacotes
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
            } // status
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
            } // temas
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
            } // tipos eventos
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
        // configurações específicas para dtg TIPO de EVENTOS
        private void SetDtgRegistrosParaTipoEvento()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Temas", 220, "");
            dtg.Sort(dtg.Columns["Temas"], ListSortDirection.Ascending);
        }
        //
        // configurações específicas para dtg TEMAS
        private void SetDtgRegistrosParaTemas()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Tipos de Eventos", 220, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 2, "Descrição", 150, "");
            dtg.Sort(dtg.Columns["Tipos de Eventos"], ListSortDirection.Ascending);
        }
        //
        // configurações específicas para dtg STATUS
        private void SetDtgRegistrosParaStatus()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Status", 220, "");
            dtg.Sort(dtg.Columns["Status"], ListSortDirection.Ascending);
        }
        //
        // configurações específicas para dtg PACOES
        private void SetDtgRegistrosParaPacotes()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Nome", 220, "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 2, "Descrição", 200  , "");
            myFunctions.ConfigurarAdicionarColuna(dtg, 3, "Duração", 100, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 4, "Valor", 100, "", alignment: DataGridViewContentAlignment.MiddleRight);
            dtg.Sort(dtg.Columns["Nome"], ListSortDirection.Ascending);
            dtg.Columns["Valor"].DefaultCellStyle.Format = "C2";
        }
        //
        // configura para dtg contratos
        private void SetDtgRegistrosParaContratos()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            // Limpar colunas existentes
            dtg.Columns.Clear();
            // configurar colunas
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
        // mostrar arquivo-contrato
        private void DtgRegistrosTabelasAuxiliares_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DataGridView dtg = (DataGridView)sender!;

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
                        // mostrar contrato
                        ExibirPainelVisualizacao();
                        VisualizarArquivoContrato(caminhoArquivo);
                    }
                    else
                    {
                        FecharPanelVisualizacao();
                    }
                }
            }
            // seleciona um registro para CRUD
            if (_form.dtgRegistrosTabelasAuxiliares.SelectedRows.Count > 0)
            {
                var selectedRow = _form.dtgRegistrosTabelasAuxiliares.SelectedRows[0]; // Obtém a linha selecionada
                var idRegistro = Convert.ToInt32(selectedRow.Cells[0].Value); // obtém o valor do Id do Registro da linha selecionada
            }
            else
            {
                //_form.idRegistro = 0; // Define como 0 se nenhuma linha estiver selecionada
            }
        }
        //
        // Mostrar painel de visualização se a tabela selecionada for "Contratos"
        private void ExibirPainelVisualizacao()
        {
            // se panel não existir ele cria novo panel
            if (_form.pnlVisualizacao == null) // erro CS0122 
            {
                CriarPanelVisualizacao();
            }
            _form.pnlVisualizacao!.Visible = true;
            // ocupa o restante do pnlMeio com dtgRegistros
            _form.dtgRegistrosTabelasAuxiliares.Dock = DockStyle.Fill;
        }
        //
        // método para visualizar o arquivo de contrato em um WebBrowser
        private void VisualizarArquivoContrato(string filePath)
        {
            // se caminho estiver vazio return
            if (string.IsNullOrEmpty(filePath))
            {
                _form.pdfViewer!.Navigate("about:blank"); // Limpar a visualização em caso de erro
                return;
            }
            // se panel não existir ele cria novo panel
            if (_form.pnlVisualizacao == null) 
            {
                CriarPanelVisualizacao();
            }
            // se caminho existe
            if (File.Exists(filePath))
            {
                _form.pdfViewer!.Navigate(filePath);
            }
            else
            {
                MessageBox.Show("Arquivo do contrato não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FecharPanelVisualizacao();
                //_form.pdfViewer!.Navigate("about:blank"); // Limpar a visualização em caso de erro
            }
        }
        //
        // configurações do painel de visualização
        private void CriarPanelVisualizacao()
        {
            _form.pnlVisualizacao = new Panel 
            {
                Dock = DockStyle.Right,
                Width = 800,
                Padding = new Padding(5,5,5,5),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray
            };

            // Cria o botão de fechar
            Button btnClose = new Button
            {
                Text = "Fechar",
                //Dock = DockStyle.Top,
                Height = 30,
                //Margin = new Padding(10,10,0,0)
                Cursor = Cursors.Hand,
            };
            btnClose.Click += BtnClose_Click;

            _form.pdfViewer = new WebBrowser
            {
                Dock = DockStyle.Fill
            };

            // Adiciona o botão de fechar e o visualizador de PDF ao painel de visualização
            _form.pnlVisualizacao.Controls.Add(btnClose);
            _form.pnlVisualizacao.Controls.Add(_form.pdfViewer);

            // Adiciona o painel de visualização ao painel principal
            _form.pnlMeio.Controls.Add(_form.pnlVisualizacao);
        }
        //
        // Evento de clique do botão de fechar
        private void BtnClose_Click(object? sender, EventArgs e)
        {
            FecharPanelVisualizacao();
        }
        //
        // retorna a tabela selecionada
        public string TabelaSelecionada()
        {
            DataGridView dtgTabelas = (DataGridView)_form.dtgTabelasAuxiliares;
            if (dtgTabelas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgTabelas.SelectedRows[0]; // linha selecionada
                var tabelaSelecionada = selectedRow.Cells[0].Value?.ToString(); // nome da tabela selecionada

                return tabelaSelecionada ?? string.Empty;
            }
            return string.Empty;
        }
        //
        // MouseEnter e MouseLeave para dar feedback visual
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
        //
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
        // configurações específicas para dtg Itens
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

            dtg.Columns["Valor"].DefaultCellStyle.Format = "C2";
        }
        //
        // configurações específicas para dtg Espaços
        private void SetDtgRegistrosParaEspacos()
        {
            DataGridView dtg = _form.dtgRegistrosTabelasAuxiliares;
            dtg.Columns.Clear();
            myFunctions.ConfigurarAdicionarColuna(dtg, 0, "ID", 50, "", alignment: DataGridViewContentAlignment.MiddleCenter);
            myFunctions.ConfigurarAdicionarColuna(dtg, 1, "Nome", 220, "");
            dtg.Sort(dtg.Columns["Nome"], ListSortDirection.Ascending);
        }
        //
        // método central para carregar registros em dtgRegistrosTabelasAuxiliares
        private void CarregarRegistrosSEMUSO(string tabela)
        {
            var registros = ObterRegistros(tabela);
            _form.dtgRegistrosTabelasAuxiliares.Rows.Clear();

            foreach (var registro in registros)
            {
                // Adicione os registros ao DataGridView conforme necessário
            }
        }
        //
        // método para centralizar a execução da consulta dos repositórios
        private IEnumerable<dynamic> ObterRegistros(string tabela)
        {
            switch (tabela)
            {
                case "Itens das Festas":
                    return repItensFestasEF.GetItensFestas();

                case "Espaços":
                    return repEspacosEF.GetEspacos();

                case "Contratos":
                    return repContratosEF.GetContratos();
                
                case "Pacotes":
                    return repPacotesEF.GetPacotes();

                case "Status":
                    return repStatusEF.GetStatus();

                case "Temas":
                    return repTemasEF.GetTemas();

                case "Tipo de Eventos":
                    return repTipoEventoEF.GetTipoEvento();

                // Continue para outras tabelas...

                default:
                    return Enumerable.Empty<dynamic>();
            }
        }
        

    } // end class DataLoader
}
