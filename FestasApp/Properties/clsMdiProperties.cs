//-------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 12/06/2024
//   
//   CLASSE CLSMDIPROPERTIES
//-------------------------------------------------------------

using System.Runtime.InteropServices;

namespace FestasApp.Properties
{
    public static class clsMdiProperties
    {
        // Importa a função GetWindowLong da DLL User32 para obter informações sobre a janela.
        [DllImport("User32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // Importa a função SetWindowLong da DLL User32 para definir informações sobre a janela.
        [DllImport("User32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        // Importa a função SetWindowPos da DLL User32 para definir a posição e outras propriedades da janela.
        [DllImport("User32.dll")]
        private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // Constantes utilizadas para manipular os estilos da janela.
        private const int GWL_EXSTYLE = -20; // Índice para obter o estilo estendido da janela.
        private const int WS_EX_CLIENTEDGE = 0X200; // Estilo para borda de cliente.
        private const uint SWP_NOSIZE = 0X0001; // Não ajusta o tamanho da janela.
        private const uint SWP_NOMOVE = 0X0002; // Não ajusta a posição da janela.
        private const uint SWP_NOZORDER = 0X0004; // Não altera a ordem Z da janela.
        private const uint SWP_NOACTIVATE = 0X0010; // Não ativa a janela.
        private const uint SWP_FRAMECHANGED = 0X0020; // Força uma alteração na estrutura da janela.
        private const uint SWP_NOOWNERZORDER = 0X0200; // Não altera a ordem Z do proprietário da janela.

        // Método SETBEVEL para definir ou remover a borda do cliente em um formulário MDI.
        public static bool ConfiguraBorda(this Form form, bool show)
        {
            // Percorre todos os controles do formulário.
            foreach (Control c in form.Controls)
            {
                // Verifica se o controle é um MdiClient.
                if (c is MdiClient client)
                {
                    // Obtém o estilo atual da janela.
                    int windowLong = GetWindowLong(c.Handle, GWL_EXSTYLE);

                    // Ajusta o estilo da janela para adicionar ou remover a borda do cliente.
                    if (show)
                    {
                        windowLong |= WS_EX_CLIENTEDGE; // Adiciona a borda.
                    }
                    else
                    {
                        windowLong &= ~WS_EX_CLIENTEDGE; // Remove a borda.
                    }

                    // Define o novo estilo da janela.
                    SetWindowLong(c.Handle, GWL_EXSTYLE, windowLong);

                    // Atualiza a posição e a estrutura da janela.
                    SetWindowPos(client.Handle, IntPtr.Zero, 0, 0, 0, 0,
                        SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER |
                        SWP_NOOWNERZORDER | SWP_FRAMECHANGED);

                    return true; // Sucesso na alteração da borda.
                }
            }
            return false; // Nenhum MdiClient encontrado no formulário.
        }
    } // end class
} // end namespace
