//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 05/07/2024
//   Ultima Alteração: 07/07/2024
//   
//   CLASSE myDateTime para auxiliar nas validações de Datas
//  
//************************************************************

using System.Diagnostics;

namespace FestasApp.Utilities
{
    public static class myDateTime
    {
        /// <summary>
        /// Valida uma data no formato "ddMMyyyy" e retorna um booleano indicando se a data é válida.
        /// </summary>
        /// <param name="data">A data a ser validada.</param>
        /// <returns>True se a data for válida, caso contrário, false.</returns>
        public static bool ValidDate(string data)
        {
            DateTime dataConvertida;
            var result = DateTime
                .TryParseExact(data, "ddMMyyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dataConvertida);

            return result;
        }

        /// <summary>
        /// Valida uma data no formato "dd/MM/yyyy" e retorna uma mensagem indicando o resultado da validação.
        /// </summary>
        /// <param name="data">A data a ser validada.</param>
        /// <returns>"ok" se a data for válida, caso contrário, uma mensagem de erro.</returns>
        public static string ValidDateMsg(string data)
        {
            DateTime dataConvertida;
            var result = DateTime
                .TryParseExact(data, "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dataConvertida);

            if (result)
            {
                if (dataConvertida.Year > 1900 && dataConvertida <= DateTime.Today.AddYears(100))
                {
                    return "ok";
                }
                else
                {
                    return $"Ano está fora da faixa de 1901 até {DateTime.Today.AddYears(100).ToString("dd/MM/yyyy")}";
                }
            }
            else
            {
                return "Data inválida!";
            }
        }

        /// <summary>
        /// Valida uma hora no formato "hh:mm" e retorna um booleano indicando se a hora é válida.
        /// </summary>
        /// <param name="time">A hora a ser validada.</param>
        /// <returns>True se a hora for válida, caso contrário, false.</returns>
        public static bool ValidTime(string time)
        {
            Debug.WriteLine($"Hora Texto: {time}");

            // Se a string estiver vazia, considere inválida (ou válida, dependendo da sua regra)
            if (string.IsNullOrWhiteSpace(time) || time == "  :")
            {
                return true;
            }

            TimeSpan TimeConvertida;
            var result = TimeSpan
                .TryParseExact(time, "hhmm",
                CultureInfo.InvariantCulture,
                TimeSpanStyles.None,
                out TimeConvertida);

            Debug.WriteLine($"Hora convertida: {TimeConvertida}");

            return result;
        }
        //
        public static string FormatTimeForDisplay(TimeSpan? time)
        {
            return time.HasValue ? time.Value.ToString(@"hh\:mm") : string.Empty;
        }
    }
}
