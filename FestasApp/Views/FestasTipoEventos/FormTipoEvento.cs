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

namespace FestasApp.Views.FestasTipoEventos
{
    public partial class FormTipoEvento : FormBaseCRUD
    {
        // declarar instâncias
        private readonly repTipoEventoEF tipoEventos = new();
        private readonly OperacaoCRUD operacao = new();
        public clsFestasTipoEvento TipoAtual { get; private set; } = new();
        private clsParam idRegistro;
        //
        // construtor
        public FormTipoEvento(clsParam idRegistro, OperacaoCRUD operacao)
        {
            InitializeComponent();
            this.idRegistro = idRegistro;
            this.operacao = operacao;

            SuspendLayout();
            ConfigurarFormBaseCrud("Tipos Eventos", operacao);
            AddEventHandlers();
            SetControls();
            ResumeLayout();
        }
        //
        private void FormTipoEvento_Load(object? sender, EventArgs e)
        {
            SuspendLayout();
            SetOperacao();
            ResumeLayout();
        }
        //
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstBtnSalvar_Click;
            this.Load += FormTipoEvento_Load;
        }
        //
        private void SetOperacao()
        {
            // Testa a operacao e configura os controles...
            switch (operacao)
            {
                case OperacaoCRUD.NOVO:
                    idRegistro.Id = 0;
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
        // mostra dados do registro selecionado
        private async void MostrarRegistro()
        {
            try
            {
                //var item = new repItensFestasEF();
                var item = tipoEventos.GetItem(idRegistro.Id!.Value);

                if (item != null)
                {
                    var txtNome = this.pnlCentral.Controls["txtNome"] as TextBox;

                    if (txtNome != null)
                    {
                        txtNome.Text = item.tpev_nome;
                        int maxLength = myFunctions.GetMaxLength("tblfestastipoevento", "tpev_nome"); // conferir tabela
                        if (maxLength > 0) txtNome.MaxLength = maxLength;
                    }
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao preencher dados do Tipo de Evento: {ex.Message}");
            }
        }
        //
        private void TstBtnSalvar_Click(object? sender, EventArgs e)
        {
            // Testa a operacao e configura os salvar...
            switch (operacao)
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
        // Método SalvarRegistro
        private async void SalvarRegistro()
        {
            var txtNome = this.pnlCentral.Controls["txtNome"] as TextBox;

            // Validação dos controles - Verifica se todos os campos necessários estão preenchidos
            if (string.IsNullOrEmpty(txtNome!.Text))
            {
                await myUtilities.myMessageBox(this, "Por favor, preencha nome do Tipo de Evento.", "Tipos de Eventos");
                return;
            }

            // Recupera os valores dos controles
            string nome = txtNome.Text ?? string.Empty;

            // Cria uma instância da classe e salva os dados sem passar o ID
            clsFestasTipoEvento item = new(nome);

            try
            {
                if (operacao == OperacaoCRUD.NOVO)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repTipoEventoEF.AddItem(item))
                    {
                        await myUtilities.myMessageBox(this, "Tipo de Evento adicionado com sucesso!", "Tipos de Eventos");
                        TipoAtual = item;
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao adicionar o Tipo de Evento.", "Tipos de Eventos");
                    }
                }
                // continua o código
                //

                else if (operacao == OperacaoCRUD.EDITAR)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repTipoEventoEF.AlterItem(idRegistro.Id!.Value, item))
                    {
                        await myUtilities.myMessageBox(this, "Tipo de Evento alterado com sucesso!", "Tipos de Eventos");
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao alterar o Tipo de Evento.", "Tipos de Eventos");
                    }
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Falha ao salvar Tipo de Evento. Erro: {ex.Message}", "Tipos de Eventos");
            }
        }
        //
        private async void DeletarRegistro()
        {
            // Exibe a mensagem de confirmação usando MessageBox.Show
            var message = $"""
                        Deseja Excluir o Registro {tipoEventos.tpev_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
            var result = await myUtilities.myMessageBox(this, message, "Excluir Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Chama o método para excluir o cliente
                    if (repTipoEventoEF.DeleteItem(idRegistro.Id!.Value))
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        await myUtilities.myMessageBox(this, "Erro ao excluir Tipo de Evento!", "Tipo de Evento Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException mysqlEx)
                {
                    await myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    await myUtilities.myMessageBox(this, ex.Message, "Item Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //
        // Configura o formulário com base na tabela selecionada
        private void SetControls()
        {
            // Limpa os controles existentes
            this.pnlCentral.Controls.Clear();

            int lblCol = 40; // coluna do label
            int txtCol = lblCol + 100; // coluna do textbox
            int rowControl = 30; // mesma linha label e textbox

            // Definição das larguras dos TextBox
            int larguraNome = 300;

            Label lblNome = new Label { Text = "Tipo Evento:", Location = new Point(lblCol, rowControl) };
            TextBox txtNome = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtNome", Width = larguraNome };

            this.pnlCentral.Controls.Add(lblNome);
            this.pnlCentral.Controls.Add(txtNome);

            // Calcula a altura necessária para acomodar todos os controles
            int alturaControles = rowControl + (rowControl * 2); // margem top e botton extra

            // Calcula a largura necessária para acomodar o maior controle
            int larguraMaiorTextBox = larguraNome; // 300
            int larguraMaiorLabel = lblNome.PreferredWidth; // +/- 50
            int larguraTotal = lblCol + larguraMaiorLabel + larguraMaiorTextBox + (lblCol * 2); // margem extra left e right

            // Ajusta a altura do formulário
            this.Height = pnlTitulo.Height + alturaControles + pnlRodape.Height;

            // Ajusta a largura do formulário. com largura minima em 550
            this.Width = larguraTotal < 550 ? 550 : larguraTotal;
        }

    } // end class FormTipoEvento : FormBaseCRUD
} // end namespace FestasApp.Views.FestasTipoEventos
