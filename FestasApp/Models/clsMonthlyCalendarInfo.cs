//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 13/06/2024
//   Ultima Alteração: 13/06/2024
//   
//   CLASSE AUXILIAR PARA FORMCALENDARIO
//
//************************************************************

namespace FestasApp.Models
{
    public class clsMonthlyCalendarInfo
    {
        // Membros para armazenar o mês, ano e os dias do calendário
        private int _Month;
        private int _Year;
        private readonly DateTime[,] _Days = new DateTime[6, 7]; // Matriz para armazenar os dias do calendário

        // Propriedades somente leitura para acessar o mês e ano
        public int Month => _Month;
        public int Year => _Year;

        // Construtor padrão: inicializa com o mês e ano atuais e configura os dias
        public clsMonthlyCalendarInfo()
        {
            _Month = DateTime.Now.Month;
            _Year = DateTime.Now.Year;
            SetDays();
        }

        // Segundo construtor: permite especificar ano e mês se forem válidos
        public clsMonthlyCalendarInfo(int year, int month)
        {
            if (year < 1 || year > 9999)
                throw new ArgumentOutOfRangeException(nameof(year));

            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month));

            _Month = month;
            _Year = year;
            SetDays();
        }

        // Configura os dias do calendário com base no mês e ano atuais
        private void SetDays()
        {
            DateTime firstDayOfMonth = new DateTime(_Year, _Month, 1);
            int column = (int)firstDayOfMonth.DayOfWeek;
            DateTime firstDayOfGrid = firstDayOfMonth.AddDays(column * -1);
            DateTime gridDate = firstDayOfGrid;

            for (int rowIndex = 0; rowIndex < 6; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 7; colIndex++)
                {
                    _Days[rowIndex, colIndex] = gridDate;
                    gridDate = gridDate.AddDays(1);
                }
            }
        }

        // Método para mudar para um novo mês
        public void GoToMonth(int year, int month)
        {
            if (year < 1 || year > 9999)
                throw new ArgumentOutOfRangeException(nameof(year));

            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month));

            _Month = month;
            _Year = year;
            SetDays();
        }

        // Retorna o dia para a linha e coluna especificadas
        public int DayInMonth(int row, int column)
        {
            if (row < 0 || row > 5)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (column < 0 || column > 6)
                throw new ArgumentOutOfRangeException(nameof(column));

            return _Days[row, column].Day;
        }

        // Verifica se o mês da linha e coluna especificadas é igual ao mês atual
        public bool IsActiveMonth(int row, int column)
        {
            if (row < 0 || row > 5)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (column < 0 || column > 6)
                throw new ArgumentOutOfRangeException(nameof(column));

            return _Days[row, column].Month == Month;
        }

        // Verifica se o dia da linha e coluna especificadas é igual ao dia atual
        public bool IsToday(int row, int column)
        {
            if (row < 0 || row > 5)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (column < 0 || column > 6)
                throw new ArgumentOutOfRangeException(nameof(column));

            return _Days[row, column].Date == DateTime.Today;
        }

        // Retorna a linha onde a data especificada está no calendário
        public int Row(DateTime dt)
        {
            for (int rowIndex = 0; rowIndex < 6; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 7; colIndex++)
                {
                    if (_Days[rowIndex, colIndex] == dt)
                        return rowIndex;
                }
            }
            return -1;
        }
        //
        // Retorna a coluna onde a data especificada está no calendário
        public int Col(DateTime dt)
        {
            for (int rowIndex = 0; rowIndex < 6; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 7; colIndex++)
                {
                    if (_Days[rowIndex, colIndex] == dt)
                        return colIndex;
                }
            }
            return -1;
        }

        // Verifica se a data especificada está no calendário atual
        public bool DateExists(DateTime dt)
        {
            return Row(dt) > -1;
        }
    }

}
