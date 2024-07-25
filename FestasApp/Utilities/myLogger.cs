//---------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C# .NET
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 14/07/2024
//   Ultima Alteração: 14/07/2024
//   
//   CLASSE myLogger um sistema de logging eficiente para monitorar e depurar exceções.
//  
//---------------------------------------------------------------

namespace FestasApp.Utilities
{
    public static class myLogger
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void LogInfo(string message)
        {
            logger.Info(message);
        }

        public static void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public static void LogError(string message, Exception ex)
        {
            logger.Error(ex, message);
        }

        public static void LogFatal(string message, Exception ex)
        {
            logger.Fatal(ex, message);
        }
    }
}

