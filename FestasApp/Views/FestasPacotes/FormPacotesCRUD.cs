//------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//  Criação do módulo: 13/07/2024
//   Ultima Alteração: 13/07/2024
//   
//   FORMULÁRIO BASE DE C.R.U.D. PARA AS TABELAS AUXILIARES
//
//------------------------------------------------------------

namespace FestasApp.Views.FestasPacotes
{
    public partial class FormPacotesCRUD : FormBaseCRUD
    {
        // instância de repositório para crud
        private readonly repPacotesEF pacotesFestas = new();
        // enumerabel
        private readonly OperacaoCRUD operacao = new();
        // instància de um novo objeto da classe
        public clsFestasPacotes PacoteAtual { get; private set; } = new();
        // constante para id
        private int? idRegistro;
        //
        // construtor padrão
        public FormPacotesCRUD(clsParam idRegistro, OperacaoCRUD operacao)
        {
            InitializeComponent();
            this.operacao = operacao;
            this.idRegistro = idRegistro.Id;

            SuspendLayout();
                ConfigurarFormBaseCrud("P a c o t e s", operacao);
                AddEventHandlers();
                SetControls();
            ResumeLayout();
        }
        //
        private void FormPacotesCRUD_Load(object? sender, EventArgs e)
        {
            SetOperacao();
        }
        //
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
            this.Load += FormPacotesCRUD_Load;
        }
        //
        // Configura os controles do formulário com base na tabela selecionada
        private void SetControls()
        {
            // Limpa os controles existentes
            this.pnlCentral.Controls.Clear();

            int lblCol = 20; // coluna do label inicial
            int txtCol = lblCol + 120; // coluna do textbox inicial
            int rowControl = 20; // mesma linha inicial

            // Definição das larguras dos TextBox
            int larguraNome = 300;
            int larguraDescricao = 400;
            int larguraDuracao = 80;
            int larguraValor = 100;

            //
            int maxLengthNome = myFunctions.GetMaxLength("tblfestaspacotes", "pct_nome");
            int maxLengthDescricao = myFunctions.GetMaxLength("tblfestaspacotes", "pct_descricao");
            int maxLengthDuracao = myFunctions.GetMaxLength("tblfestaspacotes", "pct_duracao");
            int maxLenghttValor = 12;

            //
            Label lblNome = new() { Text = "Nome:", Location = new Point(lblCol, rowControl) };
            myTextBox txtNome = new() { Location = new Point(txtCol, rowControl), Name = "txtNome", Width = larguraNome, MaxLength = maxLengthNome };
            //
            rowControl += 30;
            Label lblDescricao = new() { Text = "Descrição:", Location = new Point(lblCol, rowControl) };
            myTextBox txtDescricao = new() { Location = new Point(txtCol, rowControl), Name = "txtDescricao", Width = larguraDescricao, MaxLength = maxLengthDescricao };
            //
            rowControl += 30;
            Label lblDuracao = new() { Text = "Duração:", Location = new Point(lblCol, rowControl) };
            myTextBox txtDuracao = new() { Location = new Point(txtCol, rowControl), Name = "txtDuracao", Width = larguraDuracao, MaxLength = maxLengthDuracao };
            
            // valor do pacote
            rowControl += 30;
            Label lblValor = new() { Text = "Valor:", Location = new Point(lblCol, rowControl) };
            //
            myTextBoxNumericos txtValor = new()
            {
                Location = new Point(txtCol, rowControl),
                Name = "txtValor",
                Width = larguraValor,
                Text = "0,00",
                TextAlign = HorizontalAlignment.Right,
                MyMoeda = false,
                MyCasasDecimais = 2,
                MyPermitirZerado = true,
                //MyForcarFormatacao = true, // ativar para formatar valores -- sem uso em MyFramework
                MaxLength = maxLenghttValor
            };

            // Adiciona os controles ao painel central
            // id
            //this.pnlCentral.Controls.Add(lblId);
            //this.pnlCentral.Controls.Add(txtId);
            //
            this.pnlCentral.Controls.Add(lblNome);
            this.pnlCentral.Controls.Add(txtNome);
            this.pnlCentral.Controls.Add(lblDescricao);
            this.pnlCentral.Controls.Add(txtDescricao);
            this.pnlCentral.Controls.Add(lblDuracao);
            this.pnlCentral.Controls.Add(txtDuracao);
            this.pnlCentral.Controls.Add(lblValor);
            this.pnlCentral.Controls.Add(txtValor);

            // Calcula a altura necessária para acomodar todos os controles
            int alturaControles = rowControl + 60;

            // Calcula a largura necessária para acomodar o maior controle
            int larguraMaiorTextBox = Math.Max(Math.Max(larguraNome, larguraDuracao), Math.Max(larguraDescricao, larguraValor));
            //int larguraMaiorLabel = new[] { lblId.PreferredWidth, lblTipo.PreferredWidth, lblNome.PreferredWidth, lblDescricao.PreferredWidth, lblValor.PreferredWidth }.Max();
            int larguraMaiorLabel = new[] { lblDuracao.PreferredWidth, lblNome.PreferredWidth, lblDescricao.PreferredWidth, lblValor.PreferredWidth }.Max();
            int larguraTotal = lblCol + larguraMaiorLabel + larguraMaiorTextBox + 80; // 80 para uma margem extra

            // Ajusta a altura do formulário
            this.Height = pnlTitulo.Height + alturaControles + pnlRodape.Height;
            // Ajusta a largura do formulário
            this.Width = larguraTotal;
        }
        //
        private void TstbtnSalvar_Click(object? sender, EventArgs e)
        {
            // Testa a operacao e configura os controles...
            switch (operacao)
            {
                case OperacaoCRUD.NOVO:
                    SalvarItensFestas();
                    break;
                case OperacaoCRUD.EDITAR:
                    SalvarItensFestas();
                    break;
                case OperacaoCRUD.EXCLUIR:
                    DeletarRegistro();
                    break;
            }
        }
        //
        private async void SalvarItensFestas()
        {
            var txtNome = this.pnlCentral.Controls["txtNome"] as myTextBox;
            var txtDescricao = this.pnlCentral.Controls["txtDescricao"] as myTextBox;
            var txtDuracao = this.pnlCentral.Controls["txtDuracao"] as myTextBox;
            var txtValor = this.pnlCentral.Controls["txtValor"] as myTextBoxNumericos;

            bool isValid = await ValidarControles(txtNome!, txtDescricao!, txtDuracao!, txtValor!);
            if (!isValid)
                return;
            
            // Recupera os valores dos controles
            var nome = txtNome!.Text ?? string.Empty;
            var descricao = txtDescricao!.Text ?? string.Empty;
            var duracao = txtDuracao!.Text ?? string.Empty;
            double valor = double.Parse(0 + txtValor!.Text);
            //double.TryParse(txtValor.Text, out double valor);

            // Cria uma instância da classe clsFestasPacotes e preenche os dados sem passar o ID
            clsFestasPacotes item = new(nome, descricao, duracao, valor);
            try
            {
                if (operacao == OperacaoCRUD.NOVO)
                {
                    // Tenta adicionar o pacote de festa ao banco de dados
                    if (repPacotesEF.AddItem(item))
                    {
                        await myUtilities.myMessageBox(this, "Pacote de Festas adicionado com sucesso!", "Pacote de Festas");
                        PacoteAtual = item; // nova classe publica para ser taratada em formfestasCRUD
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao adicionar o Pacote de Festas.", "Pacote de Festas");
                    }
                }
                //
                // continua o código...
                //
                else if (operacao == OperacaoCRUD.EDITAR)
                {
                    // Tenta editar o item de festa no banco de dados
                    if (repPacotesEF.AlterItem(idRegistro!.Value, item))
                    {
                        await myUtilities.myMessageBox(this, "Pacote de Festas alterado com sucesso!", "Pacote de Festas");
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao alterar o Pacote de Festas.", "Pacote de Festas");
                    }
                }

            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Falha ao salvar Item. Erro: {ex.Message}", "Pacote de Festas");
            }
        }
        //
        private async Task<bool> ValidarControles(myTextBox txtNome, myTextBox txtDescricao, myTextBox txtDuracao, myTextBoxNumericos txtValor)
        {
            // Validação dos controles - Verifica se todos os campos necessários estão preenchidos
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                await myUtilities.myMessageBox(this, "Por favor, preencha o nome do Pacote.", "Pacote de Festas");
                txtNome.Focus();
                return false;
            }
            //
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                await myUtilities.myMessageBox(this, "Por favor, preencha a descrição do Pacote.", "Pacote de Festas");
                txtDescricao.Focus();
                return false;
            }
            //
            if (string.IsNullOrEmpty(txtDuracao.Text))
            {
                await myUtilities.myMessageBox(this, "Por favor, preencha a duração do Pacote.", "Pacote de Festas");
                txtDuracao.Focus();
                return false;
            }
            
            // Tenta converter o valor de 'txtValor' para double
            if (!double.TryParse(txtValor.Text, out double valor))
            {
                await myUtilities.myMessageBox(this, "Por favor, insira um valor válido.", "Pacote de Festas");
                txtValor.Focus();
                return false;
            }

            return true;
        }
        //
        private async void DeletarRegistro()
        {
            // Exibe a mensagem de confirmação usando MessageBox.Show
            var message = $"""
                        Deseja Excluir o Pacote {pacotesFestas.pct_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
            var result = await myUtilities.myMessageBox(this, message, "Excluir Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Chama o método para excluir o cliente
                    if (repPacotesEF.DeleteItem(idRegistro!.Value))
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        await myUtilities.myMessageBox(this, "Erro ao excluir Pacote de festa!", "Item Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //var item = new repItensFestasEF();
                var item = pacotesFestas.GetItem(idRegistro!.Value);

                if (item != null)
                {
                    //
                    var txtNome = this.pnlCentral.Controls["txtNome"] as myTextBox;
                    var txtDescricao = this.pnlCentral.Controls["txtDescricao"] as myTextBox;
                    var txtDuracao = this.pnlCentral.Controls["txtDuracao"] as myTextBox;
                    var txtValor = this.pnlCentral.Controls["txtValor"] as myTextBoxNumericos;
                    //
                    if (txtNome != null)
                    {
                        txtNome.Text = item.pct_nome;
                        //int maxLength = myFunctions.GetMaxLength("tblfestaspacotes", "pct_nome");
                        //if (maxLength > 0) txtNome.MaxLength = maxLength;
                    }
                    //
                    if (txtDescricao != null)
                    {
                        txtDescricao.Text = item.pct_descricao;
                        //int maxLength = myFunctions.GetMaxLength("tblfestaspacotes", "pct_descricao");
                        //if (maxLength > 0) txtDescricao.MaxLength = maxLength;
                    }
                    //
                    if (txtDuracao != null)
                    {
                        txtDuracao.Text = item.pct_duracao ?? string.Empty;
                        //int maxLength = myFunctions.GetMaxLength("tblfestaspacotes", "pct_duracao");
                        //if (maxLength > 0) txtDuracao.MaxLength = maxLength;
                    }
                    //
                    if (txtValor != null)
                    {
                        txtValor.Text = (item.pct_valor)?.ToString("N2") ?? "0,00";
                        //txtValor.MaxLength = 12;
                    }
                }
                else
                {
                    // Exibe mensagem caso o registro não seja encontrado
                    // myUtilities.myMessageBox(this, "Registro não encontrado.");
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao preencher dados do Pacote: {ex.Message}");
            }
        }

    } // end class FormPacotesCRUD : FormBaseCRUD
} // end namespace FestasApp.Views.FestasPacotes
