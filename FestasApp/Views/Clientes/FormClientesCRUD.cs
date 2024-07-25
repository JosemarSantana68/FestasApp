//***********************************************************
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
//************************************************************

namespace FestasApp.Views.Clientes
{
    public partial class FormClientesCRUD : FormBaseCRUD
    {
        // objeto cliente instanciado da classe...
        private clsClientes cliente = new clsClientes();
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
                SetControls();
                AddToolStripEventHandlers();
            ResumeLayout(false);
        }
        // LOAD...
        // Associa o evento KeyDown ao formulário
        private void FormClientesCRUD_Load(object? sender, EventArgs e)
        {
            MostraDadosClienteEF();
        }
        //
        // Configura o formulário com base na operação
        private void SetThisForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            ConfigurarFormBaseCrud("C l i e n t e s", operacao);
            //lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            // Testa a operacao e configura os controles...
            switch (operacao)
            {
                case OperacaoCRUD.NOVO:
                    break;
                case OperacaoCRUD.EDITAR:
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
        private void MostraDadosClienteEF()
        {
            try
            {
                // instancia uma nova entidade...
                var cliente = new repClientesEF();
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
                    //myUtilities.myMessageBox(this, "Cliente não encontrado.\nMostraDadosClienteEF");
                }
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Erro ao preencher dados do cliente: {ex.Message}\nMostraDadosClienteEF");
            }
        }
        //
        // Adiciona eventos aos botões da ToolStrip
        private void AddToolStripEventHandlers()
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
                //EditarCliente();
            }
            else if (operacao == OperacaoCRUD.EXCLUIR)
            {
                DeletarCliente();
            }
        }
        //
        // NOVO cliente
        private void SalvarClienteEF()
        {
            try
            {


                // Verifica se houve mudança nos dados do cliente
                if (operacao == OperacaoCRUD.EDITAR && !VerificarCliente())
                {
                    myUtilities.myMessageBox(this, "Não houve nenhuma mudança nos dados do cliente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Verifica se os controles são válidos
                if (!ValidarControles())
                    return;

                // Grava os dados no cliente
                AtualizarClsCliente();

                // Salvar usando EF
                if (repClientesEF.SaveCliente(cliente))
                {
                    // Exibe mensagem de sucesso
                    myUtilities.myMessageBox(this, "Cliente salvo com sucesso!", "Novo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Exibe mensagem de erro
                    myUtilities.myMessageBox(this, "Falha ao Salvar Cliente!", "Novo Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException mysqlEx)
            {
                myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, ex.Message, "Cliente Novo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // Atualiza os dados do cliente com base nos controles do formulário
        private void AtualizarClsCliente()
        {
            // Transfere os dados dos controles para o objeto clsCliente
            cliente.cli_id = clienteId!.Value; // o Id passado como parametro do FormCadastro
            cliente.cli_nome = txtNome.Text;
            cliente.cli_telefone1 = txtTelefone1.Text;
            cliente.cli_telefone2 = txtTelefone2.Text;
            cliente.cli_cpf = txtCpf.Text;
            cliente.cli_endereco = txtEndereco.Text;
            cliente.cli_cep = txtCep.Text;
            cliente.cli_cidade = txtCidade.Text;
            cliente.cli_uf = txtUF.Text;
        }
        //
        // DELETAR cliente
        private void DeletarCliente()
        {
            try
            {
                // Grava os dados no cliente
                AtualizarClsCliente();

                // Exibe a mensagem de confirmação usando MessageBox.Show
                var message = $"""
                        Deseja Excluir o cliente
                        {cliente.cli_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
                var result = myUtilities.myMessageBox(this, message, "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    

                    // Chama o método para excluir o cliente
                    if (repClientesEF.DeleteClienteEF(cliente))
                    {
                        // Exibe a mensagem de sucesso usando a nova função myMessageBox
                        //myUtilities.myMessageBox(this, "Cliente excluído com sucesso!", "E x c l u i r", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Fecha o formulário após excluir
                        return;
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        myUtilities.myMessageBox(this, "Erro ao excluir cliente!", "Cliente Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, ex.Message, "Cliente Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // Método para validar os controles antes de salvar ou alterar
        private bool ValidarControles()
        {
            // Valida o campo Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                myUtilities.myMessageBox(this, "O nome do cliente é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }
            ////
            //// Valida o campo Telefones
            //if (string.IsNullOrWhiteSpace(txtTelefone1.Text) && string.IsNullOrWhiteSpace(txtTelefone2.Text))
            //{
            //    myUtilities.myMessageBox(this, "Um dos telefones do cliente é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtTelefone1.Focus();
            //    return false;
            //}
            ////
            //// Valida o campo Cpf
            //if (string.IsNullOrWhiteSpace(txtCpf.Text) || !myUtilities.ValidarCPF(txtCpf.Text))
            //{
            //    myUtilities.myMessageBox(this, "O Cpf é inválido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (cliente.cli_nome != txtNome.Text ||
                cliente.cli_telefone1 != txtTelefone1.Text ||
                cliente.cli_telefone2 != txtTelefone2.Text ||
                cliente.cli_cpf != txtCpf.Text ||
                cliente.cli_endereco != txtEndereco.Text ||
                cliente.cli_cep != txtCep.Text ||
                cliente.cli_cidade != txtCidade.Text ||
                cliente.cli_uf != txtUF.Text)
            {
                return true; // Houve mudança
            }
            return false; // Não houve mudança
        }

    } // end class
} // end namesoace
