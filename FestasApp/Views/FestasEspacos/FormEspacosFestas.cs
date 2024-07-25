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
//   FORMULÁRIO DE C.R.U.D. PARA AS TABELAS AUXILIARES
//
//------------------------------------------------------------

namespace FestasApp.Views.FestasEspacos
{
    public partial class FormEspacosFestas : FormBaseCRUD
    {
        // declara instâncias
        private readonly repEspacosEF espacosFestas = new();
        private readonly OperacaoCRUD operacao = new();
        private int? idRegistro;

        public FormEspacosFestas(clsParam idRegistro, OperacaoCRUD operacao)
        {
            InitializeComponent();
            this.idRegistro = idRegistro.Id;
            this.operacao = operacao;

            SuspendLayout();
            ConfigurarFormBaseCrud("E s p a ç o s", operacao);
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
        private void SalvarRegistro()
        {
            var txtNome = this.pnlCentral.Controls["txtEspaco"] as TextBox;

            // Validação dos controles - Verifica se todos os campos necessários estão preenchidos
            if (string.IsNullOrEmpty(txtNome!.Text))
            {
                myUtilities.myMessageBox(this, "Por favor, preencha nome do Espaço de Festas.", "Espaço de Festa");
                return;
            }

            // Recupera os valores dos controles
            string nome = txtNome.Text ?? string.Empty;

            // Cria uma instância da classe e salva os dados sem passar o ID
            clsFestasEspacos item = new(nome);

            try
            {
                if (operacao == OperacaoCRUD.NOVO)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repEspacosEF.AddItem(item))
                    {
                        myUtilities.myMessageBox(this, "Espaço de Festas adicionado com sucesso!", "Espaço de Festas");
                        this.Close();
                    }
                    else
                    {
                        myUtilities.myMessageBox(this, "Falha ao adicionar o Espaço de Festas.", "Espaço de Festas");
                    }
                }
                else if (operacao == OperacaoCRUD.EDITAR)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repEspacosEF.AlterItem(idRegistro!.Value, item))
                    {
                        myUtilities.myMessageBox(this, "Espaço de Festas alterado com sucesso!", "Espaço de Festas");
                        this.Close();
                    }
                    else
                    {
                        myUtilities.myMessageBox(this, "Falha ao alterar o Espaço de Festas.", "Espaço de Festas");
                    }
                }
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Falha ao salvar Item. Erro: {ex.Message}", "Itens de Festas");
            }
        }
        //
        private void DeletarRegistro()
        {
            // Exibe a mensagem de confirmação usando MessageBox.Show
            var message = $"""
                        Deseja Excluir o Registro {espacosFestas.espc_nome} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
            var result = myUtilities.myMessageBox(this, message, "Excluir Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Chama o método para excluir o cliente
                    if (repEspacosEF.DeleteItem(idRegistro!.Value))
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        myUtilities.myMessageBox(this, "Erro ao excluir espaço de festas!", "Item Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Label lblNome = new Label { Text = "Espaço Festa:", Location = new Point(lblCol, rowControl) };
            TextBox txtNome = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtEspaco", Width = larguraNome };

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

            // Ajusta a largura do formulário. com largura minima em 500
            this.Width = larguraTotal < 550 ? 550 : larguraTotal;
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
                var item = espacosFestas.GetItem(idRegistro!.Value);

                if (item != null)
                {
                    var txtNome = this.pnlCentral.Controls["txtEspaco"] as TextBox;

                    if (txtNome != null)
                    {
                        txtNome.Text = item.espc_nome;
                        int maxLength = myFunctions.GetMaxLength("tblfestasstatus", "stt_status");
                        if (maxLength > 0) txtNome.MaxLength = maxLength;
                    }
                }
                //else
                //{
                //    // Exibe mensagem caso o registro não seja encontrado
                //    // myUtilities.myMessageBox(this, "Registro não encontrado.");
                //}
            }
            catch (Exception ex)
            {
                myUtilities.myMessageBox(this, $"Erro ao preencher dados do Pacote: {ex.Message}");
            }
        }

    } // end class FormEspacosFestas : FormBaseCRUD
} // end namespace FestasApp.Views.FestasEspacos
