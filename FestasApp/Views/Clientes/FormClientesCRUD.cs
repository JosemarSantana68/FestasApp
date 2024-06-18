//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 06/06/2024
//   
//   FORMULÁRIO DE CLIENTE C.R.U.D.
//
//************************************************************

using FestasApp.Enums;
using FestasApp.ViewModels; // Importa o namespace do pai, IMPORTANTE
using MyFramework.myCodes;
using MySql.Data.MySqlClient;

namespace FestasApp.Views.Clientes
{
    public partial class FormClientesCRUD : FormBaseCRUD
    {
        //
        // Instância única do FormClientesCRUD
        //public static FormClientesCRUD? Instance { get; private set; }

        // variaveis...

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
            //Instance = this; // Define a instância atual como a instância única

            SuspendLayout();

            ConfigurarForm();
            ConfigurarControles();
            AddToolStripEventHandlers();
            CarregaDadosCliente();

            ResumeLayout(false);
        }
        //----------------------
        // LOAD...
        // Associa o evento KeyDown ao formulário
        private void FormClientesCRUD_Load(object sender, EventArgs e)
        {
            //this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(FormClientesCRUD_KeyDown);
        }
        //
        // Configura o formulário com base na operação
        private void ConfigurarForm()
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            lblTitulo.Text = "C a d a s t r o  d e   C l i e n t e s";
            lblOperacao.Text = "";

            // Testa a operacao e preenche o Text da Label...
            switch (operacao)
            {
                case OperacaoCRUD.NOVO:
                    this.lblOperacao.Text = " A D I C I O N A R";
                    break;
                case OperacaoCRUD.EDITAR:
                    this.lblOperacao.Text = " A L T E R A R";
                    tstbtnSalvar.Enabled = true;
                    break;
                case OperacaoCRUD.EXCLUIR:
                    this.lblOperacao.Text = " E X C L U I R";
                    ConfigurarParaExcluir();
                    break;
                case OperacaoCRUD.CONSULTAR:
                    this.lblOperacao.Text = " C O N S U L T A R";
                    tstbtnSalvar.Enabled = false;
                    ConfigurarParaConsulta();
                    break;
            }
        }
        private void ConfigurarParaExcluir()
        {
            TravarControles();
            ConfigurarBotaoExcluir();
        }
        private void ConfigurarParaConsulta()
        {
            TravarControles();
            OcultarBotoesSalvar();
            ConfigurarBotaoCancelar();
        }
        private void OcultarBotoesSalvar()
        {
            tstbtnSalvar.Visible = false;
            tstSeparadorSalvar.Visible = false;
        }
        private void ConfigurarBotaoCancelar()
        {
            tstbtnCancel.Text = "Fechar";
            tstbtnCancel.ToolTipText = "Fechar";
        }
        private void ConfigurarBotaoExcluir()
        {
            tstbtnSalvar.Text = "Excluir";
            tstbtnSalvar.ToolTipText = "Excluir";
        }
        private void ConfigurarControles()
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
        // Método para carregar os dados do cliente nos controles do formulário
        private void CarregaDadosCliente()
        {
            if (cliente != null)
            {
                // Preenche os controles do formulário com os dados do cliente
                lblID.Text = cliente.Id.ToString();
                txtNome.Text = cliente.Nome;
                txtTelefone1.Text = cliente.Telefone1;
                txtTelefone2.Text = cliente.Telefone2;
                txtCpf.Text = cliente.CPF;
                txtEndereco.Text = cliente.Endereco;
                txtCep.Text = cliente.CEP;
                txtCidade.Text = cliente.Cidade;
                txtUF.Text = cliente.UF;
            }
        }
        //-----------------------------
        // Adiciona eventos aos botões da ToolStrip
        private void AddToolStripEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
        }
        //
        //************************************************************
        // Evento click do botão SALVAR...
        private void TstbtnSalvar_Click(object? sender, EventArgs e)
        {
            // Atualiza os dados do cliente
            //AtualizarDadosCliente();

            // Verifica a operação: NOVO, EDITAR ou EXCLUIR
            if (operacao == OperacaoCRUD.NOVO || operacao == OperacaoCRUD.EDITAR)
            {
                try
                {
                    // Se a operação for "NOVO"
                    if (operacao == OperacaoCRUD.NOVO)
                    {
                        // Verifica se os controles são válidos
                        if (!ValidarControles())
                            return;

                        // Grava os dados do cliente
                        AtualizarDadosCliente();

                        // Tenta inserir o novo cliente
                        if (cliente.CreateCliente())
                        {
                            // Exibe a mensagem de sucesso usando a nova função myMessageBox
                            myUtilities.myMessageBox(this, $"Cliente {cliente.Nome}\n salvo com sucesso!", "A d i c i o n a r", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close(); // Fecha o formulário após salvar 
                            //return;
                        }
                    }
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
                        AtualizarDadosCliente();

                        // Tenta salvar o cliente e exibe mensagem de sucesso se bem-sucedido
                        if (cliente.UpdateCliente())
                        {
                            // Exibe a mensagem de sucesso usando a nova função myMessageBox
                            myUtilities.myMessageBox(this, $"Cliente {cliente.Nome}\n salvo com sucesso!", "S a l v a r", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    var result = myUtilities.myMessageBox(this, $"Deseja Excluir o cliente\n{cliente.Nome}?\n\nEsta ação não poderá ser desfeita.", "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
        private void AtualizarDadosCliente()
        {
            // Transfere os dados dos controles para o objeto cliente
            //cliente.Id = Convert.ToInt32(lblID.Text);
            cliente.Nome = txtNome.Text;
            cliente.Telefone1 = txtTelefone1.Text;
            cliente.Telefone2 = txtTelefone2.Text;
            cliente.CPF = txtCpf.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.CEP = txtCep.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.UF = txtUF.Text;
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
        // Método para validar se houve alguma alteração nos dados do cliente
        private bool ValidarCliente()
        {
            // Compara os dados do cliente com os controles do formulário
            if (cliente.Nome != txtNome.Text ||
                cliente.Telefone1 != txtTelefone1.Text ||
                cliente.Telefone2 != txtTelefone2.Text ||
                cliente.CPF != txtCpf.Text ||
                cliente.Endereco != txtEndereco.Text ||
                cliente.CEP != txtCep.Text ||
                cliente.Cidade != txtCidade.Text ||
                cliente.UF != txtUF.Text)
            {
                return true; // Houve mudança
            }
            return false; // Não houve mudança
        }

    } // end class
} // end namesoace
