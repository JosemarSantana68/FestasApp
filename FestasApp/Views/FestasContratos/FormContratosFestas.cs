//------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do módulo: 04/08/2024
//   Ultima Alteração: 04/08/2024
//   
//   FORMULÁRIO DE C.R.U.D. PARA AS TABELAS AUXILIARES
//
//------------------------------------------------------------
//

namespace FestasApp.Views.FestasContratos
{
    public partial class FormContratosFestas : FormBaseCRUD
    {
        /// <summary>
        /// instâncias e variaveis
        /// </summary>
        private readonly repContratosEF _contrato = new();
        private readonly OperacaoCRUD _operacao = new();
        private clsParam _idContrato = new();
        public clsFestasContratos _contratoAtual = new();

        /// <summary>
        /// construtor padrão
        /// </summary>
        /// <param name="idContrato"></param>
        /// <param name="operacao"></param>
        public FormContratosFestas(clsParam idContrato, OperacaoCRUD operacao)
        {
            InitializeComponent();
            _idContrato = idContrato;
            _operacao = operacao;

            SuspendLayout();
            ConfigurarFormBaseCrud("C o n t r a t o s", operacao);
            AddEventHandlers();
            SetControls();
            ResumeLayout();
        }
        /// <summary>
        /// método para adicionar eventos handlers
        /// </summary>
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstBtnSalvar_Click;
            this.Load += FormContratosCRUD_Load;
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormContratosCRUD_Load(object? sender, EventArgs e)
        {
            SuspendLayout();
            SetOperacao();
            ResumeLayout();
        }
        /// <summary>
        /// método para salvar
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
        /// 
        /// </summary>
        private void SetOperacao()
        {
            // Testa a operacao e configura os controles...
            switch (_operacao)
            {
                case OperacaoCRUD.NOVO:
                    _idContrato.Id = 0;
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
        /// <summary>
        /// mostra dados do registro selecionado
        /// </summary>
        private async void MostrarRegistro()
        {
            try
            {
                var item = _contrato.GetItem(_idContrato.Id!.Value);

                if (item != null)
                {
                    txtNome.Text = item.ctt_nome;
                    txtPath.Text = item.ctt_caminho_arquivo;
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao preencher dados do Tema: {ex.Message}\n\nLocal do erro: {ex.StackTrace}");
            }
        }
        /// <summary>
        /// Configura o formulário com base na tabela selecionada
        /// </summary>
        private void SetControls()
        {
            // txtNome
            int maxLengthNome = myFunctions.GetMaxLength("tblfestascontratos", "ctt_nome");
            if (maxLengthNome > 0) txtNome.MaxLength = maxLengthNome;
            // txtPath
            int maxLengthPath = myFunctions.GetMaxLength("tblfestascontratos", "ctt_caminho_arquivo");
            if (maxLengthPath > 0) txtPath.MaxLength = maxLengthPath;
        }
        /// <summary>
        /// método para salvar registros
        /// </summary>
        private async void SalvarRegistro()
        {
            // Validação dos controles - Verifica se todos os campos necessários estão preenchidos
            //ValidarForm();

            if (string.IsNullOrEmpty(txtNome!.Text) || string.IsNullOrEmpty(txtPath!.Text))
            {
                await myUtilities.myMessageBox(this, "Por favor, preencha nome do Contrato das Festas.", "Contratos das Festas");
                return;
            }

            // Recupera os valores dos controles
            string nome = txtNome.Text ?? string.Empty;
            string path = txtPath.Text ?? string.Empty;

            // Cria uma instância da classe e salva os dados sem passar o ID
            clsFestasContratos item = new(nome, path);

            try
            {
                if (_operacao == OperacaoCRUD.NOVO)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repContratosEF.AddItem(item))
                    {
                        await myUtilities.myMessageBox(this, "Contrato de Festas adicionado com sucesso!", "Contratos de Festas");
                        _contratoAtual = item;
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao adicionar o Contrato de Festas.", "Contratos de Festas");
                    }
                }
                else if (_operacao == OperacaoCRUD.EDITAR)
                {
                    // Tenta alterar o contrato de festa ao banco de dados
                    if (repContratosEF.AlterItem(_idContrato.Id!.Value, item))
                    {
                        await myUtilities.myMessageBox(this, "Contrato de Festas alterado com sucesso!", "Contratos de Festas");
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao alterar o Contrato da Festas.", "Contratos de Festas");
                    }
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Falha ao salvar Contrato da Festa. Erro: {ex.Message}\n\nLocal do erro: {ex.StackTrace}", "Contratos de Festas");
            }
        }
        /// <summary>
        /// método para deletar registros
        /// </summary>
        private async void DeletarRegistro()
        {
            // Exibe a mensagem de confirmação usando MessageBox.Show
            var message = $"""
                        Deseja Excluir o Contrato {_contrato.ctt_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
            var result = await myUtilities.myMessageBox(this, message, "Excluir Contrato", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Chama o método para excluir o cliente
                    if (repContratosEF.DeleteItem(_idContrato.Id!.Value))
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        await myUtilities.myMessageBox(this, "Erro ao excluir Contrato da festas!", "Contratos Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException mysqlEx)
                {
                    await myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}\n\nEm: {mysqlEx.StackTrace}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    await myUtilities.myMessageBox(this, $"{ex.Message}\n\nEm: {ex.StackTrace}", "Contratos Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// método para buscar caminho do arquivo pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = openFileDialog.FileName;
                }
            }

        }
        /// <summary>
        /// Método para fazer o upload do arquivo PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = txtPath.Text;

                if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                {
                    await myUtilities.myMessageBox(this, "Por favor, selecione um arquivo válido.", "Carregar Arquivo");
                    return;
                }

                string newPath = repContratosEF.UploadContratoNovo(filePath);

                await myUtilities.myMessageBox(this, $"Arquivo carregado com sucesso.\n\nCaminho: {newPath}", "Carregar Arquivo");
            }
            catch (Exception ex)
            {
                // Exibir mensagem de erro com a pilha de chamadas
                await myUtilities.myMessageBox(this, $"Erro ao carregar o arquivo: {ex.Message}\n\nLocal do erro: {ex.StackTrace}", "Carregar Arquivo");
            }
        }
        //

    } // end class FormContratos : FormBaseCRUD
} // end namespace FestasApp.Views.FestasContratos
