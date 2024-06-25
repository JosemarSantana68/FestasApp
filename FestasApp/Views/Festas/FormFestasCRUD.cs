//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//  Inicio: 23/05/2024
//  Criação do Módulo: 24/06/2024
//  Ultima Alteração: 24/06/2024
//   
//   FORMULÁRIO DE FESTAS C.R.U.D.
//
//************************************************************
namespace FestasApp.Views.Festas
{
    public partial class FormFestasCRUD : FormBaseCRUD
    {
        // instanciar objetos das classe para este form
        private clsFestas festa;
        private OperacaoCRUD operacao;
        //
        // Construtor que recebe um objeto da classe que chama e a operação
        public FormFestasCRUD(clsFestas _festa, OperacaoCRUD _operacao)
        {
            InitializeComponent();

            this.festa = _festa;
            this.operacao = _operacao;

            SuspendLayout();
                ConfigurarFormBaseCrud("F e s t a s", operacao);
            ResumeLayout();
        }


    }
}
