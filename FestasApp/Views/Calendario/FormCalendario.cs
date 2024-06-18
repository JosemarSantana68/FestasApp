//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do módulo: 13/06/2024
//   Ultima Alteração: 13/06/2024
//   
//   FORMULÁRIO CALENDARIO
//
//************************************************************

using System.Globalization;

namespace FestasApp.Views.Calendario
{
    public partial class FormCalendario : Form
    {
        // Criação do objeto da classe de calendário mensal
        private clsMonthlyCalendarInfo _CalendarInfo = null!;// Adiciona a not-nullable annotation

        // Construtor do formulário
        public FormCalendario()
        {
            //MessageBox.Show("Initialize");

            this.DoubleBuffered = true; // Ativa o double buffering
            SuspendLayout();

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            // Inicializa o calendário
            _CalendarInfo = new clsMonthlyCalendarInfo();

            // Eventos para o formulário
            this.Load += FormCalendario_Load;
            this.ClientSizeChanged += FormCalendario_ClientSizeChanged;
            this.MonthYearContainer.Click += MonthYearContainer_Click;
            this.LblMonthYear.TextChanged += lblMonthYear_TextChanged;
            ResumeLayout(false);
        }
        //
        // Método chamado ao carregar o formulário principal
        private void FormCalendario_Load(object? sender, EventArgs e)
        {
            //MessageBox.Show("Load");
            PreencherCalendario();
            CriarDadosTeste();
        }
        //
        // Inicialização dos componentes do formulário
        private void ConfigurarFormCalendario()
        {
            SuspendLayout();
            //
            // Configuração inicial dos containers de layout
            ConfigurarContainers();
            ConfiguraMesAno();
            AjustarMesAno();
            AjustarDiasDaSemana();
            AjustarDias();
            //
            ResumeLayout(false);
        }
        //
        // Método chamado ao alterar o tamanho do formulário principal
        private void FormCalendario_ClientSizeChanged(object? sender, EventArgs e)
        {
            // Redimensiona os containers de layout de acordo com o novo tamanho do formulário
            SuspendLayout();
            ConfigurarFormCalendario();
            ResumeLayout(false);
        }
        //
        // Método para definir o tamanho dos containers baseado no formulário principal
        private void ConfigurarContainers()
        {
            SuspendLayout();

            // LINHAS DOS DIAS - Cálculo do tamanho e posição dos containers de dias
            int daysHeight = (ClientSize.Height - MonthYearContainer.Height - DaysOfWeekContainer.Height) / 6; // altura
            int daysYStart = MonthYearContainer.Height + DaysOfWeekContainer.Height; // y - posição inicial

            // Configuração dos containers de cada linha de dias (6 linhas dos dias - 0 a 5)
            for (int i = 0; i < 6; i++)
            {
                Panel? daysRowContainer = Controls[$"DaysRow{i}Containers"] as Panel;
                daysRowContainer!.Size = new Size(ClientSize.Width, daysHeight);
                daysRowContainer.Location = new Point(0, daysYStart + (daysHeight * i));
            }
            ResumeLayout(false);
        }
        //
        // Método para configurar o label do mês e ano
        private void ConfiguraMesAno()
        {
            LblMonthYear.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            LblMonthYear.AutoSize = true;
            LblMonthYear.BackColor = Color.Transparent;
            LblMonthYear.ForeColor = Color.Black;

            LblMonthYear.Text = "Mês Ano";
            LblMonthYear.Text = $"{NomeMes(_CalendarInfo.Month)} {_CalendarInfo.Year}";
        }
        //
        // método para colocar primeira letra DO MÊS em maiúscula
        private void lblMonthYear_TextChanged(object? sender, EventArgs e)
        {
            Label? lbl = sender as Label;
            if (!string.IsNullOrEmpty(lbl?.Text))
            {
                lbl.Text = char.ToUpper(lbl.Text[0]) + lbl.Text.Substring(1);
            }
        }
        //
        // Método para centralizar o label do mês e ano no container
        private void AjustarMesAno()
        {
            SuspendLayout();
            int x = (MonthYearContainer.Width - LblMonthYear.Width) / 2;
            int y = (MonthYearContainer.Height - LblMonthYear.Height) / 2;
            LblMonthYear.Location = new Point(x, y);
            ResumeLayout(false);
        }
        //
        // Método para dimensionar os labels dos dias da semana igualmente
        private void AjustarDiasDaSemana()
        {
            // passa o panel dias da semana como parametro
            AjustarLarguraIgual(DaysOfWeekContainer);
        }
        //
        // Método para dimensionar os controles filhos igualmente em largura
        private void AjustarLarguraIgual(Control c)
        {
            SuspendLayout();
            if (c.Controls.Count == 0) return;

            int width = c.Width / c.Controls.Count;
            int x = 0;

            foreach (Control ctrl in c.Controls)
            {
                ctrl.Height = c.Height;
                ctrl.Width = width;
                ctrl.Location = new Point(x, 0);
                x += width;
            }
            ResumeLayout(false);
        }
        //
        // Método para dimensionar os painéis dos dias
        private void AjustarDias()
        {
            for (int i = 0; i < 6; i++)
            {
                // passa os 6 paineis linhas dos dias do mes 0 - 5
                Panel? daysRowContainer = Controls[$"DaysRow{i}Containers"] as Panel;
                AjustarLarguraIgual(daysRowContainer!);
            }
        }
        //------------------------------------------------------------
        // Método para preencher o calendário com os dias do mês atual
        private void PreencherCalendario()
        {
            SuspendLayout();
            // Verifica se _CalendarInfo é null e inicializa se necessário
            if (_CalendarInfo == null)
            {
                _CalendarInfo = new clsMonthlyCalendarInfo();
            }

            LblMonthYear.Text = $"{NomeMes(_CalendarInfo.Month)} {_CalendarInfo.Year}";

            // for das linhas 0 - 5
            for (int rowIndex = 0; rowIndex < 6; rowIndex++)
            {
                // for das colunas 0 - 6
                for (int colIndex = 0; colIndex < 7; colIndex++)
                {
                    Panel? container = Controls[$"DaysRow{rowIndex}Containers"] as Panel;
                    Panel? pnl = container!.Controls[$"PnlDay{rowIndex}{colIndex}"] as Panel;
                    Label? lbl = pnl!.Controls[$"LblDayOfMonth{rowIndex}{colIndex}"] as Label;

                    // escreve dia do mes ba label
                    lbl!.Text = _CalendarInfo.DayInMonth(rowIndex, colIndex).ToString();

                    // pinta a fonte para mes ativo
                    if (_CalendarInfo.IsActiveMonth(rowIndex, colIndex))
                    {
                        lbl.ForeColor = Color.White;
                        pnl!.BackColor = Color.FromArgb(26, 32, 40);
                    }
                    // pinta mês inativo
                    else
                    {
                        lbl.ForeColor = Color.Gray;
                        pnl!.BackColor = Color.FromArgb(56, 62, 68);
                    }

                    // pinta fonte para dia de hoje
                    if (_CalendarInfo.IsToday(rowIndex, colIndex))
                    {
                        lbl.ForeColor = Color.DarkGoldenrod;
                        lbl.Text += " - Hoje";
                    }
                }
            }
            ResumeLayout(false);
        }
        //
        // Método para criar dados de teste no calendário
        private void CriarDadosTeste()
        {
            // Remove eventos antigos do calendário
            RemoverDadosEventos(this);

            // Dicionário para armazenar datas e seus respectivos compromissos
            var compromissosPorData = new Dictionary<DateTime, List<string>>()
            {
                { new DateTime(2024, 5, 18), new List<string> { "Compromisso 1" } },
                { new DateTime(2024, 4, 12), new List<string> { "Compromisso 2" } },
                { new DateTime(2024, 6, 5), new List<string> { "Compromisso 3", "Compromisso 4" } } // Dois compromissos na mesma data
            };

            foreach (var item in compromissosPorData)
            {
                DateTime date = item.Key; // data do compromisso
                List<string> compromissos = item.Value; // compromissos da data

                if (_CalendarInfo.DateExists(date))
                {
                    // Localiza o painel referente à data do compromisso
                    int col = _CalendarInfo.Col(date);
                    int row = _CalendarInfo.Row(date);
                    Panel? container = Controls[$"DaysRow{row}Containers"] as Panel; // linha do mês
                    Panel? pnl = container!.Controls[$"PnlDay{row}{col}"] as Panel;  // dia da linha

                    //// Calcula a posição Y para o novo Label
                    //int nextLabelPositionY = 0;
                    //// Calcula a posição Y para o novo Label
                    //foreach (Control ctrl in pnl!.Controls)
                    //{
                    //    nextLabelPositionY += ctrl.Height;
                    //}

                    // Adiciona cada compromisso do dia
                    foreach (string compromisso in compromissos)
                    {
                        Label lbl = new myLblCompromisso()
                        {
                            Name = $"LblEvento{row}{col}{pnl!.Controls.Count}", // Garante nomes únicos para cada label
                            BackColor = Color.FromArgb(240, 240, 240),
                            ForeColor = Color.Black,
                            Text = compromisso,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Size = new Size(pnl.Width, 20), // Define o tamanho do Label
                            //Location = new Point(0, nextLabelPositionY),
                            Location = new Point(0, 20 * pnl.Controls.Count) // Ajusta a posição para evitar sobreposição
                        };
                        pnl.Controls.Add(lbl);
                    }
                }
            }
        }
        //
        // Método chamado ao clicar no container de mês e ano
        private void MonthYearContainer_Click(object? sender, EventArgs e)
        {
            int midPointX = MonthYearContainer.Width / 2;
            Point pointClicked = MonthYearContainer.PointToClient(Cursor.Position);
            DateTime activeMonth = new DateTime(_CalendarInfo.Year, _CalendarInfo.Month, 1);
            DateTime newMonth;

            if (pointClicked.X < midPointX)
                newMonth = activeMonth.AddMonths(-1); // Mês anterior
            else
                newMonth = activeMonth.AddMonths(1); // Próximo mês

            _CalendarInfo.GoToMonth(newMonth.Year, newMonth.Month);

            // Remove eventos antigos do calendário
            RemoverDadosEventos(this);
            PreencherCalendario();
            CriarDadosTeste();
        }
        //
        // Método recursivo para remover dados de teste do calendário
        private void RemoverDadosEventos(Control c)
        {
            foreach (Control ctrl in c.Controls)
            {
                RemoverDadosEventos(ctrl);
                if (ctrl.Parent != null && ctrl.Name.Contains("LblEvento"))
                    ctrl.Parent.Controls.Remove(ctrl);
            }
        }
        //
        // Função auxiliar para retornar o nome do mês com base no número do mês
        private string NomeMes(int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }
        //
    }// end class
} // namespace

