//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do módulo: 16/06/2024
//   Ultima Alteração: 16/06/2024
//    
//   FUNÇÕES AUXILIARES
//
//  Este controle personalizado, myLblDiasMes, faz parte Aplicativo para Controle de Festas & Eventos,
//  Ele estende a funcionalidade do controle Label com comportamentos adicionais e configurações de estilo.
//
//************************************************************

namespace FestasApp.Views.Calendario
{
    public class myLblDiasMes : Label
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Dock = DockStyle.Top;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            AutoSize = false;
            Height = 20;
        }
    }
}
