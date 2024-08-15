//------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do módulo: 14/07/2024
//   Ultima Alteração: 14/07/2024
//   
//   FORMULÁRIO C.R.U.D. PARA AS TABELAS AUXILIARES
//
//------------------------------------------------------------


namespace FestasApp.Views.FestasTemas
{
    public partial class FormTemasFestas : FormBaseCRUD
    {
        /// <summary>
        /// declarar instâncias e variáveis
        /// </summary>
        private readonly repTemasEF _temaFestas = new();
        private readonly OperacaoCRUD _operacao = new();
        public clsFestasTemas _temaAtual = new();
        private clsParam _idRegistro = new();
        /// <summary>
        /// construtor com parâmetros
        /// </summary>
        /// <param name="idRegistro"></param>
        /// <param name="operacao"></param>
        public FormTemasFestas(clsParam idRegistro, OperacaoCRUD operacao)
        {
            InitializeComponent();
            this._idRegistro = idRegistro;
            this._operacao = operacao;

            SuspendLayout();
                ConfigurarFormBaseCrud("Temas Festas", _operacao);
                AddEventHandlers();
                SetControls();
            ResumeLayout();
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStatusCRUD_Load(object? sender, EventArgs e)
        {
            SuspendLayout();
                SetOperacao();
            ResumeLayout();
        }
        /// <summary>
        /// adiciona eventos handlers
        /// </summary>
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstBtnSalvar_Click;
            this.Load += FormStatusCRUD_Load;
        }
        /// <summary>
        ///  btn salvar temas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstBtnSalvar_Click(object? sender, EventArgs e)
        {
            // Testa a operacao e configura os salvar...
            switch (_operacao)
            {
                case OperacaoCRUD.NOVO:
                    SalvarRegistro();
                    break;
                case OperacaoCRUD.EDITAR:
                    SalvarRegistro();
                    break;
                case OperacaoCRUD.EXCLUIR:
                    DeletarRegistro();
                    break;
            }
        }
        /// <summary>
        /// método para salvar registros
        /// </summary>
        private async void SalvarRegistro()
        {
            var txtNome = this.pnlCentral.Controls["txtNome"] as myTextBox;
            var txtDescricao = this.pnlCentral.Controls["txtDescricao"] as myTextBox;

            // Validação dos controles - Verifica se todos os campos necessários estão preenchidos
            //ValidarForm();
            if (string.IsNullOrEmpty(txtNome!.Text) || string.IsNullOrEmpty(txtDescricao!.Text))
            {
                await myUtilities.myMessageBox(this, "Por favor, preencha todos os dados do Temas das Festas.", "Temas das Festas");
                return;
            }

            // Recupera os valores dos controles
            string nome = txtNome.Text ?? string.Empty;
            string descricao = txtDescricao.Text ?? string.Empty;

            // Cria uma instância da classe e salva os dados sem passar o ID
            clsFestasTemas item = new(nome, descricao);

            try
            {
                if (_operacao == OperacaoCRUD.NOVO)
                {
                    // Tenta adicionar novo item de festa ao banco de dados
                    if (repTemasEF.AddItem(item))
                    {
                        await myUtilities.myMessageBox(this, "Tema de Festas adicionado com sucesso!", "Temas de Festas");
                        _temaAtual = item;
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao adicionar o Tema de Festas.", "Temas de Festas");
                    }
                }
                else if (_operacao == OperacaoCRUD.EDITAR)
                {
                    // Tenta editar o item de festa no banco de dados
                    if (repTemasEF.AlterItem(_idRegistro.Id!.Value, item))
                    {
                        await myUtilities.myMessageBox(this, "Tema da Festas alterado com sucesso!", "Temas de Festas");
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao alterar o Tema da Festas.", "Temas de Festas");
                    }
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Falha ao salvar Tema. Erro: {ex.Message}\n\nEm:{ex.StackTrace}", "Temas de Festas");
            }
        }
        /// <summary>
        /// método para deletar registros
        /// </summary>
        private async void DeletarRegistro()
        {
            // Exibe a mensagem de confirmação usando MessageBox.Show
            var message = $"""
                        Deseja Excluir o Registro {_temaFestas.tema_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
            var result = await myUtilities.myMessageBox(this, message, "Excluir Tema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Chama o método para excluir o cliente
                    if (repTemasEF.DeleteItem(_idRegistro.Id!.Value))
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        await myUtilities.myMessageBox(this, "Erro ao excluir Tema da festas!", "Temas Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException mysqlEx)
                {
                    await myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}\n\nEm:{mysqlEx.StackTrace}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    await myUtilities.myMessageBox(this, $"{ex.Message}\n\nEm:{ex.StackTrace}", "Tema Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //
        /// <summary>
        /// Configura o formulário com base na tabela selecionada
        /// </summary>
        private void SetControls()
        {
            // Limpa os controles existentes
            this.pnlCentral.Controls.Clear();

            int lblCol = 40; // coluna do label
            int txtCol = lblCol + 100; // coluna do textbox
            int rowControl = 30; // mesma linha label e textbox

            // Definição das larguras dos TextBox
            int larguraNome = 200;
            int larguraDescricao = 300;


            Label lblNome = new Label { Text = "Tema:", Location = new Point(lblCol, rowControl) };
            myTextBox txtNome = new() { Location = new Point(txtCol, rowControl), Name = "txtNome", Width = larguraNome };
            //
            rowControl += rowControl; // espaço entre linhas
            //
            Label lblDescricao = new Label { Text = "Descrição:", Location = new Point(lblCol, rowControl) };
            myTextBox txtDescricao = new() { Location = new Point(txtCol, rowControl), Name = "txtDescricao", Width = larguraDescricao };

            this.pnlCentral.Controls.Add(lblNome);
            this.pnlCentral.Controls.Add(txtNome);
            this.pnlCentral.Controls.Add(lblDescricao);
            this.pnlCentral.Controls.Add(txtDescricao);

            // Calcula a altura necessária para acomodar todos os controles
            int alturaControles = rowControl + (rowControl); // margem top e botton extra

            // Calcula a largura necessária para acomodar o maior controle
            int larguraMaiorTextBox = Math.Max(larguraNome, larguraDescricao);
            int larguraMaiorLabel = new[] { lblNome.PreferredWidth, lblDescricao.PreferredWidth }.Max();
            int larguraTotal = lblCol + larguraMaiorLabel + larguraMaiorTextBox + (lblCol * 2); // margem extra left e right

            // Ajusta a altura do formulário
            this.Height = pnlTitulo.Height + alturaControles + pnlRodape.Height;

            // Ajusta a largura do formulário. com largura minima em 550
            this.Width = larguraTotal < 550 ? 550 : larguraTotal;
        }
        //
        /// <summary>
        /// Configura a operação informada
        /// </summary>
        private void SetOperacao()
        {
            // Testa a operacao e configura os controles...
            switch (_operacao)
            {
                case OperacaoCRUD.NOVO:
                    _idRegistro.Id = 0;
                    //MostrarItemFesta();
                    break;
                case OperacaoCRUD.EDITAR:
                    MostrarRegistro();
                    break;
                case OperacaoCRUD.EXCLUIR:
                    //TravarControles();
                    MostrarRegistro();
                    break;
                case OperacaoCRUD.CONSULTAR:
                    //TravarControles();
                    MostrarRegistro();
                    break;
            }
        }
        //
        /// <summary>
        /// mostra dados do registro selecionado
        /// </summary>
        private async void MostrarRegistro()
        {
            try
            {
                // captura tema da tabela
                var item = _temaFestas.GetItem(_idRegistro.Id!.Value);

                if (item != null)
                {
                    myTextBox? txtNome = this.pnlCentral.Controls["txtNome"] as myTextBox;
                    myTextBox? txtDescricao = this.pnlCentral.Controls["txtDescricao"] as myTextBox;

                    if (txtNome != null)
                    {
                        txtNome.Text = item.tema_nome;
                        int maxLength = myFunctions.GetMaxLength("tblfestastemas", "tema_nome"); // conferir tabela
                        if (maxLength > 0) txtNome.MaxLength = maxLength;
                    }

                    if (txtDescricao != null)
                    {
                        txtDescricao.Text = item.tema_descricao;
                        int maxLength = myFunctions.GetMaxLength("tblfestastemas", "tema_descricao");
                        if (maxLength > 0) txtDescricao.MaxLength = maxLength;
                    }
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao preencher dados do Tema: {ex.Message}\n\nEm: {ex.StackTrace}");
            }
        }

    } // end class FormTemasFestas : FormBaseCRUD
} // end namespace FestasApp.Views.FestasTemas
