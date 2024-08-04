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
        // declarar instâncias
        private readonly repTemasEF temaFestas = new();
        private readonly OperacaoCRUD operacao = new();
        public clsFestasTemas TemaAtual { get; private set; } = new();
        private int? idRegistro;

        public FormTemasFestas(clsParam idRegistro, OperacaoCRUD operacao)
        {
            InitializeComponent();
            this.idRegistro = idRegistro.Id;
            this.operacao = operacao;

            SuspendLayout();
            ConfigurarFormBaseCrud("Temas Festas", operacao);
            AddEventHandlers();
            SetControls();
            ResumeLayout();
        }
        //
        private void FormStatusCRUD_Load(object? sender, EventArgs e)
        {
            SuspendLayout();
            SetOperacao();
            ResumeLayout();
        }
        //
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstBtnSalvar_Click;
            this.Load += FormStatusCRUD_Load;
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
        //
        private async void SalvarRegistro()
        {
            var txtNome = this.pnlCentral.Controls["txtNome"] as TextBox;
            var txtDescricao = this.pnlCentral.Controls["txtDescricao"] as TextBox;

            // Validação dos controles - Verifica se todos os campos necessários estão preenchidos
            //ValidarForm();
            if (string.IsNullOrEmpty(txtNome!.Text) || string.IsNullOrEmpty(txtDescricao!.Text))
            {
                await myUtilities.myMessageBox(this, "Por favor, preencha nome do Temas das Festas.", "Temas das Festas");
                return;
            }

            // Recupera os valores dos controles
            string nome = txtNome.Text ?? string.Empty;
            string descricao = txtDescricao.Text ?? string.Empty;

            // Cria uma instância da classe e salva os dados sem passar o ID
            clsFestasTemas item = new(nome, descricao);

            try
            {
                if (operacao == OperacaoCRUD.NOVO)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repTemasEF.AddItem(item))
                    {
                        await myUtilities.myMessageBox(this, "Tema de Festas adicionado com sucesso!", "Temas de Festas");
                        
                        TemaAtual = item;

                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao adicionar o Tema de Festas.", "Temas de Festas");
                    }
                }
                else if (operacao == OperacaoCRUD.EDITAR)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repTemasEF.AlterItem(idRegistro!.Value, item))
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
                await myUtilities.myMessageBox(this, $"Falha ao salvar Tema. Erro: {ex.Message}", "Temas de Festas");
            }
        }
        //
        private async void DeletarRegistro()
        {
            // Exibe a mensagem de confirmação usando MessageBox.Show
            var message = $"""
                        Deseja Excluir o Registro {temaFestas.tema_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
            var result = await myUtilities.myMessageBox(this, message, "Excluir Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Chama o método para excluir o cliente
                    if (repTemasEF.DeleteItem(idRegistro!.Value))
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
                    await myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    await myUtilities.myMessageBox(this, ex.Message, "Tema Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            int larguraNome = 200;
            int larguraDescricao = 300;


            Label lblNome = new Label { Text = "Tema:", Location = new Point(lblCol, rowControl) };
            TextBox txtNome = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtNome", Width = larguraNome };
            //
            rowControl += 30; // espaço entre linhas
            //
            Label lblDescricao = new Label { Text = "Descrição:", Location = new Point(lblCol, rowControl) };
            TextBox txtDescricao = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtDescricao", Width = larguraDescricao };

            this.pnlCentral.Controls.Add(lblNome);
            this.pnlCentral.Controls.Add(txtNome);
            this.pnlCentral.Controls.Add(lblDescricao);
            this.pnlCentral.Controls.Add(txtDescricao);

            // Calcula a altura necessária para acomodar todos os controles
            int alturaControles = rowControl + (rowControl * 2); // margem top e botton extra

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
        //
        private void SetOperacao()
        {
            // Testa a operacao e configura os controles...
            switch (operacao)
            {
                case OperacaoCRUD.NOVO:
                    idRegistro = 0;
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
                var item = temaFestas.GetItem(idRegistro!.Value);

                if (item != null)
                {
                    var txtNome = this.pnlCentral.Controls["txtNome"] as TextBox;
                    var txtDescricao = this.pnlCentral.Controls["txtDescricao"] as TextBox;

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
                //else
                //{
                //    // Exibe mensagem caso o registro não seja encontrado
                //    // await myUtilities.myMessageBox(this, "Registro não encontrado.");
                //}
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao preencher dados do Tema: {ex.Message}");
            }
        }

    } // end class FormTemasFestas : FormBaseCRUD
} // end namespace FestasApp.Views.FestasTemas
