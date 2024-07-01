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
        private clsClientes cliente;
        private OperacaoCRUD operacao;
        //
        // Construtor que aceita um objeto clsClientes e a operação
        public FormClientesCRUD(clsClientes _cliente, OperacaoCRUD _operacao)
        {
            InitializeComponent();
            // Recebe o cliente e a operação passados por parâmetro
            this.cliente = _cliente;
            this.operacao = _operacao;

            SuspendLayout();
                ConfigurarFormBaseCrud("C l i e n t e s", operacao);
                SetThisForm();
                SetControls();
                AddToolStripEventHandlers();
                PreencherControlesComDadosCliente();
            ResumeLayout(false);
        }
        // LOAD...
        // Associa o evento KeyDown ao formulário
        private void FormClientesCRUD_Load(object sender, EventArgs e)
        {
            
        }
        //
        // Configura o formulário com base na operação
        private void SetThisForm()
        {
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
         private void SetControls()
        {
            txtNome.MaxLength = 100;
            txtEndereco.MaxLength = 100;
            txtCidade.MaxLength = 100;
            txtUF.MaxLength = 20;
        }
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
        // Método para carregar os dados do cliente(recebido no parâmetro) nos controles do formulário
        private void PreencherControlesComDadosCliente()
        {
            if (cliente != null)
            {
                // Preenche os controles do formulário com os dados do cliente
                lblID.Text = cliente.cli_id.ToString();
                txtNome.Text = cliente.cli_nome;
                txtTelefone1.Text = cliente.cli_telefone1;
                txtTelefone2.Text = cliente.cli_telefone2;
                txtCpf.Text = cliente.cli_cpf;
                txtEndereco.Text = cliente.cli_endereco;
                txtCep.Text = cliente.cli_cep;
                txtCidade.Text = cliente.cli_cidade;
                txtUF.Text = cliente.cli_uf;
            }
        }
        //
        // Adiciona eventos aos botões da ToolStrip
        private void AddToolStripEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
        }
        //
        // Evento click do botão SALVAR...
        private void TstbtnSalvar_Click(object? sender, EventArgs e)
        {
            if (operacao == OperacaoCRUD.NOVO)
            {
                SalvarNovoCliente();
            }
            else if (operacao == OperacaoCRUD.EDITAR)
            {
                EditarCliente();
            }
            else if (operacao == OperacaoCRUD.EXCLUIR)
            {
                DeletarCliente();
            }
        }
        //
        // NOVO cliente
        private void SalvarNovoCliente()
        {
            try
            {
                // Verifica se os controles são válidos
                if (!ValidarControles())
                    return;

                // Grava os dados do cliente
                AtualizarClsCliente();

                // Tenta inserir o novo cliente
                if (cliente.CreateCliente())
                {
                    // Exibe a mensagem de sucesso usando a nova função myMessageBox
                    myUtilities.myMessageBox(this, $"Cliente {cliente.cli_nome}\n salvo com sucesso!", "A d i c i o n a r", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close(); // Fecha o formulário após salvar
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
        // EDITAR cliente
        private void EditarCliente()
        {
            try
            {
                // Verifica se houve mudança nos dados do cliente
                if (!ValidarCliente())
                {
                    myUtilities.myMessageBox(this, "Não houve nenhuma mudança nos dados do cliente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Verifica se os controles são válidos
                if (!ValidarControles())
                    return;

                // Grava os dados do cliente
                AtualizarClsCliente();

                // Tenta salvar o cliente e exibe mensagem de sucesso se bem-sucedido
                if (cliente.UpdateCliente())
                {
                    // Exibe a mensagem de sucesso usando a nova função myMessageBox
                    var message = $"""
                                Cliente {cliente.cli_nome}

                                Alterado com sucesso!
                                """;
                    myUtilities.myMessageBox(this, message, "A l t e r a r", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha o formulário após salvar 
                }
            }
            catch (MySqlException mysqlEx)
            {
                myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, ex.Message, "Cliente Alterar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // DELETAR cliente
        private void DeletarCliente()
        {
            try
            {
                // Exibe a mensagem de confirmação usando MessageBox.Show
                var message = $"""
                        Deseja Excluir o cliente
                        {cliente.cli_nome}?
                        
                        Esta ação não poderá ser desfeita!
                        """;
                var result = myUtilities.myMessageBox(this, message, "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Chama o método para excluir o cliente
                    if (cliente.DeleteCliente())
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
        //***********************************************************************
        private void TstbtnSalvar_ClickSEMUSO(object? sender, EventArgs e)
        {
            // Verifica a operação: NOVO, EDITAR ou EXCLUIR
            if (operacao == OperacaoCRUD.NOVO || operacao == OperacaoCRUD.EDITAR)
            {
                try
                {
                    //
                    // Se a operação for "NOVO"
                    if (operacao == OperacaoCRUD.NOVO)
                    {
                        // Verifica se os controles são válidos
                        if (!ValidarControles())
                            return;

                        // Grava os dados do cliente
                        AtualizarClsCliente();

                        // Tenta inserir o novo cliente
                        if (cliente.CreateCliente())
                        {
                            // Exibe a mensagem de sucesso usando a nova função myMessageBox
                            myUtilities.myMessageBox(this, $"Cliente {cliente.cli_nome}\n salvo com sucesso!", "A d i c i o n a r", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.Close(); // Fecha o formulário após salvar
                        }
                    }
                    //
                    // Se a operação for "EDITAR"
                    else if (operacao == OperacaoCRUD.EDITAR)
                    {
                        // Verifica se houve mudança nos dados do cliente
                        if (!ValidarCliente())
                        {
                            myUtilities.myMessageBox(this,"Não houve nenhuma mudança nos dados do cliente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Verifica se os controles são válidos
                        if (!ValidarControles())
                            return;

                        // Grava os dados do cliente
                        AtualizarClsCliente();

                        // Tenta salvar o cliente e exibe mensagem de sucesso se bem-sucedido
                        if (cliente.UpdateCliente())
                        {
                            // Exibe a mensagem de sucesso usando a nova função myMessageBox
                            var message = $"""
                                Cliente {cliente.cli_nome}

                                Salvo com sucesso!
                                """;

                            myUtilities.myMessageBox(this, message, "S a l v a r", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close(); // Fecha o formulário após salvar 
                            //return;
                        }
                    }
                }
                catch (MySqlException mysqlEx)
                {
                    myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    myUtilities.myMessageBox(this, ex.Message, "Cliente Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Se a operação for "EXCLUIR"
            else if (operacao == OperacaoCRUD.EXCLUIR)
            {
                try
                {
                    // Exibe a mensagem de confirmação usando MessageBox.Show
                    var message = $"""
                        Deseja Excluir o cliente
                        {cliente.cli_nome}?
                        
                        Esta ação não poderá ser desfeita."
                        """;
                    var result = myUtilities.myMessageBox(this, message, "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Chama o método para excluir o cliente
                        if (cliente.DeleteCliente())
                        {
                            // Exibe a mensagem de sucesso usando a nova função myMessageBox
                            //myUtilities.myMessageBox(this, "Cliente excluído com sucesso!", "E x c l u i r", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close(); // Fecha o formulário após excluir
                            return;
                        }
                        else
                        {
                            // Exibe a mensagem de erro se a exclusão falhar
                            myUtilities.myMessageBox(this, "Erro ao excluir cliente!", "E r r o", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Trata outras exceções e exibe mensagem de erro
                    myUtilities.myMessageBox(this, $"Erro: {ex.Message}", "E r r o", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //
        // Atualiza os dados do cliente com base nos controles do formulário
        private void AtualizarClsCliente()
        {
            // Transfere os dados dos controles para o objeto clsCliente
            //cliente.Id = Convert.ToInt32(lblID.Text);
            cliente.cli_nome    = txtNome.Text;
            cliente.cli_telefone1 = txtTelefone1.Text;
            cliente.cli_telefone2 = txtTelefone2.Text;
            cliente.cli_cpf = txtCpf.Text;
            cliente.cli_endereco = txtEndereco.Text;
            cliente.cli_cep = txtCep.Text;
            cliente.cli_cidade = txtCidade.Text;
            cliente.cli_uf = txtUF.Text;
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
            //
            // Valida o campo Telefones
            if (string.IsNullOrWhiteSpace(txtTelefone1.Text) && string.IsNullOrWhiteSpace(txtTelefone2.Text))
            {
                myUtilities.myMessageBox(this, "Um dos telefones do cliente é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefone1.Focus();
                return false;
            }
            //
            // Valida o campo Cpf
            if (string.IsNullOrWhiteSpace(txtCpf.Text) || !myUtilities.ValidarCPF(txtCpf.Text))
            {
                myUtilities.myMessageBox(this, "O Cpf é inválido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpf.Focus();
                return false;
            }
            // Se todas as validações passarem, retorna verdadeiro
            return true;
        }
        //
        // Método para validar se houve alguma alteração nos dados do clsCliente
        private bool ValidarCliente()
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
