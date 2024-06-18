//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do módulo: 12/06/2024
//   Ultima Alteração: 16/06/2024
//   
//   FORMULÁRIO DE USUÁRIOS C.R.U.D.
//
//************************************************************

using FestasApp.Enums;
using FestasApp.ViewModels;
using MyFramework.myCodes;
using MySql.Data.MySqlClient;

namespace FestasApp.Views.Usuarios
{
    public partial class FormUsuariosCRUD : FormBaseCRUD
    {
        // instanciar objetos para essa classe
        private clsUsuarios usuario;
        private OperacaoCRUD operacao;

        //
        // Construtor que aceita um objeto clsUsuarios e a operação
        public FormUsuariosCRUD(clsUsuarios _usuario, OperacaoCRUD _operacao)
        {
            InitializeComponent();

            this.usuario = _usuario;
            this.operacao = _operacao;

            this.SuspendLayout();

            ConfigurarForm();
            ConfigurarControles();
            PopularControlesComUsuario();

            this.ResumeLayout();

            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
        }
        //
        // Configura o formulário com base na operação
        private void ConfigurarForm()
        {
            lblTitulo.Text = "C a d a s t r o  d e   U s u á r i o s";
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
        //
        // btn SALVAR
        private void TstbtnSalvar_Click(object? sender, EventArgs e)
        {
            if (ValidarControles()) // Valida os controles antes de continuar
            {
                AtualizaUsuario();
                if (operacao == OperacaoCRUD.NOVO)
                {
                    SalvarUsuario();
                }
                else if (operacao == OperacaoCRUD.EDITAR)
                {
                    EditarUsuario();
                }
                else if (operacao == OperacaoCRUD.EXCLUIR)
                {
                    DeletarUsuario();
                }
            }
        }
        //
        // DELETAR usuario
        private void DeletarUsuario()
        {
            try
            {
                // Exibe a mensagem de confirmação usando MessageBox.Show
                var result = myUtilities.myMessageBox(this, $"Deseja Excluir o usuário {usuario.Nome}?\nEsta ação não poderá ser desfeita.", "Excluir Usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Chama o método para excluir o cliente
                    if (usuario.DeleteUsuario())
                    {
                        // Exibe a mensagem de sucesso usando a nova função myMessageBox
                        myUtilities.myMessageBox(this, "Usuário excluído com sucesso!", "E x c l u i r", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Fecha o formulário após excluir
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        myUtilities.myMessageBox(this, "Erro ao excluir usuário!", "Usuário Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, ex.Message, "Usuário Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // EDITAR usuário
        private void EditarUsuario()
        {
            try
            {
                if (usuario.UpdateUsuario())
                {
                    // Exibe a mensagem de sucesso usando a nova função myMessageBox
                    myUtilities.myMessageBox(this, $"Usuário {usuario.Nome} alterado com sucesso!", "A l t e r a r", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha o formulário após salvar 
                }
            }
            catch (MySqlException mysqlEx)
            {
                myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, ex.Message, "Usuário Alterar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // NOVO usuário
        private void SalvarUsuario()
        {
            try
            {
                if (usuario.CreateUsuario())
                {
                    // Exibe a mensagem de sucesso usando a nova função myMessageBox
                    myUtilities.myMessageBox(this, $"Novo Usuário {usuario.Nome} criado com sucesso!", "A d i c i o n a r", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha o formulário após salvar 
                }
            }
            catch (MySqlException mysqlEx)
            {
                myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, ex.Message, "Usuário Novo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // ATUALIZA classe usuario com valores dos controles
        private void AtualizaUsuario()
        {
            //usuario.Id = Convert.ToInt32(lblID.Text);
            usuario.Nome = txtUserNome.Text;
            usuario.Login = txtUserLogin.Text;
            usuario.Email = txtUserEmail.Text;
            usuario.Senha = txtUserSenha.Text;
            usuario.Ativo = chkUserAtivo.Checked; // grava Ativo bool true ou false
        }
        //
        // carrega controles com dados da classe usuario
        private void PopularControlesComUsuario()
        {
            lblID.Text = usuario.Id.ToString();
            txtUserNome.Text = usuario.Nome;
            txtUserLogin.Text = usuario.Login;
            txtUserEmail.Text = usuario.Email;
            txtUserSenha.Text = usuario.Senha;
            chkUserAtivo.Checked = usuario.Ativo;
            ConfiguraChkUserAtivo();
        }
        //
        // Configurações dos controles do formulário
        private void ConfigurarControles()
        {
            txtUserNome.MaxLength = 100;
            txtUserLogin.MaxLength = 50;
            txtUserEmail.MaxLength = 100;
            txtUserSenha.MaxLength = 50;
            chkUserAtivo.Checked = true;
            chkUserAtivo.Text = "SIM";
        }
        //
        // Evento disparado quando o estado do checkbox de usuário ativo é alterado
        private void chkUserAtivo_CheckedChanged(object sender, EventArgs e)
        {
            ConfiguraChkUserAtivo();
        }
        //
        // Configura o checkbox de usuário ativo
        private void ConfiguraChkUserAtivo()
        {
            if (chkUserAtivo.Checked)
            {
                chkUserAtivo.Text = "SIM";
                chkUserAtivo.ForeColor = Color.Green;
                chkUserAtivo.Font = new Font(chkUserAtivo.Font, FontStyle.Bold);
            }
            else
            {
                chkUserAtivo.Text = "NÃO";
                chkUserAtivo.ForeColor = Color.Red;
                chkUserAtivo.Font = new Font(chkUserAtivo.Font, FontStyle.Bold);
            }
        }
        //
        // Configuração do btn para a operação de exclusão
        private void ConfigurarParaExcluir()
        {
            //TravarControles();
            tstbtnSalvar.Text = "Excluir";
            tstbtnSalvar.ToolTipText = "Excluir";
        }
        //
        // Configuração dos btns para a operação de consulta
        private void ConfigurarParaConsulta()
        {
            //TravarControles();
            tstbtnSalvar.Visible = false;
            tstSeparadorSalvar.Visible = false;
            tstbtnCancel.Text = "Fechar";
            tstbtnCancel.ToolTipText = "Fechar";
        }
        //
        // Método para validar os controles antes de salvar ou alterar
        private bool ValidarControles()
        {
            // Valida o campo Nome
            if (string.IsNullOrWhiteSpace(txtUserNome.Text))
            {
                myUtilities.myMessageBox(this, "O nome do usuário é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserNome.Focus();
                return false;
            }

            // Valida o campo Login
            if (string.IsNullOrWhiteSpace(txtUserLogin.Text))
            {
                myUtilities.myMessageBox(this, "O login do usuário é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserLogin.Focus();
                return false;
            }

            // Valida o campo Email
            if (string.IsNullOrWhiteSpace(txtUserEmail.Text) || !myUtilities.IsValidEmail(txtUserEmail.Text))
            {
                myUtilities.myMessageBox(this, "O email é inválido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserEmail.Focus();
                return false;
            }

            // Valida o campo Senha
            if (string.IsNullOrWhiteSpace(txtUserSenha.Text))
            {
                myUtilities.myMessageBox(this, "A senha do usuário é obrigatória.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserSenha.Focus();
                return false;
            }

            // Se todas as validações passarem, retorna verdadeiro
            return true;
        }


    } // class FormUsuariosCRUD
} // namespace FestasApp.Views.Usuarios
