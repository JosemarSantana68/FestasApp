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
//  Este controle personalizado, myLblCompromisso, faz parte Aplicativo para Controle de Festas & Eventos,
//  Ele estende a funcionalidade do controle Label com comportamentos adicionais e configurações de estilo.
//
//************************************************************

namespace FestasApp.Views.Calendario
{
    public class myLblCompromisso : Label
    {
        // Armazena a cor original do painel
        private Color _originalBackColor;
        private Color _originalForeColor;
        //
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            // Salva a cor original atual
            _originalBackColor = BackColor;
            _originalForeColor = ForeColor;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);          
            // Altera a cor do fundo quando o mouse entra no painel
            //BackColor = Color.DarkOrange;
            ForeColor = Color.DarkOrange;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            // Restaura a cor original quando o mouse sai do painel
            //BackColor = _originalBackColor;
            ForeColor = _originalForeColor;
        }
    }
}
