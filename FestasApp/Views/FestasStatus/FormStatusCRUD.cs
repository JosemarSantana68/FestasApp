﻿//------------------------------------------------------------
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


namespace FestasApp.Views.FestasStatus
{
    public partial class FormStatusCRUD : FormBaseCRUD
    {
        // declara instâncias
        private readonly repStatusEF statusFesta = new();
        private readonly OperacaoCRUD operacao = new();
        private int? idRegistro;

        public FormStatusCRUD(clsParam idRegistro, OperacaoCRUD operacao)
        {
            InitializeComponent();
            this.idRegistro = idRegistro.Id;
            this.operacao = operacao;

            SuspendLayout();
            ConfigurarFormBaseCrud("S t a u t s", operacao);
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
        //
        private void SalvarRegistro()
        {
            var txtNome = this.pnlCentral.Controls["txtStatus"] as TextBox;

            // Validação dos controles - Verifica se todos os campos necessários estão preenchidos
            if (string.IsNullOrEmpty(txtNome!.Text))
            {
                myUtilities.myMessageBox(this, "Por favor, preencha nome do Status da Festas.", "Status da Festa");
                return;
            }

            // Recupera os valores dos controles
            string nome = txtNome.Text ?? string.Empty;

            // Cria uma instância da classe e salva os dados sem passar o ID
            clsFestasStatus item = new(nome);

            try
            {
                if (operacao == OperacaoCRUD.NOVO)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repStatusEF.AddItem(item))
                    {
                        myUtilities.myMessageBox(this, "Status de Festas adicionado com sucesso!", "Status de Festas");
                        this.Close();
                    }
                    else
                    {
                        myUtilities.myMessageBox(this, "Falha ao adicionar o Status de Festas.", "Status de Festas");
                    }
                }
                else if (operacao == OperacaoCRUD.EDITAR)
                {
                    // Tenta adicionar o item de festa ao banco de dados
                    if (repStatusEF.AlterItem(idRegistro!.Value, item))
                    {
                        myUtilities.myMessageBox(this, "Status da Festas alterado com sucesso!", "Espaço de Festas");
                        this.Close();
                    }
                    else
                    {
                        myUtilities.myMessageBox(this, "Falha ao alterar o Status da Festas.", "Espaço de Festas");
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
                        Deseja Excluir o Registro {statusFesta.stt_status} ?
                        
                        Esta ação não poderá ser desfeita!
                        """;
            var result = myUtilities.myMessageBox(this, message, "Excluir Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Chama o método para excluir o cliente
                    if (repStatusEF.DeleteItem(idRegistro!.Value))
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        // Exibe a mensagem de erro se a exclusão falhar
                        myUtilities.myMessageBox(this, "Erro ao excluir Status da festas!", "Item Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Label lblNome = new Label { Text = "Status:", Location = new Point(lblCol, rowControl) };
            TextBox txtNome = new myTextBox { Location = new Point(txtCol, rowControl), Name = "txtStatus", Width = larguraNome };

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
            this.Width = larguraTotal < 550? 550: larguraTotal;
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
                var item = statusFesta.GetItem(idRegistro!.Value);

                if (item != null)
                {
                    var txtStatus = this.pnlCentral.Controls["txtStatus"] as TextBox;

                    if (txtStatus != null)
                    {
                        txtStatus.Text = item.stt_status;
                        int maxLength = myFunctions.GetMaxLength("tblfestasstatus", "stt_status"); // conferir tabela
                        if (maxLength > 0) txtStatus.MaxLength = maxLength;
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
                myUtilities.myMessageBox(this, $"Erro ao preencher dados do Pacote: {ex.Message}");
            }
        }


    } // end class FormStatusCRUD : FormBaseCRUD
} // end namespace FestasApp.Views.FestasStatus