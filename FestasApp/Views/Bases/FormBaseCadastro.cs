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
        public void TratarBtnCrud(bool desabilitar)
        {
            if (tstbtnEditar != null) tstbtnEditar.Enabled = !desabilitar;
            if (tstbtnConsultar != null) tstbtnConsultar.Enabled = !desabilitar;
            if (tstbtnExcluir != null) tstbtnExcluir.Enabled = !desabilitar;
        }
        //
        // Evento disparado ao clicar no botão de fechar
        private void tstbtnFechar_Click(object sender, EventArgs e)
        {
            // Fecha o formulário atual
            this.Close();
        }


    } // end class
} // end namespace
