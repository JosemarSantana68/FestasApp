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
        private readonly repPacotesEF pacotesFestas = new();
        private readonly OperacaoCRUD operacao = new();
        private int? idRegistro;

        public FormPacotesCRUD(clsParam idRegistro, OperacaoCRUD operacao)
        {
            InitializeComponent();
            this.operacao = operacao;
            this.idRegistro = idRegistro.Id;

            SuspendLayout();
            ConfigurarFormBaseCrud("P a c o t e s", operacao);
            AddEventHandlers();
            SetControls();
            SetOperacao();
            ResumeLayout();

        }
        //
        private void FormPacotesCRUD_Load(object? sender, EventArgs e)
        {

        }
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
            this.Load += FormPacotesCRUD_Load;
        }

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

        private void SalvarItensFestas()
        {
            var txtNome = this.pnlCentral.Controls["txtNome"] as TextBox;
            var txtDescricao = this.pnlCentral.Controls["txtDescricao"] as TextBox;
            var txtDuracao = this.pnlCentral.Controls["txtDuracao"] as TextBox;
            var txtValor = this.pnlCentral.Controls["txtValor"] as TextBox;

            if (!ValidarControles(txtNome, txtDescricao, txtDuracao, txtValor))
                return;
            
            // Recupera os valores dos controles
            string nome = txtNome.Text ?? string.Empty;
            string descricao = txtDescricao.Text ?? string.Empty;
            string duracao = txtDuracao.Text ?? string.Empty;
            double valor = double.Parse(0 + txtValor.Text);
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
                        myUtilities.myMessageBox(this, "Pacote de Festas adicionado com sucesso!", "Pacote de Festas");
                        this.Close();
                    }
                    else
                    {
                        myUtilities.myMessageBox(this, "Falha ao adicionar o Pacote de Festas.", "Pacote de Festas");
                    }
                }
                else if (operacao == OperacaoCRUD.EDITAR)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repPacotesEF.AlterItem(idRegistro!.Value, item))
                    {
                        myUtilities.myMessageBox(this, "Pacote de Festas alterado com sucesso!", "Pacote de Festas");
                        this.Close();
                    }
                    else
                    {
                        myUtilities.myMessageBox(this, "Falha ao alterar o Pacote de Festas.", "Pacote de Festas");
                    }
                }

            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Falha ao salvar Item. Erro: {ex.Message}", "Pacote de Festas");
            }
        }
        //
        private bool ValidarControles(TextBox? txtNome, TextBox? txtDescricao, TextBox? txtDuracao, TextBox? txtValor)
        {
            // Validação dos controles - Verifica se todos os campos necessários estão preenchidos
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                myUtilities.myMessageBox(this, "Por favor, preencha o nome do Pacote.", "Pacote de Festas");
                txtNome.Focus();
                return false;
            }
            //
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                myUtilities.myMessageBox(this, "Por favor, preencha a descrição do Pacote.", "Pacote de Festas");
                txtDescricao.Focus();
                return false;
            }
            //
            if (string.IsNullOrEmpty(txtDuracao.Text))
            {
                myUtilities.myMessageBox(this, "Por favor, preencha a duração do Pacote.", "Pacote de Festas");
                txtDuracao.Focus();
                return false;
            }
            
            // Tenta converter o valor de 'txtValor' para double
            if (!double.TryParse(txtValor.Text, out double valor))
            {
                myUtilities.myMessageBox(this, "Por favor, insira um valor válido.", "Pacote de Festas");
                txtValor.Focus();
                return false;
            }

            return true;
        }

        //
        //
        private void DeletarRegistro()
        {
            // Exibe a mensagem de confirmação usando MessageBox.Show
            var message = $"""
                        Deseja Excluir o Pacote {pacotesFestas.pct_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
            var result = myUtilities.myMessageBox(this, message, "Excluir Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
                        myUtilities.myMessageBox(this, "Erro ao excluir Pacote de festa!", "Item Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException mysqlEx)
                {
                    myUtilities.myMessageBox(this, $"Erro no banco de dados: {mysqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    myUtilities.myMessageBox(this, ex.Message, "Item Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //

        //
        //
        // Configura o formulário com base na tabela selecionada
        private void SetControls()
        {
            // Limpa os controles existentes
            this.pnlCentral.Controls.Clear();

            int lblCol = 20; // coluna do label
            int txtCol = lblCol + 120; // coluna do textbox
            int rowControl = 20; // mesma linha

            // Definição das larguras dos TextBox
            int larguraNome = 300;
            int larguraDescricao = 400;
            int larguraDuracao = 80;
            int larguraValor = 100;

            Label lblNome = new Label { Text = "Nome:", Location = new Point(lblCol, rowControl) };
            TextBox txtNome = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtNome", Width = larguraNome };
            rowControl += 30;
            Label lblDescricao = new Label { Text = "Descrição:", Location = new Point(lblCol, rowControl) };
            TextBox txtDescricao = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtDescricao", Width = larguraDescricao };
            rowControl += 30;
            Label lblDuracao = new Label { Text = "Duração:", Location = new Point(lblCol, rowControl) };
            TextBox txtDuracao = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtDuracao", Width = larguraDuracao };
            rowControl += 30;
            Label lblValor = new Label { Text = "Valor:", Location = new Point(lblCol, rowControl) };
            TextBox txtValor = new myTextBoxNumericos { Location = new Point(txtCol, rowControl), Name = "txtValor", Width = larguraValor, TextAlign = HorizontalAlignment.Right, MyPermitirZerado = true };

            // Adiciona os controles ao painel central
            //this.pnlCentral.Controls.Add(lblId);
            //this.pnlCentral.Controls.Add(txtId);

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
        private void MostrarRegistro()
        {
            try
            {
                //var item = new repItensFestasEF();
                var item = pacotesFestas.GetItem(idRegistro!.Value);

                if (item != null)
                {
                    var txtNome = this.pnlCentral.Controls["txtNome"] as TextBox;
                    var txtDescricao = this.pnlCentral.Controls["txtDescricao"] as TextBox;
                    var txtDuracao = this.pnlCentral.Controls["txtDuracao"] as TextBox;
                    var txtValor = this.pnlCentral.Controls["txtValor"] as TextBox;

                    if (txtNome != null) txtNome.Text = item.pct_nome;
                    if (txtDescricao != null) txtDescricao.Text = item.pct_descricao;
                    if (txtDuracao != null) txtDuracao.Text = item.pct_duracao ?? string.Empty;
                    if (txtValor != null) txtValor.Text = (item.pct_valor)?.ToString("F2") ?? "0,00";
                }
                else
                {
                    // Exibe mensagem caso o registro não seja encontrado
                    // myUtilities.myMessageBox(this, "Registro não encontrado.");
                }
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Erro ao preencher dados do Pacote: {ex.Message}");
            }
        }

    } // end class FormPacotesCRUD : FormBaseCRUD
} // end namespace FestasApp.Views.FestasPacotes
