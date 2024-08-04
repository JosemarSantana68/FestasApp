//------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//  Criação do módulo: 12/07/2024
//   Ultima Alteração: 12/07/2024
//   
//   FORMULÁRIO BASE DE C.R.U.D. PARA AS TABELAS AUXILIARES
//
//------------------------------------------------------------

using MySqlX.XDevAPI;

namespace FestasApp.Views.TabelasAuxiliares
{
    public partial class FormItensFestasCRUD : FormBaseCRUD
    {
        //
        private repItensFestasEF itensFesta = new();
        private OperacaoCRUD operacao;
        private int? idRegistro;
        //
        // construtor com parâmetros
        public FormItensFestasCRUD(clsParam idRegistro, OperacaoCRUD operacao)
        {
            InitializeComponent();
            this.operacao = operacao;
            this.idRegistro = idRegistro.Id;

            SuspendLayout();
                ConfigurarFormBaseCrud("Itens de Festas", operacao);
                AddEventHandlers();
                SetControls();
            ResumeLayout();
        }
        //
        private void FormItensFestasCRUD_Load(object? sender, EventArgs e)
        {
            SetOperacao();
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
                    MostrarItemFesta();
                    break;
                case OperacaoCRUD.EXCLUIR:
                    //TravarControles();
                    MostrarItemFesta();
                    break;
                case OperacaoCRUD.CONSULTAR:
                    //TravarControles();
                    MostrarItemFesta();
                    break;
            }
        }
        //
        private void AddEventHandlers()
        {
            this.tstbtnSalvar.Click += TstbtnSalvar_Click;
            this.Load += FormItensFestasCRUD_Load;
        }
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
            int larguraTipo = 200;
            int larguraDescricao = 400;
            int larguraValor = 100;

            // Definição das MaxLenght dos TextBox
            int maxLenghtNome = myFunctions.GetMaxLength("tblfestasitens", "itensfest_nome"); // varchar (100)
            int maxLenghtTipo = myFunctions.GetMaxLength("tblfestasitens", "itensfest_tipo"); // varchar (50)
            int maxLenghtDescricao = myFunctions.GetMaxLength("tblfestasitens", "itensfest_descricao"); // text
            int maxLenghtValor = 12; // myFunctions.GetMaxLength("tblfestasitens", "itensfest_valor"); // decimal(10,2) erro com -1

            Label lblNome = new Label { Text = "Nome:", Location = new Point(lblCol, rowControl) };
            myTextBox txtNome = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtNome", Width = larguraNome, MaxLength = maxLenghtNome };

            rowControl += 30;
            Label lblTipo = new Label { Text = "Tipo:", Location = new Point(lblCol, rowControl) };
            myTextBox txtTipo = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtTipo", Width = larguraTipo, MaxLength = maxLenghtTipo };

            rowControl += 30;
            Label lblDescricao = new Label { Text = "Descrição:", Location = new Point(lblCol, rowControl) };
            myTextBox txtDescricao = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtDescricao", Width = larguraDescricao, MaxLength = maxLenghtDescricao };

            rowControl += 30;
            Label lblValor = new Label { Text = "Valor:", Location = new Point(lblCol, rowControl) };
            myTextBoxNumericos txtValor = new()
            {
                Location = new Point(txtCol, rowControl),
                Name = "txtValor",
                Width = larguraValor,
                Text = "0,00",
                TextAlign = HorizontalAlignment.Right,
                MyPermitirZerado = true,
                MyCasasDecimais = 2,
                MyForcarFormatacao = true,
                MaxLength = maxLenghtValor
            };

            this.pnlCentral.Controls.Add(lblNome);
            this.pnlCentral.Controls.Add(txtNome);
            this.pnlCentral.Controls.Add(lblTipo);
            this.pnlCentral.Controls.Add(txtTipo);
            this.pnlCentral.Controls.Add(lblDescricao);
            this.pnlCentral.Controls.Add(txtDescricao);
            this.pnlCentral.Controls.Add(lblValor);
            this.pnlCentral.Controls.Add(txtValor);

            // Calcula a altura necessária para acomodar todos os controles
            int alturaControles = rowControl + 60;

            // Calcula a largura necessária para acomodar o maior controle
            int larguraMaiorTextBox = Math.Max(Math.Max(larguraTipo, larguraNome), Math.Max(larguraDescricao, larguraValor));
            int larguraMaiorLabel = new[] { lblTipo.PreferredWidth, lblNome.PreferredWidth, lblDescricao.PreferredWidth, lblValor.PreferredWidth }.Max();
            int larguraTotal = lblCol + larguraMaiorLabel + larguraMaiorTextBox + 80; // 80 para uma margem extra

            // Ajusta a altura do formulário
            this.Height = pnlTitulo.Height + alturaControles + pnlRodape.Height;
            // Ajusta a largura do formulário
            this.Width = larguraTotal;
        }
        //
        // Botão de Salvar
        //Button btnSalvar = new Button { Text = "Salvar", Location = new Point(150, 160) };
        //btnSalvar.Click += TstbtnSalvar_Click;
        //this.Controls.Add(btnSalvar);
        //
        //
        // mostra dados do registro selecionado
        private async void MostrarItemFesta()
        {
            try
            {
                //var item = new repItensFestasEF();
                var item = itensFesta.GetItem(idRegistro!.Value);

                if (item != null)
                {
                    //
                    var txtNome = this.pnlCentral.Controls["txtNome"] as myTextBox;
                    var txtTipo = this.pnlCentral.Controls["txtTipo"] as myTextBox;
                    var txtDescricao = this.pnlCentral.Controls["txtDescricao"] as myTextBox;
                    var txtValor = this.pnlCentral.Controls["txtValor"] as myTextBoxNumericos;
                    //
                    if (txtNome != null)
                    {
                        txtNome.Text = item.itensfest_nome;
                        //int maxLength = myFunctions.GetMaxLength("tblfestasitens", "itensfest_nome");
                        //if (maxLength > 0) txtNome.MaxLength = maxLength;
                    }
                    //
                    if (txtTipo != null)
                    {
                        txtTipo.Text = item.itensfest_tipo ?? string.Empty;
                        //int maxLength = myFunctions.GetMaxLength("tblfestasitens", "itensfest_tipo");
                        //if (maxLength > 0) txtTipo.MaxLength = maxLength;
                    }
                    //
                    if (txtDescricao != null)
                    {
                        txtDescricao.Text = item.itensfest_descricao;
                        //int maxLength = myFunctions.GetMaxLength("tblfestasitens", "itensfest_descricao");
                        //if (maxLength > 0) txtDescricao.MaxLength = maxLength;
                    }

                    if (txtValor != null)
                    {
                        txtValor.Text = (item.itensfest_valor)?.ToString("N2") ?? "0,00";
                        //txtValor.MaxLength = 12; // Definindo manualmente para campo decimal (10 dígitos + 1 para ponto decimal + 1 para precisão)
                    }
                    ////
                    //// Exemplos de MaskedTextBox
                    //var mskCpf = this.pnlCentral.Controls["mskCpf"] as MaskedTextBox;
                    //if (mskCpf != null)
                    //{
                    //    mskCpf.Text = item.cpf; // Supondo que há um campo CPF no item
                    //                            // A máscara já controla a entrada, então não é necessário definir MaxLength
                    //}
                    ////
                    //var mskData = this.pnlCentral.Controls["mskData"] as MaskedTextBox;
                    //if (mskData != null)
                    //{
                    //    mskData.Text = item.data?.ToString("dd/MM/yyyy"); // Supondo que há um campo data no item
                    //                                                      // A máscara já controla a entrada, então não é necessário definir MaxLength
                    //}
                    //// Adicione manualmente para outros campos conforme necessário
                    //var txtCodigo = this.pnlCentral.Controls["txtCodigo"] as TextBox;
                    //if (txtCodigo != null)
                    //{
                    //    txtCodigo.MaxLength = 10; // Definindo manualmente para campo int
                    //}
                }
            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Erro ao preencher dados do Item: {ex.Message}");
            }
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
        private async void DeletarRegistro()
        {
            // Exibe a mensagem de confirmação usando MessageBox.Show
            var message = $"""
                        Deseja Excluir o Item {itensFesta.itensfest_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
            var result = await myUtilities.myMessageBox(this, message, "Excluir Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Chama o método para excluir o cliente
                    if (repItensFestasEF.ExcluirItemFesta(idRegistro!.Value))
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        await myUtilities.myMessageBox(this, "Erro ao excluir item de festa!", "Item Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private  async void SalvarItensFestas()
        {
            var txtNome = this.pnlCentral.Controls["txtNome"] as myTextBox;
            var txtTipo = this.pnlCentral.Controls["txtTipo"] as myTextBox;
            var txtDescricao = this.pnlCentral.Controls["txtDescricao"] as myTextBox;
            var txtValor = this.pnlCentral.Controls["txtValor"] as myTextBoxNumericos;

            // Validação dos controles - Verifica se todos os campos necessários estão preenchidos
            if (string.IsNullOrEmpty(txtNome?.Text) ||
                string.IsNullOrEmpty(txtTipo?.Text) ||
                string.IsNullOrEmpty(txtDescricao?.Text) ||
                string.IsNullOrEmpty(txtValor?.Text))
            {
                await myUtilities.myMessageBox(this, "Por favor, preencha todos os campos.", "Itens de Festa");
                return;
            }

            // Recupera os valores dos controles
            string nome = txtNome.Text ?? string.Empty;
            string tipo = txtTipo.Text ?? string.Empty;
            string descricao = txtDescricao.Text ?? string.Empty;

            //double valor = double.Parse(0 + this.pnlCentral.Controls["txtValor"].Text);
            // Tenta converter o valor de 'txtValor' para double
            if (!double.TryParse(txtValor.Text, out double valor))
            {
                await myUtilities.myMessageBox(this, "Por favor, insira um valor válido.", "Itens de Festa");
                return;
            }

            // Cria uma instância da classe clsFestasItens e salva os dados sem passar o ID
            clsFestasItens item = new(tipo, nome, descricao, valor);

            try
            {
                if (operacao == OperacaoCRUD.NOVO)
                {
                    // Tenta adicionar o novo item de festa ao banco de dados
                    if (repItensFestasEF.AddItemFesta(item))
                    {
                        await myUtilities.myMessageBox(this, "Item de Festas adicionado com sucesso!", "Itens de Festas");
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao adicionar o Item de Festas.", "Itens de Festas");
                    }
                }
                else if (operacao == OperacaoCRUD.EDITAR)
                {
                    // Tenta adicionar o item de festa editado ao banco de dados
                    if (repItensFestasEF.EditarItemFesta(idRegistro!.Value, item))
                    {
                        await myUtilities.myMessageBox(this, "Item de Festas alterado com sucesso!", "Itens de Festas");
                        this.Close();
                    }
                    else
                    {
                        await myUtilities.myMessageBox(this, "Falha ao alterar o Item de Festas.", "Itens de Festas");
                    }
                }

            }
            catch (Exception ex)
            {
                await myUtilities.myMessageBox(this, $"Falha ao salvar Item. Erro: {ex.Message}", "Itens de Festas");
            }
        }
        //

    } // end class FormBaseAuxilares : FormBaseCRUD

} // end namespace FestasApp.Views.Bases
