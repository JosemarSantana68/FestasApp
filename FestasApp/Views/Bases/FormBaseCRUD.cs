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
        public FormBaseCRUD()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void tstbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
