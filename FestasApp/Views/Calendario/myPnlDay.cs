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
//  Este controle personalizado, myPnlDay, faz parte Aplicativo para Controle de Festas & Eventos,
//  Ele estende a funcionalidade do controle Panel com comportamentos adicionais e configurações de estilo.
//
//************************************************************

namespace FestasApp.Views.Calendario
{
    public class myPnlDay : Panel
    {
        // Armazena a cor original do painel
        //private Color _originalBackColor;
        private Color _tempBackColor;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Font = new Font("Segoe UI", 10, FontStyle.Regular);
            BorderStyle = BorderStyle.FixedSingle; // Adiciona bordas aos painéis dos dias
            BackColor = Color.FromArgb(26,32,40);
            ForeColor = Color.White;
            Cursor = Cursors.Hand;
            // Salva a cor original atual
            //_originalBackColor = BackColor;
        }
        //
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            // Salva a cor do fundo atual
            _tempBackColor = BackColor;
            // Altera a cor do fundo quando o mouse entra no painel
            BackColor = Color.FromArgb(37, 46, 59);

        }
        //
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            // Restaura a cor original quando o mouse sai do painel
            //BackColor = _originalBackColor;
            // Restaura a cor do fundo anterior quando o mouse sai do painel
            BackColor = _tempBackColor;

        }

    } // end class myPnlDay
} // end namespace FestasApp.Views.Calendario
