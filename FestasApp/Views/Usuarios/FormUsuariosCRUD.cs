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

            SuspendLayout();
                ConfigurarFormBaseCrud("U s u á r i o s", operacao);
                SetThisForm();
                SetControls();
                AddEventHandlers();
            ResumeLayout();
        }
        //
        private void FormUsuariosCRUD_Load(object? sender, EventArgs e)
        {
            PopularControlesComUsuario();
        }
        //
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
            this.Load += FormUsuariosCRUD_Load;
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
                    //TravarControles();
                    break;
                case OperacaoCRUD.CONSULTAR:
                    //TravarControles();
                    break;
            }
        }
        //
        // btn SALVAR
        private void TstbtnSalvar_Click(object? sender, EventArgs e)
        {
            if (operacao == OperacaoCRUD.NOVO)
            {
                SalvarNovoUsuario();
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
        //
        // DELETAR usuario
        private async void DeletarUsuario()
        {
            try
            {
                // Exibe a mensagem de confirmação usando MessageBox.Show
                var message = $"""
                        Deseja Excluir o usuário {usuario.user_nome}?
                        
                        Esta ação não poderá ser desfeita!
                        """;
                var result = await myUtilities.myMessageBox(this, message, "Excluir Usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Chama o método para excluir o usuário
                    repUsuarios repUser = new repUsuarios();
                    if (repUser.DeleteUsuario(usuario.user_id))
                    {
                        this.Close(); // Fecha o formulário após excluir
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        await myUtilities.myMessageBox(this, "Erro ao excluir usuário!", "Usuário Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                await myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, ex.Message, "Usuário Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // EDITAR usuário
        private async void EditarUsuario()
        {
            try
            {
                // Verifica se houve mudança nos dados do usuário
                if (!ValidarClsUsuario())
                {
                    await myUtilities.myMessageBox(this, "Não houve nenhuma mudança nos dados do usuário.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Verifica se os controles são válidos
                bool isValid = await ValidarControles();
                if (!isValid)
                    return;

                AtualizarClsUsuario();

                repUsuarios repUser = new repUsuarios();
                if (repUser.UpdateUsuario(usuario))
                {
                    // Exibe a mensagem de sucesso usando a nova função myMessageBox
                    await myUtilities.myMessageBox(this, $"Usuário {usuario.user_nome} alterado com sucesso!", "A l t e r a r", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha o formulário após salvar 
                }
            }
            catch (MySqlException mysqlEx)
            {
                await myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, ex.Message, "Usuário Alterar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        // NOVO usuário
        private async void SalvarNovoUsuario()
        {
            try
            {
                // Verifica se os controles são válidos
                bool isValid = await ValidarControles();
                if (!isValid)
                    return;

                AtualizarClsUsuario();

                repUsuarios repUser = new repUsuarios();
                if (repUser.CreateUsuario(usuario))
                {
                    // Exibe a mensagem de sucesso usando a nova função myMessageBox
                   await myUtilities.myMessageBox(this, $"Novo Usuário {usuario.user_nome} criado com sucesso!", "A d i c i o n a r", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Fecha o formulário após salvar 
                }
            }
            catch (MySqlException mysqlEx)
            {
                await myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, ex.Message, "Usuário Novo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private bool ValidarClsUsuario()
        {
            if (usuario.user_nome != txtUserNome.Text ||
            usuario.user_login != txtUserLogin.Text ||
            usuario.user_email != txtUserEmail.Text ||
            usuario.user_senha != txtUserSenha.Text ||
            usuario.user_ativo != chkUserAtivo.Checked)
            {
                return true;
            }
            return false;
        }
        //
        // ATUALIZA classe usuario com valores dos controles
        private void AtualizarClsUsuario()
        {
            //usuario.Id = Convert.ToInt32(lblID.Text);
            usuario.user_nome = txtUserNome.Text;
            usuario.user_login = txtUserLogin.Text;
            usuario.user_email = txtUserEmail.Text;
            usuario.user_senha = txtUserSenha.Text;
            usuario.user_ativo = chkUserAtivo.Checked; // grava Ativo bool true ou false
        }
        //
        // carrega controles com dados da classe usuario
        private void PopularControlesComUsuario()
        {
            lblID.Text = usuario.user_id.ToString();
            txtUserNome.Text = usuario.user_nome;
            txtUserLogin.Text = usuario.user_login;
            txtUserEmail.Text = usuario.user_email;
            txtUserSenha.Text = usuario.user_senha;
            chkUserAtivo.Checked = usuario.user_ativo;
            ConfiguraChkUserAtivo();
        }
        //
        // Configurações dos controles do formulário
        private void SetControls()
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
        }
        //
        // Configuração dos btns para a operação de consulta
        private void ConfigurarParaConsulta()
        {
            //TravarControles();
        }
        //
        // Método para validar os controles antes de salvar ou alterar
        private async Task<bool> ValidarControles()
        {
            // Valida o campo Nome
            if (string.IsNullOrWhiteSpace(txtUserNome.Text))
            {
                await myUtilities.myMessageBox(this, "O nome do usuário é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserNome.Focus();
                return false;
            }

            // Valida o campo Login
            if (string.IsNullOrWhiteSpace(txtUserLogin.Text))
            {
                await myUtilities.myMessageBox(this, "O login do usuário é obrigatório.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserLogin.Focus();
                return false;
            }

            // Valida o campo Email
            if (string.IsNullOrWhiteSpace(txtUserEmail.Text) || !myUtilities.IsValidEmail(txtUserEmail.Text))
            {
                await myUtilities.myMessageBox(this, "O email é inválido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserEmail.Focus();
                return false;
            }

            // Valida o campo Senha
            if (string.IsNullOrWhiteSpace(txtUserSenha.Text))
            {
                await myUtilities.myMessageBox(this, "A senha do usuário é obrigatória.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserSenha.Focus();
                return false;
            }

            // Se todas as validações passarem, retorna verdadeiro
            return true;
        }

    } // class FormUsuariosCRUD
} // namespace FestasApp.Views.Usuarios
