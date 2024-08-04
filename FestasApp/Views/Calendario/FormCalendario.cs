//-------------------------------------------------------------------
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
//-------------------------------------------------------------------

namespace FestasApp.Views.Calendario
{
    public partial class FormCalendario : Form
    {
        // Criação do objeto da classe de calendário mensal
        private clsMonthlyCalendarInfo _CalendarInfo = null!;// Adiciona a not-nullable annotation

        // Construtor padrão do formulário
        public FormCalendario()
        {
            //
            this.DoubleBuffered = true; // Ativa o double buffering
            SuspendLayout();
            InitializeComponent();
                this.FormBorderStyle = FormBorderStyle.None;
                // Inicializa o calendário
                _CalendarInfo = new clsMonthlyCalendarInfo();
                AddEventHandlers();
            ResumeLayout(false);
        }
        //
        // Método chamado ao carregar o formulário.Show()
        private void FormCalendario_Load(object? sender, EventArgs e)
        {
            PreencherCalendario(); // monta os dias e semanas do clendario
            CriarDadosCalendarioEF(); // preenche com os dados da tblFestas
            //CriarDadosTeste();
        }
        //
        // Adiciona eventos handlers
        private void AddEventHandlers()
        {
            // Eventos para o formulário
            this.Load += FormCalendario_Load;
            this.ClientSizeChanged += FormCalendario_ClientSizeChanged;
            this.LblMonthYear.Click += MonthYearContainer_Click;
            this.LblMonthYear.TextChanged += lblMonthYear_TextChanged;
            // container Mês Ano
            lblMesAntes.Click += MudarMesAntes_Click;
            picMesAntes.Click += MudarMesAntes_Click;
            lblMesApos.Click += MudarMesApos_Click;
            picMesApos.Click += MudarMesApos_Click;
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
        // Inicialização dos componentes do formulário
        private void ConfigurarFormCalendario()
        {
            SuspendLayout();
                // Configuração inicial dos containers de layout
                ConfigurarContainers();
                ConfiguraMesAno();
                //AjustarMesAno();
                AjustarDiasDaSemana();
                AjustarDias();
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
            LblMonthYear.AutoSize = false;
            LblMonthYear.BackColor = Color.Transparent;
            LblMonthYear.ForeColor = Color.Black;
            LblMonthYear.TextAlign = ContentAlignment.MiddleCenter;

            LblMonthYear.Text = "Mês Ano";
            LblMonthYear.Text = $"{NomeMes(_CalendarInfo.Month)} {_CalendarInfo.Year}";
        }
        //
        // método para colocar primeira letra DO MÊS em maiúscula
        private void lblMonthYear_TextChanged(object? sender, EventArgs e)
        {
            Label? lbl = sender as Label;

            if (lbl != null)
            {
                lbl.Text = lbl.Text.ToPrimeUpper();
            }
            // mudar datas antes e depois
            DateTime activeMonth = new DateTime(_CalendarInfo.Year, _CalendarInfo.Month, 1);
            DateTime newMonth;
            //mes/ano antes
            newMonth = activeMonth.AddMonths(-1);
            lblMesAntes.Text = $"{NomeMes(newMonth.Month)} {newMonth.Year}".ToPrimeUpper();
            //mes/ano depois
            newMonth = activeMonth.AddMonths(1);
            lblMesApos.Text = $"{NomeMes(newMonth.Month)} {newMonth.Year}".ToPrimeUpper();
        }
        //
        // Método para centralizar o label do mês e ano no container
        private void AjustarMesAno()
        {
            SuspendLayout();
            int x = (MonthYearContainer.Width - LblMonthYear.Width) / 2; // meio da largura
            int y = (MonthYearContainer.Height - LblMonthYear.Height) / 2; // meio da altura
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
            // testa se há controles
            if (c.Controls.Count == 0) return;

            // ajusta a largura
            int width = c.Width / c.Controls.Count;
            int x = 0;
            // ajusta a altura
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
            _CalendarInfo ??= new clsMonthlyCalendarInfo();

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

                    // Lista temporária para armazenar os controles a serem removidos
                    var controlesParaRemover = new List<Control>();

                    // Coleta os compromissos existentes para evitar duplicação ao recarregar
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl != null && ctrl.Name.Contains("LblEvento"))
                            controlesParaRemover.Add(ctrl);
                    }

                    // Remove os controles fora do loop de iteração
                    foreach (Control ctrl in controlesParaRemover)
                    {
                        pnl.Controls.Remove(ctrl);
                    }

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
        // Método chamado ao clicar no label lblMonthYear de mês e ano
        private void MonthYearContainer_Click(object? sender, EventArgs e)
        {
            int midPointX = LblMonthYear.Width / 2;
            Point pointClicked = LblMonthYear.PointToClient(Cursor.Position);
            DateTime activeMonth = new DateTime(_CalendarInfo.Year, _CalendarInfo.Month, 1);
            DateTime newMonth;
            if (pointClicked.X < midPointX)
            {
                newMonth = activeMonth.AddMonths(-1); // Mês anterior
            }
            else
            {
                newMonth = activeMonth.AddMonths(1); // Próximo mês
            }
            _CalendarInfo.GoToMonth(newMonth.Year, newMonth.Month);
            AtualizaMesAno();
        }
        //
        // Método chamado ao clicar no container de mês e ano
        private void MudarMesAntes_Click(object? sender, EventArgs e)
        {
            DateTime activeMonth = new DateTime(_CalendarInfo.Year, _CalendarInfo.Month, 1);
            DateTime newMonth;
            newMonth = activeMonth.AddMonths(-1); // Mês anterior
            _CalendarInfo.GoToMonth(newMonth.Year, newMonth.Month);
            AtualizaMesAno();
        }
        //
        // Método chamado ao clicar no container de mês e ano
        private void MudarMesApos_Click(object? sender, EventArgs e)
        {
            DateTime activeMonth = new DateTime(_CalendarInfo.Year, _CalendarInfo.Month, 1);
            DateTime newMonth;
            newMonth = activeMonth.AddMonths(1); // Próximo mês
            _CalendarInfo.GoToMonth(newMonth.Year, newMonth.Month);
            lblMesAntes.Text = $"{NomeMes(_CalendarInfo.Month)} {_CalendarInfo.Year}";
            AtualizaMesAno();
        }
        //
        private void AtualizaMesAno()
        {
            //RemoverDadosEventos(this);
            PreencherCalendario();
            CriarDadosCalendarioEF();
            //CriarDadosTeste();
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
        private void picBtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        //*******************************************************************************
        // Método para popular festas no calendário EM UMA LABEL (tipo-festa nome-cliente)

        /// <summary>
        /// Popula um dicionário com as festas por data.
        /// </summary>
        /// <returns>Um dicionário onde a chave é a data da festa e o valor é uma lista de strings
        /// com o tipo de evento e nome do cliente.</returns>
        private Dictionary<DateTime, List<string>> PopularFestas()
        {
            // Dicionário para armazenar datas das festas e seus respectivos clientes e tipos de eventos
            var compromissosPorData = new Dictionary<DateTime, List<string>>();

            try
            {
                using (clsFestasContext context = new clsFestasContext())
                {
                    // Consultar dados do banco de dados
                    var festas = context.Festas
                                        .Include(f => f.Cliente)
                                        .Include(f => f.TipoEvento)
                                        .ToList();

                    // Popula o dicionário com os dados das festas
                    foreach (var festa in festas)
                    {
                        if (festa.fest_dtFesta.HasValue)
                        {
                            DateTime dataFesta = festa.fest_dtFesta.Value;
                            string compromisso = $"{festa.TipoEvento?.tpev_nome ?? "Evento"}; ({festa.Cliente?.cli_nome ?? "Cliente"})";

                            // Verifica se a data já existe no dicionário
                            if (!compromissosPorData.ContainsKey(dataFesta))
                            {
                                compromissosPorData[dataFesta] = new List<string>();
                            }

                            // Adiciona o compromisso à lista da data correspondente
                            compromissosPorData[dataFesta].Add(compromisso);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Trata a exceção, pode-se adicionar logging ou outras ações aqui
                Console.WriteLine($"Erro ao popular festas: {ex.Message}");
            }

            return compromissosPorData;
        }
        //
        /// <summary>
        /// Popula o calendário com as festas do banco de dados.
        /// </summary>
        private void CriarDadosCalendarioEF()
        {
            try
            {
                // Recebe o dicionário com as festas por data
                var compromissosPorData = PopularFestas();

                // Percorre cada item do dicionário para popular o calendário
                foreach (var item in compromissosPorData)
                {
                    DateTime date = item.Key; // Data do compromisso
                    List<string> compromissos = item.Value; // Lista de compromissos da data

                    // Verifica se a data existe no calendário
                    if (_CalendarInfo.DateExists(date))
                    {
                        // Localiza o painel referente à data do compromisso
                        int col = _CalendarInfo.Col(date); // Coluna no calendário (0 - 6)
                        int row = _CalendarInfo.Row(date); // Linha no calendário (0 - 5)
                        Panel? container = Controls[$"DaysRow{row}Containers"] as Panel; // Linha do mês
                        Panel? pnl = container!.Controls[$"PnlDay{row}{col}"] as Panel;  // Dia da linha

                        // Habilita a barra de rolagem vertical
                        pnl!.AutoScroll = true;
                        pnl.HorizontalScroll.Enabled = false; // Desabilita a barra de rolagem horizontal
                        pnl.HorizontalScroll.Visible = false; // Garante que a barra de rolagem horizontal não seja visível

                        int cont = 1;

                        // Adiciona cada compromisso do dia
                        foreach (string compromisso in compromissos)
                        {
                            // Calcula a altura acumulada das labels existentes
                            int totalHeight = pnl.Controls.Cast<Control>().Sum(ctrl => ctrl.Height);

                            // Define o tamanho da fonte com base no estado do formulário principal
                            Font labelFont = FormMenuMain.InstanceFrmMain!.WindowState == FormWindowState.Maximized
                                ? new Font("Segoe UI", 9, FontStyle.Regular)
                                : new Font("Segoe UI", 7, FontStyle.Regular);

                            // Cria e configura a label que recebe a festa e cliente
                            Label lbl = new myLblCompromisso() // Controle personalizado
                            {
                                Name = $"LblEvento{row}{col}{pnl.Controls.Count}", // Garante nomes únicos para cada label
                                BackColor = Color.Transparent, // Define a cor de fundo da label
                                ForeColor = Color.White, // Define a cor do texto da label
                                Text = $"{cont++}. {compromisso}", // Define o texto da label
                                TextAlign = ContentAlignment.TopLeft, // Alinha o texto à esquerda e no topo
                                Size = new Size(pnl.Width, 18), // Define a altura do label
                                Location = new Point(0, totalHeight + 5), // Ajusta a posição para evitar sobreposição
                                AutoSize = true, // Permite ajuste do tamanho
                                MaximumSize = new Size(pnl.Width, 0), // Limita a largura, permitindo quebra de linha
                                Font = labelFont // Define o tamanho da fonte
                            };

                            // Adiciona o label ao painel do dia
                            pnl.Controls.Add(lbl);
                        }

                        // Define o tamanho mínimo para a barra de rolagem (altura total dos controles dentro do pnl)
                        int vtotalHeight = pnl.Controls.Cast<Control>().Sum(ctrl => ctrl.Height);
                        pnl.AutoScrollMinSize = new Size(0, vtotalHeight);
                    }
                }
            }
            catch (Exception ex)
            {
                // Exceção para tratamento de erros, você pode adicionar logging ou outras ações aqui
                Console.WriteLine($"Erro ao criar dados do calendário: {ex.Message}");
            }
        }
        //
        //*********************** SEM USO **********************
        //
        #region Códigos substituidos e sem uso
        //
        // Método para popular dados no calendário EM DUAS LINHAS
        private void CriarDadosCalendarioEFSEMUSO()
        {
            using (clsFestasContext context = new())
            {
                // Dicionário para armazenar datas das festas e seus respectivos clientes e tipos de eventos
                var compromissosPorData = new Dictionary<DateTime, List<(string TipoEvento, string Cliente)>>();

                // Consultar dados do banco de dados
                var festas = context.Festas
                                    .Include(f => f.Cliente)
                                    .Include(f => f.TipoEvento)
                                    .ToList();

                // Popula o Dicionário
                foreach (var festa in festas)
                {
                    if (festa.fest_dtFesta.HasValue)
                    {
                        DateTime dataFesta = festa.fest_dtFesta.Value;
                        string tipoEvento = festa.TipoEvento?.tpev_nome ?? "Evento";
                        string cliente = festa.Cliente?.cli_nome ?? "Cliente";

                        if (!compromissosPorData.ContainsKey(dataFesta))
                        {
                            compromissosPorData[dataFesta] = new List<(string TipoEvento, string Cliente)>();
                        }
                        compromissosPorData[dataFesta].Add((tipoEvento, cliente));
                    }
                }

                // Mostra o Dicionário
                foreach (var item in compromissosPorData)
                {
                    DateTime date = item.Key; // data do compromisso
                    List<(string TipoEvento, string Cliente)> compromissos = item.Value; // compromissos da data

                    if (_CalendarInfo.DateExists(date))
                    {
                        // Localiza o painel referente à data do compromisso
                        int col = _CalendarInfo.Col(date);
                        int row = _CalendarInfo.Row(date);
                        Panel? container = Controls[$"DaysRow{row}Containers"] as Panel; // linha do mês
                        Panel? pnl = container!.Controls[$"PnlDay{row}{col}"] as Panel;  // dia da linha

                        // Adiciona cada compromisso do dia
                        foreach (var compromisso in compromissos)
                        {
                            string tipoEvento = compromisso.TipoEvento;
                            string cliente = compromisso.Cliente;

                            Label lblTipoEvento = new myLblCompromisso()
                            {
                                Name = $"LblTipoEvento{row}{col}{pnl!.Controls.Count}", // Garante nomes únicos para cada label
                                BackColor = Color.FromArgb(240, 240, 240),
                                ForeColor = Color.Black,
                                Text = tipoEvento,
                                TextAlign = ContentAlignment.MiddleLeft,
                                Size = new Size(pnl.Width, 20), // Define o tamanho do Label
                                Location = new Point(0, 40 * pnl.Controls.Count) // Ajusta a posição para evitar sobreposição
                            };
                            pnl.Controls.Add(lblTipoEvento);

                            Label lblCliente = new myLblCompromisso()
                            {
                                Name = $"LblCliente{row}{col}{pnl.Controls.Count}", // Garante nomes únicos para cada label
                                BackColor = Color.FromArgb(240, 240, 240),
                                ForeColor = Color.Gray,
                                Text = cliente,
                                TextAlign = ContentAlignment.MiddleLeft,
                                Size = new Size(pnl.Width, 20), // Define o tamanho do Label
                                Location = new Point(0, lblTipoEvento.Location.Y + 20) // Ajusta a posição para evitar sobreposição
                            };
                            pnl.Controls.Add(lblCliente);
                        }
                    }
                }
            }
        }
        //
        // Método para popular dados no calendário
        private void CriarDadosTesteSEMUSO()
        {
            // Remove eventos antigos do calendário
            //RemoverDadosEventos(this);

            // Dicionário para armazenar datas das festas e seus respectivos clientes
            // extrair de tblfestas - fest_dtfesta; fest_tpev;
            // extrair de tblclientes - cli_nome

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
        #endregion
        //

    }// end class
} // namespace

