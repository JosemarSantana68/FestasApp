//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 19/06/2024
//   
//   FORMULÁRIO BASE DE CADASTRO
//
//************************************************************

namespace FestasApp.Views
{
    public partial class FormBaseCadastro : Form
    {
        // construtor...
        public FormBaseCadastro()
        {
            InitializeComponent();
            ConfigurarFormBaseCadastro();
        }
        //
        private void FormBaseCadastro_Load(object sender, EventArgs e)
        {
            // Outras configurações de carregamento podem ser adicionadas aqui, se necessário
        }
        //
        // Configurações iniciais do formulário de cadastro base
        private void ConfigurarFormBaseCadastro()
        {
            // Remove a borda do formulário
            this.FormBorderStyle = FormBorderStyle.None;
            // Remove os botões de controle padrão (minimizar, maximizar, fechar)
            this.ControlBox = false;
        }
        //
        // Método para ajustar o estado dos botões de CRUD
        /// <summary>
        /// Ajusta o estado dos botões de CRUD
        /// </summary>
        /// <param name="desabilitar">True para desabilitar os botões, False para habilitar</param>
        public void TratarBtnCrud(bool habilitado)
        {
            if (tstbtnEditar != null) tstbtnEditar.Enabled = habilitado;
            if (tstbtnConsultar != null) tstbtnConsultar.Enabled = habilitado;
            if (tstbtnExcluir != null) tstbtnExcluir.Enabled = habilitado;
        }
        //
        // Evento disparado ao clicar no botão de fechar
        private void tstbtnFechar_Click(object sender, EventArgs e)
        {
            // Fecha o formulário atual
            this.Close();
        }
        public void AbrirFormCRUDGenerico<T, TForm>(DataGridView dtg,
                                             int colIdIndex,
                                             Func<DataGridViewRow, T> mapper,
                                             Action reloadGrid,
                                             Func<T, OperacaoCRUD, TForm> formFactory,
                                             OperacaoCRUD operacao,
                                             int delay = 1000)
            where T : class
            where TForm : Form
        {
            // Verifique se há uma linha selecionada no DataGridView
            if (dtg.CurrentRow != null)
            {
                // Pegue o índice da linha atual
                int rowIndex = dtg.CurrentRow.Index;

                // Verifique se a célula da coluna desejada, ID, não é nula
                if (dtg.Rows[rowIndex].Cells[colIdIndex].Value != null)
                {
                    try
                    {
                        // Mapear os dados da linha selecionada para o objeto do domínio
                        T objeto = mapper(dtg.Rows[rowIndex]);

                        // Criar e abrir o formulário CRUD passando o objeto e a operação
                        using (TForm frm = formFactory(objeto, operacao))
                        {
                            // Usar a Modal para exibir o FormCRUD
                            FormMenuMain.ShowModalOverlay(frm, delay: delay);

                            // Atualizar DataGrid após a operação CRUD
                            reloadGrid();
                        }
                    }
                    catch (FormatException)
                    {
                        FormMenuMain.ShowMyMessageBox("O valor na coluna ID não é um número válido.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidCastException)
                    {
                        FormMenuMain.ShowMyMessageBox("Não foi possível converter o valor na coluna ID para um número inteiro.", "Erro de Conversão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        FormMenuMain.ShowMyMessageBox($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FormMenuMain.ShowMyMessageBox("A célula da coluna ID está vazia.", "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                FormMenuMain.ShowMyMessageBox("Nenhuma linha está selecionada.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } // end AbrirFormCRUDGenerico()




    } // end class
} // end namespace
