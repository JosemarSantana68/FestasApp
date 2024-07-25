//--------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação deste Módulo: 11/07/2024
//   Ultima Alteração: 11/07/2024
//   
//   Esta classe será responsável pela configuração dos controles do formulário.
//--------------------------------------------------------------

namespace FestasApp.Views.TabelasAuxiliares
{
    public class ControlConfigurator
    {
        private readonly FormAuxiliaresMain _form;

        public ControlConfigurator(FormAuxiliaresMain form)
        {
            _form = form;
        }

        public void ConfigureControls()
        {
            _form.dtgRegistrosTabelasAuxiliares.Dock = DockStyle.Fill;
            //_form.pnlCabecalho.Height = 60;
        }
    }


}
