//------------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 05/07/2024
//   Ultima Alteração: 07/07/2024
//   
//   CLASSE myDateTime para auxiliar nas validações de Datas e Horas
//  
//------------------------------------------------------------------

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
                .TryParseExact(data, "dd/MM/yyyy",
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
        //

        /// <summary>
        /// Valida uma hora no formato "hh:mm" e retorna um booleano indicando se a hora é válida.
        /// </summary>
        /// <param name="time">A hora a ser validada.</param>
        /// <returns>True se a hora for válida, caso contrário, false.</returns>
        public static bool ValidTime(string time, string mask = @"hh\:mm")
        {
            //Debug.WriteLine($"Hora Texto: {time}");

            // Se a string estiver vazia, considere inválida (ou válida, dependendo da sua regra)
            if (string.IsNullOrWhiteSpace(time) || time == "  :")
            {
                return true;
            }

            TimeSpan TimeConvertida;
            var result = TimeSpan
                .TryParseExact(time, mask,
                CultureInfo.InvariantCulture,
                TimeSpanStyles.None,
                out TimeConvertida);

            //Debug.WriteLine($"Hora convertida: {TimeConvertida}");

            return result;
        }
        //
        // método para formatar hora em texto, para apresentar no form
        public static string FormatTimeForDisplay(TimeSpan? time, string mask = @"hh\:mm")
        {
            // Verifica se o tempo tem valor e retorna formatado, caso contrário retorna string vazia
            return time.HasValue ? time.Value.ToString(mask) : string.Empty;
        }
        //
        // método para formatar texto em hora, para salvar em repositório
        public static TimeSpan? FormatTimeToRap(string txtTime, string mask = @"hh\:mm")
        {
            if (string.IsNullOrWhiteSpace(txtTime))
            {
                return null; // Retorna nulo se o texto estiver vazio ou for nulo
            }

            try
            {
                // Tenta converter o texto em TimeSpan usando o formato especificado
                return TimeSpan.ParseExact(txtTime, mask, CultureInfo.InvariantCulture);
            }
            catch (FormatException ex)
            {
                // Lida com exceções de formato e retorna nulo ou uma mensagem de erro apropriada
                Console.WriteLine($"Erro ao formatar o tempo: {ex.Message}");
                return null;
            }
        }
        

    } // end static class myDateTime
} // end namespace
