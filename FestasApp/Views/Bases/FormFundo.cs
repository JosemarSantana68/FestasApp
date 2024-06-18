//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 06/06/2024
//   Ultima Alteração: 
//   
//   FORMULÁRIO FUNDO SOBREAMENTO
//
//************************************************************

namespace FestasApp.Views.Bases
{
    public partial class FormFundo : Form
    {
        public FormFundo(Form form = null)
        {
            InitializeComponent();

            // Verifica se o parâmetro form é null e, se for, define-o como FormMenuBase
            if (form == null)
            {
                form = FormMenuBase.Instance; // uma instância de ForMenuBase
            }

            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.5;
            this.BackColor = Color.Black;
            //this.TopMost = true;

            // tamanho e posição
            this.Width = form.Width;
            this.Height = form.Height;
            this.Top = form.Top;
            this.Left = form.Left;

        }
        // EXEMPLO DE CHAMADA...
        ////private void button1_Click(object sender, EventArgs e)
        ////{
        ////    // Abra o formulário de edição de clientes passando o cliente
        ////    using (FormFundo frm = new FormFundo(FormMenuBase.Instance))
        ////    {
        ////        frm.ShowDialog();
        ////    }
        ////}


    } // end class
} // end namespace
