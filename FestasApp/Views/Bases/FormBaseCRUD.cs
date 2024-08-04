//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 
//   
//   FORMULÁRIO BASE DE C.R.U.D.
//
//************************************************************
namespace FestasApp.ViewModels
{
    public partial class FormBaseCRUD : Form
    {
        // construtor padrão
        public FormBaseCRUD()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
        }
        //
        // Configura o formulário com base na operação
        public void ConfigurarFormBaseCrud(string nomeform, OperacaoCRUD operacao)
        {
            lblTitulo.Text = $"C a d a s t r o   d e   {nomeform}";
            lblOperacao.Text = string.Empty;
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
                    ConfigurarBotaoExcluir();
                    break;
                case OperacaoCRUD.CONSULTAR:
                    this.lblOperacao.Text = " C O N S U L T A R";
                    tstbtnSalvar.Enabled = false;
                    ConfigurarBotaoCancelar();
                    break;
            }
        }
        //
        // btn consultar
        public void ConfigurarBotaoCancelar()
        {
            tstbtnCancel.Text = "Fechar";
            tstbtnCancel.ToolTipText = "Fechar";
            tstbtnSalvar.Visible = false;
            tstSeparadorSalvar.Visible = false;
        }
        //
        // btn excluir
        public void ConfigurarBotaoExcluir()
        {
            tstbtnSalvar.Text = "Excluir";
            tstbtnSalvar.ToolTipText = "Excluir";
            tstbtnSalvar.Image = Properties.Resources.delete;
        }
        //
        // btn cancelar
        private void tstbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    } // end class FormBaseCRUD
} // end namespace
