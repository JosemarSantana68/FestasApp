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
        // objeto cliente instanciado da classe...
        public clsClientes ClienteAtual { get; private set; } = new();
        private OperacaoCRUD operacao;
        private int? clienteId;
        //
        // Construtor que aceita um objeto clsClientes e a operação
        public FormClientesCRUD(clsParam _clienteId, OperacaoCRUD _operacao)
        {
            InitializeComponent();
            // Recebe o cliente e a operação passados por parâmetro
            this.clienteId = _clienteId.Id;
            this.operacao = _operacao;

            SuspendLayout();
                SetThisForm();
                AddEventHandlers();
            ResumeLayout(false);
        }
        // LOAD...
        // Associa o evento KeyDown ao formulário
        private void FormClientesCRUD_Load(object? sender, EventArgs e)
        {
            SetControls();
            SetOperacao();
        }
        //
        // Configura o formulário com base na operação
        private void SetThisForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            ConfigurarFormBaseCrud("C l i e n t e s", operacao);
            //lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }
        //
        private void SetControls()
        {
            txtNome.MaxLength = 100;
            txtEndereco.MaxLength = 100;
            txtCidade.MaxLength = 100;
            txtUF.MaxLength = 20;
            txtTelefone1.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtTelefone2.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCpf.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCep.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }
        //
        private void SetOperacao()
        {
            // Testa a operacao e configura os controles...
            switch (operacao)
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
        //
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
        // Método para carregar os dados do cliente nos controles do formulário
        private async void MostraDadosClienteEF()
        {
            try
            {
                // instancia uma nova entidade...
                repClientesEF cliente = new();
                var clienteEncontrado = cliente.GetCliente(clienteId!.Value);

                if (clienteEncontrado != null)
                {
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
                    lblID.Text = clienteId.ToString();
                    //await myUtilities.myMessageBox(this, "Cliente não encontrado.\nMostraDadosClienteEF");
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao preencher dados do cliente: {ex.Message}\nMostraDadosClienteEF");
            }
        }
        //
        // Adiciona eventos aos botões da ToolStrip
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
            this.Load += FormClientesCRUD_Load;
        }
        //
        // Evento click do botão SALVAR...
        private void TstbtnSalvar_Click(object? sender, EventArgs e)
        {
            if (operacao == OperacaoCRUD.NOVO)
            {
                SalvarClienteEF();
            }
            else if (operacao == OperacaoCRUD.EDITAR)
            {
                SalvarClienteEF();
            }
            else if (operacao == OperacaoCRUD.EXCLUIR)
            {
                DeletarCliente();
            }
        }
        //
        // NOVO e EDITAR cliente
        private async void SalvarClienteEF()
        {
            try
            {
                // Verifica se houve mudança nos dados do cliente
                if (operacao == OperacaoCRUD.EDITAR && !VerificarCliente())
                {
                    await myUtilities.myMessageBox(this, "Não houve nenhuma mudança nos dados do cliente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                bool isValid = await ValidarControles();
                // Verifica se os controles são válidos
                if (!isValid)
                    return;

                // Grava os dados do formulário no ClienteAtual
                AtualizarClsCliente();

                // Salvar usando EF, NOVO ou EDITA.
                if (repClientesEF.SaveCliente(ClienteAtual))
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
        //
        // Atualiza os dados do cliente com base nos controles do formulário
        private void AtualizarClsCliente()
        {
            // Transfere os dados dos controles para o objeto clsCliente
            if (operacao != OperacaoCRUD.NOVO) 
                ClienteAtual.cli_id = clienteId!.Value; // o Id passado como parametro do FormCadastro

            ClienteAtual.cli_nome = txtNome.Text;
            ClienteAtual.cli_telefone1 = txtTelefone1.Text;
            ClienteAtual.cli_telefone2 = txtTelefone2.Text;
            ClienteAtual.cli_cpf = txtCpf.Text;
            ClienteAtual.cli_endereco = txtEndereco.Text;
            ClienteAtual.cli_cep = txtCep.Text;
            ClienteAtual.cli_cidade = txtCidade.Text;
            ClienteAtual.cli_uf = txtUF.Text;
        }
        //
        // DELETAR cliente
        private async void DeletarCliente()
        {
            try
            {
                // Grava os dados no cliente
                AtualizarClsCliente();

                // Exibe a mensagem de confirmação usando MessageBox.Show
                var message = $"""
                        Deseja Excluir o cliente {ClienteAtual.cli_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
                var result = await myUtilities.myMessageBox(this, message, "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Chama o método para excluir o cliente
                    if (repClientesEF.DeleteClienteEF(ClienteAtual))
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
        // Método para validar os controles antes de salvar ou alterar
        private async Task<bool> ValidarControles()
        {
            // Valida o campo Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                await myUtilities.myMessageBox(this, "O nome do cliente é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }
            
            //// Valida o campo Telefones
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
        // Método para validar se houve alguma alteração nos dados do clsCliente
        private bool VerificarCliente()
        {
            // Compara os dados do cliente com os controles do formulário
            if (ClienteAtual.cli_nome != txtNome.Text ||
                ClienteAtual.cli_telefone1 != txtTelefone1.Text ||
                ClienteAtual.cli_telefone2 != txtTelefone2.Text ||
                ClienteAtual.cli_cpf != txtCpf.Text ||
                ClienteAtual.cli_endereco != txtEndereco.Text ||
                ClienteAtual.cli_cep != txtCep.Text ||
                ClienteAtual.cli_cidade != txtCidade.Text ||
                ClienteAtual.cli_uf != txtUF.Text)
            {
                return true; // Houve mudança
            }
            return false; // Não houve mudança
        }

    } // end class
} // end namesoace
