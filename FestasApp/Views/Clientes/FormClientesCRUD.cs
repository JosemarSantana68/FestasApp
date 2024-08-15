//------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do módulo: 23/05/2024
//   Ultima Alteração: 24/06/2024
//   
//   FORMULÁRIO DE CLIENTES - C.R.U.D.
//
//------------------------------------------------------------

namespace FestasApp.Views.Clientes
{
    public partial class FormClientesCRUD : FormBaseCRUD
    {
        //  objeto cliente instanciado da classe...
        //  public clsClientes ClienteAtual { get; private set; } = new();
        private OperacaoCRUD _operacao;
        private clsParam? _clienteId;
        public ClientesViewModel _viewModel { get; private set; } = new();
        
        //
        /// <summary>
        /// Construtor que aceita um objeto clsClientes e a operação
        /// </summary>
        /// <param name="_clienteId"></param>
        /// <param name="_operacao"></param>
        public FormClientesCRUD(clsParam _clienteId, OperacaoCRUD _operacao)
        {
            InitializeComponent();
            // Recebe o cliente e a operação passados por parâmetro
            this._clienteId = _clienteId;
            this._operacao = _operacao;
            //this._viewModel = new ClientesViewModel();

            // Carrega o cliente específico baseado no ID, se disponível
            if (_clienteId.Id != null)
            {
                _viewModel.ClienteSelecionado = _viewModel.GetCliente(_clienteId.Id!.Value);
            }

            SuspendLayout();
                SetThisForm();
                AddEventHandlers();
            ResumeLayout(false);
        }
        /// <summary>
        /// LOAD...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClientesCRUD_Load(object? sender, EventArgs e)
        {
            SetControls();
            SetOperacao();
        }
        //
        /// <summary>
        /// Configura o formulário com base na operação
        /// </summary>
        private void SetThisForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            ConfigurarFormBaseCrud("C l i e n t e s", _operacao);
            //lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }
        /// <summary>
        /// Configura controles do Form
        /// </summary>
        private void SetControls()
        {
            // maxLength de acordo com os tamanhos dos campos na tabela
            txtNome.MaxLength = 100;
            txtEndereco.MaxLength = 100;
            txtCidade.MaxLength = 100;
            txtUF.MaxLength = 20;
            txtTelefone1.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtTelefone2.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCpf.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCep.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }
        /// <summary>
        /// Chama os métodos de acordo com a operação
        /// </summary>
        private void SetOperacao()
        {
            // Testa a operacao e configura os controles...
            switch (_operacao)
            {
                case OperacaoCRUD.NOVO:
                    break;
                case OperacaoCRUD.EDITAR: 
                    MostraDadosClienteEF(); 
                    break;
                case OperacaoCRUD.CONSULTAR:
                    MostraDadosClienteEF();
                    TravarControles();
                    break;
                case OperacaoCRUD.EXCLUIR:
                    MostraDadosClienteEF();
                    TravarControles();
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void TravarControles()
        {
            txtNome.ReadOnly = true;
            txtTelefone1.ReadOnly = true;
            txtTelefone2.ReadOnly = true;
            txtCpf.ReadOnly = true;
            txtEndereco.ReadOnly = true;
            txtCep.ReadOnly = true;
            txtCidade.ReadOnly = true;
            txtUF.ReadOnly = true;
        }
        //
        /// <summary>
        /// Método para carregar os dados do cliente nos controles do formulário
        /// </summary>
        private async void MostraDadosClienteEF()
        {
            try
            {
                // Usa o ViewModel para buscar o cliente
                //var clienteEncontrado = _viewModel.GetCliente(_clienteId!.Id!.Value);

                var clienteEncontrado = _viewModel.ClienteSelecionado;

                if (clienteEncontrado != null)
                {
                    //this.ClienteAtual = clienteEncontrado;

                    // Preenche os controles do formulário com os dados do cliente
                    lblID.Text = clienteEncontrado.cli_id.ToString();
                    txtNome.Text = clienteEncontrado.cli_nome;
                    txtTelefone1.Text = clienteEncontrado.cli_telefone1;
                    txtTelefone2.Text = clienteEncontrado.cli_telefone2;
                    txtCpf.Text = clienteEncontrado.cli_cpf;
                    txtEndereco.Text = clienteEncontrado.cli_endereco;
                    txtCep.Text = clienteEncontrado.cli_cep;
                    txtCidade.Text = clienteEncontrado.cli_cidade;
                    txtUF.Text = clienteEncontrado.cli_uf;
                }
                else
                {
                    lblID.Text = _clienteId!.Id.ToString();
                    //await myUtilities.myMessageBox(this, "Cliente não encontrado.\nMostraDadosClienteEF");
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao preencher dados do cliente: {ex.Message}\nMostraDadosClienteEF");
            }
        }
        //
        /// <summary>
        /// Adiciona eventos aos botões da ToolStrip
        /// </summary>
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
            this.Load += FormClientesCRUD_Load;
        }
        //
        /// <summary>
        /// Evento click do botão SALVAR...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TstbtnSalvar_Click(object? sender, EventArgs e)
        {
            if (_operacao == OperacaoCRUD.NOVO)
            {
                SalvarClienteEF();
            }
            else if (_operacao == OperacaoCRUD.EDITAR)
            {
                SalvarClienteEF();
            }
            else if (_operacao == OperacaoCRUD.EXCLUIR)
            {
                DeletarCliente();
            }
        }
        //
        /// <summary>
        /// NOVO e EDITAR cliente
        /// </summary>
        private async void SalvarClienteEF()
        {
            try
            {
                // Verifica se houve mudança nos dados do cliente
                if (_operacao == OperacaoCRUD.EDITAR && !VerificarCliente())
                {
                    await myUtilities.myMessageBox(this, "Não houve nenhuma mudança nos dados do cliente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Verifica se os controles são válidos
                bool isValidControls = await ValidarControles();
                if (!isValidControls)
                    return;

                // Grava os dados do formulário no _viewModel.ClienteSelecionado
                AtualizarClsCliente();

                // validar cliente em viewModel
                bool isValidObject = await ValidarCliente();
                if (!isValidObject)
                {
                    // Exibe mensagem de erro ou toma outra ação necessária
                    return;
                }

                // Salvar usando viewModel, NOVO ou EDITA.
                if (_viewModel.SaveCliente(_viewModel.ClienteSelecionado!))
                {
                    // Exibe mensagem de sucesso
                    await myUtilities.myMessageBox(this, "Cliente salvo com sucesso!", "Novo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    // Exibe mensagem de erro
                    await myUtilities.myMessageBox(this, "Falha ao Salvar Cliente!", "Novo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException mysqlEx)
            {
                await myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, ex.Message, "Cliente Novo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Valida Cliente usando Data Annotation
        /// </summary>
        /// <param name="clienteAtual"></param>
        /// <returns></returns>
        private async Task<bool> ValidarCliente()
        {
            //var erros = clsValidator.isValidObject(_viewModel.ClienteSelecionado!);
            
            var erros = _viewModel.ErrosValidacao;

            var camposInvalidos = string.Empty;

            // lista de erros
            foreach (var erro in erros)
            {
                camposInvalidos += erro + "\n";
                break;
            }
            // se encontrar erros
            if (!string.IsNullOrEmpty(camposInvalidos))
            {
                await myUtilities.myMessageBox(this, mensagem: camposInvalidos, "Data Anottation");
                return false;
            }
            return true;
        }
        //
        /// <summary>
        /// Atualiza os dados do cliente com base nos controles do formulário
        /// </summary>
        private void AtualizarClsCliente()
        {
            // se não é novo cliente, atribui o id para o objeto
            if (_operacao != OperacaoCRUD.NOVO)
                _viewModel.ClienteSelecionado!.cli_id = _clienteId!.Id!.Value;
            else // se NOVO declara um objeto novo vazio
                _viewModel.ClienteSelecionado = new();

            // Transfere os dados dos controles para o objeto
            _viewModel.ClienteSelecionado.cli_nome = txtNome.Text;
            _viewModel.ClienteSelecionado.cli_telefone1 = txtTelefone1.Text;
            _viewModel.ClienteSelecionado.cli_telefone2 = txtTelefone2.Text;
            _viewModel.ClienteSelecionado.cli_cpf = txtCpf.Text;
            _viewModel.ClienteSelecionado.cli_endereco = txtEndereco.Text;
            _viewModel.ClienteSelecionado.cli_cep = txtCep.Text;
            _viewModel.ClienteSelecionado.cli_cidade = txtCidade.Text;
            _viewModel.ClienteSelecionado.cli_uf = txtUF.Text;
        }
        //
        /// <summary>
        /// DELETAR cliente
        /// </summary>
        private async void DeletarCliente()
        {
            try
            {
                // Grava os dados no cliente
                AtualizarClsCliente();

                // Verifica se o cliente tem festas associadas
                using (clsFestasContext context = new())
                {
                    bool temFestasAssociadas = context.Festas.Any(f => f.fest_cli_id == _viewModel.ClienteSelecionado!.cli_id);

                    if (temFestasAssociadas)
                    {
                        await myUtilities.myMessageBox(this, "Não é possível excluir o cliente, pois ele está associado a uma ou mais festas.", "Exclusão Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                // Exibe a mensagem de confirmação usando MessageBox.Show
                var message = $"""
                        Deseja Excluir o cliente {_viewModel.ClienteSelecionado!.cli_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
                var result = await myUtilities.myMessageBox(this, message, "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Chama o método para excluir o cliente
                    if (_viewModel.DeleteCliente(_viewModel.ClienteSelecionado!))
                    {
                        // Exibe a mensagem de sucesso usando a nova função myMessageBox
                        //await myUtilities.myMessageBox(this, "Cliente excluído com sucesso!", "E x c l u i r", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Close(); // Fecha o formulário após excluir
                        return;
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        await myUtilities.myMessageBox(this, "Erro ao excluir cliente!", "Cliente Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                await myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, ex.Message, "Cliente Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        /// <summary>
        /// Método para validar os controles antes de salvar ou alterar
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ValidarControles()
        {
            // Valida o campo Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                await myUtilities.myMessageBox(this, "O nome do cliente é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }

            //// Valida o campo Telefones // if (txtTelefone1.Text.Length != 11)
            //if (string.IsNullOrWhiteSpace(txtTelefone1.Text) && string.IsNullOrWhiteSpace(txtTelefone2.Text))
            //{
            //    await myUtilities.myMessageBox(this, "Um dos telefones do cliente é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtTelefone1.Focus();
            //    return false;
            //}

            //// Valida o campo Cpf
            //if (string.IsNullOrWhiteSpace(txtCpf.Text) || !myUtilities.ValidarCPF(txtCpf.Text))
            //{
            //    await myUtilities.myMessageBox(this, "O Cpf é inválido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtCpf.Focus();
            //    return false;
            //}

            // Se todas as validações passarem, retorna verdadeiro
            return true;
        }
        //
        /// <summary>
        /// Método para validar se houve alguma alteração nos dados do Cliente
        /// </summary>
        /// <returns></returns>
        private bool VerificarCliente()
        {
            // Compara os dados do cliente com os controles do formulário
            if (_viewModel.ClienteSelecionado!.cli_nome != txtNome.Text ||
                _viewModel.ClienteSelecionado!.cli_telefone1 != txtTelefone1.Text ||
                _viewModel.ClienteSelecionado!.cli_telefone2 != txtTelefone2.Text ||
                _viewModel.ClienteSelecionado!.cli_cpf != txtCpf.Text ||
                _viewModel.ClienteSelecionado!.cli_endereco != txtEndereco.Text ||
                _viewModel.ClienteSelecionado!.cli_cep != txtCep.Text ||
                _viewModel.ClienteSelecionado!.cli_cidade != txtCidade.Text ||
                _viewModel.ClienteSelecionado!.cli_uf != txtUF.Text)
            {
                return true; // Houve mudança
            }
            return false; // Não houve mudança
        }
        //

    } // end class
} // end namesoace
